using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public class OmniDataItemMock : OmniDataManagementBase
    {
        #region Constructors
        public OmniDataItemMock()  : base()
        {
        }
        #endregion

        #region Load Method

        public override List<TransactionSummary> LoadTransactionSummaryDetails()
        {
            List<TransactionSummary> transactionSummaryDetailsList = new List<TransactionSummary>();

            List<TransactionDetails> transDetailsList = new List<TransactionDetails>();
            transDetailsList.Add(new TransactionDetails {
                TransactionID  = 1,
                ChargeDate = "2017-07-01",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#Paym42924",
                Description = "Payment",
                Amount = 130.00,
                TransactionType = 1,
                TransactionTypeName = "Payment"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 2,
                ChargeDate = "2017-07-01",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#Rex 42924",
                Description = "Rex Mex BBQ",
                Amount = 210.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 3,
                ChargeDate = "2017-07-01",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#Lord42933",
                Description = "Lords and Taylor",
                Amount = 170.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 4,
                ChargeDate = "2017-07-07",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#Delt42934",
                Description = "Delta Airlines",
                Amount = 1050.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 5,
                ChargeDate = "2017-07-12",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#Tran42935",
                Description = "Transfer request",
                Amount = 450.00,
                TransactionType = 4,
                TransactionTypeName = "Balance Transfer"
            });

            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 6,
                ChargeDate = "2017-07-22",
                SettlementDate = "2017-07-08",
                ReferenceNumber = "R#ATM 42938",
                Description = "ATM Studio7",
                Amount = 450.00,
                TransactionType = 4,
                TransactionTypeName = "Balance Transfer"
            });

            TransactionSummary tSummary = new TransactionSummary();            
            tSummary.AccountID = 1;
            tSummary.TransactionSummaryID = 1;
            tSummary.TransactionSummaryName = "TRANS20170829";
            tSummary.TransactionSummaryDate = "2017-08-29";
            tSummary.ListTransactionDetails = transDetailsList;

            transactionSummaryDetailsList.Add(tSummary);

            transDetailsList = new List<TransactionDetails>();

            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 7,
                ChargeDate = "2017-08-01",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#Taco42965",
                Description = "Taco Bell #147",
                Amount = 20.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 8,
                ChargeDate = "2017-08-01",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#Bobs42965",
                Description = "Bobs Big Boy",
                Amount = 70.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 9,
                ChargeDate = "2017-08-07",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#Delt42934",
                Description = "Delta Airlines",
                Amount = 1050.00,
                TransactionType = 3,
                TransactionTypeName = "Purchase"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 10,
                ChargeDate = "2017-08-12",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#Tran42935",
                Description = "Transfer request",
                Amount = 150.00,
                TransactionType = 4,
                TransactionTypeName = "Balance Transfer"
            });

            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 11,
                ChargeDate = "2017-08-22",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#ATM 42938",
                Description = "ATM Asian Sun",
                Amount = 40.00,
                TransactionType = 4,
                TransactionTypeName = "Balance Transfer"
            });
            transDetailsList.Add(new TransactionDetails
            {
                TransactionID = 12,
                ChargeDate = "2017-08-01",
                SettlementDate = "2017-09-08",
                ReferenceNumber = "R#Paym42955",
                Description = "Payment",
                Amount = 130.00,
                TransactionType = 1,
                TransactionTypeName = "Payment"
            });

            tSummary = new TransactionSummary();
            tSummary.AccountID = 1;
            tSummary.TransactionSummaryID = 2;
            tSummary.TransactionSummaryName = "TRANS20170929";
            tSummary.TransactionSummaryDate = "2017-09-29";
            tSummary.ListTransactionDetails = transDetailsList;

            transactionSummaryDetailsList.Add(tSummary);

            return transactionSummaryDetailsList;
        }

        public override List<CardAccountDetails> LoadCardAccountDetails(string userToken)
        {
            AccountDetails entity = new AccountDetails();
            List<CardAccountDetails> cardAccountDetailsList = new List<CardAccountDetails>();
            List<AccountDetails> accountDetailsList = new List<AccountDetails>();

            entity.AccountID = 1;
            entity.AccountType = 10;
            entity.AccountName = "Bills Savings";
            entity.AccountTypeName = "Savings";
            entity.AccountAlias = "Alias1 Bills Savings";
            entity.AccountStatus = 0;
            accountDetailsList.Add(entity);

            entity = new AccountDetails();
            entity.AccountID = 3;
            entity.AccountType = 20;
            entity.AccountName = "Bills Checking";
            entity.AccountTypeName = "Checking";
            entity.AccountAlias = "Alias1 Bills Checking";
            entity.AccountStatus = 0;
            accountDetailsList.Add(entity);

            entity = new AccountDetails();
            entity.AccountID = 2;
            entity.AccountType = 30;
            entity.AccountName = "Bills Credit";
            entity.AccountTypeName = "Credit";
            entity.AccountAlias = "Alias1 Bills Credit";
            entity.AccountStatus = 0;
            accountDetailsList.Add(entity);

            cardAccountDetailsList.Add(
                    new OmniDataManagement.CardAccountDetails
                    {
                        CardID = 1,
                        CardName = "Billy Card 1",
                        AccountList = accountDetailsList
                    }
                );

            cardAccountDetailsList.Add(
                    new OmniDataManagement.CardAccountDetails
                    {
                        CardID = 2,
                        CardName = "Mary Card 2",
                        AccountList = accountDetailsList
                    }
                );

            cardAccountDetailsList.Add(
                  new OmniDataManagement.CardAccountDetails
                  {
                      CardID = 3,
                      CardName = "Anna Card 3",
                      AccountList = accountDetailsList
                  }
              );

            accountDetailsList = new List<AccountDetails>();
            entity = new AccountDetails();
            entity.AccountID = 4;
            entity.AccountType = 10;
            entity.AccountTypeName = "Savings";
            entity.AccountName = "Rob's Test Account";
            entity.AccountAlias = "Alias1 Rob's Test Account";
            entity.AccountStatus = 0;
            accountDetailsList.Add(entity);

            entity = new AccountDetails();
            entity.AccountID = 5;
            entity.AccountType = 20;
            entity.AccountTypeName = "Checking";
            entity.AccountName = "Broke Betty's Checking Accout";
            entity.AccountAlias = "Alias1 Broke Betty's Checking Accout";
            entity.AccountStatus = 0;
            accountDetailsList.Add(entity);

            cardAccountDetailsList.Add(
                   new OmniDataManagement.CardAccountDetails
                   {
                       CardID = null,
                       CardName = string.Empty,
                       AccountList = accountDetailsList
                   }
               );

            return cardAccountDetailsList;
        }

        public override List<CardDetails> LoadCardDetails()
        {
            List<CardDetails> listCardDetails = new List<OmniDataManagement.CardDetails>();
            List<RewardDetails> listRewards = new List<RewardDetails>();

            listRewards.Add(new RewardDetails()
            {
                RewardID = 2,
                RewardPoints = 1500,
                RewardDate = "03/10/2018"
            });
            listRewards.Add(new RewardDetails()
            {
                RewardID = 1,
                RewardPoints = 500,
                RewardDate = "03/01/2018"
            });

            CardDetails entity = new OmniDataManagement.CardDetails();
            entity.CardID = 1;
            entity.CardNumber = "47015XXXXXX30687";
            entity.CardName = "Billy's Card";
            entity.CardExpirationDate = "02/28/2020";
            entity.IsActive = true;
            entity.Balance = "$250";
            entity.MinPaymentDue = "$25";
            entity.AvailableCredit = "$2500";
            entity.NextPaymentDate = "02/28/2018";
            entity.IsLocked = false;
            entity.IsFrozen = false;
            entity.IsRestricted = true;            
            entity.CardRewards = listRewards;
            listCardDetails.Add(entity);

            listRewards = new List<RewardDetails>();
            listRewards.Add(new RewardDetails()
            {
                RewardID = 3,
                RewardPoints = 1500,
                RewardDate = "03/11/2018"
            });

            entity = new OmniDataManagement.CardDetails();
            entity.CardID = 2;
            entity.CardNumber = "48889XXXXXX58516";
            entity.CardName = "Mary's Card";
            entity.CardExpirationDate = "02/28/2020";
            entity.IsActive = true;
            entity.Balance = "$1150";
            entity.MinPaymentDue = "$100";
            entity.AvailableCredit = "$2000";
            entity.NextPaymentDate = "02/28/2018";
            entity.IsLocked = true;
            entity.IsFrozen = false;
            entity.IsRestricted = false;
            entity.CardRewards = listRewards;
            listCardDetails.Add(entity);

            listRewards = new List<RewardDetails>();
            listRewards.Add(new RewardDetails()
            {
                RewardID = 4,
                RewardPoints = 100,
                RewardDate = "03/05/2018"
            });

            entity = new OmniDataManagement.CardDetails();
            entity.CardID = 3;
            entity.CardNumber = "41472XXXXXX95328";
            entity.CardName = "Anna's Card";
            entity.CardExpirationDate = "02/28/2020";
            entity.IsActive = true;
            entity.Balance = "$50";
            entity.MinPaymentDue = "$0";
            entity.AvailableCredit = "$500";
            entity.NextPaymentDate = "02/28/2018";
            entity.IsLocked = false;
            entity.IsFrozen = true;
            entity.IsRestricted = false;
            listCardDetails.Add(entity);
            entity.CardRewards = listRewards;
            return listCardDetails;
        }

        #endregion
    }
}
