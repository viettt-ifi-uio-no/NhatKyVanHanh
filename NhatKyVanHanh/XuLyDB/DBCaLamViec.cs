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
    class DBCaLamViec
    {
        public string addNewCaLamViec(CaLamViec caLV, bool isnewCaLV)
        {
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string newca = "INSERT CALAMVIEC (MaNv, MaCa, ThinhTrang, GhiChu) "
                + " VALUES (@mNv, @mC, @tinhTrang, @ghiChu)";
            string updateca = "UPDATE CALAMVIEC SET MaNv = @mNv, MaCa = @mC, ThinhTrang = @tinhTrang, GhiChu = @ghiChu WHERE MaNv = @mNv";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            if (!isnewCaLV)
            {
                cmd.CommandText = newca;
            }
            else { cmd.CommandText = updateca; }

            cmd.Parameters.AddWithValue("@mC", caLV.maNV);
            cmd.Parameters.AddWithValue("@tG", caLV.maCa);
            cmd.Parameters.AddWithValue("@mK", caLV.tinhTrang);
            cmd.Parameters.AddWithValue("@mK", caLV.ghiChu);

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
    }
}
