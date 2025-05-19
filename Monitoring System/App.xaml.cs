using Monitoring_System.View;

namespace Monitoring_System
{
    public partial class App : Application
    {
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new UserInterface());
        }
    }
}