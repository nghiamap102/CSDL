using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.BUS
{
    class BUS_CTHD
    {
        DAO.DAO_CTHD da;
        public BUS_CTHD()
        {
            da = new DAO.DAO_CTHD();
        }
        public void LayDSCTDH(DataGridView gv, int maDH)
        {
            gv.DataSource = da.DSCTDH(maDH);
        }
        public void LayDSSP(ComboBox cb)
        {
            cb.DataSource = da.LayDSSP();
            cb.DisplayMember = "TenHang";
            cb.ValueMember = "MaHang";
        }
        public void LayDSLoaiHH(ComboBox cb)
        {
            cb.DataSource = da.LayDSLoaiHH();
            cb.DisplayMember = "TenLoaiHH";
            cb.ValueMember = "MaLoaiHH";
        }
        public tb_HangHoa LayTTSP(int maSP)
        {
            return da.LayTTSP(maSP);
        }
        public bool ThemCTHD(tb_CTHD p)
        {
            try
            {
                da.ThemCTDH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaCTHD(tb_CTHD p)
        {
            try
            {
                da.SuaCTHD(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaCTHD(tb_CTHD p)
        {
            try
            {
                da.XoaCTHD(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
