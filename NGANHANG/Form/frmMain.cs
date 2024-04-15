using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NGANHANG.Util;
using NGANHANG.DTO;
using NGANHANG.Form;
using NGANHANG.Report;

namespace NGANHANG
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private frmMoTK formMoTK;

        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnCreateLogin.Enabled = btnLogout.Enabled = false;
            ribbonCategory.Visible = ribbonService.Visible = ribbonReport.Visible = false;
        }


        private void UpdateUserInfo()
        {
            User user = SecurityContext.User;
            if (user == null) return;

            // Update status bar
            this.MANV.Text = $"MANV: {user.Username}";
            this.HOTEN.Text = $"HOTEN: {user.Fullname}";
            this.NHOM.Text = $"NHOM: {user.GetGroupName()}";

            btnLogin.Enabled = false;
            btnCreateLogin.Enabled = btnLogout.Enabled = true;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    ribbonCategory.Visible = ribbonReport.Visible = true;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    ribbonCategory.Visible = ribbonService.Visible = ribbonReport.Visible = true;
                    break;
                default:
                    throw new Exception("User group is unidentified");
            }

            
        }

        private void CreateAndShowLoginForm()
        {
            frmLogin f = new frmLogin
            {
                MdiParent = this,
                ChangeUserInfo = UpdateUserInfo
            };
            f.Show();
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmLogin));
            if (form != null)
                form.Activate();
            else
                CreateAndShowLoginForm();

        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận đăng xuất?") == DialogResult.OK)
            {
                foreach (System.Windows.Forms.Form form in MdiChildren)
                {
                    form.Close();
                }

                //CreateAndShowLoginForm();

                SecurityContext.ClearUser();

                // Clear user info in status bar
                this.MANV.Text = "MANV";
                this.HOTEN.Text = "HOTEN";
                this.NHOM.Text = "NHOM";

                btnLogin.Enabled = true;
                btnCreateLogin.Enabled = btnLogout.Enabled = false;
                ribbonCategory.Visible = ribbonService.Visible = ribbonReport.Visible = false;
            }
        }


        private void btnCreateLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmNhanVien));
            if (form != null)
                form.Activate();
            else
            {
                frmNhanVien f = new frmNhanVien()
                {
                    MdiParent = this,

                };
                f.Show();

            }
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmKhachHang));
            if (form != null)
                form.Activate();
            else
            {
                frmKhachHang f = new frmKhachHang()
                {
                    MdiParent = this,

                };
                f.Show();

            }
        }

        private void btnMoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmMoTK));
            if (form != null)
                form.Activate();
            else
            {
                formMoTK = new frmMoTK();

                formMoTK.ShowDialog(this);

            }
        }

        private void btnChuyenGuiRut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmGiaoDich));
            if (form != null)
                form.Activate();
            else
            {
                frmGiaoDich f = new frmGiaoDich()
                {
                    MdiParent = this,
                };

                f.Show();

            }
        }

        private void btnDSTKM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmThongKeMoTK));
            if (form != null)
                form.Activate();
            else
            {
                frmThongKeMoTK f = new frmThongKeMoTK()
                {
                    MdiParent = this,
                };
                f.Show();

            }
        }

        private void btnThongKeKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmThongKeKH));
            if (form != null)
                form.Activate();
            else
            {
                frmThongKeKH f = new frmThongKeKH()
                {
                    MdiParent = this,
                };
                f.Show();

            }
        }

        private void btnSaoKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Windows.Forms.Form form = ControlUtil.CheckFormExists(this, typeof(frmSaoKe));
            if (form != null)
                form.Activate();
            else
            {
                frmSaoKe f = new frmSaoKe()
                {
                    MdiParent = this,
                };
                f.Show();

            }
        }
    }


}
