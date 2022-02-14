using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicVotingSystemService.Data_Models
{
    /// <summary>
    /// Data model for the User stored in the database. Login using NationalInsuranceNumber (only unique entries) and Password.
    /// </summary>
    public class User
    {
        public string UserID { get; set; }
        public string NationalInsuranceNumber { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return $"{Forename} {Surname}";
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string HomeTel { get; set; }
        public string MobileTel { get; set; }
        public string EmailAddress { get; set; }
        public AccountType AccountType { get; set; }
        public int Authenticated { get; set; }
        public string Password { get; set; }
    }

    public enum AccountType
    {
        Voter,
        Administrator,
        Auditor
    }
}
