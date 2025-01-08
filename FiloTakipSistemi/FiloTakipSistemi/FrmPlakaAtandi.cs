using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FiloTakipSistemi.Entity7;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using System.Data.SqlClient;
using static FiloTakipSistemi.FrmGiris;
using System.Drawing;


namespace FiloTakipSistemi
{
    public partial class FrmPlakaAtandi : Form
    {


        private FiloTakipEntities9 db = new FiloTakipEntities9();

        // BindingSource tanımlıyoruz
        private BindingSource bindingSourcePlakaAtandi = new BindingSource();

        // PlakaAtandiListesi özelliğini tanımlıyoruz
        public List<TblPlakaAtandi> PlakaAtandiListesi { get; set; }



        public FrmPlakaAtandi()
        {
            InitializeComponent();
            PlakaAtandiListesi = new List<TblPlakaAtandi>(); // Listeyi başlatıyoruz

            // RepositoryItemDateEdit1 (YuklemeNoktasiVarısTarihi) için
            RepositoryItemDateEdit repositoryItemDateEdit1 = new RepositoryItemDateEdit();
            repositoryItemDateEdit1.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            repositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True; // Vista takvimini etkinleştir
            repositoryItemDateEdit1.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Saat seçimini etkinleştir
            gridControlPlakaAtandi.RepositoryItems.Add(repositoryItemDateEdit1); // RepositoryItem'ı ekleyin
            gridViewPlakaAtandi.Columns["YuklemeNoktasiVarısTarihi"].ColumnEdit = repositoryItemDateEdit1; // Sütuna atama

            // RepositoryItemDateEdit2 (YuklemeNoktasiCikisTarihi) için
            RepositoryItemDateEdit repositoryItemDateEdit2 = new RepositoryItemDateEdit();
            repositoryItemDateEdit2.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            repositoryItemDateEdit2.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True; // Vista takvimini etkinleştir
            repositoryItemDateEdit2.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Saat seçimini etkinleştir
            gridControlPlakaAtandi.RepositoryItems.Add(repositoryItemDateEdit2); // RepositoryItem'ı ekleyin
            gridViewPlakaAtandi.Columns["YuklemeNoktasiCikisTarihi"].ColumnEdit = repositoryItemDateEdit2; // Sütuna atama

            // RepositoryItemDateEdit3 (Gerceklesen) için
            RepositoryItemDateEdit repositoryItemDateEdit3 = new RepositoryItemDateEdit();
            repositoryItemDateEdit3.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit3.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            repositoryItemDateEdit3.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True; // Vista takvimini etkinleştir
            repositoryItemDateEdit3.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Saat seçimini etkinleştir
            gridControlPlakaAtandi.RepositoryItems.Add(repositoryItemDateEdit3); // RepositoryItem'ı ekleyin
            gridViewPlakaAtandi.Columns["Gerceklesen"].ColumnEdit = repositoryItemDateEdit3; // Sütuna atama

            // RepositoryItemDateEdit4 (TeslimNoktasiCikisTarihi) için
            RepositoryItemDateEdit repositoryItemDateEdit4 = new RepositoryItemDateEdit();
            repositoryItemDateEdit4.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit4.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            repositoryItemDateEdit4.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True; // Vista takvimini etkinleştir
            repositoryItemDateEdit4.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Saat seçimini etkinleştir
            gridControlPlakaAtandi.RepositoryItems.Add(repositoryItemDateEdit4); // RepositoryItem'ı ekleyin
            gridViewPlakaAtandi.Columns["TeslimNoktasiCikisTarihi"].ColumnEdit = repositoryItemDateEdit4; // Sütuna atama

            // Diğer sütunlar için düzenleme izinlerini kaldır
            List<DevExpress.XtraGrid.Columns.GridColumn> columns = gridViewPlakaAtandi.Columns.Cast<DevExpress.XtraGrid.Columns.GridColumn>().ToList();

            foreach (DevExpress.XtraGrid.Columns.GridColumn column in columns)
            {
                // Eğer sütun adları belirtilen sütunlardan biri değilse
                if (column.FieldName != "PlakaDurumu" &&
                    column.FieldName != "Sec" &&
                    column.FieldName != "YuklemeNoktasiVarısTarihi" &&
                    column.FieldName != "YuklemeNoktasiCikisTarihi" &&
                    column.FieldName != "Gerceklesen" &&
                    column.FieldName != "TeslimNoktasiCikisTarihi")
                {
                    column.OptionsColumn.AllowEdit = false; // Salt okunur yap
                }
                else
                {
                    column.OptionsColumn.AllowEdit = true; // Düzenlemeye izin ver
                }
            }

            // Sec sütunu sadece bir kez ekle ve en sola yerleştir
            if (!gridViewPlakaAtandi.Columns.Contains(gridViewPlakaAtandi.Columns["Sec"]))
            {
                GridColumn secColumn = new GridColumn();
                secColumn.FieldName = "Sec";
                secColumn.Caption = "Sec";
                secColumn.Visible = true;
                secColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;

                // CheckBox için CellEdit ekliyoruz
                secColumn.ColumnEdit = new RepositoryItemCheckEdit();

                // gridControlPlakaAtandi'ye ekliyoruz
                gridViewPlakaAtandi.Columns.Add(secColumn);
            }

            // Sec sütununu en başa taşıyoruz (sütun sırası değiştirildi)
            var secColumnIndex = gridViewPlakaAtandi.Columns["Sec"].VisibleIndex;
            gridViewPlakaAtandi.Columns["Sec"].VisibleIndex = 0; // Sec sütununu en başa taşıyoruz
        }





