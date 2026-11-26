-- 0. Sequence sinh mã nhân viên tự động (NV0001, NV0002, ...)
CREATE SEQUENCE seq_MaNV
    START WITH 1
    INCREMENT BY 1;

-- 1. BẢNG NHÂN VIÊN
CREATE TABLE NHANVIEN
(
    NhanVienID int IDENTITY(1,1) NOT NULL,
    MaNV varchar(10) NOT NULL,
    HoTen nvarchar(100) NOT NULL,
    NgaySinh date,
    GioiTinh nvarchar(10),
    SoDienThoai varchar(15),
    DiaChi nvarchar(200),
    VaiTro nvarchar(50) NOT NULL,

    CONSTRAINT PK_NHANVIEN PRIMARY KEY (NhanVienID),
    CONSTRAINT UQ_NHANVIEN_MANV UNIQUE (MaNV),
    CONSTRAINT CK_NHANVIEN_VAITRO CHECK (VaiTro IN (N'Quản lý', N'Phục vụ', N'Thu ngân'))
);

-- 2. BẢNG TÀI KHOẢN
CREATE TABLE TAIKHOAN
(
    TaiKhoanID int IDENTITY(1,1) NOT NULL,
    NhanVienID int NOT NULL,
    TenDangNhap varchar(50) NOT NULL,
    MatKhau varchar(255) NOT NULL,
    Email varchar(255),
    TrangThai nvarchar(30),
    NgayTao datetime DEFAULT GETDATE(),

    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (TaiKhoanID),
    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY (NhanVienID) REFERENCES NHANVIEN(NhanVienID),
    CONSTRAINT UQ_TAIKHOAN_NHANVIENID UNIQUE (NhanVienID),
    CONSTRAINT UQ_TAIKHOAN_TENDANGNHAP UNIQUE (TenDangNhap)
);

-- 3. BẢNG CA LÀM VIỆC
CREATE TABLE CA_LAMVIEC
(
    CaID int IDENTITY(1,1) NOT NULL,
    TenCa nvarchar(50) NOT NULL,
    GioBatDau time NOT NULL,
    GioKetThuc time NOT NULL,

    CONSTRAINT PK_CA_LAMVIEC PRIMARY KEY (CaID)
);

-- 4. BẢNG PHÂN CÔNG CA
CREATE TABLE PHANCONG_CA
(
    PhanCongID int IDENTITY(1,1) NOT NULL,
    NhanVienID int NOT NULL,
    CaID int NOT NULL,
    NgayLam date NOT NULL,
    GioVao datetime,
    GioRa datetime,

    CONSTRAINT PK_PHANCONG_CA PRIMARY KEY (PhanCongID),
    CONSTRAINT FK_PHANCONG_CA_NHANVIEN FOREIGN KEY (NhanVienID) REFERENCES NHANVIEN(NhanVienID),
    CONSTRAINT FK_PHANCONG_CA_CA_LAMVIEC FOREIGN KEY (CaID) REFERENCES CA_LAMVIEC(CaID)
);

-- 5. BẢNG BÀN ĂN
CREATE TABLE BAN
(
    BanID int IDENTITY(1,1) NOT NULL,
    MaBan varchar(10) NOT NULL,
    TenBan nvarchar(50) NOT NULL,
    SucChua int NOT NULL,
    TrangThai nvarchar(30) DEFAULT N'Trống',

    CONSTRAINT PK_BAN PRIMARY KEY (BanID),
    CONSTRAINT UQ_BAN_MABAN UNIQUE (MaBan)
);

-- 6. BẢNG DANH MỤC MÓN
CREATE TABLE DANHMUCMON
(
    DanhMucID int IDENTITY(1,1) NOT NULL,
    TenDanhMuc nvarchar(100) NOT NULL,

    CONSTRAINT PK_DANHMUCMON PRIMARY KEY (DanhMucID)
);

-- 7. BẢNG MÓN ĂN
CREATE TABLE MONAN
(
    MonID int IDENTITY(1,1) NOT NULL,
    MaMon varchar(10) NOT NULL,
    TenMon nvarchar(100) NOT NULL,
    DonGia decimal(18, 2) NOT NULL,
    DonViTinh nvarchar(30),
    MoTa nvarchar(500),
    DanhMucID int NOT NULL,
    TrangThai nvarchar(30) DEFAULT N'Đang bán',

    CONSTRAINT PK_MONAN PRIMARY KEY (MonID),
    CONSTRAINT UQ_MONAN_MAMON UNIQUE (MaMon),
    CONSTRAINT FK_MONAN_DANHMUCMON FOREIGN KEY (DanhMucID) REFERENCES DANHMUCMON(DanhMucID)
);

-- 8. BẢNG KHUYẾN MÃI
CREATE TABLE KHUYENMAI
(
    KhuyenMaiID int IDENTITY(1,1) NOT NULL,
    MaKM varchar(10) NOT NULL,
    TenKM nvarchar(100) NOT NULL,
    LoaiKM nvarchar(30) NOT NULL,
    GiaTri decimal(18, 2) NOT NULL,
    DieuKienToiThieu decimal(18, 2),
    NgayBatDau date NOT NULL,
    NgayKetThuc date NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_KHUYENMAI PRIMARY KEY (KhuyenMaiID),
    CONSTRAINT UQ_KHUYENMAI_MAKM UNIQUE (MaKM)
);

