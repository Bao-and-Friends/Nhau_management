using System.Windows.Controls;

namespace RestaurantClient.UI.Inventory
{
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            dgInventory.ItemsSource = new List<object>
            {
                new { Id = "KHO01", Name = "Thịt Bò Fuji Úc", Unit = "Kg", Quantity = "4.5", MinThreshold = "10.0", Status = "⚠️ Sắp Hết" },
                new { Id = "KHO02", Name = "Cá Hồi Nauy Tươi", Unit = "Kg", Quantity = "15.0", MinThreshold = "5.0", Status = "Đầy Đủ" },
                new { Id = "KHO03", Name = "Bia Heineken Lon", Unit = "Thùng", Quantity = "25", MinThreshold = "8", Status = "Đầy Đủ" },
                new { Id = "KHO04", Name = "Gạo Thơm ST25", Unit = "Bao (25kg)", Quantity = "6", MinThreshold = "2", Status = "Đầy Đủ" }
            };
        }
    }
}
