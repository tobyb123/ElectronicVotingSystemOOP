using ElectronicVotingSystemService.Data_Models;
using System.Collections.Generic;

namespace ElectronicVotingSystemService
{
    public interface IDatabaseHelper
    {
        List<CountVote> CountVotesForElection(string electionInstanceID);
        int CreateNewVote(string electionInstanceID, string candidateID, string userID);
        List<Election> GetActiveElections();
        List<Election> GetAllElections();
        Candidate GetCandidateFromElectionIDCandidateName(string electionInstanceID, string candidateName);
        List<Candidate> GetCandidatesFromElection(string electionInstanceID);
        Election GetElectionFromElectionID(string electionInstanceID);
        User GetUser(string nationalInsuranceNumber, string password);
        bool IsValidUserCredentials(string nationalInsuranceNumber, string password);
        bool HasAdministratorAuthenticatedUser(string nationalInsuranceNumber, string password);
        Vote GetUserVoteFromElection(string electionInstanceID, string userID);
        bool HasUserVotedForCandidate(string electionInstanceID, string candidateID, string userID);
        int UpdateVote(Vote vote, string candidateID);
    }
}