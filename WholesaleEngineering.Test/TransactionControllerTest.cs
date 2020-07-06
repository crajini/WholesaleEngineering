using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WholesaleEngineering.Controllers;

namespace WholesaleEngineering.Test
{
    public class TransactionControllerTest
    {
        private readonly Mock<ITransactionRepository> _moqTransactionRepository;
        private TransactionController _transactionController;
        private readonly Mock<ILogger<TransactionController>> _moqLoggerTransactionController;

        /// <summary>
        /// constructor
        /// </summary>
        public TransactionControllerTest()
        {
            _moqTransactionRepository = new Mock<ITransactionRepository>();
            _moqLoggerTransactionController = new Mock<ILogger<TransactionController>>();
        }

        /// <summary>
        /// initialize the setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _transactionController = new TransactionController(_moqTransactionRepository.Object, _moqLoggerTransactionController.Object);
        }

        /// <summary>
        /// to test success test case
        /// </summary>
        /// <returns>transaction list</returns>
        [Test]
        public async Task Get_SuccessResult()
        {
            //Arrange
            _moqTransactionRepository.Setup(x => x.GetTransactions(It.IsAny<long>())).ReturnsAsync(new List<Transaction> { new Transaction { AccountName = "Testing", AccountNumber = "1221343345", CreditAmount = "1", Currency = "AUD", DebitAmount = "2", Narrative = "test", TransactionType = "Credit", ValueDate = DateTime.Now } });

            //Act
            var result = await _transactionController.GetTransactionList(1) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Testing", (result.Value as List<Transaction>)[0].AccountName);
        }

        /// <summary>
        /// to test invalid account number
        /// </summary>
        /// <returns>error message for account number</returns>
        [Test]
        public void GetTransactions_Exception()
        {
            //Arrange
            _moqTransactionRepository.Setup(x => x.GetTransactions(It.IsAny<long>())).ThrowsAsync(new InvalidOperationException());

            //Act
            var result = Assert.ThrowsAsync<InvalidOperationException>(async () => await _transactionController.GetTransactionList(0));

            //Assert
            Assert.NotNull(result);
        }
    }
}
