CREATE TABLE NHANVIEN
(
    MaNV varchar(10) NOT NULL,
    HoTen nvarchar(100) NOT NULL,
    NgaySinh date,
    GioiTinh nvarchar(10),
    SoDienThoai varchar(15),
    DiaChi nvarchar(200),
    VaiTro nvarchar(50) NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_NHANVIEN PRIMARY KEY (MaNV),

    CONSTRAINT CK_NHANVIEN_VAITRO CHECK (VaiTro IN (N'Quản lý', N'Phục vụ', N'Thu ngân'))
);

CREATE TABLE TAIKHOAN
(
    MaTaiKhoan varchar(10) NOT NULL,
    MaNV varchar(10) NOT NULL,
    TenDangNhap varchar(50) NOT NULL,
    MatKhau varchar(255) NOT NULL,
    TrangThai nvarchar(30),
    NgayTao datetime DEFAULT GETDATE(),

    CONSTRAINT PK_TAIKHOAN PRIMARY KEY (MaTaiKhoan),

    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),

    CONSTRAINT UQ_TAIKHOAN_MANV UNIQUE (MaNV),

    CONSTRAINT UQ_TAIKHOAN_TENDANGNHAP UNIQUE (TenDangNhap)
);

CREATE TABLE CA_LAMVIEC
(
    MaCa varchar(10) NOT NULL,
    TenCa nvarchar(50) NOT NULL,
    GioBatDau time NOT NULL,
    GioKetThuc time NOT NULL,

    CONSTRAINT PK_CA_LAMVIEC PRIMARY KEY (MaCa)
);

CREATE TABLE PHANCONG_CA
(
    MaPhanCong varchar(10) NOT NULL,
    MaNV varchar(10) NOT NULL,
    MaCa varchar(10) NOT NULL,
    NgayLam date NOT NULL,
    GioVao datetime,
    GioRa datetime,

    CONSTRAINT PK_PHANCONG_CA PRIMARY KEY (MaPhanCong),

    CONSTRAINT FK_PHANCONG_CA_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),

    CONSTRAINT FK_PHANCONG_CA_CA_LAMVIEC FOREIGN KEY (MaCa) REFERENCES CA_LAMVIEC(MaCa)
);

CREATE TABLE BAN
(
    MaBan varchar(10) NOT NULL,
    TenBan nvarchar(50) NOT NULL,
    SucChua int NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_BAN PRIMARY KEY (MaBan)
);

CREATE TABLE PHIENPHUCVU
(
    MaPhien varchar(10) NOT NULL,
    MaNV varchar(10) NOT NULL,
    ThoiGianMo datetime NOT NULL,
    ThoiGianDong datetime,
    TrangThai nvarchar(30),

    CONSTRAINT PK_PHIENPHUCVU PRIMARY KEY (MaPhien),

    CONSTRAINT FK_PHIENPHUCVU_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

CREATE TABLE PHIEN_BAN
(
    MaPhien varchar(10) NOT NULL,
    MaBan varchar(10) NOT NULL,

    CONSTRAINT PK_PHIEN_BAN PRIMARY KEY (MaPhien, MaBan),

    CONSTRAINT FK_PHIEN_BAN_PHIENPHUCVU FOREIGN KEY (MaPhien) REFERENCES PHIENPHUCVU(MaPhien),

    CONSTRAINT FK_PHIEN_BAN_BAN FOREIGN KEY (MaBan) REFERENCES BAN(MaBan)
);

CREATE TABLE DANHMUCMON
(
    MaDanhMuc varchar(10) NOT NULL,
    TenDanhMuc nvarchar(100) NOT NULL,

    CONSTRAINT PK_DANHMUCMON PRIMARY KEY (MaDanhMuc)
);

CREATE TABLE MONAN
(
    MaMon varchar(10) NOT NULL,
    TenMon nvarchar(100) NOT NULL,
    DonGia decimal(18, 2) NOT NULL,
    DonViTinh nvarchar(30),
    MoTa nvarchar(500),
    MaDanhMuc varchar(10) NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_MONAN PRIMARY KEY (MaMon),

    CONSTRAINT FK_MONAN_DANHMUCMON FOREIGN KEY (MaDanhMuc) REFERENCES DANHMUCMON(MaDanhMuc)
);

CREATE TABLE DONHANG
(
    MaDonHang varchar(10) NOT NULL,
    MaPhien varchar(10) NOT NULL,
    NgayTao datetime DEFAULT GETDATE(),
    TrangThai nvarchar(30),

    CONSTRAINT PK_DONHANG PRIMARY KEY (MaDonHang),

    CONSTRAINT FK_DONHANG_PHIENPHUCVU FOREIGN KEY (MaPhien) REFERENCES PHIENPHUCVU(MaPhien),

    CONSTRAINT UQ_DONHANG_MAPHIEN UNIQUE (MaPhien)
);

CREATE TABLE CHITIET_DONHANG
(
    MaChiTiet varchar(10) NOT NULL,
    MaDonHang varchar(10) NOT NULL,
    MaMon varchar(10) NOT NULL,
    SoLuong int NOT NULL,
    DonGia decimal(18, 2) NOT NULL,
    GhiChu nvarchar(500),
    TrangThaiMon nvarchar(30),

    CONSTRAINT PK_CHITIET_DONHANG PRIMARY KEY (MaChiTiet),

    CONSTRAINT FK_CHITIET_DONHANG_DONHANG FOREIGN KEY (MaDonHang) REFERENCES DONHANG(MaDonHang),

    CONSTRAINT FK_CHITIET_DONHANG_MONAN FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon)
);

