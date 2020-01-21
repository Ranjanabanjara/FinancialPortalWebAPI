using FinancialPortalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Util;
using static FinancialPortalWebAPI.Enumerations.TransactionType;

namespace FinancialPortalWebAPI.Controllers
{
    [RoutePrefix("Api/Transactions")]
    public class TransactionsController : BaseController
    {
        /// <summary>
        /// Retrieves all Transactions 
        /// </summary>
        /// <param name="bankAccountId">FK pointing to BankAccount</param>
        /// <returns>An array of Transaction</returns>
        [ResponseType(typeof(List<Transactions>))]
        [Route("GetAllTransactions")]
        public async Task<List<Transaction>> GetAllTransactions(int bankAccountId)
        {
            return await db.GetAllTransactions(bankAccountId);

        }
        /// <summary>
        /// Adds a Transaction 
        /// </summary>
        /// <param name="bankAccountId">FK pointing to BankAccount</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="budgetItemId">FK pointing to BudgetItem</param>
        /// <param name="transactionType">Enum for Transaction Type</param>
        /// <param name="amount">Value of Transaction</param>
        /// <param name="memo">Note on Transaction</param>
        /// <returns></returns>
        [ResponseType(typeof(Transaction))]
        [HttpPost, Route("AddTransaction")]
        public IHttpActionResult AddTransaction(int bankAccountId, string ownerId, int budgetItemId, TransType transactionType, float amount, string memo)
        {
            return Ok(db.AddTransaction(bankAccountId, ownerId, budgetItemId, transactionType, amount, memo));

        }

        /// <summary>
        /// Retrieves a specific Transaction 
        /// </summary>
        /// <param name="id">PK of Transaction</param>
        /// <returns>Transaction</returns>
        [ResponseType(typeof(Transaction))]
        [Route("GetTransaction")]
        public async Task<Transaction> GetTransaction(int id)
        {
            return await db.GetTransaction(id);

        }

        /// <summary>
        /// Removes the Pk of Transaction in the Database
        /// </summary>
        /// <param name="id">Pk of Transaction to remove</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteTransaction")]
        public IHttpActionResult DeleteTransaction(int id)
        {
            return Ok(db.DeleteTransaction(id));

        }







    }
}
