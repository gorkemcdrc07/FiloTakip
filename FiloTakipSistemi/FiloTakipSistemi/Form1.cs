using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using FiloTakipSistemi.Entity2;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Export.Xl;
using DevExpress.SpreadsheetSource;
using DevExpress.XtraExport.Implementation;
using ExcelInterop = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using ClosedXML.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraBars;
using ExcelDataReader;
using System.Text;












namespace FiloTakipSistemi
{
    public partial class Form1 : Form
    {
        private FrmAracDurumBelirleme aracDurumBelirlemeForm; // Değişkeni tanımla
        public Form1()
        {
            
            InitializeComponent();
            IsMdiContainer = true; // Form1'i MDI container olarak ayarlıyoruz
            // ProgressBar ve Label'ı başlangıçta gizle
            progressBar1.Visible = false;
            labelStatus.Visible = false;

            


            // Kontrolleri merkezde konumlandır
            CenterControls();
        }


        // FormClosing olayını dinleyen metot
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            System.Windows.Forms.Application.Exit(); // Uygulamanın kapanmasını sağlar
        }


        public void BtnVeriEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Dosya gezgini aç
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Dosyaları (*.xls;*.xlsx)|*.xls;*.xlsx";
            openFileDialog.Title = "Bir Excel Dosyası Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın yolu
                string filePath = openFileDialog.FileName;

                // Excel dosyasını oku ve gridControlGoster'a ata
                DataTable dataTable = LoadExcelData(filePath);

