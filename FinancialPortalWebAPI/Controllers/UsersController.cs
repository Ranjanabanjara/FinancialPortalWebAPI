using FinancialPortalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancialPortalWebAPI.Controllers
{
    [RoutePrefix("Api/Users")]
    public class UsersController : BaseController
    {
        /// <summary>
        /// Retrieves all Users Information in Database
        /// </summary>
        /// <returns>Array of Users</returns>
        [Route ("GetAllUsersInformation")]        
        public async Task<List<Users>> GetAllUsersInformation()
        {
            return await db.GetAllUsersInformation();
        }

    }
}
