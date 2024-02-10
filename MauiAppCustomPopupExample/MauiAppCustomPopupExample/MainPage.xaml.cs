using CustomControls.MAUI.MessageBox.AppPresentations.CommonSource;

namespace MauiAppCustomPopupExample
{
    public partial class MainPage : ContentPage
    {
        int count = 0; MainPageViewModel mainPageViewModel = null;
        public MainPage()
        {
            InitializeComponent();
            mainPageViewModel = MauiServiceHandler.Current.GetServices<MainPageViewModel>().FirstOrDefault();
            this.BindingContext = mainPageViewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
