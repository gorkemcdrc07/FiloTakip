using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using FiloTakipSistemi.Entity7;
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
using static FiloTakipSistemi.FrmGiris;
using System.Drawing;












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

                // Excel dosyasını oku ve çıkarılan satır sayısını al
                int removedRowCount = 0;
                DataTable dataTable = LoadExcelData(filePath, out removedRowCount);

                // Çıkarılan satır sayısını göster
                MessageBox.Show(
                    $"{removedRowCount} satır çıkarıldı.",
                    "Bilgilendirme",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Verileri göster
                FrmVeriGöster veriGosterForm = new FrmVeriGöster();
                veriGosterForm.gridControlGoster.DataSource = dataTable;
                veriGosterForm.MdiParent = this; // Set Form1 as MDI parent
                veriGosterForm.Show();
            }
        }

        private DataTable LoadExcelData(string filePath, out int removedRowCount)
        {
            removedRowCount = 0; // Başlangıçta çıkarılan satır sayısı sıfır

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
                            // Çıkarılan satır sayısını artır
                            removedRowCount++;

                            // Satırı sil
                            dataTable.Rows.RemoveAt(i);
                        }
                    }

                    // Veriyi kaydediyoruz (silinen satırlar DataTable'dan kaldırıldı)
                    dataTable.AcceptChanges();

                    // 1. sütun (TMSOrderId) değerlerini alıyoruz
                    HashSet<string> tmsOrderIds = new HashSet<string>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        tmsOrderIds.Add(row[0].ToString()); // 1. sütun (TMSOrderId) değerini al
                    }

                    // TblDetay'daki TMSOrderID değerlerini al
                    var existingTmsOrderIds = GetExistingTmsOrderIds();

                    // Excel'deki satırları kontrol ediyoruz
                    for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
                    {
                        string tmsOrderId = dataTable.Rows[i][0].ToString(); // 1. sütundaki TMSOrderId değerini al

                        // Eğer TblDetay'da bu TMSOrderId varsa satırı kaldırıyoruz
                        if (existingTmsOrderIds.Contains(tmsOrderId))
                        {
                            removedRowCount++; // Satır çıkarıldı
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

        private HashSet<string> GetExistingTmsOrderIds()
        {
            // TblDetay'dan TMSOrderID değerlerini alacak bir metod. 
            // Bu metodun içeriği, veritabanı sorgusu ile TMSOrderID'leri çekmeli.

            HashSet<string> tmsOrderIds = new HashSet<string>();

            // Veritabanı bağlantısını kurarak TblDetay tablosundan TMSOrderID değerlerini çekeceğiz
            using (var context = new FiloTakipEntities9())
            {
                tmsOrderIds = new HashSet<string>(context.TblDetay.Select(d => d.TMSOrderID.ToString()));
            }

            return tmsOrderIds;
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
            // Kullanıcı rolünü mesaj kutusunda göster
            MessageBox.Show($"Kullanıcı Rolü: {FrmGiris.GlobalUser.KullaniciRol}",
                "Kullanıcı Rolü", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            // Formu MDI Child olarak göster
            plakaForm.Show();

            // Listele metodunu çağırarak formdaki GridControl'e veri yüklenmesini sağlar
            plakaForm.Listele();
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
            // Yeni bir form örneği oluşturuluyor
            FrmAracDurumBelirleme aracDurumlarıForm = new FrmAracDurumBelirleme();

            // Bu formu MDI parent olarak Form1'e ayarlıyoruz
            aracDurumlarıForm.MdiParent = this; // 'this', Form1'dir.

            // Formu gösteriyoruz
            aracDurumlarıForm.Show();
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

        private void BtnRezerve_ItemClick(object sender, ItemClickEventArgs e)
        {
            // FrmRezervePlakalar formunu oluştur
            FrmRezervePlakalar frmRezerve = new FrmRezervePlakalar();

            // Form1'i MDI Parent olarak ayarla
            frmRezerve.MdiParent = this;

            // Formu göster
            frmRezerve.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Kullanıcı rolünü kontrol et
            if (GlobalUser.KullaniciRol == "duzenleme")
            {
                // Eğer kullanıcı "Düzenleme" rolündeyse, RibbonPageGroup'leri gizle
                ribbonPageGroup1.Visible = false;
                ribbonPageGroup2.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
            }
            else
            {
                // Diğer roller için RibbonPageGroup'leri göster
                ribbonPageGroup1.Visible = true;
                ribbonPageGroup2.Visible = true;
            }

            // Kullanıcı adı kontrolü
            if (GlobalUser.KullaniciAdi == "Ferhat.Karisli" || GlobalUser.KullaniciRol == "yonetici")
            {
                // Sadece Ferhat.Karisli ve admin için butonları görünür yap
                ribbonPageGroup1.Visible = true;
            }
            else
            {
                // Diğer kullanıcılar için butonları gizle
                ribbonPageGroup1.Visible = false;
            }
        }


        private void BtnMobiliz_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMobiliz frm = new FrmMobiliz { MdiParent = this };
            frm.Show();
        }

    }
}






        
    
