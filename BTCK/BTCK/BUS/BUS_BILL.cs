using BTCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.BUS
{
    class BUS_BILL
    {
        DAO_BILL da;
        public BUS_BILL()
        {
            da = new DAO_BILL();
        }
        public void LayDSBill(DataGridView gv)
        {
            gv.DataSource = da.LayDSHD();
        }
        public void LayDSKH(ComboBox cb)
        {
            cb.DataSource = da.LayDSKH();
            cb.DisplayMember = "TenKH";
            cb.ValueMember = "MaKH";
        }
        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = da.LayDSNV();
            cb.DisplayMember = "TenNV";
            cb.ValueMember = "MaNV";
        }
        public bool ThemBill(tb_HoaDon h)
        {
            try
            {
                da.ThemHD(h);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaHD(tb_HoaDon p)
        {
            try
            {
                da.SuaHD(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaHD(tb_HoaDon p)
        {
            try
            {
                da.XoaHD(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
