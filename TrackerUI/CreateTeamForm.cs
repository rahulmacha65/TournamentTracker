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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        ITeamRequestor callingFrom;
        public CreateTeamForm(ITeamRequestor caller)
        {
            InitializeComponent();
            callingFrom = caller;
            WireupList();
        }

        private void WireupList()
        {
            selectTeamMemberDropdown.DataSource = null;
            selectTeamMemberDropdown.DataSource = availableTeamMembers;
            selectTeamMemberDropdown.DisplayMember = "FullName";

            TeamMemberListbox.DataSource = null;
            TeamMemberListbox.DataSource = selectedTeamMembers;
            TeamMemberListbox.DisplayMember = "FullName";
        }

        private void createMemberBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = fnValue.Text;
                p.LastName = lnValue.Text;
                p.Email = emailTextValue.Text;
                p.CellPhoneNumber = cellPhoneNumberValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);
                WireupList();

                fnValue.Text = "";
                lnValue.Text = "";
                emailTextValue.Text = "";
                cellPhoneNumberValue.Text = "";
            }
            else
            {
                MessageBox.Show("Please fill all fields in the Form.");
            }

        }
        private bool ValidateForm()
        {
            if (fnValue.Text.Length == 0)
            {
                return false;
            }
            if (lnValue.Text.Length == 0)
            {
                return false;
            }
            if (emailLabel.Text.Length == 0)
            {
                return false;
            }
            if (cellPhoneLabel.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void addTeamMemberBtn_Click(object sender, EventArgs e)
        {
            if (selectTeamMemberDropdown.SelectedItem!=null)
            {
                PersonModel p = selectTeamMemberDropdown.SelectedItem as PersonModel;
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                WireupList();
            }
            else
            {
                MessageBox.Show("Please select Team member");
            }
        }

        private void deleteSelectedMemberBtn_Click(object sender, EventArgs e)
        {
            if (TeamMemberListbox.SelectedItem!=null)
            {
                PersonModel p = TeamMemberListbox.SelectedItem as PersonModel;
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireupList();
            }
            else
            {
                MessageBox.Show("To Remove Member. Please select a Person.");
            }

        }

        private void createTeamBtn_Click(object sender, EventArgs e)
        {
            TeamModel model = new TeamModel();
            model.TeamName = teamNameValue.Text;
            model.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(model);

            callingFrom.TeamComplete(model);
            this.Close();
        }
    }
}
