using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicVotingSystemService;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystem.Dashboards
{
    public partial class frmAuditorDashboard : Form
    {
        private User _user { get; set; }
        private Election _selectedElection { get; set; }

        IDatabaseHelper databaseHelper = new DatabaseHelper();
        public frmAuditorDashboard(User user)
        {
            InitializeComponent();

            // Set user to be accessed from all parts of code in dashboard.
            _user = user;

            lblName.Text = _user.FullName;

            // Get every election in databse regardless of start and end times.
            List<Election> elections = databaseHelper.GetAllElections();

            if (elections != null)
            {
                // If we have active elections - display the data within the listBox control.
                lsbxElections.DataSource = elections;
                lsbxElections.DisplayMember = "ElectionName";
                lsbxElections.ValueMember = "ElectionInstanceID";
            }
        }

        private void lsbxElections_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear out the previous selected elections votes
            dgvVoteCount.DataSource = null;

            // Sets the selected election value so code doesn't have to be repeated to get the Election object Type from its ID.
            if (lsbxElections.SelectedValue.GetType() == typeof(Election))
                _selectedElection = (Election)lsbxElections.SelectedValue;
            else
                _selectedElection = databaseHelper.GetElectionFromElectionID(lsbxElections.SelectedValue.ToString());

            // Set vote count data of election in the UI control on dashboard
            SetVoteCountInTable();
        }

        /// <summary>
        /// Sets the data source of data grid view control to display vote count for selected election.
        /// </summary>
        private void SetVoteCountInTable()
        {
            if (_selectedElection != null)
            {
                // If we have votes for election - populate the control on the dashboard - if not then clear the grid view.
                List<CountVote> countVote = databaseHelper.CountVotesForElection(_selectedElection.ElectionInstanceID);
                dgvVoteCount.DataSource = countVote?.Count >= 1 == true ? countVote : null;
            }
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            // Open voting dashboard and let user vote.
            frmVoterDashboard frmVoterDash = new frmVoterDashboard(_user);
            frmVoterDash.TopMost = true;
            frmVoterDash.BringToFront();
            frmVoterDash.ShowDialog();

            // After the user has or hasn't voted - refresh the votes count control to be populated with new results.
            SetVoteCountInTable();
        }
    }
}
