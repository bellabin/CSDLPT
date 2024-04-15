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
using DevExpress.XtraReports.UI;

namespace NGANHANG.Report
{
    public partial class frmSaoKe : DevExpress.XtraEditors.XtraForm
    {
        public frmSaoKe()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmSaoKe_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);

            txbSOTK.Enabled = txbCMND.Enabled = teSODU.Enabled = txbCN.Enabled = false;
            deFrom.DateTime = deTo.DateTime = DateTime.Now;
        }

        private void btnSaoKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (bdsTK.Count == 0)
                {
                    MessageUtil.ShowErrorMsgDialog("Không thể xem báo cáo vì danh sách tài khoản rỗng");
                    return;
                }
                if (deFrom.DateTime >= deTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }

                string STK = ((DataRowView)bdsTK[bdsTK.Position])["SOTK"].ToString();
                XrptSaoKe report = new XrptSaoKe(STK, deFrom.DateTime, deTo.DateTime);
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
                return;
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog("Tài khoản không có giao dịch ");
                return;
            }
        }
    }
}