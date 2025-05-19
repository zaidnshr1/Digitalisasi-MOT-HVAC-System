
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monitoring_System.Model
{
    public class ModelLamp : INotifyPropertyChanged
    {
        public string LampName { get; }
        public ushort LampPort { get; }
        private bool? _isLampOn;
        public bool? IsLampOn
        { get => _isLampOn;
            set
            {
                if (_isLampOn != value)
                {
                    _isLampOn = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
