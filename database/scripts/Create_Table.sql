
CREATE TABLE VAITRO
(
    MaVaiTro varchar(10) NOT NULL,
    TenVaiTro nvarchar(50) NOT NULL,

    CONSTRAINT PK_VAITRO PRIMARY KEY (MaVaiTro)
);

CREATE TABLE NHANVIEN
(
    MaNV varchar(10) NOT NULL,
    HoTen nvarchar(100) NOT NULL,
    NgaySinh date,
    GioiTinh nvarchar(10),
    SoDienThoai varchar(15),
    DiaChi nvarchar(200),
    MaVaiTro varchar(10) NOT NULL,
    TrangThai nvarchar(30),

    CONSTRAINT PK_NHANVIEN PRIMARY KEY (MaNV),

    CONSTRAINT FK_NHANVIEN_VAITRO FOREIGN KEY (MaVaiTro) REFERENCES VAITRO(MaVaiTro)
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
