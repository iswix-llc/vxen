using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VXEN.ModelGenerator.Steps;

namespace VXEN.ModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Current Directory to EXE location
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileInfo fileInfo = new FileInfo(assembly.Location);
            Environment.CurrentDirectory = fileInfo.Directory.FullName;

            // Download Schemas from VANTIV and use XSD to generate classes
            Download.Prebuild();

            // Workaround missing classes due to XSD provided being invalid
            List<string> elementsToSkip = new List<string>();
            elementsToSkip.Add("TransactionSetup");
            elementsToSkip.Add("BatchUpload");
            CodeDom.FixMissingTransactionClasses(@"Transaction\express.xsd", @"Transaction\express-transaction-extensions.cs", "https://transaction.elementexpress.com", "VXEN.Models.Transaction", elementsToSkip);

            elementsToSkip.Clear();
            CodeDom.FixMissingTransactionClasses(@"Services\expressservices.xsd", @"Services\express-services-extensions.cs", @"https://services.elementexpress.com", "VXEN.Models.Services", elementsToSkip);

            CodeDom.FixMissingTransactionClasses(@"Reporting\expressreporting.xsd", @"Reporting\express-reporting-extensions.cs", @"https://reporting.elementexpress.com", "VXEN.Models.Reporting", elementsToSkip);

        }
    }
}
