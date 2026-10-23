using System.Windows;
using System.Windows.Input;
using RestaurantManagement.WPF.ViewModels;

namespace RestaurantManagement.WPF.Views
{
    public partial class ForgotPasswordDialog : Window
    {
        public ForgotPasswordDialog()
        {
            InitializeComponent();
            DataContext = new ForgotPasswordViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
