
namespace Monitoring_System.Model
{
    public class ModelMonitoring
    {
        public string MonitoringName { get; }
        public ushort MonitoringPort { get; }
        public ushort? MonitoringValue { get; set; }  // 16 bit
      //public int? MonitoringValue { get; set; }        32 bit

        public ModelMonitoring(string monitoringName, ushort monitoringPort)
        {
            MonitoringName = monitoringName;
            MonitoringPort = monitoringPort;
        }

        public static List<ModelMonitoring> GetDefaultMonitoringList() => new()
        {
            new ModelMonitoring("Temperature", 1413),
            new ModelMonitoring("Humidity", 1416),
            new ModelMonitoring("Pressure", 578),
            new ModelMonitoring("VSD", 1289)
        };
    }
}
