﻿using BTCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCK.BUS
{
    class BUS_HH
    {
        DAO_HH da;
        public BUS_HH()
        {
            da = new DAO_HH();
        }
        public void LayDSHH(DataGridView gv)
        {
            gv.DataSource = da.LayDSHH();
        }
        public void LayLoaiHH(ComboBox cb)
        {
            cb.DataSource = da.LayLoaiHH();
            cb.DisplayMember = "TenLoaiHH";
            cb.ValueMember = "MaLoaiHH";
        }
        public bool ThemHH(tb_HangHoa h)
        {
            try 
            {
                da.ThemHH(h);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaHH(tb_HangHoa p)
        {
            try
            {
                da.SuaHH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaHH(tb_HangHoa p)
        {
            try
            {
                da.XoaHH(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
