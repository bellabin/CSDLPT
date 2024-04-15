using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;
using System.Data;
using NGANHANG.DTO;
using NGANHANG.Util;
using System.Text.RegularExpressions;

namespace NGANHANG
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static String ConnectionStr; 
        public static String serverName = "";
        public static String MACNHT;

        public static string DISTRIBUTOR_NAME = "DESKTOP-6RHI5LQ";
        public static string REMOTE_LOGIN = "HTKN";
        public static string REMOTE_PASS = "123456";
        public static string CONNECTION_STR_TEMPLATE = "Data Source={0};Initial Catalog=NGANHANG;{1}";
        public static String connstrPublisher = "Data Source=DESKTOP-6RHI5LQ;Initial Catalog=NGANHANG;Integrated Security=true";
        public static BindingSource bindingSource = new BindingSource();
        public static String mlogin = "";
        public static String password = "";

        public static frmMain frmChinh;

        public static void SetServerToSubcriber(string subcriber, string loginName, string pass)
        {
            serverName = subcriber;
            ConnectionStr = string.Format(CONNECTION_STR_TEMPLATE, serverName, $"User ID={loginName};password={pass}");


        }

        public static bool CheckConnection()
        {

            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.conn.ConnectionString = ConnectionStr;
                Program.conn.Open();
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nXem lại tài khoản và mật khẩu.\n " + e.Message, "", MessageBoxButtons.OK);
                //Console.WriteLine(e.Message);
                return false;
            }

        }

        public static User Login(string loginName)
        {
            SqlDataReader dataReader = Program.ExecuteSqlDataReader($"EXEC dbo.sp_Login '{loginName}'");
            if (dataReader == null)
                return null;

            if (!dataReader.Read())
            {
                MessageUtil.ShowInfoMsgDialog("Login bạn nhập không có quyền truy cập dữ liệu.\nVui lòng nhập lại mã nhân viên.");
                return null;
            }
            User user = new User(dataReader);
            dataReader.Close();
            return user;
        }

        public static int kiemTraNhanVienTonTai(string NhanVienID)
        {
            return (int)Program.ExecSqlCheck("sp_KiemTraNhanVien", NhanVienID);

        }

        public static int kiemTraCMNDTonTai(string CMND)
        {
            return (int)Program.ExecSqlCheck("sp_KiemTraCMND", CMND);

        }

        public static int kiemTraKhachHangTonTai(string CMND)
        {
            return (int)Program.ExecSqlCheck("sp_KiemTraKhachHang", CMND);

        }

        public static int ExecSqlCheck(String tenSP, String a)
        {
            String sql = $"DECLARE @return_value int EXEC @return_value = [dbo].[{tenSP}] @a SELECT 'Return Value' = @return_value";

            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if (conn.State == ConnectionState.Closed) conn.Open();
            sqlCommand.Parameters.AddWithValue("@a", a);
            SqlDataReader dataReader = null;
            try
            {
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                int result_value = int.Parse(dataReader.GetValue(0).ToString());
                conn.Close();
                return result_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return -1;
            }
        }


        public static SqlDataReader ExecuteSqlDataReader(string query)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = new SqlConnection(ConnectionStr),
                CommandText = query,
                CommandType = CommandType.Text
            };

            SqlDataReader sqlDataReader;
            try
            {
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi kết nối cơ sở dữ liệu.\nKiểm tra lại tên đăng nhập và mật khẩu.\nChi tiết lỗi: {ex.Message}");
                return null;
            }
        }

        public static int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int rowsAffected = -1;

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandTimeout = 600, // 10 mins
                };

                if (parameters != null)
                {
                    int i = 0;
                    foreach (string item in Regex.Split(query, @"\s+"))
                    {
                        if (item.Contains("@"))
                        {
                            int id = item.IndexOf(',');
                            if (id > 0)
                                command.Parameters.AddWithValue(item.Remove(id), parameters[i]);
                            else
                                command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                    rowsAffected = -2;
                }
            }

            return rowsAffected;
        }

        public static string LayChiNhanhHT()
        {
            SqlDataReader dataReader = Program.ExecuteSqlDataReader($"EXEC sp_LayChiNhanhHienTai");
            dataReader.Read();
            return dataReader.GetValue(0).ToString();
        }



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.frmChinh = new frmMain();
            Application.Run(frmChinh);
        }
    }
}
