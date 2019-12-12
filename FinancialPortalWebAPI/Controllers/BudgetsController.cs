using FinancialPortalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace FinancialPortalWebAPI.Controllers
{
    [RoutePrefix("Api/Budgets")]
    public class BudgetsController : BaseController
    { 
        /// <summary>
        /// Retrieves all Budgets Categories in a specific Household
        /// </summary>
        /// <param name="houseId">Fk Pointing To Household</param>
        /// <returns>An array of Budget</returns>
        [ResponseType(typeof(List<Budget>))]
        [Route("GetAllBudgetCategories")]
        public async Task<List<Budget>> GetAllBudgetCategories(int houseId)
        {
            return await db.GetAllBudgetCategories(houseId);

        }
        /// <summary>
        /// Creates a Budget Category for a specific Household
        /// </summary>
        /// <param name="houseId">FK pointing to Household</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="name">Name of Budget Category</param>
        /// <param name="targetAmount">Allocated amount for the Budget Category</param>
        /// <returns>PK of Budget</returns>
       
        [ResponseType(typeof(Budget))]
        [HttpPost, Route("AddBudgetCategory")]
        public IHttpActionResult AddBudgetCategory(int houseId, string ownerId, string name, float targetAmount)
        {
            return Ok(db.AddBudgetCategory(houseId, ownerId, name, targetAmount));

        }

        /// <summary>
        ///  Retrieves all data of specific Budget Category
        /// </summary>
        /// <param name="id">PK of Budget category</param>
        /// <returns>Budget</returns>
        [ResponseType(typeof(Budget))]
        [Route("GetBudget")]
        public async Task<Budget> GetBudget(int id)
        {
            return await db.GetBudget(id);

        }
    }
}

