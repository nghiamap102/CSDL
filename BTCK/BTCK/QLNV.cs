using BTCK.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK
{
    public partial class QLNV : Form
    {
        BUS_NV bus;
        public QLNV()
        {
            bus = new BUS_NV();
            InitializeComponent();
        }

        void EnableBtn()
        {
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btResetPassword.Enabled = true;
        }
        void DisableBtn()
        {
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btResetPassword.Enabled = false;
        }
        Boolean CheckEmpty()
        {
            if (txtDiaChi.Text.Length == 0 || txtMK.Text.Length == 0 ||
                txtMK.Text.Length == 0 || txtMK.Text.Length == 0 || txtMK.Text.Length == 0 )
            {
                return false;
            }
            else
                return true;
        }
        void rsInput()
        {
            
            txtDiaChi.ResetText();
            txtMaNV.ResetText();
            txtMK.ResetText();
            txtTenNV.ResetText(); 
            txtSDT.ResetText();
            txtSex.ResetText();
            dtpBirth.ResetText();
            DisableBtn();
        }
        private void HienThiDSNV()
        {
            gvNV.DataSource = null;
            //txtMaNV.Enabled = false;
            bus.LayDSNV(gvNV);
            gvNV.Columns[0].Width = (int)(gvNV.Width * 0.08);
            gvNV.Columns[1].Width = (int)(gvNV.Width * 0.15);
            gvNV.Columns[2].Width = (int)(gvNV.Width * 0.08);
            gvNV.Columns[3].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[4].Width = (int)(gvNV.Width * 0.2);
            gvNV.Columns[5].Width = (int)(gvNV.Width * 0.15);
            gvNV.Columns[6].Width = (int)(gvNV.Width * 0.15);

        }
        private void QLNV_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            HienThiDSNV();
            rsInput();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tb_NhanVien p = new tb_NhanVien();

            if (CheckEmpty() == true)
            {
                p.DiaChi = txtDiaChi.Text;
                p.MatKhau = txtMK.Text;
                p.GioiTinh = txtSex.Text;
                p.SDT = txtSDT.Text;
                p.NamSinh = dtpBirth.Value;
                p.TenNV = txtTenNV.Text;

                if (bus.ThemNV(p) == true)
                {
                    MessageBox.Show("Thêm Thành Công");
                    rsInput();
                    bus.LayDSNV(gvNV);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            tb_NhanVien o = new tb_NhanVien();
            o.MaNV = int.Parse(txtMaNV.Text);

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn có muốn xóa không?",
               "Xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (bus.XoaNV(o))
                {
                    MessageBox.Show("Xóa thành công");
                    rsInput();
                    bus.LayDSNV(gvNV);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }    
            }

            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            rsInput();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            tb_NhanVien p = new tb_NhanVien();
            p.MaNV = int.Parse(txtMaNV.Text);
            p.TenNV = txtTenNV.Text.ToString();
            p.GioiTinh = txtSex.Text;
            p.NamSinh = dtpBirth.Value;
            p.DiaChi = txtDiaChi.Text;
            p.SDT = txtSDT.Text;
            if (bus.SuaNV(p))
            {
                MessageBox.Show("Sửa thành công");
                rsInput();
                bus.LayDSNV(gvNV);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void gvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvNV.Rows.Count)
            {
                txtMaNV.Enabled = false;
                EnableBtn();
                txtMaNV.Text = gvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNV.Text = gvNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSDT.Text = gvNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSex.Text = gvNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = gvNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                dtpBirth.Text = gvNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMK.Text = gvNV.Rows[e.RowIndex].Cells[6].Value.ToString();

            }
        }

        private void btResetPassword_Click(object sender, EventArgs e)
        {
            if (txtMK.Text.Length == 0)
            {
                MessageBox.Show("Mật khẩu không được trống");
            }
            else
            {
                tb_NhanVien nv = new tb_NhanVien();
                nv.MaNV = int.Parse(txtMaNV.Text);
                nv.MatKhau = txtMK.Text;

                if (bus.ResetPassưord(nv))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");
                    bus.LayDSNV(gvNV);
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại");
                }    

            }
        }

      
    }
}
