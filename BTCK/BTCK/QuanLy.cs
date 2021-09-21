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
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void quảnLíSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHH a = new QLHH();
            a.MdiParent = this;
            a.StartPosition = FormStartPosition.CenterScreen;
            a.Show();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }

        private void quanLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNV f = new QLNV();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }

        private void quảnLýLoạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHH f = new LoaiHH();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }
    }
}
