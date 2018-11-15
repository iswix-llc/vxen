using System.Diagnostics;
using System.Net;
using Microsoft.VisualBasic.FileIO;

namespace VXEN.ModelGenerator.Steps
{
    class Download
    {

        public static void Prebuild()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile("https://transaction.elementexpress.com/express.xsd", @"Transaction\express.xsd");
                wc.DownloadFile("https://services.elementexpress.com/expressservices.xsd", @"Services\expressservices.xsd");
                wc.DownloadFile("https://reporting.elementexpress.com/expressreporting.xsd", @"Reporting\expressreporting.xsd");
                RunProgram(@"Transaction\express.xsd /classes /namespace:VXEN.Models.Transaction");
                RunProgram(@"Reporting\expressreporting.xsd /classes /namespace:VXEN.Models.Reporting");
                RunProgram(@"Services\expressservices.xsd /classes /namespace:VXEN.Models.Services");
                FileSystem.MoveFile("express.cs", @"Transaction\express.cs", true);
                FileSystem.MoveFile("expressservices.cs", @"Services\expressservices.cs", true);
                FileSystem.MoveFile("expressreporting.cs", @"Reporting\expressreporting.cs", true);
            }

        }

        public static void RunProgram(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = @"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\xsd.exe";
            psi.Arguments = arguments;
            Process proc = Process.Start(psi);
            proc.WaitForExit();
        }
    }
}
