using NhatKyVanHanh.AllObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NhatKyVanHanh.XuLyDB
{
    class DBCongViec
    {

        public string addNewCV(CongViec nv, bool isNewNCV)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string newCongViec = "INSERT CONGVIEC (MaCV, MaCa, MoTaCV, XulyCV, DeXuat, GhiChu)"
                + " VALUES (@maCV, @maCa, @motaCV, @xuLyCV, @deXuat, @ghiChu)";
            string updateCongViec = "UPDATE CONGVIEC SET MaCV = @maCV, MaCa = @maCa, MoTaCV = @motaCV, XulyCV = @xuLyCV "
                + ", DeXuat = @deXuat, GhiChu = @ghiChu WHERE MaCV = @maCV";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (isNewNCV) cmd.CommandText = newCongViec;
            else cmd.CommandText = updateCongViec;

            cmd.Parameters.AddWithValue("@maCV", nv.maCV);
            cmd.Parameters.AddWithValue("@maCa", nv.maCa);
            cmd.Parameters.AddWithValue("@motaCV", nv.moTaCV);
            cmd.Parameters.AddWithValue("@xuLyCV", nv.xuLyCV);
            cmd.Parameters.AddWithValue("@deXuat", nv.deXuat);
            cmd.Parameters.AddWithValue("@ghiChu", nv.ghiChu);



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

        public void updateGridData(DataGridView dataGridNV, string caID)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM CONGVIEC WHERE MACA = '"+caID+"'";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "CONGVIEC");
            dataGridNV.DataSource = ds;
            dataGridNV.DataMember = "CONGVIEC";

            dbmg.closeDatabase();
        }

        public int removeCV(string maCV)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM CongViec WHERE MaCV = @mcv";
            cmd.Parameters.AddWithValue("@mcv", maCV);


            int ret = -1;

            try
            {
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("--------------> " + e.Message);
            }

            dbmg.closeDatabase();

            return (ret > 0) ? ret : -1;
        }


    }
}
