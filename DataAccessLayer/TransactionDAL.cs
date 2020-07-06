using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TransactionDAL:BaseDAL
    {
        /// <summary>
        /// get transaction list
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>type of transaction list</returns>
        public async Task<List<Transaction>> GetTransactions(long accountNumber)
        {
            IEnumerable<Transaction> response = new List<Transaction>();
            using (IDbConnection db = new SqlConnection(GetConnectionString(DbConstants.DbConnection)))
            {
                response= await db.QueryAsync<Transaction>(DbConstants.GetTransactions, new { @accountNumber = accountNumber }, commandType: CommandType.StoredProcedure, commandTimeout: 1000);
            }
            return response.AsList();
        }        
    }
}
