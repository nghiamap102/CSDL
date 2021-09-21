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
    public partial class QLHH : Form
    {
        BUS_HH bus;
        public QLHH()
        {
            bus = new BUS_HH();
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
            if (txtSoLuong.Text.Length == 0 || txtDonGia.Text.Length == 0 || 
                 cbLoaiHH.SelectedValue == null )
            {
                return false;
            }
            else
                return true;
        }
        void rsInput()
        {
            cbLoaiHH.ResetText();
            cbLoaiHH.SelectedItem = null;
            cbLoaiHH.Text = "Chọn Loại Hàng";            
            txtSoLuong.ResetText();
            txtDonGia.ResetText();
            txtMaSP.ResetText();
            txtTenHH.ResetText();
            DisableBtn();
        }
        private void HienThiDSHH()
        {
            gVSanPham.DataSource = null;
            bus.LayDSHH(gVSanPham);
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.1);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.25);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.2);

        }
        private void QLHH_Load(object sender, EventArgs e)
        {
            txtMaSP.Enabled = false;
            HienThiDSHH();
            bus.LayLoaiHH(cbLoaiHH);
            rsInput();

        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count)
            {
                EnableBtn();
                txtMaSP.Text = gVSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenHH.Text = gVSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoLuong.Text = gVSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbLoaiHH.SelectedValue = int.Parse(gVSanPham.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tb_HangHoa p = new tb_HangHoa();

            if (CheckEmpty() == true)
            {
                p.TenHang = txtTenHH.Text.ToString();
                p.SoLuong = int.Parse(txtSoLuong.Text.ToString());
                p.LoaiHangHoa = int.Parse(cbLoaiHH.SelectedValue.ToString());
                p.DonGia = int.Parse(txtDonGia.Text.ToString());

                if ( p.SoLuong < 0 || int.Parse(txtDonGia.Text.ToString()) < 0)
                {
                    MessageBox.Show("số lượng không dc bé hơn 0");
                }
                else
                {
                    if (p.TenHang.Contains("123"))
                    {
                        MessageBox.Show("Vui Lòng Nhập Đúng Tên Hàng Hóa ");
                    }
                    else
                    {
                        if (bus.ThemHH(p) == true)
                        {
                            MessageBox.Show("Thêm Thành Công");
                            rsInput();
                            bus.LayDSHH(gVSanPham);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            tb_HangHoa o = new tb_HangHoa();
            o.MaHang = int.Parse(txtMaSP.Text);

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn có muốn xóa không?",
               "Xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (bus.XoaHH(o))
                {
                    MessageBox.Show("Xóa đơn hàng thành công");
                    rsInput();
                    bus.LayDSHH(gVSanPham);
                }
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng thất bại");
            }
            rsInput();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            tb_HangHoa p = new tb_HangHoa();
            p.MaHang = int.Parse(txtMaSP.Text.ToString());
            p.LoaiHangHoa = int.Parse(cbLoaiHH.SelectedValue.ToString());
            p.DonGia = Decimal.Parse(txtDonGia.Text.ToString());
            p.SoLuong = int.Parse(txtSoLuong.Text.ToString());
            p.TenHang = txtTenHH.Text.ToString();

            if (bus.SuaHH(p))
            {
                MessageBox.Show("Sửa sản phẩm thành công");
                rsInput();
                bus.LayDSHH(gVSanPham);
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
