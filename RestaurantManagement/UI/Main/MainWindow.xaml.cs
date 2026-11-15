using System;
using System.Windows;
using System.Windows.Controls;
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
            UpdateUserProfileHeader();

            // Mặc định nạp màn hình Dashboard Quản lý đầu tiên (Figma MainWindow)
            LoadDashboardView();
        }

        private void UpdateUserProfileHeader()
        {
            if (ApiService.Staff != null && !string.IsNullOrWhiteSpace(ApiService.Staff.HoTen))
            {
                string role = string.IsNullOrWhiteSpace(ApiService.Staff.VaiTro) ? "Nhân viên" : ApiService.Staff.VaiTro;
                lblStaffProfile.Text = $"👤  {ApiService.Staff.HoTen} ({role})";
            }
            else
            {
                lblStaffProfile.Text = "👤  Quốc Huy (Quản lý)";
            }
        }

        private void SetActiveNavButton(Button activeButton)
        {
            foreach (var child in sidebarPanel.Children)
            {
                if (child is Button btn)
                {
                    btn.Tag = (btn == activeButton) ? "Active" : "";
                }
            }
        }

        private void LoadDashboardView()
        {
            SetActiveNavButton(btnNavDashboard);
            var dashboard = new AdminDashboardView();
            dashboard.NavigateRequested += OnDashboardNavigateRequested;
            mainContent.Content = dashboard;
        }

        private void OnDashboardNavigateRequested(object? sender, string target)
        {
            switch (target)
            {
                case "Staff":
                    Nav_Staff_Click(btnNavStaff, new RoutedEventArgs());
                    break;
                case "Food":
                    Nav_Food_Click(btnNavFood, new RoutedEventArgs());
                    break;
                case "Inventory":
                    Nav_Inventory_Click(btnNavInventory, new RoutedEventArgs());
                    break;
                case "Revenue":
                    Nav_Revenue_Click(btnNavRevenue, new RoutedEventArgs());
                    break;
            }
        }

        private void Nav_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            LoadDashboardView();
        }

        private void Nav_TableMap_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavTableMap);
            mainContent.Content = new TableMapView();
        }

        private void Nav_Serving_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavServing);
            mainContent.Content = new ServingView();
        }

        private void Nav_Cashier_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavCashier);
            mainContent.Content = new CashierView();
        }

        private void Nav_Food_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavFood);
            mainContent.Content = new FoodManagementView();
        }

        private void Nav_Staff_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavStaff);
            mainContent.Content = new StaffManagementView();
        }

        private void Nav_Revenue_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavRevenue);
            mainContent.Content = new RevenueReportView();
        }

        private void Nav_Inventory_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavInventory);
            mainContent.Content = new InventoryView();
        }

        private void Nav_Chat_Click(object sender, RoutedEventArgs e)
        {
            SetActiveNavButton(btnNavChat);
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
                    UpdateUserProfileHeader();
                    LoadDashboardView();
                };
                mainContent.Content = loginView;
            }
        }
    }
}