using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCK.DAO
{
    class DAO_BILL
    {
        QuanLyBanNuocHoaEntities1 db;
        public DAO_BILL()
        {
            db = new QuanLyBanNuocHoaEntities1();
        }
        public dynamic LayDSHD()
        {
            var ds = db.tb_HoaDon.Select(s => new
            {
                s.MaHD,
                s.NgayLap,
                s.KhachHang,
                s.NguoiLap,
            }).ToList();

            return ds;
        }
        public dynamic LayDSKH()
        {
            var ds = db.tb_KhachHang.Select(s => new
            {
                s.TenKH,
                s.MaKH
            }).ToList();
            return ds;
        }
        public dynamic LayDSNV()
        {
            var ds = db.tb_NhanVien.Select(s => new
            {
                s.TenNV,
                s.MaNV
            }).ToList();
            return ds;
        }
        public void ThemHD(tb_HoaDon h)
        {
            db.tb_HoaDon.Add(h);
            db.SaveChanges();
        }
        public void SuaHD(tb_HoaDon d)
        {
            tb_HoaDon o = db.tb_HoaDon.Find(d.MaHD);
            o.NguoiLap = d.NguoiLap;
            o.NgayLap = d.NgayLap;
            o.KhachHang = d.KhachHang;

            db.SaveChanges();
        }
        public void XoaHD(tb_HoaDon o)
        {
            tb_HoaDon d = db.tb_HoaDon.Find(o.MaHD);
            db.tb_HoaDon.Remove(d);
            db.SaveChanges();
        }
    }
}
