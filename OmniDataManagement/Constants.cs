using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniDataManagement
{
    public static class Constants
    {
        public static string UserLoginURLParameters = "UserLogin/CardHolderLogin?ActionID=1";
        public static string AccountsURLParameters = "CHP/AccountDetails?userToken=";
        public static string TransactionURLParameters = "CHP/TransactionDetails?userToken=";
        public static string UpdateAccountAliasURLParameters = "CHP/UpdateAccountAlias?userToken=";
        public static string ChangeAccountStatusURLParameters = "CHP/ChangeAccountStatus?userToken=";
        public static string AddAccountRequestURLParameters = "CHP/AddAccountRequest?userToken=";
        public static string AddErrorLogURLParameters = "CHP/ErrorLog?userToken=";

        public static int UserLoginTTL = 500;
        public static int UserLoginPOC = 1;
        public static int UserLoginInstitutionID = 11;
        public static int TransactionDays = 150;
        public static string PassPhrase = "password";

        enum enumAccountStatus
        {
            [Description("Open")]
            Open = 0,
            [Description("Close")]
            Close = 1,
            [Description("Restricted")]
            Restricted = 2,
            [Description("On Hold")]
            OnHold = 3
        };

        enum enumTransactionStatus
        {
            [Description("Settled")]
            Settled = 0,
            [Description("Pending")]
            Pending = 1,
            [Description("Disputed")]
            Disputed = 9
        };

        enum enumAccountType
        {
            [Description("Savings")]
            Savings = 10,
            [Description("Checking")]
            Checking = 20,
            [Description("Credit")]
            Credit = 30
        };

        enum enumTransactionType
        {
            [Description("Charge")]
            Unknown = 0,
            [Description("Charge")]
            AuthRequest = 1,
            [Description("Charge")]
            Settlement = 2,
            [Description("Surcharge")]
            Surcharge = 4,
            [Description("Fee")]
            Fee = 8,
            [Description("Transfer")]
            Transfer = 16,
            [Description("Reversal")]
            Reversal = 32,
            [Description("Change Back")]
            ChangeBack = 64,
            [Description("Adjustment (Manual)")]
            Adjustment = 128
        };

        public static string GetAccountType(int accountType)
        {            
            if (accountType == (int)enumAccountType.Checking)
                return enumAccountType.Checking.ToName();
            else if (accountType == (int)enumAccountType.Savings)
                return enumAccountType.Checking.ToName();
            else if (accountType == (int)enumAccountType.Credit)
                return enumAccountType.Checking.ToName();
            else
                return string.Empty;
        }

        public static string GetAccountStatus(int accountStatus)
        {
            if (accountStatus == (int)enumAccountStatus.Open)
                return enumAccountStatus.Open.ToName();
            else if (accountStatus == (int)enumAccountStatus.Close)
                return enumAccountStatus.Close.ToName();
            else if (accountStatus == (int)enumAccountStatus.Restricted)
                return enumAccountStatus.Restricted.ToName();
            else if (accountStatus == (int)enumAccountStatus.OnHold)
                return enumAccountStatus.OnHold.ToName();
            else
                return string.Empty;
        }

        public static string GetTransactionStatus(int transStatus)
        {
            if (transStatus == (int)enumTransactionStatus.Pending)
                return enumTransactionStatus.Pending.ToName();
            else if (transStatus == (int)enumTransactionStatus.Settled)
                return enumTransactionStatus.Settled.ToName();
            else if (transStatus == (int)enumTransactionStatus.Disputed)
                return enumTransactionStatus.Disputed.ToName();
            
            else
                return string.Empty;
        }

        public static string GetTransactionType(int tranType)
        {
            if (tranType == (int)enumTransactionType.Unknown)
                return enumTransactionType.Unknown.ToName();
            else if (tranType == (int)enumTransactionType.AuthRequest)
                return enumTransactionType.AuthRequest.ToName();
            else if (tranType == (int)enumTransactionType.Settlement)
                return enumTransactionType.Settlement.ToName();
            else if (tranType == (int)enumTransactionType.Surcharge)
                return enumTransactionType.Surcharge.ToName();
            if (tranType == (int)enumTransactionType.Fee)
                return enumTransactionType.Fee.ToName();
            else if (tranType == (int)enumTransactionType.Transfer)
                return enumTransactionType.Transfer.ToName();
            else if (tranType == (int)enumTransactionType.Reversal)
                return enumTransactionType.Reversal.ToName();
            else if (tranType == (int)enumTransactionType.ChangeBack)
                return enumTransactionType.ChangeBack.ToName();
            else if (tranType == (int)enumTransactionType.Adjustment)
                return enumTransactionType.Adjustment.ToName();
            else
                return string.Empty;
        }


        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

    }
}
