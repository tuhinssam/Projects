using Google.Cloud.Language.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentenceAnalysisDemoWndForm
{
    public partial class Form1 : Form
    {
        public enum PredictedCustomerFeedbacks {Outstanding, Excellent, Good, Poor, VeryPoor, CannotBeDetermined}
        string[] ticketFileList = null;
        List<TicketResponse> ticketData = new List<TicketResponse>();
        //Dictionary<string, List<TicketResponse>> dictTicket = new Dictionary<string, List<TicketResponse>>();
        string ticketDataPath = "TicketInfo";
        List<double> listCustomerScores = new List<double>();
        List<double> listAgentScores = new List<double>();

        public Form1()
        {
            //load all ticket data
            ticketFileList = Directory.GetFiles(ticketDataPath);
            
            InitializeComponent();

            chartSentiment.ChartAreas[0].AxisY.Maximum = 1;
            chartSentiment.ChartAreas[0].AxisY.Minimum = -1;
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            //delete later
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool ticketFound = false;       
            foreach (string ticketFilePath in ticketFileList)
            {
                string ticketNum = Path.GetFileName(ticketFilePath).Split('.').First();

                if(ticketNum == txtSearchVal.Text)
                {
                    lblAgentScore.Text = "Loading...";
                    lblCustomerScore.Text = "Loading...";
                    lblPredictedScore.Text = "Loading...";
                    ticketFound = true;

                    TicketData ticketDetails = JsonConvert.DeserializeObject<TicketData>(File.ReadAllText(ticketFilePath));
                    List<TicketResponse> lstTicketResponses = ticketDetails.TicketResponses;
                    List<UserResponseBody> listAgentResonseBody = new List<UserResponseBody>();
                    List<UserResponseBody> listCustResonseBody = new List<UserResponseBody>();

                    //dgAgentResponses.DataSource = (from c in lstTicketResponses
                    //                     where c.SentFrom == "uipathsupport@uipath.com"
                    //                     select new UserResponseBody
                    //                     {
                    //                         Body = c.Body
                    //                     }).ToList<UserResponseBody>();

                    //dgCustomerRes.DataSource = (from c in lstTicketResponses
                    //                     where c.SentFrom != "uipathsupport@uipath.com"
                    //                     select new UserResponseBody
                    //                     {
                    //                         Body = c.Body
                    //                     }).ToList<UserResponseBody>();

                    //categorize AgentResponse/Customer response
                    foreach (TicketResponse agentRes in lstTicketResponses.Where(obj => obj.SentFrom == "uipathsupport@uipath.com").ToList())
                    {
                        UserResponseBody objURD = new UserResponseBody();
                        double textAnalysisScore = getTextAnalysisScore(agentRes.Body);
                        listAgentScores.Add(textAnalysisScore);
                        agentRes.Sentiment = textAnalysisScore;
                        objURD.Body = agentRes.Body;
                        objURD.Sentiment = agentRes.Sentiment;
                        listAgentResonseBody.Add(objURD);
                    }
                    foreach (TicketResponse custRes in lstTicketResponses.Where(obj => obj.SentFrom != "uipathsupport@uipath.com").ToList())
                    {
                        UserResponseBody objURD = new UserResponseBody();
                        double textAnalysisScore = getTextAnalysisScore(custRes.Body);
                        listCustomerScores.Add(textAnalysisScore);
                        custRes.Sentiment = textAnalysisScore;
                        objURD.Body = custRes.Body;
                        objURD.Sentiment = custRes.Sentiment;
                        listCustResonseBody.Add(objURD);
                    }

                    dgAgentResponses.DataSource = listAgentResonseBody;
                    dgCustomerRes.DataSource = listCustResonseBody;

                    //set values calculated values in label
                    double agentMedoianScore = calculateMedian(listAgentScores);
                    double customerMedoianScore = calculateMedian(listCustomerScores);

                    lblAgentScore.Text = Convert.ToString(agentMedoianScore);
                    lblCustomerScore.Text = Convert.ToString(customerMedoianScore);

                    string predictedScore = PredictedScore(agentMedoianScore, customerMedoianScore, listCustResonseBody.Count);
                    lblPredictedScore.Text = predictedScore;

                    
                    //Prepare chart from the score obtained
                    foreach (double score in listAgentScores)
                    {
                        chartSentiment.Series["AgentScore"].Points.AddY(score);
                    }
                    foreach (double score in listCustomerScores)
                    {
                        chartSentiment.Series["CustScore"].Points.AddY(score);
                    }
                }
                
            }
            if (ticketFound == false)
                MessageBox.Show("No Ticket found with Searched data!");
             
        }

        /// <summary>
        /// Predict Score
        /// </summary>
        /// <param name="agentMedianScore"></param>
        /// <param name="customerMedianScore"></param>
        /// <returns></returns>
        private string PredictedScore(double agentMedianScore, double customerMedianScore, int custResCount)
        {
            double scoreToCheck = 0;

            if (customerMedianScore > 0 && agentMedianScore > 0)
            {
                scoreToCheck = customerMedianScore;
            }
           else if (customerMedianScore > 0 && agentMedianScore < 0)
            {
                scoreToCheck = customerMedianScore;
            }
            else if (customerMedianScore > 0 && agentMedianScore == 0)
            {
                scoreToCheck = customerMedianScore;
            }
            else if (customerMedianScore == 0 && agentMedianScore < 0)
            {
                scoreToCheck = customerMedianScore;
            }
            else if (customerMedianScore == 0 && agentMedianScore == 0)
            {
                scoreToCheck = customerMedianScore;
            }
            else if (customerMedianScore < 0 && agentMedianScore > 0)
            {
                scoreToCheck = customerMedianScore;
            }
            else if (customerMedianScore < 0 && agentMedianScore < 0)
            {
                if (customerMedianScore < agentMedianScore)
                {
                    scoreToCheck = customerMedianScore;
                }
                else
                {
                    scoreToCheck = agentMedianScore;
                }
            }

            if (custResCount == 0)
                return PredictedCustomerFeedbacks.CannotBeDetermined.ToString();
            else
            {
                if (scoreToCheck == 0)
                    return PredictedCustomerFeedbacks.Good.ToString();
                else if(scoreToCheck < 0 && scoreToCheck <= -0.5)
                    return PredictedCustomerFeedbacks.Poor.ToString();
                else if (scoreToCheck < 0.5 && scoreToCheck <= -1)
                    return PredictedCustomerFeedbacks.VeryPoor.ToString();
                else if (scoreToCheck > 0 && scoreToCheck <= 0.5)
                    return PredictedCustomerFeedbacks.Excellent.ToString();
                else if (scoreToCheck > 0.5 && scoreToCheck <= 1)
                    return PredictedCustomerFeedbacks.Outstanding.ToString();
                else
                    return PredictedCustomerFeedbacks.CannotBeDetermined.ToString();
            }
        }

        /// <summary>
        /// Get Sentiment Analysis Score
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private static double getTextAnalysisScore(string sentence)
        {
            #region TextAnalysis
            
            var client = LanguageServiceClient.Create();

            var response = client.AnalyzeSentiment(new Document()
            {
                Content = sentence,
                Type = Document.Types.Type.PlainText
            });

            var sentiment = response.DocumentSentiment;

            Console.WriteLine(sentence);
            Console.WriteLine($"Overall Score: {sentiment.Score}");
            Console.WriteLine($"Magnitude: {sentiment.Magnitude}");
            //Console.ReadLine();
            #endregion
            return sentiment.Score;
        }

        /// <summary>
        /// Calculate Median Score from reponses
        /// </summary>
        /// <param name="agentResScoreList"></param>
        /// <returns></returns>
        private static double calculateMedian(List<double> agentResScoreList)
        {
            int numberCount = agentResScoreList.Count();
            int halfIndex = agentResScoreList.Count() / 2;
            var sortedNumbers = agentResScoreList.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = ((sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1))) / 2;
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            return median;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listCustomerScores.Clear();
            listAgentScores.Clear();
        }
    }
}
