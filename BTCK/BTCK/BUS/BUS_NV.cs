using BTCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.BUS
{
    class BUS_NV
    {
        DAO_NV da;
        public BUS_NV()
        {
            da = new DAO_NV();
        }
        public void LayDSNV(DataGridView gv)
        {
            gv.DataSource = da.LayDSNV();
        }
        public bool ThemSP(tb_NhanVien p)
        {
            try
            {
                da.ThemSP(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaSP(tb_NhanVien p)
        {
            try
            {
                da.SuaSP(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaSP(tb_NhanVien p)
        {
            try
            {
                da.XoaSP(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
