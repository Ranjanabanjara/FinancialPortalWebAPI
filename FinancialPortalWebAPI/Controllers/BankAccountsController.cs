using FinancialPortalWebAPI.Enumerations;
using FinancialPortalWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static FinancialPortalWebAPI.Enumerations.AccountType;

namespace FinancialPortalWebAPI.Controllers
{
    [RoutePrefix("Api/BankAccounts")]
    public class BankAccountsController : BaseController
    {
        /// <summary>
        /// Retrieves all BankAccounts data for a specific Household
        /// </summary>
        /// <param name="houseId">FK Pointing Household</param>
        /// <returns>An array of Bank Account</returns>
        [ResponseType(typeof(List<BankAccount>))]
        [Route("GetHouseholdBankAccounts")]
        public async Task<List<BankAccount>> GetHouseholdBankAccounts(int houseId)
        {
            return await db.GetHouseholdBankAccounts(houseId);

        }

        /// <summary>
        /// Adds a BankAccount to a Specific Household
        /// </summary>
        /// <param name="houseId">Fk Pointing Household</param>
        /// <param name="accountType">Enum for Account Type</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="name">Name of Bank</param>
        /// <param name="startingBalance">Amount while creating Bank Account</param>
        /// <param name="lowBalanceThreshold">Alert Level Balance</param>
        /// <returns>PK of New BankAccount</returns>
        [ResponseType(typeof(BankAccount))]
        [HttpPost, Route("AddBankAccount")]
        public IHttpActionResult AddBankAccount(int houseId, AccType accountType, string ownerId, string name, float startingBalance, float lowBalanceThreshold)
        {
            return Ok(db.AddBankAccount(houseId, accountType, ownerId, name, startingBalance, lowBalanceThreshold));

        }


        /// <summary>
        ///  Retrieves all data of specific BankAccount
        /// </summary>
        /// <param name="id">PK of BankAccount</param>
        /// <returns>BankAccount</returns>
        [ResponseType(typeof(Household))]
        [Route("GetBankAccount")]
        public async Task<BankAccount> GetBankAccount(int id)
        {
            return await db.GetBankAccount(id);

        }

        /// <summary>
        /// Removes the Pk of BankAccount 
        /// </summary>
        /// <param name="id">Pk of BankAccount to remove</param>
        /// <returns></returns>
        [HttpDelete, Route("DeleteBankAccount")]
        public IHttpActionResult DeleteBankAccount(int id)
        {
            return Ok(db.DeleteBankAccount(id));

        }
    }
}
