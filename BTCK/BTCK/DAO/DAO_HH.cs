using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCK.DAO
{
    class DAO_HH
    {
        QuanLyBanNuocHoaEntities db;
        public DAO_HH()
        {
            db = new QuanLyBanNuocHoaEntities();
        }
        public dynamic LayDSHH()
        {
            var ds = db.tb_HangHoa.Select(s => new
            {
                s.MaHang,
                s.TenHang,
                s.SoLuong,
                s.DonGia,
                s.LoaiHangHoa
            }).ToList();

            return ds;
        }
        public dynamic LayLoaiHH()
        {
            var ds = db.tb_LoaiHangHoa.Select(s => new
            {
                s.MaLoaiHH,
                s.TenLoaiHH
            }).ToList();
            return ds;
        }
        public void ThemHH(tb_HangHoa h)
        {
            db.tb_HangHoa.Add(h);
            db.SaveChanges();
        }
        public void SuaHH(tb_HangHoa d)
        {
            tb_HangHoa o = db.tb_HangHoa.Find(d.MaHang);
            o.TenHang = d.TenHang;
            o.LoaiHangHoa = d.LoaiHangHoa;
            o.DonGia = d.DonGia; 
            o.SoLuong = d.SoLuong;

            db.SaveChanges();
        }
        public void XoaHH(tb_HangHoa o)
        {
            tb_HangHoa d = db.tb_HangHoa.Find(o.MaHang);
            db.tb_HangHoa.Remove(d);
            db.SaveChanges();
        }
    }
}
