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
using NGANHANG.Util;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace NGANHANG.Form
{
    public partial class frmGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        public frmGiaoDich()
        {
            InitializeComponent();
        }

        private void frmGiaoDich_Load(object sender, EventArgs e)
        {
            pcChuyen.Enabled = pcGoiRut.Enabled = btnHuy.Enabled = false;
            pcTK.Enabled = btnXacNhan.Enabled = true;
            teSODU.Enabled = false;

        }

        private void laySoDuTK()
        {
            string cmd = $"SELECT SODU FROM [DBO].[TAIKHOAN] WHERE SOTK = {txbSOTK.Text}";
            SqlDataReader dataReader = Program.ExecuteSqlDataReader(cmd);
            dataReader.Read();

            teSODU.EditValue = dataReader.GetValue(0);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSOTK.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Vui lòng nhập số tài khoản ");
                txbSOTK.Focus();
                return;
            }

            if (Regex.IsMatch(txbSOTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txbSOTK.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("sp_KiemTraSoTK", txbSOTK.Text) == 0)
                {
                    MessageBox.Show("Số tài khoản không tồn tại");
                    txbSOTK.Focus();
                    return;
                }
                laySoDuTK();
                pcGoiRut.Enabled = pcChuyen.Enabled = true;
                pcTK.Enabled = false;
                btnXacNhan.Enabled = false;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnGoi_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(teSoTienGoiRut.EditValue) < 100000)
            {
                MessageBox.Show("Số tiền gởi phải lớn hơn 100000");
                teSoTienGoiRut.Focus();
                return;
            }

            int ktThucthi = Program.ExecuteNonQuery(
              "EXEC dbo.sp_GiaoDichGoiRut @TYPE , @SOTIEN , @SOTK , @MANV ",
                  new object[] { "GT", teSoTienGoiRut.EditValue, txbSOTK.Text, SecurityContext.User.Username }
             );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                laySoDuTK();
            }
        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(teSoTienGoiRut.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Vui lòng nhập số tiền ");
                teSoTienGoiRut.Focus();
                return;
            }

            if (Convert.ToInt64(teSoTienGoiRut.EditValue) < 100000)
            {
                MessageBox.Show("Số tiền rút phải lớn hơn 100000");
                teSoTienGoiRut.Focus();
                return;
            }
            if (Convert.ToInt64(teSoTienGoiRut.EditValue) > Convert.ToInt64(teSODU.EditValue) )
            {
                MessageBox.Show("Số tiền rút phải bé hơn số dư");
                teSoTienGoiRut.Focus();
                return;
            }


            int ktThucthi = Program.ExecuteNonQuery(
              "EXEC dbo.sp_GiaoDichGoiRut @TYPE , @SOTIEN , @SOTK , @MANV ",
                  new object[] { "RT", teSoTienGoiRut.EditValue, txbSOTK.Text, SecurityContext.User.Username }
             );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                laySoDuTK();
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txbSoTKNhan.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txbSoTKNhan.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("sp_KIEMTRASOTK", txbSoTKNhan.Text) == 0)
                {
                    MessageBox.Show("Số tài khoản không tồn tại");
                    txbSoTKNhan.Focus();
                    return;
                }
            }
            if (Convert.ToInt64(teSoTienChuyen.EditValue) < 100000)
            {
                MessageBox.Show("Số tiền chuyển phải lớn hơn 100000");
                teSoTienChuyen.Focus();
                return;
            }
            if (Convert.ToInt64(teSoTienChuyen.EditValue) > Convert.ToInt64(teSODU.EditValue) )
            {
                MessageBox.Show("Số tiền chuyển phải bé hơn số dư");
                teSoTienChuyen.Focus();
                return;
            }



            int ktThucthi = Program.ExecuteNonQuery(
            "EXEC dbo.sp_GiaoDichChuyenTien @SOTK_NHAN , @SOTK_CHUYEN , @SOTIEN , @MANV ",
                new object[] { txbSoTKNhan.Text, txbSOTK.Text.Trim(), teSoTienChuyen.EditValue, SecurityContext.User.Username }
           );

            if (ktThucthi > 0)
            {
                MessageBox.Show("Giao dịch thành công");
                laySoDuTK();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pcChuyen.Enabled = pcGoiRut.Enabled = false;
            pcTK.Enabled = btnXacNhan.Enabled = true;
            btnHuy.Enabled = false;
        }
    }
}