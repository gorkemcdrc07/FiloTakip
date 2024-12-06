namespace FiloTakipSistemi
{
    partial class FrmPlanlamaEkranı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanlamaEkranı));
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridControlSiparis = new DevExpress.XtraGrid.GridControl();
            this.tblSiparisListesiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet18 = new FiloTakipSistemi.FiloTakipDataSet18();
            this.gridViewSiparis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSourceSiparis = new System.Windows.Forms.BindingSource(this.components);
            this.tblPlakaGunlukRaporBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet2 = new FiloTakipSistemi.FiloTakipDataSet2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.gridControlPlakaOnerisi = new DevExpress.XtraGrid.GridControl();
            this.bindingSourcePlakaOnerisi = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.plakaÖnerisiYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satırSilmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblPlakaGunlukRaporTableAdapter = new FiloTakipSistemi.FiloTakipDataSet2TableAdapters.TblPlakaGunlukRaporTableAdapter();
            this.tblSiparisListesiTableAdapter = new FiloTakipSistemi.FiloTakipDataSet18TableAdapters.TblSiparisListesiTableAdapter();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnAtamaYap = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSiparisListesiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaGunlukRaporBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPlakaOnerisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePlakaOnerisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // gridControlSiparis
            // 
            this.gridControlSiparis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlSiparis.DataSource = this.tblSiparisListesiBindingSource;
            this.gridControlSiparis.Location = new System.Drawing.Point(0, 53);
            this.gridControlSiparis.MainView = this.gridViewSiparis;
            this.gridControlSiparis.Name = "gridControlSiparis";
            this.gridControlSiparis.Size = new System.Drawing.Size(1230, 894);
            this.gridControlSiparis.TabIndex = 0;
            this.gridControlSiparis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSiparis});
            // 
            // tblSiparisListesiBindingSource
            // 
            this.tblSiparisListesiBindingSource.DataMember = "TblSiparisListesi";
            this.tblSiparisListesiBindingSource.DataSource = this.filoTakipDataSet18;
            // 
            // filoTakipDataSet18
            // 
            this.filoTakipDataSet18.DataSetName = "FiloTakipDataSet18";
            this.filoTakipDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridViewSiparis
            // 
            this.gridViewSiparis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gridViewSiparis.GridControl = this.gridControlSiparis;
            this.gridViewSiparis.Name = "gridViewSiparis";
            this.gridViewSiparis.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Plaka";
            this.gridColumn1.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn1.FieldName = "Plaka";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Müşteri Adı";
            this.gridColumn2.FieldName = "MusteriAdi";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Hizmet Tipi";
            this.gridColumn3.FieldName = "HizmetTipi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Proje Adı";
            this.gridColumn4.FieldName = "ProjeAdi";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Araç Tipi";
            this.gridColumn5.FieldName = "AracTipi";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Sipariş Tarihi";
            this.gridColumn6.FieldName = "SiparisTarihi";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sipariş No";
            this.gridColumn7.FieldName = "SiparisNo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Yükleme Tarihi";
            this.gridColumn8.FieldName = "YuklemeTarihi";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Nokta Sayısı";
            this.gridColumn9.FieldName = "NoktaSayisi";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Yükleme Noktası";
            this.gridColumn10.FieldName = "YuklemeNoktasi";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Yükleme İl";
            this.gridColumn11.FieldName = "YuklemeIl";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Yükleme İlçe";
            this.gridColumn12.FieldName = "YuklemeIlce";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Teslim Noktası";
            this.gridColumn13.FieldName = "TeslimNoktasi";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Teslim İl";
            this.gridColumn14.FieldName = "TeslimIl";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Teslim İlçe";
            this.gridColumn15.FieldName = "TeslimIlce";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Pozisyon No";
            this.gridColumn16.FieldName = "PozisyonNo";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 15;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Tahmini Km";
            this.gridColumn17.FieldName = "TahminiKm";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 16;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Tahmini Varış";
            this.gridColumn18.FieldName = "TahminiVarisSaatTarih";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 17;
            // 
            // tblPlakaGunlukRaporBindingSource
            // 
            this.tblPlakaGunlukRaporBindingSource.DataMember = "TblPlakaGunlukRapor";
            this.tblPlakaGunlukRaporBindingSource.DataSource = this.filoTakipDataSet2;
            // 
            // filoTakipDataSet2
            // 
            this.filoTakipDataSet2.DataSetName = "FiloTakipDataSet2";
            this.filoTakipDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureEdit1);
            this.panel1.Controls.Add(this.gridControlPlakaOnerisi);
            this.panel1.Location = new System.Drawing.Point(0, 714);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 327);
            this.panel1.TabIndex = 3;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(1886, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(15, 22);
            this.pictureEdit1.TabIndex = 4;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.PictureEdit1_Click);
            // 
            // gridControlPlakaOnerisi
            // 
            this.gridControlPlakaOnerisi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPlakaOnerisi.DataSource = this.bindingSourcePlakaOnerisi;
            this.gridControlPlakaOnerisi.Location = new System.Drawing.Point(0, 0);
            this.gridControlPlakaOnerisi.MainView = this.gridView1;
            this.gridControlPlakaOnerisi.Name = "gridControlPlakaOnerisi";
            this.gridControlPlakaOnerisi.Size = new System.Drawing.Size(1230, 233);
            this.gridControlPlakaOnerisi.TabIndex = 5;
            this.gridControlPlakaOnerisi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlPlakaOnerisi;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plakaÖnerisiYapToolStripMenuItem,
            this.satırSilmeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 48);
            // 
            // plakaÖnerisiYapToolStripMenuItem
            // 
            this.plakaÖnerisiYapToolStripMenuItem.Name = "plakaÖnerisiYapToolStripMenuItem";
            this.plakaÖnerisiYapToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.plakaÖnerisiYapToolStripMenuItem.Text = "Plaka Önerisi Yap";
            this.plakaÖnerisiYapToolStripMenuItem.Click += new System.EventHandler(this.plakaÖnerisiYapToolStripMenuItem_Click);
            // 
            // satırSilmeToolStripMenuItem
            // 
            this.satırSilmeToolStripMenuItem.Name = "satırSilmeToolStripMenuItem";
            this.satırSilmeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.satırSilmeToolStripMenuItem.Text = "Satır Silme";
            this.satırSilmeToolStripMenuItem.Click += new System.EventHandler(this.satırSilmeToolStripMenuItem_Click);
            // 
            // tblPlakaGunlukRaporTableAdapter
            // 
            this.tblPlakaGunlukRaporTableAdapter.ClearBeforeFill = true;
            // 
            // tblSiparisListesiTableAdapter
            // 
            this.tblSiparisListesiTableAdapter.ClearBeforeFill = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(1098, 96);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAtamaYap);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1230, 44);
            this.panel2.TabIndex = 5;
            // 
            // BtnAtamaYap
            // 
            this.BtnAtamaYap.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnAtamaYap.Appearance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAtamaYap.Appearance.ForeColor = System.Drawing.Color.Black;
            this.BtnAtamaYap.Appearance.Options.UseBackColor = true;
            this.BtnAtamaYap.Appearance.Options.UseFont = true;
            this.BtnAtamaYap.Appearance.Options.UseForeColor = true;
            this.BtnAtamaYap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAtamaYap.ImageOptions.SvgImage")));
            this.BtnAtamaYap.Location = new System.Drawing.Point(12, 4);
            this.BtnAtamaYap.Name = "BtnAtamaYap";
            this.BtnAtamaYap.Size = new System.Drawing.Size(182, 37);
            this.BtnAtamaYap.TabIndex = 0;
            this.BtnAtamaYap.Text = "Atama Yap";
            this.BtnAtamaYap.Click += new System.EventHandler(this.BtnAtamaYap_Click);
            // 
            // FrmPlanlamaEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 947);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControlSiparis);
            this.Name = "FrmPlanlamaEkranı";
            this.Text = "PLANLAMA EKRANI";
            this.Load += new System.EventHandler(this.FrmPlanlamaEkranı_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSiparisListesiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPlakaGunlukRaporBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPlakaOnerisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePlakaOnerisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSiparis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plakaÖnerisiYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satırSilmeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        public DevExpress.XtraGrid.GridControl gridControlSiparis;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public System.Windows.Forms.BindingSource bindingSourceSiparis;
        private DevExpress.XtraGrid.GridControl gridControlPlakaOnerisi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSourcePlakaOnerisi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private FiloTakipDataSet2 filoTakipDataSet2;
        private System.Windows.Forms.BindingSource tblPlakaGunlukRaporBindingSource;
        private FiloTakipDataSet2TableAdapters.TblPlakaGunlukRaporTableAdapter tblPlakaGunlukRaporTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private FiloTakipDataSet18 filoTakipDataSet18;
        private System.Windows.Forms.BindingSource tblSiparisListesiBindingSource;
        private FiloTakipDataSet18TableAdapters.TblSiparisListesiTableAdapter tblSiparisListesiTableAdapter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton BtnAtamaYap;
    }
}