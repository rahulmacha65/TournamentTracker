using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "tournaments";
        //TODO- Make the createPrize method actually save to the database
        /// <summary>
        /// Saves a new prize to the database.
        /// </summary>
        /// <param name="model">The prize infomration.</param>
        /// <returns>The prize information. including the unique Identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SqlCommand cmd = new SqlCommand("dbo.spPrizes_Insert",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlaceNumber", model.PlaceNumber);
                cmd.Parameters.AddWithValue("@PlaceName", model.PlaceName);
                cmd.Parameters.AddWithValue("@PrizeAmount", model.PriceAmount);
                cmd.Parameters.AddWithValue("@PrizePercentage", model.PricePercentage);
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["@id"].Value;
                    model.ID = id;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db))) 
            { 
                SqlCommand cmd = new SqlCommand("dbo.spPerson_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@CellPhoneNumber", model.CellPhoneNumber);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["@Id"].Value;
                    model.Id = id;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> personsList = new List<PersonModel>();
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SqlCommand cmd = new SqlCommand("spPeopel_All", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();

                try
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    foreach(DataRow dr in table.Rows)
                    {
                        PersonModel model = new PersonModel();
                        model.Id = Int32.Parse(dr["Id"].ToString());
                        model.FirstName = dr["FirstName"].ToString();
                        model.LastName = dr["LastName"].ToString();
                        model.Email = dr["EmailAddress"].ToString();
                        model.CellPhoneNumber = dr["CellPhoneNumber"].ToString();
                        personsList.Add(model);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return personsList;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using(SqlConnection con  =new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SqlCommand cmd = new SqlCommand("dbo.spTeam_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamName", model.TeamName);
                SqlParameter pram = new SqlParameter("@id", SqlDbType.Int);
                pram.Direction = ParameterDirection.Output;    
                cmd.Parameters.Add(pram);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    model.Id = (int)cmd.Parameters["@id"].Value;
                    foreach(PersonModel tm in model.TeamMembers)
                    {
                        SqlCommand cmd1 = new SqlCommand("dbo.spTeamMembers_Insert", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@TeamId", model.Id);
                        cmd1.Parameters.AddWithValue("@PersonId", tm.Id);
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> teamList = new List<TeamModel>();
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SqlCommand cmd = new SqlCommand("dbo.spTeam_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                DataTable table1 = new DataTable();
                try
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                    foreach (DataRow dr in table.Rows)
                    {
                        TeamModel model = new TeamModel();
                        model.Id = Int32.Parse(dr["Id"].ToString());
                        model.TeamName = dr["TeamName"].ToString();
                        SqlCommand cmd1 = new SqlCommand("dbo.spTeamMembers_GetByTeam", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@TeamId", model.Id);

                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(table1);
                        foreach(DataRow dr1 in table1.Rows)
                        {
                            List<PersonModel> pModelList = new List<PersonModel>();
                            pModelList.Add(new PersonModel()
                            {
                                Id = Int32.Parse(dr1["Id"].ToString()),
                                FirstName = dr1["FirstName"].ToString(),
                                LastName = dr1["LastName"].ToString(),
                                Email = dr1["EmailAddress"].ToString(),
                                CellPhoneNumber = dr1["CellPhoneNumber"].ToString()
                            });
                            model.TeamMembers = pModelList;
                        }
                        teamList.Add(model);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return teamList;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                try
                {
                    SaveTournament(con, model);
                    SaveTournamentPrizes(con, model);
                    SaveTournamentTeamEntries(con, model);
                    SaveTournamentRounds(con, model);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return model;
        }
        private void SaveTournament(SqlConnection con,TournamentModel model)
        {
            SqlCommand cmd = new SqlCommand("dbo.spTournaments_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TournamentName", model.TournamentName);
            cmd.Parameters.AddWithValue("@EntryFee", model.EntryFee);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            model.Id =  (int)cmd.Parameters["@Id"].Value;
        }
        private void SaveTournamentPrizes(SqlConnection con, TournamentModel model)
        {
            foreach (PrizeModel p in model.Prizes)
            {
                SqlCommand cmd1 = new SqlCommand("dbo.spTournamentPrizes_Insert", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@TournamentId", model.Id);
                cmd1.Parameters.AddWithValue("@PrizeId", p.ID);
                cmd1.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();
            }
        }
        private void SaveTournamentTeamEntries(SqlConnection con,TournamentModel model)
        {
            foreach (TeamModel tm in model.EnteredTeams)
            {
                SqlCommand cmd2 = new SqlCommand("dbo.spTournamentEntries_Insert", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@TournamentId", model.Id);
                cmd2.Parameters.AddWithValue("@TeamId", tm.Id);
                cmd2.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd2.ExecuteNonQuery();
            }
        }
        private void SaveTournamentRounds(SqlConnection con, TournamentModel model)
        {
            //Loop through the rounds
            //Loop through the Matchups
            //Save the Matchup in DB
            //Loop through the entries and save in DB
            
            foreach (List<MatchUpModel> round in model.Rounds)
            {
                foreach(MatchUpModel matchup in round)
                {
                    SqlCommand cmd = new SqlCommand("dbo.spMatchups_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TournamentId", model.Id);
                    cmd.Parameters.AddWithValue("@MatchupRound", matchup.MatchupRound);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    matchup.Id = (int)cmd.Parameters["@Id"].Value;
                     
                    foreach(MatchUpEntryModel entry in matchup.Entries)
                    {
                        SqlCommand cmd1 = new SqlCommand("dbo.spMatchupEntries_Insert", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@MatchupId",matchup.Id);
                        if (entry.ParentMatchUp != null)
                        {
                            cmd1.Parameters.AddWithValue("@ParentMatchupId", entry.ParentMatchUp.Id);
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@ParentMatchupId", 0);//@ParentMatchupId
                        }
                        if (entry.TeamCompeting!=null)
                        {
                            cmd1.Parameters.AddWithValue("@TeamCompetingId", entry.TeamCompeting.Id);
                        }
                        else
                        {
                            cmd1.Parameters.AddWithValue("@TeamCompetingId", 0);
                        }
                        cmd1.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd1.ExecuteNonQuery();
                        entry.Id = (int)cmd1.Parameters["@Id"].Value;
                    }
                }
            }
        }

        public List<TournamentModel> GetTournament_All()
        {
            List<TournamentModel> tournament = new List<TournamentModel>();
            
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SqlCommand cmd = new SqlCommand("spTournament_All", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();

                try
                {
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    ad.Fill(table);
                     
                    foreach (DataRow dr in table.Rows)
                    {
                        TournamentModel model = new TournamentModel();
                        model.Id = Int32.Parse(dr["Id"].ToString());
                        model.TournamentName = dr["TournamentName"].ToString();
                        model.EntryFee = Decimal.Parse(dr["EntryFee"].ToString());
                        tournament.Add(model);
                    }
                    //populate prizes
                    foreach (TournamentModel t in tournament)
                    {
                        SqlCommand cmd1 = new SqlCommand("spPrizes_GetByTournament", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@TournamentId", t.Id);
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        da.Fill(dt2);
                        foreach(DataRow dr in dt2.Rows)
                        {
                            PrizeModel p = new PrizeModel();
                            p.ID = Int32.Parse(dr["Id"].ToString());
                            p.PlaceNumber = Int32.Parse(dr["PlaceNumber"].ToString());
                            p.PlaceName = dr["PlaceName"].ToString();
                            p.PriceAmount = Decimal.Parse(dr["PrizeAmount"].ToString());
                            p.PricePercentage = Double.Parse(dr["PrizePercentage"].ToString());
                            t.Prizes.Add(p);

                        }
                        //populate Teams
                        SqlCommand cmd2 = new SqlCommand("spTeam_GetByTournament",con);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@TournamentId", t.Id);
                        DataTable dt3 = new DataTable();
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                        da1.Fill(dt3);
                        foreach(DataRow dr in dt3.Rows)
                        {
                            TeamModel tm = new TeamModel();
                            tm.Id = Int32.Parse(dr["Id"].ToString());
                            tm.TeamName = dr["TeamName"].ToString();
                            t.EnteredTeams.Add(tm);
                            SqlCommand cmd3 = new SqlCommand("dbo.spTeamMembers_GetByTeam", con);
                            cmd3.CommandType = CommandType.StoredProcedure;
                            cmd3.Parameters.AddWithValue("@TeamId", tm.Id);
                            DataTable dt5 = new DataTable();
                            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                            da3.Fill(dt5);
                            foreach (DataRow dr1 in dt5.Rows)
                            {
                                PersonModel pModelList = new PersonModel();
                                pModelList.Id = Int32.Parse(dr1["Id"].ToString());
                                pModelList.FirstName = dr1["FirstName"].ToString();
                                pModelList.LastName = dr1["LastName"].ToString();
                                pModelList.Email = dr1["EmailAddress"].ToString();
                                pModelList.CellPhoneNumber = dr1["CellPhoneNumber"].ToString();
                                tm.TeamMembers.Add(pModelList);
                            }
                        }

                        //Populate Rounds

                        SqlCommand cmd4 = new SqlCommand("spMatchup_GetByTournament", con);
                        cmd4.CommandType = CommandType.StoredProcedure;
                        cmd4.Parameters.AddWithValue("@TournamentId", t.Id);
                        DataTable dt4 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd4);
                        da2.Fill(dt4);
                        List<MatchUpModel> matchups = new List<MatchUpModel>();
                        foreach (DataRow dr in dt4.Rows)
                        {
                            int winId = 0;
                            MatchUpModel mp = new MatchUpModel();
                            mp.Id = Int32.Parse(dr["Id"].ToString());//dr["WinnerId"]
                            if(Int32.TryParse(dr["WinnerId"].ToString(),out winId)){
                                mp.WinnerId = winId;
                            }
                            mp.MatchupRound = Int32.Parse(dr["MatchupRound"].ToString());
                            matchups.Add(mp);
                            foreach (MatchUpModel m in matchups)
                            {
                                SqlCommand cmd5 = new SqlCommand("spMatchupEntries_GetByMatchup", con);
                                cmd5.CommandType = CommandType.StoredProcedure;
                                cmd5.Parameters.AddWithValue("@MatchupId",m.Id);
                                DataTable dt6 = new DataTable();
                                SqlDataAdapter da3 = new SqlDataAdapter(cmd5);
                                da3.Fill(dt6);
                                foreach(DataRow dr1 in dt6.Rows)
                                {
                                    double points = 0.0;
                                    MatchUpEntryModel me = new MatchUpEntryModel();
                                    me.Id = Int32.Parse(dr1["Id"].ToString());
                                    if(Double.TryParse(dr1["Score"].ToString(),out points))
                                    {
                                        me.Score = points;
                                    };
                                    me.ParentMatchUpId = Int32.Parse(dr1["ParentMatchupId"].ToString());
                                    me.TeamCompetingId = Int32.Parse(dr1["TeamCompetingId"].ToString());
                                    m.Entries.Add(me);
                                    List<TeamModel> allTeams = GetTeam_All();
                                    //POPULATE EACH MATCHUP (1 MODEL)
                                    if (m.WinnerId > 0)
                                    {
                                        m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                                    }
                                    //POPULATE EACH ENTRY (2 MODEL)
                                    foreach (MatchUpEntryModel m2 in m.Entries)
                                    {
                                        if (m2.TeamCompetingId > 0)
                                        {
                                            m2.TeamCompeting = allTeams.Where(x => x.Id == m2.TeamCompetingId).First();
                                        }
                                        if (m2.ParentMatchUpId > 0)
                                        {
                                            m2.ParentMatchUp = matchups.Where(x => x.Id == m2.ParentMatchUpId).First();
                                        }
                                    }
                                }
                            }
                        }
                        //List<List<MatchupModel>>
                        List<MatchUpModel> currRow = new List<MatchUpModel>();
                        int currRound = 1;
                        foreach (MatchUpModel m in matchups)
                        {
                            if (m.MatchupRound > currRound)
                            {
                                t.Rounds.Add(currRow);
                                currRow = new List<MatchUpModel>();
                                currRound++;
                            }
                            currRow.Add(m);
                        }
                        t.Rounds.Add(currRow);

                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return tournament;
        }

        public void UpdateMatchUpModel(MatchUpModel model)
        {
            using (SqlConnection con = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spMatchups_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                if (model.Winner != null)
                {
                    cmd.Parameters.AddWithValue("@WinnerId", model.Winner.Id);
                    cmd.ExecuteNonQuery();
                }

                foreach(MatchUpEntryModel entry in model.Entries)
                {
                    SqlCommand cmd1 = new SqlCommand("spMatchEntries_Update", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Id", entry.Id);
                    if (entry.TeamCompeting != null)
                    {
                        cmd1.Parameters.AddWithValue("@TeamCompetingId", entry.TeamCompeting.Id);
                        cmd1.Parameters.AddWithValue("@Score", entry.Score);
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
