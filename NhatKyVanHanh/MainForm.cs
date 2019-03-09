using NhatKyVanHanh.AllObjects;
using NhatKyVanHanh.GUI;
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

namespace NhatKyVanHanh
{
    public partial class MainForm : Form
    {
        SQLMining sqlMining;
        Form User, nhatKy;
        Timer t = new Timer();
        string thucHienCaID;

        public MainForm()
        {
            InitializeComponent();
            DBKetNoi xldb = new DBKetNoi();
            xldb.CreateDatabaseIfNotExisted();
            initMain();
        }

        private void btnRawQuery_Click(object sender, EventArgs e)
        {
            if (sqlMining != null) return;
            sqlMining = new SQLMining();
            sqlMining.Closed += sqlMining_Closed;
            sqlMining.Show();
        }

        void sqlMining_Closed(object sender, EventArgs e)
        {
            sqlMining = null;
        }



        void User_Closed(object sender, EventArgs e)
        {
            User = null;
        }

        void nhatKy_Closed(object sender, EventArgs e)
        {
            nhatKy = null;
        }


        private void btnNV_Click(object sender, EventArgs e)
        {
            if (User != null) return;
            User = new User();
            User.Closed += User_Closed;
            User.Show();
        }


        private void btnVaoCa_Click(object sender, EventArgs e)
        {
            //KHOI TAO THC VA LUU TRU

            if (nhatKy != null || thucHienCaID == null) return;
            Ca ca = new Ca();
            ca.maCa = thucHienCaID;
            ca.thoiGian = "" + DateTime.Now;
            ca.maKip = cbKip.Text.Substring(0, cbKip.Text.IndexOf(" - "));

            DBCa dbCa = new DBCa();
            bool isUpdate = false;
            if (dbCa.isExisted(ca.maCa, ca.maKip))
            {
                DialogResult dlr = MessageBox.Show("Bạn có muon doi kip?", "IceTea Việt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;
                isUpdate = true;
            }

            dbCa.addNewCa(ca,isUpdate);
            nhatKy = new NhatKy(thucHienCaID, ca.maKip);
            nhatKy.Closed += nhatKy_Closed;
            nhatKy.Show();
        }

        private void cbKip_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVaoCa.Enabled = true;
        }

        private void initMain()
        {

            t.Interval = 1000;  //in milliseconds
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();  //this will use t_Tick() method

            thucHienCaID = "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + ((DateTime.Now.Hour < 19) ? "S" : "C");

            DBKip ntb = new DBKip();
            ntb.updateComboBoxIdOnly(cbKip);

            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            string sql = "SELECT * FROM NhanVien ORDER BY MAKIP ";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            dataadapter.Fill(ds, "NhanVien");
            dGCaKip.DataSource = ds;
            dGCaKip.DataMember = "NhanVien";

            dbmg.closeDatabase();

        }
        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            string time = ""+ DateTime.Now;
            //update label
            lblClock.Text = time;
        }

    }
}
