namespace FiloTakipSistemi
{
    partial class FrmAracBilgileri
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
            this.gridControlAracBilgileri = new DevExpress.XtraGrid.GridControl();
            this.gridViewAracBilgileri = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAracBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAracBilgileri)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAracBilgileri
            // 
            this.gridControlAracBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.gridControlAracBilgileri.MainView = this.gridViewAracBilgileri;
            this.gridControlAracBilgileri.Name = "gridControlAracBilgileri";
            this.gridControlAracBilgileri.Size = new System.Drawing.Size(1230, 947);
            this.gridControlAracBilgileri.TabIndex = 0;
            this.gridControlAracBilgileri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAracBilgileri});
            // 
            // gridViewAracBilgileri
            // 
            this.gridViewAracBilgileri.GridControl = this.gridControlAracBilgileri;
            this.gridViewAracBilgileri.Name = "gridViewAracBilgileri";
            this.gridViewAracBilgileri.OptionsView.ShowGroupPanel = false;
            // 
            // FrmAracBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 947);
            this.Controls.Add(this.gridControlAracBilgileri);
            this.Name = "FrmAracBilgileri";
            this.Text = "FrmAracBilgileri";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAracBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAracBilgileri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAracBilgileri;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAracBilgileri;
    }
}