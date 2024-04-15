using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace NGANHANG.Report
{
    public partial class Xrpt_ThongKeMoTaiKhoanTatCaChiNhanh : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_ThongKeMoTaiKhoanTatCaChiNhanh()
        {
            InitializeComponent();
        }

        public Xrpt_ThongKeMoTaiKhoanTatCaChiNhanh(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[1].Value = dateTo.Date.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Fill();

            lbTime.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
