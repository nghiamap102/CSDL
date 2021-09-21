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
    public partial class LoaiHH : Form
    {
        BUS_HH bLHH;
        public LoaiHH()
        {
            InitializeComponent();
            bLHH = new BUS_HH();
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
            if (txtTenLHH.Text.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void rsInput()
        {
            txtMaLHH.Text = "";
            txtTenLHH.Text = "";
            DisableBtn();
        }

        private void FLoaiHH_Load(object sender, EventArgs e)
        {
            txtMaLHH.Enabled = false;
            LayDSLoaiHH();
            rsInput();
        }

        void LayDSLoaiHH()
        {
            gVLoaiHH.DataSource = null;
            bLHH.LayLoaiHH(gVLoaiHH);
            gVLoaiHH.Columns[0].Width = (int)(gVLoaiHH.Width * 0.2);
            gVLoaiHH.Columns[1].Width = (int)(gVLoaiHH.Width * 0.2);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gVLoaiHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVLoaiHH.Rows.Count)
            {
                EnableBtn();
                txtMaLHH.Text = gVLoaiHH.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLHH.Text = gVLoaiHH.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if(CheckEmpty())
            {
                tb_LoaiHangHoa p = new tb_LoaiHangHoa();
                p.TenLoaiHH = txtTenLHH.Text;
                
                if(bLHH.ThemLoaiHH(p))
                {
                    MessageBox.Show("Thêm thành công");
                    LayDSLoaiHH();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Tên loại hàng hóa rỗng");
            }
            rsInput();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maLHH = int.Parse(txtMaLHH.Text);

            DialogResult result = MessageBox.Show(
               "Bạn chắc chắn có muốn xóa không?",
               "Xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                if (bLHH.XoaLoaiHH(maLHH))
                {
                    MessageBox.Show("Xóa loại sản phẩm thành công");
                    bLHH.LayLoaiHH(gVLoaiHH);
                }
            }
            else
            {
                MessageBox.Show("Xóa loại sản phẩm thất bại");
            }
            rsInput();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            tb_LoaiHangHoa p = new tb_LoaiHangHoa();
            p.MaLoaiHH = int.Parse(txtMaLHH.Text);
            p.TenLoaiHH = txtTenLHH.Text;

            if (bLHH.SuaLoaiHH(p))
            {
                MessageBox.Show("Sửa thành công");
                bLHH.LayLoaiHH(gVLoaiHH);
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            rsInput();
        }
    }
}
