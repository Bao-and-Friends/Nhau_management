using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class PromoViewModel : ViewModelBase
{
    private readonly List<PromoItemModel> _allPromos = [];
    private string _searchText = string.Empty;

    public ObservableCollection<PromoItemModel> FilteredPromos { get; } = [];

    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilters(); }
    }

    public RelayCommand AddPromoCommand { get; }

    public PromoViewModel()
    {
        AddPromoCommand = new RelayCommand(() =>
        {
            _allPromos.Add(new PromoItemModel
            {
                MaVoucher = $"VC{_allPromos.Count + 1:D3}",
                TenChuongTrinh = "Chương trình ưu đãi mới",
                HinhThuc = "Giảm 5%",
                DieuKien = "Mọi hóa đơn",
                HanDung = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy"),
                TrangThai = "Đang áp dụng"
            });
            ApplyFilters();
        });

        LoadDemoPromos();
    }

    private void LoadDemoPromos()
    {
        _allPromos.Clear();
        _allPromos.AddRange([
            new() { MaVoucher = "KM10", TenChuongTrinh = "Giảm 10% tổng hóa đơn", HinhThuc = "Giảm 10%", DieuKien = "Hóa đơn từ 500.000 đ", HanDung = "31/12/2026", TrangThai = "Đang áp dụng" },
            new() { MaVoucher = "FREEKHOAI", TenChuongTrinh = "Tặng 1 đĩa Khoai tây chiên", HinhThuc = "Tặng món", DieuKien = "Bàn đi từ 4 khách", HanDung = "15/12/2026", TrangThai = "Đang áp dụng" },
            new() { MaVoucher = "TRUANHAU", TenChuongTrinh = "Giảm 50.000 đ giờ vàng trưa", HinhThuc = "Giảm tiền mặt", DieuKien = "Khung giờ 11:00 - 13:00", HanDung = "30/11/2026", TrangThai = "Đang áp dụng" },
            new() { MaVoucher = "SINHNHAT", TenChuongTrinh = "Ưu đãi tiệc sinh nhật", HinhThuc = "Giảm 15%", DieuKien = "CCCD trùng ngày sinh nhật", HanDung = "Không thời hạn", TrangThai = "Đang áp dụng" },
            new() { MaVoucher = "BEERFEST", TenChuongTrinh = "Uống 4 tặng 1 lon Tiger", HinhThuc = "Tặng đồ uống", DieuKien = "Gọi từ 4 lon bia", HanDung = "01/12/2026", TrangThai = "Đang áp dụng" }
        ]);
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        FilteredPromos.Clear();
        var q = _allPromos.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(SearchText))
            q = q.Where(x => x.TenChuongTrinh.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || x.MaVoucher.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        foreach (var item in q) FilteredPromos.Add(item);
    }
}
