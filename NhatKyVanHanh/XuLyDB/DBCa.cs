using NhatKyVanHanh.AllObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NhatKyVanHanh.XuLyDB
{
    class DBCa
    {



        public string addNewCa(Ca ca, bool isnewca)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string newca = "INSERT CA (MaCa, ThoiGian, MaKip) "
                + " VALUES (@mC, @tG, @mK)";
            string updateca = "UPDATE CA SET ThoiGian = @tG, MaKip = @mK WHERE MaCa = @mC";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (!isnewca){cmd.CommandText = newca;
            } else{cmd.CommandText = updateca; }

            cmd.Parameters.AddWithValue("@mC", ca.maCa);
            cmd.Parameters.AddWithValue("@tG", ca.thoiGian);
            cmd.Parameters.AddWithValue("@mK", ca.maKip);

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

        public bool isExisted(string caID, string maKip)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM CA WHERE MACA = '" + caID+"'";
            SqlCommand sqlCmd = new SqlCommand(sql, con);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            bool existed = false;
            while (sqlReader.Read())
            {
               existed = !sqlReader["MaKip"].ToString().Contains(maKip);
            }

            sqlReader.Close();

            dbmg.closeDatabase();

            return existed;
        }




    }
}
