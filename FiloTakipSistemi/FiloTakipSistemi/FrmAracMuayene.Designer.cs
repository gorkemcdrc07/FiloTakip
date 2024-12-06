namespace FiloTakipSistemi
{
    partial class FrmAracMuayene
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
            this.gridControlAracMuayene = new DevExpress.XtraGrid.GridControl();
            this.gridViewAracMuayene = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAracMuayene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAracMuayene)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAracMuayene
            // 
            this.gridControlAracMuayene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAracMuayene.Location = new System.Drawing.Point(0, 0);
            this.gridControlAracMuayene.MainView = this.gridViewAracMuayene;
            this.gridControlAracMuayene.Name = "gridControlAracMuayene";
            this.gridControlAracMuayene.Size = new System.Drawing.Size(1230, 947);
            this.gridControlAracMuayene.TabIndex = 0;
            this.gridControlAracMuayene.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAracMuayene});
            // 
            // gridViewAracMuayene
            // 
            this.gridViewAracMuayene.GridControl = this.gridControlAracMuayene;
            this.gridViewAracMuayene.Name = "gridViewAracMuayene";
            this.gridViewAracMuayene.OptionsView.ShowGroupPanel = false;
            // 
            // FrmAracMuayene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 947);
            this.Controls.Add(this.gridControlAracMuayene);
            this.Name = "FrmAracMuayene";
            this.Text = "FrmAracMuayene";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAracMuayene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAracMuayene)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAracMuayene;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAracMuayene;
    }
}