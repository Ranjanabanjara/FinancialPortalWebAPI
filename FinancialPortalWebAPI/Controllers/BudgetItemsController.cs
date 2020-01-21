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
        /// <param name="budgetId">FK pointing to Budget Category</param>
        /// <param name="name">Name of BudgetItem</param>
        /// <param name="description">Description of BudgetItem</param>
        /// <param name="targetAmount">Allocated amount for the BudgetItem</param>
        /// <returns>PK of BudgetItem</returns>

        [ResponseType(typeof(BudgetItem))]
        [HttpPost, Route("AddBudgetItem")]
        public IHttpActionResult AddBudgetItem(int budgetId, string name, string description, float targetAmount)
        {
            return Ok(db.AddBudgetItem(budgetId, name, description, targetAmount));

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

        /// <summary>
        /// Removes the Pk of BudgetItem in the Database
        /// </summary>
        /// <param name="id">Pk of BudgetItem to remove</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBudgetItem")]
        public IHttpActionResult DeleteBudgetItem(int id)
        {
            return Ok(db.DeleteBudgetItem(id));

        }
    }

}
