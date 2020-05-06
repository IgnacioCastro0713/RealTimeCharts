using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using RealTimeCharts.Data.models;
using RealTimeCharts.Web.Hubs;

namespace RealTimeCharts.Web.services
{
    public class ChartDataUpdate
    {
        // Singleton instance    
        private static readonly Lazy<ChartDataUpdate>
            _instance = new Lazy<ChartDataUpdate>(() => new ChartDataUpdate());

        // Send Data every 5 seconds    
        readonly int _updateInterval = 5000;

        //Timer Class    
        private Timer _timer;
        private volatile bool _sendingChartData = false;
        private readonly object _chartUpdateLock = new object();
        private readonly LineChart _lineChart = new LineChart();
        private readonly PieChart _pieChart = new PieChart();

        private ChartDataUpdate()
        {
        }

        public static ChartDataUpdate Instance => _instance.Value;

        // Calling this method starts the Timer    
        public void GetChartData() => _timer = new Timer(ChartTimerCallBack, null, _updateInterval, _updateInterval);

        private void ChartTimerCallBack(object state)
        {
            if (_sendingChartData)
            {
                return;
            }

            lock (_chartUpdateLock)
            {
                if (!_sendingChartData)
                {
                    _sendingChartData = true;
                    SendChartData();
                    _sendingChartData = false;
                }
            }
        }

        private void SendChartData()
        {
            _lineChart.SetLineChartData();
            _pieChart.SetPieChartData();
            GetAllClients().All.UpdateChart(_lineChart, _pieChart);
        }

        private static dynamic GetAllClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<ChartHub>().Clients;
        }
    }
}