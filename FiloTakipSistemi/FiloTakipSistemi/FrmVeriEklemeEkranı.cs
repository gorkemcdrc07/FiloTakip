using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using FiloTakipSistemi.Entity7;
using System.Drawing;


namespace FiloTakipSistemi
{
    public partial class FrmVeriEklemeEkranı : Form
    {
        private DataTable hedefDataTable;
        private FiloTakipEntities9 context; // Declare the context
        private DataTable sortedData; // Sıralanmış veriler
        private DataTable allData;    // Tüm verile

        public FrmVeriEklemeEkranı()
        {
            InitializeComponent();
            gridViewVeriler.RowClick += gridControlVeriler_RowClick;



            // Hedef DataTable'ı oluşturuyoruz
            hedefDataTable = new DataTable();

            // Sütunları tanımlıyoruz (örneğin)
            hedefDataTable.Columns.Add("ReferansNo", typeof(int));
            hedefDataTable.Columns.Add("TMSOrderID", typeof(int));
            hedefDataTable.Columns.Add("Firma", typeof(string));
            hedefDataTable.Columns.Add("Proje", typeof(string));
            hedefDataTable.Columns.Add("HizmetTipi", typeof(string));
            hedefDataTable.Columns.Add("IstenilenAracTipi", typeof(string));
            hedefDataTable.Columns.Add("SiparisNumarasi", typeof(string));
            hedefDataTable.Columns.Add("SiparisTarihi", typeof(DateTime));
            hedefDataTable.Columns.Add("YuklemeTarihi", typeof(DateTime));
            hedefDataTable.Columns.Add("TeslimTarihi", typeof(DateTime));
            hedefDataTable.Columns.Add("NoktaSayisi", typeof(int));
            hedefDataTable.Columns.Add("YuklemeNoktasi", typeof(string));
            hedefDataTable.Columns.Add("YuklemeIli", typeof(string));
            hedefDataTable.Columns.Add("YuklemeIlcesi", typeof(string));
            hedefDataTable.Columns.Add("SiparisDurumu", typeof(string));
            hedefDataTable.Columns.Add("TeslimNoktasi", typeof(string));
            hedefDataTable.Columns.Add("TeslimIli", typeof(string));
            hedefDataTable.Columns.Add("TeslimIlcesi", typeof(string));
            hedefDataTable.Columns.Add("MusteriSiparisNo", typeof(string));
            hedefDataTable.Columns.Add("MusteriReferansNo", typeof(string));
            hedefDataTable.Columns.Add("Aciklama", typeof(string));
            hedefDataTable.Columns.Add("SiparisAcan", typeof(string));
            hedefDataTable.Columns.Add("SiparisAcilisZamani", typeof(DateTime));
            hedefDataTable.Columns.Add("PozisyonNo", typeof(string));
            hedefDataTable.Columns.Add("ToplamKg", typeof(decimal));
        }

