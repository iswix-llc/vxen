using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VXEN.Models.Transaction;
using VXEN.Services;

namespace VXEN.TestApp.Tests
{
    public partial class Test
    {
        public static void CheckSaleTest()
        {
            var transaction = new typeTransaction();
            transaction.TransactionAmount = 100m;
            transaction.TransactionAmountSpecified = true;
            transaction.ReferenceNumber = "0001";
            transaction.MarketCode = "3";

            var demandDepositAccount = new typeDemandDepositAccount();
            demandDepositAccount.AccountNumber = "1663069001";
            demandDepositAccount.RoutingNumber = "250674111";
            demandDepositAccount.DDAAccountType = "1";
            

            var checkSale = new typeCheckSale();
            checkSale.Application = Utilities.CreateApplication();
            checkSale.Credentials = Utilities.CreateCredentials();
            checkSale.Terminal = Utilities.CreateTerminal();
            checkSale.Transaction = transaction;
            checkSale.DemandDepositAccount = demandDepositAccount;


            Server server = new Server();
            var task = server.SendToApiASync<typeCheckSale>(Settings.apiURL, checkSale);
            task.Wait();

            string data = task.Result;
            XDocument responseDocument = XDocument.Parse(task.Result);

            string expressResponseCode = responseDocument.GetElementValueFromResponse("ExpressResponseCode");
            string expressResponseMessage = responseDocument.GetElementValueFromResponse("ExpressResponseMessage");
            Console.WriteLine($"{expressResponseCode} : {expressResponseMessage}");
            Console.WriteLine("Full Response:");
            Console.WriteLine(responseDocument.ToString());

        }
    }
}
