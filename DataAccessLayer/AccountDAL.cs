using Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAL : BaseDAL
    {
        /// <summary>
        /// get account for a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>type of account list</returns>
        public async Task<List<Account>> GetAccounts(int userId)
        {
            IEnumerable<Account> response = new List<Account>();
            using (IDbConnection db = new SqlConnection(GetConnectionString(DbConstants.DbConnection)))
            {
                response = await db.QueryAsync<Account>(DbConstants.GetAccounts, new { @userId = userId }, commandType: CommandType.StoredProcedure, commandTimeout: 1000);
            }
            return response.AsList();
        }
    }
}
