using CustomControls.MAUI.MessageBox;
using CustomControls.MAUI.MessageBox.AppPresentations.CustomMessageBox;
using System.Windows.Input;

namespace MauiAppCustomPopupExample
{
    public class MainPageViewModel
    {
        public ICommand AlertCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SelfCommand { get; set; }
        IModalMessageBoxServiceHandler modalMessageBoxServiceHandler = null;
        public MainPageViewModel(IModalMessageBoxServiceHandler modalMessageBoxServiceHandler)
        {
            this.modalMessageBoxServiceHandler = modalMessageBoxServiceHandler;
            AlertCommand = new Command(() => AlertPopupCommand());
            ConfirmCommand = new Command(() => ConfirmPopupCommand());
            SelfCommand = new Command(() => SelfPopupCommand());
        }
        private void AlertPopupCommand()
        {

            //Message box method without using an instance.
            CustomAlertMessageBox customAlertMessageBoxWithoutInstance = ModalMessageBoxHandler.GetCustomMessageBox(messageTitle: "Demo", messageText: "Sample Information messageBox", messageBoxButtonText: "Ok");
            customAlertMessageBoxWithoutInstance.ButtonEventHandler += (sender, obj) =>
            {

            };

            //Method for injecting dependencies using a service for the message box.
            CustomAlertMessageBox customAlertMessageBox = modalMessageBoxServiceHandler.GetCustomMessageBox(messageTitle: "Demo", messageText: "Sample Information messageBox", messageBoxButtonText: "Show");
            customAlertMessageBox.ButtonEventHandler += (sender, obj) =>
            {

            };


        }
        private void ConfirmPopupCommand()
        {

            //Message box method without using an instance.
            //CustomConfirmMessageBox customConfirmMessageBoxWithoutInstance = ModalMessageBoxHandler.GetConfirmationMessageBox(messageTitle: "Demo", messageText: "Test messagebox", affirmativeButtonText: "Ok", negativeButtonText: "Cancel");
            //customConfirmMessageBoxWithoutInstance.AffirmativeButtonEventHandler += (sender, obj) =>
            //{

            //};
            //customConfirmMessageBoxWithoutInstance.NegativeButtonEventHandler += (sender, obj) =>
            //{

            //};

            //Method for injecting dependencies using a service for the message box.
            CustomConfirmMessageBox customConfirmMessageBox = modalMessageBoxServiceHandler.GetConfirmationMessageBox(messageTitle: "Demo", messageText: "Do you want to continue?", affirmativeButtonText: "YES", negativeButtonText: "CANCEL");
            customConfirmMessageBox.AffirmativeButtonEventHandler += (sender, obj) =>
            {

            };
            customConfirmMessageBox.NegativeButtonEventHandler += (sender, obj) =>
            {

            };
        }
        private void SelfPopupCommand()
        {
            SelfModalMessageBox myCustomPopup = new SelfModalMessageBox();

            //Message box method without using an instance.

            //ModalMessageBoxHandler.ShowOwnCustomPopup(myCustomPopup);

            //Method for injecting dependencies using a service for the message box.
            modalMessageBoxServiceHandler.ShowCustomOwnPopup(myCustomPopup);
        }
    }
}
