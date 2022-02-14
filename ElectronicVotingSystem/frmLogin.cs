using ElectronicVotingSystemService;
using ElectronicVotingSystemService.Data_Models;
using ElectronicVotingSystem.Dashboards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicVotingSystemService.Authentication;

namespace ElectronicVotingSystem
{
    public partial class frmLogin : Form
    {
        AuthenticationHelper authenticationHelper = new AuthenticationHelper(new DatabaseHelper());
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Not Implemented As A Major Feature...
            // Next Version Will Include This.
            MessageBox.Show("Not Implemented Yet. \n Please try again soon.");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nINumber = txtNationalInsuranceNumber.Text;
            string password = txtPassword.Text;

            // Verify we have data in text boxes. If not then display error.
            bool validCredentials = authenticationHelper.IsValidUserCredentials(nINumber, password);

            if (validCredentials == false)
                MessageBox.Show("Please enter correct National Insurance Number\nAnd a Password to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // Now we have correct login information, we will verify that the user has been authenticated by an admin.
                bool hasUserBeenAuthenticated = authenticationHelper.HasAdminAuthenticatedUser(nINumber, password);

                if (hasUserBeenAuthenticated)
                {
                    Hide();

                    // Get account type of user
                    AccountType accountType = authenticationHelper.GetUserAccountType(nINumber, password);

                    // Display relative dashboards based on user account type.
                    switch (accountType)
                    {
                        // Keep calling authenticationHelper to seperate UI from service functions for added layer of security
                        case AccountType.Administrator:
                            // As only 3 major features implemented, admin currently functions only as a voter.
                            frmVoterDashboard frmAdminDash = new frmVoterDashboard(authenticationHelper.GetUser(nINumber, password));
                            frmAdminDash.ShowDialog();
                            break;
                        case AccountType.Auditor:
                            frmAuditorDashboard frmAuditorDash = new frmAuditorDashboard(authenticationHelper.GetUser(nINumber, password));
                            frmAuditorDash.ShowDialog();
                            break;
                        case AccountType.Voter:
                            frmVoterDashboard frmVoterDash = new frmVoterDashboard(authenticationHelper.GetUser(nINumber, password));
                            frmVoterDash.ShowDialog();
                            break;
                        default:
                            break;
                    }

                    // Reset text fields so when all subsequent forms close, resets login info for security
                    txtNationalInsuranceNumber.Text = "";
                    txtPassword.Text = "";
                    nINumber = "";
                    password = "";

                    Show();
                }
                else    // User has not been authenticated by an admin yet. Display error message.
                    MessageBox.Show("You are pending authentication by an administrator.\nPlease try again soon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // So that the enter key can be used to enter details - ease of user convenience.
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }
    }
}
