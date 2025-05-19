using System.Collections.ObjectModel;
using Monitoring_System.Model;
using Modbus.IO;
using System.Net.Sockets;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Modbus.Device;
using System.IO.Ports;

namespace Monitoring_System.ViewModel
{
    public class ViewModelLamp : INotifyPropertyChanged
    {
        public ObservableCollection<ModelLamp> LampList { get; private set; }
        private TcpClient? _tcpClient;
        private ModbusIpMaster? _modbusMaster;

        public ViewModelLamp()
        {
            LampList = new ObservableCollection<ModelLamp>(ModelLamp.GetDefaultLampList());
            ConnectToModbus();
            ReadLampStates();
        }

        private void ConnectToModbus()
        {
            try
            {
                _tcpClient = new TcpClient("192.168.1.113", 502);
                _modbusMaster = ModbusIpMaster.CreateIp(_tcpClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Modbus Connection Failed: {ex.Message}");
            }
        }

        private async void ReadLampStates()
        {
            while (true)
            {
                foreach (var Lamp in LampList)
                {
                    try
                    {
                        if (_modbusMaster == null)
                        {
                            Console.WriteLine("Modbus connection failed");
                            return;
                        }

                    bool[] coilStatus = await _modbusMaster.ReadCoilsAsync(Lamp.LampPort, 1);
                    Lamp.IsLampOn = coilStatus[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to read coil for {Lamp.LampName}: {ex.Message}");
                    }
                }
                await Task.Delay(500);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
