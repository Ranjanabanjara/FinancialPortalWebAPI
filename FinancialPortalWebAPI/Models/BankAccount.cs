using FinancialPortalWebAPI.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static FinancialPortalWebAPI.Enumerations.AccountType;

namespace FinancialPortalWebAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }

        [EnumDataType(typeof(AccountType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccType AccountType { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }

        public double StartingBalance { get; set; }
        public double CurrentBalance { get; set; }
        public double LowBalanceThreshold { get; set; }
        public DateTime Created { get; set; }

    
    }
}