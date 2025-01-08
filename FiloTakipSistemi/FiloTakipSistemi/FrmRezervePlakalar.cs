using DevExpress.XtraEditors.Repository;
using FiloTakipSistemi.Entity7;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmRezervePlakalar : Form
    {
        RepositoryItemCheckEdit checkEdit;

        public FrmRezervePlakalar()
        {
            InitializeComponent();

            // GridControl üzerinde bulunan tüm sütunları salt okunur yapmak
            var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                {
                    column.OptionsColumn.AllowEdit = false; // Sütunu salt okunur yap
                }
            }
        }


        private void FrmRezervePlakalar_Load(object sender, EventArgs e)
        {
            // Verileri yükle
            this.tblRezerveTableAdapter1.Fill(this.filoTakipDataSet27.TblRezerve);
            this.tblRezerveTableAdapter.Fill(this.filoTakipDataSet18.TblRezerve);

            // RezervasyonTarihi sütununun tarih ve saat formatını ayarla
            gridView1.Columns["RezervasyonTarihi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["RezervasyonTarihi"].DisplayFormat.FormatString = "g"; // 'g' kısa tarih ve saat formatıdır.

            // CheckEdit sütununu ekle
            AddCheckEditColumn();

            // Satırları renklendir
            ColorRows();
        }

        private void AddCheckEditColumn()
        {
            // CheckEdit nesnesini oluştur ve GridControl'e ekle
            checkEdit = new RepositoryItemCheckEdit();
            gridControl1.RepositoryItems.Add(checkEdit);

            // GridView'e "Seçim" sütununu ekle
            var colCheckEdit = gridView1.Columns.AddVisible("Secim", "Seçim");
            colCheckEdit.UnboundType = DevExpress.Data.UnboundColumnType.Boolean; // Sütun tipi boolean olmalı
            colCheckEdit.ColumnEdit = checkEdit;
            colCheckEdit.VisibleIndex = 0; // İlk sütun olarak görünür

            // Varsayılan değer olarak false ata
            colCheckEdit.OptionsColumn.AllowEdit = true; // Düzenlenebilir olmalı
            colCheckEdit.OptionsColumn.AllowFocus = true; // Odaklanabilir
        }

        private void ColorRows()
        {
            // Satır bazında renklendirme yap
            gridView1.RowCellStyle += (sender, e) =>
            {
                using (var context = new FiloTakipEntities9())
                {
                    // Plaka sütunundaki değeri al
                    string plaka = e.RowHandle >= 0 ? gridView1.GetRowCellValue(e.RowHandle, "Plaka")?.ToString() : null;

                    if (!string.IsNullOrEmpty(plaka))
                    {
                        // TblPlakaDurumları tablosunda ilgili plakayı bul ve Durum sütununu al
                        var durum = context.TblPlakaDurumları
                                           .Where(p => p.Plaka == plaka)
                                           .Select(p => p.Durum)
                                           .FirstOrDefault();

                        // Duruma göre satır rengini ayarla
                        if (durum == "BOŞTA")
                        {
                            e.Appearance.BackColor = Color.LightGreen; // Yeşil
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.IndianRed; // Kırmızı
                        }
                    }
                }
            };
        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            // Veriyi yeniden yükle
            this.tblRezerveTableAdapter.Fill(this.filoTakipDataSet18.TblRezerve);

            // Grid'i güncelle
            gridControl1.RefreshDataSource();

            // Satırları renklendir
            ColorRows();
        }


        private void BtnAtamaYap_Click(object sender, EventArgs e)
        {
            using (var context = new FiloTakipEntities9()) // DbContext oluştur
            {
                // Seçilen satırları al
                var selectedRows = gridView1.GetSelectedRows();

                foreach (var rowHandle in selectedRows)
                {
                    if (rowHandle >= 0)
                    {
                        // Satırdaki verileri al
                        var plaka = gridView1.GetRowCellValue(rowHandle, "Plaka")?.ToString();
                        var rezervasyonTarihi = gridView1.GetRowCellValue(rowHandle, "RezervasyonTarihi")?.ToString();
                        var surucuAdSoyad = gridView1.GetRowCellValue(rowHandle, "SurucuAdSoyad")?.ToString();
                        var surucuTelefon = gridView1.GetRowCellValue(rowHandle, "SurucuTelefon")?.ToString();
                        var surucuTC = gridView1.GetRowCellValue(rowHandle, "SurucuTC")?.ToString();
                        var musteriAdi = gridView1.GetRowCellValue(rowHandle, "MusteriAdi")?.ToString();
                        var yuklemeNoktasi = gridView1.GetRowCellValue(rowHandle, "YuklemeNoktasi")?.ToString();
                        var yuklemeIl = gridView1.GetRowCellValue(rowHandle, "YuklemeIl")?.ToString();
                        var yuklemeIlcesi = gridView1.GetRowCellValue(rowHandle, "YuklemeIlcesi")?.ToString();
                        var tonaj = gridView1.GetRowCellValue(rowHandle, "Tonaj")?.ToString();
                        var teslimNoktasi = gridView1.GetRowCellValue(rowHandle, "TeslimNoktasi")?.ToString();
                        var teslimIli = gridView1.GetRowCellValue(rowHandle, "TeslimIli")?.ToString();
                        var teslimIlcesi = gridView1.GetRowCellValue(rowHandle, "TeslimIlcesi")?.ToString();
                        var navlunTutar = gridView1.GetRowCellValue(rowHandle, "NavlunTutar")?.ToString();
                        var aciklama = gridView1.GetRowCellValue(rowHandle, "Aciklama")?.ToString();
                        var sonNokta = gridView1.GetRowCellValue(rowHandle, "SonNokta")?.ToString();
                        var tahminiVaris = gridView1.GetRowCellValue(rowHandle, "TahminiVaris")?.ToString();

                        // TblPlakaDurumları tablosunda plaka durumunu kontrol et
                        var plakaDurumu = context.TblPlakaDurumları
                                                 .Where(pd => pd.Plaka == plaka)
                                                 .Select(pd => pd.Durum)
                                                 .FirstOrDefault();

                        if (plakaDurumu != "BOŞTA")
                        {
                            // Durum "BOŞTA" değilse uyarı ver ve işlemi durdur
                            MessageBox.Show($"Bu plakanın durumu {plakaDurumu}. Plaka ataması yapılmaz.");
                            continue; // Bir sonraki satıra geç
                        }

                        // RezervasyonTarihi'ni DateTime'a dönüştür
                        DateTime rezervasyonTarihiDateTime;
                        if (!DateTime.TryParse(rezervasyonTarihi, out rezervasyonTarihiDateTime))
                        {
                            MessageBox.Show($"Geçersiz tarih formatı: {rezervasyonTarihi}");
                            continue; // Eğer tarih dönüştürme başarısızsa, bir sonraki satıra geç
                        }

                        // TahminiVaris string'ini DateTime'a dönüştür
                        DateTime tahminiVarisDateTime;
                        if (!DateTime.TryParse(tahminiVaris, out tahminiVarisDateTime))
                        {
                            MessageBox.Show($"Geçersiz tahmini varış tarihi formatı: {tahminiVaris}");
                            continue; // Eğer tarih dönüştürme başarısızsa, bir sonraki satıra geç
                        }

                        // TblPlakaAtandi tablosuna yeni bir kayıt oluştur
                        var yeniKayit = new TblPlakaAtandi
                        {
                            PlakaDurumu = "PLAKA ATANDI", // Sabit değer
                            SeferTarihi = rezervasyonTarihiDateTime, // DateTime olarak kullanıyoruz
                            Plaka = plaka,
                            SurucuAdSoyad = surucuAdSoyad,
                            SurucuTelefon = surucuTelefon,
                            SurucuTC = surucuTC,
                            MusteriAdi = musteriAdi,
                            YuklemeNoktasi = yuklemeNoktasi,
                            YuklemeIl = yuklemeIl,
                            YuklemeIlcesi = yuklemeIlcesi,
                            Tonaj = tonaj,
                            TeslimNoktasi = teslimNoktasi,
                            TeslimIli = teslimIli,
                            TeslimIlcesi = teslimIlcesi,
                            NavlunTutar = navlunTutar,
                            Aciklama = aciklama,
                            SonNokta = sonNokta,
                            TahminiVaris = tahminiVarisDateTime // DateTime olarak kaydediyoruz
                        };

                        // Yeni kaydı TblPlakaAtandi tablosuna ekle
                        context.TblPlakaAtandi.Add(yeniKayit);

                        // TblRezerve tablosundaki bu satırı sil
                        var rezervasyon = context.TblRezerve
                                                  .Where(r => r.Plaka == plaka &&
                                                              r.RezervasyonTarihi.HasValue &&
                                                              r.RezervasyonTarihi.Value.Year == rezervasyonTarihiDateTime.Year &&
                                                              r.RezervasyonTarihi.Value.Month == rezervasyonTarihiDateTime.Month &&
                                                              r.RezervasyonTarihi.Value.Day == rezervasyonTarihiDateTime.Day)
                                                  .FirstOrDefault();

                        if (rezervasyon != null)
                        {
                            // Satırı sil
                            context.TblRezerve.Remove(rezervasyon);
                        }
                        else
                        {
                            MessageBox.Show("Rezervasyon kaydı bulunamadı!");
                        }
                    }
                }

                // Değişiklikleri kaydet
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Plaka atamaları başarıyla yapıldı ve rezervasyon kaydı silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata oluştu: {ex.Message}");
                }

                // DataSource'u güncelle
                gridControl1.RefreshDataSource(); // gridControl'ün veri kaynağını yenile

                // BindingSource ile de güncelleme yapabilirsiniz
                if (tblRezerveBindingSource1 != null)
                {
                    tblRezerveBindingSource1.ResetBindings(false); // BindingSource'u yenileyin
                }
            }
        }




    }
}

