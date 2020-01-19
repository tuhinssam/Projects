using Newtonsoft.Json.Linq;
using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace UiPathTeam.JSONUtilities
{
    public class ValidateJSONWithoutSchema : CodeActivity
    {
        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter JSON input in string format")]
        public InArgument<string> InputJSON { get; set; }

        [Category("Input")]
        [DefaultValue(null)]
        [Description("Enter JSON input file path in string format")]
        public InArgument<string> InputJSONFilePath { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Result is True/False")]
        public OutArgument<bool> Result { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Contains reason for the invalid json")]
        public OutArgument<string> OutputException { get; set; }

        [DefaultValue(null)]
        public InArgument<bool> ContinueOnError { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string inputJSON = string.Empty;
            string jsonFilePath = string.Empty;

            try
            {
                inputJSON = InputJSON.Get(context);
                jsonFilePath = InputJSONFilePath.Get(context);

                bool isvalidJson = true;

                try
                {
                    if (!string.IsNullOrEmpty(inputJSON))
                    {
                        var jsonObject = JObject.Parse(inputJSON);
                    }
                    else if (!string.IsNullOrEmpty(jsonFilePath))
                    {
                        string jsonString = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                        var jsonObject = JObject.Parse(jsonString);
                    }
                    else if (string.IsNullOrEmpty(inputJSON) && string.IsNullOrEmpty(jsonFilePath))
                    {
                        throw new Exception("Both of the input properties are empty.");
                    }

                }
                catch (FormatException fex)
                {
                    OutputException.Set(context, fex.Message);
                    Result.Set(context, false);
                    isvalidJson = false;
                    //Console.WriteLine(fex);
                }
                catch (Exception ex) //some other exception
                {
                    OutputException.Set(context, ex.Message);
                    Result.Set(context, false);
                    isvalidJson = false;
                    //Console.WriteLine(ex.ToString());
                }

                if (isvalidJson)
                    Result.Set(context, true);
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

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }
    }
}
