using DataAccessLayer;
using Models;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository: IAccountRepository
    {
        public async Task<List<Account>> GetAccountList(int userId)
        {
            AccountDAL accountDAL = new AccountDAL();
            return await accountDAL.GetAccounts(userId);             
        }
    }
}
