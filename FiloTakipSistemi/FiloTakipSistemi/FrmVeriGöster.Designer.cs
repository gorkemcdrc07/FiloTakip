namespace FiloTakipSistemi
{
    partial class FrmVeriGöster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVeriGöster));
            this.gridControlGoster = new DevExpress.XtraGrid.GridControl();
            this.gridViewGoster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAktar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGoster)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlGoster
            // 
            this.gridControlGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlGoster.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlGoster.Location = new System.Drawing.Point(0, 71);
            this.gridControlGoster.MainView = this.gridViewGoster;
            this.gridControlGoster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControlGoster.Name = "gridControlGoster";
            this.gridControlGoster.Size = new System.Drawing.Size(1640, 1079);
            this.gridControlGoster.TabIndex = 1;
            this.gridControlGoster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGoster});
            // 
            // gridViewGoster
            // 
            this.gridViewGoster.DetailHeight = 431;
            this.gridViewGoster.GridControl = this.gridControlGoster;
            this.gridViewGoster.Name = "gridViewGoster";
            this.gridViewGoster.OptionsEditForm.PopupEditFormWidth = 1067;
            this.gridViewGoster.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAktar);
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1640, 54);
            this.panel1.TabIndex = 2;
            // 
            // BtnAktar
            // 
            this.BtnAktar.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.BtnAktar.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAktar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnAktar.Appearance.Options.UseBackColor = true;
            this.BtnAktar.Appearance.Options.UseFont = true;
            this.BtnAktar.Appearance.Options.UseForeColor = true;
            this.BtnAktar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAktar.ImageOptions.SvgImage")));
            this.BtnAktar.Location = new System.Drawing.Point(16, 5);
            this.BtnAktar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAktar.Name = "BtnAktar";
            this.BtnAktar.Size = new System.Drawing.Size(243, 46);
            this.BtnAktar.TabIndex = 0;
            this.BtnAktar.Text = "Sipariş Listesine Aktar";
            this.BtnAktar.Click += new System.EventHandler(this.BtnAktar_Click);
            // 
            // FrmVeriGöster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 1166);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControlGoster);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmVeriGöster";
            this.Text = "VeriGöster";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGoster)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraGrid.GridControl gridControlGoster;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewGoster;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton BtnAktar;
    }
}