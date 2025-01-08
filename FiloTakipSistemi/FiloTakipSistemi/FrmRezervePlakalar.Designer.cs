namespace FiloTakipSistemi
{
    partial class FrmRezervePlakalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRezervePlakalar));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblRezerveBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet27 = new FiloTakipSistemi.FiloTakipDataSet27();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPlakaDurumu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeferTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurucuAdSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurucuTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurucuTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeNoktasi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeIl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeIlcesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTonaj = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimNoktasi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimIli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimIlcesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNavlunTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSonNokta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRezervasyonTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tblRezerveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet18 = new FiloTakipSistemi.FiloTakipDataSet18();
            this.tblRezerveTableAdapter = new FiloTakipSistemi.FiloTakipDataSet18TableAdapters.TblRezerveTableAdapter();
            this.BtnSorgula = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAtamaYap = new DevExpress.XtraEditors.SimpleButton();
            this.tblRezerveTableAdapter1 = new FiloTakipSistemi.FiloTakipDataSet27TableAdapters.TblRezerveTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRezerveBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRezerveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet18)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.tblRezerveBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(12, 94);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1616, 777);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblRezerveBindingSource1
            // 
            this.tblRezerveBindingSource1.DataMember = "TblRezerve";
            this.tblRezerveBindingSource1.DataSource = this.filoTakipDataSet27;
            // 
            // filoTakipDataSet27
            // 
            this.filoTakipDataSet27.DataSetName = "FiloTakipDataSet27";
            this.filoTakipDataSet27.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPlakaDurumu,
            this.colSeferTarihi,
            this.colPlaka,
            this.colSurucuAdSoyad,
            this.colSurucuTelefon,
            this.colSurucuTC,
            this.colMusteriAdi,
            this.colYuklemeNoktasi,
            this.colYuklemeIl,
            this.colYuklemeIlcesi,
            this.colTonaj,
            this.colTeslimNoktasi,
            this.colTeslimIli,
            this.colTeslimIlcesi,
            this.colNavlunTutar,
            this.colAciklama,
            this.colSonNokta,
            this.colRezervasyonTarihi,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPlakaDurumu
            // 
            this.colPlakaDurumu.FieldName = "PlakaDurumu";
            this.colPlakaDurumu.MinWidth = 25;
            this.colPlakaDurumu.Name = "colPlakaDurumu";
            this.colPlakaDurumu.Visible = true;
            this.colPlakaDurumu.VisibleIndex = 0;
            this.colPlakaDurumu.Width = 94;
            // 
            // colSeferTarihi
            // 
            this.colSeferTarihi.FieldName = "SeferTarihi";
            this.colSeferTarihi.MinWidth = 25;
            this.colSeferTarihi.Name = "colSeferTarihi";
            this.colSeferTarihi.Visible = true;
            this.colSeferTarihi.VisibleIndex = 1;
            this.colSeferTarihi.Width = 94;
            // 
            // colPlaka
            // 
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.MinWidth = 25;
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 2;
            this.colPlaka.Width = 94;
            // 
            // colSurucuAdSoyad
            // 
            this.colSurucuAdSoyad.FieldName = "SurucuAdSoyad";
            this.colSurucuAdSoyad.MinWidth = 25;
            this.colSurucuAdSoyad.Name = "colSurucuAdSoyad";
            this.colSurucuAdSoyad.Visible = true;
            this.colSurucuAdSoyad.VisibleIndex = 3;
            this.colSurucuAdSoyad.Width = 94;
            // 
            // colSurucuTelefon
            // 
            this.colSurucuTelefon.FieldName = "SurucuTelefon";
            this.colSurucuTelefon.MinWidth = 25;
            this.colSurucuTelefon.Name = "colSurucuTelefon";
            this.colSurucuTelefon.Visible = true;
            this.colSurucuTelefon.VisibleIndex = 4;
            this.colSurucuTelefon.Width = 94;
            // 
            // colSurucuTC
            // 
            this.colSurucuTC.FieldName = "SurucuTC";
            this.colSurucuTC.MinWidth = 25;
            this.colSurucuTC.Name = "colSurucuTC";
            this.colSurucuTC.Visible = true;
            this.colSurucuTC.VisibleIndex = 5;
            this.colSurucuTC.Width = 94;
            // 
            // colMusteriAdi
            // 
            this.colMusteriAdi.FieldName = "MusteriAdi";
            this.colMusteriAdi.MinWidth = 25;
            this.colMusteriAdi.Name = "colMusteriAdi";
            this.colMusteriAdi.Visible = true;
            this.colMusteriAdi.VisibleIndex = 6;
            this.colMusteriAdi.Width = 94;
            // 
            // colYuklemeNoktasi
            // 
            this.colYuklemeNoktasi.FieldName = "YuklemeNoktasi";
            this.colYuklemeNoktasi.MinWidth = 25;
            this.colYuklemeNoktasi.Name = "colYuklemeNoktasi";
            this.colYuklemeNoktasi.Visible = true;
            this.colYuklemeNoktasi.VisibleIndex = 7;
            this.colYuklemeNoktasi.Width = 94;
            // 
            // colYuklemeIl
            // 
            this.colYuklemeIl.FieldName = "YuklemeIl";
            this.colYuklemeIl.MinWidth = 25;
            this.colYuklemeIl.Name = "colYuklemeIl";
            this.colYuklemeIl.Visible = true;
            this.colYuklemeIl.VisibleIndex = 8;
            this.colYuklemeIl.Width = 94;
            // 
            // colYuklemeIlcesi
            // 
            this.colYuklemeIlcesi.FieldName = "YuklemeIlcesi";
            this.colYuklemeIlcesi.MinWidth = 25;
            this.colYuklemeIlcesi.Name = "colYuklemeIlcesi";
            this.colYuklemeIlcesi.Visible = true;
            this.colYuklemeIlcesi.VisibleIndex = 9;
            this.colYuklemeIlcesi.Width = 94;
            // 
            // colTonaj
            // 
            this.colTonaj.FieldName = "Tonaj";
            this.colTonaj.MinWidth = 25;
            this.colTonaj.Name = "colTonaj";
            this.colTonaj.Visible = true;
            this.colTonaj.VisibleIndex = 10;
            this.colTonaj.Width = 94;
            // 
            // colTeslimNoktasi
            // 
            this.colTeslimNoktasi.FieldName = "TeslimNoktasi";
            this.colTeslimNoktasi.MinWidth = 25;
            this.colTeslimNoktasi.Name = "colTeslimNoktasi";
            this.colTeslimNoktasi.Visible = true;
            this.colTeslimNoktasi.VisibleIndex = 11;
            this.colTeslimNoktasi.Width = 94;
            // 
            // colTeslimIli
            // 
            this.colTeslimIli.FieldName = "TeslimIli";
            this.colTeslimIli.MinWidth = 25;
            this.colTeslimIli.Name = "colTeslimIli";
            this.colTeslimIli.Visible = true;
            this.colTeslimIli.VisibleIndex = 12;
            this.colTeslimIli.Width = 94;
            // 
            // colTeslimIlcesi
            // 
            this.colTeslimIlcesi.FieldName = "TeslimIlcesi";
            this.colTeslimIlcesi.MinWidth = 25;
            this.colTeslimIlcesi.Name = "colTeslimIlcesi";
            this.colTeslimIlcesi.Visible = true;
            this.colTeslimIlcesi.VisibleIndex = 13;
            this.colTeslimIlcesi.Width = 94;
            // 
            // colNavlunTutar
            // 
            this.colNavlunTutar.FieldName = "NavlunTutar";
            this.colNavlunTutar.MinWidth = 25;
            this.colNavlunTutar.Name = "colNavlunTutar";
            this.colNavlunTutar.Visible = true;
            this.colNavlunTutar.VisibleIndex = 14;
            this.colNavlunTutar.Width = 94;
            // 
            // colAciklama
            // 
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.MinWidth = 25;
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 15;
            this.colAciklama.Width = 94;
            // 
            // colSonNokta
            // 
            this.colSonNokta.FieldName = "SonNokta";
            this.colSonNokta.MinWidth = 25;
            this.colSonNokta.Name = "colSonNokta";
            this.colSonNokta.Visible = true;
            this.colSonNokta.VisibleIndex = 16;
            this.colSonNokta.Width = 94;
            // 
            // colRezervasyonTarihi
            // 
            this.colRezervasyonTarihi.FieldName = "RezervasyonTarihi";
            this.colRezervasyonTarihi.MinWidth = 25;
            this.colRezervasyonTarihi.Name = "colRezervasyonTarihi";
            this.colRezervasyonTarihi.Visible = true;
            this.colRezervasyonTarihi.VisibleIndex = 17;
            this.colRezervasyonTarihi.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tahmini Varış";
            this.gridColumn1.FieldName = "TahminiVaris";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 18;
            this.gridColumn1.Width = 94;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // tblRezerveBindingSource
            // 
            this.tblRezerveBindingSource.DataMember = "TblRezerve";
            this.tblRezerveBindingSource.DataSource = this.filoTakipDataSet18;
            // 
            // filoTakipDataSet18
            // 
            this.filoTakipDataSet18.DataSetName = "FiloTakipDataSet18";
            this.filoTakipDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblRezerveTableAdapter
            // 
            this.tblRezerveTableAdapter.ClearBeforeFill = true;
            // 
            // BtnSorgula
            // 
            this.BtnSorgula.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSorgula.Appearance.BorderColor = System.Drawing.Color.White;
            this.BtnSorgula.Appearance.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSorgula.Appearance.Options.UseBackColor = true;
            this.BtnSorgula.Appearance.Options.UseBorderColor = true;
            this.BtnSorgula.Appearance.Options.UseFont = true;
            this.BtnSorgula.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSorgula.ImageOptions.Image")));
            this.BtnSorgula.Location = new System.Drawing.Point(16, 19);
            this.BtnSorgula.Name = "BtnSorgula";
            this.BtnSorgula.Size = new System.Drawing.Size(163, 47);
            this.BtnSorgula.TabIndex = 1;
            this.BtnSorgula.Text = "SORGULA";
            this.BtnSorgula.Click += new System.EventHandler(this.BtnSorgula_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnAtamaYap);
            this.panel1.Controls.Add(this.BtnSorgula);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1616, 83);
            this.panel1.TabIndex = 2;
            // 
            // BtnAtamaYap
            // 
            this.BtnAtamaYap.Appearance.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnAtamaYap.Appearance.BorderColor = System.Drawing.Color.White;
            this.BtnAtamaYap.Appearance.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAtamaYap.Appearance.Options.UseBackColor = true;
            this.BtnAtamaYap.Appearance.Options.UseBorderColor = true;
            this.BtnAtamaYap.Appearance.Options.UseFont = true;
            this.BtnAtamaYap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnAtamaYap.ImageOptions.Image")));
            this.BtnAtamaYap.Location = new System.Drawing.Point(185, 19);
            this.BtnAtamaYap.Name = "BtnAtamaYap";
            this.BtnAtamaYap.Size = new System.Drawing.Size(163, 47);
            this.BtnAtamaYap.TabIndex = 2;
            this.BtnAtamaYap.Text = "ATAMA YAP";
            this.BtnAtamaYap.Click += new System.EventHandler(this.BtnAtamaYap_Click);
            // 
            // tblRezerveTableAdapter1
            // 
            this.tblRezerveTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmRezervePlakalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 883);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmRezervePlakalar";
            this.Text = "REZERVE PLAKALAR";
            this.Load += new System.EventHandler(this.FrmRezervePlakalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRezerveBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblRezerveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet18)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private FiloTakipDataSet18 filoTakipDataSet18;
        private System.Windows.Forms.BindingSource tblRezerveBindingSource;
        private FiloTakipDataSet18TableAdapters.TblRezerveTableAdapter tblRezerveTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colPlakaDurumu;
        private DevExpress.XtraGrid.Columns.GridColumn colSeferTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colSurucuAdSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colSurucuTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colSurucuTC;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeNoktasi;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeIl;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeIlcesi;
        private DevExpress.XtraGrid.Columns.GridColumn colTonaj;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimNoktasi;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimIli;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimIlcesi;
        private DevExpress.XtraGrid.Columns.GridColumn colNavlunTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colSonNokta;
        private DevExpress.XtraGrid.Columns.GridColumn colRezervasyonTarihi;
        private DevExpress.XtraEditors.SimpleButton BtnSorgula;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton BtnAtamaYap;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private FiloTakipDataSet27 filoTakipDataSet27;
        private System.Windows.Forms.BindingSource tblRezerveBindingSource1;
        private FiloTakipDataSet27TableAdapters.TblRezerveTableAdapter tblRezerveTableAdapter1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}