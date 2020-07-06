using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repository.Interface;

namespace WholesaleEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Privare variables
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _log;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="accountRepository"></param>
        public AccountController(IAccountRepository accountRepository, ILogger<AccountController> logger)
        {
            _accountRepository = accountRepository;
            _log = logger;
        }

        /// <summary>
        /// get user account list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>account list</returns>
        [HttpGet]
        [Route("getaccountlist")]
        public async Task<IActionResult> GetAccountList(int id)
        {
            _log.LogInformation("GetAccountList: param value is " + id);
            List<Account> response = new List<Account>();
            response = await _accountRepository.GetAccountList(id);
            return Ok(response);
        }
    }
}
