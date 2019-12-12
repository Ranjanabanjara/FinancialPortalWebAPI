using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FinancialPortalWebAPI.Enumerations.AccountType;

namespace FinancialPortalWebAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public AccType AccountType { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }

        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        public double LowBalanceThreshold { get; set; }
        public DateTime Created { get; set; }

    
    }
}