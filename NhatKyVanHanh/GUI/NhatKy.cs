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
        Form NhatKyVaBaoCao;
        string caID, maKip, congviecID;
        Timer t = new Timer();

        public NhatKy(string caID, string maKip)
        {
            InitializeComponent();
            this.caID = caID;
            this.maKip = maKip;
            khoitaoform();
            
        }


        void NhatKyVaBaoCao_Closed(object sender, EventArgs e)
        {
            NhatKyVaBaoCao = null;
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
            //if (NhatKyVaBaoCao != null) return;
            //NhatKyVaBaoCao = new NhatKyVaBaoCao();
            //NhatKyVaBaoCao.Closed += NhatKyVaBaoCao_Closed;
            //NhatKyVaBaoCao.Show();
            try
            {
                string saveExcelFile = @"C:\Users\admin\Desktop\excel_report.xlsx";

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                    return;
                }
                xlApp.Visible = false;

                object misValue = System.Reflection.Missing.Value;

                Workbook wb = xlApp.Workbooks.Add(misValue);

                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                int row = 1;
                string fontName = "Times New Roman";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;
                //Xuất dòng Tiêu đề của File báo cáo: Lưu ý
                Range row1_TieuDe_ThongKeSanPham = ws.get_Range("A1", "E1");
                row1_TieuDe_ThongKeSanPham.Merge();
                row1_TieuDe_ThongKeSanPham.Font.Size = fontSizeTieuDe;
                row1_TieuDe_ThongKeSanPham.Font.Name = fontName;
                row1_TieuDe_ThongKeSanPham.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1_TieuDe_ThongKeSanPham.Value2 = "Thống kê sản phẩm";

                //Tạo Ô Số Thứ Tự (STT)
                Range row23_STT = ws.get_Range("A2", "A3");//Cột A dòng 2 và dòng 3
                row23_STT.Merge();
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "STT";

                //Tạo Ô Mã Sản phẩm :
                Range row23_MaSP = ws.get_Range("B2", "B3");//Cột B dòng 2 và dòng 3
                row23_MaSP.Merge();
                row23_MaSP.Font.Size = fontSizeTenTruong;
                row23_MaSP.Font.Name = fontName;
                row23_MaSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaSP.Value2 = "Mã Sản Phẩm";
                row23_MaSP.ColumnWidth = 20;

                //Tạo Ô Tên Sản phẩm :
                Range row23_TenSP = ws.get_Range("C2", "C3");//Cột C dòng 2 và dòng 3
                row23_TenSP.Merge();
                row23_TenSP.Font.Size = fontSizeTenTruong;
                row23_TenSP.Font.Name = fontName;
                row23_TenSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_TenSP.ColumnWidth = 20;
                row23_TenSP.Value2 = "Tên Sản Phẩm";

                //Tạo Ô Giá Sản phẩm :
                Range row2_GiaSP = ws.get_Range("D2", "E2");//Cột D->E của dòng 2
                row2_GiaSP.Merge();
                row2_GiaSP.Font.Size = fontSizeTenTruong;
                row2_GiaSP.Font.Name = fontName;
                row2_GiaSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row2_GiaSP.Value2 = "Giá Sản Phẩm";

                //Tạo Ô Giá Nhập:
                Range row3_GiaNhap = ws.get_Range("D3", "D3");//Ô D3
                row3_GiaNhap.Font.Size = fontSizeTenTruong;
                row3_GiaNhap.Font.Name = fontName;
                row3_GiaNhap.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_GiaNhap.Value2 = "Giá Nhập";
                row3_GiaNhap.ColumnWidth = 20;

                //Tạo Ô Giá Xuất:
                Range row3_GiaXuat = ws.get_Range("E3", "E3");//Ô E3
                row3_GiaXuat.Font.Size = fontSizeTenTruong;
                row3_GiaXuat.Font.Name = fontName;
                row3_GiaXuat.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row3_GiaXuat.Value2 = "Giá Xuất";
                row3_GiaXuat.ColumnWidth = 20;
                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "E3");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                int stt = 0;
                row = 3;//dữ liệu xuất bắt đầu từ dòng số 4 trong file Excel (khai báo 3 để vào vòng lặp nó ++ thành 4)
                
                for (int i = 0; i< 10; i++)
                {
                    stt++;
                    row++;
                    dynamic[] arr = {"ROWWWWWWWWWWWWW ", "ROWWWWWWWWWWWWW ", "ROWWWWWWWWWWWWW ", "ROWWWWWWWWWWWWW ", "ROWWWWWWWWWWWWW " };
                    Range rowData = ws.get_Range("A" + row, "E" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    rowData.Font.Size = fontSizeNoiDung;
                    rowData.Font.Name = fontName;
                    rowData.Value2 = arr;
                }
                //Kẻ khung toàn bộ
                BorderAround(ws.get_Range("A2", "E" + row));

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(saveExcelFile);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                //Mở File excel sau khi Xuất thành công
                System.Diagnostics.Process.Start(saveExcelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

   
       //Hàm kẻ khung cho Excel
       private void BorderAround(Range range)
       {
           Borders borders = range.Borders;
           borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
           borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
           borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
           borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
           borders.Color = Color.Black;
           borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
           borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
           borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
           borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
       }
       //Hàm thu hồi bộ nhớ cho COM Excel
       private static void releaseObject(object obj)
       {
           try
           {
               System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
               obj = null;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               obj = null;
           }
           finally
           { GC.Collect(); }
       }


    }
}
