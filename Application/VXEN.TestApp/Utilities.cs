using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VXEN.Models.Transaction;

namespace VXEN.TestApp
{
    class Utilities
    {
        public static typeApplication CreateApplication()
        {
            var application = new typeApplication();
            application.ApplicationID = Settings.ApplicationID;
            application.ApplicationName = "VXEN.TestApp";
            application.ApplicationVersion = "1.0.0";
            return application;
        }

        public static typeCredentials CreateCredentials()
        {
            var credentials = new typeCredentials();
            credentials.AcceptorID = Settings.AcceptorID;
            credentials.AccountID = Settings.AccountID;
            credentials.AccountToken = Settings.AccountToken;
            return credentials;
        }

        public static typeTerminal CreateTerminal()
        {
            var terminal = new typeTerminal();
            terminal.TerminalID = Environment.MachineName;
            terminal.CardPresentCode = $"{(int)CardPresentCode.NotPresent}";
            terminal.CardholderPresentCode = $"{(int)CardHolderPresentCode.MailOrder}";
            terminal.CardInputCode = $"{(int)CardInputCode.ManualKeyed}";
            terminal.CVVPresenceCode = $"{(int)CVVPresenceCode.Provided}";
            terminal.TerminalCapabilityCode = $"{(int)TerminalCapabilityCode.KeyEntered}";
            terminal.TerminalEnvironmentCode = $"{(int)TerminalEnvironmentCode.Ecommerce}";
            terminal.MotoECICode = $"{(int)MotoEciCode.Recurring}";
            return terminal;
        }
    }
}
