using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCK.DAO
{
    class DAO_NV
    {
        QuanLyBanNuocHoaEntities db; 
        public DAO_NV()
        {
            db = new QuanLyBanNuocHoaEntities();
        }
        public dynamic LayDSNV()
        {
            var ds = db.tb_NhanVien.Select(s => new {
              s.MaNV,
            s.TenNV,
              s.GioiTinh,
                s.NamSinh,
                s.DiaChi,
                s.SDT,
                s.MatKhau
            }).ToList();
            return ds;
        }
        public void ThemSP(tb_NhanVien p)
        {
            db.tb_NhanVien.Add(p);
            db.SaveChanges();
        }
        public void SuaSP(tb_NhanVien d)
        {
            tb_NhanVien o = db.tb_NhanVien.Find(d.MaNV);
            o.TenNV = d.TenNV;
            o.NamSinh = d.NamSinh;
            o.GioiTinh = d.GioiTinh;
            o.DiaChi = d.DiaChi;
            o.SDT = d.SDT;
            o.MatKhau = d.MatKhau;

            db.SaveChanges();
        }
        public void XoaSP(tb_NhanVien o)
        {
            tb_NhanVien d = db.tb_NhanVien.Find(o.MaNV);
            db.tb_NhanVien.Remove(d);
            db.SaveChanges();
        }
    }
}
