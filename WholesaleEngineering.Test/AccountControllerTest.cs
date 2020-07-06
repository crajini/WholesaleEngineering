using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Interface;
using WholesaleEngineering.Controllers;
using System.Threading.Tasks;
using Models;
using System;
using Microsoft.Extensions.Logging;

namespace WholesaleEngineering.Test
{
    public class AccountControllerTest
    {
        private readonly Mock<IAccountRepository> _moqAccountRepository;
        private readonly Mock<ILogger<AccountController>> _moqLoggerAccountController;
        private AccountController _accountController;

        /// <summary>
        /// constructor
        /// </summary>
        public AccountControllerTest()
        {
            _moqAccountRepository = new Mock<IAccountRepository>();
            _moqLoggerAccountController = new Mock<ILogger<AccountController>>();
        }

        /// <summary>
        /// initialize the setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _accountController = new AccountController(_moqAccountRepository.Object, _moqLoggerAccountController.Object);
        }

        /// <summary>
        /// test success test case
        /// </summary>
        /// <returns>success</returns>
        [Test]
        public async Task Get_SuccessResult()
        {
            //Arrange
            _moqAccountRepository.Setup(x => x.GetAccountList(It.IsAny<int>())).ReturnsAsync(new List<Models.Account> { new Account { AccountName = "Testing", AccountNumber = "1342324234", AccountType = "Savings", BalanceDate = DateTime.Now, Currency = "AUD", OpeningAvailableBalance = "122.22", UserId = 1 } });

            //Act
            var result = await _accountController.GetAccountList(1) as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Testing", (result.Value as List<Account>)[0].AccountName);
        }

        /// <summary>
        /// to test invalid user id
        /// </summary>
        /// <returns>error message</returns>
        [Test]
        public void GetAccountList_Exception()
        {
            //Arrange
            _moqAccountRepository.Setup(x => x.GetAccountList(It.IsAny<int>())).ThrowsAsync(new InvalidOperationException());

            //Act
            var result = Assert.ThrowsAsync<InvalidOperationException>(async () => await _accountController.GetAccountList(0));

            //Assert
            Assert.NotNull(result);
        }
    }
}