                // VeriGoster formunu MDI child olarak aç
                FrmVeriGöster veriGosterForm = new FrmVeriGöster();
                veriGosterForm.gridControlGoster.DataSource = dataTable;
                veriGosterForm.MdiParent = this;  // Set Form1 as MDI parent
                veriGosterForm.Show();

            }
        }

        private DataTable LoadExcelData(string filePath)
        {
            // Excel dosyasını okuyabilmek için gerekli kütüphaneyi kullanıyoruz
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Excel verilerini DataSet olarak okuyoruz
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        // İlk satır başlık olarak alınacak
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            // Başlıkları oku
                            UseHeaderRow = true
                        }
                    });

                    // İlk sayfayı alıyoruz
                    DataTable dataTable = result.Tables[0];

                    // 14. sütuna bakıp "Filo Araç Planlamada" dışında bir şey varsa o satırı kaldırıyoruz
                    for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                    {
                        string column14Value = dataTable.Rows[i][13].ToString(); // 14. sütun (index 13) değerini al

                        if (column14Value != "Filo Araç Planlamada")
                        {
                            // Uyarı ver
                            MessageBox.Show($"Satır atlandı. Sipariş Durumu sütunda geçerli değer bulunmadı: {column14Value}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Satırı sil
                            dataTable.Rows.RemoveAt(i);
                        }
                    }

                    // Veriyi kaydediyoruz (silinen satırlar DataTable'dan kaldırıldı)
                    dataTable.AcceptChanges();

                    // 23. sütuna göre gruplayacağız (index 22)
                    var groupedRows = dataTable.AsEnumerable()
                        .GroupBy(row => row[22].ToString()) // Grup yapmak için 23. sütunu kullan
                        .OrderBy(group => group.Key) // Grupları sıralama
                        .ToList();

                    DataTable sortedDataTable = dataTable.Clone(); // Yeni DataTable oluştur (yeni sıralama için)

                    // Grupları yeni DataTable'a ekliyoruz
                    foreach (var group in groupedRows)
                    {
                        foreach (var row in group)
                        {
                            sortedDataTable.ImportRow(row);
                        }
                    }

                    return sortedDataTable;
                }
            }
        }














        private string GetCellValue(Range cell)
        {
            return cell.Value2 != null ? cell.Value2.ToString() : string.Empty;
        }

        private DateTime? ParseDateTime(string dateValue)
        {
            if (!string.IsNullOrEmpty(dateValue))
            {
                if (DateTime.TryParse(dateValue, out DateTime result))
                {
                    return result;
                }

                if (double.TryParse(dateValue, out double excelDate))
                {
                    return DateTime.FromOADate(excelDate);
                }
            }
            return null; // veya varsayılan bir tarih dönebilirsiniz.
        }

        private int GetColumnIndex(string columnName, Range usedRange)
        {
            for (int col = 1; col <= usedRange.Columns.Count; col++)
            {
                if (usedRange.Cells[1, col].Value2 != null &&
                    usedRange.Cells[1, col].Value2.ToString() == columnName)
                {
                    return col; // Başlık bulundu, sütun numarasını döndür
                }
            }
            return -1; // Başlık bulunamazsa -1 döndür
        }

        private void CenterControls()
        {
            // Ekranın ortasında konumlandır
            labelStatus.Location = new System.Drawing.Point((this.ClientSize.Width - labelStatus.Width) / 2,
                                                            (this.ClientSize.Height - labelStatus.Height - progressBar1.Height) / 2);

            // ProgressBar'ı labelStatus'un hemen altına yerleştir
            progressBar1.Location = new System.Drawing.Point((this.ClientSize.Width - progressBar1.Width) / 2,
                                                             labelStatus.Bottom + 10); // 10 piksel boşluk
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterControls(); // Form boyutu değiştiğinde kontrolleri yeniden merkezle
        }

        private void BtnPlanlamaEkrani_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Açık MDI Child formlarını kontrol et
            foreach (Form childForm in this.MdiChildren)
            {
                // Eğer FrmPlanlamaEkranı formu açıksa
                if (childForm is FrmPlanlamaEkranı)
                {
                    // Formu aktif hale getir ve işlemi bitir
                    childForm.Activate();
                    return;
                }
            }

            // Eğer form açık değilse yeni bir FrmPlanlamaEkranı formu oluştur ve aç
            FrmPlanlamaEkranı planlamaEkranı = new FrmPlanlamaEkranı
            {
                MdiParent = this // Form1 burada MDI Parent olarak atanıyor
            };

            // Formu göster
            planlamaEkranı.Show();

            // Listele metodunu çağır
            planlamaEkranı.Listele();
        }




        private void BtnMuayeneTarih_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // FrmAracMuayene formunu oluştur
            FrmAracMuayene aracMuayene = new FrmAracMuayene
            {
                MdiParent = this // MDI Parent olarak Form1'i ayarla
            };

            // Formu göster
            aracMuayene.Show();
            aracMuayene.Listele(); // Listele metodunu çağır
        }

        private void BtnAracBilgileri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // FrmAracBilgileri formunu oluştur
            FrmAracBilgileri aracBilgileri = new FrmAracBilgileri
            {
                MdiParent = this // MDI Parent olarak Form1'i ayarla
            };

            // Formu göster
            aracBilgileri.Show();
        }

        private void BtnAtananPlakalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Açık MDI Child formlarını kontrol et
            foreach (Form childForm in this.MdiChildren)
            {
                // Eğer FrmPlakaAtandi formu açıksa
                if (childForm is FrmPlakaAtandi)
                {
                    // Formu aktif hale getir ve işlemi bitir
                    childForm.Activate();
                    return;
                }
            }

            // Eğer form açık değilse yeni bir FrmPlakaAtandi formu oluştur ve aç
            FrmPlakaAtandi plakaForm = new FrmPlakaAtandi
            {
                MdiParent = this // Form1 burada MDI Parent olarak atanıyor
            };

            // Listele metodunu çağırarak formdaki GridControl'e veri yüklenmesini sağlar
            plakaForm.Listele();

            // Formu MDI Child olarak göster
            plakaForm.Show();
        }




        private void BtnPlakaDurumları_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Yeni bir FrmAracDurumları formu oluştur
            FrmAracDurumları frmAracDurumları = new FrmAracDurumları
            {
                MdiParent = this  // Form1'i MDI parent olarak ayarla
            };

            // Formu göster
            frmAracDurumları.Show();
        }

        private void BtnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // FrmRapor formunu oluştur
            FrmRapor raporForm = new FrmRapor();

            // MDI parent'ı ayarla
            raporForm.MdiParent = this; // Bu kod, mevcut formu MDI parent olarak ayarlıyor.

            // Formu aç
            raporForm.Show();
        }

        private void BtnAracDurumlarıDuzenle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // FrmAracDurumBelirleme formunu aç ve tam ekran yap
            FrmAracDurumBelirleme form = new FrmAracDurumBelirleme();
            form.WindowState = FormWindowState.Maximized; // Formu tam ekran yap
            form.Show(); // Modal olarak aç
        }

        private void BtnSiparisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Açık MDI Child formlarını kontrol et
            foreach (Form childForm in this.MdiChildren)
            {
                // Eğer FrmVeriEklemeEkranı formu açıksa
                if (childForm is FrmVeriEklemeEkranı)
                {
                    // Formu aktif hale getir ve işlemi bitir
                    childForm.Activate();

                    // BtnPlanlamayaAt butonunun görünür olmasını sağla
                    FrmVeriEklemeEkranı frmVeriEklemeEkranı = (FrmVeriEklemeEkranı)childForm;
                    return;
                }
            }

            // Eğer form açık değilse yeni bir FrmVeriEklemeEkranı formu oluştur ve aç
            FrmVeriEklemeEkranı frmVeriEklemeEkranıNew = new FrmVeriEklemeEkranı
            {
                MdiParent = this // Form1 burada MDI Parent olarak atanıyor
            };

            // Formu göster
            frmVeriEklemeEkranıNew.Show();

        }
    }
}
