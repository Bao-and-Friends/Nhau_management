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
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

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
    public RelayCommand RefreshCommand { get; }
    public RelayCommand ToggleAvailabilityCommand { get; }

    public MenuViewModel(IApiService api)
    {
        _api = api;
        FilterCommand = new RelayCommand(p => { if (p is string cat) SelectedCategory = cat; });
        RefreshCommand = new RelayCommand(async () => await LoadMenuAsync());
        ToggleAvailabilityCommand = new RelayCommand(p =>
        {
            if (p is MenuItemModel item)
            {
                item.ConMon = !item.ConMon;
                OnPropertyChanged(nameof(FilteredDishes));
                ApplyFilter();
            }
        });

        _ = LoadMenuAsync();
    }

    public void AddDish(MenuItemModel dish)
    {
        _allDishes.Insert(0, dish);
        ApplyFilter();
    }

    public async Task LoadMenuAsync()
    {
        IsLoading = true;
        try
        {
            var dishes = await _api.GetDishesAsync();
            _allDishes.Clear();
            foreach (var d in dishes)
            {
                _allDishes.Add(new MenuItemModel
                {
                    MaMon = d.MaMon,
                    TenMon = d.TenMon,
                    DanhMuc = string.IsNullOrWhiteSpace(d.TenDanhMuc) ? "Món chính" : d.TenDanhMuc,
                    DonGia = d.DonGia,
                    DonViTinh = string.IsNullOrWhiteSpace(d.DonViTinh) ? "Đĩa" : d.DonViTinh,
                    ConMon = !string.Equals(d.TrangThai, "Hết món", StringComparison.OrdinalIgnoreCase) && d.TrangThai != "0",
                    Icon = ResolveCategoryIcon(d.TenDanhMuc)
                });
            }
            ApplyFilter();
        }
        finally
        {
            IsLoading = false;
        }
    }

    private static string ResolveCategoryIcon(string? category)
    {
        if (string.IsNullOrWhiteSpace(category)) return "🍽";
        var cat = category.ToLower();
        if (cat.Contains("lẩu") || cat.Contains("nướng")) return "🍲";
        if (cat.Contains("hải sản") || cat.Contains("tôm") || cat.Contains("cá") || cat.Contains("mực")) return "🦐";
        if (cat.Contains("khai vị") || cat.Contains("gỏi") || cat.Contains("rau")) return "🥗";
        if (cat.Contains("uống") || cat.Contains("bia") || cat.Contains("nước")) return "🍺";
        if (cat.Contains("bò") || cat.Contains("thịt") || cat.Contains("heo") || cat.Contains("gà")) return "🥩";
        return "🍽";
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
