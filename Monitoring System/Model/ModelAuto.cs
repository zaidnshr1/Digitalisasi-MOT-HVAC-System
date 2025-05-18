
namespace Monitoring_System.Model
{
    public class ModelAuto
    {
        public string AutoName { get; }
        public ushort AutoPort { get; }
        public bool? IsAutoOn { get; set; }

        public ModelAuto(string autoName, ushort autoPort)
        {
            AutoName = autoName;
            AutoPort = autoPort;
        }
        public static List<ModelAuto> GetDefaultAutoList() => new()
        {
            new ModelAuto("Auto", 3072)
        };
    }
}
