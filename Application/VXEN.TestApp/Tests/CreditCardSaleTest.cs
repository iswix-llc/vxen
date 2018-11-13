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
        public static void CreditCardSale()
        {
            var transaction = new typeTransaction();
            transaction.TransactionAmount = 100m;
            transaction.TransactionAmountSpecified = true;
            transaction.ReferenceNumber = "AIS1234";

            var card = new typeCard();
            card.CardNumber = "5499990123456781";
            card.ExpirationMonth = "12";
            card.ExpirationYear = "19";

            var creditCardSale = new typeCreditCardSale();
            creditCardSale.Application = Utilities.CreateApplication();
            creditCardSale.Credentials = Utilities.CreateCredentials();
            creditCardSale.Terminal = Utilities.CreateTerminal();
            creditCardSale.Transaction = transaction;
            creditCardSale.Card = card;


            Server server = new Server();
            var task = server.SendToApiASync<typeCreditCardSale>(Settings.apiURL, creditCardSale);
            task.Wait();

            XDocument responseDocument = XDocument.Parse(task.Result);


            string expressResponseCode = responseDocument.GetElementValueFromResponse("ExpressResponseCode");
            string expressResponseMessage = responseDocument.GetElementValueFromResponse("ExpressResponseMessage");
            Console.WriteLine($"{expressResponseCode} : {expressResponseMessage}");
            Console.WriteLine("Full Response:");
            Console.WriteLine(responseDocument.ToString());
        }
    }
}
