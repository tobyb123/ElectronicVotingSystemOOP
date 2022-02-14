using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVotingSystemService.Data_Models
{
    /// <summary>
    /// Data model for the candidate stored in the database. Linked to the Election Table through ElectionInstanceID.
    /// </summary>
    public class Candidate
    {
        public string CandidateID { get; set; }
        public string ElectionInstanceID { get; set; }
        public string CandidateName { get; set; }
    }
}
