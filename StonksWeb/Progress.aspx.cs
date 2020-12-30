using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;

namespace StonksWeb
{
    public partial class Progress : Page
    {
        public Color Transparent { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillChart();
            var values = GetAdvice();
            var score = GetPotencialScore();
            var moneyForExpenses = values["Expenses"].ToString();
            var recommendedValues = GetRecommendedValues(moneyForExpenses);

            LoadAdvice(values, recommendedValues, score);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Income.InnerText = FinancialPlanController.ActivePlan.Income.ToString("€#.#");
            Spendings.InnerText = FinancialPlanController.ActivePlan.GetSpendings().ToString("€#.#");
        }

        private void FillChart()
        {
            chartPlanned.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chartPlanned.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;

            chartPlanned.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chartPlanned.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            chartPlanned.ChartAreas[0].AxisX.LineColor = Color.White;
            chartPlanned.ChartAreas[0].AxisY.LineColor = Color.White;

            chartPlanned.ChartAreas[0].BackColor = Color.Transparent;

            chartPlanned.Series["Monthly Expenses"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
            //ExpensesChart 
            foreach (Expense expense in FinancialPlanController.ActivePlan.Expenses)
            {
                try
                {
                    chartPlanned.Series["Monthly Expenses"].Points.AddXY(
                    FinancialPlanController.ActivePlan.GetExpense(expense.Type).Type.ToString(),
                    FinancialPlanController.ActivePlan.GetExpense(expense.Type).Value);
                }
                catch(Exception e)
                {
                    LoadError(e);
                }
            }
        }

        private void LoadError(Exception e) {
            Console.WriteLine(e);
            Console.Write("There was an error loading some data");
            Label1.Text = "There was an error trying to load the data." + e;
        }

        private Dictionary<string, double> GetRecommendedValues(string moneyForExpenses) 
        {
            string strurl = string.Format("https://localhost:5001/api/progress/RecommendedValues?usedForExpenses=" + moneyForExpenses);
            WebRequest requestObjectGet = WebRequest.Create(strurl);
            requestObjectGet.Method = "GET";
            HttpWebResponse responseObjectGet = null;
            try
            {
                responseObjectGet = (HttpWebResponse)requestObjectGet.GetResponse();
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }

            string strresult = null;
            using (Stream stream = responseObjectGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            var recommendedValues = JsonConvert.DeserializeObject<Dictionary<string, double>>(strresult);

            return recommendedValues;
        }

        private double GetPotencialScore() 
        {
            string strurl = string.Format("https://localhost:5001/api/progress/GetPotencialScore?income=" + FinancialPlanController.ActivePlan.Income.ToString());
            WebRequest requestObjectGet = WebRequest.Create(strurl);
            requestObjectGet.Method = "GET";
            HttpWebResponse responseObjectGet = null;
            try
            {
                responseObjectGet = (HttpWebResponse)requestObjectGet.GetResponse();
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }

            string strresult = null;
            using (Stream stream = responseObjectGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            var score = JsonConvert.DeserializeObject<double>(strresult);

            return score;
        }

        private Dictionary<string, double> GetAdvice() 
        {
            string strurl = string.Format("https://localhost:5001/api/progress/GetAdvice?income=" + FinancialPlanController.ActivePlan.Income.ToString());
            WebRequest requestObjectGet = WebRequest.Create(strurl);
            requestObjectGet.Method = "GET";
            HttpWebResponse responseObjectGet;
            try
            {
                responseObjectGet = (HttpWebResponse)requestObjectGet.GetResponse();
            }
            catch (Exception e1)
            {
                throw new Exception(e1.Message);
            }

            string strresult = null;
            using (Stream stream = responseObjectGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresult = sr.ReadToEnd();
                sr.Close();
            }

            var values = JsonConvert.DeserializeObject<Dictionary<string, double>>(strresult);

            return values;
        }

        private void LoadAdvice(Dictionary<string, double> values, Dictionary<string, double> recommendedValues, double score) {
            var moneyForInvesting = FinancialPlanController.ActivePlan.Income - FinancialPlanController.ActivePlan.GetSpendings() - FinancialPlanController.ActivePlan.Income*0.3;
            AdviceTextBox.Text = values["Investing"].ToString() + "€";
            ExpenseTextBox.Text = values["Expenses"].ToString() + "€";
            SaveTextBox.Text = values["Savings"].ToString() + "€";
            House.Text = (recommendedValues["Housing"].ToString("€#.#"));
            Food.Text = (recommendedValues["Groceries"].ToString("€#.#"));
            Transport.Text = (recommendedValues["Transport"].ToString("€#.#"));
            Entertain.Text = (recommendedValues["Entertainment"].ToString("€#.#"));
            Shop.Text = (recommendedValues["Shopping"].ToString("€#.#"));
            Health.Text = (recommendedValues["Health"].ToString("€#.#"));
            Utilities.Text = (recommendedValues["Utilities"].ToString("€#.#"));
            Other.Text = (recommendedValues["Other"].ToString("€#.#"));
            Score.Text = score.ToString("€#.#");
            SavedMoney.Text = (values["Investing"] * 120).ToString("€#.#");

            InvestingText.InnerText = "💰 Do you want to know how much money you could have if you kept investing " + values["Investing"].ToString("€#.#") + " every month for 10 years?";

            if (moneyForInvesting >= values["Savings"])
            {
                Reached.Visible = true;
            }
            else
            {
                NotReached.Visible = true;
                PotencialScore.Visible = true;
            }

            if (FinancialPlanController.ActivePlan.GetSpendings() <= values["Savings"])
            {
                Div1.Visible = true;
            }
            else
            {
                Div2.Visible = true;
                Recommended.Visible = true;
            }

            if (FinancialPlanController.ActivePlan.GetSavings() >= values["Savings"])
            {
                Div3.Visible = true;
            }
            else
            {
                Div4.Visible = true;
            }
        }
    }
}