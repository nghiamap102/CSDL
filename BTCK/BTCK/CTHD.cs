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
    public partial class CTHD : Form
    {
        public int maHD;
        BUS_CTHD bus;
        bool co = false;
        public CTHD()
        {
            bus = new BUS_CTHD();
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
            if (txtMaDH.Text.Length == 0 || txtDonGia.Text.Length == 0 ||
                 cbLoaiHH.SelectedValue == null||cbLoaiHH.SelectedValue==null)
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
            cbSP.ResetText();
            cbLoaiHH.SelectedItem = null;
            cbLoaiHH.Text = "Chọn Hàng Hóa";
            txtDonGia.ResetText();
            
            DisableBtn();
        }

        private void CTHD_Load(object sender, EventArgs e)
        {
            bus.LayDSSP(cbSP);
            bus.LayDSLoaiHH(cbLoaiHH);
            co = true;
            txtMaDH.Text = maHD.ToString();
            rsInput();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_HangHoa p;
            int maSP;
            if (co)
            {
                maSP = Int32.Parse(cbSP.SelectedValue.ToString());
                p = bus.LayTTSP(maSP);
                txtDonGia.Text = p.DonGia.ToString();
                cbLoaiHH.SelectedIndex = int.Parse(p.LoaiHangHoa.ToString())-1;
                Console.WriteLine(cbSP.SelectedValue);
            }

            //cbLoaiHH.SelectedIndex = p.LoaiHangHoa.Value;

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            tb_CTHD p = new tb_CTHD();

            if (CheckEmpty() == true)
            {
                p.MaHH = cbSP.Text.ToString();
                
                p. = int.Parse(cbLoaiHH.SelectedValue.ToString());
                p.DonGia = int.Parse(txtDonGia.Text.ToString());

                if (p.SoLuong < 0 || int.Parse(txtDonGia.Text.ToString()) < 0)
                {
                    MessageBox.Show("số lượng không dc bé hơn 0");

                }
                else
                {
                    if (bus.ThemCTHD(p) == true)
                    {
                        MessageBox.Show("Thêm Thành Công");
                        rsInput();
                        bus.LayDSSP(gvSP);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.RowIndex < gvSP.Rows.Count)
            //{
            //    EnableBtn();
            //    txtMaDH.Text = gvSP.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    txtDonGia.Text = gvSP.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    cb.SelectedValue = int.Parse(gvSP.Rows[e.RowIndex].Cells[4].Value.ToString());
            //    cbLoaiHH.SelectedValue = int.Parse(gvSP.Rows[e.RowIndex].Cells[4].Value.ToString());
            //}
        }
    }
}
