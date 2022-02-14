using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using ElectronicVotingSystemService.Data_Models;

namespace ElectronicVotingSystemService
{
    /// <summary>
    /// Helper Service to Write/Read from the SQLite database
    /// </summary>
    public class DatabaseHelper : IDatabaseHelper
    {
        /// <summary>
        /// Get connection string for SQLite database.
        /// </summary>
        /// <returns>Connection String for SQLite database stored in the App.Config file</returns>
        private string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        /// <summary>
        /// Returns user from database if admin has verifired them
        /// </summary>
        /// <param name="nationalInsuranceNumber"></param>
        /// <param name="password"></param>
        /// <returns>Instance of user if they have correct credentials and have been authenticated</returns>
        public User GetUser(string nationalInsuranceNumber, string password)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [User] WHERE NationalInsuranceNumber = '{nationalInsuranceNumber}'" +
                    $" AND Password = '{password}'";

                var output = connection.Query<User>(sqlQ, new DynamicParameters());

                if (output.Count() == 1)
                    return output.ToList()[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Does user credentials exist in database
        /// </summary>
        /// <param name="nationalInsuranceNumber"></param>
        /// <param name="password"></param>
        /// <returns>True or Fasle if user credentials exist in the database</returns>
        public bool IsValidUserCredentials(string nationalInsuranceNumber, string password)
        {
            // Verify we have more than just an empty string before establishing connection to database.
            if (string.IsNullOrEmpty(nationalInsuranceNumber) || string.IsNullOrWhiteSpace(nationalInsuranceNumber)
                || string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password))
                return false;

            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT NationalInsuranceNumber, Password FROM [User] WHERE NationalInsuranceNumber = '{nationalInsuranceNumber}' AND Password = '{password}'";

                var output = connection.Query<User>(sqlQ);

                return output.Count() == 1 ? true : false;
            }
        }

        public bool HasAdministratorAuthenticatedUser(string nationalInsuranceNumber, string password)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT Authenticated FROM [User] WHERE NationalInsuranceNumber = '{nationalInsuranceNumber}'" +
                    $" AND Password = '{password}' AND Authenticated = '1'";

                var output = connection.Query<int>(sqlQ);

