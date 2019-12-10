using FinancialPortalWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;



namespace FinancialPortalWebAPI.Controllers
{
    [RoutePrefix("Api/Households")]
    public class HouseholdsController : ApiController
    {
        private ApiContext db = new ApiContext();

        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();

        }
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int id)
        {
            return await db.GetHousehold(id);

        }
        [Route("GetHouseholdAsJson")]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = await db.GetHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented});

        }



    }
}