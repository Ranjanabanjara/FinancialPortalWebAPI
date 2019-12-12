using FinancialPortalWebAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FinancialPortalWebAPI.Controllers

{
    [RoutePrefix("Api/Households")]
    public class HouseholdsController : BaseController
    {
      
        /// <summary>
        ///  Retrieves all HouseHolds Data stored in Database
        /// </summary>
        /// <returns>An array of Household</returns>
        [ResponseType(typeof(List<Household>))]
        [Route("GetAllHouseholdData")]
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await db.GetAllHouseholdData();

        }

        /// <summary>
        /// Adds a new household in Database
        /// </summary>
        /// <returns>PK of New Household</returns>
        [ResponseType(typeof(Household))]
        [HttpPost, Route("AddHousehold")]
        public IHttpActionResult AddHousehold(string name, string greeting)
        {
            return Ok(db.AddHousehold(name, greeting));

        }
        /// <summary>
        /// Updates properties of Household 
        /// </summary>
        /// <param name="id">PK of Household to update</param>
        /// <param name="name">Name of Household</param>
        /// <param name="greeting">Greeting of Household</param>
        /// <returns>Updated Household</returns>
        [ResponseType(typeof(Household))]
        [HttpPut, Route("UpdateHousehold")]
        public IHttpActionResult UpdateHousehold(int id, string name, string greeting)
        {
            return Ok(db.UpdateHousehold(id, name, greeting));

        }


       /// <summary>
       /// Removes the Pk of Household in the Database
       /// </summary>
       /// <param name="id">Pk of Household to remove</param>
       /// <returns></returns>
        [HttpDelete, Route("DeleteHousehold")]
        public IHttpActionResult DeleteHousehold(int id)
        {
            return Ok(db.DeleteHousehold(id));

        }

        /// <summary>
        ///  Retrieves all data of specific Household
        /// </summary>
        /// <param name="id">PK of Household</param>
        /// <returns>Household</returns>
        [ResponseType(typeof(Household))]
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int id)
        {
            return await db.GetHousehold(id);

        }
        /// <summary>
        /// Retrieves all data of specific Household in JSON format
        /// </summary>
        /// <param name="id">PK of Household</param>
        /// <returns>Household</returns>
        
        [Route("GetHouseholdAsJson")]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = await db.GetHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented});

        }

 


    }
}