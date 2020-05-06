using Newtonsoft.Json;
using RealTimeCharts.Data.Generator;

namespace RealTimeCharts.Data.models
{
    public class PieChart
    {
        [JsonProperty("value")] private int[] _pieChartData;

        public void SetPieChartData()
        {
            _pieChartData = new int[3];

            for (int i = 0; i < _pieChartData.Length; i++)
            {
                _pieChartData[i] = RandomNumberGenerator.RandomScalingFactor();
            }
        }
    }
}