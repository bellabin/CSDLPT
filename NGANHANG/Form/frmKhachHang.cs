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
using NGANHANG.DTO;
using System.Text.RegularExpressions;

namespace NGANHANG.Form
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private string serverName;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.khachHangTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.khachHangTableAdapter.Fill(this.DS.KhachHang);

            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.taiKhoanTableAdapter.Fill(this.DS.TaiKhoan);

            cbBranch.DataSource = Program.bindingSource;
            cbBranch.DisplayMember = "TENCN";
            cbBranch.ValueMember = "TENSERVER";
            cbBranch.SelectedIndex = SecurityContext.User.BranchIndex;
            serverName = cbBranch.SelectedValue.ToString();

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
            btnLuu.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnThoatThem.Enabled = pcKH.Enabled = false;
            btnThoatThem.Visibility = btnThoatSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                khachHangTableAdapter.Fill(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsKH.Position;
            bdsKH.AddNew();

            pcKH.Enabled = true;
            txbMACN.Text = Program.MACNHT.ToString();
            gcKH.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            txbMACN.Enabled = false;

            cbPHAI.Items.Clear();
            cbPHAI.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbPHAI.SelectedIndex = 0;

            txbCMND.Enabled = true;
            txbCMND.Focus();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnLuu.Enabled = btnUndo.Enabled = btnThoatThem.Enabled = true;
            btnRedo.Enabled = false;

            btnLuu.Tag = btnThem;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang oldKhachHang = null;
            string KhachHangCMND = "";

            if (btnLuu.Tag == btnSua)
            {
                oldKhachHang = new KhachHang((DataRowView)bdsKH[bdsKH.Position]);
            }
            else
            {
                // Kiểm tra các ràng buộc
                KhachHangCMND = txbCMND.Text.Trim();
                if (string.IsNullOrEmpty(KhachHangCMND))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không được để trống.");
                    txbCMND.Focus();
                    return;
                }

                if (KhachHangCMND.Contains(" ") || !Regex.Match(KhachHangCMND, "\\d{10}").Success)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không hợp lệ hoặc chưa đủ 10 chữ số");
                    txbCMND.Focus();
                    return;
                }

                // Kiểm tra cmnd tồn tại
                if (Program.kiemTraKhachHangTonTai(KhachHangCMND) == 1)
                {
                    MessageUtil.ShowErrorMsgDialog("Khách hàng đã tồn tại. Vui lòng chọn mã khác");
                    txbCMND.Focus();
                    return;
                }

                txbCMND.Text = KhachHangCMND;

            }

            string HO = txbHO.Text.Trim();
            if (string.IsNullOrEmpty(HO))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbHO.Focus();
                return;
            }

            HO = ControlUtil.RemoveDuplicateSpace(HO);
            HO = ControlUtil.CapitalizeFirstLetter(HO);
            txbHO.Text = HO;

            string TEN = txbTEN.Text.Trim();
            if (string.IsNullOrEmpty(TEN))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbTEN.Focus();
                return;
            }

            if (TEN.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên khách hàng không hợp lệ");
                txbTEN.Focus();
                return;
            }

            TEN = ControlUtil.CapitalizeFirstLetter(TEN);
            txbTEN.Text = TEN;

            string DIACHI = txbDIACHI.Text.Trim();
            if (string.IsNullOrEmpty(DIACHI))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ khách hàng không được để trống");
                txbDIACHI.Focus();
                return;
            }

            DIACHI = ControlUtil.RemoveDuplicateSpace(DIACHI);
            txbDIACHI.Text = DIACHI;

            string SODT = txbSODT.Text.Trim();
            if (string.IsNullOrEmpty(SODT))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không được để trống");
                txbSODT.Focus();
                return;
            }

            if (!SODT.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không hợp lệ");
                txbSODT.Focus();
                return;
            }

            if (SODT.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không đúng 10 chữ số");
                txbSODT.Focus();
                return;
            }
            txbSODT.Text = SODT;

            if (deNGAYCAP.DateTime > DateTime.Now)
            {
                MessageUtil.ShowErrorMsgDialog("Ngày cấp CMND khách hàng không hợp lệ");
                deNGAYCAP.Focus();
                return;
            }

            cbPHAI.DataBindings[0].WriteValue();
            deNGAYCAP.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsKH.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsKH.ResetCurrentItem();
                khachHangTableAdapter.Update(this.DS.KhachHang);


                MessageUtil.ShowInfoMsgDialog("Ghi thành công");
            }
            catch (Exception ex)
            {
                string msg = btnLuu.Tag == btnThem ? "Lỗi không thể thêm KH mới" : "Lỗi không thể hiệu chỉnh KH";
                MessageUtil.ShowErrorMsgDialog($"{msg}.\nChi tiết: {ex.Message}");
                return;
            }

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsKH.Position;
            pcKH.Enabled = true;
            gcKH.Enabled = false;
            btnThoatSua.Enabled = true;
            btnThoatSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnLuu.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnLuu.Tag = btnSua;

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string KhachHangCMND = ((DataRowView)bdsKH[bdsKH.Position])["CMND"].ToString();
            
            if (bdsTK.Count > 0 )
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa khách hàng đã có tài khoản.");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa khách hàng có số CMND {KhachHangCMND}?") == DialogResult.OK)
            {
                KhachHang deletedKhachHang = null;
                try
                {
                    deletedKhachHang = new KhachHang((DataRowView)bdsKH[bdsKH.Position]);
                    // Xóa trên máy trước
                    bdsKH.RemoveCurrent();
                    // Xóa trên server
                    khachHangTableAdapter.Update(this.DS.KhachHang);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa khách hàng. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                    khachHangTableAdapter.Fill(this.DS.KhachHang);
                    bdsKH.Position = bdsKH.Find("CMND", KhachHangCMND);
                    return;
                }

                btnXoa.Enabled = bdsKH.Count != 0;
                btnUndo.Enabled = true;
            }
        }

        private void btnThoatThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcKH.Enabled = false;
            gcKH.Enabled = true;
            btnThoatThem.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnRedo.Enabled = true;
            btnLuu.Enabled = false;
            try
            {
                khachHangTableAdapter.Fill(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnThoatSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcKH.Enabled = false;
            gcKH.Enabled = true;
            btnThoatSua.Enabled = false;
            btnThoatSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnRedo.Enabled = true;
            btnLuu.Enabled = false;
            try
            {
                khachHangTableAdapter.Fill(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }
    }
}