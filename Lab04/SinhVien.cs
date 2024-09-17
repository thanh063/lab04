using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab04
{
    public class SinhVien
    {
        private string v1;
        private string v2;
        private string v3;
        private DateTime dateTime;
        private string v4;
        private string v5;
        private string v6;
        private string v7;
        private string v8;

        public string MaSV { get; set; }  // Mã sinh viên
        public string HoTen { get; set; } // Họ và tên
        public string Phai { get; set; }  // Phái (Nam/Nữ)
        public DateTime NgaySinh { get; set; } // Ngày sinh
        public string Lop { get; set; }  // Lớp
        public string SoDienThoai { get; set; } // Số điện thoại
        public string Email { get; set; } // Email
        public string DiaChi { get; set; } // Địa chỉ
        public string Hinh { get; set; }  // Hình (đường dẫn đến hình ảnh)

        // Constructor không tham số
        public SinhVien() { }

        // Constructor có tham số
        public SinhVien(string maSV, string hoTen, string phai, string text, DateTime ngaySinh,
                        string lop, string soDienThoai, string email, string diaChi, string hinh)
        {
            MaSV = maSV;
            HoTen = hoTen;
            Phai = phai;
            NgaySinh = ngaySinh;
            Lop = lop;
            SoDienThoai = soDienThoai;
            Email = email;
            DiaChi = diaChi;
            Hinh = hinh;
        }

        public SinhVien(string v1, string v2, string v3, DateTime dateTime, string v4, string v5, string v6, string v7, string v8)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.dateTime = dateTime;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.v7 = v7;
            this.v8 = v8;
        }

        // Phương thức để hiển thị thông tin sinh viên

    }


}


