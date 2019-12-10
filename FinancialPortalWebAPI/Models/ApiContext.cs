using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FinancialPortalWebAPI.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext()
        :base("APIConnection")
        {
        }

        public static ApiContext Create()
        {
            return new ApiContext();
        }

        public async Task<List<Household>> GetAllHouseholdData()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholdData").ToListAsync();

        }
        public async Task<Household> GetHousehold(int id)
        {
            return await Database.SqlQuery<Household>("GetHousehold @id", new SqlParameter("id", id)).FirstOrDefaultAsync();

        }
    }

 




}
