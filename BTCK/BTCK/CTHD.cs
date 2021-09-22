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
        DataTable tbDH;

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
            if (txtMaDH.Text.Length == 0 || txtDonGia.Text.Length == 0 )
            {
                return false;
            }
            else
                return true;
        }
        void rsInput()
        {
            cbSP.ResetText();
            cbSP.SelectedItem = null;
            cbSP.Text = "Chọn Hàng Hóa";
            txtDonGia.ResetText();
            
            DisableBtn();
        }

        private void CTHD_Load(object sender, EventArgs e)
        {
            bus.LayDSSP(cbSP);
            co = true;
            cbSP.SelectedValue = 1;
            txtMaDH.Text = maHD.ToString();
            rsInput();
            //bus.LayDSCTDH(gvSP,maHD);
            tbDH = new DataTable();
            tbDH.Columns.Add("MaHD");
            tbDH.Columns.Add("MaHH");
            tbDH.Columns.Add("SoLuong");
            tbDH.Columns.Add("DonGia");
            tbDH.Columns.Add("TongTien");
            gvSP.DataSource = tbDH;

            gvSP.Columns[0].Width = (int)(gvSP.Width * 0.15);
            gvSP.Columns[1].Width = (int)(gvSP.Width * 0.15);
            gvSP.Columns[2].Width = (int)(gvSP.Width * 0.15);
            gvSP.Columns[3].Width = (int)(gvSP.Width * 0.2);
            gvSP.Columns[4].Width = (int)(gvSP.Width * 0.25);

        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_HangHoa p;
            int maSP;
            if (co)
            {
                maSP = 1;
                //maSP = Int32.Parse(cbSP.SelectedValue.ToString());
                p = bus.LayTTSP(maSP);
                txtDonGia.Text = p.DonGia.ToString();
            }


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DataRow r;
            bool KTSP = true;
            foreach (DataRow item in tbDH.Rows)
            {
                if (cbSP.SelectedValue.ToString() == item[0].ToString())
                {
                    item[2] = int.Parse(item[2].ToString()) + numSoLuong.Value;
                    KTSP = false;
                    break;
                }
            }

            if (KTSP)
            {
                r = tbDH.NewRow();
                r[0] = Int32.Parse(txtMaDH.Text.ToString());
                r[1] = Int32.Parse(cbSP.SelectedValue.ToString());
                r[2] = Convert.ToInt32(numSoLuong.Value);
                r[3] = Convert.ToInt32(txtDonGia.Text.Replace(".", ""));
                r[4] = Convert.ToInt32(numSoLuong.Value) * Convert.ToInt32(txtDonGia.Text.Replace(".", ""));
                int count = gvSP.Rows.Count;
                int i = 0;
                decimal thanhtien = 0;

                for (i = 0; i < count; i++)
                {
                    thanhtien += Decimal.Parse(r[4].ToString());
                    txtThanhTien.Text = thanhtien.ToString();
                }
                tbDH.Rows.Add(r);
                
            }
            

        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvSP.Rows.Count)
            {
                EnableBtn();
               
                txtDonGia.Text = gvSP.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbSP.SelectedValue = int.Parse(gvSP.Rows[e.RowIndex].Cells[1].Value.ToString());
                numSoLuong.Value = decimal.Parse( gvSP.Rows[e.RowIndex].Cells[2].Value.ToString());
                //Console.WriteLine(numSoLuong.Value);
            }
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            //if (bus.ThemCTDH(maDH, tbDH))
            //{
            //    MessageBox.Show("Đặt hàng thành công");
            //    Close();
            //}
            //else
            //{
            //    MessageBox.Show("Đặt hàng thất bại");
            //}

        }
    }
}
