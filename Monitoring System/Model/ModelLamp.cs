
using System.Security.Cryptography.X509Certificates;

namespace Monitoring_System.Model
{
    public class ModelLamp
    {
        public string LampName { get;}
        public ushort LampPort { get;}
        public bool?  IsLampOn { get; set; }

        public ModelLamp(string lampName, ushort lampPort)
        {
            LampName = lampName;
            LampPort = lampPort;

        }

        public static List<ModelLamp> GetDefaultLampList() => new()
        {
                new ModelLamp("LS1", 3075),
                new ModelLamp("LS2", 3076),
                new ModelLamp("OT1", 3077),
                new ModelLamp("OT2", 3078),
                new ModelLamp("View", 3079),
                new ModelLamp("Sign", 3080)
        };
    }
}
