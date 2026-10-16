INSERT INTO VAITRO
VALUES
('VT01', N'Quản lý'),
('VT02', N'Phục vụ'),
('VT03', N'Thu ngân');

INSERT INTO NHANVIEN
VALUES
('NV01', N'Nguyễn Văn A', '2000-05-10', N'Nam', '0901234567', N'TP.HCM', 'VT02', N'Đang làm'),
('NV02', N'Trần Thị B', '2001-08-20', N'Nữ', '0912345678', N'TP.HCM', 'VT03', N'Đang làm');

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
