using System.Windows.Controls;

namespace RestaurantClient.UI.Management
{
    public partial class FoodManagementView : UserControl
    {
        public FoodManagementView()
        {
            InitializeComponent();
            dgFoods.ItemsSource = new List<object>
            {
                new { Id = "M01", Name = "Bò Fuji Nướng Đá", Category = "Món Chính", Unit = "Phần", Price = 285000, Status = "Đang Phục Vụ" },
                new { Id = "M02", Name = "Sashimi Cá Hồi Tươi", Category = "Món Khai Vị", Unit = "Dĩa", Price = 195000, Status = "Đang Phục Vụ" },
                new { Id = "M03", Name = "Lẩu Thái Hải Sản Tomyum", Category = "Món Lẩu", Unit = "Nồi", Price = 345000, Status = "Đang Phục Vụ" },
                new { Id = "M04", Name = "Bia Craft Pasteur Street", Category = "Đồ Uống", Unit = "Ly", Price = 85000, Status = "Đang Phục Vụ" },
                new { Id = "M05", Name = "Cua Huỳnh Đế Hấp Gừng", Category = "Hải Sản", Unit = "Kg", Price = 1200000, Status = "Tạm Hết Món" }
            };
        }
    }
}
