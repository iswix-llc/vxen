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
            terminal.CardPresentCode = "3";
            terminal.CardholderPresentCode = "4";
            terminal.CardInputCode = "4";
            terminal.CVVPresenceCode = "2";
            terminal.TerminalCapabilityCode = "2";
            terminal.TerminalEnvironmentCode = "6";
            terminal.MotoECICode = $"7";
            return terminal;
        }
    }
}
