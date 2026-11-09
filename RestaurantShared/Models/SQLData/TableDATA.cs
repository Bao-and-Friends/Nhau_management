using System;
using System.Data;
using System.Text.Json.Serialization;

namespace RestaurantShared.Models.SQLData
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TableStatus
    {
        TRONG,      // Bàn trống (Màu xám/bạc)
        CO_KHACH,   // Đang có khách ngồi nhậu (Màu xanh lá)
        DA_DAT,     // Khách đã gọi đặt trước (Màu vàng/cam)
        CHO_DON     // Khách vừa về, chờ dọn dẹp (Màu đỏ/hồng)
    }
    public class TableDATA
    {
        // Constructor rỗng: BẮT BUỘC để Dapper và JSON Deserializer hoạt động
        public TableDATA() { }
       
        // Khóa chính (Ví dụ: "B01", "VIP02")
        public string MaBan { get; set; } = string.Empty;
        // Tên hiển thị trên nút bấm (Ví dụ: "Bàn 1", "Phòng VIP 2")
        public string TenBan { get; set; } = string.Empty;
        // Sức chứa số người (Ví dụ: 4, 6, 10 người)
        public int SucChua { get; set; } = 4;
        // Trạng thái hiện tại của bàn
        public TableStatus TrangThai { get; set; } = TableStatus.TRONG;
        // (Khuyên thêm) Khu vực bàn: Tầng trệt, Lầu 1, Sân vườn, Phòng VIP
        // (Thuộc tính tiện ích - Không lưu trong SQL): Trả về tên tiếng Việt hiển thị
        [JsonIgnore] // Không gửi trường này ra JSON vì WinForms tự format được
        public string TenTrangThaiVN => TrangThai switch
        {
            TableStatus.CO_KHACH => "Có Khách",
            TableStatus.DA_DAT => "Đã Đặt",
            TableStatus.CHO_DON => "Chờ Dọn",
            _ => "Trống"
        };
    }
}