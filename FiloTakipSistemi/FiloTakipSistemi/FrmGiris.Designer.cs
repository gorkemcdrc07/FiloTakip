using DevExpress.XtraEditors; // Ensure you have this using directive

namespace FiloTakipSistemi
{
    partial class FrmGiris
    {
        private System.ComponentModel.IContainer components = null;
        private TextEdit txtKullaniciAdi; // TextEdit for Username
        private TextEdit txtSifre; // TextEdit for Password

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiris));
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.BtnGiris = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnKayıt = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnKayit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(3, 105);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.NullText = "Kullanıcı Adı";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(186, 22);
            this.txtKullaniciAdi.TabIndex = 0;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(3, 156);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSifre.Properties.Appearance.Options.UseFont = true;
            this.txtSifre.Properties.NullText = "Şifre";
            this.txtSifre.Properties.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(186, 22);
            this.txtSifre.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 26);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "GİRİŞ YAP";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(193, 221);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(236, 65);
            this.pictureEdit1.TabIndex = 3;
            // 
            // BtnGiris
            // 
            this.BtnGiris.Appearance.BackColor = System.Drawing.Color.Black;
            this.BtnGiris.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGiris.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnGiris.Appearance.Options.UseBackColor = true;
            this.BtnGiris.Appearance.Options.UseFont = true;
            this.BtnGiris.Appearance.Options.UseForeColor = true;
            this.BtnGiris.Appearance.Options.UseTextOptions = true;
            this.BtnGiris.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.BtnGiris.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.BtnGiris.Location = new System.Drawing.Point(233, 221);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(196, 42);
            this.BtnGiris.TabIndex = 4;
            this.BtnGiris.Text = "GİRİŞ";
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BtnKayıt);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtKullaniciAdi);
            this.panel1.Controls.Add(this.txtSifre);
            this.panel1.Location = new System.Drawing.Point(233, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 224);
            this.panel1.TabIndex = 5;
            // 
            // BtnKayıt
            // 
            this.BtnKayıt.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKayıt.Appearance.Options.UseFont = true;
            this.BtnKayıt.Location = new System.Drawing.Point(61, 9);
            this.BtnKayıt.Name = "BtnKayıt";
            this.BtnKayıt.Size = new System.Drawing.Size(79, 26);
            this.BtnKayıt.TabIndex = 3;
            this.BtnKayıt.Text = "KAYIT OL";
            this.BtnKayıt.Click += new System.EventHandler(this.BtnKayıt_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BtnKayit);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.textEdit2);
            this.panel2.Controls.Add(this.textEdit1);
            this.panel2.Location = new System.Drawing.Point(427, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 224);
            this.panel2.TabIndex = 6;
            // 
            // BtnKayit
            // 
            this.BtnKayit.Appearance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKayit.Appearance.Options.UseFont = true;
            this.BtnKayit.Location = new System.Drawing.Point(54, 194);
            this.BtnKayit.Name = "BtnKayit";
            this.BtnKayit.Size = new System.Drawing.Size(75, 23);
            this.BtnKayit.TabIndex = 7;
            this.BtnKayit.Text = "KAYIT OL";
            this.BtnKayit.Click += new System.EventHandler(this.BtnKayit_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 26);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "KAYIT OL";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(6, 158);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.NullText = "Şifre";
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(186, 22);
            this.textEdit2.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(6, 107);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.NullText = "Kullanıcı Adı";
            this.textEdit1.Size = new System.Drawing.Size(186, 22);
            this.textEdit1.TabIndex = 1;
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 283);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGiris";
            this.Text = "Giriş Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private LabelControl labelControl1;
        private PictureEdit pictureEdit1;
        private LabelControl BtnGiris;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private SimpleButton BtnKayit;
        private LabelControl labelControl2;
        private TextEdit textEdit2;
        private TextEdit textEdit1;
        private HyperlinkLabelControl BtnKayıt;
    }
}
