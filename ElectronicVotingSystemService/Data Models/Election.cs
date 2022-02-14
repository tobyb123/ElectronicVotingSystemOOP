using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVotingSystemService.Data_Models
{
    /// <summary>
    /// Data model for the Election stored in the database. 
    /// </summary>
    public class Election
    {
        public string ElectionInstanceID { get; set; }
        public string ElectionName { get; set; }
        public string ElectionStartDate { get; set; }
        public string ElectionEndDate { get; set; }
    }
}
