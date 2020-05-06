using Microsoft.AspNet.SignalR;
using RealTimeCharts.Data.models;
using RealTimeCharts.Web.services;

namespace RealTimeCharts.Web.Hubs
{
    public class ChartHub : Hub
    {
        private readonly ChartDataUpdate _chartInstance;

        public ChartHub() : this(ChartDataUpdate.Instance)
        {
        }

        private ChartHub(ChartDataUpdate chartInstance) => _chartInstance = chartInstance;

        public void InitChartData()
        {
            var lineChart = new LineChart();
            var pieChart = new PieChart();
            lineChart.SetLineChartData();
            pieChart.SetPieChartData();
            Clients.All.UpdateChart(lineChart, pieChart);


            //Call GetChartData to send Chart data every 5 seconds
            _chartInstance.GetChartData();
        }
    }
}