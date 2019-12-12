using FinancialPortalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinancialPortalWebAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected ApiContext db = new ApiContext();
    }
}
