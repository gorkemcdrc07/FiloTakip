namespace FiloTakipSistemi
{
    partial class FrmRapor
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
            this.tblPlakaDurumlarıBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet21 = new FiloTakipSistemi.FiloTakipDataSet21();
            this.tblPlakaDurumlarıBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet5 = new FiloTakipSistemi.FiloTakipDataSet5();
            this.tblPlakaDurumlarıTableAdapter = new FiloTakipSistemi.FiloTakipDataSet5TableAdapters.TblPlakaDurumlarıTableAdapter();
            this.tblPlakaDurumlarıTableAdapter1 = new FiloTakipSistemi.FiloTakipDataSet21TableAdapters.TblPlakaDurumlarıTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tblPlakaDurumlarıBindingSource1
            // 
            this.tblPlakaDurumlarıBindingSource1.DataMember = "TblPlakaDurumları";
            this.tblPlakaDurumlarıBindingSource1.DataSource = this.filoTakipDataSet21;
            // 
            // filoTakipDataSet21
            // 
            this.filoTakipDataSet21.DataSetName = "FiloTakipDataSet21";
            this.filoTakipDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblPlakaDurumlarıBindingSource
            // 
            this.tblPlakaDurumlarıBindingSource.DataMember = "TblPlakaDurumları";
            this.tblPlakaDurumlarıBindingSource.DataSource = this.filoTakipDataSet5;
            // 
            // filoTakipDataSet5
            // 
            this.filoTakipDataSet5.DataSetName = "FiloTakipDataSet5";
            this.filoTakipDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblPlakaDurumlarıTableAdapter
            // 
            this.tblPlakaDurumlarıTableAdapter.ClearBeforeFill = true;
            // 
            // tblPlakaDurumlarıTableAdapter1
            // 
            this.tblPlakaDurumlarıTableAdapter1.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(620, 521);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(638, 12);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(620, 521);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // FrmRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1636, 700);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRapor";
            this.Text = "RAPOR";
            this.Load += new System.EventHandler(this.FrmRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FiloTakipDataSet5 filoTakipDataSet5;
        private System.Windows.Forms.BindingSource tblPlakaDurumlarıBindingSource;
        private FiloTakipDataSet5TableAdapters.TblPlakaDurumlarıTableAdapter tblPlakaDurumlarıTableAdapter;
        private FiloTakipDataSet21 filoTakipDataSet21;
        private System.Windows.Forms.BindingSource tblPlakaDurumlarıBindingSource1;
        private FiloTakipDataSet21TableAdapters.TblPlakaDurumlarıTableAdapter tblPlakaDurumlarıTableAdapter1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}