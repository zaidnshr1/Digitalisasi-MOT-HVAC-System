
namespace Monitoring_System.Model
{
    public class ModelSetpoint
    {
        public string SetpointName { get; }
        public ushort SetpointPort { get; }
        public ushort? SetpointValue { get; set; }   // 16 bit
      //public float? SetpointValue {get; set;}         32 bit

        public ModelSetpoint(string setpointName, ushort setpointPort)
        {
            SetpointName = setpointName;
            SetpointPort = setpointPort;
        }

        public static List<ModelSetpoint> GetDefaultSetpointList() => new()
        {
            new ModelSetpoint("Temperature", 1212),
            new ModelSetpoint("Humidity", 1213)
        };
    }
}
