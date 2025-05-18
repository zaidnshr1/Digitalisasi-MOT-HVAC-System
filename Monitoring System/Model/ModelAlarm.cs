
namespace Monitoring_System.Model
{
    public class ModelAlarm
    {
        public string AlarmName { get; }
        public ushort AlarmPort { get; }
        public bool? IsAlarmOn {  get; set; }

        public ModelAlarm(string alarmName, ushort alarmPort)
        {
            AlarmName = alarmName;
            AlarmPort = alarmPort;
        }

        public static List<ModelAlarm> GetDefaultAlarmList() => new()
        {
            new ModelAlarm("AHU", 3123),
            new ModelAlarm("DPSHEPA", 3183),
            new ModelAlarm("ACCU", 3177),
            new ModelAlarm("HPLP", 3122)
        };

    }

}
