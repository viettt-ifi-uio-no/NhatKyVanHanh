using NhatKyVanHanh.AllObjects;
using NhatKyVanHanh.XuLyDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NhatKyVanHanh.GUI
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            resetFeilds();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            updateNhanVien(true);

        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            updateNhanVien(false);
            btnSuaNV.Enabled = false;
        } 

        private void btnThemKip_Click(object sender, EventArgs e)
        {
            updateKip(true);
        }

        private void updateNhanVien(bool isNewNhanVien)
        {
            if (txtMaNV.Text.Equals("") || txtTenNV.Text.Equals("") || cbKipNV.Text.Equals(""))
            {
                MessageBox.Show(this, "Mã, tên nhân viên và kíp ko hợp lệ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien nv = new NhanVien();

            nv.maNv = txtMaNV.Text;
            nv.tenNV = txtTenNV.Text;
            nv.maKip = cbKipNV.Text.Substring(0,cbKipNV.Text.IndexOf(" - "));
            nv.kipTruong = (chkKipTruong.Checked) ? "YES" : "NO";

            DBNhanVien dbnv = new DBNhanVien();

            string ret = dbnv.addNewStaf(nv, isNewNhanVien);
            if (ret.Contains("duplicate key")) MessageBox.Show(this, "TRUNG ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ret.Length > 0) MessageBox.Show(this, ret, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dbnv.updateGridData(dGNhanVien);
        }

        private void updateKip(bool isNewKip)
        {
            if (txtMaKip.Text.Equals("") || txtTenKip.Text.Equals("") )
            {
                MessageBox.Show(this, "Mã, tên kíp ko hợp lệ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kip kip = new Kip();

            kip.maKip = txtMaKip.Text;
            kip.tenKip = txtTenKip.Text;

            DBKip dbKip = new DBKip();

            string ret = dbKip.addNewKip(kip, isNewKip);
            if (ret.Contains("duplicate key")) MessageBox.Show(this, "TRUNG ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (ret.Length > 0) MessageBox.Show(this, ret, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dbKip.updateGridData(dGKip);
            resetFeilds();
        }

        void resetFeilds()
        {
            DBKip ntb = new DBKip();
            ntb.updateComboBoxIdOnly(cbKipNV);
            ntb.updateGridData(dGKip);

            DBKip dbKip = new DBKip();
            dbKip.updateGridData(dGKip);
            DBNhanVien dbnv = new DBNhanVien();
            dbnv.updateGridData(dGNhanVien);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DBNhanVien dbNV = new DBNhanVien();
            dbNV.removeNewStaf(txtMaNV.Text);
            resetFeilds();
        }

        private void btnXoaKip_Click(object sender, EventArgs e)
        {
            DBKip dbKip = new DBKip();
            dbKip.removeKIP(txtMaKip.Text);
            resetFeilds();
        }



        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;
            DataGridViewRow row = dGNhanVien.Rows[rowIndex];
            txtMaNV.Text = row.Cells[0].Value.ToString();
            foreach(var item in cbKipNV.Items)
            {
                if (item.ToString().Contains(row.Cells[1].Value.ToString()))
                {
                    cbKipNV.SelectedItem = item;
                    break;
                }
            }
            txtTenNV.Text = row.Cells[2].Value.ToString();

            if (row.Cells[3].Value.ToString().Equals("YES")){
                chkKipTruong.Checked = true;
            }else{
                chkKipTruong.Checked = false;
            }
            btnSuaNV.Enabled = true;


        }

        private void dGKip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;
            DataGridViewRow row = dGKip.Rows[rowIndex];
            txtMaKip.Text = row.Cells[0].Value.ToString();
            txtTenKip.Text = row.Cells[1].Value.ToString();
        }


    }
}
