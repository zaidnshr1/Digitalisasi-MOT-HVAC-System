using Monitoring_System.ViewModel;

namespace Monitoring_System.View;

public partial class UserInterface : ContentPage
{
	private ViewModelLamp viewModelLamp;
	public UserInterface()
	{
		InitializeComponent();
        viewModelLamp = new ViewModelLamp();
		BindingContext = viewModelLamp;
	}
}