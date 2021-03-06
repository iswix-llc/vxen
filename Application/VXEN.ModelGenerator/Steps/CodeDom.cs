﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.CSharp;

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
                        codeNameSpace.Types.Add(GenerateClass(elementName, elementName, className, xmlNamespace));
                    }
                }
            }

            if (xsdPath == @"Transaction\express.xsd")
            {
                codeNameSpace.Types.Add(GenerateClass("TransactionSetupMethod", "TransactionSetup", "typeTransactionObjects", xmlNamespace));
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

        public static CodeTypeDeclaration GenerateClass(string className, string rootElement, string parentClassName, string rootNamespace)
        {
            CodeTypeDeclaration generatedClass = new CodeTypeDeclaration("type" + className);
            var attr = new CodeAttributeDeclaration(new CodeTypeReference(typeof(System.Xml.Serialization.XmlRootAttribute)));
            var attributeArg1 = new CodeAttributeArgument(new CodePrimitiveExpression(rootElement));
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

        public static void RemoveUnwantedDefaultValueAttributes(string classPath)
        {
            var oldLines = File.ReadAllLines(classPath).ToList<string>();
            var newLines = new List<string>();

            foreach (var oldLine in oldLines)
            {
                if(!oldLine.Contains("System.ComponentModel.DefaultValueAttribute"))
                {
                    newLines.Add(oldLine);
                }
            }

            File.Delete(classPath);
            File.WriteAllLines(classPath, newLines);
            Console.WriteLine("PAK" );
        }
    }
}
