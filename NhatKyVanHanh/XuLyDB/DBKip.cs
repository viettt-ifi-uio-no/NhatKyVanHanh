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
    class DBKip
    {
        public void updateGridData(DataGridView dataGridKip)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM Kip";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "Kip");
            dataGridKip.DataSource = ds;
            dataGridKip.DataMember = "Kip";

            dbmg.closeDatabase();
        }

        public string addNewKip(Kip kip, bool isNewKip)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string newKip = "INSERT KIP (MaKip, TenKip) "
                + " VALUES (@mK, @tK)";
            string updateKip = "UPDATE KIP SET MaKip = @mK, TenKip = @tK WHERE MaKip = @mK";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (isNewKip) cmd.CommandText = newKip;
            else cmd.CommandText = updateKip;

            cmd.Parameters.AddWithValue("@mK", kip.maKip);
            cmd.Parameters.AddWithValue("@tK", kip.tenKip);

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



        public void updateComboBoxIdOnly(ComboBox cb)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM KIP";
            SqlCommand sqlCmd = new SqlCommand(sql, con);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                cb.Items.Add(sqlReader["MaKip"].ToString() + " - " + sqlReader["TenKip"].ToString());
            }

            sqlReader.Close();

            dbmg.closeDatabase();
        }

        public int removeKIP(string kipId)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM KIP WHERE MAKIP = @mk";
            cmd.Parameters.AddWithValue("@mk", kipId);


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