        private void FrmPlakaAtandi_Load(object sender, EventArgs e)
        {
            Listele(); // Anlık tablo görüntüsünü alıyoruz ve form yüklendiğinde tabloyu gösteriyoruz
        }

        // TblPlakaAtandi tablosundaki verileri çeker ve GridControl'e bağlar
        public void Listele(int? selectedPlakaID = null)
        {
            // TblPlakaAtandi tablosundan verileri alıyoruz
            PlakaAtandiListesi = db.TblPlakaAtandi.ToList();

            // Eğer belirli bir Plaka ID'si verilmişse, sadece o plakanın verilerini alıyoruz
            if (selectedPlakaID.HasValue)
            {
                PlakaAtandiListesi = PlakaAtandiListesi
                    .Where(p => p.ID == selectedPlakaID.Value)
                    .ToList();
            }

            // YuklemeIl'e göre SonNokta'yı güncelliyoruz
            foreach (var plakaAtandi in PlakaAtandiListesi)
            {
                // TblBolgeler'de ilgili bölgeyi bulmak için sorgu
                var bolge = db.TblBolgeler
                    .Where(b => b.İl == plakaAtandi.YuklemeIl)
                    .Select(b => b.Bolge)
                    .FirstOrDefault();

                // Eğer bölge bulunduysa, SonNokta'ya ata
                if (!string.IsNullOrEmpty(bolge))
                {
                    plakaAtandi.SonNokta = bolge;
                }
                else
                {
                    plakaAtandi.SonNokta = "Bölge bulunamadı"; // Eğer bölge bulunmazsa bir uyarı ekleyebiliriz
                }
            }

            // BindingSource'a verileri atıyoruz
            bindingSourcePlakaAtandi.DataSource = PlakaAtandiListesi;

            // GridControl'e BindingSource'u bağlıyoruz
            gridControlPlakaAtandi.DataSource = bindingSourcePlakaAtandi;

            // GridView'i güncelliyoruz
            gridViewPlakaAtandi.BestFitColumns();
        }


        public void Guncelle()
        {
            using (FiloTakipEntities9 db = new FiloTakipEntities9())
            {
                // gridControlPlakaAtandi için verileri al
                gridControlPlakaAtandi.DataSource = db.TblPlakaAtandi.ToList();
                gridControlPlakaAtandi.Refresh(); // Veriyi yenile
            }
        }