-- 9. BẢNG HÓA ĐƠN (Gắn trực tiếp với Bàn, quản lý mở bàn - gọi món - thanh toán)
CREATE TABLE HOADON
(
    HoaDonID int IDENTITY(1,1) NOT NULL,
    MaHoaDon varchar(20) NOT NULL,
    BanID int NOT NULL,
    NhanVienID int NOT NULL,
    KhuyenMaiID int NULL,

    ThoiGianVao datetime DEFAULT GETDATE(),
    ThoiGianRa datetime NULL,

    TongTienHang decimal(18, 2) NOT NULL DEFAULT 0,
    PhuThu decimal(18, 2) NOT NULL DEFAULT 0,
    GiamGia decimal(18, 2) NOT NULL DEFAULT 0,
    ThueVAT decimal(18, 2) NOT NULL DEFAULT 0,
    TongThanhToan decimal(18, 2) NOT NULL DEFAULT 0,

    TrangThai nvarchar(30) NOT NULL DEFAULT N'Chưa thanh toán',
    GhiChu nvarchar(500) NULL,

    CONSTRAINT PK_HOADON PRIMARY KEY (HoaDonID),
    CONSTRAINT UQ_HOADON_MAHOADON UNIQUE (MaHoaDon),
    CONSTRAINT FK_HOADON_BAN FOREIGN KEY (BanID) REFERENCES BAN(BanID),
    CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY (NhanVienID) REFERENCES NHANVIEN(NhanVienID),
    CONSTRAINT FK_HOADON_KHUYENMAI FOREIGN KEY (KhuyenMaiID) REFERENCES KHUYENMAI(KhuyenMaiID),
    CONSTRAINT CK_HOADON_TRANGTHAI CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán', N'Đã hủy'))
);

-- 10. BẢNG CHI TIẾT HÓA ĐƠN (Các món gọi trong hóa đơn)
CREATE TABLE CHITIET_HOADON
(
    ChiTietID int IDENTITY(1,1) NOT NULL,
    HoaDonID int NOT NULL,
    MonID int NOT NULL,
    SoLuong int NOT NULL,
    DonGia decimal(18, 2) NOT NULL,
    GhiChu nvarchar(500),
    TrangThaiMon nvarchar(30) DEFAULT N'Chờ chế biến',

    CONSTRAINT PK_CHITIET_HOADON PRIMARY KEY (ChiTietID),
    CONSTRAINT FK_CHITIET_HOADON_HOADON FOREIGN KEY (HoaDonID) REFERENCES HOADON(HoaDonID) ON DELETE CASCADE,
    CONSTRAINT FK_CHITIET_HOADON_MONAN FOREIGN KEY (MonID) REFERENCES MONAN(MonID)
);

-- 11. BẢNG LỊCH SỬ ĐIỀU CHỈNH HÓA ĐƠN / MÓN
CREATE TABLE LICHSU_DIEUCHINH
(
    LichSuID int IDENTITY(1,1) NOT NULL,
    HoaDonID int NOT NULL,
    NhanVienID int NOT NULL,
    ThoiGian datetime DEFAULT GETDATE(),
    HanhDong nvarchar(100) NOT NULL,
    NoiDungCu nvarchar(MAX),
    NoiDungMoi nvarchar(MAX),
    LyDo nvarchar(500),

    CONSTRAINT PK_LICHSU_DIEUCHINH PRIMARY KEY (LichSuID),
    CONSTRAINT FK_LICHSU_DIEUCHINH_HOADON FOREIGN KEY (HoaDonID) REFERENCES HOADON(HoaDonID),
    CONSTRAINT FK_LICHSU_DIEUCHINH_NHANVIEN FOREIGN KEY (NhanVienID) REFERENCES NHANVIEN(NhanVienID)
);

-- 12. BẢNG PHƯƠNG THỨC THANH TOÁN
CREATE TABLE PHUONGTHUCTHANHTOAN
(
    PhuongThucID int IDENTITY(1,1) NOT NULL,
    TenPTTT nvarchar(100) NOT NULL,

    CONSTRAINT PK_PHUONGTHUCTHANHTOAN PRIMARY KEY (PhuongThucID)
);

-- 13. BẢNG THANH TOÁN (Giao dịch thanh toán của hóa đơn)
CREATE TABLE THANHTOAN
(
    ThanhToanID int IDENTITY(1,1) NOT NULL,
    HoaDonID int NOT NULL,
    PhuongThucID int NOT NULL,
    PhanCongID int NOT NULL,
    SoTien decimal(18, 2) NOT NULL,
    TienKhachDua decimal(18, 2),
    TienThua decimal(18, 2),
    ThoiGianThanhToan datetime DEFAULT GETDATE(),
    TrangThai nvarchar(30) DEFAULT N'Thành công',

    CONSTRAINT PK_THANHTOAN PRIMARY KEY (ThanhToanID),
    CONSTRAINT FK_THANHTOAN_HOADON FOREIGN KEY (HoaDonID) REFERENCES HOADON(HoaDonID),
    CONSTRAINT FK_THANHTOAN_PHUONGTHUCTHANHTOAN FOREIGN KEY (PhuongThucID) REFERENCES PHUONGTHUCTHANHTOAN(PhuongThucID),
    CONSTRAINT FK_THANHTOAN_PHANCONG_CA FOREIGN KEY (PhanCongID) REFERENCES PHANCONG_CA(PhanCongID)
);

-- 14. BẢNG NHẬT KÝ HOẠT ĐỘNG
CREATE TABLE NHATKY_HOATDONG
(
    NhatKyID int IDENTITY(1,1) NOT NULL,
    TaiKhoanID int NOT NULL,
    HanhDong nvarchar(100) NOT NULL,
    ThoiGian datetime DEFAULT GETDATE(),
    MoTa nvarchar(500),

    CONSTRAINT PK_NHATKY_HOATDONG PRIMARY KEY (NhatKyID),
    CONSTRAINT FK_NHATKY_HOATDONG_TAIKHOAN FOREIGN KEY (TaiKhoanID) REFERENCES TAIKHOAN(TaiKhoanID)
);
