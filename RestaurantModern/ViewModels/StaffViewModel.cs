using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;
using RestaurantShared.DTOs;

namespace RestaurantModern.ViewModels;

public class StaffViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly List<StaffItemModel> _allStaff = [];
    private string _selectedRole = "Tất cả";
    private string _searchText = string.Empty;
    private bool _showAddModal = false;
    private string _statusMessage = string.Empty;
    private bool _isStatusError;

    // Add Form Fields
    private string _newUsername = string.Empty;
    private string _newPassword = string.Empty;
    private string _newFullName = string.Empty;
    private string _newRole = "Phục vụ";
    private string _newGender = "Nam";
    private string _newPhone = string.Empty;
    private string _newEmail = string.Empty;
    private string _newAddress = "Hà Nội";

    public ObservableCollection<StaffItemModel> FilteredStaff { get; } = [];

    public bool IsManager => string.Equals(_api.CurrentStaff?.VaiTro?.Trim(), "Quản lý", StringComparison.OrdinalIgnoreCase);
    public bool ShowRoleWarning => !IsManager;
    public string CurrentStaffRole => _api.CurrentStaff?.VaiTro ?? "Nhân viên";
    public string CurrentStaffCode => _api.CurrentStaff?.MaNV ?? "NV01";

    public string SelectedRole
    {
        get => _selectedRole;
        set { if (SetProperty(ref _selectedRole, value)) ApplyFilter(); }
    }

    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilter(); }
    }

    public bool ShowAddModal
    {
        get => _showAddModal;
        set => SetProperty(ref _showAddModal, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            if (SetProperty(ref _statusMessage, value))
            {
                OnPropertyChanged(nameof(HasStatusMessage));
            }
        }
    }

    public bool HasStatusMessage => !string.IsNullOrWhiteSpace(StatusMessage);

    public bool IsStatusError
    {
        get => _isStatusError;
        set => SetProperty(ref _isStatusError, value);
    }

    public string NewUsername { get => _newUsername; set => SetProperty(ref _newUsername, value); }
    public string NewPassword { get => _newPassword; set => SetProperty(ref _newPassword, value); }
    public string NewFullName { get => _newFullName; set => SetProperty(ref _newFullName, value); }
    public string NewRole { get => _newRole; set => SetProperty(ref _newRole, value); }
    public string NewGender { get => _newGender; set => SetProperty(ref _newGender, value); }
    public string NewPhone { get => _newPhone; set => SetProperty(ref _newPhone, value); }
    public string NewEmail { get => _newEmail; set => SetProperty(ref _newEmail, value); }
    public string NewAddress { get => _newAddress; set => SetProperty(ref _newAddress, value); }

    public RelayCommand FilterCommand { get; }
    public RelayCommand OpenAddModalCommand { get; }
    public RelayCommand CloseAddModalCommand { get; }
    public AsyncRelayCommand SubmitAddStaffCommand { get; }

    public StaffViewModel(IApiService api)
    {
        _api = api;

        FilterCommand = new RelayCommand(p => { if (p is string r) SelectedRole = r; });
        OpenAddModalCommand = new RelayCommand(() =>
        {
            StatusMessage = string.Empty;
            IsStatusError = false;
            ShowAddModal = true;
        });
        CloseAddModalCommand = new RelayCommand(() => ShowAddModal = false);

        SubmitAddStaffCommand = new AsyncRelayCommand(async () =>
        {
            if (!IsManager)
            {
                IsStatusError = true;
                StatusMessage = $"Từ chối quyền: Bạn đang đăng nhập với vai trò '{CurrentStaffRole}'. Vui lòng đăng xuất và đăng nhập tài khoản Quản lý (ví dụ: QL01) để lưu nhân viên vào Database.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewFullName))
            {
                IsStatusError = true;
                StatusMessage = "Vui lòng nhập họ và tên nhân viên.";
                return;
            }

            if (string.IsNullOrWhiteSpace(NewUsername))
            {
                IsStatusError = true;
                StatusMessage = "Vui lòng nhập tên đăng nhập.";
                return;
            }

            var passwordToUse = string.IsNullOrWhiteSpace(NewPassword) ? "123456" : NewPassword;
            if (passwordToUse.Length < 6)
            {
                IsStatusError = true;
                StatusMessage = "Mật khẩu khởi tạo phải có tối thiểu 6 ký tự.";
                return;
            }

            var req = new RegisterAccountRequest(
                NewUsername.Trim(),
                passwordToUse.Trim(),
                NewFullName.Trim(),
                NewRole,
                NewGender,
                DateTimeOffset.Now.AddYears(-22),
                string.IsNullOrWhiteSpace(NewPhone) ? "0981112233" : NewPhone.Trim(),
                string.IsNullOrWhiteSpace(NewEmail) ? $"{NewUsername.ToLower()}@nhau.vn" : NewEmail.Trim(),
                string.IsNullOrWhiteSpace(NewAddress) ? "Hà Nội" : NewAddress.Trim()
            );

            // Calls POST /api/account/register to save into database NHANVIEN & TAIKHOAN
            var res = await _api.RegisterStaffAsync(req);
            if (res.IsSuccess)
            {
                _allStaff.Add(new StaffItemModel
                {
                    MaNV = $"NV{_allStaff.Count + 1:D3}",
                    HoTen = NewFullName.Trim(),
                    VaiTro = NewRole,
                    SoDienThoai = string.IsNullOrWhiteSpace(NewPhone) ? "0981112233" : NewPhone.Trim(),
                    Email = string.IsNullOrWhiteSpace(NewEmail) ? $"{NewUsername.ToLower()}@nhau.vn" : NewEmail.Trim(),
                    TrangThai = "Đang làm việc"
                });
                ApplyFilter();
                ShowAddModal = false;
                StatusMessage = "Đã lưu nhân viên và tạo tài khoản vào Database thành công!";
                IsStatusError = false;

                // Reset form
                NewFullName = string.Empty;
                NewUsername = string.Empty;
                NewPassword = string.Empty;
                NewPhone = string.Empty;
                NewEmail = string.Empty;
            }
            else
            {
                IsStatusError = true;
                StatusMessage = res.Message ?? "Lỗi khi lưu nhân viên vào cơ sở dữ liệu.";
            }
        });

        LoadDemoStaff();
    }

    private void LoadDemoStaff()
    {
        _allStaff.Clear();
        _allStaff.AddRange([
            new() { MaNV = "NV001", HoTen = "Trần Quốc Huy", VaiTro = "Quản lý", SoDienThoai = "0981234567", Email = "huytq@nhau.vn", TrangThai = "Đang làm việc" },
            new() { MaNV = "NV002", HoTen = "Nguyễn Thu Hà", VaiTro = "Thu ngân", SoDienThoai = "0972345678", Email = "hant@nhau.vn", TrangThai = "Đang làm việc" },
            new() { MaNV = "NV003", HoTen = "Lê Hoàng Long", VaiTro = "Phục vụ", SoDienThoai = "0963456789", Email = "longlh@nhau.vn", TrangThai = "Đang làm việc" },
            new() { MaNV = "NV004", HoTen = "Phạm Đình Bảo", VaiTro = "Bếp trưởng", SoDienThoai = "0914567890", Email = "baopd@nhau.vn", TrangThai = "Đang làm việc" },
            new() { MaNV = "NV005", HoTen = "Đỗ Quỳnh Mai", VaiTro = "Phục vụ", SoDienThoai = "0905678901", Email = "maidq@nhau.vn", TrangThai = "Nghỉ phép" }
        ]);
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        FilteredStaff.Clear();
        var q = _allStaff.AsEnumerable();
        if (SelectedRole != "Tất cả") q = q.Where(x => x.VaiTro.Equals(SelectedRole, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(SearchText)) q = q.Where(x => x.HoTen.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || x.MaNV.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        foreach (var item in q) FilteredStaff.Add(item);
    }
}
