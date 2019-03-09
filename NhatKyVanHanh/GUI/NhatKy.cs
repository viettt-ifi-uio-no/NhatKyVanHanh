using Microsoft.Office.Interop.Excel;
using NhatKyVanHanh.AllObjects;
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
    public partial class NhatKy : Form

    {
        Form report;
        string caID, maKip, congviecID;
        Timer t = new Timer();

        public NhatKy(string caID, string maKip)
        {
            InitializeComponent();
            this.caID = caID;
            this.maKip = maKip;
            khoitaoform();
            
        }


        void report_Closed(object sender, EventArgs e)
        {
            report = null;
        }



        private void btnAddCV_Click(object sender, EventArgs e)
        {
            updateCongViec(true);
           
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            updateCongViec(false);
            btnSuaCV.Enabled = false;
        }


        private void updateCongViec(bool isNewCongViec)
        {
            if (txtCongViec.Text.Equals("") )
            {
                MessageBox.Show(this, "Chưa điền nội dung Cong Việc");
                return;
            }

            CongViec cv = new CongViec();

            if (isNewCongViec) cv.maCV = "" + DateTime.Now;
            else cv.maCV = this.congviecID;
            cv.maCa = this.caID;
            cv.moTaCV = txtCongViec.Text;
            cv.xuLyCV = txtXuLy.Text;
            cv.deXuat = txtDeXuat.Text;
            cv.ghiChu = txtGhiChu.Text;

            DBCongViec dbnv = new DBCongViec();

            string ret = dbnv.addNewCV(cv, isNewCongViec);
            if (ret.Contains("duplicate key")) MessageBox.Show(this, "TRUNG ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ret.Length > 0) MessageBox.Show(this, ret, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dbnv.updateGridData(dGCongViec,cv.maCa);
        }

        private void khoitaoform(){
            lblCaID.Text = this.caID;
            lblKipThucHien.Text = this.maKip;
            t.Interval = 1000;  //in milliseconds
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();  //this will use t_Tick() method

            khoitaoListNV();
            DBCongViec dbnv = new DBCongViec();
            dbnv.updateGridData(dGCongViec, this.caID);

            txtCongViec.Text = "";
            txtXuLy.Text = "";
            txtDeXuat.Text = "";
            txtGhiChu.Text = "";

        }


        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            string time = "" + DateTime.Now;
            //update label
            lblClock.Text = time;
        }

        private void dGCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;
            DataGridViewRow row = dGCongViec.Rows[rowIndex];
            this.congviecID = row.Cells[0].Value.ToString();
            txtCongViec.Text = row.Cells[2].Value.ToString();
            txtXuLy.Text = row.Cells[3].Value.ToString();
            txtDeXuat.Text = row.Cells[4].Value.ToString();
            txtGhiChu.Text = row.Cells[5].Value.ToString();

            btnSuaCV.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DBCongViec dbCV = new DBCongViec();
            dbCV.removeCV(this.congviecID);
            btnXoa.Enabled = false;
            khoitaoform();
        }

        private void khoitaoListNV()
        {
            
            DBKetNoi.initializeInstance();
            DBKetNoi dbmg = DBKetNoi.getInstance();
            SqlConnection con = dbmg.openDatabase();

            SqlDataAdapter ada = new SqlDataAdapter("select * from NHANVIEN Where MaKip = '"+this.maKip+"'", con);
            System.Data.DataTable dt = new System.Data.DataTable();
            ada.Fill(dt);

            lsThanhVien.Clear();
            lsThanhVien.View = View.Details;
            lsThanhVien.Columns.Add("Kíp ID");
            lsThanhVien.Columns.Add("Id");
            lsThanhVien.Columns.Add("Tên");
            lsThanhVien.Columns.Add("Kíp trưởng");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ListViewItem listitem = new ListViewItem( new[] { dr["MaKip"].ToString(), dr["Id"].ToString(), dr["TenNhanVien"].ToString(), dr["KipTruong"].ToString() } );
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["MaKip"].ToString());
                listitem.SubItems.Add(dr["Id"].ToString());
                listitem.SubItems.Add(dr["TenNhanVien"].ToString());
                listitem.SubItems.Add(dr["KipTruong"].ToString());

                lsThanhVien.Items.Add(listitem);
            }

            dbmg.closeDatabase();

        }

        private void btnXemNhatKy_Click(object sender, EventArgs e)
        {
            if (report != null) return;
            report = new report();
            report.Closed += report_Closed;
            report.Show();

        }





    }
}
