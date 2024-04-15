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
using System.Data.SqlClient;

namespace NGANHANG.Form
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private string serverName;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

            this.chuyenTienTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.chuyenTienTableAdapter.Fill(this.DS.GD_CHUYENTIEN);

            this.goiRutTableAdapter.Connection.ConnectionString = Program.ConnectionStr;
            this.goiRutTableAdapter.Fill(this.DS.GD_GOIRUT);

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
                    btnChuyenNV.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBranch.Enabled = false;
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                    btnChuyenNV.Enabled = (bdsNV.Count > 0);
                    break;
                default:
                    throw new Exception("User group is unidentified");
            }

            btnReload.Enabled = btnExit.Enabled = true;
            btnLuu.Enabled = btnUndo.Enabled = btnRedo.Enabled = btnThoatThem.Enabled = pcNV.Enabled = false;
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
                nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsNV.Position;
            bdsNV.AddNew();

            pcNV.Enabled = true;
            txbMACN.Text = Program.MACNHT.ToString();
            gcNV.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            txbMACN.Enabled = false;

            cbPHAI.Items.Clear();
            cbPHAI.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbPHAI.SelectedIndex = 0;

            chbTTX.Checked = false;
            chbTTX.Enabled = false;
            txbMANV.Enabled = true;
            txbMANV.Focus();
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnLuu.Enabled = btnUndo.Enabled = btnThoatThem.Enabled = true;
            btnRedo.Enabled = false;

            btnLuu.Tag = btnThem;

            SqlDataReader reader = Program.ExecuteSqlDataReader("SELECT TOP 1 nv.MANV FROM dbo.NhanVien nv ORDER BY nv.MANV DESC");
            reader.Read();
            string tmp = reader.GetValue(0).ToString();
            tmp = tmp.Replace("NV","");
            int num = Int32.Parse(tmp) + 2;
            string tmpMANV = "NV" + num.ToString();
            //MessageUtil.ShowErrorMsgDialog(tmpMANV);
            txbMANV.Text = tmpMANV;
            txbMANV.Enabled = false;

            // Push cancel-editing event to undo stack
            //undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhanVien oldNhanVien = null;
            string NhanVienID = "";
            string NhanVienCMND = "";

            if (btnLuu.Tag == btnSua)
            {
                oldNhanVien = new NhanVien((DataRowView)bdsNV[bdsNV.Position]);
            }
            else
            {
                // Kiểm tra các ràng buộc
                //MANV tu dong tang
                
                
                NhanVienID = txbMANV.Text.Trim();
                if (string.IsNullOrEmpty(NhanVienID))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được để trống.");
                    txbMANV.Focus();
                    return;
                }

                if (NhanVienID.Contains(" "))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không hợp lệ");
                    txbMANV.Focus();
                    return;
                }

                if (NhanVienID.Length > 10)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được vượt quá 10 kí tự");
                    txbMANV.Focus();
                    return;
                }

                // Kiểm tra mã nhân viên tồn tại trên site chủ
                if (Program.kiemTraNhanVienTonTai(NhanVienID) == 1)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác");
                    txbMANV.Focus();
                    return;
                }


                NhanVienID = NhanVienID.ToUpper();
                txbMANV.Text = NhanVienID;


                NhanVienCMND = txbCMND.Text.Trim();
                if (string.IsNullOrEmpty(NhanVienCMND))
                {
                    MessageUtil.ShowErrorMsgDialog("CMND không được để trống.");
                    txbCMND.Focus();
                    return;
                }

                if (NhanVienCMND.Contains(" "))
                {
                    MessageUtil.ShowErrorMsgDialog("CMND không hợp lệ");
                    txbCMND.Focus();
                    return;
                }

                if (NhanVienCMND.Length > 10)
                {
                    MessageUtil.ShowErrorMsgDialog("CMND không được vượt quá 10 kí tự");
                    txbCMND.Focus();
                    return;
                }

                // kiểm tra cmnd
                if (Program.kiemTraCMNDTonTai(NhanVienCMND) == 1)
                {
                    MessageUtil.ShowErrorMsgDialog("CMND đã tồn tại. Vui lòng kiểm tra lại");
                    txbCMND.Focus();
                    return;
                }

                txbCMND.Text = NhanVienCMND;
            }

            string HO = txbHO.Text.Trim();
            if (string.IsNullOrEmpty(HO))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbHO.Focus();
                return;
            }

            HO = ControlUtil.RemoveDuplicateSpace(HO);
            HO = ControlUtil.CapitalizeFirstLetter(HO);
            txbHO.Text = HO;

            string TEN = txbTEN.Text.Trim();
            if (string.IsNullOrEmpty(TEN))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbTEN.Focus();
                return;
            }

            if (TEN.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên nhân viên không hợp lệ");
                txbTEN.Focus();
                return;
            }

            TEN = ControlUtil.CapitalizeFirstLetter(TEN);
            txbTEN.Text = TEN;

            string DIACHI = txbDIACHI.Text.Trim();
            if (string.IsNullOrEmpty(DIACHI))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ nhân viên không được để trống");
                txbDIACHI.Focus();
                return;
            }

            DIACHI = ControlUtil.RemoveDuplicateSpace(DIACHI);
            txbDIACHI.Text = DIACHI;

            string SODT = txbSODT.Text.Trim();
            if (string.IsNullOrEmpty(SODT))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không được để trống");
                txbSODT.Focus();
                return;
            }

            if (!SODT.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không hợp lệ");
                txbSODT.Focus();
                return;
            }

            if (SODT.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không đúng 10 chữ số");
                txbSODT.Focus();
                return;
            }
            txbSODT.Text = SODT;


                   

            cbPHAI.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsNV.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsNV.ResetCurrentItem();
                nhanVienTableAdapter.Update(this.DS.NhanVien);

                // update MANV
                SqlDataReader reader = Program.ExecuteSqlDataReader("SELECT TOP 1 nv.MANV FROM dbo.NhanVien nv ORDER BY nv.MANV DESC");
                reader.Read();
                string tmp = reader.GetValue(0).ToString();
                tmp = tmp.Replace("NV", "");
                int num = Int32.Parse(tmp) + 2;
                string tmpMANV = "NV" + num.ToString();
                //MessageUtil.ShowErrorMsgDialog(tmpMANV);
                txbMANV.Text = tmpMANV;
                MessageUtil.ShowInfoMsgDialog("Ghi thành công");
            }
            catch (Exception ex)
            {
                string msg = btnLuu.Tag == btnThem ? "Lỗi không thể thêm nhân viên mới" : "Lỗi không thể hiệu chỉnh nhân viên";
                MessageUtil.ShowErrorMsgDialog($"{msg}.\nChi tiết: {ex.Message}");
                return;
            }






            // undo
            
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsNV.Position;
            pcNV.Enabled = true;
            gcNV.Enabled = false;
            btnThoatSua.Enabled = true;
            btnThoatSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnLuu.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnLuu.Tag = btnSua;



            //undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
            //ControlUtil.ResolveStackStorage(undoStack);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Không thể xóa nhân viên đang là user
            string NhanVienId = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            if (NhanVienId.Equals(SecurityContext.User.Username))
            {
                MessageUtil.ShowErrorMsgDialog("Bạn chỉ được thay đổi thông tin của mình, không thể xóa.");
                return;
            }

            if (bdsGoiRut.Count > 0 || bdsChuyenTien.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa nhân viên đã thực hiện giao dịch cho khách hàng");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa nhân viên có mã số {NhanVienId}?") == DialogResult.OK)
            {
                NhanVien deletedNhanVien = null;
                try
                {
                    deletedNhanVien = new NhanVien((DataRowView)bdsNV[bdsNV.Position]);
                    // Xóa trên máy trước
                    bdsNV.RemoveCurrent();
                    // Xóa trên server
                    nhanVienTableAdapter.Update(this.DS.NhanVien);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                    nhanVienTableAdapter.Fill(this.DS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", deletedNhanVien.MaNV);
                    return;
                }

                btnXoa.Enabled = bdsNV.Count != 0;

                // Ignore to save grid pos
                //undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedNhanVien, -1));
                btnUndo.Enabled = true;
                //ControlUtil.ResolveStackStorage(undoStack);
                //redoStack.Clear();
                btnRedo.Enabled = false;
                btnChuyenNV.Enabled = bdsNV.Count != 0;
            }
        }

        private void btnThoatThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcNV.Enabled = false;
            gcNV.Enabled = true;
            btnThoatThem.Enabled = false;
            btnThoatThem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnRedo.Enabled = true;
            btnLuu.Enabled = false;
            try
            {
                nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnThoatSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pcNV.Enabled = false;
            gcNV.Enabled = true;
            btnThoatSua.Enabled = false;
            btnThoatSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnChuyenNV.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnUndo.Enabled = btnRedo.Enabled = true;
            btnLuu.Enabled = false;
            try
            {
                nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }
    }
}