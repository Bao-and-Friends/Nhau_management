INSERT INTO NHANVIEN
(
    MaNV,
    HoTen,
    NgaySinh,
    GioiTinh,
    SoDienThoai,
    DiaChi,
    VaiTro,
    TrangThai
)
VALUES
('NV01', N'Nguyễn Văn A', '2000-05-10', N'Nam', '0901234567', N'TP.HCM', N'Phục vụ', N'Đang làm'),
('NV02', N'Trần Thị B', '2001-08-20', N'Nữ', '0912345678', N'TP.HCM', N'Thu ngân', N'Đang làm');

INSERT INTO TAIKHOAN
(
    MaTaiKhoan,
    MaNV,
    TenDangNhap,
    MatKhau,
    TrangThai
)
VALUES
('TK01', 'NV01', 'nguyenvana', '123456', N'Hoạt động'),
('TK02', 'NV02', 'tranthib', '123456', N'Hoạt động');