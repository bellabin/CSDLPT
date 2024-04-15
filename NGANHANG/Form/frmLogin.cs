using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using NGANHANG.Util;
using NGANHANG.DTO;

namespace NGANHANG.Form
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection connPublisher = new SqlConnection();
        private Action changeUserInfo;
        public Action ChangeUserInfo { get => changeUserInfo; set => changeUserInfo = value; }

        public frmLogin()
        {
            InitializeComponent();
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (KetNoiDatabaseGoc() == 0)
                return;
            layDanhSachPhanManh("SELECT * FROM dbo.v_GetSubcribers");
            txbLoginName.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại tên publisher và tên db.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // adapter dùng để đưa dữ liệu từ view sang database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùng adapter thì mới đổ vào data table được
            da.Fill(dt);


            connPublisher.Close();
            //bind data vào bindSource
            Program.bindingSource.DataSource = dt;


            cbBranch.DataSource = Program.bindingSource;
            cbBranch.DisplayMember = "TENCN";
            cbBranch.ValueMember = "TENSERVER";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            string pass = txbPassword.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được trống");
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                MessageUtil.ShowErrorMsgDialog("Mật khẩu không được trống");
                return;
            }

            string serverName = cbBranch.SelectedValue.ToString();
            Program.SetServerToSubcriber(serverName, loginName, pass);


            if (Program.CheckConnection() == false)
                return;
            Program.MACNHT = Program.LayChiNhanhHT();
            User user = Program.Login(loginName);
            if (user != null)
            {
                user.Login = loginName;
                user.Pass = pass;
                user.BranchIndex = cbBranch.SelectedIndex;
                SecurityContext.User = user;
                // update stt bar
                ChangeUserInfo.Invoke();
                
                Close();

            }
        }

        
    }
}