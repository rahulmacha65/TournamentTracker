using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        List<string> rounds = new List<string>();
        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            this.tournament = tournamentModel;
            SetupViewPage();
        }

        private void SetupViewPage()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void LoadRound()
        {

        }
        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
