using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VXEN.Services
{
    public static class ResponseHelper
    {
        public static string GetElementValueFromResponse(this XDocument responseDocument, string elementName)
        {
            string data = string.Empty;

            try
            {
                var elements = from e in responseDocument.Descendants()
                              where e.Name.LocalName == elementName
                               select e;
                data = elements.First().Value;

            }
            catch(Exception)
            {
            }

            return data;
        }
    }
}
