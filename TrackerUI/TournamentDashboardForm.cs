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
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();
        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }

        private void WireUpLists()
        {
            loadTournamentDropdown.DataSource = tournaments;
            loadTournamentDropdown.DisplayMember = "TournamentName";
        }
        private void loadTournamentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createTournamentBtn_Click(object sender, EventArgs e)
        {
            CreateTournamentForm Cform = new CreateTournamentForm();
            Cform.Show();
        }

        private void loadTournamentBtn_Click(object sender, EventArgs e)
        {
            TournamentModel model = (TournamentModel)loadTournamentDropdown.SelectedItem;
            TournamentViewerForm viewer = new TournamentViewerForm(model);
            viewer.Show();
        }
    }
}