                return output.ToList()[0] == 1 ? true : false;
            }
        }

        /// <summary>
        /// Gets all elections in database regardless of start and end times
        /// </summary>
        /// <returns>List of Instances of Election objects from the database</returns>
        public List<Election> GetAllElections()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT DISTINCT * from [Election]";

                var output = connection.Query<Election>(sqlQ, new DynamicParameters());

                if (output.Count() >= 1)
                    return output.ToList();
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns an election based on the ElectionInstanceID
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <returns>Returns an instance of the election object based on its ElectionInstanceID from the database</returns>
        public Election GetElectionFromElectionID(string electionInstanceID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [Election] WHERE ElectionInstanceID = '{electionInstanceID}'";

                var output = connection.Query<Election>(sqlQ, new DynamicParameters());

                if (output.Count() == 1)
                    return output.ToList()[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns candidate based on ElectionInstanceID and Candidate Name
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <param name="candidateName"></param>
        /// <returns>Candidate object from the database based on their ElectionInstanceId and CandidateName</returns>
        public Candidate GetCandidateFromElectionIDCandidateName(string electionInstanceID, string candidateName)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [Candidate] WHERE ElectionInstanceID = '{electionInstanceID}' AND CandidateName = '{candidateName}'";

                var output = connection.Query<Candidate>(sqlQ, new DynamicParameters());

                if (output.Count() == 1)
                    return output.ToList()[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns all elections where todays date is within start and end date ranges.
        /// </summary>
        /// <returns>List of election objects where todays date is after start and before election end date</returns>
        public List<Election> GetActiveElections()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT DISTINCT ElectionName, ElectionInstanceID from [Election] WHERE ElectionStartDate < DATETIME('now') and ElectionEndDate > DATETIME('now')";

                var output = connection.Query<Election>(sqlQ, new DynamicParameters());

                if (output.Count() >= 1)
                    return output.ToList();
                else
                    return null;
            }
        }

        /// <summary>
        /// Returns list of candidates registered to an eleciton
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <returns>List of candidate objects based on ElectionInstanceID</returns>
        public List<Candidate> GetCandidatesFromElection(string electionInstanceID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [Candidate] WHERE ElectionInstanceID = '{electionInstanceID}'";

                var output = connection.Query<Candidate>(sqlQ, new DynamicParameters());

                if (output.Count() >= 1)
                    return output.ToList();
                else
                    return null;
            }
        }

        /// <summary>
        /// Will return candidate from vote table based on election and user
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <returns>Candidate if they have voted, or null if they haven't</returns>
        public Vote GetUserVoteFromElection(string electionInstanceID, string userID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [Vote] WHERE ElectionInstanceID = '{electionInstanceID}' AND UserID = '{userID}'";

                var output = connection.Query<Vote>(sqlQ, new DynamicParameters());

                if (output.Count() >= 1)
                    return output.ToList()[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Creates a new vote and adds it to the Vote table in the database
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <param name="candidateID"></param>
        /// <param name="userID"></param>
        /// <returns>How many rows were entered. 0 for error, 1 for success</returns>
        public int CreateNewVote(string electionInstanceID, string candidateID, string userID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                Vote vote = new Vote()
                {
                    UserID = userID,
                    CandidateID = candidateID,
                    VoteCreatedDate = DateTime.Now,
                    VoteUpdatedDate = DateTime.Now,
                    ElectionInstanceID = electionInstanceID
                };

                string sqlQ = $"INSERT INTO [Vote] (UserID, CandidateID, VoteCreatedDate, VoteUpdatedDate, ElectionInstanceID)" +
                    $" VALUES (@UserID, @CandidateID, @VoteCreatedDate, @VoteUpdatedDate, @ElectionInstanceID)";

                var output = connection.Execute(sqlQ, vote);

                return output;
            }
        }

        /// <summary>
        /// Updates vote already in the database based on UserID and ElectionInstanceID - updates VoteUpdatedDate in db
        /// </summary>
        /// <param name="vote"></param>
        /// <param name="candidateID"></param>
        /// <returns>How many rows were updated. 0 for error, 1 for success</returns>
        public int UpdateVote(Vote vote, string candidateID)
        {
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                // If user has revoked the vote set candidate id to be SQL type null
                // If user updates vote, append candidate id in ' for SQL string
                if (string.IsNullOrEmpty(candidateID) || string.IsNullOrWhiteSpace(candidateID))
                    candidateID = "NULL";
                else
                    candidateID = $"'{candidateID}'";

                string sqlQ = $"UPDATE [VOTE] SET CandidateID = {candidateID}, VoteUpdatedDate = DATETIME('now')" +
                $" WHERE UserID = '{vote.UserID}' AND VoteInstanceID = '{vote.VoteInstanceID}' AND ElectionInstanceID = '{vote.ElectionInstanceID}'";

                int output = connection.Execute(sqlQ, new DynamicParameters());

                return output;
            }
        }

        /// <summary>
        /// Used to see if user has voted for a candidate in election so it can be (un)/ticked in UI control
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <param name="candidateID"></param>
        /// <param name="userID"></param>
        /// <returns>True or False if user has votedfor candidate in election</returns>
        public bool HasUserVotedForCandidate(string electionInstanceID, string candidateID, string userID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"SELECT * FROM [Vote] WHERE ElectionInstanceID = '{electionInstanceID}' AND CandidateID = '{candidateID}' AND UserID = '{userID}'";

                var output = connection.Query<Candidate>(sqlQ, new DynamicParameters());

                if (output.Count() == 1)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        ///  Counts the votes for each candidate in election based on ElectionInstanceID
        /// </summary>
        /// <param name="electionInstanceID"></param>
        /// <returns>List of CountVote object from database if there are votes in the election. Null if there are no votes.</returns>
        public List<CountVote> CountVotesForElection(string electionInstanceID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlQ = $"select Distinct Candidate.CandidateName, COUNT(Vote.CandidateID) as VoteCount from Vote" +
                    $" INNER JOIN Candidate on Candidate.CandidateID = Vote.CandidateID  where vote.ElectionInstanceID = '{electionInstanceID}'" +
                    $" GROUP BY Candidate.CandidateName ORDER BY VoteCount desc";

                var output = connection.Query<CountVote>(sqlQ, new DynamicParameters());

                if (output.Count() >= 1)
                    return output.ToList();
                else
                    return null;
            }
        }
    }
}
