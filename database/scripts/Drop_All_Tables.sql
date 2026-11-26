-- ========================================================
-- SCRIPT XÓA TOÀN BỘ CÁC BẢNG CŨ (DROP TABLES)
-- Thứ tự: Xóa từ bảng con (chứa khóa ngoại) lên bảng cha
-- ========================================================

-- 1. Xóa các bảng phụ thuộc cuối cùng (tầng giao dịch, nhật ký)
DROP TABLE IF EXISTS NHATKY_HOATDONG;
DROP TABLE IF EXISTS THANHTOAN;
DROP TABLE IF EXISTS PHUONGTHUCTHANHTOAN;
DROP TABLE IF EXISTS LICHSU_DIEUCHINH;

-- 2. Xóa chi tiết gọi món / chi tiết hóa đơn
DROP TABLE IF EXISTS CHITIET_HOADON;
DROP TABLE IF EXISTS CHITIET_GOIMON;

-- 3. Xóa hóa đơn và phiên phục vụ (nếu có từ bản cũ)
DROP TABLE IF EXISTS HOADON;
DROP TABLE IF EXISTS PHIENPHUCVU;

-- 4. Xóa khuyến mãi, món ăn và danh mục món
DROP TABLE IF EXISTS KHUYENMAI;
DROP TABLE IF EXISTS MONAN;
DROP TABLE IF EXISTS DANHMUCMON;

-- 5. Xóa bàn ăn
DROP TABLE IF EXISTS BAN;

-- 6. Xóa phân công ca và ca làm việc
DROP TABLE IF EXISTS PHANCONG_CA;
DROP TABLE IF EXISTS CA_LAMVIEC;

-- 7. Xóa tài khoản và nhân viên
DROP TABLE IF EXISTS TAIKHOAN;
DROP TABLE IF EXISTS NHANVIEN;

-- 8. Xóa sequence sinh mã nhân viên (nếu có)
DROP SEQUENCE IF EXISTS seq_MaNV;

PRINT N'>>> ĐÃ XÓA TOÀN BỘ CÁC BẢNG CŨ THÀNH CÔNG!';
