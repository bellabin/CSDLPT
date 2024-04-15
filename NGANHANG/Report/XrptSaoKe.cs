using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using NGANHANG.Util;

namespace NGANHANG.Report
{
    public partial class XrptSaoKe : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptSaoKe(string STK, DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();

            //this.sqlDataSource1.Connection.ConnectionString = Program.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = STK;
            query.Parameters[1].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[2].Value = dateTo.Date.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Fill();
            lbSTK.Text = STK;
            lbTime.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
