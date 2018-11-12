using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VXEN.TestApp
{
    class Settings
    {
        static public string AccountID
        {
            get
            {
                return ConfigurationManager.AppSettings["AccountId"];
            }
        }

        static public string AccountToken
        {
            get
            {
                return ConfigurationManager.AppSettings["AccountToken"];
            }
        }

        static public string ApplicationID
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationID"];
            }
        }

        static public string AcceptorID
        {
            get
            {
                return ConfigurationManager.AppSettings["AcceptorID"];
            }
        }

        static  public Uri apiURL
        {
            get
            {
                return new Uri(ConfigurationManager.AppSettings["ApiURL"]);
            }
        }

    }
}
