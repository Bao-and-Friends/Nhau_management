using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action _onLogout;

    private ViewModelBase _currentViewModel;
    private NavigationItem? _selectedNavItem;
    private string _activePageTitle = "Tổng quan hoạt động";
    private string _activePageSubtitle = "Tình hình nhà hàng theo vai trò hiện tại.";

    public ObservableCollection<NavigationItem> NavItems { get; } = [];

    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public NavigationItem? SelectedNavItem
    {
        get => _selectedNavItem;
        set
        {
            if (SetProperty(ref _selectedNavItem, value) && value != null)
            {
                Navigate(value.Tag, null);
            }
        }
    }

    public string ActivePageTitle
    {
        get => _activePageTitle;
        set => SetProperty(ref _activePageTitle, value);
    }

    public string ActivePageSubtitle
    {
        get => _activePageSubtitle;
        set => SetProperty(ref _activePageSubtitle, value);
    }

    public string CurrentStaffName => _api.CurrentStaff?.HoTen ?? "Trần Quốc Huy";
    public string CurrentStaffRole => _api.CurrentStaff?.VaiTro ?? "Quản lý";
    public string CurrentStaffCode => _api.CurrentStaff?.MaNV ?? "NV001";
    public bool IsManager => CurrentStaffRole.Equals("Quản lý", StringComparison.OrdinalIgnoreCase);

    public RelayCommand LogoutCommand { get; }
    public RelayCommand NavigateCommand { get; }

    public MainViewModel(IApiService api, Action onLogout)
    {
        _api = api;
        _onLogout = onLogout;

        LogoutCommand = new RelayCommand(() =>
        {
            _api.Logout();
            _onLogout();
        });

        NavigateCommand = new RelayCommand(p =>
        {
            if (p is string tag) Navigate(tag, null);
        });

        InitNavigation();

        // Default to Overview
        _currentViewModel = new OverviewViewModel(_api, Navigate);
        _selectedNavItem = NavItems.FirstOrDefault(x => x.Tag == "home");
    }

    private void InitNavigation()
    {
        // Khớp chính xác 13 mục trong Figma (Node 6:3)
        NavItems.Clear();
        NavItems.Add(new NavigationItem { Tag = "home", Title = "Tổng quan", Icon = "🏠", Subtitle = "Tình hình nhà hàng tổng quan" });
        NavItems.Add(new NavigationItem { Tag = "tables", Title = "Quản lý bàn", Icon = "🪑", Subtitle = "Theo dõi trạng thái bàn theo thời gian thực" });
        NavItems.Add(new NavigationItem { Tag = "payment", Title = "Thanh toán", Icon = "💳", Subtitle = "Thanh toán hóa đơn bàn đang dùng" });
        NavItems.Add(new NavigationItem { Tag = "invoices", Title = "Hóa đơn", Icon = "📄", Subtitle = "Lịch sử hóa đơn và chứng từ thanh toán" });
        NavItems.Add(new NavigationItem { Tag = "menu", Title = "Thực đơn", Icon = "🍲", Subtitle = "Danh sách món ăn và giá bán" });
        NavItems.Add(new NavigationItem { Tag = "stock", Title = "Quản lý kho", Icon = "📦", Subtitle = "Tồn kho nguyên vật liệu và cảnh báo" });
        NavItems.Add(new NavigationItem { Tag = "staff", Title = "Nhân viên", Icon = "👥", Subtitle = "Danh sách nhân sự và tài khoản" });
        NavItems.Add(new NavigationItem { Tag = "shifts", Title = "Ca làm việc", Icon = "⏱", Subtitle = "Phân chia ca trực nhân viên" });
        NavItems.Add(new NavigationItem { Tag = "promo", Title = "Khuyến mãi", Icon = "🎁", Subtitle = "Chương trình ưu đãi và giảm giá" });
        NavItems.Add(new NavigationItem { Tag = "reports", Title = "Thống kê", Icon = "📊", Subtitle = "Báo cáo doanh thu & hóa đơn" });
        NavItems.Add(new NavigationItem { Tag = "chat", Title = "Chat nội bộ", Icon = "💬", Subtitle = "Trao đổi giữa phục vụ và bếp" });
        NavItems.Add(new NavigationItem { Tag = "logs", Title = "Nhật ký", Icon = "📋", Subtitle = "Lịch sử hoạt động hệ thống" });
        NavItems.Add(new NavigationItem { Tag = "profile", Title = "Hồ sơ", Icon = "👤", Subtitle = "Thông tin cá nhân & đổi mật khẩu" });
    }

    public void Navigate(string tag, object? parameter)
    {
        switch (tag.ToLower())
        {
            case "home":
                ActivePageTitle = "Tổng quan hoạt động";
                ActivePageSubtitle = "Tình hình nhà hàng theo vai trò hiện tại.";
                CurrentViewModel = new OverviewViewModel(_api, Navigate);
                break;
            case "tables":
                ActivePageTitle = "Quản lý bàn";
                ActivePageSubtitle = "Theo dõi trạng thái bàn theo thời gian thực.";
                CurrentViewModel = new TableManagementViewModel(_api, Navigate);
                break;
            case "table-detail":
                if (parameter is TableItem table)
                {
                    ActivePageTitle = $"Chi tiết bàn • {table.TenBan}";
                    ActivePageSubtitle = "Các thao tác được gắn với phiên phục vụ hiện tại.";
                    CurrentViewModel = new TableDetailViewModel(table, _api, Navigate);
                }
                break;
            case "payment":
                ActivePageTitle = "Thanh toán";
                ActivePageSubtitle = "Xử lý thanh toán tiền mặt & chuyển khoản VietQR.";
                CurrentViewModel = new PaymentViewModel(_api, Navigate, parameter as TableItem);
                break;
            case "invoices":
                ActivePageTitle = "Quản lý hóa đơn";
                ActivePageSubtitle = "Lịch sử hóa đơn, chứng từ thanh toán và xuất hóa đơn.";
                CurrentViewModel = new InvoiceViewModel(_api, Navigate);
                break;
            case "menu":
                ActivePageTitle = "Quản lý thực đơn";
                ActivePageSubtitle = "Danh mục các món ăn, đồ uống và tình trạng phục vụ.";
                CurrentViewModel = new MenuViewModel(_api);
                break;
            case "stock":
                ActivePageTitle = "Quản lý kho";
                ActivePageSubtitle = "Theo dõi tồn kho thực phẩm, nước giải khát và cảnh báo định mức.";
                CurrentViewModel = new StockViewModel();
                break;
            case "staff":
                ActivePageTitle = "Nhân viên";
                ActivePageSubtitle = "Quản lý danh sách nhân sự, phân quyền và cấp tài khoản.";
                CurrentViewModel = new StaffViewModel(_api);
                break;
            case "shifts":
                ActivePageTitle = "Ca làm việc";
                ActivePageSubtitle = "Phân công ca trực cho nhân viên các bộ phận.";
                CurrentViewModel = new ShiftsViewModel();
                break;
            case "promo":
                ActivePageTitle = "Chương trình khuyến mãi";
                ActivePageSubtitle = "Theo dõi chương trình ưu đãi, mã giảm giá và áp dụng cho khách.";
                CurrentViewModel = new PromoViewModel();
                break;
            case "reports":
                ActivePageTitle = "Thống kê doanh thu";
                ActivePageSubtitle = "Báo cáo doanh thu, sản lượng bán hàng và hiệu suất ca trực.";
                CurrentViewModel = new RevenueStatsViewModel();
                break;
            case "chat":
                ActivePageTitle = "Chat nội bộ nhà hàng";
                ActivePageSubtitle = "Trao đổi công việc giữa phục vụ, thu ngân, quản lý và bếp.";
                CurrentViewModel = new ChatViewModel(_api);
                break;
            case "logs":
                ActivePageTitle = "Nhật ký hoạt động";
                ActivePageSubtitle = "Lịch sử thao tác người dùng và kiểm toán hệ thống.";
                CurrentViewModel = new LogsViewModel();
                break;
            case "profile":
                ActivePageTitle = "Hồ sơ";
                ActivePageSubtitle = "Thông tin tài khoản nhân viên và đổi mật khẩu bảo mật.";
                CurrentViewModel = new ProfileViewModel(_api);
                break;
        }

        var navMatch = NavItems.FirstOrDefault(x => x.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
        if (navMatch != null && _selectedNavItem != navMatch)
        {
            _selectedNavItem = navMatch;
            OnPropertyChanged(nameof(SelectedNavItem));
        }
    }
}
