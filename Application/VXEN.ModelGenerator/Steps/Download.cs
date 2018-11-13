using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VXEN.ModelGenerator.Steps
{
    class Download
    {

        public static void GenerateClasses()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile("https://transaction.elementexpress.com/express.xsd", @"Transaction\express.xsd");
                wc.DownloadFile("https://services.elementexpress.com/expressservices.xsd", @"Services\expressservices.xsd");
                wc.DownloadFile("https://reporting.elementexpress.com/expressreporting.xsd", @"Reporting\expressreporting.xsd");
            }

            string xsdPath = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\xsd.exe";
            Process.Start(xsdPath, @"Transaction\express.xsd /classes /namespace:VXEN.Models.Transaction");
            Process.Start(xsdPath, @"Reporting\expressreporting.xsd /classes /namespace:VXEN.Models.Reporting");
            Process.Start(xsdPath, @"Services\expresservices.xsd /classes /namespace:VXEN.Models.Services");
        }
    }
}
