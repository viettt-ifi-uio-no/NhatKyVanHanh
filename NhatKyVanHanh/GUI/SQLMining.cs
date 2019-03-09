using NhatKyVanHanh.XuLyDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NhatKyVanHanh.GUI
{
    public partial class SQLMining : Form
    {
        public SQLMining()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if(txtQueryString.Text.ToLower().Contains("drop") ||
                txtQueryString.Text.ToLower().Contains("insert") ||
                txtQueryString.Text.ToLower().Contains("delete") ||
                txtQueryString.Text.ToLower().Contains("alter"))
            {
                MessageBox.Show(this, "VUI LONG KHONG THAY DOI CO SO DU LIEU", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = txtQueryString.Text;
            
            try
            {
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                dataadapter.Fill(ds);
                dGridRawData.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("CANNOT EXE CUTE SELECT " + ex.Message);
            }

            dbmg.closeDatabase();
        }
    }
}