        private void FrmPlakaAtandi_Load_1(object sender, EventArgs e)
        {
            // Kullanıcı rolünü kontrol etmek için CustomRowCellEdit olayını bağla
            gridViewPlakaAtandi.CustomRowCellEdit += GridViewPlakaAtandi_CustomRowCellEdit;


            // TODO: Bu kod satırı 'filoTakipDataSet19.TblPlakaAtandi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPlakaAtandiTableAdapter.Fill(this.filoTakipDataSet19.TblPlakaAtandi);
            // TODO: Bu kod satırı 'filoTakipDataSet3.TblAracStatu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblAracStatuTableAdapter2.Fill(this.filoTakipDataSet3.TblAracStatu);
        }

        private void GridViewPlakaAtandi_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            // Eğer düzenlenmek istenen sütun PlakaDurumu ise kontrol yap
            if (e.Column.FieldName == "PlakaDurumu")
            {
                // Eğer kullanıcı rolü "Duzenleme" veya "Yonetici" değilse düzenleme engellenir
                if (FrmGiris.GlobalUser.KullaniciRol != "duzenleme" && FrmGiris.GlobalUser.KullaniciRol != "yonetici")
                {
                    // Salt okunur düzenleme öğesi atama
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit readOnlyItem = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
                    {
                        ReadOnly = true // Düzenlemeyi salt okunur yapar
                    };

                    e.RepositoryItem = readOnlyItem;
                }
                else
                {
                    // Düzenleme yapılabilirse orijinal RepositoryItem'ı kullan
                    e.RepositoryItem = repositoryItemLookUpEdit3;
                }
            }
        }





