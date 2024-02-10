using CommunityToolkit.Maui.Views;
using CustomControls.MAUI.MessageBox.AppPresentations.CommonSource;

namespace MauiAppCustomPopupExample;

public partial class SelfModalMessageBox : Popup
{
	public SelfModalMessageBox()
	{
		InitializeComponent();
        BindingContext = MauiServiceHandler.Current.GetServices<SelfModalMessageBoxViewModel>().FirstOrDefault();
    }
}