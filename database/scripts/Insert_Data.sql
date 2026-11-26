-- 1. Thêm nhân viên mẫu
INSERT INTO NHANVIEN (MaNV, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi, VaiTro)
VALUES 
('NV001', N'Trần Quốc Huy', '1995-03-15', N'Nam', '0981234567', N'Hà Nội', N'Quản lý'),
('NV002', N'Nguyễn Thu Hà', '1998-07-20', N'Nữ', '0972345678', N'Hà Nội', N'Thu ngân'),
('NV003', N'Lê Hoàng Long', '2001-11-05', N'Nam', '0963456789', N'Hà Nội', N'Phục vụ');

-- 2. Thêm tài khoản mẫu (Mật khẩu '123456' băm bằng BCrypt chuẩn)
INSERT INTO TAIKHOAN (NhanVienID, TenDangNhap, MatKhau, Email, TrangThai)
VALUES 
(1, 'admin', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'admin@nhau.vn', N'Hoạt động'),
(2, 'thungan', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'thungan@nhau.vn', N'Hoạt động'),
(3, 'phucvu', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'phucvu@nhau.vn', N'Hoạt động');

-- 3. Thêm ca làm việc
INSERT INTO CA_LAMVIEC (TenCa, GioBatDau, GioKetThuc)
VALUES 
(N'Ca Sáng', '08:00:00', '16:00:00'),
(N'Ca Tối', '16:00:00', '23:30:00');

-- 4. Thêm bàn
INSERT INTO BAN (MaBan, TenBan, SucChua, TrangThai)
VALUES 
('B01', N'Bàn 01', 4, N'Có Khách'),
('B02', N'Bàn 02', 4, N'Trống'),
('B03', N'Bàn 03', 6, N'Trống'),
('B04', N'Bàn 04', 8, N'Trống'),
('VIP01', N'Phòng VIP 1', 12, N'Trống');

-- 5. Thêm danh mục món
INSERT INTO DANHMUCMON (TenDanhMuc)
VALUES 
(N'Món Khai Vị'),
(N'Món Nướng - Chiên'),
(N'Lẩu & Nước Dùng'),
(N'Đồ Uống');

-- 6. Thêm món ăn
INSERT INTO MONAN (MaMon, TenMon, DonGia, DonViTinh, MoTa, DanhMucID, TrangThai)
VALUES 
('M001', N'Đậu Phộng Rang Tỏi Ớt', 35000, N'Dĩa', N'Đậu phộng rang thơm cay giòn', 1, N'Đang bán'),
('M002', N'Chả Ram Tôm Đất', 79000, N'Phần', N'Chả ram giòn rụm cuốn rau sống', 1, N'Đang bán'),
('M003', N'Bò Nướng Sa Tế', 149000, N'Phần', N'Bò ướp sa tế nướng than hoa', 2, N'Đang bán'),
('M004', N'Sụn Gà Chiên Nước Mắm', 119000, N'Dĩa', N'Sụn gà giòn đậm đà', 2, N'Đang bán'),
('M005', N'Lẩu Thái Hải Sản', 299000, N'Nồi', N'Lẩu chua cay tôm mực bò nấm', 3, N'Đang bán'),
('M006', N'Bia Tiger Bạc', 25000, N'Lon', N'Bia Tiger lon 330ml', 4, N'Đang bán'),
('M007', N'Nước Suối Aquafina', 15000, N'Chai', N'Nước tinh khiết 500ml', 4, N'Đang bán');

-- 7. Thêm phương thức thanh toán
INSERT INTO PHUONGTHUCTHANHTOAN (TenPTTT)
VALUES 
(N'Tiền mặt'),
(N'Chuyển khoản ngân hàng (VietQR)'),
(N'Thẻ tín dụng / Ghi nợ');

-- 8. Thêm hóa đơn mẫu (Bàn 1 đang có khách)
INSERT INTO HOADON (MaHoaDon, BanID, NhanVienID, ThoiGianVao, TongTienHang, TongThanhToan, TrangThai)
VALUES 
('HD0001', 1, 2, DATEADD(MINUTE, -45, GETDATE()), 388000, 388000, N'Chưa thanh toán');

-- 9. Thêm chi tiết món của hóa đơn 1
INSERT INTO CHITIET_HOADON (HoaDonID, MonID, SoLuong, DonGia, TrangThaiMon)
VALUES 
(1, 1, 1, 35000, N'Đã phục vụ'),
(1, 3, 1, 149000, N'Đã phục vụ'),
(1, 4, 1, 119000, N'Đã phục vụ'),
(1, 6, 3, 25000, N'Đã phục vụ'),
(1, 7, 1, 15000, N'Đã phục vụ');