CREATE TABLE LICHSU_DIEUCHINH
(
    MaLichSu varchar(10) NOT NULL,
    MaDonHang varchar(10) NOT NULL,
    MaNV varchar(10) NOT NULL,
    ThoiGian datetime DEFAULT GETDATE(),
    HanhDong nvarchar(100) NOT NULL,
    NoiDungCu nvarchar(MAX),
    NoiDungMoi nvarchar(MAX),
    LyDo nvarchar(500),

    CONSTRAINT PK_LICHSU_DIEUCHINH PRIMARY KEY (MaLichSu),

    CONSTRAINT FK_LICHSU_DIEUCHINH_DONHANG FOREIGN KEY (MaDonHang) REFERENCES DONHANG(MaDonHang),

    CONSTRAINT FK_LICHSU_DIEUCHINH_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

CREATE TABLE KHUYENMAI
(
    MaKM varchar(10) NOT NULL,
    TenKM nvarchar(100) NOT NULL,
    LoaiKM nvarchar(30) NOT NULL,
    GiaTri decimal(18, 2) NOT NULL,
    DieuKienToiThieu decimal(18, 2),
    NgayBatDau date NOT NULL,
    NgayKetThuc date NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_KHUYENMAI PRIMARY KEY (MaKM)
);

CREATE TABLE HOADON
(
    MaHoaDon varchar(10) NOT NULL,
    MaDonHang varchar(10) NOT NULL,
    MaKM varchar(10),
    NgayLap datetime DEFAULT GETDATE(),
    TongTienHang decimal(18, 2) NOT NULL,
    GiamGia decimal(18, 2) NOT NULL,
    TongThanhToan decimal(18, 2) NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_HOADON PRIMARY KEY (MaHoaDon),

    CONSTRAINT FK_HOADON_DONHANG FOREIGN KEY (MaDonHang) REFERENCES DONHANG(MaDonHang),

    CONSTRAINT FK_HOADON_KHUYENMAI FOREIGN KEY (MaKM) REFERENCES KHUYENMAI(MaKM),

    CONSTRAINT UQ_HOADON_MADONHANG UNIQUE (MaDonHang)
);

CREATE TABLE PHUONGTHUCTHANHTOAN
(
    MaPTTT varchar(10) NOT NULL,
    TenPTTT nvarchar(100) NOT NULL,

    CONSTRAINT PK_PHUONGTHUCTHANHTOAN PRIMARY KEY (MaPTTT)
);

CREATE TABLE THANHTOAN
(
    MaThanhToan varchar(10) NOT NULL,
    MaHoaDon varchar(10) NOT NULL,
    MaPTTT varchar(10) NOT NULL,
    MaPhanCong varchar(10) NOT NULL,
    SoTien decimal(18, 2) NOT NULL,
    TienKhachDua decimal(18, 2),
    TienThua decimal(18, 2),
    ThoiGianThanhToan datetime DEFAULT GETDATE(),
    TrangThai nvarchar(30),

    CONSTRAINT PK_THANHTOAN PRIMARY KEY (MaThanhToan),

    CONSTRAINT FK_THANHTOAN_HOADON FOREIGN KEY (MaHoaDon) REFERENCES HOADON(MaHoaDon),

    CONSTRAINT FK_THANHTOAN_PHUONGTHUCTHANHTOAN FOREIGN KEY (MaPTTT) REFERENCES PHUONGTHUCTHANHTOAN(MaPTTT),

    CONSTRAINT FK_THANHTOAN_PHANCONG_CA FOREIGN KEY (MaPhanCong) REFERENCES PHANCONG_CA(MaPhanCong)
);

CREATE TABLE NHATKY_HOATDONG
(
    MaNhatKy varchar(10) NOT NULL,
    MaTaiKhoan varchar(10) NOT NULL,
    HanhDong nvarchar(100) NOT NULL,
    ThoiGian datetime DEFAULT GETDATE(),
    MoTa nvarchar(500),

    CONSTRAINT PK_NHATKY_HOATDONG PRIMARY KEY (MaNhatKy),

    CONSTRAINT FK_NHATKY_HOATDONG_TAIKHOAN FOREIGN KEY (MaTaiKhoan) REFERENCES TAIKHOAN(MaTaiKhoan)
);
