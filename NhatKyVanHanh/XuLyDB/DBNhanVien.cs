using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhatKyVanHanh.AllObjects;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;

namespace NhatKyVanHanh.XuLyDB
{
    class DBNhanVien
    {
        public void updateGridData(DataGridView dataGridNV)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM NhanVien";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "NhanVien");
            dataGridNV.DataSource = ds;
            dataGridNV.DataMember = "NhanVien";

            dbmg.closeDatabase();
        }

        public string addNewStaf(NhanVien nv, bool isNewNhanVien)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string newNhanVien = "INSERT NHANVIEN (Id, MaKip, TenNhanVien, KipTruong) "
                + " VALUES (@maNV, @maKip, @tenNV, @KT)";
            string updateNhanVien = "UPDATE NHANVIEN SET Id = @maNV, TenNhanVien = @tenNV, maKip = @maKip, KipTruong = @KT WHERE Id = @maNV";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (isNewNhanVien) cmd.CommandText = newNhanVien;
            else cmd.CommandText = updateNhanVien;

            cmd.Parameters.AddWithValue("@maNv", nv.maNv);
            cmd.Parameters.AddWithValue("@tenNv", nv.tenNV);
            cmd.Parameters.AddWithValue("@maKip", nv.maKip);
            cmd.Parameters.AddWithValue("@KT", nv.kipTruong);

            string ret = "";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("The product name is " + e.Message);
                ret = e.Message;
            }

            dbmg.closeDatabase();
            return ret;
        }


        public int removeNewStaf(string nv)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM NHANVIEN WHERE Id = @maNv";
            cmd.Parameters.AddWithValue("@maNv", nv);


            int ret = -1;

            try
            {
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("The product name is " + e.Message);
            }

            dbmg.closeDatabase();

            return (ret > 0) ? ret : -1;
        }
    }
}
