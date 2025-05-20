using System.Collections.ObjectModel;
using Monitoring_System.Model;
using Modbus.IO;
using System.Net.Sockets;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Modbus.Device;
using System.IO.Ports;
using System.Windows.Input;

namespace Monitoring_System.ViewModel
{
    public class ViewModelLamp : INotifyPropertyChanged
    {
        public ObservableCollection<ModelLamp> LampList { get; private set; }
        private TcpClient? _tcpClient;
        private ModbusIpMaster? _modbusMaster;
        private readonly byte _slaveId = 1;
        public ICommand ToggleLampCommand { get; }
        public ViewModelLamp()
        {
            LampList = new ObservableCollection<ModelLamp>(ModelLamp.GetDefaultLampList());
            ConnectToModbus();
            ReadLampStates();
            LampList = new ObservableCollection<ModelLamp>(ModelLamp.GetDefaultLampList());
            ToggleLampCommand = new Command<ModelLamp>(async (lamp) => await ToggleLampAsync(lamp));
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
                Console.WriteLine($"--ConnectModbus Connection Failed: {ex.Message}");
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
                            Console.WriteLine("--ReadLamp connection failed");
                            return;
                        }

                    bool[] coilStatus = await _modbusMaster.ReadCoilsAsync(Lamp.LampPort, 1);
                    Lamp.IsLampOn = coilStatus[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed reading coil for {Lamp.LampName}: {ex.Message}");
                    }
                }
                await Task.Delay(500);
            }
        }

        public async Task ToggleLampAsync(ModelLamp lamp)
        {
            if(_modbusMaster == null)
            {
                Console.WriteLine("--ToggleLampAsync Modbus Not Connected");
                return;
            }
            try
            {
                if (lamp.IsLampOn == null)
                {
                    Console.WriteLine($"Lamp {lamp.LampName} in unknown state and cannot be toggled");
                    return;
                }
                bool newState = !(lamp.IsLampOn ?? false);
                await _modbusMaster.WriteSingleCoilAsync(lamp.LampPort, newState);
                lamp.IsLampOn = newState;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"--ToggleLamp Failed writing coil for {lamp.LampName}: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