        // 'AktarVeri' metodunu ekliyoruz
        public void AktarVeri(DataTable kaynakDataTable)
        {
            if (kaynakDataTable == null || kaynakDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Aktarılacak veri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kaynak DataTable'dan hedef DataTable'a veri aktarımı
            foreach (DataRow kaynakRow in kaynakDataTable.Rows)
            {
                DataRow hedefRow = hedefDataTable.NewRow();

                // Kaynak DataTable'dan hedef DataTable'a sütun eşleştirme işlemi
                hedefRow["TMSOrderID"] = kaynakRow["TMSOrderID"];
                hedefRow["Firma"] = kaynakRow["Firma"];
                hedefRow["Proje"] = kaynakRow["Proje"];
                hedefRow["HizmetTipi"] = kaynakRow["Hizmet Tipi"];
                hedefRow["IstenilenAracTipi"] = kaynakRow["İstenilen Araç Tipi"];
                hedefRow["SiparisNumarasi"] = kaynakRow["Sipariş Numarası"];
                hedefRow["SiparisTarihi"] = kaynakRow["Sipariş Tarihi"];
                hedefRow["YuklemeTarihi"] = kaynakRow["Yükleme Tarihi"];
                hedefRow["TeslimTarihi"] = kaynakRow["Teslim Tarihi"];
                hedefRow["NoktaSayisi"] = kaynakRow["Nokta Sayısı"];
                hedefRow["YuklemeNoktasi"] = kaynakRow["Yükleme Noktası"];
                hedefRow["YuklemeIli"] = kaynakRow["Yükleme İli"];
                hedefRow["YuklemeIlcesi"] = kaynakRow["Yükleme İlçesi"];
                hedefRow["SiparisDurumu"] = kaynakRow["Sipariş Durumu"];
                hedefRow["TeslimNoktasi"] = kaynakRow["Teslim Noktası"];
                hedefRow["TeslimIli"] = kaynakRow["Teslim İli"];
                hedefRow["TeslimIlcesi"] = kaynakRow["Teslim İlçesi"];
                hedefRow["MusteriSiparisNo"] = kaynakRow["Müşteri Sipariş No"];
                hedefRow["MusteriReferansNo"] = kaynakRow["Müşteri Referans No"];
                hedefRow["Aciklama"] = kaynakRow["Açıklama"];
                hedefRow["SiparisAcan"] = kaynakRow["Sipariş Açan"];
                hedefRow["SiparisAcilisZamani"] = kaynakRow["Siparis Açılış Zamanı"];
                hedefRow["PozisyonNo"] = kaynakRow["Pozisyon No"];
                hedefRow["ToplamKg"] = kaynakRow["Toplam KG"];

                // Hedef tabloya satır ekliyoruz
                hedefDataTable.Rows.Add(hedefRow);
            }

            // gridControlVeriler'e veri atıyoruz
            gridControlVeriler.DataSource = hedefDataTable;
        }

        private void FrmVeriEklemeEkranı_Load(object sender, EventArgs e)
        {

        }




        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Initialize context if it's not already initialized
            if (context == null)
            {
                context = new FiloTakipEntities9();
            }

            // İlk işlev: Verileri kaydet
            SaveData();

            // İkinci işlev: Planlamaya atama işlemi
            AssignToPlanning();

            // İşlemler tamamlandı
            MessageBox.Show("Veriler başarıyla kaydedildi ve planlamaya atandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Verileri kaydetme işlemini yapan metot
        private void SaveData()
        {
            GridView gridView = gridControlVeriler.MainView as GridView;

            if (gridView != null)
            {
                // Teslim noktalarını ve diğer verileri gruplamak için dictionary'ler
                Dictionary<string, List<string>> tmsOrderIDs = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> siparisNumaralari = new Dictionary<string, List<string>>();
                Dictionary<string, List<string>> teslimNoktalar = new Dictionary<string, List<string>>();

                // Diğer sütunlar
                Dictionary<string, string> referansNos = new Dictionary<string, string>();
                Dictionary<string, string> firmalar = new Dictionary<string, string>();
                Dictionary<string, string> projeler = new Dictionary<string, string>();
                Dictionary<string, string> hizmetTipleri = new Dictionary<string, string>();
                Dictionary<string, string> istenilenAracTipleri = new Dictionary<string, string>();
                Dictionary<string, string> yuklemeTarihleri = new Dictionary<string, string>();
                Dictionary<string, string> teslimTarihleri = new Dictionary<string, string>();
                Dictionary<string, string> noktaSayilari = new Dictionary<string, string>();
                Dictionary<string, string> yuklemeNoktasi = new Dictionary<string, string>();
                Dictionary<string, string> yuklemeIli = new Dictionary<string, string>();
                Dictionary<string, string> yuklemeIlcesi = new Dictionary<string, string>();
                Dictionary<string, string> siparisDurumlari = new Dictionary<string, string>();
                Dictionary<string, string> teslimIli = new Dictionary<string, string>();
                Dictionary<string, string> teslimIlcesi = new Dictionary<string, string>();
                Dictionary<string, string> musteriler = new Dictionary<string, string>();
                Dictionary<string, string> aciklamalar = new Dictionary<string, string>();
                Dictionary<string, string> siparisAcanlar = new Dictionary<string, string>();
                Dictionary<string, string> siparisAcilisZamanlari = new Dictionary<string, string>();
                Dictionary<string, string> toplamKg = new Dictionary<string, string>();

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    var pozisyonNo = gridView.GetRowCellValue(i, gridView.Columns["PozisyonNo"])?.ToString();

                    if (!string.IsNullOrEmpty(pozisyonNo))
                    {
                        // Verileri pozisyonNo'ya göre gruplamak
                        AddToGroup(tmsOrderIDs, pozisyonNo, gridView.GetRowCellValue(i, gridView.Columns["TMSOrderID"])?.ToString());
                        AddToGroup(siparisNumaralari, pozisyonNo, gridView.GetRowCellValue(i, gridView.Columns["SiparisNumarasi"])?.ToString());
                        AddToGroup(teslimNoktalar, pozisyonNo, gridView.GetRowCellValue(i, gridView.Columns["TeslimNoktasi"])?.ToString());

                        // Diğer sütunları da aynı şekilde grup edelim
                        referansNos[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["ReferansNo"])?.ToString();
                        firmalar[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["Firma"])?.ToString();
                        projeler[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["Proje"])?.ToString();
                        hizmetTipleri[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["HizmetTipi"])?.ToString();
                        istenilenAracTipleri[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["IstenilenAracTipi"])?.ToString();
                        yuklemeTarihleri[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["YuklemeTarihi"])?.ToString();
                        teslimTarihleri[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["TeslimTarihi"])?.ToString();
                        noktaSayilari[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["NoktaSayisi"])?.ToString();
                        yuklemeNoktasi[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["YuklemeNoktasi"])?.ToString();
                        yuklemeIli[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["YuklemeIli"])?.ToString();
                        yuklemeIlcesi[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["YuklemeIlcesi"])?.ToString();
                        siparisDurumlari[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["SiparisDurumu"])?.ToString();
                        teslimIli[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["TeslimIli"])?.ToString();
                        teslimIlcesi[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["TeslimIlcesi"])?.ToString();
                        musteriler[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["MusteriSiparisNo"])?.ToString();
                        aciklamalar[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["Aciklama"])?.ToString();
                        siparisAcanlar[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["SiparisAcan"])?.ToString();
                        siparisAcilisZamanlari[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["SiparisAcilisZamani"])?.ToString();
                        toplamKg[pozisyonNo] = gridView.GetRowCellValue(i, gridView.Columns["ToplamKg"])?.ToString();

                        // TblDetay'a veri kaydet
                        TblDetay detayRecord = new TblDetay
                        {
                            PozisyonNo = pozisyonNo,
                            TMSOrderID = gridView.GetRowCellValue(i, gridView.Columns["TMSOrderID"])?.ToString(),
                            SiparisNumarasi = gridView.GetRowCellValue(i, gridView.Columns["SiparisNumarasi"])?.ToString(),
                            TeslimNoktasi = gridView.GetRowCellValue(i, gridView.Columns["TeslimNoktasi"])?.ToString(),
                            ReferansNo = referansNos[pozisyonNo],
                            Firma = firmalar[pozisyonNo],
                            Proje = projeler[pozisyonNo],
                            HizmetTipi = hizmetTipleri[pozisyonNo],
                            IstenilenAracTipi = istenilenAracTipleri[pozisyonNo],
                            YuklemeTarihi = ConvertToDateTime(yuklemeTarihleri[pozisyonNo]),
                            TeslimTarihi = ConvertToDateTime(teslimTarihleri[pozisyonNo]),
                            NoktaSayisi = noktaSayilari[pozisyonNo],
                            YuklemeNoktasi = yuklemeNoktasi[pozisyonNo],
                            YuklemeIli = yuklemeIli[pozisyonNo],
                            YuklemeIlcesi = yuklemeIlcesi[pozisyonNo],
                            SiparisDurumu = siparisDurumlari[pozisyonNo],
                            TeslimIli = teslimIli[pozisyonNo],
                            TeslimIlcesi = teslimIlcesi[pozisyonNo],
                            MusteriSiparisNo = musteriler[pozisyonNo],
                            Aciklama = aciklamalar[pozisyonNo],
                            SiparisAcan = siparisAcanlar[pozisyonNo],
                            SiparisAcilisZamani = ConvertToDateTime(siparisAcilisZamanlari[pozisyonNo]),
                            ToplamKg = toplamKg[pozisyonNo]
                        };

                        context.TblDetay.Add(detayRecord); // TblDetay'a kaydet
                    }
                }

                // Zaten var olan TMSOrderID'leri kontrol et
                var existingTmsOrderIDs = context.TblSiparisListesi.Select(s => s.TMSOrderID).ToList();
                List<string> duplicateOrderIDs = new List<string>();

                // Her PozisyonNo için tek bir kayıt oluştur
                // Her PozisyonNo için tek bir kayıt oluştur
                foreach (var pozisyon in tmsOrderIDs.Keys)
                {
                    var mergedTmsOrderID = string.Join(";", tmsOrderIDs[pozisyon]);
                    var mergedSiparisNumarasi = string.Join(";", siparisNumaralari[pozisyon]);
                    var mergedTeslimNoktasi = string.Join(";", teslimNoktalar[pozisyon]);

                    if (existingTmsOrderIDs.Contains(mergedTmsOrderID))
                    {
                        duplicateOrderIDs.Add(mergedTmsOrderID);
                        continue; // Zaten var olan TMSOrderID atlanır
                    }

                    // TblSiparisListesi kaydını oluştur
                    TblSiparisListesi siparisRecord = new TblSiparisListesi
                    {
                        ReferansNo = referansNos[pozisyon],
                        TMSOrderID = mergedTmsOrderID,
                        Firma = firmalar[pozisyon],
                        Proje = projeler[pozisyon],
                        HizmetTipi = hizmetTipleri[pozisyon],
                        IstenilenAracTipi = istenilenAracTipleri[pozisyon],
                        SiparisNumarasi = mergedSiparisNumarasi,
                        SiparisTarihi = ConvertToDateTime(yuklemeTarihleri[pozisyon]),
                        YuklemeTarihi = ConvertToDateTime(yuklemeTarihleri[pozisyon]),
                        TeslimTarihi = ConvertToDateTime(teslimTarihleri[pozisyon]),
                        NoktaSayisi = noktaSayilari[pozisyon],
                        YuklemeNoktasi = yuklemeNoktasi[pozisyon],
                        YuklemeIli = yuklemeIli[pozisyon],
                        YuklemeIlcesi = yuklemeIlcesi[pozisyon],
                        SiparisDurumu = siparisDurumlari[pozisyon],
                        TeslimNoktasi = mergedTeslimNoktasi,
                        TeslimIli = teslimIli[pozisyon],
                        TeslimIlcesi = teslimIlcesi[pozisyon],
                        MusteriSiparisNo = musteriler[pozisyon],
                        MusteriReferansNo = musteriler[pozisyon],
                        Aciklama = aciklamalar[pozisyon],
                        SiparisAcan = siparisAcanlar[pozisyon],
                        SiparisAcilisZamani = ConvertToDateTime(siparisAcilisZamanlari[pozisyon]),
                        PozisyonNo = pozisyon,
                        ToplamKg = toplamKg[pozisyon]
                    };

                    context.TblSiparisListesi.Add(siparisRecord); // TblSiparisListesi'ne kaydet

                    // TblSiparisListesiYedek kaydını oluştur (Aynı verileri yedek tabloya kaydet)
                    TblSiparisListesiYedek siparisYedekRecord = new TblSiparisListesiYedek
                    {
                        ReferansNo = referansNos[pozisyon],
                        TMSOrderID = mergedTmsOrderID,
                        Firma = firmalar[pozisyon],
                        Proje = projeler[pozisyon],
                        HizmetTipi = hizmetTipleri[pozisyon],
                        IstenilenAracTipi = istenilenAracTipleri[pozisyon],
                        SiparisNumarasi = mergedSiparisNumarasi,
                        SiparisTarihi = ConvertToDateTime(yuklemeTarihleri[pozisyon]),
                        YuklemeTarihi = ConvertToDateTime(yuklemeTarihleri[pozisyon]),
                        TeslimTarihi = ConvertToDateTime(teslimTarihleri[pozisyon]),
                        NoktaSayisi = noktaSayilari[pozisyon],
                        YuklemeNoktasi = yuklemeNoktasi[pozisyon],
                        YuklemeIli = yuklemeIli[pozisyon],
                        YuklemeIlcesi = yuklemeIlcesi[pozisyon],
                        SiparisDurumu = siparisDurumlari[pozisyon],
                        TeslimNoktasi = mergedTeslimNoktasi,
                        TeslimIli = teslimIli[pozisyon],
                        TeslimIlcesi = teslimIlcesi[pozisyon],
                        MusteriSiparisNo = musteriler[pozisyon],
                        MusteriReferansNo = musteriler[pozisyon],
                        Aciklama = aciklamalar[pozisyon],
                        SiparisAcan = siparisAcanlar[pozisyon],
                        SiparisAcilisZamani = ConvertToDateTime(siparisAcilisZamanlari[pozisyon]),
                        PozisyonNo = pozisyon,
                        ToplamKg = toplamKg[pozisyon]
                    };

                    context.TblSiparisListesiYedek.Add(siparisYedekRecord); // TblSiparisListesiYedek'e kaydet
                }

                // Değişiklikleri kaydet
                context.SaveChanges();


                if (duplicateOrderIDs.Count > 0)
                {
                    MessageBox.Show($"Aşağıdaki TMSOrderID'ler zaten mevcut: {string.Join(", ", duplicateOrderIDs)}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }





        private void AddToGroup(Dictionary<string, List<string>> group, string key, string value)
        {
            if (!group.ContainsKey(key))
            {
                group[key] = new List<string>();
            }
            if (!string.IsNullOrEmpty(value))
            {
                group[key].Add(value);
            }
        }

        private DateTime? ConvertToDateTime(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, out DateTime result))
            {
                return result;
            }
            return null;
        }



        private DateTime ConvertToDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                throw new InvalidOperationException("Tarih değeri null olamaz.");
            }

            if (DateTime.TryParse(value.ToString(), out DateTime result))
            {
                return result;
            }

            throw new FormatException($"Geçersiz tarih formatı: {value}");
        }


        // Planlamaya atama işlemi (gerekirse bunu özelleştirebilirsiniz)
        private void AssignToPlanning()
        {
            // Placeholder for your logic to assign data to the planning system
        }

        // Global bir DataTable değişkeni tanımlıyoruz
        private DataTable allRowsData;

        private DataTable originalData; // gridControlVeriler'in orijinal verilerini tutacak değişken

        private void gridControlVeriler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridView != null && e.RowHandle >= 0)
            {
                DataRow selectedRow = gridView.GetDataRow(e.RowHandle);

                if (selectedRow != null)
                {
                    string pozisyonNo = selectedRow["PozisyonNo"].ToString();

                    // Aynı PozisyonNo'ya sahip diğer satırları filtrele
                    DataTable filteredData = GetRowsByPozisyonNo(pozisyonNo);



                    // İlk veriyi sakla (arkada tutma)
                    originalData = (gridControlVeriler.DataSource as DataTable);

                    // Ekstra grid'i göster
                    ShowExtraGridOnSameForm(filteredData);
                }
                else
                {
                    MessageBox.Show("Seçilen satır boş!"); // Hata tespiti
                }
            }
            else
            {
                MessageBox.Show("GridView veya RowHandle geçersiz."); // Hata tespiti
            }
        }

