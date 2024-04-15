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

namespace NGANHANG.Form
{
    public partial class frmMoTK : DevExpress.XtraEditors.XtraForm
    {
        public frmMoTK()
        {
            InitializeComponent();
        }


        private void frmMoTK_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);

            // TODO: This line of code loads data into the 'DS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.chuyenTienTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.chuyenTienTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'DS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.goiRutTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.goiRutTableAdapter.Fill(this.DS.GD_GOIRUT);

            cbBranch.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            cbBranch.DisplayMember = "TENCN";
            cbBranch.ValueMember = "TENSERVER";

            cbBranch.SelectedIndex = SecurityContext.User.BranchIndex;

            //phân quyền
            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBranch.Enabled = true;
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBranch.Enabled = false;
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    break;
                default:
                    throw new Exception("User group is unidentified");
            }

            btnReload.Enabled = btnExit.Enabled = true;
            btnLuu.Enabled = btnUndo.Enabled = btnRedo.Enabled = pcTK.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsTK.Position;
            bdsTK.AddNew();

            pcTK.Enabled = true;
            txbMACN.Text = Program.MACNHT.ToString();
            gcTK.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            txbMACN.Enabled = false;

            txbSOTK.Enabled = true;
            txbSOTK.Focus();
            deNGAYMO.Enabled = false;
            deNGAYMO.Text = DateTime.Now.ToString("yyyy/MM/dd");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnLuu.Enabled = btnUndo.Enabled = btnThoatThem.Enabled = true;
            btnRedo.Enabled = false;

            btnLuu.Tag = btnThem;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int kiemtra;
            if (txbCMND.Text == "")
            {
                MessageBox.Show("CMND không được để trống");
                txbCMND.Focus();
                return;
            }
            if (Regex.IsMatch(txbCMND.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("CMND chỉ nhận số");
                txbCMND.Focus();
                return;
            }
            else
            {
                kiemtra = Program.ExecSqlCheck("sp_KiemTraKhachHang", txbCMND.Text);
                if (kiemtra == 0)
                {
                    MessageBox.Show("CMND không tồn tại");
                    txbCMND.Focus();
                    return;
                }
            }

            if (Regex.IsMatch(txbSOTK.Text, @"^[0-9]+$") == false)
            {
                MessageBox.Show("Số tài khoản chỉ nhận số");
                txbSOTK.Focus();
                return;
            }
            else
            {
                if (Program.ExecSqlCheck("sp_KiemTraSoTK", txbSOTK.Text) == 1)
                {
                    MessageBox.Show("Số tài khoản đã tồn tại");
                    txbSOTK.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(teSODU.Text))
            {
                MessageUtil.ShowErrorMsgDialog("Số dư không được để trống");
                teSODU.Focus();
                return;
            }


            if (Convert.ToInt64(teSODU.EditValue) < 100000)
            {
                MessageBox.Show("Số dư phải lớn hơn 100000");
                teSODU.Focus();
                return;
            }
            if (!Program.CheckConnection()) return;

            if (MessageBox.Show("Bạn có chắc muốn lưu ?", "Thông báo",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    bdsTK.EndEdit();
                    bdsTK.ResetCurrentItem();
                    this.taiKhoanTableAdapter.Update(this.DS.TaiKhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi tài khoản : " + ex.Message, "", MessageBoxButtons.OK);
                }
            }


            gcTK.Enabled = true;
            pcTK.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string soTK = ((DataRowView)bdsTK[bdsTK.Position])["SOTK"].ToString();
            if (bdsGoiRut.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì đã có giao dịch gởi hoặc rút tiền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bdsChuyenTien.Count > 0 || bdsChuyenTien1.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì đã có giao dịch gởi hoặc rút tiền", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Program.CheckConnection()) return;

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa tài khoản mã số {soTK}?") == DialogResult.OK)
            {
                try
                {
                    soTK = ((DataRowView)bdsTK[bdsTK.Position])["SOTK"].ToString();
                    bdsTK.RemoveCurrent();
                    this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
                    this.taiKhoanTableAdapter.Update(this.DS.TaiKhoan);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra trong quá trình xóa: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
                    bdsTK.Position = bdsTK.Find("SOTK", soTK);
                }

                btnXoa.Enabled = (bdsTK.Count > 0);
            }
        }

        private void btnThoatThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcTK.Enabled = false;
            gcTK.Enabled = true;
            btnThoatThem.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnRedo.Enabled = true;
            btnLuu.Enabled = false;
            try
            {
                taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }
    }
}