using System;
using System.Collections.Generic;
using System.Text;
using ElectronicVotingSystemService;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystemTests
{
    public class DatabaseMock : IDatabaseHelper
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        public DatabaseMock()
        {
            _users.Add("NI-1234", new User()
            {
                NationalInsuranceNumber = "NI-1234",
                Password = "password123",
                AccountType = AccountType.Administrator,
                Authenticated = 1
            });

            _users.Add("NI-Audit", new User()
            {
                NationalInsuranceNumber = "NI-Audit",
                Password = "auditor123",
                AccountType = AccountType.Auditor,
                Authenticated = 1
            });

            _users.Add("NI-Admin", new User()
            {
                NationalInsuranceNumber = "NI-Admin",
                Password = "password456",
                AccountType = AccountType.Administrator,
                Authenticated = 1
            });

            _users.Add("NI-Voter", new User()
            {
                NationalInsuranceNumber = "NI-Voter",
                Password = "1234567890",
                AccountType = AccountType.Voter,
                Authenticated = 1
            });

            _users.Add("1357-NI", new User()
            {
                NationalInsuranceNumber = "1357-NI",
                Password = "password1357",
                AccountType = AccountType.Voter,
                Authenticated = 0
            });
        }

        public List<CountVote> CountVotesForElection(string electionInstanceID)
        {
            throw new NotImplementedException();
        }

        public int CreateNewVote(string electionInstanceID, string candidateID, string userID)
        {
            throw new NotImplementedException();
        }

        public List<Election> GetActiveElections()
        {
            throw new NotImplementedException();
        }

        public List<Election> GetAllElections()
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidateFromElectionIDCandidateName(string electionInstanceID, string candidateName)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetCandidatesFromElection(string electionInstanceID)
        {
            throw new NotImplementedException();
        }

        public Election GetElectionFromElectionID(string electionInstanceID)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string nationalInsuranceNumber, string password)
        {
            if (_users.ContainsKey(nationalInsuranceNumber))
                return _users[nationalInsuranceNumber];
            else
                return null;
        }

        public Vote GetUserVoteFromElection(string electionInstanceID, string userID)
        {
            throw new NotImplementedException();
        }

        public bool HasAdministratorAuthenticatedUser(string nationalInsuranceNumber, string password)
        {
            var user = GetUser(nationalInsuranceNumber, password);
            return user?.Authenticated == 1 ? true : false;
        }

        public bool HasUserVotedForCandidate(string electionInstanceID, string candidateID, string userID)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUserCredentials(string nationalInsuranceNumber, string password)
        {
            return _users.ContainsValue(GetUser(nationalInsuranceNumber, password));
        }

        public int UpdateVote(Vote vote, string candidateID)
        {
            throw new NotImplementedException();
        }
    }
}
