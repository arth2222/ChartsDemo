using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace ChartsDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindChart();
            }
        }

        public void BindChart()
        {
            TempReading tr = new TempReading();
            List<TempReading> temps = tr.GetTempReadingsByYearMonthAndDay(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            Chart1.Series[0].XValueMember = "Hour";
            Chart1.Series[0].XValueType = ChartValueType.Int32;//optional
            Chart1.Series[0].YValueMembers = "Temp";
            Chart1.Series[0].ChartType = SeriesChartType.Line;

            //to serier=2 grafer/bars etc
            Chart1.Series[1].XValueMember = "Hour";
            Chart1.Series[1].XValueType = ChartValueType.Int32;//optional
            Chart1.Series[1].YValueMembers = "Humid";
            Chart1.Series[1].ChartType = SeriesChartType.Line;

            //Chart1.DataBindTable(temps,"Hour");//using just DataBind() below
            Chart1.ChartAreas[0].AxisX.Minimum = -1;
            Chart1.ChartAreas[0].AxisX.Maximum = 24;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            
            Chart1.DataSource = temps;
            Chart1.DataBind();

            for (int i = 0; i < temps.Count; i++)
                Chart1.Series[0].Points[i].ToolTip = temps[i].Temp.ToString() ;
        }




    }

    public class TempReading
    {
        public int Temp { get; set; }
        public int Humid { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }    
        public int Hour { get; set; }

        public List<TempReading> GetTempReadingsByYearMonthAndDay(int year,int month,int day)
        {
            Random r = new Random();
            List<TempReading> temps = new List<TempReading>();
            for(int i=0;i<24;i++)
            {
                TempReading temp = new TempReading();
                temp.Temp = r.Next(-2, 7);
                temp.Year = year; temp.Month = month; temp.Day = day;
                temp.Hour = i;
                temp.Humid = temp.Temp * 2;
                temps.Add(temp);
            }
            return temps;
        }

    }
}