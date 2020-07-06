using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// get tansaction list of an account id
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns>type of transaction list</returns>
        Task<List<Transaction>> GetTransactions(long accountNumber);        
    }
}
