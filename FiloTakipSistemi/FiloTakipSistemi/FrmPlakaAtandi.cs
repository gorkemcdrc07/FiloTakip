using FiloTakipSistemi.Entity2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmPlakaAtandi : Form
    {
        private FiloTakipEntities7 db = new FiloTakipEntities7();

        // BindingSource tanımlıyoruz
        private BindingSource bindingSourcePlakaAtandi = new BindingSource();

        // PlakaAtandiListesi özelliğini tanımlıyoruz
        public List<TblPlakaAtandi> PlakaAtandiListesi { get; set; }

        public FrmPlakaAtandi()
        {
            InitializeComponent();
            PlakaAtandiListesi = new List<TblPlakaAtandi>(); // Listeyi başlatıyoruz
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
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
            {
                // gridControlPlakaAtandi için verileri al
                gridControlPlakaAtandi.DataSource = db.TblPlakaAtandi.ToList();
                gridControlPlakaAtandi.Refresh(); // Veriyi yenile
            }
        }

        private void FrmPlakaAtandi_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'filoTakipDataSet19.TblPlakaAtandi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPlakaAtandiTableAdapter.Fill(this.filoTakipDataSet19.TblPlakaAtandi);
            // TODO: Bu kod satırı 'filoTakipDataSet3.TblAracStatu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblAracStatuTableAdapter2.Fill(this.filoTakipDataSet3.TblAracStatu);

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
            using (var context = new FiloTakipEntities7())
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

                            // TblPlakaDurumları tablosunda plaka eşleşen kaydı bul
                            var plakaDurumKayit = context.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);

                            if (plakaDurumKayit != null)
                            {
                                // Durum alanını güncelle
                                plakaDurumKayit.Durum = durum;
                            }

                            // TblPlakaAtandi tablosunda plaka eşleşen kaydı bul
                            var plakaAtandiKayit = context.TblPlakaAtandi.FirstOrDefault(p => p.Plaka == plaka);

                            if (plakaAtandiKayit != null)
                            {
                                // Durum alanını güncelle
                                plakaAtandiKayit.PlakaDurumu = durum; // PlakaDurumu'nu güncelliyoruz
                            }
                        }

                        // Veritabanında değişiklikleri kaydet
                        context.SaveChanges();
                        MessageBox.Show("Değişiklikler kaydedildi ve Durum güncellendi.");
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
    }
}
