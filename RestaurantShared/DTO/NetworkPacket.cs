using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public enum NetworkAction
    {
        UNKNOW,
        LOGIN,
        LOGIN_RESPONSE,
        GET_TABLE_LIST,
        GET_TABLE_LIST_RESPONSE,
        REGISTER,  
        REGISTER_RESPONSE,
        FORGET_PASSWORD,
        FORGET_PASSWORD_RESPONSE,
        OTP_VERIFY,
        OTP_VERIFY_RESPONSE,
        OTP_RESEND,
        OTP_RESEND_RESPONSE,
        CHANGE_PASSWORD,
        CHANGE_PASSWORD_RESPONSE

    }
    public class NetworkPacket
    {
        // Loại hành động: "LOGIN", "GET_TABLES", "UPDATE_TABLE", "LOGOUT"
        public NetworkAction Action { get; set; }
        // Trạng thái xử lý: true nếu thành công, false nếu thất bại
        public bool IsSuccess { get; set; } = true;
        // Thông báo đi kèm (ví dụ: "Đăng nhập thành công" hoặc "Sai mật khẩu")
        public string Message { get; set; } = string.Empty;
        // Dữ liệu chi tiết dạng chuỗi JSON (ví dụ JSON của NhanVienDATA, List<TableDATA>)
        public string Payload { get; set; } = string.Empty;
        public DateTime Timestamp { get; } = DateTime.Now;
    }
}
