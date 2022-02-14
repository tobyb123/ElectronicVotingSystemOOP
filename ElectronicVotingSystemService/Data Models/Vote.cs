using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicVotingSystemService.Data_Models
{
    /// <summary>
    /// Data model for the Vote stored in the database. Linked to User table through User ID, 
    /// Candidate table with CandidateID and Election table with ElectionInstanceID.
    /// </summary>
    public class Vote
    {
        public string VoteInstanceID { get; set; }
        public string UserID { get; set; }
        public string CandidateID { get; set; }
        public DateTime  VoteCreatedDate{ get; set; }
        public DateTime VoteUpdatedDate { get; set; }
        public string ElectionInstanceID { get; set; }
    }
}
