using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
namespace Lab04
{
    public partial class Form1 : Form
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
            SinhVien sv1 = new SinhVien("2212461", "Ngô Công Thành", "Nam", new DateTime(2004,01,05), "CTK46", "0368.635.765", "2212461@dlu.edu.vn", "DALAT LAM DONG", "");
            danhSachSinhVien.Add(sv1);
            SinhVien sv2 = new SinhVien("2212398", "Đỗ Lâm Ngọc An Khang", "Nữ", new DateTime(2004,06,16), "CTK46", "0904.656.564", "2212389@dlu.edu.vn", "DONG NAI", "");
            danhSachSinhVien.Add(sv2);
            SinhVien sv3 = new SinhVien("2212436", "Phan Thành Phát", "Nam", new DateTime(2004,12,12), "CTK46", "090.9999.999", "2212436@dlu.edu.vn", "PHAN THIET", "");
            danhSachSinhVien.Add(sv3);
        }

        private void btnBrowre_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị đường dẫn hình ảnh trong TextBox
                    txtHinh.Text = openFileDialog.FileName;

                    // Hiển thị hình ảnh trong PictureBox
                    pbHinh.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtxtMaSo.Clear();
            txtHoTen.Clear();
            
            dtpNgaySinh.Value = DateTime.Now;
            
            maskedTextBox1.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtHinh.Clear();

            // Đặt lại hình ảnh trong PictureBox
            pbHinh.Image = null;

           
        }
    

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSV = mtxtMaSo.Text;

            // Tìm sinh viên theo mã sinh viên
            SinhVien sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSV == maSV);

            if (sinhVien != null)
            {
                // Cập nhật thông tin sinh viên
                sinhVien.HoTen = txtHoTen.Text;
                sinhVien.Phai = rdNam.Text;
                sinhVien.NgaySinh = dtpNgaySinh.Value;
                sinhVien.Lop = cboLop.Text;
                sinhVien.SoDienThoai = maskedTextBox1.Text;
                sinhVien.Email = txtEmail.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.Hinh = txtHinh.Text;
            }
            else
            {
                // Thêm sinh viên mới
                SinhVien newSinhVien = new SinhVien(maSV,
                    txtHoTen.Text,
                    rdNam.Text,
                    rdNu.Text,
                    dtpNgaySinh.Value,
                    cboLop.Text,
                    maskedTextBox1.Text,
                    txtEmail.Text,
                    txtDiaChi.Text,
                    txtHinh.Text
                );
                danhSachSinhVien.Add(newSinhVien);
            }

            // Cập nhật ListView
            UpdateListView();
        }

        private void UpdateListView()
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in danhSachSinhVien)
            {
                ListViewItem item = new ListViewItem(sv.MaSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Phai);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoDienThoai);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Hinh);
                lvSinhVien.Items.Add(item);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];
                string maSV = item.Text;

                // Tìm sinh viên theo mã sinh viên
                SinhVien sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSV == maSV);

                if (sinhVien != null)
                {
                    // Hiển thị thông tin sinh viên lên các TextBox và PictureBox
                    mtxtMaSo.Text = sinhVien.MaSV;
                    txtHoTen.Text = sinhVien.HoTen;
                    rdNam.Text = sinhVien.Phai;
                    rdNu.Text = sinhVien.Phai;
                    dtpNgaySinh.Value = sinhVien.NgaySinh;
                    cboLop.Text = sinhVien.Lop;
                    maskedTextBox1.Text = sinhVien.SoDienThoai;
                    txtEmail.Text = sinhVien.Email;
                    txtDiaChi.Text = sinhVien.DiaChi;
                    txtHinh.Text = sinhVien.Hinh;

                    if (!string.IsNullOrEmpty(sinhVien.Hinh) && System.IO.File.Exists(sinhVien.Hinh))
                    {
                        pbHinh.Image = Image.FromFile(sinhVien.Hinh);
                    }
                    else
                    {
                        pbHinh.Image = null;
                    }
                }
            }
        }

        private void xoaToolStripMenuItem_Opening(object sender, CancelEventArgs e)
        {
            List<string> maSVsToRemove = new List<string>();

            foreach (ListViewItem item in lvSinhVien.SelectedItems)
            {
                // Lấy mã sinh viên từ ListViewItem
                string maSV = item.Text;
                maSVsToRemove.Add(maSV);
            }

            // Xóa các sinh viên từ danhSachSinhVien
            foreach (string maSV in maSVsToRemove)
            {
                SinhVien sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSV == maSV);
                if (sinhVien != null)
                {
                    danhSachSinhVien.Remove(sinhVien);
                }
            }
            // Cập nhật lại ListView
            UpdateListView();
        }
       
    }
    }
    