        private void BtnGorunum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveGridLayout();
            MessageBox.Show("Mevcut sütun düzeni başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Düzeni Kaydetme
        private void SaveGridLayout()
        {
            try
            {
                // Düzen dosyasının yolu
                string layoutFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GridLayoutPlakaAtandi.xml");

                // GridView düzenini XML dosyasına kaydet
                gridViewPlakaAtandi.SaveLayoutToXml(layoutFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Düzen kaydedilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            using (var context = new FiloTakipEntities9())
            {
                // DataSource'un null olup olmadığını kontrol et
                if (gridControlPlakaAtandi.DataSource != null)
                {
                    // BindingSource üzerinden verileri al
                    if (gridControlPlakaAtandi.DataSource is BindingSource bindingSource)
                    {
                        // BindingSource'dan veri listesini al
                        var plakaAtandiListesi = bindingSource.List.Cast<TblPlakaAtandi>().ToList();

                        foreach (var plakaAtandi in plakaAtandiListesi)
                        {
                            string plaka = plakaAtandi.Plaka;
                            string durum = plakaAtandi.PlakaDurumu; // PlakaDurumu'nu alıyoruz
                            DateTime? gerceklesen = plakaAtandi.Gerceklesen; // Gerceklesen alanını alıyoruz
                            DateTime? seferTarihi = plakaAtandi.SeferTarihi; // SeferTarihi
                            string surucuAdSoyad = plakaAtandi.SurucuAdSoyad; // SurucuAdSoyad
                            string surucuTelefon = plakaAtandi.SurucuTelefon; // SurucuTelefon
                            string surucuTC = plakaAtandi.SurucuTC; // SurucuTC
                            string musteriAdi = plakaAtandi.MusteriAdi; // MusteriAdi
                            string yuklemeNoktasi = plakaAtandi.YuklemeNoktasi; // YuklemeNoktasi
                            string yuklemeIl = plakaAtandi.YuklemeIl; // YuklemeIl
                            string yuklemeIlcesi = plakaAtandi.YuklemeIlcesi; // YuklemeIlcesi

                            // Tonaj ve NavlunTutar değerlerini string olarak saklıyoruz
                            string tonaj = plakaAtandi.Tonaj; // string olarak al
                            string navlunTutar = plakaAtandi.NavlunTutar; // string olarak al

                            string teslimNoktasi = plakaAtandi.TeslimNoktasi; // TeslimNoktasi
                            string teslimIli = plakaAtandi.TeslimIli; // TeslimIli
                            string teslimIlcesi = plakaAtandi.TeslimIlcesi; // TeslimIlcesi

                            DateTime? tahminiVaris = plakaAtandi.TahminiVaris; // TahminiVaris
                            string sonNokta = plakaAtandi.SonNokta; // SonNokta
                            string aciklama = plakaAtandi.Aciklama; // Aciklama
                            DateTime? YuklemeNoktasiVarısTarihi = plakaAtandi.YuklemeNoktasiVarısTarihi;
                            DateTime? YuklemeNoktasiCikisTarihi = plakaAtandi.YuklemeNoktasiCikisTarihi;
                            DateTime? TeslimNoktasiCikisTarihi = plakaAtandi.TeslimNoktasiCikisTarihi;

                            // PlakaDurumu "BOŞTA" olanları kontrol et ve onları güncelle
                            if (string.IsNullOrEmpty(durum) || durum == "BOŞTA")
                            {
                                // TblTamamlananSeferler tablosuna veriyi aktar
                                TblTamamlananSeferler tamamlananSefer = new TblTamamlananSeferler
                                {
                                    PlakaDurumu = "TAMAMLANDI",
                                    SeferTarihi = seferTarihi,
                                    Plaka = plaka,
                                    SurucuAdSoyad = surucuAdSoyad,
                                    SurucuTelefon = surucuTelefon,
                                    SurucuTC = surucuTC,
                                    MusteriAdi = musteriAdi,
                                    YuklemeNoktasi = yuklemeNoktasi,
                                    YuklemeIl = yuklemeIl,
                                    YuklemeIlcesi = yuklemeIlcesi,
                                    Tonaj = tonaj, // string olarak atanıyor
                                    TeslimNoktasi = teslimNoktasi,
                                    TeslimIli = teslimIli,
                                    TeslimIlcesi = teslimIlcesi,
                                    NavlunTutar = navlunTutar, // string olarak atanıyor
                                    TahminiVaris = tahminiVaris,
                                    Gerceklesen = gerceklesen,
                                    SonNokta = sonNokta,
                                    Aciklama = aciklama,
                                    YuklemeNoktasiVarısTarihi = YuklemeNoktasiVarısTarihi,
                                    YuklemeNoktasiCikisTarihi = YuklemeNoktasiCikisTarihi,
                                    TeslimNoktasiCikisTarihi = TeslimNoktasiCikisTarihi,
                                };
                                context.TblTamamlananSeferler.Add(tamamlananSefer);

                                // gridControlPlakaAtandi tablosundan bu satırı sil
                                bindingSource.Remove(plakaAtandi);

                                // TblPlakaAtandi tablosundan bu satırı sil
                                var plakaAtandiKayit = context.TblPlakaAtandi.FirstOrDefault(p => p.Plaka == plaka);
                                if (plakaAtandiKayit != null)
                                {
                                    context.TblPlakaAtandi.Remove(plakaAtandiKayit);
                                }

                                // PlakaDurumu "BOŞTA" olan PlakaDurumları kaydını güncelle
                                var plakaDurumKayit = context.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);
                                if (plakaDurumKayit != null)
                                {
                                    plakaDurumKayit.Durum = "BOŞTA"; // "BOŞTA" olarak güncelliyoruz
                                }
                            }
                            else
                            {
                                // TblPlakaDurumları tablosunda plaka eşleşen kaydı bul
                                var plakaDurumKayit = context.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);

                                if (plakaDurumKayit != null)
                                {
                                    // Durum alanını güncelle
                                    plakaDurumKayit.Durum = durum; // Durumu güncelliyoruz
                                }

                                // TblPlakaAtandi tablosunda plaka eşleşen kaydı bul
                                var plakaAtandiKayit = context.TblPlakaAtandi.FirstOrDefault(p => p.Plaka == plaka);

                                if (plakaAtandiKayit != null)
                                {
                                    // Durum alanını güncelle
                                    plakaAtandiKayit.PlakaDurumu = durum; // PlakaDurumu'nu güncelliyoruz

                                    // Gerceklesen tarihini güncelle
                                    if (gerceklesen.HasValue)
                                    {
                                        plakaAtandiKayit.Gerceklesen = gerceklesen.Value;
                                    }

                                    // YuklemeNoktasiVarısTarihi, YuklemeNoktasiCikisTarihi ve TeslimNoktasiCikisTarihi'ni güncelle
                                    if (YuklemeNoktasiVarısTarihi.HasValue)
                                    {
                                        plakaAtandiKayit.YuklemeNoktasiVarısTarihi = YuklemeNoktasiVarısTarihi.Value;
                                    }
                                    if (YuklemeNoktasiCikisTarihi.HasValue)
                                    {
                                        plakaAtandiKayit.YuklemeNoktasiCikisTarihi = YuklemeNoktasiCikisTarihi.Value;
                                    }
                                    if (TeslimNoktasiCikisTarihi.HasValue)
                                    {
                                        plakaAtandiKayit.TeslimNoktasiCikisTarihi = TeslimNoktasiCikisTarihi.Value;
                                    }
                                }
                            }
                        }

                        // Veritabanında değişiklikleri kaydet
                        context.SaveChanges();
                        MessageBox.Show("Değişiklikler kaydedildi, Durum ile Gerçekleşen güncellendi ve 'BOŞTA' olanlar silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri kaynağı geçersiz. Lütfen kontrol edin.");
                    }
                }
                else
                {
                    MessageBox.Show("gridControlPlakaAtandi veri kaynağı boş.");
                }
            }
        }

        private void BtnPlanlamayaGonder_Click(object sender, EventArgs e)
        {
            // FiloTakipEntities9 bağlamı ile veritabanına bağlan
            using (var dbContext = new FiloTakipEntities9())
            {
                // gridControlPlakaAtandi'de Sec sütununda tıklanan satırı bul
                foreach (var row in this.gridViewPlakaAtandi.GetSelectedRows())
                {
                    // Seçilen satırın Plaka değeri
                    var plaka = this.gridViewPlakaAtandi.GetRowCellValue(row, "Plaka").ToString();
                    var tmsOrderId = this.gridViewPlakaAtandi.GetRowCellValue(row, "TMSOrderID").ToString();

                    // 1. TblPlakaAtandi tablosundan ilgili satırı sil
                    var plakaAtandi = dbContext.TblPlakaAtandi.FirstOrDefault(p => p.Plaka == plaka);
                    if (plakaAtandi != null)
                    {
                        dbContext.TblPlakaAtandi.Remove(plakaAtandi);
                    }

                    // 2. TblPlakaDurumlari tablosunda Plaka sütununda ilgili satırı bul ve güncelle
                    var plakaDurum = dbContext.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);
                    if (plakaDurum != null)
                    {
                        plakaDurum.YuklemeNoktası = null;
                        plakaDurum.TeslimNoktası = null;
                        plakaDurum.SonIl = null;
                        plakaDurum.SonIlce = null;
                        plakaDurum.SonNokta = null;
                        plakaDurum.TahminiVarisZamani = null;
                        plakaDurum.YuklemeYeriArasındaKm = null;
                        plakaDurum.Durum = "BOŞTA";
                    }

                    // 3. TblSiparisListesiYedek tablosunda TMSOrderID'yi bul ve TblSiparisListesi tablosuna aktar
                    var siparisYedek = dbContext.TblSiparisListesiYedek.FirstOrDefault(s => s.TMSOrderID == tmsOrderId);
                    if (siparisYedek != null)
                    {
                        // Yeni Sipariş oluşturuluyor
                        var yeniSiparis = new TblSiparisListesi
                        {
                            Plaka = siparisYedek.Plaka,
                            ReferansNo = siparisYedek.ReferansNo,
                            TMSOrderID = siparisYedek.TMSOrderID,
                            Firma = siparisYedek.Firma,
                            Proje = siparisYedek.Proje,
                            HizmetTipi = siparisYedek.HizmetTipi,
                            IstenilenAracTipi = siparisYedek.IstenilenAracTipi,
                            SiparisNumarasi = siparisYedek.SiparisNumarasi,
                            SiparisTarihi = siparisYedek.SiparisTarihi,
                            YuklemeTarihi = siparisYedek.YuklemeTarihi,
                            TeslimTarihi = siparisYedek.TeslimTarihi,
                            NoktaSayisi = siparisYedek.NoktaSayisi,
                            YuklemeNoktasi = siparisYedek.YuklemeNoktasi,
                            YuklemeIli = siparisYedek.YuklemeIli,
                            YuklemeIlcesi = siparisYedek.YuklemeIlcesi,
                            SiparisDurumu = siparisYedek.SiparisDurumu,
                            TeslimNoktasi = siparisYedek.TeslimNoktasi,
                            TeslimIli = siparisYedek.TeslimIli,
                            TeslimIlcesi = siparisYedek.TeslimIlcesi,
                            MusteriSiparisNo = siparisYedek.MusteriSiparisNo,
                            MusteriReferansNo = siparisYedek.MusteriReferansNo,
                            Aciklama = siparisYedek.Aciklama,
                            SiparisAcan = siparisYedek.SiparisAcan,
                            SiparisAcilisZamani = siparisYedek.SiparisAcilisZamani,
                            PozisyonNo = siparisYedek.PozisyonNo,
                            ToplamKg = siparisYedek.ToplamKg,
                            TahminiVaris = siparisYedek.TahminiVaris,
                            TahminiKm = siparisYedek.TahminiKm
                        };

                        // TblSiparisListesi tablosuna yeni siparişi ekle
                        dbContext.TblSiparisListesi.Add(yeniSiparis);
                    }

                    // Veritabanı işlemlerini kaydet
                    dbContext.SaveChanges();

                    // gridControlPlakaAtandi üzerindeki satırı sil
                    this.gridViewPlakaAtandi.DeleteRow(row);
                }
            }

            // gridControlPlakaAtandi üzerindeki değişikliklerin yansıtılması
            gridControlPlakaAtandi.RefreshDataSource();

            // İşlem tamamlandığında kullanıcıya mesaj göster
            MessageBox.Show("Atanan Plaka iptali gerçekleşti, Planlamaya geri gönderildi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // gridControl ve gridView'i yenileyerek son durumu göster
            this.gridViewPlakaAtandi.RefreshData();
        }

        private void BtnDetay_Click(object sender, EventArgs e)
        {
            var selectedRowHandle = this.gridViewPlakaAtandi.FocusedRowHandle;

            if (selectedRowHandle >= 0)
            {
                var plakaValue = this.gridViewPlakaAtandi.GetRowCellValue(selectedRowHandle, "Plaka")?.ToString();
                var teslimNoktasiValue = this.gridViewPlakaAtandi.GetRowCellValue(selectedRowHandle, "TeslimNoktasi")?.ToString();

                if (!string.IsNullOrEmpty(plakaValue))
                {
                    // TeslimNoktasi değerinde ';' işareti varsa işleme devam et
                    if (teslimNoktasiValue != null && teslimNoktasiValue.Contains(";"))
                    {
                        using (var db = new FiloTakipEntities9())
                        {
                            // TblPlakaAtandi tablosundan TMSOrderID değerini al
                            var tmsOrderIdsRaw = db.TblPlakaAtandi
                                                   .Where(p => p.Plaka == plakaValue)
                                                   .Select(p => p.TMSOrderID)
                                                   .FirstOrDefault();

                            if (!string.IsNullOrEmpty(tmsOrderIdsRaw))
                            {
                                // TMSOrderID değerlerini ayrıştır
                                var tmsOrderIds = tmsOrderIdsRaw.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                // TblDetay tablosunda bu TMSOrderID'lerle ilgili satırları al
                                var detayList = db.TblDetay
                                                  .Where(d => tmsOrderIds.Contains(d.TMSOrderID))
                                                  .ToList();

                                if (detayList.Any())
                                {
                                    // Yeni bir FrmSiparisDetay formu oluştur
                                    FrmSiparisDetay detayForm = new FrmSiparisDetay();

                                    // Veriyi DataTable olarak dönüştür
                                    var dataTable = ConvertToDataTable(detayList);
                                    detayForm.LoadData(dataTable); // Veriyi formdaki gridControlDetay'a bağla
                                    detayForm.ShowDialog(); // Formu göster
                                }
                                else
                                {
                                    MessageBox.Show("Bu TMSOrderID'ler için detay bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Plaka değeri için TMSOrderID bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Uğraması olmayan bir sefer olduğundan bu işleme ihtiyaç duyulmamaktadır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seçili satırın Plaka değeri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var properties = typeof(T).GetProperties();
            DataTable dataTable = new DataTable();

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                var row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }




    }
}







