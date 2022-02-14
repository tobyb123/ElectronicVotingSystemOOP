using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystem.Dashboards
{
    public partial class frmAdministratorDashboard : Form
    {
        private User _user { get; set; }
        public frmAdministratorDashboard(User user)
        {
            InitializeComponent();
            _user = user;


        }
    }
}
