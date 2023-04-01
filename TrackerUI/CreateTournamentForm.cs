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

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form,IPrizeRequestor, ITeamRequestor
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            TeamWireupList();
        }

        private void TeamWireupList()
        {
            selectTeamDropdown.DataSource = null;
            selectTeamDropdown.DataSource = availableTeams;
            selectTeamDropdown.DisplayMember = "TeamName";

            TournamentPlayerListBox.DataSource = null;
            TournamentPlayerListBox.DataSource = selectedTeams;
            TournamentPlayerListBox.DisplayMember = "TeamName";

            PrizesListBox.DataSource = null;
            PrizesListBox.DataSource = selectedPrizes;
            PrizesListBox.DisplayMember = "PlaceName";
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addTeamBtn_Click(object sender, EventArgs e)
        {
            if (selectTeamDropdown.SelectedItem != null)
            {
                TeamModel p = selectTeamDropdown.SelectedItem as TeamModel;
                availableTeams.Remove(p);
                selectedTeams.Add(p);
                TeamWireupList();

            }
            else
            {
                MessageBox.Show("Please select Team Name.");
            }
        }

        private void deleteSelectedPlayerBtn_Click(object sender, EventArgs e)
        {
            if (TournamentPlayerListBox.SelectedItems != null)
            {
                TeamModel tm = TournamentPlayerListBox.SelectedItem as TeamModel;
                availableTeams.Add(tm);
                selectedTeams.Remove(tm);
                TeamWireupList();

            }
            else
            {
                MessageBox.Show("Please select Team/Player List.");
            }
        }

        private void createPrizeBtn_Click(object sender, EventArgs e)
        {
            //call the createPrizeForm
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            TeamWireupList();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm team = new CreateTeamForm(this);
            team.Show();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            TeamWireupList();
        }

        private void deleteSelctedPrize_Click(object sender, EventArgs e)
        {
            if (PrizesListBox.SelectedItem != null)
            {
                PrizeModel P = PrizesListBox.SelectedItem as PrizeModel;
                selectedPrizes.Remove(P);
                TeamWireupList();
            }
        }
    }
}
