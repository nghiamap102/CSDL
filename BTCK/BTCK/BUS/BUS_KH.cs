using BTCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.BUS
{
    class BUS_KH
    {
        DAO_KH da;
        public BUS_KH()
        {
            da = new DAO_KH();
        }
        public void LayDSKH(DataGridView gv)
        {
            gv.DataSource = da.LayDSKH();
        }
        public bool ThemKH(tb_KhachHang p)
        {
            try
            {
                da.ThemKH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaKH(tb_KhachHang p)
        {
            try
            {
                da.SuaKH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaKH(tb_KhachHang p)
        {
            try
            {
                da.XoaKH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
