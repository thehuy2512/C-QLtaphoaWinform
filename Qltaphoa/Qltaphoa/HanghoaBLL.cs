using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Qltaphoa
{
    class HanghoaBLL
    {
        HanghoaDAL dalHh;
        public HanghoaBLL()
        {
            dalHh = new HanghoaDAL();
        }
        public DataTable getAllHanghoa()
        {
            return dalHh.getAllHanghoa();
        }
        public bool InsertHanghoa(tblHanghoa Hh)
        {
            return dalHh.InsertHanghoa(Hh);
        }
        public bool UpdateHanghoa(tblHanghoa Hh)
        {
            return dalHh.UpdateHanghoa(Hh);
        }
        public bool DeleteHanghoa(tblHanghoa Hh)
        {
            return dalHh.DeleteHanghoa(Hh);
        }
        public DataTable FindHanghoa(string Hh)
        {
            return dalHh.FindHanghoa(Hh);
        }
        

    }
}
