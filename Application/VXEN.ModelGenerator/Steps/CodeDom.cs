using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VXEN.ModelGenerator.Steps
{
    static class CodeDom
    {

        public static void FixMissingTransactionClasses(string xsdPath, string classpath, string xmlNamespace, string classNamespace, List<string> elementsToSkip)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CodeCompileUnit compileunit = new CodeCompileUnit();
            CodeNamespace codeNameSpace = new CodeNamespace(classNamespace);
            compileunit.Namespaces.Add(codeNameSpace);

            XDocument schema = XDocument.Load(xsdPath);
            var elements = from e in schema.Root.Elements()
                           select e;

            foreach (var element in elements)
            {
                string elementName = element.GetOptionalAttribute("name");
                string className = element.GetOptionalAttribute("type");

                if (!string.IsNullOrEmpty(elementName) && !string.IsNullOrEmpty(className))
                {
                    if (!elementsToSkip.Contains(elementName))
                    {
                        codeNameSpace.Types.Add(GenerateClass(elementName, className, xmlNamespace));
                    }
                }
            }

            // Create a TextWriter to a StreamWriter to the output file.
            using (StreamWriter sw = new StreamWriter(classpath, false))
            {
                using (IndentedTextWriter tw = new IndentedTextWriter(sw, "    "))
                {
                    provider.GenerateCodeFromCompileUnit(compileunit, tw, new CodeGeneratorOptions());
                    tw.Close();
                }
            }
        }

        public static CodeTypeDeclaration GenerateClass(string elementName, string parentClassName, string rootNamespace)
        {
            CodeTypeDeclaration generatedClass = new CodeTypeDeclaration("type" + elementName);
            var attr = new CodeAttributeDeclaration(new CodeTypeReference(typeof(System.Xml.Serialization.XmlRootAttribute)));
            var attributeArg1 = new CodeAttributeArgument(new CodePrimitiveExpression(elementName));
            var attributeArg2 = new CodeAttributeArgument("Namespace", new CodePrimitiveExpression(rootNamespace));
            var attributeArg3 = new CodeAttributeArgument("IsNullable", new CodePrimitiveExpression(false));
            attr.Arguments.Add(attributeArg1);
            attr.Arguments.Add(attributeArg2);
            attr.Arguments.Add(attributeArg3);
            generatedClass.CustomAttributes.Add(attr);
            generatedClass.BaseTypes.Add(parentClassName);
            generatedClass.TypeAttributes = TypeAttributes.Public;
            return generatedClass;
        }

        public static string GetOptionalAttribute(this XElement Element, string AttributeName)
        {
            string value = string.Empty;
            try
            {
                value = Element.Attribute(AttributeName).Value;
            }
            catch (Exception)
            {
            }
            return value;
        }
    }
}
