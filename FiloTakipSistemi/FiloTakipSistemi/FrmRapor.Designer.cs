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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblPlakaDurumlarıBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet21 = new FiloTakipSistemi.FiloTakipDataSet21();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblPlakaDurumlarıBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet5 = new FiloTakipSistemi.FiloTakipDataSet5();
            this.tblPlakaDurumlarıTableAdapter = new FiloTakipSistemi.FiloTakipDataSet5TableAdapters.TblPlakaDurumlarıTableAdapter();
            this.tblPlakaDurumlarıTableAdapter1 = new FiloTakipSistemi.FiloTakipDataSet21TableAdapters.TblPlakaDurumlarıTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet5)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblPlakaDurumlarıBindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1227, 500);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Plaka";
            this.gridColumn1.FieldName = "Plaka";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sürücü Adı";
            this.gridColumn2.FieldName = "SurucuAdı";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sefer Tarihi";
            this.gridColumn3.FieldName = "SeferTarihi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Yükleme Noktası";
            this.gridColumn4.FieldName = "YuklemeNoktası";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Teslim Noktası";
            this.gridColumn5.FieldName = "TeslimNoktası";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Durum";
            this.gridColumn6.FieldName = "Durum";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Açıklama";
            this.gridColumn9.FieldName = "Aciklama";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
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
            // FrmRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 500);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmRapor";
            this.Text = "RAPOR";
            this.Load += new System.EventHandler(this.FrmRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaDurumlarıBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private FiloTakipDataSet5 filoTakipDataSet5;
        private System.Windows.Forms.BindingSource tblPlakaDurumlarıBindingSource;
        private FiloTakipDataSet5TableAdapters.TblPlakaDurumlarıTableAdapter tblPlakaDurumlarıTableAdapter;
        private FiloTakipDataSet21 filoTakipDataSet21;
        private System.Windows.Forms.BindingSource tblPlakaDurumlarıBindingSource1;
        private FiloTakipDataSet21TableAdapters.TblPlakaDurumlarıTableAdapter tblPlakaDurumlarıTableAdapter1;
    }
}