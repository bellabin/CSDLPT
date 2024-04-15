namespace NGANHANG.Form
{
    partial class frmGiaoDich
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
            this.pcTK = new DevExpress.XtraEditors.PanelControl();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.teSODU = new DevExpress.XtraEditors.TextEdit();
            this.txbSOTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcChuyen = new DevExpress.XtraEditors.PanelControl();
            this.label7 = new System.Windows.Forms.Label();
            this.teSoTienChuyen = new DevExpress.XtraEditors.TextEdit();
            this.txbSoTKNhan = new System.Windows.Forms.TextBox();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pcGoiRut = new DevExpress.XtraEditors.PanelControl();
            this.btnHuy = new System.Windows.Forms.Button();
            this.teSoTienGoiRut = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRut = new System.Windows.Forms.Button();
            this.btnGoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcTK)).BeginInit();
            this.pcTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSODU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChuyen)).BeginInit();
            this.pcChuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSoTienChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGoiRut)).BeginInit();
            this.pcGoiRut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSoTienGoiRut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pcTK
            // 
            this.pcTK.Controls.Add(this.btnXacNhan);
            this.pcTK.Controls.Add(this.teSODU);
            this.pcTK.Controls.Add(this.txbSOTK);
            this.pcTK.Controls.Add(this.label2);
            this.pcTK.Controls.Add(this.label1);
            this.pcTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcTK.Location = new System.Drawing.Point(0, 0);
            this.pcTK.Name = "pcTK";
            this.pcTK.Size = new System.Drawing.Size(1046, 54);
            this.pcTK.TabIndex = 0;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(666, 9);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 33);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // teSODU
            // 
            this.teSODU.Location = new System.Drawing.Point(448, 13);
            this.teSODU.Name = "teSODU";
            this.teSODU.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teSODU.Properties.Appearance.Options.UseFont = true;
            this.teSODU.Properties.DisplayFormat.FormatString = "n0";
            this.teSODU.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSODU.Properties.EditFormat.FormatString = "n0";
            this.teSODU.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSODU.Size = new System.Drawing.Size(166, 26);
            this.teSODU.TabIndex = 3;
            // 
            // txbSOTK
            // 
            this.txbSOTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSOTK.Location = new System.Drawing.Point(145, 13);
            this.txbSOTK.Name = "txbSOTK";
            this.txbSOTK.Size = new System.Drawing.Size(187, 26);
            this.txbSOTK.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(392, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số dư:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số tài khoản:";
            // 
            // pcChuyen
            // 
            this.pcChuyen.Controls.Add(this.label7);
            this.pcChuyen.Controls.Add(this.teSoTienChuyen);
            this.pcChuyen.Controls.Add(this.txbSoTKNhan);
            this.pcChuyen.Controls.Add(this.btnChuyen);
            this.pcChuyen.Controls.Add(this.label6);
            this.pcChuyen.Controls.Add(this.label4);
            this.pcChuyen.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcChuyen.Location = new System.Drawing.Point(353, 54);
            this.pcChuyen.Name = "pcChuyen";
            this.pcChuyen.Size = new System.Drawing.Size(693, 349);
            this.pcChuyen.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "Số tiền chuyển:";
            // 
            // teSoTienChuyen
            // 
            this.teSoTienChuyen.Location = new System.Drawing.Point(177, 128);
            this.teSoTienChuyen.Name = "teSoTienChuyen";
            this.teSoTienChuyen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teSoTienChuyen.Properties.Appearance.Options.UseFont = true;
            this.teSoTienChuyen.Properties.DisplayFormat.FormatString = "n0";
            this.teSoTienChuyen.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSoTienChuyen.Properties.EditFormat.FormatString = "n0";
            this.teSoTienChuyen.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSoTienChuyen.Size = new System.Drawing.Size(163, 26);
            this.teSoTienChuyen.TabIndex = 7;
            // 
            // txbSoTKNhan
            // 
            this.txbSoTKNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSoTKNhan.Location = new System.Drawing.Point(177, 79);
            this.txbSoTKNhan.Name = "txbSoTKNhan";
            this.txbSoTKNhan.Size = new System.Drawing.Size(163, 26);
            this.txbSoTKNhan.TabIndex = 6;
            // 
            // btnChuyen
            // 
            this.btnChuyen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyen.Location = new System.Drawing.Point(202, 208);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(75, 36);
            this.btnChuyen.TabIndex = 1;
            this.btnChuyen.Text = "Chuyển";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số TK nhận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chuyển tiền";
            // 
            // pcGoiRut
            // 
            this.pcGoiRut.Controls.Add(this.btnHuy);
            this.pcGoiRut.Controls.Add(this.teSoTienGoiRut);
            this.pcGoiRut.Controls.Add(this.label5);
            this.pcGoiRut.Controls.Add(this.btnRut);
            this.pcGoiRut.Controls.Add(this.btnGoi);
            this.pcGoiRut.Controls.Add(this.label3);
            this.pcGoiRut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcGoiRut.Location = new System.Drawing.Point(0, 54);
            this.pcGoiRut.Name = "pcGoiRut";
            this.pcGoiRut.Size = new System.Drawing.Size(353, 349);
            this.pcGoiRut.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(12, 305);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 32);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // teSoTienGoiRut
            // 
            this.teSoTienGoiRut.Location = new System.Drawing.Point(145, 73);
            this.teSoTienGoiRut.Name = "teSoTienGoiRut";
            this.teSoTienGoiRut.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teSoTienGoiRut.Properties.Appearance.Options.UseFont = true;
            this.teSoTienGoiRut.Properties.DisplayFormat.FormatString = "n0";
            this.teSoTienGoiRut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSoTienGoiRut.Properties.EditFormat.FormatString = "n0";
            this.teSoTienGoiRut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teSoTienGoiRut.Size = new System.Drawing.Size(146, 26);
            this.teSoTienGoiRut.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số tiền:";
            // 
            // btnRut
            // 
            this.btnRut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRut.Location = new System.Drawing.Point(272, 209);
            this.btnRut.Name = "btnRut";
            this.btnRut.Size = new System.Drawing.Size(75, 36);
            this.btnRut.TabIndex = 2;
            this.btnRut.Text = "Rút";
            this.btnRut.UseVisualStyleBackColor = true;
            this.btnRut.Click += new System.EventHandler(this.btnRut_Click);
            // 
            // btnGoi
            // 
            this.btnGoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoi.Location = new System.Drawing.Point(78, 209);
            this.btnGoi.Name = "btnGoi";
            this.btnGoi.Size = new System.Drawing.Size(75, 35);
            this.btnGoi.TabIndex = 1;
            this.btnGoi.Text = "Gởi";
            this.btnGoi.UseVisualStyleBackColor = true;
            this.btnGoi.Click += new System.EventHandler(this.btnGoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gởi / Rút tiền";
            // 
            // frmGiaoDich
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 403);
            this.Controls.Add(this.pcGoiRut);
            this.Controls.Add(this.pcChuyen);
            this.Controls.Add(this.pcTK);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGiaoDich";
            this.Text = "Giao dịch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGiaoDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcTK)).EndInit();
            this.pcTK.ResumeLayout(false);
            this.pcTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSODU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChuyen)).EndInit();
            this.pcChuyen.ResumeLayout(false);
            this.pcChuyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSoTienChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcGoiRut)).EndInit();
            this.pcGoiRut.ResumeLayout(false);
            this.pcGoiRut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teSoTienGoiRut.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcTK;
        private System.Windows.Forms.Button btnXacNhan;
        private DevExpress.XtraEditors.TextEdit teSODU;
        private System.Windows.Forms.TextBox txbSOTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl pcChuyen;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit teSoTienChuyen;
        private System.Windows.Forms.TextBox txbSoTKNhan;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.PanelControl pcGoiRut;
        private DevExpress.XtraEditors.TextEdit teSoTienGoiRut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRut;
        private System.Windows.Forms.Button btnGoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHuy;
    }
}