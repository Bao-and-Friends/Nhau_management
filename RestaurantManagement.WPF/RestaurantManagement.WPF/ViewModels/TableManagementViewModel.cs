using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagement.WPF.Models;
using RestaurantShared.DAO;
using RestaurantShared.DTO;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class TableManagementViewModel : BaseViewModel
    {
        // Danh sách gốc tất cả các bàn
        private readonly List<TableDisplayModel> _allTables = new();

        // Danh sách hiển thị lên giao diện (đã qua lọc)
        [ObservableProperty]
        private ObservableCollection<TableDisplayModel> _filteredTables = new();

        // Bàn hiện đang được chọn
        [ObservableProperty]
        private TableDisplayModel? _selectedTable;

        // Bộ đếm số lượng bàn
        [ObservableProperty]
        private int _totalCount;
        [ObservableProperty]
        private int _availableCount;
        [ObservableProperty]
        private int _occupiedCount;
        [ObservableProperty]
        private int _reservedCount;
        [ObservableProperty]
        private int _billReadyCount;

        // Bộ lọc hiện tại (Tất cả, Trống, Có khách...)
        [ObservableProperty]
        private string _currentFilter = "Tất cả";

        public TableManagementViewModel()
        {
            LoadTables();
        }

        // Tải dữ liệu bàn từ CSDL (kèm dữ liệu mẫu thông minh nếu chưa kết nối DB)
        public void LoadTables()
        {
            _allTables.Clear();

            try
            {
                // Thử lấy danh sách bàn từ DAO sẵn có trong RestaurantShared
                var dbTables = TableDAO.Instance.GetListTable();
                if (dbTables != null && dbTables.Count > 0)
                {
                    foreach (var t in dbTables)
                    {
                        // Chuẩn hóa trạng thái từ CSDL
                        string normStatus = TableDisplayModel.NormalizeStatus(t.TrangThai);

                        _allTables.Add(new TableDisplayModel
                        {
                            MaBan = t.MaBan,
                            TenBan = t.TenBan,
                            SucChua = t.SucChua,
                            TrangThai = normStatus,
                            KhuVuc = "Tầng 1",
                            ThoiGianVao = normStatus == "Có Khách" ? "Đang phục vụ" : (normStatus == "Đã Đặt" ? "Hẹn trước" : "")
                        });
                    }
                }
            }
            catch
            {
                // Nếu DB chưa bật, tự động nạp Mock Data để test UI mượt mà
            }

            // Nếu DB rỗng hoặc chưa nạp, tạo 12 bàn mẫu sinh động
            if (_allTables.Count == 0)
            {
                _allTables.AddRange(new List<TableDisplayModel>
                {
                    new() { MaBan = "B01", TenBan = "Bàn 01", SucChua = 4, TrangThai = "Có khách", ThoiGianVao = "11:20 (40p)", TamTinh = 485000 },
                    new() { MaBan = "B02", TenBan = "Bàn 02", SucChua = 2, TrangThai = "Trống" },
                    new() { MaBan = "B03", TenBan = "Bàn 03", SucChua = 6, TrangThai = "Có khách", ThoiGianVao = "10:45 (75p)", TamTinh = 1250000 },
                    new() { MaBan = "B04", TenBan = "Bàn 04", SucChua = 4, TrangThai = "Đã đặt", ThoiGianVao = "Hẹn 12:30" },
                    new() { MaBan = "B05", TenBan = "Bàn 05", SucChua = 8, TrangThai = "Trống" },
                    new() { MaBan = "B06", TenBan = "Bàn 06", SucChua = 4, TrangThai = "Cần thanh toán", ThoiGianVao = "11:00 (60p)", TamTinh = 820000 },
                    new() { MaBan = "B07", TenBan = "Bàn 07", SucChua = 2, TrangThai = "Trống" },
                    new() { MaBan = "B08", TenBan = "Bàn 08", SucChua = 4, TrangThai = "Có khách", ThoiGianVao = "11:35 (25p)", TamTinh = 320000 },
                    new() { MaBan = "B09", TenBan = "Bàn 09", SucChua = 10, TrangThai = "Trống" },
                    new() { MaBan = "B10", TenBan = "Bàn 10", SucChua = 4, TrangThai = "Trống" },
                    new() { MaBan = "B11", TenBan = "Bàn 11", SucChua = 6, TrangThai = "Có khách", ThoiGianVao = "11:10 (50p)", TamTinh = 960000 },
                    new() { MaBan = "B12", TenBan = "Bàn 12", SucChua = 4, TrangThai = "Trống" },
                });
            }

            UpdateCounts();
            ApplyFilter("Tất cả");

            // Chọn mặc định bàn đầu tiên
            SelectedTable = FilteredTables.FirstOrDefault();
        }

        private void UpdateCounts()
        {
            TotalCount = _allTables.Count;
            AvailableCount = _allTables.Count(t => TableDisplayModel.NormalizeStatus(t.TrangThai) == "Trống");
            OccupiedCount = _allTables.Count(t => TableDisplayModel.NormalizeStatus(t.TrangThai) == "Có Khách");
            ReservedCount = _allTables.Count(t => TableDisplayModel.NormalizeStatus(t.TrangThai) == "Đã Đặt");
            BillReadyCount = _allTables.Count(t => TableDisplayModel.NormalizeStatus(t.TrangThai) == "Chờ Dọn");
        }

        [RelayCommand]
        private void ApplyFilter(string status)
        {
            CurrentFilter = status;
            if (status == "Tất cả")
            {
                FilteredTables = new ObservableCollection<TableDisplayModel>(_allTables);
            }
            else
            {
                FilteredTables = new ObservableCollection<TableDisplayModel>(
                    _allTables.Where(t => TableDisplayModel.NormalizeStatus(t.TrangThai) == TableDisplayModel.NormalizeStatus(status))
                );
            }
        }

        [RelayCommand]
        private void SelectTable(TableDisplayModel table)
        {
            SelectedTable = table;
        }

        // Đổi trạng thái bàn thành bàn Trống (Dọn bàn)
        [RelayCommand]
        private void ClearTable()
        {
            if (SelectedTable == null) return;
            SelectedTable.TrangThai = "Trống";
            SelectedTable.TamTinh = 0;
            SelectedTable.ThoiGianVao = string.Empty;
            UpdateCounts();
            ApplyFilter(CurrentFilter);
        }
    }
}