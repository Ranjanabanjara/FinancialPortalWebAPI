using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static FinancialPortalWebAPI.Enumerations.AccountType;
using static FinancialPortalWebAPI.Enumerations.TransactionType;

namespace FinancialPortalWebAPI.Models
{
    /// <summary>
    /// API Context inherited from DbContext
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiContext()
        :base("APIConnection")
        {
        }

        public static ApiContext Create()
        {
            return new ApiContext();
        }

        public async Task<List<Users>> GetAllUsersInformation()
        {
            return await Database.SqlQuery<Users>("GetAllUsersInformation").ToListAsync();
        }
        /// <summary>
        /// Retrieves all Households in Database
        /// </summary>
        /// <returns>An array of Households</returns>
        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();

        }
        /// <summary>
        /// Retrieves all data of a specific Household
        /// </summary>
        /// <param name="id">PK of Household</param>
        /// <returns>Household Data</returns>
        public async Task<Household> GetHousehold(int id)
        {
            return await Database.SqlQuery<Household>("GetHousehold @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }
        /// <summary>
        /// Creates a Household
        /// </summary>
        /// <param name="name">Name of Household</param>
        /// <param name="greeting">Greeting</param>
        /// <returns>PK of Household</returns>
        public  int AddHousehold(string name, string greeting)
        {
            return  Database.ExecuteSqlCommand("AddHousehold @name, @greeting", new SqlParameter("name", name), new SqlParameter("greeting", greeting));

        }
        /// <summary>
        /// Updates Data of an Existing Household
        /// </summary>
        /// <param name="id">PK of Household to Update</param>
        /// <param name="name">Name of Household</param>
        /// <param name="greeting">Greeting of Household</param>
        /// <returns></returns>
        public int UpdateHousehold(int id, string name, string greeting)
        {
            return Database.ExecuteSqlCommand("UpdateHousehold @id, @name, @greeting", 
                new SqlParameter("id", id), 
                new SqlParameter("name", name), 
                new SqlParameter("greeting", greeting));

        }
        /// <summary>
        /// Removes a Household in database
        /// </summary>
        /// <param name="id">PK of Household to remove</param>
        /// <returns></returns>
        public int DeleteHousehold(int id)
        {
            return Database.ExecuteSqlCommand("DeleteHousehold @id",
                new SqlParameter("id", id));


        }

        /// <summary>
        /// Retrieves all Bank Account of a specific Household
        /// </summary>
        /// <param name="houseId">FK Pointing to Household</param>
        /// <returns>Bank Account</returns>
        public async Task<List<BankAccount>> GetHouseholdBankAccounts(int houseId)
        {
            return await Database.SqlQuery<BankAccount>("GetHouseholdBankAccounts @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }
        /// <summary>
        /// Adds a bank Account for a specific household
        /// </summary>
        /// <param name="houseId">Fk pointing to household</param>
        /// <param name="accountType">Enum accounttype</param>
        /// <param name="ownerId">Fk pointing to Owner User</param>
        /// <param name="name">Name of the Bank Account</param>
        /// <param name="startingBalance">Balance to start</param>
        /// <param name="lowBalanceThreshold">Alert Level balance</param>
        /// <returns>PK of BankAccount</returns>
        public int AddBankAccount(int houseId, AccType accountType, string ownerId, string name, float startingBalance, float lowBalanceThreshold)
        {
            var emumAccountType = (int)accountType;
            return Database.ExecuteSqlCommand("AddBankAccount @houseId, @accountType, @ownerId, @name, @startingBalance, @lowBalanceThreshold",
                new SqlParameter("houseId", houseId),
                 new SqlParameter("accountType", emumAccountType ),
                  new SqlParameter("ownerId", ownerId ),
                   new SqlParameter("name", name),
                   new SqlParameter("startingBalance", startingBalance ),
                new SqlParameter("lowBalanceThreshold", lowBalanceThreshold));

        }


        /// <summary>
        /// Retrieves data related to a specific BankAccount
        /// </summary>
        /// <param name="id">PK of BankAccount</param>
        /// <returns>BankAccount</returns>
        public async Task<BankAccount> GetBankAccount(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccount @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }


        /// <summary>
        /// Removes a BankAccount
        /// </summary>
        /// <param name="id">PK of BankAccount to remove</param>
        /// <returns></returns>
        public int DeleteBankAccount(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBankAccount @id",
                new SqlParameter("id", id));


        }

        /// <summary>
        /// Retrieves all Budget Categories 
        /// </summary>
        /// <param name="houseId">Fk Pointing to Household</param>
        /// <returns>An array of Bank Account</returns>
        public async Task<List<Budget>> GetAllBudgetCategories(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetAllBudgetCategories @houseId",
                new SqlParameter("houseId", houseId )).ToListAsync();
        }


        /// <summary>
        /// Creates Budget Category 
        /// </summary>
        /// <param name="houseId">FK pointing to Household</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="name">Budget category Name</param>
        /// <param name="targetAmount">Allocated Amount for the Category</param>
        /// <returns>PK of Budget</returns>
     
        public int AddBudgetCategory(int houseId, string ownerId, string name, float targetAmount)
        {
            return Database.ExecuteSqlCommand("AddBudgetCategory @houseId, @ownerId, @name, @targetAmount",
                new SqlParameter("houseId", houseId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("name", name),
                new SqlParameter("targetAmount", targetAmount));
             

        }

        /// <summary>
        /// Retrieves all data related to specific Budget Category
        /// </summary>
        /// <param name="id">PK of Budget Category</param>
        /// <returns>Budget</returns>
        public async Task<Budget> GetBudget(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudget @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Updates the Budget Category Name
        /// </summary>
        /// <param name="id">PK of Budget Category </param>
        /// <param name="name">Name of Budget Category</param>
        /// <returns></returns>
        public int UpdateBudgetCategory(int id, string name)
        {
            return Database.ExecuteSqlCommand("UpdateBudgetCategory @id, @name",
                new SqlParameter("id", id),
                new SqlParameter("name", name)
                );

        }

        /// <summary>
        /// Removes a Budget Category in database
        /// </summary>
        /// <param name="id">PK of Budget Category to remove</param>
        /// <returns></returns>
        public int DeleteBudget(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudget @id",
                new SqlParameter("id", id));


        }

        /// <summary>
        /// Retrieves all BudgetItems for a specific Budget Category
        /// </summary>
        /// <param name="budgetId">Fk Pointing to Budget Category</param>
        /// <returns>An array of BudgetItem</returns>
        public async Task<List<BudgetItem>> GetAllBudgetItems(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetAllBudgetItems @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }


       
        /// <summary>
        /// Creates a BudgetItem for a Budget Category
        /// </summary>
        /// <param name="budgetId">FK pointing to Budget category</param>
        /// <param name="name">Name of BudgetItem</param>
        /// <param name="description">Description of BudgetItem</param>
        /// <param name="targetAmount">Allocated amount for the same BudgetItem</param>
        /// <returns>PK of BudgetItem</returns>
        public int AddBudgetItem(int budgetId, string name, string description, float targetAmount)
        {
            return Database.ExecuteSqlCommand("AddBudgetItem @budgetId, @name, @description, @targetAmount",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("targetAmount", targetAmount));


        }
        /// <summary>
        /// Retrieves all data of specific BudgetItem
        /// </summary>
        /// <param name="id">PK of BudgetItem</param>
        /// <returns>BudgetItem</returns>
        public async Task<BudgetItem> GetBudgetItem(int id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItem @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Removes a BudgetItem in database
        /// </summary>
        /// <param name="id">PK of BudgetItem to remove</param>
        /// <returns></returns>
        public int DeleteBudgetItem(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBudgetItem @id",
                new SqlParameter("id", id));


        }

        /// <summary>
        /// Retrieves all data of specific Transaction 
        /// </summary>
        /// <param name="id">PK of Transaction</param>
        /// <returns>Transaction</returns>
        public async Task<Transaction> GetTransaction(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransaction @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }
        
        /// <summary>
        /// Retrieves all Transactions 
        /// </summary>
        /// <param name="bankAccountId">FK pointing to BankAccount</param>
        /// <returns>An array of Transactions</returns>
        public async Task<List<Transaction>> GetAllTransactions(int bankAccountId)
        {
            return await Database.SqlQuery<Transaction>("GetAllTransactions @bankAccountId",
                new SqlParameter("bankAccountId", bankAccountId)).ToListAsync();
        }


        /// <summary>
        /// Creates a Transaction 
        /// </summary>
        /// <param name="bankAccountId">FK Pointing to BanAccount</param>
        /// <param name="ownerId">FK pointing to Owner User</param>
        /// <param name="budgetItemId">FK pointing to BudgetItem</param>
        /// <param name="transactionType">Enum for Transaction Type</param>
        /// <param name="amount">Amount of Transaction</param>
        /// <param name="memo">Transaction information</param>
        /// <returns>PK of New Transaction</returns>
        public int AddTransaction(int bankAccountId, string ownerId, int budgetItemId, TransType transactionType, float amount, string memo)
        {
            return Database.ExecuteSqlCommand("AddBudgetItem @bankAccountId, @ownerId , @BudgetItemId, @transactionType, @amount, @memo",
                new SqlParameter("bankAccountId", bankAccountId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("BudgetItemId", budgetItemId),
                new SqlParameter("transactionType", (int)transactionType),
                new SqlParameter("amount", amount),
                 new SqlParameter("memo", memo));
        }

        /// <summary>
        /// Removes a Transaction in database
        /// </summary>
        /// <param name="id">PK of Transaction to remove</param>
        /// <returns></returns>
        public int DeleteTransaction(int id)
        {
            return Database.ExecuteSqlCommand("DeleteTransaction @id",
                new SqlParameter("id", id));


        }
    }


 

}
