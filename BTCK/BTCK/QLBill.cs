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
    public partial class QLBill : Form
    {
        BUS.BUS_BILL bus;
        public QLBill()
        {
            bus = new BUS.BUS_BILL();
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
            if (cbKhachHang.SelectedValue == null ||
                 cbNhanVien.SelectedValue == null)
            {
                return false;
            }
            else
                return true;
        }
        void rsInput()
        {
            cbKhachHang.ResetText();
            cbKhachHang.SelectedItem = null;
            cbKhachHang.Text = "Khách Hàng";
            cbNhanVien.ResetText();
            cbNhanVien.SelectedItem = null;
            cbNhanVien.Text = "Nhân viên";
            txtMaDH.ResetText();
            DisableBtn();
        }
        private void HienThiDSBill()
        {
            gVDH.DataSource = null;
            bus.LayDSBill(gVDH);
            //gVDH.Columns[0].Width = (int)(gVDH.Width * 0.1);
            //gVDH.Columns[1].Width = (int)(gVDH.Width * 0.25);
            //gVDH.Columns[2].Width = (int)(gVDH.Width * 0.15);
            //gVDH.Columns[3].Width = (int)(gVDH.Width * 0.2);
            rsInput();

        }
        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                EnableBtn();
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpNgayDatHang.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void QLBill_Load(object sender, EventArgs e)
        {
            HienThiDSBill();
            bus.LayDSKH(cbKhachHang);
            bus.LayDSNV(cbNhanVien);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tb_HoaDon p = new tb_HoaDon();

            if (CheckEmpty() == true)
            {
                p.MaHD = int.Parse(txtMaDH.Text.ToString());
                p.NgayLap = dtpNgayDatHang.Value;

                p.NguoiLap = cbNhanVien.SelectedValue.ToString();
                p.KhachHang = int.Parse(cbKhachHang.SelectedValue.ToString());

                if (bus.ThemBill(p) == true)
                {
                    MessageBox.Show("Thêm Thành Công");
                    rsInput();
                    bus.LayDSBill(gVDH);
                }
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
