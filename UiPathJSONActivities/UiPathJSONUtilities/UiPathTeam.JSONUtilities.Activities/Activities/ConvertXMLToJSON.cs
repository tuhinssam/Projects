using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace UiPathTeam.JSONUtilities
{
    public class ConvertXMLToJSON : CodeActivity
    {

        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter XML input in string format")]
        public InArgument<string> InputXML { get; set; }

        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter path to read XML input")]
        public InArgument<string> InputFilePath { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Provides corresponding JSON of the XML")]
        public OutArgument<string> OutputJSON { get; set; }

        [DefaultValue(null)]
        public InArgument<bool> ContinueOnError { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string inputXML = string.Empty;
            string xmlFilepath = string.Empty;
            string xmlstring = string.Empty;

            try
            {
                inputXML = InputXML.Get(context);
                xmlFilepath = InputFilePath.Get(context);

                if (!string.IsNullOrEmpty(inputXML))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(inputXML);
                    string jsonText = JsonConvert.SerializeXmlNode(doc);
                    OutputJSON.Set(context, jsonText);
                }
                else if (!string.IsNullOrEmpty(xmlFilepath))
                {
                    xmlstring = File.ReadAllText(xmlFilepath, Encoding.UTF8);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlstring);
                    string jsonText = JsonConvert.SerializeXmlNode(doc);
                    OutputJSON.Set(context, jsonText);
                }
                else if (string.IsNullOrEmpty(inputXML) && string.IsNullOrEmpty(xmlFilepath))
                {
                    throw new Exception("Both of the input properties are empty.");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

                if (!ContinueOnError.Get(context))
                {
                    throw;
                }
            }
        }
    }
}
