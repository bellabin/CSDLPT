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
    public partial class frmThongKeMoTK : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeMoTK()
        {
            InitializeComponent();
        }

        private void frmThongKeMoTK_Load(object sender, EventArgs e)
        {
            cbBranch.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            cbBranch.DisplayMember = "TENCN";
            cbBranch.ValueMember = "TENSERVER";
            cbBranch.SelectedIndex = SecurityContext.User.BranchIndex;

            deFrom.DateTime = deTo.DateTime = DateTime.Now;
            rbtnCN.Checked = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (deFrom.DateTime > deTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }
                string MACN;
                if (cbBranch.Text.Equals("BENTHANH"))
                    MACN = "BENTHANH";
                else
                    MACN = "TANDINH";


                if (rbtnCN.Checked)
                {
                    Xrpt_ThongKeMoTaiKhoanChiNhanh report = new Xrpt_ThongKeMoTaiKhoanChiNhanh(deFrom.DateTime, deTo.DateTime, MACN);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                }
                else
                {
                    Xrpt_ThongKeMoTaiKhoanTatCaChiNhanh report = new Xrpt_ThongKeMoTaiKhoanTatCaChiNhanh(deFrom.DateTime, deTo.DateTime);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                }
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }
    }
}