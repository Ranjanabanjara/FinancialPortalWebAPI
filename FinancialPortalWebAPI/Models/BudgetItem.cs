using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalWebAPI.Models
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double TargetAmount { get; set; }
        public double CurrentAmount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

      
    }
}