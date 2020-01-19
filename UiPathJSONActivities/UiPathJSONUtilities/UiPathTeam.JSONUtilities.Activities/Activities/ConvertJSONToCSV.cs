using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace UiPathTeam.JSONUtilities
{
    public class ConvertJSONToCSV: CodeActivity
    {

        [DefaultValue(null)]
        [Description("Enter JSON input")]
        [Category("Input")]
        public InArgument<string> InputJSON { get; set; }

        [DefaultValue(null)]
        [Description("Enter path to read JSON input")]
        [Category("Input")]
        public InArgument<string> InputJSONFilePath { get; set; }

        [DefaultValue(null)]
        [Description("Enter output CSV file location")]
        [Category("Output")]
        public InArgument<string> OutputCSVFilePath { get; set; }
        
        [DefaultValue(null)]
        [Description("true/false")]
        public InArgument<bool> ContinueOnError { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            DataTable dt = new DataTable();
            string jsonString = string.Empty;
            string jsonFilePath = string.Empty;
            string csvFilePath = string.Empty;

            jsonFilePath = InputJSONFilePath.Get(context);
            jsonString = InputJSON.Get(context);
            csvFilePath = OutputCSVFilePath.Get(context);


            try
            {
                if (!string.IsNullOrEmpty(jsonString))
                {
                    //convert json to datatable
                    dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
                }
                else if (!string.IsNullOrEmpty(jsonFilePath))
                {
                    dt = JsonConvert.DeserializeObject<DataTable>(File.ReadAllText(jsonFilePath, Encoding.UTF8));
                }
                else if (string.IsNullOrEmpty(jsonFilePath) && string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Both Input parameters are empty or null");
                }

                //convert datatable to csv
                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText(csvFilePath, sb.ToString());

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
    }
}
