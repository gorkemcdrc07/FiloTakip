namespace FiloTakipSistemi
{
    partial class FrmVeriEklemeEkranı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVeriEklemeEkranı));
            this.gridControlVeriler = new DevExpress.XtraGrid.GridControl();
            this.tblDtaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filoTakipDataSet26 = new FiloTakipSistemi.FiloTakipDataSet26();
            this.gridViewVeriler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMSOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirma = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProje = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHizmetTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstenilenAracTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisNumarasi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoktaSayisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeNoktasi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeIli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuklemeIlcesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisDurumu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimNoktasi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimIli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimIlcesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriSiparisNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteriReferansNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisAcan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisAcilisZamani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPozisyonNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamKg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblDtaTableAdapter = new FiloTakipSistemi.FiloTakipDataSet26TableAdapters.TblDtaTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVeriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDtaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVeriler)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlVeriler
            // 
            this.gridControlVeriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlVeriler.DataSource = this.tblDtaBindingSource;
            this.gridControlVeriler.Location = new System.Drawing.Point(0, 51);
            this.gridControlVeriler.MainView = this.gridViewVeriler;
            this.gridControlVeriler.Name = "gridControlVeriler";
            this.gridControlVeriler.Size = new System.Drawing.Size(1230, 884);
            this.gridControlVeriler.TabIndex = 3;
            this.gridControlVeriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVeriler});
            // 
            // tblDtaBindingSource
            // 
            this.tblDtaBindingSource.DataMember = "TblDta";
            this.tblDtaBindingSource.DataSource = this.filoTakipDataSet26;
            // 
            // filoTakipDataSet26
            // 
            this.filoTakipDataSet26.DataSetName = "FiloTakipDataSet26";
            this.filoTakipDataSet26.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridViewVeriler
            // 
            this.gridViewVeriler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReferansNo,
            this.colTMSOrderID,
            this.colFirma,
            this.colProje,
            this.colHizmetTipi,
            this.colIstenilenAracTipi,
            this.colSiparisNumarasi,
            this.colSiparisTarihi,
            this.colYuklemeTarihi,
            this.colTeslimTarihi,
            this.colNoktaSayisi,
            this.colYuklemeNoktasi,
            this.colYuklemeIli,
            this.colYuklemeIlcesi,
            this.colSiparisDurumu,
            this.colTeslimNoktasi,
            this.colTeslimIli,
            this.colTeslimIlcesi,
            this.colMusteriSiparisNo,
            this.colMusteriReferansNo,
            this.colAciklama,
            this.colSiparisAcan,
            this.colSiparisAcilisZamani,
            this.colPozisyonNo,
            this.colToplamKg});
            this.gridViewVeriler.GridControl = this.gridControlVeriler;
            this.gridViewVeriler.Name = "gridViewVeriler";
            this.gridViewVeriler.OptionsBehavior.Editable = false;
            this.gridViewVeriler.OptionsView.ShowGroupPanel = false;
            // 
            // colReferansNo
            // 
            this.colReferansNo.FieldName = "ReferansNo";
            this.colReferansNo.Name = "colReferansNo";
            this.colReferansNo.Visible = true;
            this.colReferansNo.VisibleIndex = 0;
            // 
            // colTMSOrderID
            // 
            this.colTMSOrderID.FieldName = "TMSOrderID";
            this.colTMSOrderID.Name = "colTMSOrderID";
            this.colTMSOrderID.Visible = true;
            this.colTMSOrderID.VisibleIndex = 1;
            // 
            // colFirma
            // 
            this.colFirma.FieldName = "Firma";
            this.colFirma.Name = "colFirma";
            this.colFirma.Visible = true;
            this.colFirma.VisibleIndex = 2;
            // 
            // colProje
            // 
            this.colProje.FieldName = "Proje";
            this.colProje.Name = "colProje";
            this.colProje.Visible = true;
            this.colProje.VisibleIndex = 3;
            // 
            // colHizmetTipi
            // 
            this.colHizmetTipi.FieldName = "HizmetTipi";
            this.colHizmetTipi.Name = "colHizmetTipi";
            this.colHizmetTipi.Visible = true;
            this.colHizmetTipi.VisibleIndex = 4;
            // 
            // colIstenilenAracTipi
            // 
            this.colIstenilenAracTipi.FieldName = "IstenilenAracTipi";
            this.colIstenilenAracTipi.Name = "colIstenilenAracTipi";
            this.colIstenilenAracTipi.Visible = true;
            this.colIstenilenAracTipi.VisibleIndex = 5;
            // 
            // colSiparisNumarasi
            // 
            this.colSiparisNumarasi.FieldName = "SiparisNumarasi";
            this.colSiparisNumarasi.Name = "colSiparisNumarasi";
            this.colSiparisNumarasi.Visible = true;
            this.colSiparisNumarasi.VisibleIndex = 6;
            // 
            // colSiparisTarihi
            // 
            this.colSiparisTarihi.FieldName = "SiparisTarihi";
            this.colSiparisTarihi.Name = "colSiparisTarihi";
            this.colSiparisTarihi.Visible = true;
            this.colSiparisTarihi.VisibleIndex = 7;
            // 
            // colYuklemeTarihi
            // 
            this.colYuklemeTarihi.FieldName = "YuklemeTarihi";
            this.colYuklemeTarihi.Name = "colYuklemeTarihi";
            this.colYuklemeTarihi.Visible = true;
            this.colYuklemeTarihi.VisibleIndex = 8;
            // 
            // colTeslimTarihi
            // 
            this.colTeslimTarihi.FieldName = "TeslimTarihi";
            this.colTeslimTarihi.Name = "colTeslimTarihi";
            this.colTeslimTarihi.Visible = true;
            this.colTeslimTarihi.VisibleIndex = 9;
            // 
            // colNoktaSayisi
            // 
            this.colNoktaSayisi.FieldName = "NoktaSayisi";
            this.colNoktaSayisi.Name = "colNoktaSayisi";
            this.colNoktaSayisi.Visible = true;
            this.colNoktaSayisi.VisibleIndex = 10;
            // 
            // colYuklemeNoktasi
            // 
            this.colYuklemeNoktasi.FieldName = "YuklemeNoktasi";
            this.colYuklemeNoktasi.Name = "colYuklemeNoktasi";
            this.colYuklemeNoktasi.Visible = true;
            this.colYuklemeNoktasi.VisibleIndex = 11;
            // 
            // colYuklemeIli
            // 
            this.colYuklemeIli.FieldName = "YuklemeIli";
            this.colYuklemeIli.Name = "colYuklemeIli";
            this.colYuklemeIli.Visible = true;
            this.colYuklemeIli.VisibleIndex = 12;
            // 
            // colYuklemeIlcesi
            // 
            this.colYuklemeIlcesi.FieldName = "YuklemeIlcesi";
            this.colYuklemeIlcesi.Name = "colYuklemeIlcesi";
            this.colYuklemeIlcesi.Visible = true;
            this.colYuklemeIlcesi.VisibleIndex = 13;
            // 
            // colSiparisDurumu
            // 
            this.colSiparisDurumu.FieldName = "SiparisDurumu";
            this.colSiparisDurumu.Name = "colSiparisDurumu";
            this.colSiparisDurumu.Visible = true;
            this.colSiparisDurumu.VisibleIndex = 14;
            // 
            // colTeslimNoktasi
            // 
            this.colTeslimNoktasi.FieldName = "TeslimNoktasi";
            this.colTeslimNoktasi.Name = "colTeslimNoktasi";
            this.colTeslimNoktasi.Visible = true;
            this.colTeslimNoktasi.VisibleIndex = 15;
            // 
            // colTeslimIli
            // 
            this.colTeslimIli.FieldName = "TeslimIli";
            this.colTeslimIli.Name = "colTeslimIli";
            this.colTeslimIli.Visible = true;
            this.colTeslimIli.VisibleIndex = 16;
            // 
            // colTeslimIlcesi
            // 
            this.colTeslimIlcesi.FieldName = "TeslimIlcesi";
            this.colTeslimIlcesi.Name = "colTeslimIlcesi";
            this.colTeslimIlcesi.Visible = true;
            this.colTeslimIlcesi.VisibleIndex = 17;
            // 
            // colMusteriSiparisNo
            // 
            this.colMusteriSiparisNo.FieldName = "MusteriSiparisNo";
            this.colMusteriSiparisNo.Name = "colMusteriSiparisNo";
            this.colMusteriSiparisNo.Visible = true;
            this.colMusteriSiparisNo.VisibleIndex = 18;
            // 
            // colMusteriReferansNo
            // 
            this.colMusteriReferansNo.FieldName = "MusteriReferansNo";
            this.colMusteriReferansNo.Name = "colMusteriReferansNo";
            this.colMusteriReferansNo.Visible = true;
            this.colMusteriReferansNo.VisibleIndex = 19;
            // 
            // colAciklama
            // 
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 20;
            // 
            // colSiparisAcan
            // 
            this.colSiparisAcan.FieldName = "SiparisAcan";
            this.colSiparisAcan.Name = "colSiparisAcan";
            this.colSiparisAcan.Visible = true;
            this.colSiparisAcan.VisibleIndex = 21;
            // 
            // colSiparisAcilisZamani
            // 
            this.colSiparisAcilisZamani.FieldName = "SiparisAcilisZamani";
            this.colSiparisAcilisZamani.Name = "colSiparisAcilisZamani";
            this.colSiparisAcilisZamani.Visible = true;
            this.colSiparisAcilisZamani.VisibleIndex = 22;
            // 
            // colPozisyonNo
            // 
            this.colPozisyonNo.FieldName = "PozisyonNo";
            this.colPozisyonNo.Name = "colPozisyonNo";
            this.colPozisyonNo.Visible = true;
            this.colPozisyonNo.VisibleIndex = 23;
            // 
            // colToplamKg
            // 
            this.colToplamKg.FieldName = "ToplamKg";
            this.colToplamKg.Name = "colToplamKg";
            this.colToplamKg.Visible = true;
            this.colToplamKg.VisibleIndex = 24;
            // 
            // tblDtaTableAdapter
            // 
            this.tblDtaTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 44);
            this.panel1.TabIndex = 4;
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.BackColor = System.Drawing.Color.Green;
            this.BtnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Appearance.Options.UseBackColor = true;
            this.BtnSave.Appearance.Options.UseForeColor = true;
            this.BtnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSave.ImageOptions.SvgImage")));
            this.BtnSave.Location = new System.Drawing.Point(12, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(131, 38);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "KAYDET";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmVeriEklemeEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 947);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControlVeriler);
            this.Name = "FrmVeriEklemeEkranı";
            this.Text = "FrmVeriEklemeEkranı";
            this.Load += new System.EventHandler(this.FrmVeriEklemeEkranı_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVeriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblDtaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filoTakipDataSet26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVeriler)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraGrid.GridControl gridControlVeriler;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewVeriler;
        private DevExpress.XtraGrid.Columns.GridColumn colReferansNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTMSOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn colFirma;
        private DevExpress.XtraGrid.Columns.GridColumn colProje;
        private DevExpress.XtraGrid.Columns.GridColumn colHizmetTipi;
        private DevExpress.XtraGrid.Columns.GridColumn colIstenilenAracTipi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisNumarasi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colNoktaSayisi;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeNoktasi;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeIli;
        private DevExpress.XtraGrid.Columns.GridColumn colYuklemeIlcesi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisDurumu;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimNoktasi;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimIli;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimIlcesi;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriSiparisNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteriReferansNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisAcan;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisAcilisZamani;
        private DevExpress.XtraGrid.Columns.GridColumn colPozisyonNo;
        private DevExpress.XtraGrid.Columns.GridColumn colToplamKg;
        private System.Windows.Forms.BindingSource tblDtaBindingSource;
        private FiloTakipDataSet26 filoTakipDataSet26;
        private FiloTakipDataSet26TableAdapters.TblDtaTableAdapter tblDtaTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
    }
}