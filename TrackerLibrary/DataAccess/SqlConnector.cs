using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}
