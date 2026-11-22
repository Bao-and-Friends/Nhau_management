using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class MenuViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly List<MenuItemModel> _allDishes = [];
    private string _selectedCategory = "Tất cả";
    private string _searchText = string.Empty;

    public ObservableCollection<MenuItemModel> FilteredDishes { get; } = [];

    public string SelectedCategory
    {
        get => _selectedCategory;
        set { if (SetProperty(ref _selectedCategory, value)) ApplyFilter(); }
    }

    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilter(); }
    }

    public RelayCommand FilterCommand { get; }
    public RelayCommand ToggleAvailabilityCommand { get; }

    public MenuViewModel(IApiService api)
    {
        _api = api;
        FilterCommand = new RelayCommand(p => { if (p is string cat) SelectedCategory = cat; });
        ToggleAvailabilityCommand = new RelayCommand(p =>
        {
            if (p is MenuItemModel item)
            {
                item.ConMon = !item.ConMon;
                OnPropertyChanged(nameof(FilteredDishes));
                ApplyFilter();
            }
        });

        LoadDemoMenu();
    }

    public void AddDish(MenuItemModel dish)
    {
        _allDishes.Insert(0, dish);
        ApplyFilter();
    }

    private void LoadDemoMenu()
    {
        _allDishes.Clear();
        _allDishes.AddRange([
            new() { MaMon = "M001", TenMon = "Lẩu Thái Hải Sản Thập Cẩm", DanhMuc = "Lẩu & Nướng", DonGia = 350000, DonViTinh = "Nồi", ConMon = true, Icon = "🍲" },
            new() { MaMon = "M002", TenMon = "Lẩu Bò Nhúng Giấm", DanhMuc = "Lẩu & Nướng", DonGia = 320000, DonViTinh = "Nồi", ConMon = true, Icon = "🍲" },
            new() { MaMon = "M003", TenMon = "Bò Nướng Tảng Sốt Tiêu Xanh", DanhMuc = "Món chính", DonGia = 189000, DonViTinh = "Đĩa", ConMon = true, Icon = "🥩" },
            new() { MaMon = "M004", TenMon = "Sườn Heo Nướng BBQ Mật Ong", DanhMuc = "Món chính", DonGia = 175000, DonViTinh = "Đĩa", ConMon = true, Icon = "🍖" },
            new() { MaMon = "M005", TenMon = "Gà Hấp Lá Chanh Nửa Con", DanhMuc = "Món chính", DonGia = 160000, DonViTinh = "Đĩa", ConMon = true, Icon = "🍗" },
            new() { MaMon = "M006", TenMon = "Mực Chiên Bơ Tỏi Giòn Rụm", DanhMuc = "Hải sản", DonGia = 145000, DonViTinh = "Đĩa", ConMon = true, Icon = "🦑" },
            new() { MaMon = "M007", TenMon = "Tôm Sú Hấp Bia Nước Dừa", DanhMuc = "Hải sản", DonGia = 195000, DonViTinh = "Đĩa", ConMon = true, Icon = "🦐" },
            new() { MaMon = "M008", TenMon = "Bạch Tuộc Sa Tế Nướng Cay", DanhMuc = "Hải sản", DonGia = 150000, DonViTinh = "Đĩa", ConMon = false, Icon = "🐙" },
            new() { MaMon = "M009", TenMon = "Gỏi Ngó Sen Tôm Thịt", DanhMuc = "Khai vị", DonGia = 89000, DonViTinh = "Đĩa", ConMon = true, Icon = "🥗" },
            new() { MaMon = "M010", TenMon = "Khoai Tây Chiên Lắc Phô Mai", DanhMuc = "Khai vị", DonGia = 55000, DonViTinh = "Đĩa", ConMon = true, Icon = "🍟" },
            new() { MaMon = "M011", TenMon = "Bia Tiger Crystal (Lon)", DanhMuc = "Đồ uống", DonGia = 28000, DonViTinh = "Lon", ConMon = true, Icon = "🍺" },
            new() { MaMon = "M012", TenMon = "Bia Heineken Silver (Lon)", DanhMuc = "Đồ uống", DonGia = 32000, DonViTinh = "Lon", ConMon = true, Icon = "🍺" },
            new() { MaMon = "M013", TenMon = "Nước Ngọt Coca / 7Up", DanhMuc = "Đồ uống", DonGia = 18000, DonViTinh = "Lon", ConMon = true, Icon = "🥤" },
            new() { MaMon = "M014", TenMon = "Nước Suối Lavie", DanhMuc = "Đồ uống", DonGia = 12000, DonViTinh = "Chai", ConMon = true, Icon = "💧" }
        ]);
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        FilteredDishes.Clear();
        var q = _allDishes.AsEnumerable();
        if (SelectedCategory != "Tất cả") q = q.Where(x => x.DanhMuc.Equals(SelectedCategory, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(SearchText)) q = q.Where(x => x.TenMon.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || x.MaMon.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        foreach (var item in q) FilteredDishes.Add(item);
    }
}
