using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace UiPathTeam.JSONUtilities
{
    public class ValidateXML : CodeActivity
    {

        [DefaultValue(null)]
        [Description("Enter XML input in string format")]
        [Category("Input")]
        public InArgument<string> InputXMLString { get; set; }

        [DefaultValue(null)]
        [Description("Enter file path to read XML input")]
        [Category("Input")]
        public InArgument<string> InputXMLFilePath { get; set; }

        [DefaultValue(null)]
        [Description("Returns True/False based on validation")]
        [Category("Output")]
        public OutArgument<bool> Result { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Return Exception message if there is any exception")]
        public OutArgument<string> OutputExceptionMessage { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                string strXML = InputXMLString.Get(context);
                string xmlFilepath = InputXMLFilePath.Get(context);

                if(!string.IsNullOrEmpty(strXML))
                {
                    XDocument xdoc = XDocument.Parse(strXML);
                    Result.Set(context, true);
                    OutputExceptionMessage.Set(context, "");
                }
                else if(!string.IsNullOrEmpty(xmlFilepath))
                {
                    string inputXML = File.ReadAllText(xmlFilepath, Encoding.UTF8);
                    XDocument xdoc = XDocument.Parse(inputXML);
                    Result.Set(context, true);
                    OutputExceptionMessage.Set(context, "");
                }
                else if (string.IsNullOrEmpty(strXML) && string.IsNullOrEmpty(xmlFilepath))
                {
                    throw new Exception("InputXMLString and InputXMLFilePath both fields are empty");
                }
            }
            catch (Exception ex)
            {
                OutputExceptionMessage.Set(context, ex.Message);
                Result.Set(context, false);
                Trace.TraceError(ex.StackTrace);
            }
            
        }
    }
}
