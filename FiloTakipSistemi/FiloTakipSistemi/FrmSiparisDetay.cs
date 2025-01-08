using System;
using System.Data;
using System.Linq;  // FirstOrDefault metodunu kullanabilmek için eklenmeli
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FiloTakipSistemi.Entity7;

namespace FiloTakipSistemi
{
    public partial class FrmSiparisDetay : Form
    {
        public FrmSiparisDetay()
        {
            InitializeComponent();
        }

        // Veriyi GridControl'e bağlamak ve yalnızca belirli sütunları göstermek için metot
        public void LoadData(DataTable data)
        {
            gridControlDetay.DataSource = data;

            // GridView üzerinde sadece belirli sütunları göster
            gridViewDetay.Columns.Clear(); // Eski sütunları temizle

            // RepositoryItemDateEdit eklemek için
            RepositoryItemDateEdit dateEdit = new RepositoryItemDateEdit
            {
                EditMask = "dd.MM.yyyy HH:mm", // Tarih ve saat formatı
                DisplayFormat = { FormatString = "dd.MM.yyyy HH:mm", FormatType = DevExpress.Utils.FormatType.DateTime }
            };

            // Göstermek istediğiniz sütunları tanımlayın ve sütun adlarını özelleştirin
            var columnsWithCaptions = new (string FieldName, string Caption)[]
            {
                ("TMSOrderID", "Sipariş ID"),
                ("Firma", "Firma"),
                ("Proje", "Proje"),
                ("YuklemeNoktasi", "Yükleme Noktası"),
                ("YuklemeIli", "Yükleme İli"),
                ("YuklemeIlcesi", "Yükleme İlçesi"),
                ("TeslimNoktasi", "Teslim Noktası"),
                ("TeslimIli", "Teslim İli"),
                ("TeslimIlcesi", "Teslim İlçesi"),
                ("YuklemeNoktasiVarısTarihi", "Yükleme Noktası Varış Tarihi"),
                ("YuklemeNoktasiCikisTarihi", "Yükleme Noktası Çıkış Tarihi"),
                ("Gerceklesen", "Teslim Noktası Varış Tarihi"),
                ("TeslimNoktasiCikisTarihi", "Teslim Noktası Çıkış Tarihi")
            };

            foreach (var column in columnsWithCaptions)
            {
                var gridColumn = gridViewDetay.Columns.AddVisible(column.FieldName);
                gridColumn.Caption = column.Caption; // Sütun başlığını özelleştir

                // RepositoryItemDateEdit ile tarih ve saat seçimi ekle
                if (column.FieldName == "YuklemeNoktasiVarısTarihi" ||
                    column.FieldName == "YuklemeNoktasiCikisTarihi" ||
                    column.FieldName == "TeslimNoktasiCikisTarihi" ||
                    column.FieldName == "Gerceklesen")
                {
                    gridColumn.ColumnEdit = dateEdit; // Tarih ve saat seçimi olan sütunlara RepositoryItemDateEdit ekle
                }

                // Salt okunur yapmak için
                if (column.FieldName == "TMSOrderID" ||
                    column.FieldName == "Firma" ||
                    column.FieldName == "Proje" ||
                    column.FieldName == "YuklemeNoktasi" ||
                    column.FieldName == "YuklemeIli" ||
                    column.FieldName == "YuklemeIlcesi" ||
                    column.FieldName == "TeslimNoktasi" ||
                    column.FieldName == "TeslimIli" ||
                    column.FieldName == "TeslimIlcesi")
                {
                    gridColumn.OptionsColumn.AllowEdit = false; // Bu sütunları salt okunur yap
                }
            }

            // GridView ayarlarını yenile
            gridViewDetay.BestFitColumns(); // Sütun genişliklerini içeriğe göre ayarla
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            using (var context = new FiloTakipEntities9()) // Entity Framework DbContext
            {
                // Tüm satırları dolaş
                for (int rowHandle = 0; rowHandle < gridViewDetay.RowCount; rowHandle++)
                {
                    if (!gridViewDetay.IsGroupRow(rowHandle)) // Gruplandırılmış satırları atlamak için
                    {
                        // Satırdaki hücre değerlerini al
                        var tmsOrderID = gridViewDetay.GetRowCellValue(rowHandle, "TMSOrderID")?.ToString();

                        var yuklemeNoktasiVarisTarihiStr = gridViewDetay.GetRowCellValue(rowHandle, "YuklemeNoktasiVarısTarihi")?.ToString();
                        DateTime? yuklemeNoktasiVarisTarihi = string.IsNullOrEmpty(yuklemeNoktasiVarisTarihiStr) ? (DateTime?)null : DateTime.TryParse(yuklemeNoktasiVarisTarihiStr, out DateTime parsedVarisTarihi) ? parsedVarisTarihi : (DateTime?)null;

                        var yuklemeNoktasiCikisTarihiStr = gridViewDetay.GetRowCellValue(rowHandle, "YuklemeNoktasiCikisTarihi")?.ToString();
                        DateTime? yuklemeNoktasiCikisTarihi = string.IsNullOrEmpty(yuklemeNoktasiCikisTarihiStr) ? (DateTime?)null : DateTime.TryParse(yuklemeNoktasiCikisTarihiStr, out DateTime parsedCikisTarihi) ? parsedCikisTarihi : (DateTime?)null;

                        var teslimNoktasiCikisTarihiStr = gridViewDetay.GetRowCellValue(rowHandle, "TeslimNoktasiCikisTarihi")?.ToString();
                        DateTime? teslimNoktasiCikisTarihi = string.IsNullOrEmpty(teslimNoktasiCikisTarihiStr) ? (DateTime?)null : DateTime.TryParse(teslimNoktasiCikisTarihiStr, out DateTime parsedTeslimCikisTarihi) ? parsedTeslimCikisTarihi : (DateTime?)null;

                        var gerceklesenStr = gridViewDetay.GetRowCellValue(rowHandle, "Gerceklesen")?.ToString();
                        DateTime? gerceklesen = string.IsNullOrEmpty(gerceklesenStr) ? (DateTime?)null : DateTime.TryParse(gerceklesenStr, out DateTime parsedGerceklesen) ? parsedGerceklesen : (DateTime?)null;

                        // İlgili kaydı veritabanında bul
                        var detay = context.TblDetay.FirstOrDefault(d => d.TMSOrderID == tmsOrderID);

                        if (detay != null)
                        {
                            // Değer silinmişse NULL olarak kaydet
                            detay.YuklemeNoktasiVarısTarihi = yuklemeNoktasiVarisTarihi;
                            detay.YuklemeNoktasiCikisTarihi = yuklemeNoktasiCikisTarihi;
                            detay.TeslimNoktasiCikisTarihi = teslimNoktasiCikisTarihi;
                            detay.Gerceklesen = gerceklesen;
                        }
                    }
                }

                // Veritabanını güncelle
                context.SaveChanges();
                MessageBox.Show("Tüm değişiklikler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
