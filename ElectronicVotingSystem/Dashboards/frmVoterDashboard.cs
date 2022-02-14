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
    public partial class frmVoterDashboard : Form
    {
        private User _user;
        private Election _selectedElection;
        private Candidate _selectedCandidate;

        IDatabaseHelper databaseHelper = new DatabaseHelper();

        public frmVoterDashboard(User user)
        {
            InitializeComponent();

            // Set user to be accessed from all parts of code in dashboard.
            _user = user;

            lblName.Text = _user.FullName;

            // Get elections where start and end date are within todays date range.
            List<Election> elections = databaseHelper.GetActiveElections();

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
            // Clear out the previous selected elections candidates 
            chklbVotes.Items.Clear();

            // Sets the selected election value so code doesn't have to be repeated to get the Election object Type from its ID.
            if (lsbxElections.SelectedValue.GetType() == typeof(Election))
                _selectedElection = (Election)lsbxElections.SelectedValue;
            else
                _selectedElection = databaseHelper.GetElectionFromElectionID(lsbxElections.SelectedValue.ToString());

            List<Candidate> candidates = databaseHelper.GetCandidatesFromElection(_selectedElection.ElectionInstanceID != null ? _selectedElection.ElectionInstanceID : "");

            if (candidates != null)
            {
                // Now we have candidates available to vote for in the election - see if the user has already voted for any candidate in the election.
                bool hasUserVotedForCandidate = false;
                foreach (var candidate in candidates)
                {
                    hasUserVotedForCandidate = databaseHelper.HasUserVotedForCandidate(_selectedElection.ElectionInstanceID, candidate.CandidateID, _user.UserID);
                    if (hasUserVotedForCandidate)
                    {
                        // If user has already voted, set candidate to the dashboards currently selected candidate.
                        _selectedCandidate = candidate;
                    }

                    // If user has voted for candidate, make sure they are checked by default.
                    chklbVotes.Items.Add(candidate.CandidateName, hasUserVotedForCandidate);
                }
            }
        }

        private void chklbVotes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // This makes it so only 1 checkbox can be selected at a time.
            if (e.NewValue == CheckState.Checked && chklbVotes.CheckedItems.Count > 0)
            {
                chklbVotes.ItemCheck -= chklbVotes_ItemCheck;
                chklbVotes.SetItemChecked(chklbVotes.CheckedIndices[0], false);
                chklbVotes.ItemCheck += chklbVotes_ItemCheck;
            }

            // If a candidate has been selected - store them as currently selected.
            // If it has been deselected - store as null so program knows vote has been revoked.
            if (e.NewValue == CheckState.Checked)
                _selectedCandidate = databaseHelper.GetCandidateFromElectionIDCandidateName(_selectedElection.ElectionInstanceID, chklbVotes.Items[e.Index].ToString());
            else
                _selectedCandidate = null;
        }

        private void btnCastVote_Click(object sender, EventArgs e)
        {
            // If user has previosuly voted in the election, it will be stored as variable vote.
            Vote vote = databaseHelper.GetUserVoteFromElection(_selectedElection.ElectionInstanceID, _user.UserID);

            // If no voteshave been selected and there are candidates listed - must be a revoke vote.
            if (chklbVotes.CheckedItems.Count == 0 && chklbVotes.Items.Count > 1 && _selectedCandidate == null && _selectedElection != null)
            {
                if (vote != null)
                {
                    // If we previously had a vote, and none is selected, ask them if they are sure they want to revoke. If yes , revoke.
                    DialogResult result = MessageBox.Show("Are you sure you wish to revoke vote from election?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        int rowsAffected = databaseHelper.UpdateVote(vote, "");

                        // Confirms that the vote has been revoked back to user so they don't try do it again.
                        MessageBox.Show($"{rowsAffected} vote(s) revoked.", "", MessageBoxButtons.OK);
                    }
                }
                else   // If they don't have a previous vote in election , they can't remove a vote that isn't there.
                    MessageBox.Show("You have no registered vote to remove from the election.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chklbVotes.CheckedItems.Count > 1)
            {
                // Shouldn't be able to select more than 1 - just in case added for security of vote count validation
                MessageBox.Show("You can only vote for 1 candidate per election.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chklbVotes.CheckedItems.Count == 1 && _selectedCandidate != null && _selectedElection != null)
            {
                // We have got 1 candidate selected and an active election selected. Create or update vote.
                int rowsAffected = 0;

                if (vote == null)
                {
                    // If we had no previous vote for user in election - must be creating a vote.
                    rowsAffected = databaseHelper.CreateNewVote(_selectedElection.ElectionInstanceID, _selectedCandidate.CandidateID, _user.UserID);
                    MessageBox.Show($"{rowsAffected} vote(s) created.", "", MessageBoxButtons.OK);
                }
                else
                {
                    // If we had a previous vote for user in election - must want to update vote.
                    rowsAffected = databaseHelper.UpdateVote(vote, _selectedCandidate.CandidateID);
                    MessageBox.Show($"{rowsAffected} vote(s) updated.", "", MessageBoxButtons.OK);
                }
            }
            else
            {
                // For added user security and robustness - should never be hit but just in case display an error.
                MessageBox.Show("An unexpected error has occurred.\nMake sure an election and only 1 candidate is selected.\nIf problem persists, please reboot the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
