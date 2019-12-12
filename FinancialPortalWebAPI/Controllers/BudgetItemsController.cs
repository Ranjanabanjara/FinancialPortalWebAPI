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
    [RoutePrefix("Api/BudgetItems")]
    public class BudgetItemsController : BaseController
    {
        /// <summary>
        /// Retrieves all BudgetItems in a specific Budget category
        /// </summary>
        /// <param name="budgetId">Fk Pointing To Budget Category</param>
        /// <returns>An array of BudgetItems</returns>
        [ResponseType(typeof(List<BudgetItem>))]
        [Route("GetAllBudgetItems")]
        public async Task<List<BudgetItem>> GetAllBudgetItems(int budgetId)
        {
            return await db.GetAllBudgetItems(budgetId);

        }
        /// <summary>
        /// Creates a BudgetItem for a specific BudgetCategory
        /// </summary>
        /// <param name="houseId">FK pointing to Household</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="name">Name of Budget Category</param>
        /// <param name="targetAmount">Allocated amount for the Budget Category</param>
        /// <returns>PK of BudgetItem</returns>

        [ResponseType(typeof(BudgetItem))]
        [HttpPost, Route("AddBudgetItem")]
        public IHttpActionResult AddBudgetItem(int houseId, string ownerId, string name, float targetAmount)
        {
            return Ok(db.AddBudgetItem(houseId, ownerId, name, targetAmount));

        }

        /// <summary>
        ///  Retrieves all data of specific BudgetItem
        /// </summary>
        /// <param name="id">PK of BudgetItem</param>
        /// <returns>BudgetItem</returns>
        [ResponseType(typeof(BudgetItem))]
        [Route("GetBudgetItem")]
        public async Task<BudgetItem> GetBudgetItem(int id)
        {
            return await db.GetBudgetItem(id);

        }
    }
}
