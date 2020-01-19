using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace UiPathTeam.JSONUtilities
{
    public class ValidateJSONWithSchema:CodeActivity
    {
        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter JSON Schema in string format")]
        public InArgument<string> InputJSONSchemaPath { get; set; }

        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter JSON Schema in string format")]
        public InArgument<string> InputJSONSchema { get; set; }

        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter JSON input in string format")]
        public InArgument<string> InputJSONString { get; set; }

        [DefaultValue(null)]
        [Category("Input")]
        [Description("Enter path to read JSON input")]
        public InArgument<string> InputJSONFilePath { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Is Valid JSON")]
        public OutArgument<bool> Result { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("Enter path to read JSON input")]
        public OutArgument<string> OutException { get; set; }

        [DefaultValue(null)]
        public InArgument<bool> ContinueOnError { get; set; }

        
        protected override void Execute(CodeActivityContext context)
        {
            string inputJsonSchema = string.Empty;
            string jsonSchemaFilePath = string.Empty;
            string inputJSON = string.Empty;
            string inputJsonFilePath = string.Empty;
            bool isvalid = true;

            try
            {
                inputJsonSchema = InputJSONSchema.Get(context);
                jsonSchemaFilePath = InputJSONSchemaPath.Get(context);
                inputJSON = InputJSONString.Get(context);
                inputJsonFilePath = InputJSONFilePath.Get(context);

                string json = string.Empty;
                string jsonSchema = string.Empty;

                if (string.IsNullOrEmpty(jsonSchemaFilePath) && string.IsNullOrEmpty(inputJsonSchema))
                {
                    throw new Exception("JSON Schema is empty");
                }
                else if (!string.IsNullOrEmpty(inputJsonSchema))
                {
                    jsonSchema = inputJsonSchema;
                }
                else if (!string.IsNullOrEmpty(jsonSchemaFilePath))
                {
                    jsonSchema = File.ReadAllText(jsonSchemaFilePath, Encoding.UTF8);
                }

                if (string.IsNullOrEmpty(inputJSON) && string.IsNullOrEmpty(inputJsonFilePath))
                {
                    throw new Exception("JSON data is empty");
                }
                else if (!string.IsNullOrEmpty(inputJSON))
                {
                    json = inputJSON;
                }
                else if (!string.IsNullOrEmpty(inputJsonFilePath))
                {
                    json = File.ReadAllText(inputJsonFilePath, Encoding.UTF8);
                }

                JsonSchema schema = JsonSchema.Parse(jsonSchema);
                JObject objJson = JObject.Parse(json);
                isvalid = objJson.IsValid(schema);

                Result.Set(context, isvalid);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.StackTrace);

                if (!ContinueOnError.Get(context))
                {
                    OutException.Set(context, ex.Message);
                    Result.Set(context, false);
                    throw;
                }
            }
        }
    }
}
