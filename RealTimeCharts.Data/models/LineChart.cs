using System.Linq;
using Newtonsoft.Json;
using RealTimeCharts.Data.Generator;

namespace RealTimeCharts.Data.models
{
    public class LineChart
    {
        [JsonProperty("lineChartData")] private int[] _lineChartData;
        [JsonProperty("colorString")] private string _colorString;

        public void SetLineChartData()
        {
            _lineChartData = new int[7];

            for (var i = 0; i < _lineChartData.Length; i++)
            {
                _lineChartData[i] = RandomNumberGenerator.RandomScalingFactor();
            }

            _colorString = $"rgba({RandomNumberGenerator.RandomColorFactor()},{RandomNumberGenerator.RandomColorFactor()},{RandomNumberGenerator.RandomColorFactor()},.3)";
        }
    }
}