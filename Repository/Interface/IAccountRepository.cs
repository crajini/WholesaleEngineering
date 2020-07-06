using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        /// <summary>
        /// get account list for a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>type of account list</returns>
        Task<List<Account>> GetAccountList(int userId);        
    }
}
