using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        List<int> rounds = new List<int>();
        List<MatchUpModel> selectedMatchups = new List<MatchUpModel>();

        BindingSource roundsBinding = new BindingSource();
        BindingSource matchupBinding = new BindingSource();
        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            
            this.tournament = tournamentModel;
            tournament.OnTournamentComplete += Tournament_OnTournamentComplete;
            SetupViewPage();
            LoadRounds();
        }

        private void Tournament_OnTournamentComplete(object sender, DateTime e)
        {
            this.Close();
        }

        private void SetupViewPage()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void LoadRounds()
        {
            rounds.Add(1);
            int currRound = 1;
            foreach(List<MatchUpModel> matchups  in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }
            //roundDropdown.DataSource = null;
            roundsBinding.DataSource = rounds;
            roundDropdown.DataSource = roundsBinding;
        }
        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void roundDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchUps();
        }
        private void LoadMatchUps()
        {
            int round = (int)roundDropdown.SelectedItem;
            foreach(List<MatchUpModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound == round)
                {
                    selectedMatchups = matchups;
                }
            }
            //MatchupListBox.DataSource = null;
            matchupBinding.DataSource = selectedMatchups;
            MatchupListBox.DataSource = matchupBinding;
            MatchupListBox.DisplayMember = "DisplayName";
            LoadMatchUpDetails((MatchUpModel)MatchupListBox.SelectedItem);
        }

        private void LoadMatchUpDetails(MatchUpModel model)
        {
            MatchUpModel m = model;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName.ToString();
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoName.Text = "<Bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneName.Text = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName.ToString();
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoName.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void MatchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchUpDetails((MatchUpModel)MatchupListBox.SelectedItem);
        }


        private void ScoreBtn_Click(object sender, EventArgs e)
        {
            int startingRound = CheckCurrentRound(tournament);
            MatchUpModel m = (MatchUpModel)MatchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName.ToString();
                        if(Double.TryParse(teamOneScoreValue.Text, out teamOneScore))
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid Team 1 Score");
                            return;
                        }
                        
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoName.Text = m.Entries[0].TeamCompeting.TeamName.ToString();
                        if (Double.TryParse(teamTwoScoreValue.Text, out teamTwoScore))
                        {
                            m.Entries[0].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid Team 2 Score");
                            return;
                        }
                    }
                }
            }
            if(teamOneScore> teamTwoScore)
            {
                m.Winner = m.Entries[0].TeamCompeting;
                MessageBox.Show("Team 1 Winner");
            }
            else if(teamOneScore < teamTwoScore)
            {
                m.Winner = m.Entries[1].TeamCompeting;
                MessageBox.Show("Team 2 Winner");
            }
            else
            {
                MessageBox.Show("I Don't Handle Ties");
            }
            GlobalConfig.Connection.UpdateMatchUpModel(m);
            int endingRound = CheckCurrentRound(tournament);
            if(endingRound > startingRound)
            {
                AlertUsersToNewRound(tournament);
            }
        }

        private  void AlertUsersToNewRound(TournamentModel model)
        {
            int currentRoundNumber = CheckCurrentRound(model);
            List<MatchUpModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach(MatchUpModel matchups in currentRound)
            {
                foreach(MatchUpEntryModel me in matchups.Entries)
                {
                    foreach(PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNewRound(p, me.TeamCompeting.TeamName,matchups.Entries.Where(x=>x.TeamCompeting!=me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }
        private void AlertPersonToNewRound(PersonModel p,string teamName, MatchUpEntryModel competitor)
        {
            string fromAddress = GlobalConfig.SenderEmail("senderEmail");
            string to = "";
            string subject = "";
            
            StringBuilder body = new StringBuilder();
            if (competitor !=null)
            {
                subject = $"You have a new matchup with {competitor.TeamCompeting.TeamName}";
                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.AppendLine(competitor.TeamCompeting.TeamName);
                body.AppendLine(Environment.NewLine);
                body.AppendLine(Environment.NewLine);
                body.AppendLine("Have a great time!!");
                body.AppendLine("~Tournament Organizers");
            }
            else
            {
                subject = $"You have bye week in this round";
                body.AppendLine("Enjoy your round off!");
                body.AppendLine("~Tournament Organizers");
            }
            to = p.Email; 


            EmailService.SendEmail(fromAddress, to, subject, body.ToString());
        }
        private int CheckCurrentRound(TournamentModel model)
        {
            int output = 1;
            foreach (List<MatchUpModel> m in model.Rounds)
            {
                if (m.All(x => x.Winner != null))
                {
                    output++;
                }
                else
                {
                    return output;
                }
            }
            TournamentCompleted(model);
            return output - 1;
        }
        private void TournamentCompleted(TournamentModel model)
        {
            GlobalConfig.Connection.CompleteTournament(model);
            TeamModel winner = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winner).First().TeamCompeting;
            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;
            if (model.Prizes.Count > 0)
            {
                decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;

                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();
                if (firstPlacePrize != null)
                {
                    winnerPrize = CalculatePrizePayout(model.Prizes[0], totalIncome);
                }
                if(secondPlacePrize != null)
                {
                    runnerUpPrize = CalculatePrizePayout(model.Prizes[1], totalIncome);
                }
            }

            //send Winner Email to All Teams
            string fromAddress = GlobalConfig.SenderEmail("senderEmail");
            List<string> to = new List<string>();
            List<string> bcc = new List<string>();
            string subject = "";

            StringBuilder body = new StringBuilder();
            subject = $"In {model.TournamentName}, {winner.TeamName} has Won!";
            body.AppendLine("<h1>We have a WINNER!</h1>");
            body.Append("<p> Congratulations to our Winner in a great Tournament.</p>");
            if (winnerPrize > 0)
            {
                body.AppendLine($"<p>{winner.TeamName} will receive {winnerPrize}</p>");
            }
            if (runnerUpPrize > 0)
            {
                body.AppendLine($"<p>{runnerUp.TeamName} will receive {runnerUpPrize}</p>");
            }
            body.AppendLine("<p> Thank You for a great Tournament!! </p>");
            body.AppendLine("~Tournament Organizers");


            foreach(TeamModel t in model.EnteredTeams)
            {
                foreach(PersonModel p in t.TeamMembers)
                {
                    if (p.Email.Length > 0)
                    {
                        bcc.Add(p.Email);
                    }
                }
            }

            EmailService.SendEmail(fromAddress, to, subject, body.ToString(),bcc);

            model.TournamentComplete();
        }
        private decimal CalculatePrizePayout(PrizeModel prize,decimal totalIncome)
        {
            decimal output = 0;
            if (prize.PriceAmount > 0)
            {
                output = prize.PriceAmount;
            }
            else
            {
                output = Decimal.Multiply(totalIncome, Convert.ToDecimal(prize.PricePercentage / 100));
            }
            return output;
        }
    }
}
