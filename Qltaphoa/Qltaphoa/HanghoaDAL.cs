using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Qltaphoa
{
    class HanghoaDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public HanghoaDAL()
        {
            dc = new DataConnection();

        }
        public DataTable getAllHanghoa()
        {   // tao cau lenh lay toan bo hang hoa
            string sql = "SELECT * FROM tblHanghoa";
            // tao mot ket noi den sql
            SqlConnection con = dc.getConnect();
            // khoi toa doi tuong cho sql adapter
            da = new SqlDataAdapter(sql, con);
            //mở kết nối
            con.Open();
            // đổ dữ liệu từ sqlAdapter vao DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //đóng kết nối
            con.Close();
            return dt;
        }
        public bool InsertHanghoa(tblHanghoa Hh)
        {
            string sql = "INSERT INTO tblHanghoa(Mahang, Tenhang, Loaihang, Dongia, Soluong) VALUES(@Mahang, @Tenhang, @Loaihang, @Dongia, @Soluong)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar).Value = Hh.Mahang;
                cmd.Parameters.Add("@Tenhang", SqlDbType.NVarChar).Value = Hh.Tenhang;
                cmd.Parameters.Add("@Loaihang", SqlDbType.NVarChar).Value = Hh.Loaihang;
                cmd.Parameters.Add("@Dongia", SqlDbType.Int).Value = Hh.Dongia;
                cmd.Parameters.Add("@Soluong", SqlDbType.Int).Value = Hh.Soluong;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateHanghoa(tblHanghoa Hh)
        {
            string sql = "UPDATE tblHanghoa SET Mahang=@Mahang, Tenhang=@Tenhang, Loaihang=@Loaihang, Dongia=@Dongia, @Soluong=@Soluong WHERE Id=@Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Hh.Id;
                cmd.Parameters.Add("@Mahang", SqlDbType.NVarChar).Value = Hh.Mahang;
                cmd.Parameters.Add("@Tenhang", SqlDbType.NVarChar).Value = Hh.Tenhang;
                cmd.Parameters.Add("@Loaihang", SqlDbType.NVarChar).Value = Hh.Loaihang;
                cmd.Parameters.Add("@Dongia", SqlDbType.Int).Value = Hh.Dongia;
                cmd.Parameters.Add("@Soluong", SqlDbType.Int).Value = Hh.Soluong;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public bool DeleteHanghoa(tblHanghoa Hh)
        {
            string sql = "DELETE tblHanghoa WHERE Id=@Id";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Hh.Id;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }
        public DataTable FindHanghoa(string Hh)
        {
            string sql = "SELECT * FROM tblHanghoa WHERE Tenhang like N'%"+Hh+"%' or Loaihang like N'%"+Hh+"%' ";
            SqlConnection con = dc.getConnect();
            // khoi toa doi tuong cho sql adapter
            da = new SqlDataAdapter(sql, con);
            //mở kết nối
            con.Open();
            // đổ dữ liệu từ sqlAdapter vao DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //đóng kết nối
            con.Close();
            return dt;
        }
        
    }
}
