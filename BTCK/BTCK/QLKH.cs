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
    public partial class QLKH : Form
    {
        BUS_KH bus;
        public QLKH()
        {
            bus = new BUS_KH();
            InitializeComponent();
        }
        void EnableBtn()
        {
            btXoa.Enabled = true;
            btSua.Enabled = true;
        }
        void DisableBtn()
        {
            btSua.Enabled = false;
            btXoa.Enabled = false;
        }
        Boolean CheckEmpty()
        {
            if (txtDiaChi.Text.Length == 0 || txtSDT.Text.Length == 0 ||
                txtTenNV.Text.Length == 0 || txtSex.Text.Length == 0 )
            {
                return false;
            }
            else
                return true;
        }
        void rsInput()
        {

            txtDiaChi.ResetText();
            txtEmail.ResetText();
            txtTenNV.ResetText();
            txtSDT.ResetText();
            txtSex.ResetText();
            dtpBirth.ResetText();
            DisableBtn();
        }
        private void HienThiDSKH()
        {
            gvNV.DataSource = null;
            txtMaKH.Enabled = false;
            bus.LayDSKH(gvNV);
            gvNV.Columns[0].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[1].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[2].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[3].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[4].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[5].Width = (int)(gvNV.Width * 0.1);
            gvNV.Columns[6].Width = (int)(gvNV.Width * 0.1);

        }
        private void QLKH_Load(object sender, EventArgs e)
        {
            HienThiDSKH();
            rsInput();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tb_KhachHang p = new tb_KhachHang();

            if (CheckEmpty() == true)
            {
                p.DiaChi = txtDiaChi.Text;
                p.Email = txtEmail.Text.ToString();
                p.GioiTinh = txtSex.Text;
                p.SDT = txtSDT.Text;
                p.NamSinh = dtpBirth.Value;
                p.TenKH = txtTenNV.Text;

                if (bus.ThemKH(p) == true)
                {
                    MessageBox.Show("Thêm Thành Công");
                    rsInput();
                    bus.LayDSKH(gvNV);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            tb_KhachHang o = new tb_KhachHang();
            o.MaKH = int.Parse(txtMaKH.Text.ToString());

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn có mún xóa không?",
               "Xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (bus.XoaKH(o))
                {
                    MessageBox.Show("Xóa thành công");
                    rsInput();
                    bus.LayDSKH(gvNV);
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
            tb_KhachHang p = new tb_KhachHang();

            p.MaKH = int.Parse(txtMaKH.Text);
            p.TenKH = txtTenNV.Text.ToString();
            p.GioiTinh = txtSex.Text;
            p.NamSinh = dtpBirth.Value;
            p.DiaChi = txtDiaChi.Text;
            p.SDT = txtSDT.Text;
            p.Email = txtEmail.Text;

            if (bus.SuaKH(p))
            {
                MessageBox.Show("Sửa thành công");
                rsInput();
                bus.LayDSKH(gvNV);
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
                EnableBtn();
                txtMaKH.Text = gvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNV.Text = gvNV.Rows[e.RowIndex].Cells[1].Value.ToString();
               
                txtEmail.Text = gvNV.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSDT.Text = gvNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSex.Text = gvNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = gvNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpBirth.Text = gvNV.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
        }
    }
}
