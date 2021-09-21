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
        public bool ThemNV(tb_NhanVien p)
        {
            try
            {
                da.ThemNV(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaNV(tb_NhanVien p)
        {
            try
            {
                da.SuaNV(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaNV(tb_NhanVien p)
        {
            try
            {
                da.XoaNV(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ResetPassưord(tb_NhanVien p)
        {
            try
            {
                da.ResetPassword(p);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
