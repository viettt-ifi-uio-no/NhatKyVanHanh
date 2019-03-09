using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhatKyVanHanh.XuLyDB
{
    class DBKetNoi
    {
        private int mOpenCounter;
        private static DBKetNoi instance;
        private static SqlConnection mDatabase;
        private static System.Object lockThis = new System.Object();
        public string CONNSTR = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = NhatKyVanHanhIT; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\itcrtc.mdf;Integrated Security=True";



        public bool CreateDatabaseIfNotExisted()
        {
            string CONNSTRDB = "Data Source=(localdb)\\MSSQLLocalDB; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(CONNSTRDB);
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            GrantAccess(appPath); //Need to assign the permission for current application to allow create database on server (if you are in domain).
            bool IsExits = CheckDatabaseExists(connection, "NhatKyVanHanhIT"); //Check database exists in sql server.
            if (!IsExits)
            {
                Debug.WriteLine("==================TAO MOI DB ==============" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));


                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    command.CommandText = "CREATE DATABASE NhatKyVanHanhIT; ";
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("Please Check.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Debug.WriteLine("============ ATTACH DB FILE  =============" + ex.Message);
                    SqlCommand cmd = new SqlCommand("sp_attach_db");
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dbname", "NhatKyVanHanhIT");
                    cmd.Parameters.AddWithValue("@filename1", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\NhatKyVanHanhIT.mdf");
                    cmd.ExecuteNonQuery();

                    return false;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                SqlConnection conn = new SqlConnection(CONNSTR);
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    command.CommandText = createTableQueries();
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("Please Check.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Debug.WriteLine("============ KO TAO DB TABLES ====================" + ex.Message);
                    return false;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

                return true;
            }
            Debug.WriteLine("============ DA CO DB ====================" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            return false;
        }

        public static bool GrantAccess(string fullPath)
        {
            DirectoryInfo info = new DirectoryInfo(fullPath);
            WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
            DirectorySecurity ds = info.GetAccessControl();
            ds.AddAccessRule(new FileSystemAccessRule(self.Name,
            FileSystemRights.FullControl,
            InheritanceFlags.ObjectInherit |
            InheritanceFlags.ContainerInherit,
            PropagationFlags.None,
            AccessControlType.Allow));
            info.SetAccessControl(ds);
            return true;
        }

        public static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    result = (databaseID > 0);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        public static void initializeInstance()
        {
            lock (lockThis)
            {
                if (instance == null)
                {
                    instance = new DBKetNoi();
                }
            }
        }

        public static DBKetNoi getInstance()
        {
            lock (lockThis)
            {
                if (instance == null)
                {
                    throw new System.InvalidOperationException("DB is not initialized, call initializeInstance(..) to initialize instance.");
                }
            }
            return instance;
        }

        public SqlConnection openDatabase()
        {
            lock (lockThis)
            {
                mOpenCounter++;
                //If it is the first time
                if (mOpenCounter == 1)
                {
                    mDatabase = new SqlConnection(CONNSTR);
                    mDatabase.Open();
                }
            }
            //else just return the opened instance
            return mDatabase;
        }

        public void closeDatabase()
        {
            //We do not want to close the DB while the other use it
            lock (lockThis)
            {
                mOpenCounter--;
                if (mOpenCounter == 0)
                {
                    //REAL CLOSE
                    mDatabase.Close();
                    mDatabase = null;
                }
            }
        }

        private string createTableQueries()
        {

            string kip = "CREATE TABLE Kip ( [MaKip]  NVARCHAR(50) NOT NULL, [TenKip] NVARCHAR(50) NOT NULL, PRIMARY KEY CLUSTERED ([MaKip] ASC)); ";
            string nhanvien = "CREATE TABLE NhanVien(" +
                                   "[Id]          NVARCHAR(50) NOT NULL," +
                                   "[MaKip]       NVARCHAR(50) NOT NULL," +
                                   "[TenNhanVien] NVARCHAR(50) NOT NULL," +
                                   "[KipTruong]   NVARCHAR(50) NULL," +
                                   "PRIMARY KEY CLUSTERED([Id] ASC)," +
                                   "CONSTRAINT[FK_NhanVien_Kip] FOREIGN KEY ([MaKip]) REFERENCES Kip ([MaKip])); ";
            string ca = "CREATE TABLE Ca (" +
                                "[MaCa]     NVARCHAR(50) NOT NULL," +
                                "[TenCa]    NVARCHAR(50) NULL," +
                                "[ThoiGian] NVARCHAR(50) NULL," +
                                "[SlgBoDam] INT NULL," +
                                "[MaKip]    NVARCHAR(50) NOT NULL," +
                                "PRIMARY KEY CLUSTERED([MaCa] ASC)," +
                                "CONSTRAINT[FK_Ca_Kip] FOREIGN KEY([MaKip]) REFERENCES Kip ([MaKip])); ";
            string congviec = "CREATE TABLE CongViec (" +
                                 "[MaCV]   NVARCHAR(50)  NOT NULL," +
                                 "[MaCa]   NVARCHAR(50)  NOT NULL," +
                                 "[MoTaCV] NVARCHAR(MAX) NULL," +
                                 "[XuLyCV] NVARCHAR(MAX) NULL," +
                                 "[DeXuat] NVARCHAR(MAX) NULL," +
                                 "[GhiChu] NVARCHAR(MAX) NULL," +
                                 "PRIMARY KEY CLUSTERED([MaCV] ASC)," +
                                 "CONSTRAINT[FK_CongViec_Ca] FOREIGN KEY([MaCa]) REFERENCES Ca ([MaCa])); ";
            string calamviec = "CREATE TABLE CaLamViec (" +
                                 "[MaNv]      NVARCHAR(50)  NOT NULL," +
                                 "[MaCa]      NVARCHAR(50)  NOT NULL," +
                                 "[TinhTrang] NVARCHAR(50)  NOT NULL," +
                                 "[GhiChu]    NVARCHAR(MAX) NULL," +
                                 "PRIMARY KEY CLUSTERED([MaCa] ASC, [MaNv] ASC)," +
                                 "CONSTRAINT[FK_CaLamViec_NhanVien] FOREIGN KEY([MaNv]) REFERENCES NhanVien ([Id])," +
                                 "CONSTRAINT[FK_CaLamViec_Ca] FOREIGN KEY([MaCa]) REFERENCES Ca ([MaCa])); ";
            return kip + nhanvien + ca + congviec + calamviec;
        }

    }
}
