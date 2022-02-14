using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVotingSystemService.Data_Models
{
    /// <summary>
    /// Data model for the CountVote returned from the database to populate DataGridView control on auditor dashboard.
    /// </summary>
    public class CountVote
    {
        public string CandidateName { get; set; }
        public int VoteCount { get; set; }
    }
}
