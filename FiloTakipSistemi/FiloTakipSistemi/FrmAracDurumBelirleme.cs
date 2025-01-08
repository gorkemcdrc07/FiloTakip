using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using FiloTakipSistemi.Entity7;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmAracDurumBelirleme : Form
    {
        public FrmAracDurumBelirleme()
        {
            InitializeComponent();
        }

        private void FrmAracDurumBelirleme_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'filoTakipDataSet36.TblPlakaDurumları' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPlakaDurumlarıTableAdapter2.Fill(this.filoTakipDataSet36.TblPlakaDurumları);
            // TblSebepler ve diğer tablolara veri yükleme işlemleri
            this.tblSebeplerTableAdapter.Fill(this.filoTakipDataSet35.TblSebepler);
            this.tblPlakaDurumlarıTableAdapter1.Fill(this.filoTakipDataSet34.TblPlakaDurumları);
            this.tblPlakaDurumlarıTableAdapter.Fill(this.filoTakipDataSet33.TblPlakaDurumları);

            // Durum sütununa ComboBox ekle
            RepositoryItemComboBox comboBox = new RepositoryItemComboBox();
            comboBox.Items.Add("İZİNLİ");
            comboBox.Items.Add("BAKIM İZNİ");
            comboBox.Items.Add("ARIZALI");
            comboBox.Items.Add("KESİNTİ");

            // GridView'deki Durum sütununu ComboBox ile ilişkilendir
            gridControl1.RepositoryItems.Add(comboBox);
            gridView1.Columns["Sebep"].ColumnEdit = comboBox;

            // RepositoryItemDateEdit1 (Başlangıç Tarihi) için tarih ve saat seçimi
            RepositoryItemDateEdit repositoryItemDateEdit1 = new RepositoryItemDateEdit();
            repositoryItemDateEdit1.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            gridControl1.RepositoryItems.Add(repositoryItemDateEdit1);
            gridView1.Columns["BaslangıcTarihi"].ColumnEdit = repositoryItemDateEdit1;

            // RepositoryItemDateEdit2 (Bitiş Tarihi) için tarih ve saat seçimi
            RepositoryItemDateEdit repositoryItemDateEdit2 = new RepositoryItemDateEdit();
            repositoryItemDateEdit2.Mask.EditMask = "dd.MM.yyyy HH:mm"; // Tarih ve saat formatı
            repositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = true; // Maskeyi görüntü formatı olarak kullan
            gridControl1.RepositoryItems.Add(repositoryItemDateEdit2);
            gridView1.Columns["BitisTarihi"].ColumnEdit = repositoryItemDateEdit2;
        }



        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // MyDbContext sınıfından bir nesne oluştur
            using (var dbContext = new FiloTakipEntities9())
            {
                // GridView'den seçili satırları al
                var selectedRows = gridView1.GetSelectedRows();

                bool isOperationSuccessful = false; // İşlem başarılı mı kontrol etmek için

                // Seçili satırlar üzerinde döngü başlat
                foreach (int rowHandle in selectedRows)
                {
                    // Satırdaki Plaka ve Durum sütunlarından değerleri al
                    string plaka = gridView1.GetRowCellValue(rowHandle, "Plaka").ToString();
                    var mevcutDurum = gridView1.GetRowCellValue(rowHandle, "Sebep").ToString();  // ComboBox seçeneğini al

                    // Sebep, Başlangıç Tarihi, Bitiş Tarihi ve Açıklama değerlerini al
                    var secilenSebep = gridView1.GetRowCellValue(rowHandle, "Sebep").ToString();
                    var baslangicTarihi = gridView1.GetRowCellValue(rowHandle, "BaslangıcTarihi") as DateTime?;
                    var bitisTarihi = gridView1.GetRowCellValue(rowHandle, "BitisTarihi") as DateTime?;
                    var aciklama = gridView1.GetRowCellValue(rowHandle, "Aciklama").ToString();
                    var surucuAdi = gridView1.GetRowCellValue(rowHandle, "SurucuAdı").ToString();
                    var surucuTelefon = gridView1.GetRowCellValue(rowHandle, "SurucuTelefon").ToString();
                    var surucuTC = gridView1.GetRowCellValue(rowHandle, "SurucuTC").ToString();
                    var sonIl = gridView1.GetRowCellValue(rowHandle, "SonIl").ToString();
                    var sonIlce = gridView1.GetRowCellValue(rowHandle, "SonIlce").ToString();

                    // Eğer Plaka boşsa veya null ise, devam et
                    if (string.IsNullOrEmpty(plaka))
                        continue;

                    // Eğer Sebep boşsa, bu satırla ilgili işlem yapma
                    if (string.IsNullOrEmpty(secilenSebep))
                        continue;

                    // TblPlakaDurumları tablosundan, Plaka'ya karşılık gelen Durum değerini sorgula
                    var durum = dbContext.TblPlakaDurumları
                                         .Where(p => p.Plaka == plaka)
                                         .FirstOrDefault();

                    // Eğer Plaka'ya karşılık gelen bir Durum bulunduysa, bu Durum'u güncelle
                    if (durum != null)
                    {
                        // Durum, Sebep, Başlangıç Tarihi, Bitiş Tarihi ve Açıklama değerlerini veritabanındaki yeni değerlerle güncelle
                        durum.Durum = mevcutDurum;
                        durum.Sebep = secilenSebep;
                        durum.BaslangıcTarihi = baslangicTarihi;
                        durum.BitisTarihi = bitisTarihi;
                        durum.Aciklama = aciklama;

                        // Veritabanına değişiklikleri kaydet
                        dbContext.SaveChanges();

                        // GridControl'deki Durum sütununu da güncelle
                        gridView1.SetRowCellValue(rowHandle, "Sebep", secilenSebep);
                        gridView1.SetRowCellValue(rowHandle, "BaslangıcTarihi", baslangicTarihi);
                        gridView1.SetRowCellValue(rowHandle, "BitisTarihi", bitisTarihi);
                        gridView1.SetRowCellValue(rowHandle, "Aciklama", aciklama);

                        // İşlem başarılı oldu
                        isOperationSuccessful = true;
                    }
                    else
                    {
                        // Eğer Plaka bulunamazsa, uygun bir mesaj yazabilir ya da varsayılan bir değer atayabilirsiniz
                        MessageBox.Show($"Plaka {plaka} için Durum bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Sebep sütunu dolu olan satırları TblSebeplerListesi tablosuna kaydet
                    var yeniSebep = new TblSebeplerListesi
                    {
                        Plaka = plaka,
                        SurucuAdı = surucuAdi,
                        SurucuTelefon = surucuTelefon,
                        SurucuTC = surucuTC,
                        SonIl = sonIl,
                        SonIlce = sonIlce,
                        Sebep = secilenSebep,
                        BaslangıcTarihi = baslangicTarihi,
                        BitisTarihi = bitisTarihi,
                        Aciklama = aciklama
                    };

                    // Eğer Sebep doluysa, kaydet
                    dbContext.TblSebeplerListesi.Add(yeniSebep);
                    dbContext.SaveChanges();
                }

                // İşlem başarılıysa kullanıcıya mesaj göster
                if (isOperationSuccessful)
                {
                    MessageBox.Show("İşlemler başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void BtnYenile_Click(object sender, EventArgs e)
        {
            // Güncel tarihi ve saati alıyoruz
            DateTime currentDateTime = DateTime.Now;

            using (var context = new FiloTakipEntities9()) // DbContext'inizi burada kullanın
            {
                // TblPlakaDurumları tablosundaki tüm verileri alıyoruz
                var records = context.TblPlakaDurumları.ToList();

                bool isDataUpdated = false; // Veri güncellenip güncellenmediğini kontrol etmek için

                foreach (var record in records)
                {
                    // BitisTarihi sütununu kontrol ediyoruz
                    if (record.BitisTarihi != null)
                    {
                        DateTime bitisTarihi = record.BitisTarihi.Value;

                        // Eğer BitisTarihi, günümüz tarihi ve saatiyle eşitse işlemi yap
                        if (bitisTarihi.Date == currentDateTime.Date && bitisTarihi.Hour == currentDateTime.Hour && bitisTarihi.Minute == currentDateTime.Minute)
                        {
                            // Verileri temizliyoruz
                            record.BaslangıcTarihi = null;
                            record.BitisTarihi = null;
                            record.Aciklama = null;
                            record.Sebep = null;

                            // Durum sütununu "BOŞTA" yapıyoruz
                            record.Durum = "BOŞTA";

                            // Veri güncellenmiş olduğundan, flag'i true yapıyoruz
                            isDataUpdated = true;
                        }
                    }
                }

                // Eğer veriler güncellenmişse, değişiklikleri kaydediyoruz
                if (isDataUpdated)
                {
                    context.SaveChanges();

                    // Kullanıcıya işlem başarılı mesajı veriyoruz
                    MessageBox.Show("Veriler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sayfayı yeniliyoruz (örneğin, GridControl'u yeniden yükleyebilirsiniz)
                    RefreshGridControl();
                }
                else
                {
                    // Eğer hiçbir veri güncellenmemişse, kullanıcıya mesaj veriyoruz
                    MessageBox.Show("Güncellenmesi gereken veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Sayfayı yenilemek için kullanılan metod
        private void RefreshGridControl()
        {
            // gridControl'ün veri kaynağını yenilemek
            gridControl1.RefreshDataSource();
        }

    }
}


          

