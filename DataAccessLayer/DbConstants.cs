namespace DataAccessLayer
{
    public class DbConstants
    {
        #region Account DAL
        public const string DbConnection = "Connectionstring";
        public const string GetAccounts = "usp_GetUserAccountList";
        #endregion

        #region Transactions
        public const string GetTransactions = "usp_GetAccountTransactionList";
        #endregion
    }
}