        private DataTable GetRowsByPozisyonNo(string pozisyonNo)
        {
            DataTable filteredData = new DataTable();

            // gridControlVeriler'in veri kaynağını al (örneğin: DataTable)
            DataTable originalData = (gridControlVeriler.DataSource as DataTable);

            if (originalData != null)
            {
                // PozisyonNo'ya göre filtreleme yap
                var rows = originalData.Select($"PozisyonNo = '{pozisyonNo}'");

                // Yeni DataTable'ı doldur
                filteredData = originalData.Clone(); // Aynı yapıya sahip yeni bir DataTable oluştur
                foreach (var row in rows)
                {
                    filteredData.ImportRow(row);
                }
            }

            return filteredData;
        }

        private void ShowExtraGridOnSameForm(DataTable rowData)
        {
            // Eğer daha önce eklenmiş bir GridControl varsa, güncelle ve ön plana getir
            var existingGrid = this.Controls.Find("extraGridControl", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;
            if (existingGrid != null)
            {
                existingGrid.DataSource = rowData;
                existingGrid.BringToFront(); // GridControl'ü ön plana getir
                existingGrid.Refresh();
                return;
            }

            // Yeni bir GridControl oluştur ve forma ekle
            DevExpress.XtraGrid.GridControl extraGridControl = new DevExpress.XtraGrid.GridControl
            {
                Name = "extraGridControl",
                DataSource = rowData,
                Dock = DockStyle.Bottom,
                Height = 200
            };

            DevExpress.XtraGrid.Views.Grid.GridView extraGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            extraGridControl.MainView = extraGridView;
            extraGridControl.ViewCollection.Add(extraGridView);

            // "Sıra" sütunu varsa düzenle, yoksa ekle
            if (!rowData.Columns.Contains("Sıra"))
            {
                rowData.Columns.Add("Sıra", typeof(int));

                // Varsayılan sıra değerlerini ekle
                for (int i = 0; i < rowData.Rows.Count; i++)
                {
                    rowData.Rows[i]["Sıra"] = i + 1; // Başlangıç sırası mevcut sıraya göre
                }
            }

            // Grid'i forma ekle
            this.Controls.Add(extraGridControl);

            // GridView ayarları
            extraGridView.OptionsView.ShowGroupPanel = false;
            extraGridView.BestFitColumns();
            extraGridView.OptionsBehavior.Editable = true; // Satırların düzenlenebilir olmasını sağla
            extraGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;

            // "Sıra" sütununu düzenlenebilir yap
            extraGridView.Columns["Sıra"].OptionsColumn.AllowEdit = true;

            // Validasyon işlemleri için ValidatingEditor olayı
            extraGridView.ValidatingEditor += (sender, e) =>
            {
                var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view.FocusedColumn.FieldName == "Sıra")
                {
                    if (!int.TryParse(e.Value?.ToString(), out int newValue) || newValue <= 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Sıra değeri pozitif bir sayı olmalıdır!";
                    }
                }
            };

            // Buton eklemek için bir panel oluştur
            Panel bottomPanel = new Panel
            {
                Name = "bottomPanel",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            // "Sırala" butonunu oluştur
            Button extraButton = new Button
            {
                Text = "Sırala",
                Dock = DockStyle.Fill
            };

            // Sırala butonuna tıklanınca sıralama işlemi
            extraButton.Click += (sender, e) =>
            {
                // Ekstra GridControl'deki görünümden veriyi al
                if (extraGridControl.MainView is DevExpress.XtraGrid.Views.Grid.GridView extraView)
                {
                    var extraDataSource = extraGridControl.DataSource as DataTable;
                    if (extraDataSource == null) return;

                    // Ekstra griddeki TMSOrderID değerlerini al
                    var tmsOrderIds = extraDataSource.AsEnumerable()
                                          .Select(row => row["TMSOrderID"].ToString())
                                          .ToList();

                    // Ana GridControl'ü bul
                    var mainGrid = this.Controls.Find("gridControlVeriler", true).FirstOrDefault() as DevExpress.XtraGrid.GridControl;
                    DataTable mainDataSource = null;

                    // Silinen satırları ve indeksleri saklamak için listeler
                    List<object[]> deletedRows = new List<object[]>();
                    List<int> deletedIndexes = new List<int>();

                    // Ana gridin yüksekliğini sabitle (daha sonrasında restore edilecek)
                    int originalHeight = mainGrid.Height;

                    if (mainGrid != null)
                    {
                        mainDataSource = mainGrid.DataSource as DataTable;
                        if (mainDataSource != null)
                        {
                            // Ana griddeki TMSOrderID'ye göre eşleşen satırları sil ve indekslerini sakla
                            for (int i = mainDataSource.Rows.Count - 1; i >= 0; i--)
                            {
                                var row = mainDataSource.Rows[i];
                                var tmsOrderID = row["TMSOrderID"].ToString();

                                if (tmsOrderIds.Contains(tmsOrderID))
                                {
                                    deletedRows.Insert(0, row.ItemArray); // Satır içeriğini sakla (öncelik sırasını korumak için başa ekliyoruz)
                                    deletedIndexes.Insert(0, i);          // Silinen satırın indeksini sakla
                                    mainDataSource.Rows.RemoveAt(i);
                                }
                            }

                            // Grid'in görünümünü yenilemeden önce boyutu sabitle
                            mainGrid.Height = originalHeight;

                            // Ana grid görünümünü yenile (bunu en son yapalım, gereksiz yenilemelerden kaçınalım)
                            mainGrid.Refresh();
                        }
                    }

                    // Sıralama işlemi: "Sıra" sütununa göre sırala ve 1'den itibaren güncelle
                    var sortedRows = extraDataSource.AsEnumerable()
                                         .OrderBy(row => Convert.ToInt32(row["Sıra"]))
                                         .ToList();

                    // "Sıra" sütununu 1'den itibaren yeniden numaralandır
                    for (int i = 0; i < sortedRows.Count; i++)
                    {
                        sortedRows[i]["Sıra"] = (i + 1).ToString();
                    }

                    // Yeni sıralanmış veriyi gridin veri kaynağına geri yükle
                    extraGridControl.DataSource = sortedRows.CopyToDataTable();
                    extraView.RefreshData();

                    // Kullanıcıdan onay al
                    var result = MessageBox.Show("Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        // Silinen satırları orijinal indekslerine göre geri ekle
                        for (int i = 0; i < deletedRows.Count; i++)
                        {
                            var newRow = mainDataSource.NewRow();
                            newRow.ItemArray = deletedRows[i];
                            mainDataSource.Rows.InsertAt(newRow, deletedIndexes[i]); // Orijinal indeksine ekle
                        }

                        // Grid'in boyutunu eski haline getirme
                        mainGrid.Height = originalHeight;
                        mainGrid.Refresh();
                        MessageBox.Show("İşlem iptal edildi, silinen satırlar eski yerlerine geri getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.Yes)
                    {
                        // Silinen satırların yerini ekstra griddeki sıralı satırlarla doldur
                        for (int i = 0; i < deletedRows.Count; i++)
                        {
                            var sortedRow = sortedRows[i];
                            var newRow = mainDataSource.NewRow();

                            // Sadece ortak sütunları kopyala
                            foreach (DataColumn column in mainDataSource.Columns)
                            {
                                if (extraDataSource.Columns.Contains(column.ColumnName)) // Ortak sütun kontrolü
                                {
                                    newRow[column.ColumnName] = sortedRow[column.ColumnName];
                                }
                            }

                            // Silinen satırın yerine ekstra griddeki sıralı satırı ekle
                            mainDataSource.Rows.InsertAt(newRow, deletedIndexes[i]);
                        }

                        // Grid'in boyutunu eski haline getirme
                        mainGrid.Height = originalHeight;
                        mainGrid.Refresh();

                        MessageBox.Show("İşlem onaylandı, veriler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Ekstra GridControl'ü tamamen kapat
                    extraGridControl.Dispose(); // Ekstra grid'i kapat
                    extraButton.Dispose();
                }
            };








            // Butonu panele ekle ve paneli forma ekle
            bottomPanel.Controls.Add(extraButton);
            this.Controls.Add(bottomPanel);

            // GridControl ve paneli ön plana getir
            extraGridControl.BringToFront();
            bottomPanel.BringToFront();
        }
    }
}



