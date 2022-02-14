using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicVotingSystemService;
using ElectronicVotingSystemService.Authentication;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystemTests
{
    [TestClass]
    public class VotingSystemTests
    {
        AuthenticationHelper authenticationHelper = new AuthenticationHelper(new DatabaseMock());

        [TestMethod]
        public void GetRealUser()
        {
            var realUser = authenticationHelper.GetUser("NI-1234", "password123");
            Assert.IsNotNull(realUser);
            Assert.AreEqual("NI-1234", realUser.NationalInsuranceNumber);

            var fakeUser = authenticationHelper.GetUser("NI-1234678", "password12345678");
            Assert.IsNull(fakeUser);
            Assert.AreNotEqual("NI-1234678", fakeUser?.NationalInsuranceNumber);
        }

        [TestMethod]
        public void GetValidUserCredential()
        {
            var validCredentials = authenticationHelper.IsValidUserCredentials("NI-Audit", "auditor123");
            Assert.IsTrue(validCredentials);

            var invalidCredentials = authenticationHelper.IsValidUserCredentials("NI-Audit999", "auditor123999");
            Assert.IsFalse(invalidCredentials);
        }

        [TestMethod]
        public void HasAdministratorAuthenticatedUserTrue()
        {
            var hasBeenAuthenticated = authenticationHelper.HasAdminAuthenticatedUser("NI-Voter", "1234567890");
            Assert.IsTrue(hasBeenAuthenticated);

            var hasntBeenAuthenticated = authenticationHelper.HasAdminAuthenticatedUser("1357-NI", "password1357");
            Assert.IsFalse(hasntBeenAuthenticated);

            Assert.AreNotEqual(hasBeenAuthenticated, hasntBeenAuthenticated);
        }

        [TestMethod]
        public void GetUserAccountType()
        {
            var adminAccountType = AccountType.Administrator;
            var voterAccountType = AccountType.Voter;

            var adminUserAccountType = authenticationHelper.GetUserAccountType("NI-1234", "password123");
            Assert.AreEqual(adminAccountType, adminUserAccountType);
            Assert.AreNotEqual(voterAccountType, adminUserAccountType);

            var voterUserAccountType = authenticationHelper.GetUserAccountType("NI-Voter", "1234567890");
            Assert.AreEqual(voterAccountType, voterUserAccountType);
            Assert.AreNotEqual(voterUserAccountType, adminUserAccountType);
        }
    }
}
