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
using DevExpress.XtraReports.UI;
using NGANHANG.Util;

namespace NGANHANG.Report
{
    public partial class frmThongKeKH : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeKH()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                XrptThongKeKhachHang report = new XrptThongKeKhachHang();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }
    }
}