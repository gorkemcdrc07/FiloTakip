using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid; // DevExpress GridView namespace
using FiloTakipSistemi.Entity7;
using System.Drawing; // Point türü için gerekli
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Data.Entity.Infrastructure;





namespace FiloTakipSistemi
{
    public partial class FrmPlanlamaEkranı : Form
    {
        private BindingSource bindingSourceSiparisListesi;

        private Timer myTimer; // Timer değişkeni

        public FrmPlanlamaEkranı()
        {
            InitializeComponent();
            gridControlSiparis.MouseDown += GridControlSiparis_MouseDown; // Olayı bağlayın
            bindingSourceSiparisListesi = new BindingSource(); // BindingSource'ı başlat
            gridControl1.Visible = false;

            // XtraGrid olaylarını bağlayın
            var gridView = gridControlSiparis.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                gridView.MouseDown += GridView_MouseDown; // XtraGrid için MouseDown olayını bağladık
                gridView.RowClick += GridView_RowClick;   // Satır tıklama olayını bağladık
            }

            // RepositoryItemDateEdit (Tahmini Varış) için tarih ve saat seçimi
            RepositoryItemDateEdit repositoryItemDateEdit1 = new RepositoryItemDateEdit();
            repositoryItemDateEdit1.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            repositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True; // Vista takvimini etkinleştir
            repositoryItemDateEdit1.VistaEditTime = DevExpress.Utils.DefaultBoolean.True; // Saat seçimini etkinleştir
            gridControl1.RepositoryItems.Add(repositoryItemDateEdit1);

            // "TahminiVaris" sütununa tarih ve saat seçimi ekle
            gridView.Columns["TahminiVaris"].ColumnEdit = repositoryItemDateEdit1;
        }

        // XtraGrid MouseDown olayı
        private void GridView_MouseDown(object sender, MouseEventArgs e)
        {
            // Burada XtraGrid üzerindeki fare tıklama olaylarını işleyebilirsiniz
        }

