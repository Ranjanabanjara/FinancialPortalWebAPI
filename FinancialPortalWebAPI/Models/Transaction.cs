using FinancialPortalWebAPI.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static FinancialPortalWebAPI.Enumerations.TransactionType;

namespace FinancialPortalWebAPI.Models
{
    public class Transaction
    {
        
            public int Id { get; set; }
            public int BankAccountId { get; set; }
            public string OwnerId { get; set; }
            public int? BudgetItemId { get; set; }
            [EnumDataType(typeof(TransactionType))]
            [JsonConverter(typeof(StringEnumConverter))]
            public TransType TransactionType { get; set; }
            public double Amount { get; set; }
            public string Memo { get; set; }
            public DateTime Created { get; set; }
            public DateTime? Updated { get; set; }

    }
}