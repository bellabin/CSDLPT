namespace NGANHANG
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenGuiRut = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSTKM = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKeKH = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaoKe = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonSys = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonCategory = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonService = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(40, 39, 40, 39);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnLogin,
            this.btnLogout,
            this.btnCreateLogin,
            this.btnKH,
            this.btnNV,
            this.btnMoTK,
            this.btnChuyenGuiRut,
            this.btnDSTKM,
            this.btnThongKeKH,
            this.btnSaoKe});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 440;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonSys,
            this.ribbonCategory,
            this.ribbonService,
            this.ribbonReport});
            this.ribbonControl1.Size = new System.Drawing.Size(1011, 158);
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Đăng nhập";
            this.btnLogin.Id = 1;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 2;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnCreateLogin
            // 
            this.btnCreateLogin.Caption = "Tạo tài khoản";
            this.btnCreateLogin.Id = 3;
            this.btnCreateLogin.Name = "btnCreateLogin";
            this.btnCreateLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateLogin_ItemClick);
            // 
            // btnKH
            // 
            this.btnKH.Caption = "Khách hàng";
            this.btnKH.Id = 4;
            this.btnKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKH.ImageOptions.Image")));
            this.btnKH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKH.ImageOptions.LargeImage")));
            this.btnKH.Name = "btnKH";
            this.btnKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKH_ItemClick);
            // 
            // btnNV
            // 
            this.btnNV.Caption = "Nhân Viên";
            this.btnNV.Id = 5;
            this.btnNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNV.ImageOptions.Image")));
            this.btnNV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNV.ImageOptions.LargeImage")));
            this.btnNV.Name = "btnNV";
            this.btnNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNV_ItemClick);
            // 
            // btnMoTK
            // 
            this.btnMoTK.Caption = "Mở tài khoản";
            this.btnMoTK.Id = 6;
            this.btnMoTK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoTK.ImageOptions.Image")));
            this.btnMoTK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMoTK.ImageOptions.LargeImage")));
            this.btnMoTK.Name = "btnMoTK";
            this.btnMoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoTK_ItemClick);
            // 
            // btnChuyenGuiRut
            // 
            this.btnChuyenGuiRut.Caption = "Chuyển, gửi, rút tiền";
            this.btnChuyenGuiRut.Id = 7;
            this.btnChuyenGuiRut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChuyenGuiRut.ImageOptions.SvgImage")));
            this.btnChuyenGuiRut.Name = "btnChuyenGuiRut";
            this.btnChuyenGuiRut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChuyenGuiRut_ItemClick);
            // 
            // btnDSTKM
            // 
            this.btnDSTKM.Caption = "Danh sách tài khoản mở";
            this.btnDSTKM.Id = 8;
            this.btnDSTKM.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDSTKM.ImageOptions.Image")));
            this.btnDSTKM.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDSTKM.ImageOptions.LargeImage")));
            this.btnDSTKM.Name = "btnDSTKM";
            this.btnDSTKM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSTKM_ItemClick);
            // 
            // btnThongKeKH
            // 
            this.btnThongKeKH.Caption = "Thống kê khách hàng";
            this.btnThongKeKH.Id = 9;
            this.btnThongKeKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKeKH.ImageOptions.Image")));
            this.btnThongKeKH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThongKeKH.ImageOptions.LargeImage")));
            this.btnThongKeKH.Name = "btnThongKeKH";
            this.btnThongKeKH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKeKH_ItemClick);
            // 
            // btnSaoKe
            // 
            this.btnSaoKe.Caption = "Sao kê tài khoản";
            this.btnSaoKe.Id = 10;
            this.btnSaoKe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaoKe.ImageOptions.Image")));
            this.btnSaoKe.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaoKe.ImageOptions.LargeImage")));
            this.btnSaoKe.Name = "btnSaoKe";
            this.btnSaoKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaoKe_ItemClick);
            // 
            // ribbonSys
            // 
            this.ribbonSys.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonSys.Name = "ribbonSys";
            this.ribbonSys.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogin);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCreateLogin);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonCategory
            // 
            this.ribbonCategory.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonCategory.Name = "ribbonCategory";
            this.ribbonCategory.Text = "Quản lý";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnKH);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNV);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonService
            // 
            this.ribbonService.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonService.Name = "ribbonService";
            this.ribbonService.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMoTK);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChuyenGuiRut);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonReport
            // 
            this.ribbonReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonReport.Name = "ribbonReport";
            this.ribbonReport.Text = "Báo cáo";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDSTKM);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnThongKeKH);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSaoKe);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "ribbonPage5";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "ribbonPage7";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1011, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(42, 17);
            this.MANV.Text = "MANV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(45, 17);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(45, 17);
            this.NHOM.Text = "NHOM";
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 471);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonSys;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnCreateLogin;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonCategory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonService;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MANV;
        private System.Windows.Forms.ToolStripStatusLabel HOTEN;
        private System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.BarButtonItem btnKH;
        private DevExpress.XtraBars.BarButtonItem btnNV;
        private DevExpress.XtraBars.BarButtonItem btnMoTK;
        private DevExpress.XtraBars.BarButtonItem btnChuyenGuiRut;
        private DevExpress.XtraBars.BarButtonItem btnDSTKM;
        private DevExpress.XtraBars.BarButtonItem btnThongKeKH;
        private DevExpress.XtraBars.BarButtonItem btnSaoKe;
    }
}

