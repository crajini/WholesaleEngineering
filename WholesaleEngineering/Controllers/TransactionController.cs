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
    public class TransactionController : ControllerBase
    {
        #region Private Variables
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<TransactionController> _log;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="transactionRepository"></param>
        public TransactionController(ITransactionRepository transactionRepository, ILogger<TransactionController> logger)
        {
            _transactionRepository = transactionRepository;
            _log = logger;
        }

        /// <summary>
        /// get transaction list
        /// </summary>
        /// <returns>transaction list</returns>
        [HttpGet]
        [Route("gettransactionlist")]
        public async Task<IActionResult> GetTransactionList(long accountNumber)
        {
            _log.LogInformation("GetTransactionList: param value is " + accountNumber);
            List<Transaction> response = new List<Transaction>();
            response = await _transactionRepository.GetTransactions(accountNumber);
            return Ok(response);
        }
    }
}