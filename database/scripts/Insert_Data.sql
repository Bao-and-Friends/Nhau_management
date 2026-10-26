
INSERT INTO NHANVIEN
VALUES
('NV01', N'Nguyễn Văn A', '2000-05-10', N'Nam', '0901234567', N'TP.HCM', N'Thu Ngân',null,'totribao17891@gmail.com'),
('NV02', N'Trần Thị B', '2001-08-20', N'Nữ', '0912345678', N'TP.HCM', N'Quản Lý',null,'totribao17891@gmail.com');

INSERT INTO TAIKHOAN
(
    MaNV,
    TenDangNhap,
    MatKhau,
    TrangThai
)
VALUES
('NV01', 'nguyenvana', '$2a$11$6bvzfY/Zmv7oanqLWQIrNunn46DrxPLeR3gff.kd.xyvawkLNtciS', N'Hoạt động'),
('NV02', 'tranthib', '$2a$11$IjzZi.AfI9ER4CuUQbg.L.owhWnPcteA3yrdR2Rk63p8oa9uExTl6', N'Hoạt động');
select * from taikhoan
select * from Nhanvien
select * from Ban
update NHANVIEN
set TrangThai = null
where MaNV='NV02'
DELETE FROM NHANVIEN WHERE MaNV='NV03';