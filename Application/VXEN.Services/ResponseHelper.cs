using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<string> GetElementValuesFromResponse(this XDocument responseDocument, string elementName)
        {

            var elements = from e in responseDocument.Descendants()
                           where e.Name.LocalName == elementName
                           select e.Value;
            return elements.ToList<string>();
        }

        public static Dictionary<string,string> GetResponseAsDictionary(this XDocument responseDocument)
        {
            var elements = from e in responseDocument.Descendants()
                            select e;
            return elements.ToDictionary(o => o.Name.LocalName, o => o.Value);
        }

    }
}
