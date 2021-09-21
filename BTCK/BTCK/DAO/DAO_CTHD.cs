using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.DAO
{
    class DAO_CTHD
    {
        QuanLyBanNuocHoaEntities1 db;
        public DAO_CTHD()
        {
            db = new QuanLyBanNuocHoaEntities1();
        }
        public dynamic LayDSSP()
        {
            var ds = db.tb_HangHoa.Select(s => new { s.MaHang,s.TenHang}).ToList();
            return ds;
        }
        public dynamic LayDSLoaiHH()
        {
            var ds = db.tb_LoaiHangHoa.Select(s => new { s.MaLoaiHH, s.TenLoaiHH }).ToList();
            return ds;
        }
        public dynamic LayTTSP(int maSP)
        {
            var ds = db.tb_HangHoa.Where(s => s.MaHang == maSP).FirstOrDefault();
            return ds;
        }
        public dynamic DSCTDH(int maDH)
        {
            var ds = db.tb_CTHD.Where(s => s.MaHD == maDH).Select(s => new {
                s.MaHD,
                s.MaHH,
                s.SoLuong,
                s.DonGia,

            }).ToList();
            return ds;
        }
       
        public void ThemCTDH(tb_CTHD o)
        {

            db.tb_CTHD.Add(o);
            db.SaveChanges();
        }
        public void ThemCTHD(tb_CTHD p)
        {
            db.tb_CTHD.Add(p);
            db.SaveChanges();
        }
        public void SuaCTHD(tb_CTHD d)
        {
            tb_CTHD o = db.tb_CTHD.Find(d.MaHD);
            o.DonGia = d.DonGia;
            o.SoLuong = d.SoLuong;
            o.MaHH = d.MaHH;
            db.SaveChanges();
        }
        public void XoaCTHD(tb_CTHD o)
        {
            tb_CTHD d = db.tb_CTHD.Find(o.MaHD);
            db.tb_CTHD.Remove(d);
            db.SaveChanges();
        }
    }
}
