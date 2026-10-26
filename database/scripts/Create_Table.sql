CREATE TABLE NHANVIEN
(
    MaNV varchar(10) primary key ,
    HoTen nvarchar(100) NOT NULL,
    NgaySinh date,
    GioiTinh nvarchar(10),
    SoDienThoai varchar(15),
    DiaChi nvarchar(200),
    VaiTro varchar(10) NOT NULL,
    TrangThai nvarchar(30),
    Email varchar(255),
);

CREATE TABLE TAIKHOAN
(
    
    MaNV varchar(10) primary key,
    TenDangNhap varchar(50) NOT NULL,
    MatKhau varchar(255) NOT NULL,
    TrangThai nvarchar(30),
    NgayTao datetime DEFAULT GETDATE(),

    CONSTRAINT FK_TAIKHOAN_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),

    CONSTRAINT UQ_TAIKHOAN_TenDangNhap UNIQUE (TenDangNhap),
);
