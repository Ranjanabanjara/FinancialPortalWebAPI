﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialPortalWebAPI.Models
{
    public class Household
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Greeting { get; set; }

        public DateTime Created { get; set; }

    }
}