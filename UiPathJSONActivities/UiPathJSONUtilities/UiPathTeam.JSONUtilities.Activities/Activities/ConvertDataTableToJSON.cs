using System;
using System.Activities;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using UiPathTeam.JSONUtilities.Activities;
using UiPathTeam.JSONUtilities.Activities.Properties;

namespace UiPathTeam.JSONUtilities
{
    public class ConvertDataTableToJSON: CodeActivity
    {
        [RequiredArgument]
        [Description("Enter DataTable input")]
        [Category("Input")]
        public InArgument<System.Data.DataTable> InputDataTable { get; set; }

        [DefaultValue(null)]
        [Description("Generates output JSON String")]
        [Category("Output")]
        public OutArgument<string> OutputJSONString { get; set; }

        [DefaultValue(null)]
        [Description("true/false")]
        public InArgument<bool> ContinueOnError { get; set; }

        [DefaultValue(null)]
        [Category("Output")]
        [Description("ExceptionMessage")]
        public OutArgument<string> OutputExceptionMessage { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                DataTable dt = InputDataTable.Get(context);
                //string tableName = InputTableName.Get(context);

                var JSONString = new StringBuilder();
                if (dt.Rows.Count > 0)
                {
                    JSONString.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        JSONString.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (j < dt.Columns.Count - 1)
                            {
                                JSONString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\",");
                            }
                            else if (j == dt.Columns.Count - 1)
                            {
                                JSONString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + "\"" + dt.Rows[i][j].ToString() + "\"");
                            }
                        }
                        if (i == dt.Rows.Count - 1)
                        {
                            JSONString.Append("}");
                        }
                        else
                        {
                            JSONString.Append("},");
                        }
                    }
                    JSONString.Append("]");
                }

                OutputJSONString.Set(context, JSONString.ToString());
            }
            catch(Exception ex)
            {
                OutputExceptionMessage.Set(context, ex.Message);

                Trace.TraceError(ex.ToString());

                if (!ContinueOnError.Get(context))
                {
                    throw;
                }
            }
        }
    }
}
