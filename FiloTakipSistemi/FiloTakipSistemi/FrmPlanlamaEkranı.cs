using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid; // DevExpress GridView namespace
using FiloTakipSistemi.Entity2;
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
            panel1.Visible = false;
            bindingSourceSiparisListesi = new BindingSource(); // BindingSource'ı başlat

            // Timer'ı başlat
            myTimer = new Timer();
            myTimer.Interval = 30; // Örneğin 30 ms
            myTimer.Tick += Timer1_Tick; // Timer olayını bağlayın

            // PictureEdit için tıklama olayını bağlayın
            pictureEdit1.Click += PictureEdit1_Click; // Yeni olay işleyici
        }

        private void FrmPlanlamaEkranı_Load(object sender, EventArgs e)
        {
            Listele(); // Form yüklendiğinde listele
        }

        public void Listele()
        {
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
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

                    // Plaka listesini doldur (hepsi), belirli Durum'ları hariç tut
                    var plakaListesi = db.TblPlakaDurumları
                        .Where(p => p.Durum != "İZİNLİ" && p.Durum != "BAKIM İZNİ" && p.Durum != "ARIZALI")
                        .Select(p => new
                        {
                            Plaka = p.Plaka,
                            Durum = p.Durum // Durum bilgisini ekliyoruz
                        })
                        .ToList();

                    // "Plaka - Durum" biçiminde görüntülemek için
                    var plakaDurumListesi = plakaListesi.Select(p => new
                    {
                        Plaka = p.Plaka,
                        Durum = p.Durum
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
                }

                if (siparisListesi.Count == 0)
                {
                    MessageBox.Show("Veri bulunamadı.");
                }
            }
        }





        public void PlakaDurumunuGuncelle(int plakaID)
        {
            using (var db = new FiloTakipEntities7())
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
            panel1.Visible = true;
            panel1.Location = new Point(panel1.Location.X, this.Height); // Formun altına yerleştir
            myTimer.Start(); // Timer başlat

            // Seçili satırdan bilgileri alın
            var selectedOrders = GetSelectedOrders();
            if (selectedOrders.Count > 0)
            {
                var selectedOrder = selectedOrders.First(); // İlk seçili satırı alın
                string yuklemeIl = selectedOrder.YuklemeIl;
                string yuklemeIlce = selectedOrder.YuklemeIlce;

                ListelePlakaOnerisi(yuklemeIl, yuklemeIlce); // Parametreleri gönder
            }
        }

        public void ListelePlakaOnerisi(string yuklemeIl, string yuklemeIlce)
        {
            try
            {
                using (FiloTakipEntities7 db = new FiloTakipEntities7())
                {
                    // TblPlakaDurumları ile eşleştirip verileri oluştur
                    var plakaDurumlariListesi = db.TblPlakaDurumları
                        .Where(p => p.Durum == "BOŞTA") // Sadece "BOŞTA" durumundaki kayıtları al
                        .Select(p => new
                        {
                            p.ID,
                            p.Plaka,
                            p.SonIl,
                            p.SonIlce,
                            p.Durum,
                            p.TahminiVarisZamani,
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

                    // Mesafe sütununu ekle
                    var resultList = plakaDurumlariListesi.Select(p => new
                    {
                        p.ID,
                        p.Plaka,
                        p.SonIl,
                        p.SonIlce,
                        p.Durum,
                        p.TahminiVarisZamani,
                        MesafeKm = p.YuklemeYeriArasındaKm
                    }).ToList();

                    bindingSourcePlakaOnerisi.DataSource = resultList;
                    gridControlPlakaOnerisi.DataSource = bindingSourcePlakaOnerisi;

                    var view = gridControlPlakaOnerisi.MainView as GridView;
                    if (view != null)
                    {
                        view.OptionsSelection.MultiSelect = true;
                        view.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;

                        if (view.Columns["Mesafe (km)"] != null)
                        {
                            view.Columns["Mesafe (km)"].Visible = false;
                            view.Columns.Remove(view.Columns["Mesafe (km)"]);
                        }

                        // "Plaka Ata" adında yeni bir sütun ekle
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

                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit
                        {
                            TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                        };

                        buttonEdit.Buttons[0].Caption = "SEÇ";
                        buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

                        buttonEdit.ButtonClick += (sender, e) =>
                        {
                            int rowHandle = view.FocusedRowHandle;
                            string plaka = view.GetRowCellValue(rowHandle, "Plaka").ToString(); // Plaka sütunundaki değeri al

                            // gridControlSiparis'e erişerek Plaka kısmını güncelle
                            var siparisView = gridControlSiparis.MainView as GridView;
                            if (siparisView != null)
                            {
                                // Seçili satırın Plaka alanını güncelle
                                int siparisRowHandle = siparisView.FocusedRowHandle;
                                siparisView.SetRowCellValue(siparisRowHandle, "Plaka", plaka); // Plaka sütununa plaka bilgisini yaz
                            }

                            using (FiloTakipEntities7 dbContext = new FiloTakipEntities7())
                            {
                                var plakaDurumu = dbContext.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka); // Plakayı bul
                                if (plakaDurumu != null)
                                {
                                    // Durumu "PLAKA ATANDI" olarak güncelle
                                    plakaDurumu.Durum = "PLAKA ATANDI";

                                    try
                                    {
                                        dbContext.SaveChanges(); // Veritabanına kaydet
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








        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Location.Y > this.Height - panel1.Height) // Panel yukarı hareket etsin
            {
                panel1.Location = new Point(panel1.Location.X, panel1.Location.Y - 5); // 5 birim yukarı hareket et
            }
            else
            {
                myTimer.Stop(); // Panel istenilen konuma ulaştığında timer'ı durdur

                // Seçili siparişi al
                var selectedOrders = GetSelectedOrders();
                if (selectedOrders.Count > 0)
                {
                    var selectedOrder = selectedOrders.First(); // İlk seçili siparişi al
                    string yuklemeIl = selectedOrder.YuklemeIl;
                    string yuklemeIlce = selectedOrder.YuklemeIlce;

                    // ListelePlakaOnerisi metodunu çağır ve parametreleri geç
                    ListelePlakaOnerisi(yuklemeIl, yuklemeIlce);
                }
            }
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
                    using (FiloTakipEntities7 db = new FiloTakipEntities7())
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

        private void PictureEdit1_Click(object sender, EventArgs e)
        {
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            // Paneli kapat
            panel1.Visible = false;
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
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
            {
                return db.TblSiparisListesi.ToList(); // İlgili veri kaynağını döndürün
            }
        }

           

        private void FrmPlanlamaEkranı_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'filoTakipDataSet18.TblSiparisListesi' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblSiparisListesiTableAdapter.Fill(this.filoTakipDataSet18.TblSiparisListesi);

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

            // Plaka sütunu doluysa işlemlere devam et
            var siparis = (TblSiparisListesi)siparisView.GetRow(siparisView.FocusedRowHandle);

            // Yeni TblPlakaAtandi nesnesi oluştur
            var plakaAtandi = new TblPlakaAtandi
            {
                Plaka = plaka, // Plaka değerini kullan
                PlakaDurumu = "PLAKA ATANDI",
                SeferTarihi = DateTime.Now,
                MusteriAdi = siparis.MusteriAdi,
                YuklemeNoktasi = siparis.YuklemeNoktasi,
                YuklemeIl = siparis.YuklemeIl,
                YuklemeIlcesi = siparis.YuklemeIlce,
                TeslimNoktasi = siparis.TeslimNoktasi,
                TeslimIli = siparis.TeslimIl,
                TeslimIlcesi = siparis.TeslimIlce
            };

            // Plaka atandı bilgisi ver
            DialogResult result = MessageBox.Show($"{plaka} plakası atandı. Devam etmek ister misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (FiloTakipEntities7 dbContext = new FiloTakipEntities7())
                {
                    // TblPlakaAtandi nesnesini veritabanına ekle
                    dbContext.TblPlakaAtandi.Add(plakaAtandi);
                    dbContext.SaveChanges(); // Veritabanına kaydet

                    // Seçili siparişi silmek için mevcut DbContext ile tekrar al
                    var siparisToDelete = dbContext.TblSiparisListesi.Find(siparis.ID);

                    if (siparisToDelete != null)
                    {
                        // Seçili siparişi sil
                        dbContext.TblSiparisListesi.Remove(siparisToDelete);
                        dbContext.SaveChanges(); // Değişiklikleri kaydet

                        // TblPlakaDurumları tablosunda durumu güncelle ve sürücü bilgilerini al
                        var plakaDurum = dbContext.TblPlakaDurumları.FirstOrDefault(p => p.Plaka == plaka);
                        if (plakaDurum != null)
                        {
                            // Durumu güncelle
                            plakaDurum.Durum = "PLAKA ATANDI"; // Durumu güncelle

                            // Sürücü bilgilerini al ve TblPlakaAtandi'ye ekle
                            plakaAtandi.SurucuAdSoyad = plakaDurum.SurucuAdı; // Sürücü adı
                            plakaAtandi.SurucuTelefon = plakaDurum.SurucuTelefon; // Sürücü telefon
                            plakaAtandi.SurucuTC = plakaDurum.SurucuTC; // Sürücü TC

                            // Güncellemeleri yap
                            plakaDurum.SeferTarihi = DateTime.Now; // SeferTarihi sütununa günün tarihini getir
                            plakaDurum.YuklemeNoktası = siparis.YuklemeNoktasi; // YuklemeNoktası değerini getir
                            plakaDurum.TeslimNoktası = siparis.TeslimNoktasi; // TeslimNoktası değerini getir
                            plakaDurum.SonIl = siparis.TeslimIl; // TeslimIl değerini getir
                            plakaDurum.SonIlce = siparis.TeslimIlce; // TeslimIlce değerini getir

                            // SonNokta değerini TblBolgeler tablosundan al
                            var bolge = dbContext.TblBolgeler.FirstOrDefault(b => b.İl == plakaDurum.SonIl);
                            plakaDurum.SonNokta = bolge?.Bolge; // Eğer bulursa, Bolge değerini al

                            dbContext.SaveChanges(); // Değişiklikleri kaydet
                        }

                        // TblPlakaAtandi tablosunda plaka durumunu güncelle
                        var plakaAtandiToUpdate = dbContext.TblPlakaAtandi.FirstOrDefault(pa => pa.Plaka == plaka);
                        if (plakaAtandiToUpdate != null)
                        {
                            plakaAtandiToUpdate.PlakaDurumu = "PLAKA ATANDI"; // Durum güncelle
                            dbContext.SaveChanges(); // Değişiklikleri kaydet
                        }

                        // FrmPlanlamaEkranı formunu güncelle
                        var frmPlanlamaEkranı = Application.OpenForms.OfType<FrmPlanlamaEkranı>().FirstOrDefault();
                        if (frmPlanlamaEkranı != null)
                        {
                            frmPlanlamaEkranı.LoadData(); // Formun güncellenmesi için LoadData() metodunu çağırın
                        }

                        MessageBox.Show("Plaka atandı, durumu güncellendi ve sipariş güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silmek için sipariş bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }






        public void LoadData()
        {
            // Veritabanından verileri yükleyin
            using (FiloTakipEntities7 dbContext = new FiloTakipEntities7())
            {
                // Örneğin, bir grid kontrolüne veri yüklemek için
                var data = dbContext.TblSiparisListesi.ToList();
                bindingSourceSiparisListesi.DataSource = data; // bindingSourceSiparisListesi adında bir BindingSource kullandığınızı varsayıyorum
                gridControlSiparis.DataSource = bindingSourceSiparisListesi; // gridControlSiparis adında bir GridControl kullandığınızı varsayıyorum
            }
        }
    }

}



































