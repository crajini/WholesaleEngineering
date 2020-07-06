using DataAccessLayer;
using Models;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        public async Task<List<Transaction>> GetTransactions(long accountNumber)
        {
            TransactionDAL transactionDAL = new TransactionDAL();
            return await transactionDAL.GetTransactions(accountNumber);
        }
    }
}
