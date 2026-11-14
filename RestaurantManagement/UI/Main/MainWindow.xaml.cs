using System.Windows;
using System.Windows.Threading;
using RestaurantClient.Services;
using RestaurantClient.UI.Account;
using RestaurantClient.UI.Authentication;
using RestaurantClient.UI.Cashier;
using RestaurantClient.UI.Chat;
using RestaurantClient.UI.Inventory;
using RestaurantClient.UI.Management;
using RestaurantClient.UI.Report;
using RestaurantClient.UI.Serving;
using RestaurantClient.UI.Table;

namespace RestaurantClient.UI.Main
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _clockTimer;

        public MainWindow()
        {
            InitializeComponent();

            // Khởi chạy đồng hồ thời gian thực
            _clockTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _clockTimer.Tick += (s, e) =>
            {
                lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            _clockTimer.Start();
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Cập nhật thông tin nhân viên đăng nhập nếu có
            if (ApiService.Staff != null)
            {
                lblStaffName.Text = ApiService.Staff.HoTen;
                lblStaffRole.Text = ApiService.Staff.VaiTro;
            }

            // Mặc định nạp màn hình Dashboard Quản lý đầu tiên
            mainContent.Content = new AdminDashboardView();
        }

        private void Nav_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new AdminDashboardView();
        }

        private void Nav_TableMap_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new TableMapView();
        }

        private void Nav_Serving_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new ServingView();
        }

        private void Nav_Cashier_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new CashierView();
        }

        private void Nav_Food_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new FoodManagementView();
        }

        private void Nav_Staff_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new StaffManagementView();
        }

        private void Nav_Revenue_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new RevenueReportView();
        }

        private void Nav_Inventory_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new InventoryView();
        }

        private void Nav_Profile_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new UserProfileView();
        }

        private void Nav_Chat_Click(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new InternalChatView();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác Nhận Đăng Xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ApiService.Logout();
                var loginView = new LoginView();
                loginView.LoginSuccess += (s, ev) =>
                {
                    mainContent.Content = new AdminDashboardView();
                };
                mainContent.Content = loginView;
            }
        }
    }
}
