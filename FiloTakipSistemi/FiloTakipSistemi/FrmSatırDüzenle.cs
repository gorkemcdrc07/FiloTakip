using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmSatırDüzenle : Form
    {
        public string ReferansNo { get; set; }
        public string TMSOrderID { get; set; }
        public string Firma { get; set; }
        public string Proje { get; set; }
        public string HizmetTipi { get; set; }
        public string IstenilenAracTipi { get; set; }
        public string SiparisNumarasi { get; set; }
        public string SiparisTarihi { get; set; }
        public string YuklemeTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public string NoktaSayisi { get; set; }
        public string YuklemeNoktasi { get; set; }
        public string YuklemeIli { get; set; }
        public string YuklemeIlcesi { get; set; }
        public string SiparisDurumu { get; set; }
        public string TeslimNoktasi { get; set; }
        public string TeslimIli { get; set; }
        public string TeslimIlcesi { get; set; }
        public string MusteriSiparisNo { get; set; }
        public string MusteriReferansNo { get; set; }
        public string Aciklama { get; set; }
        public string SiparisAcan { get; set; }
        public string SiparisAcilisZamani { get; set; }
        public string PozisyonNo { get; set; }
        public string ToplamKg { get; set; }

        public FrmSatırDüzenle()
        {
            InitializeComponent();
        }

        // Satır verilerini gridControl1'e yükleme
        public void LoadSelectedRow(DataRow selectedRow)
        {
            if (selectedRow != null)
            {
                // Verileri formdaki özelliklere aktarma
                ReferansNo = selectedRow["ReferansNo"].ToString();
                TMSOrderID = selectedRow["TMSOrderID"].ToString();
                Firma = selectedRow["Firma"].ToString();
                Proje = selectedRow["Proje"].ToString();
                HizmetTipi = selectedRow["HizmetTipi"].ToString();
                IstenilenAracTipi = selectedRow["IstenilenAracTipi"].ToString();
                SiparisNumarasi = selectedRow["SiparisNumarasi"].ToString();
                SiparisTarihi = selectedRow["SiparisTarihi"].ToString();
                YuklemeTarihi = selectedRow["YuklemeTarihi"].ToString();
                TeslimTarihi = selectedRow["TeslimTarihi"].ToString();
                NoktaSayisi = selectedRow["NoktaSayisi"].ToString();
                YuklemeNoktasi = selectedRow["YuklemeNoktasi"].ToString();
                YuklemeIli = selectedRow["YuklemeIli"].ToString();
                YuklemeIlcesi = selectedRow["YuklemeIlcesi"].ToString();
                SiparisDurumu = selectedRow["SiparisDurumu"].ToString();
                TeslimNoktasi = selectedRow["TeslimNoktasi"].ToString();
                TeslimIli = selectedRow["TeslimIli"].ToString();
                TeslimIlcesi = selectedRow["TeslimIlcesi"].ToString();
                MusteriSiparisNo = selectedRow["MusteriSiparisNo"].ToString();
                MusteriReferansNo = selectedRow["MusteriReferansNo"].ToString();
                Aciklama = selectedRow["Aciklama"].ToString();
                SiparisAcan = selectedRow["SiparisAcan"].ToString();
                SiparisAcilisZamani = selectedRow["SiparisAcilisZamani"].ToString();
                PozisyonNo = selectedRow["PozisyonNo"].ToString();
                ToplamKg = selectedRow["ToplamKg"].ToString();
            }

            // Yeni DataTable oluşturulup gridControl1'e veri kaydedilmesi
            DataTable dt = new DataTable();

            // Kolonları ekleyelim
            dt.Columns.Add("SIRA"); // Yeni SIRA sütunu ekliyoruz
            dt.Columns.Add("ReferansNo");
            dt.Columns.Add("TMSOrderID");
            dt.Columns.Add("Firma");
            dt.Columns.Add("Proje");
            dt.Columns.Add("HizmetTipi");
            dt.Columns.Add("IstenilenAracTipi");
            dt.Columns.Add("SiparisNumarasi");
            dt.Columns.Add("SiparisTarihi");
            dt.Columns.Add("YuklemeTarihi");
            dt.Columns.Add("TeslimTarihi");
            dt.Columns.Add("NoktaSayisi");
            dt.Columns.Add("YuklemeNoktasi");
            dt.Columns.Add("YuklemeIli");
            dt.Columns.Add("YuklemeIlcesi");
            dt.Columns.Add("SiparisDurumu");
            dt.Columns.Add("TeslimNoktasi");
            dt.Columns.Add("TeslimIli");
            dt.Columns.Add("TeslimIlcesi");
            dt.Columns.Add("MusteriSiparisNo");
            dt.Columns.Add("MusteriReferansNo");
            dt.Columns.Add("Aciklama");
            dt.Columns.Add("SiparisAcan");
            dt.Columns.Add("SiparisAcilisZamani");
            dt.Columns.Add("PozisyonNo");
            dt.Columns.Add("ToplamKg");

            // Yeni bir satır ekleyelim
            DataRow dr = dt.NewRow();
            dr["SIRA"] = 1;  // İlk satıra SIRA değerini atıyoruz
            dr["ReferansNo"] = ReferansNo;
            dr["TMSOrderID"] = TMSOrderID;
            dr["Firma"] = Firma;
            dr["Proje"] = Proje;
            dr["HizmetTipi"] = HizmetTipi;
            dr["IstenilenAracTipi"] = IstenilenAracTipi;
            dr["SiparisNumarasi"] = SiparisNumarasi;
            dr["SiparisTarihi"] = SiparisTarihi;
            dr["YuklemeTarihi"] = YuklemeTarihi;
            dr["TeslimTarihi"] = TeslimTarihi;
            dr["NoktaSayisi"] = NoktaSayisi;
            dr["YuklemeNoktasi"] = YuklemeNoktasi;
            dr["YuklemeIli"] = YuklemeIli;
            dr["YuklemeIlcesi"] = YuklemeIlcesi;
            dr["SiparisDurumu"] = SiparisDurumu;
            dr["TeslimNoktasi"] = TeslimNoktasi;
            dr["TeslimIli"] = TeslimIli;
            dr["TeslimIlcesi"] = TeslimIlcesi;
            dr["MusteriSiparisNo"] = MusteriSiparisNo;
            dr["MusteriReferansNo"] = MusteriReferansNo;
            dr["Aciklama"] = Aciklama;
            dr["SiparisAcan"] = SiparisAcan;
            dr["SiparisAcilisZamani"] = SiparisAcilisZamani;
            dr["PozisyonNo"] = PozisyonNo;
            dr["ToplamKg"] = ToplamKg;

            dt.Rows.Add(dr);

            // gridControl1'e DataTable'ı aktaralım
            gridControl1.DataSource = dt;
        }

        public void LoadFilteredRows(DataTable filteredRows)
        {
            // gridControl1'deki mevcut veriyi sıfırlayalım
            gridControl1.DataSource = null;

            // Yeni DataTable oluşturuluyor
            DataTable dt = filteredRows.Clone(); // Aynı şemayı kopyalar

            // "SIRA" sütunu eklemek
            dt.Columns.Add("SIRA");

            int rowIndex = 1; // Başlangıç sıra numarası
            foreach (DataRow row in filteredRows.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow.ItemArray = row.ItemArray;  // Mevcut veriyi kopyalıyoruz
                newRow["SIRA"] = rowIndex++;  // "SIRA" sütununu dolduruyoruz
                dt.Rows.Add(newRow);
            }

            // gridControl1'e yeni veriyi aktaralım
            gridControl1.DataSource = dt;

            // SIRA sütunu için ComboBox oluşturuluyor
            RepositoryItemComboBox comboBox = new RepositoryItemComboBox();
            comboBox.Items.AddRange(Enumerable.Range(1, dt.Rows.Count).Select(i => i.ToString()).ToArray());
            gridControl1.RepositoryItems.Add(comboBox);

            // SIRA sütununu ComboBox ile özelleştirelim
            gridView1.Columns["SIRA"].ColumnEdit = comboBox;

            // Seçilen değerlere göre ComboBox'ı dinamik olarak güncelleme
            gridView1.CellValueChanged += (sender, e) =>
            {
                if (e.Column.FieldName == "SIRA")
                {
                    // Seçilen değeri alıyoruz
                    string selectedValue = e.Value.ToString();

                    // Diğer satırlarda seçilen değeri pasif yapalım
                    List<string> selectedValues = new List<string>();

                    foreach (var rowHandle in gridView1.GetSelectedRows())
                    {
                        if (gridView1.IsDataRow(rowHandle))
                        {
                            // ComboBox'ı alalım
                            var row = gridView1.GetDataRow(rowHandle);
                            RepositoryItemComboBox combo = (RepositoryItemComboBox)gridView1.Columns["SIRA"].ColumnEdit;

                            // Mevcut seçenekleri alalım
                            List<string> availableItems = new List<string>(combo.Items.Cast<string>());

                            // Önceden seçilenleri çıkarıyoruz
                            foreach (var selected in selectedValues)
                            {
                                if (availableItems.Contains(selected))
                                {
                                    availableItems.Remove(selected);
                                }
                            }

                            // Yeni seçilen değeri de ekleyelim
                            selectedValues.Add(selectedValue);

                            // ComboBox'taki seçenekleri güncelleyelim
                            combo.Items.Clear();
                            combo.Items.AddRange(availableItems.ToArray());
                        }
                    }

                    // Grid'i güncelleme
                    gridControl1.RefreshDataSource();
                }
            };
        }

        private void BtnSırala_Click(object sender, EventArgs e)
        {
            // gridControl1'deki "SIRA" sütunundaki sıralamayı alıyoruz
            DataTable dt = gridControl1.DataSource as DataTable;

            // Eğer DataTable boş değilse, sıralama işlemi yapılabilir
            if (dt != null)
            {
                // Sıralama işlemi, "SIRA" sütunundaki değeri kontrol eder ve sıralar
                var sortedRows = dt.AsEnumerable()
                    .OrderBy(row => row["SIRA"] == DBNull.Value ? int.MaxValue : Convert.ToInt32(row["SIRA"]))
                    .ToList();

                // Sıralama sonrası yeni sıralanmış DataTable'ı elde edelim
                DataTable sortedTable = sortedRows.CopyToDataTable();

                // FrmVeriEklemeEkranı formunu buluyoruz (burada formu parametre olarak gönderiyoruz)
                FrmVeriEklemeEkranı frmVeriEkleme = Application.OpenForms.OfType<FrmVeriEklemeEkranı>().FirstOrDefault();

                if (frmVeriEkleme != null)
                {
                   
                }

                // gridControl1'deki mevcut verileri koruyarak sıralama işlemi yapıyoruz
                gridControl1.DataSource = sortedTable;

                // GridView'de sıralamayı yansıtmak için:
                gridView1.RefreshData();
            }
        }







    }
}