        // XtraGrid RowClick olayı
        private void GridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            // Satır tıklama olayında yapılacak işlemleri burada yazabilirsiniz
        }

        private void FrmPlanlamaEkranı_Load(object sender, EventArgs e)
        {
            Listele(); // Form yüklendiğinde listele
        }

        public void Listele()
        {
            using (FiloTakipEntities9 db = new FiloTakipEntities9())
            {
                var siparisListesi = db.TblSiparisListesi.ToList();
                bindingSourceSiparis.DataSource = siparisListesi;
                gridControlSiparis.DataSource = bindingSourceSiparis;

                // Çoklu seçim ayarları
                var view = gridControlSiparis.MainView as GridView;
                if (view != null)
                {
                    view.OptionsSelection.MultiSelect = true;
                    view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

                    // RepositoryItemLookUpEdit oluşturma
                    RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                    repositoryItemLookUpEdit.NullText = "Seçiniz";

                    // Plaka listesini doldur (hepsi)
                    var plakaListesi = db.TblPlakaDurumları
                        .Select(p => new
                        {
                            Plaka = p.Plaka,
                            Durum = p.Durum,
                            SonIl = p.SonIl,
                            SonIlce = p.SonIlce
                        })
                        .ToList();

                    // "Plaka - Durum" biçiminde görüntülemek için
                    var plakaDurumListesi = plakaListesi.Select(p => new
                    {
                        Plaka = p.Plaka,
                        Durum = p.Durum,
                        SonIl = p.SonIl,
                        SonIlce = p.SonIlce
                    }).ToList();

                    repositoryItemLookUpEdit.DataSource = plakaDurumListesi;

                    // DisplayMember ayarları, Durum ile birlikte Plaka'yı göstermek için
                    repositoryItemLookUpEdit.DisplayMember = "Plaka"; // Plaka gösterilecek
                    repositoryItemLookUpEdit.ValueMember = "Plaka"; // Plaka, arka planda kullanılacak değer

                    // Arama özelliğini etkinleştir
                    repositoryItemLookUpEdit.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains; // İçeren eşleşmeler
                    repositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard; // Standart metin düzeni

                    // LookUpEdit kontrolünü grid'e ekle
                    gridControlSiparis.RepositoryItems.Add(repositoryItemLookUpEdit);

                    // Plaka sütununu bul ve RepositoryItemLookUpEdit bağla
                    GridColumn plakaColumn = view.Columns["Plaka"];
                    if (plakaColumn != null)
                    {
                        plakaColumn.ColumnEdit = repositoryItemLookUpEdit;
                    }

                    // CellValueChanged olayını kullanarak seçilen plaka durumunu kontrol et
                    view.CellValueChanged += (sender, e) =>
                    {
                        if (e.Column.FieldName == "Plaka")
                        {
                            // İlk önce e.Value'yi kontrol edelim, null olup olmadığını kontrol ediyoruz
                            if (e.Value == null)
                            {
                                MessageBox.Show("Plaka seçilmedi, lütfen bir plaka seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // Eğer değer null ise, işlemi sonlandırıyoruz
                            }

                            string plaka = e.Value.ToString();

                            // Bu satırda, DbContext'i burada yeniden başlatıyoruz
                            using (FiloTakipEntities9 dbContext = new FiloTakipEntities9())
                            {
                                // Plaka'nın durumunu kontrol et
                                var plakaDurum = dbContext.TblPlakaDurumları
                                    .Where(p => p.Plaka == plaka)
                                    .Select(p => p.Durum)
                                    .FirstOrDefault();

                                if (plakaDurum != null && (plakaDurum == "İZİNLİ" || plakaDurum == "BAKIM İZNİ" || plakaDurum == "ARIZALI" || plakaDurum == "KESİNTİ"))
                                {
                                    MessageBox.Show($"Bu plaka şu anda '{plakaDurum}' durumunda olduğundan işlem yapılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    // Burada kullanıcı geçersiz durumu seçtiği için plaka değerini sıfırlıyoruz
                                    var viewLocal = sender as GridView;
                                    if (viewLocal != null)
                                    {
                                        // Plaka sütununu temizleyelim
                                        viewLocal.SetRowCellValue(e.RowHandle, e.Column, null);
                                    }

                                    return; // Geçersiz plaka durumu seçildiği için işlemi sonlandırıyoruz
                                }
                            }
                        }
                    };
                }

                if (siparisListesi.Count == 0)
                {
                    MessageBox.Show("Veri bulunamadı.");
                }
            }
        }






        public void PlakaDurumunuGuncelle(int plakaID)
        {
            using (var db = new FiloTakipEntities9())
            {
                var plaka = db.TblPlakaDurumları.FirstOrDefault(p => p.ID == plakaID);
                if (plaka != null)
                {
                    plaka.Durum = "PLAKA ATANDI";
                    db.SaveChanges(); // Veritabanına güncellemeyi kaydet
                }
            }
        }




        public List<TblSiparisListesi> GetSelectedOrders()
        {
            var view = gridControlSiparis.MainView as GridView;
            if (view != null && view.SelectedRowsCount > 0)
            {
                return view.GetSelectedRows()
                    .Select(rowHandle => bindingSourceSiparis.List[rowHandle] as TblSiparisListesi)
                    .ToList();
            }
            return new List<TblSiparisListesi>();
        }

        private void GridControlSiparis_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var view = gridControlSiparis.MainView as GridView;

                if (view != null)
                {
                    var hitInfo = view.CalcHitInfo(e.Location);
                    if (hitInfo.InRow)
                    {
                        contextMenuStrip1.Show(gridControlSiparis, e.Location);
                    }
                }
            }
        }


        private void plakaÖnerisiYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // gridControl1 kontrolünü görünür hale getiriyoruz
            gridControl1.Visible = true;  // Burada gridControl1 kontrolünü görünür hale getiriyoruz.

            // Seçili satırdan bilgileri alın
            var selectedOrders = GetSelectedOrders();
            if (selectedOrders.Count > 0)
            {
                var selectedOrder = selectedOrders.First(); // İlk seçili satırı alın
                string yuklemeIl = selectedOrder.YuklemeIli;
                string yuklemeIlce = selectedOrder.YuklemeIlcesi;

                // ListelePlakaOnerisi metodunu çağırarak verileri listele
                ListelePlakaOnerisi(yuklemeIl, yuklemeIlce); // Parametreleri gönder
            }
        }





        public void ListelePlakaOnerisi(string yuklemeIl, string yuklemeIlce)
        {
            try
            {
                using (FiloTakipEntities9 db = new FiloTakipEntities9())
                {
                    var plakaDurumlariListesi = db.TblPlakaDurumları
                        .Select(p => new
                        {
                            p.ID,
                            p.Plaka,
                            p.SonIl,
                            p.SonIlce,
                            p.Durum,
                            YuklemeYeriArasındaKm = db.TblMesafe
                                .Where(m => m.YuklemeIl == yuklemeIl && m.YuklemeIlce == yuklemeIlce &&
                                            m.TahliyeIl == p.SonIl && m.TahliyeIlce == p.SonIlce)
                                .Select(m => m.ToplamMesafe)
                                .FirstOrDefault()
                        })
                        .Where(p => p.YuklemeYeriArasındaKm != null)
                        .ToList();

                    if (plakaDurumlariListesi == null || plakaDurumlariListesi.Count == 0)
                    {
                        MessageBox.Show("Veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var resultList = plakaDurumlariListesi.Select(p => new
                    {
                        p.ID,
                        p.Plaka,
                        p.SonIl,
                        p.SonIlce,
                        p.Durum,
                        MesafeKm = p.YuklemeYeriArasındaKm,
                        // Molasız Varis saat ve dakika hesaplanır
                        MolasizVarisSaatVeDakika = FormatSaatDakika(Convert.ToDouble(p.YuklemeYeriArasındaKm) / 80),
                        // Molalı Varis saat ve dakika hesaplanır
                        MolaliVarisSaatVeDakika = MolaliVarisHesapla(Convert.ToDouble(p.YuklemeYeriArasındaKm) / 80)
                    }).ToList();

                    // gridControl1 ile veri bağlama
                    gridControl1.Visible = true;
                    gridControl1.DataSource = resultList;

                    var view = gridControl1.MainView as GridView;
                    if (view != null)
                    {
                        view.OptionsSelection.MultiSelect = true;
                        view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

                        // Molasız Varis Saat ve Dakika sütunu eklenir
                        if (!view.Columns.Cast<GridColumn>().Any(col => col.FieldName == "MolasizVarisSaatVeDakika"))
                        {
                            var molasizVarisSaatVeDakikaColumn = new DevExpress.XtraGrid.Columns.GridColumn
                            {
                                Caption = "Molasız Varis Saat ve Dakika",
                                FieldName = "MolasizVarisSaatVeDakika",
                                Visible = true,
                                UnboundType = DevExpress.Data.UnboundColumnType.Object
                            };
                            view.Columns.Add(molasizVarisSaatVeDakikaColumn);
                        }

                        // Molalı Varis Saat ve Dakika sütunu eklenir
                        if (!view.Columns.Cast<GridColumn>().Any(col => col.FieldName == "MolaliVarisSaatVeDakika"))
                        {
                            var molaliVarisSaatVeDakikaColumn = new DevExpress.XtraGrid.Columns.GridColumn
                            {
                                Caption = "Molalı Varis Saat ve Dakika",
                                FieldName = "MolaliVarisSaatVeDakika",
                                Visible = true,
                                UnboundType = DevExpress.Data.UnboundColumnType.Object
                            };
                            view.Columns.Add(molaliVarisSaatVeDakikaColumn);
                        }

                        // Plaka Ata sütunu eklenir
                        if (!view.Columns.Cast<GridColumn>().Any(col => col.FieldName == "PlakaAta"))
                        {
                            var plakaAtaColumn = new DevExpress.XtraGrid.Columns.GridColumn
                            {
                                Caption = "Plaka Ata",
                                FieldName = "PlakaAta",
                                Visible = true,
                                UnboundType = DevExpress.Data.UnboundColumnType.Object
                            };
                            view.Columns.Add(plakaAtaColumn);
                        }

                        // ButtonEdit ile Plaka Ata işlemi
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit
                        {
                            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                        };

                        buttonEdit.Buttons[0].Caption = "SEÇ";
                        buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

                        buttonEdit.ButtonClick += (sender, e) =>
                        {
                            int rowHandle = view.FocusedRowHandle;
                            string plaka = view.GetRowCellValue(rowHandle, "Plaka").ToString();

                            var siparisView = gridControlSiparis.MainView as GridView;
                            if (siparisView != null)
                            {
                                int siparisRowHandle = siparisView.FocusedRowHandle;
                                siparisView.SetRowCellValue(siparisRowHandle, "Plaka", plaka);
                            }

                            using (FiloTakipEntities9 dbContext = new FiloTakipEntities9())
                            {
                                var plakaDurumu = dbContext.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);
                                if (plakaDurumu != null)
                                {
                                    plakaDurumu.Durum = "PLAKA ATANDI";
                                    try
                                    {
                                        dbContext.SaveChanges();
                                        MessageBox.Show($"Plaka {plaka} için durum 'PLAKA ATANDI' olarak güncellendi.", "Plaka Seçimi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Plaka {plaka} veritabanında bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        };

                        view.CustomRowCellEdit += (sender, e) =>
                        {
                            if (e.Column.FieldName == "PlakaAta")
                            {
                                e.RepositoryItem = buttonEdit;
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatSaatDakika(double hours)
        {
            int totalMinutes = (int)(hours * 60); // Saatten dakikaya çevrilir
            int hoursPart = totalMinutes / 60;    // Saat kısmı
            int minutesPart = totalMinutes % 60; // Dakika kısmı
            return $"{hoursPart} saat {minutesPart} dakika";
        }

        private string MolaliVarisHesapla(double hours)
        {
            int totalMinutes = (int)(hours * 60); // Saatten dakikaya çevrilir
            int hoursPart = totalMinutes / 60;    // Saat kısmı
            int minutesPart = totalMinutes % 60; // Dakika kısmı

            // Eğer süre 9 saati geçiyorsa, 11 saat eklenir
            if (hoursPart > 9)
            {
                hoursPart += 11;
            }

            // Eğer süre 24 saati geçiyorsa, "1 gün" eklenir
            string result = $"{hoursPart} saat {minutesPart} dakika";
            if (hoursPart >= 24)
            {
                int days = hoursPart / 24;
                int remainingHours = hoursPart % 24;
                result = $"{days} gün {remainingHours} saat {minutesPart} dakika";
            }

            return result;
        }

















        private void satırSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // GridView'den seçilen satırları al
            var view = gridControlSiparis.MainView as GridView;

            if (view != null && view.SelectedRowsCount > 0)
            {
                // Seçilen satırları almak için
                var selectedRows = view.GetSelectedRows();

                // Silme işlemi öncesinde kullanıcıya uyarı ver
                DialogResult dialogResult = MessageBox.Show("Seçilen satırları silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    using (FiloTakipEntities9 db = new FiloTakipEntities9())
                    {
                        // Seçilen satırların verilerini sil
                        foreach (var rowHandle in selectedRows.OrderByDescending(x => x)) // En son seçilen satırdan başlayarak sil
                        {
                            var selectedRow = bindingSourceSiparis.List[rowHandle] as TblSiparisListesi; // Satırı sipariş modeline dönüştür

                            if (selectedRow != null)
                            {
                                var siparis = db.TblSiparisListesi.Find(selectedRow.ID);
                                if (siparis != null)
                                {
                                    db.TblSiparisListesi.Remove(siparis);
                                }
                            }
                        }

                        db.SaveChanges(); // Değişiklikleri kaydet

                        // Listeyi güncelle
                        Listele();
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir satır seçin.");
            }
        }

        public void Guncelle()
        {
            // gridControlSiparis için veri kaynağını güncelle
            // Örneğin, verileri yeniden yüklemek için
            gridControlSiparis.DataSource = GetUpdatedData(); // Verileri alacak bir metod ekleyin

            // Eğer başka güncelleme işlemleri varsa buraya ekleyin
            gridControlSiparis.RefreshDataSource(); // Görüntülenen veriyi yenile
        }

        // Örnek bir metod: Veritabanından güncellenmiş verileri çekmek için
        private object GetUpdatedData()
        {
            using (FiloTakipEntities9 db = new FiloTakipEntities9())
            {
                return db.TblSiparisListesi.ToList(); // İlgili veri kaynağını döndürün
            }
        }


        private void labelControl1_Click(object sender, EventArgs e)
        {
            // labelControl1'e "Görkem" yazıyoruz
            labelControl1.Text = "Görkem";
        }

        private void BtnAtamaYap_Click(object sender, EventArgs e)
        {
            // gridControlSiparis'teki seçili satırı al
            var siparisView = gridControlSiparis.MainView as GridView;
            if (siparisView == null || siparisView.FocusedRowHandle < 0)
            {
                MessageBox.Show("Lütfen bir sipariş seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili satırdan Plaka değerini al
            string plaka = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "Plaka")?.ToString();

            // Plaka sütunu boşsa uyarı ver
            if (string.IsNullOrWhiteSpace(plaka))
            {
                MessageBox.Show("Lütfen Plaka seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçili satırdan TahminiVaris değerini al (string olarak)
            var tahminiVarisString = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TahminiVaris")?.ToString();

            // Eğer TahminiVaris boşsa, uyarı ver ve işlemi sonlandır
            if (string.IsNullOrWhiteSpace(tahminiVarisString))
            {
                MessageBox.Show("Lütfen Tahmini Varış saatini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi sonlandır
            }

            // TahminiVaris değerini DateTime? türüne dönüştür
            DateTime? tahminiVaris = null;
            if (DateTime.TryParse(tahminiVarisString, out DateTime parsedTahminiVaris))
            {
                tahminiVaris = parsedTahminiVaris;
            }
            else
            {
                // Dönüştürme başarısız olursa, gerekirse default bir değer verebilirsiniz
                // Örneğin, null bırakabiliriz.
                tahminiVaris = null;
            }

            // TblPlakaDurumları tablosunda plaka bilgilerini ara
            using (FiloTakipEntities9 dbContext = new FiloTakipEntities9())
            {
                var plakaDurum = dbContext.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);

                if (plakaDurum != null)
                {
                    // Durum "BOŞTA" değilse, veriyi TblRezerve tablosuna at
                    if (plakaDurum.Durum != "BOŞTA")
                    {
                        // TblRezerve tablosuna veri eklerken sürücü bilgilerini de alıyoruz
                        var rezerv = new TblRezerve
                        {
                            Plaka = plaka,
                            SeferTarihi = DateTime.Now,
                            MusteriAdi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "Firma")?.ToString(),
                            YuklemeNoktasi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeNoktasi")?.ToString(),
                            YuklemeIl = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeIli")?.ToString(),
                            YuklemeIlcesi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeIlcesi")?.ToString(),
                            TeslimNoktasi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimNoktasi")?.ToString(),
                            TeslimIli = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIli")?.ToString(),
                            TeslimIlcesi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIlcesi")?.ToString(),
                            SurucuAdSoyad = plakaDurum.SurucuAdı,          // Sürücü adı
                            SurucuTelefon = plakaDurum.SurucuTelefon,  // Sürücü telefon
                            SurucuTC = plakaDurum.SurucuTC,             // Sürücü TC
                            RezervasyonTarihi = DateTime.Now,
                            PlakaDurumu = "REZERVE EDİLDİ",
                            // SonNokta değerini burada da ekliyoruz
                            SonNokta = plakaDurum.SonNokta, // SonNokta'yı burada kullanıyoruz
                            TahminiVaris = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TahminiVaris") as DateTime? // DateTime? nullable türü kullanılıyor                           
                        };

                        // TblRezerve tablosuna veriyi ekle
                        dbContext.TblRezerve.Add(rezerv);
                        dbContext.SaveChanges();

                        // Seçili siparişi TblSiparisListesi tablosundan sil
                        var siparisToDelete = dbContext.TblSiparisListesi.Find(siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "ID"));
                        if (siparisToDelete != null)
                        {
                            dbContext.TblSiparisListesi.Remove(siparisToDelete);
                            dbContext.SaveChanges(); // Değişiklikleri kaydet
                        }

                        // Seçili satırı GridView'den sil
                        siparisView.DeleteRow(siparisView.FocusedRowHandle);

                        MessageBox.Show("Plaka rezerve edildi ve sipariş silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Durum "BOŞTA" ise, veriyi TblPlakaAtandi tablosuna at

                        // TblPlakaDurumları tablosunda "Durum" sütununu "PLAKA ATANDI" olarak güncelle
                        plakaDurum.Durum = "PLAKA ATANDI";
                        plakaDurum.YuklemeNoktası = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeNoktasi")?.ToString();
                        plakaDurum.TeslimNoktası = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimNoktasi")?.ToString();
                        plakaDurum.SonIl = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIli")?.ToString();
                        plakaDurum.SonIlce = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIlcesi")?.ToString();

                        // SonNokta sütununa, SonIl'deki ile karşılık gelen Bölge'yi getir
                        string sonIl = plakaDurum.SonIl;

                        // Bölgeyi TblBolgeler tablosundan alıyoruz
                        var bolge = dbContext.TblBolgeler
                                             .FirstOrDefault(b => b.İl == sonIl)?.Bolge;

                        // Eğer Bölge bulunduysa, SonNokta'ya ata
                        if (!string.IsNullOrEmpty(bolge))
                        {
                            plakaDurum.SonNokta = bolge;
                        }
                        else
                        {
                            // Bölge bulunamazsa, SonNokta'ya varsayılan bir değer ata (opsiyonel)
                            plakaDurum.SonNokta = "Bölge Bulunamadı";
                        }

                        dbContext.SaveChanges(); // Durumu güncelle

                        // TblPlakaDurumları tablosundan sürücü bilgilerini al
                        var surucuAdi = plakaDurum.SurucuAdı;
                        var surucuTelefon = plakaDurum.SurucuTelefon;
                        var surucuTC = plakaDurum.SurucuTC;


                        // TblPlakaAtandi tablosuna veriyi eklerken TahminiVaris'i de kaydediyoruz
                        var plakaAtandi = new TblPlakaAtandi
                        {
                            Plaka = plaka,
                            PlakaDurumu = "PLAKA ATANDI",
                            SeferTarihi = DateTime.Now,
                            MusteriAdi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "Firma")?.ToString(),
                            YuklemeNoktasi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeNoktasi")?.ToString(),
                            YuklemeIl = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeIli")?.ToString(),
                            YuklemeIlcesi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "YuklemeIlcesi")?.ToString(),
                            TeslimNoktasi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimNoktasi")?.ToString(),
                            TeslimIli = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIli")?.ToString(),
                            TeslimIlcesi = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TeslimIlcesi")?.ToString(),
                            SurucuAdSoyad = surucuAdi,          // Sürücü adı
                            SurucuTelefon = surucuTelefon,     // Sürücü telefon
                            SurucuTC = surucuTC,               // Sürücü TC
                            TahminiVaris = tahminiVaris,       // DateTime? türünde TahminiVaris'i kaydediyoruz
                            TMSOrderID = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "TMSOrderID")?.ToString(),
                            PozisyonNo = siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "PozisyonNo")?.ToString()
                        };

                        // TblPlakaAtandi tablosuna veriyi ekle
                        dbContext.TblPlakaAtandi.Add(plakaAtandi);
                        dbContext.SaveChanges();

                        // Seçili siparişi TblSiparisListesi tablosundan sil
                        var siparisToDelete = dbContext.TblSiparisListesi.Find(siparisView.GetRowCellValue(siparisView.FocusedRowHandle, "ID"));
                        if (siparisToDelete != null)
                        {
                            dbContext.TblSiparisListesi.Remove(siparisToDelete);
                            dbContext.SaveChanges(); // Değişiklikleri kaydet
                        }

                        // Seçili satırı GridView'den sil
                        siparisView.DeleteRow(siparisView.FocusedRowHandle);

                        MessageBox.Show("Plaka atandı ve sürücü bilgileri eklendi, sipariş silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Plaka durumu bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        public void LoadData()
        {
            // Veritabanından verileri yükleyin
            using (FiloTakipEntities9 dbContext = new FiloTakipEntities9())
            {
                // Örneğin, bir grid kontrolüne veri yüklemek için
                var data = dbContext.TblSiparisListesi.ToList();
                bindingSourceSiparisListesi.DataSource = data; // bindingSourceSiparisListesi adında bir BindingSource kullandığınızı varsayıyorum
                gridControlSiparis.DataSource = bindingSourceSiparisListesi; // gridControlSiparis adında bir GridControl kullandığınızı varsayıyorum
                                                                             // GridControlSiparis'e RowClick olayını ekleyin
            }
        }


    }

}

