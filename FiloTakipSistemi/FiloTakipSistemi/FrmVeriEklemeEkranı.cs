using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using FiloTakipSistemi.Entity2;


namespace FiloTakipSistemi
{
    public partial class FrmVeriEklemeEkranı : Form
    {
        private DataTable hedefDataTable;
        private FiloTakipEntities7 context; // Declare the context
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
            // TODO: Bu kod satırı 'filoTakipDataSet26.TblDta' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblDtaTableAdapter.Fill(this.filoTakipDataSet26.TblDta);
        }




        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Initialize context if it's not already initialized
            if (context == null)
            {
                context = new FiloTakipEntities7();
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
                List<string> newTmsOrderIDs = new List<string>(); // Yeni TMSOrderID'leri takip etmek için
                List<string> duplicateTmsOrderIDs = new List<string>(); // TMSOrderID çakışmalarını toplamak için

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    var tmsOrderID = gridView.GetRowCellValue(i, gridView.Columns["TMSOrderID"])?.ToString();
                    var pozisyonNo = gridView.GetRowCellValue(i, gridView.Columns["PozisyonNo"])?.ToString();

                    if (!string.IsNullOrEmpty(tmsOrderID) && !string.IsNullOrEmpty(pozisyonNo))
                    {
                        // TMSOrderID'nin daha önce eklenip eklenmediğini kontrol et
                        var existingRecord = context.TblDta.FirstOrDefault(x => x.TMSOrderID == tmsOrderID);

                        if (existingRecord != null)
                        {
                            // TMSOrderID zaten varsa, duplicate listesine ekle ve bu satırı atla
                            duplicateTmsOrderIDs.Add(tmsOrderID);
                            continue;
                        }
                        else
                        {
                            // Eğer TMSOrderID yoksa, yeni kayıt ekle
                            TblDta newRecord = new TblDta
                            {
                                ReferansNo = gridView.GetRowCellValue(i, gridView.Columns["ReferansNo"])?.ToString(),
                                TMSOrderID = tmsOrderID,
                                Firma = gridView.GetRowCellValue(i, gridView.Columns["Firma"])?.ToString(),
                                Proje = gridView.GetRowCellValue(i, gridView.Columns["Proje"])?.ToString(),
                                HizmetTipi = gridView.GetRowCellValue(i, gridView.Columns["HizmetTipi"])?.ToString(),
                                IstenilenAracTipi = gridView.GetRowCellValue(i, gridView.Columns["IstenilenAracTipi"])?.ToString(),
                                SiparisNumarasi = gridView.GetRowCellValue(i, gridView.Columns["SiparisNumarasi"])?.ToString(),
                                SiparisTarihi = gridView.GetRowCellValue(i, gridView.Columns["SiparisTarihi"])?.ToString(),
                                YuklemeTarihi = gridView.GetRowCellValue(i, gridView.Columns["YuklemeTarihi"])?.ToString(),
                                TeslimTarihi = gridView.GetRowCellValue(i, gridView.Columns["TeslimTarihi"])?.ToString(),
                                NoktaSayisi = gridView.GetRowCellValue(i, gridView.Columns["NoktaSayisi"])?.ToString(),
                                YuklemeNoktasi = gridView.GetRowCellValue(i, gridView.Columns["YuklemeNoktasi"])?.ToString(),
                                YuklemeIli = gridView.GetRowCellValue(i, gridView.Columns["YuklemeIli"])?.ToString(),
                                YuklemeIlcesi = gridView.GetRowCellValue(i, gridView.Columns["YuklemeIlcesi"])?.ToString(),
                                SiparisDurumu = gridView.GetRowCellValue(i, gridView.Columns["SiparisDurumu"])?.ToString(),
                                TeslimNoktasi = gridView.GetRowCellValue(i, gridView.Columns["TeslimNoktasi"])?.ToString(),
                                TeslimIli = gridView.GetRowCellValue(i, gridView.Columns["TeslimIli"])?.ToString(),
                                TeslimIlcesi = gridView.GetRowCellValue(i, gridView.Columns["TeslimIlcesi"])?.ToString(),
                                MusteriSiparisNo = gridView.GetRowCellValue(i, gridView.Columns["MusteriSiparisNo"])?.ToString(),
                                MusteriReferansNo = gridView.GetRowCellValue(i, gridView.Columns["MusteriReferansNo"])?.ToString(),
                                Aciklama = gridView.GetRowCellValue(i, gridView.Columns["Aciklama"])?.ToString(),
                                SiparisAcan = gridView.GetRowCellValue(i, gridView.Columns["SiparisAcan"])?.ToString(),
                                SiparisAcilisZamani = gridView.GetRowCellValue(i, gridView.Columns["SiparisAcilisZamani"])?.ToString(),
                                PozisyonNo = pozisyonNo, // PozisyonNo'yu kaydet
                                ToplamKg = gridView.GetRowCellValue(i, gridView.Columns["ToplamKg"])?.ToString()
                            };

                            context.TblDta.Add(newRecord);
                            newTmsOrderIDs.Add(tmsOrderID); // Yeni eklenen TMSOrderID'yi takip et
                        }
                    }
                }

                // Veriyi kaydediyoruz
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kaydedilen ve duplicate olan kayıtları bildiren mesajı gösteriyoruz
                string message = string.Empty;

                if (duplicateTmsOrderIDs.Any())
                {
                    message += "Bu TMSOrderID'leri zaten mevcut:\n" + string.Join(Environment.NewLine, duplicateTmsOrderIDs);
                }

                if (newTmsOrderIDs.Any())
                {
                    message += (message.Length > 0 ? "\n" : "") + "Yeni TMSOrderID'leri başarıyla kaydedildi:\n" + string.Join(Environment.NewLine, newTmsOrderIDs);
                }

                MessageBox.Show(message, "Veri Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Planlamaya atama işlemi (gerekirse bunu özelleştirebilirsiniz)
        private void AssignToPlanning()
        {
            // Placeholder for your logic to assign data to the planning system
        }
        private void gridControlVeriler_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                // Tıklanan satırın verilerini al
                var selectedRow = gridViewVeriler.GetDataRow(e.RowHandle);

                // Eğer satır verisi varsa
                if (selectedRow != null)
                {
                    // sortedData ve allData'yı burada alıyorsunuz
                    DataTable sortedData = gridViewVeriler.DataSource as DataTable; // GridView'in datasource'undan sortedData'yı alın
                    DataTable allData = sortedData.Copy(); // allData'yı da aynı şekilde alabilirsiniz

                    // FrmRowDetails formunu oluşturun
                    FrmRowDetails frmRowDetails = new FrmRowDetails(sortedData, allData);

                    // Seçilen satır verisini formun SelectedDataRow özelliğine aktarın
                    frmRowDetails.SelectedDataRow = selectedRow;

                    // FrmRowDetails formunu gösterin
                    frmRowDetails.ShowDialog(); // ShowDialog() ile modal olarak açılır
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını göstermek için
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}

