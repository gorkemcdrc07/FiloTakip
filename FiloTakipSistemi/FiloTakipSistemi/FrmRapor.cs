using FiloTakipSistemi.Entity2;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmRapor : Form
    {
        private Timer timer;

        public FrmRapor()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 60000; // 60 saniye (60000 milisaniye)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;

            // Eğer saat 00:00 ise
            if (currentTime.Hour == 0 && currentTime.Minute == 0)
            {
                using (var db = new FiloTakipEntities7())
                {
                    // Önceki günün tarihini belirle
                    DateTime previousDate = currentTime.AddDays(-1);
                    DateTime newDate = currentTime; // Yeni tarih

                    // Önceki günün kayıtlarını al
                    var records = db.TblPlakaDurumları
                        .Where(r => r.Tarih.HasValue && r.Tarih.Value.Date == previousDate.Date)
                        .ToList();

                    // Yeni kayıtları eklemek için sırayla işle
                    foreach (var record in records)
                    {
                        // Yeni kayıt oluştur
                        var newRecord = new TblPlakaDurumları
                        {
                            Plaka = record.Plaka,
                            SurucuAdı = record.SurucuAdı,
                            SurucuTelefon = record.SurucuTelefon,
                            SurucuTC = record.SurucuTC,
                            SeferTarihi = record.SeferTarihi,
                            YuklemeNoktası = record.YuklemeNoktası,
                            TeslimNoktası = record.TeslimNoktası,
                            SonIl = record.SonIl,
                            SonIlce = record.SonIlce,
                            SonNokta = record.SonNokta,
                            TahminiVarisZamani = record.TahminiVarisZamani,
                            YuklemeYeriArasındaKm = record.YuklemeYeriArasındaKm,
                            Durum = record.Durum,
                            BaslangıcTarihi = record.BaslangıcTarihi,
                            BitisTarihi = record.BitisTarihi,
                            Aciklama = record.Aciklama,
                            Sebep = record.Sebep,
                            // Tarih alanını güncelle
                            Tarih = newDate
                        };

                        // Yeni kaydı veritabanına ekle
                        db.TblPlakaDurumları.Add(newRecord);

                        // Kopyalanan kaydın alttaki satıra eklenmesi
                        // Bu durumda aynı işlemi bir kez daha yaparak kaydın kopyasını ekleriz
                        var newRecordForNextRow = new TblPlakaDurumları
                        {
                            Plaka = record.Plaka,
                            SurucuAdı = record.SurucuAdı,
                            SurucuTelefon = record.SurucuTelefon,
                            SurucuTC = record.SurucuTC,
                            SeferTarihi = record.SeferTarihi,
                            YuklemeNoktası = record.YuklemeNoktası,
                            TeslimNoktası = record.TeslimNoktası,
                            SonIl = record.SonIl,
                            SonIlce = record.SonIlce,
                            SonNokta = record.SonNokta,
                            TahminiVarisZamani = record.TahminiVarisZamani,
                            YuklemeYeriArasındaKm = record.YuklemeYeriArasındaKm,
                            Durum = record.Durum,
                            BaslangıcTarihi = record.BaslangıcTarihi,
                            BitisTarihi = record.BitisTarihi,
                            Aciklama = record.Aciklama,
                            Sebep = record.Sebep,
                            // Tarih alanını aynı şekilde güncellemeye devam et
                            Tarih = newDate
                        };

                        // Alttaki kaydı da veritabanına ekle
                        db.TblPlakaDurumları.Add(newRecordForNextRow);
                    }

                    // Değişiklikleri kaydet
                    db.SaveChanges();
                }
            }
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'filoTakipDataSet21.TblPlakaDurumları' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPlakaDurumlarıTableAdapter1.Fill(this.filoTakipDataSet21.TblPlakaDurumları);
            // İlk verileri yükle
            this.tblPlakaDurumlarıTableAdapter.Fill(this.filoTakipDataSet5.TblPlakaDurumları);
        }
    }
}
