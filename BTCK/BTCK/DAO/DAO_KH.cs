using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCK.DAO
{
    class DAO_KH
    {
        QuanLyBanNuocHoaEntities db;
        public DAO_KH()
        {
            db = new QuanLyBanNuocHoaEntities();
        }
        public dynamic LayDSKH()
        {
            var ds = db.tb_KhachHang.Select(s => new {
                s.MaKH,
                s.TenKH,
                s.GioiTinh,
                s.NamSinh,
                s.SDT,
                s.DiaChi,
                s.Email
            }).ToList();
            return ds;
        }
        public void ThemKH(tb_KhachHang p)
        {
            db.tb_KhachHang.Add(p);
            db.SaveChanges();
        }
        public void SuaKH(tb_KhachHang d)
        {
            tb_KhachHang o = db.tb_KhachHang.Find(d.MaKH);
            o.TenKH = d.TenKH;
            o.NamSinh = d.NamSinh;
            o.GioiTinh = d.GioiTinh;
            o.DiaChi = d.DiaChi;
            o.SDT = d.SDT;
            o.Email = d.Email;

            db.SaveChanges();
        }
        public void XoaKH(tb_KhachHang o)
        {
            tb_KhachHang d = db.tb_KhachHang.Find(o.MaKH);
            db.tb_KhachHang.Remove(d);
            db.SaveChanges();
        }
    }
}
