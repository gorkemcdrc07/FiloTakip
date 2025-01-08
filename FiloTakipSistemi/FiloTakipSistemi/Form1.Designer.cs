namespace FiloTakipSistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnVeriEkle = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPlanlamaEkrani = new DevExpress.XtraBars.BarButtonItem();
            this.BtnGorunumKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAtananPlakalar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.BtnBosAraclar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDoluAraclar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMuayeneTarih = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAracBilgileri = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAtamaYap = new DevExpress.XtraBars.BarButtonItem();
            this.BtnPlakaDurumları = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRapor = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAracDurumlarıDuzenle = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAracDurumBelirlemeKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSiparisListesi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.BtnRezerve = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMobiliz = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BtnVeriEkle,
            this.BtnPlanlamaEkrani,
            this.BtnGorunumKaydet,
            this.BtnAtananPlakalar,
            this.barButtonItem1,
            this.BtnBosAraclar,
            this.barButtonItem3,
            this.BtnDoluAraclar,
            this.BtnMuayeneTarih,
            this.BtnAracBilgileri,
            this.BtnAtamaYap,
            this.BtnPlakaDurumları,
            this.BtnRapor,
            this.BtnAracDurumlarıDuzenle,
            this.BtnAracDurumBelirlemeKaydet,
            this.BtnSiparisListesi,
            this.barButtonItem2,
            this.BtnRezerve,
            this.BtnMobiliz});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage5,
            this.ribbonPage2,
            this.ribbonPage3,
            this.ribbonPage4});
            this.ribbonControl1.Size = new System.Drawing.Size(1230, 150);
            // 
            // BtnVeriEkle
            // 
            this.BtnVeriEkle.Caption = "Veri Ekle";
            this.BtnVeriEkle.Id = 1;
            this.BtnVeriEkle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnVeriEkle.ImageOptions.SvgImage")));
            this.BtnVeriEkle.Name = "BtnVeriEkle";
            this.BtnVeriEkle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnVeriEkle_ItemClick);
            // 
            // BtnPlanlamaEkrani
            // 
            this.BtnPlanlamaEkrani.Caption = "Planlama Ekranı";
            this.BtnPlanlamaEkrani.Id = 2;
            this.BtnPlanlamaEkrani.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPlanlamaEkrani.ImageOptions.SvgImage")));
            this.BtnPlanlamaEkrani.Name = "BtnPlanlamaEkrani";
            this.BtnPlanlamaEkrani.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPlanlamaEkrani_ItemClick);
            // 
            // BtnGorunumKaydet
            // 
            this.BtnGorunumKaydet.Caption = "Görünüm Kaydet";
            this.BtnGorunumKaydet.Id = 3;
            this.BtnGorunumKaydet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnGorunumKaydet.ImageOptions.SvgImage")));
            this.BtnGorunumKaydet.Name = "BtnGorunumKaydet";
            // 
            // BtnAtananPlakalar
            // 
            this.BtnAtananPlakalar.Caption = "Atanan Plakalar";
            this.BtnAtananPlakalar.Id = 4;
            this.BtnAtananPlakalar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAtananPlakalar.ImageOptions.SvgImage")));
            this.BtnAtananPlakalar.Name = "BtnAtananPlakalar";
            this.BtnAtananPlakalar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAtananPlakalar_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // BtnBosAraclar
            // 
            this.BtnBosAraclar.Caption = "Boş Araçlar";
            this.BtnBosAraclar.Id = 6;
            this.BtnBosAraclar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnBosAraclar.ImageOptions.SvgImage")));
            this.BtnBosAraclar.Name = "BtnBosAraclar";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // BtnDoluAraclar
            // 
            this.BtnDoluAraclar.Caption = "Dolu Araçlar";
            this.BtnDoluAraclar.Id = 8;
            this.BtnDoluAraclar.Name = "BtnDoluAraclar";
            // 
            // BtnMuayeneTarih
            // 
            this.BtnMuayeneTarih.Caption = "Araç Muayene";
            this.BtnMuayeneTarih.Id = 9;
            this.BtnMuayeneTarih.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnMuayeneTarih.ImageOptions.SvgImage")));
            this.BtnMuayeneTarih.Name = "BtnMuayeneTarih";
            this.BtnMuayeneTarih.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMuayeneTarih_ItemClick);
            // 
            // BtnAracBilgileri
            // 
            this.BtnAracBilgileri.Caption = "Araç Bilgileri";
            this.BtnAracBilgileri.Id = 10;
            this.BtnAracBilgileri.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAracBilgileri.ImageOptions.SvgImage")));
            this.BtnAracBilgileri.Name = "BtnAracBilgileri";
            this.BtnAracBilgileri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAracBilgileri_ItemClick);
            // 
            // BtnAtamaYap
            // 
            this.BtnAtamaYap.Caption = "Atama Yap";
            this.BtnAtamaYap.Id = 11;
            this.BtnAtamaYap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAtamaYap.ImageOptions.SvgImage")));
            this.BtnAtamaYap.Name = "BtnAtamaYap";
            // 
            // BtnPlakaDurumları
            // 
            this.BtnPlakaDurumları.Caption = "Plaka Durumları";
            this.BtnPlakaDurumları.Id = 12;
            this.BtnPlakaDurumları.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnPlakaDurumları.ImageOptions.SvgImage")));
            this.BtnPlakaDurumları.Name = "BtnPlakaDurumları";
            this.BtnPlakaDurumları.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnPlakaDurumları_ItemClick);
            // 
            // BtnRapor
            // 
            this.BtnRapor.Caption = "Günlük Rapor";
            this.BtnRapor.Id = 13;
            this.BtnRapor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnRapor.ImageOptions.SvgImage")));
            this.BtnRapor.Name = "BtnRapor";
            this.BtnRapor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRapor_ItemClick);
            // 
            // BtnAracDurumlarıDuzenle
            // 
            this.BtnAracDurumlarıDuzenle.Caption = "Araç Durumlarını Düzenle";
            this.BtnAracDurumlarıDuzenle.Id = 14;
            this.BtnAracDurumlarıDuzenle.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnAracDurumlarıDuzenle.ImageOptions.SvgImage")));
            this.BtnAracDurumlarıDuzenle.Name = "BtnAracDurumlarıDuzenle";
            this.BtnAracDurumlarıDuzenle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAracDurumlarıDuzenle_ItemClick);
            // 
            // BtnAracDurumBelirlemeKaydet
            // 
            this.BtnAracDurumBelirlemeKaydet.Id = 16;
            this.BtnAracDurumBelirlemeKaydet.Name = "BtnAracDurumBelirlemeKaydet";
            // 
            // BtnSiparisListesi
            // 
            this.BtnSiparisListesi.Caption = "Sipariş Listesi";
            this.BtnSiparisListesi.Id = 17;
            this.BtnSiparisListesi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSiparisListesi.ImageOptions.SvgImage")));
            this.BtnSiparisListesi.Name = "BtnSiparisListesi";
            this.BtnSiparisListesi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSiparisListesi_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.ActAsDropDown = true;
            this.barButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem2.Caption = "Rezerve Plakalar";
            this.barButtonItem2.DropDownControl = this.galleryDropDown1;
            this.barButtonItem2.Id = 18;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Name = "galleryDropDown1";
            this.galleryDropDown1.Ribbon = this.ribbonControl1;
            // 
            // BtnRezerve
            // 
            this.BtnRezerve.Caption = "Rezerve Plakalar";
            this.BtnRezerve.Id = 19;
            this.BtnRezerve.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnRezerve.ImageOptions.LargeImage")));
            this.BtnRezerve.Name = "BtnRezerve";
            this.BtnRezerve.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRezerve_ItemClick);
            // 
            // BtnMobiliz
            // 
            this.BtnMobiliz.Caption = "MOBİLİZ";
            this.BtnMobiliz.Id = 20;
            this.BtnMobiliz.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnMobiliz.ImageOptions.SvgImage")));
            this.BtnMobiliz.Name = "BtnMobiliz";
            this.BtnMobiliz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMobiliz_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Ana Sayfa";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnVeriEkle);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSiparisListesi);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnPlanlamaEkrani);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "PLANLAMA";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.BtnAtananPlakalar);
            this.ribbonPageGroup3.ItemLinks.Add(this.BtnRezerve);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "TAKİP";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Araç Durumları";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.BtnAracDurumlarıDuzenle);
            this.ribbonPageGroup4.ItemLinks.Add(this.BtnAracDurumBelirlemeKaydet);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Araç Muayene";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.BtnMuayeneTarih);
            this.ribbonPageGroup5.ItemLinks.Add(this.BtnAracBilgileri);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ARAÇ MUAYENE";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Günlük Rapor";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.BtnRapor);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7});
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Mobiliz";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.BtnMobiliz);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(603, 371);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(115, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "Yükleniyor Bekleyiniz...";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(538, 403);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(233, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 853);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BtnVeriEkle;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem BtnPlanlamaEkrani;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BtnGorunumKaydet;
        private DevExpress.XtraBars.BarButtonItem BtnAtananPlakalar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem BtnBosAraclar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem BtnDoluAraclar;
        private DevExpress.XtraBars.BarButtonItem BtnMuayeneTarih;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem BtnAracBilgileri;
        private DevExpress.XtraBars.BarButtonItem BtnAtamaYap;
        private DevExpress.XtraBars.BarButtonItem BtnPlakaDurumları;
        private DevExpress.XtraBars.BarButtonItem BtnRapor;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem BtnAracDurumlarıDuzenle;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem BtnAracDurumBelirlemeKaydet;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevExpress.XtraBars.BarButtonItem BtnSiparisListesi;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private DevExpress.XtraBars.BarButtonItem BtnRezerve;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem BtnMobiliz;
    }
}

