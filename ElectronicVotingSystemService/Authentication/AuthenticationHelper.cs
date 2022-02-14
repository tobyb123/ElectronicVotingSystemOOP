using System;
using System.Collections.Generic;
using System.Text;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystemService.Authentication
{
    public class AuthenticationHelper
    {
        private readonly IDatabaseHelper _databaseHelper;

        public AuthenticationHelper(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public User GetUser(string nationalInsuranceNumber, string password)
        {
            return _databaseHelper.GetUser(nationalInsuranceNumber, password);
        }

        public bool IsValidUserCredentials(string nationalInsuranceNumber, string password)
        {
            return _databaseHelper.IsValidUserCredentials(nationalInsuranceNumber, password);
        }

        public bool HasAdminAuthenticatedUser(string nationalInsuranceNumber, string password)
        {
            return _databaseHelper.HasAdministratorAuthenticatedUser(nationalInsuranceNumber, password);
        }

        public AccountType GetUserAccountType(string nINumber, string password)
        {
            return _databaseHelper.GetUser(nINumber, password).AccountType;
        }
    }
}
