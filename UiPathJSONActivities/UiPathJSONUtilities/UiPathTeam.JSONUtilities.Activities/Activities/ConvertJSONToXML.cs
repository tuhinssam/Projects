using Newtonsoft.Json;
using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace UiPathTeam.JSONUtilities
{
    public class ConvertJSONToXML : CodeActivity
    {
        [DefaultValue(null)]
        [Description("Enter JSON input in string format")]
        [Category("Input")]
        public InArgument<string> InputJSON { get; set; }

        [DefaultValue(null)]
        [Description("Enter path to read JSON input")]
        [Category("Input")]
        public InArgument<string> InputJSONFilePath { get; set; }

        [DefaultValue(null)]
        [Description("Provides corresponding XML of the JSON")]
        [Category("Output")]
        public OutArgument<string> OutputXML { get; set; }

        [DefaultValue(null)]
        [Description("true/false")]
        public InArgument<bool> ContinueOnError { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                string inputJSON = string.Empty;
                string jsonFilePath = string.Empty;

                inputJSON = InputJSON.Get(context);
                jsonFilePath = InputJSONFilePath.Get(context);

                if (!string.IsNullOrEmpty(inputJSON))
                {
                    XmlDocument doc = JsonConvert.DeserializeXmlNode(inputJSON);
                    OutputXML.Set(context, doc.InnerXml);
                }
                else if (!string.IsNullOrEmpty(jsonFilePath))
                {
                    string inputJsonFromFile = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                    XmlDocument doc = JsonConvert.DeserializeXmlNode(inputJsonFromFile);
                    OutputXML.Set(context, doc.InnerXml);
                }
                else if (string.IsNullOrEmpty(inputJSON) && string.IsNullOrEmpty(jsonFilePath))
                {
                    throw new Exception("Both Input arguments are Null or Empty");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.StackTrace);

                if (!ContinueOnError.Get(context))
                {
                    throw;
                }
            }
        }

        private string HandleSpecialChars(string inputJSON)
        {
           
                string toxml = inputJSON;
                if (!string.IsNullOrEmpty(toxml))
                {
                    // replace literal values with entities
                    toxml = toxml.Replace("&", "&amp;");
                    toxml = toxml.Replace("'", "&apos;");
                    toxml = toxml.Replace("\"", "&quot;");
                    toxml = toxml.Replace(">", "&gt;");
                    toxml = toxml.Replace("<", "&lt;");
                }
                return toxml;
        }
    }
    
}
