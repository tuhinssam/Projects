using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceAnalysisDemoWndForm
{
    class TicketResponse
    {
        public string SentTo { get; set; }
        public string SentFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Time { get; set; }
        public double Sentiment { get; set; }
    }
}
