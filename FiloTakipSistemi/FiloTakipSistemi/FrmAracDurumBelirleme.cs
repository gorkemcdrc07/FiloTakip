using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace FiloTakipSistemi
{
    public partial class FrmAracDurumBelirleme : Form
    {
        // TableAdapter'ı tanımlayın (doğru isimlendirme ile)
        private FiloTakipDataSet14TableAdapters.TblPlakaDurumlarıTableAdapter tblPlakaDurumlarıTableAdapter;

        public FrmAracDurumBelirleme()
        {
            InitializeComponent();
            // TableAdapter'ı başlatın
            tblPlakaDurumlarıTableAdapter = new FiloTakipDataSet14TableAdapters.TblPlakaDurumlarıTableAdapter(); // Düzgün isimlendirme
        }

        private void FrmAracDurumBelirleme_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'filoTakipDataSet20.TblPlakaDurumları' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblPlakaDurumlarıTableAdapter3.Fill(this.filoTakipDataSet20.TblPlakaDurumları);
            // TODO: Bu kod satırı 'filoTakipDataSet17.TblAracStatu' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tblAracStatuTableAdapter.Fill(this.filoTakipDataSet17.TblAracStatu);
            // Dataset'leri yükleyin
            this.tblPlakaDurumlarıTableAdapter.Fill(this.filoTakipDataSet14.TblPlakaDurumları);
            this.tblPlakaDurumlarıTableAdapter1.Fill(this.filoTakipDataSet13.TblPlakaDurumları);
            this.tblSebeplerTableAdapter.Fill(this.filoTakipDataSet12.TblSebepler);

            // GridView için olay dinleyicisi ekleyin
            GridView gridView = gridControl1.MainView as GridView;
            if (gridView != null)
            {
                gridView.CellValueChanged += gridView_CellValueChanged;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // DataRow'u alın
            GridView gridView = sender as GridView;
            if (gridView.GetDataRow(e.RowHandle) is DataRow row)
            {
                // "Sebep" sütununun değişip değişmediğini kontrol edin
                if (e.Column.FieldName == "Sebep")
                {
                    string selectedValue = e.Value?.ToString();
                    if (selectedValue == "İZİNLİ" || selectedValue == "BAKIM İZNİ" || selectedValue == "ARIZALI")
                    {
                        MessageBox.Show("Başlangıç ve Bitiş Tarihlerini doldurmanız gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // "BaslangıcTarihi" veya "BitisTarihi" sütunlarının değişip değişmediğini kontrol edin
                if (e.Column.FieldName == "BaslangıcTarihi" || e.Column.FieldName == "BitisTarihi")
                {
                   
                    if (row["BaslangıcTarihi"] != DBNull.Value && row["BitisTarihi"] != DBNull.Value)
                    {
                        
                        string durumValue = row["Sebep"]?.ToString();

                        
                        row["Durum"] = durumValue;

                        
                    }
                }
            }
        }


        private void BtnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Validate();
                this.tblPlakaDurumlarıBindingSource.EndEdit(); 

                var dataTable = (FiloTakipDataSet14.TblPlakaDurumlarıDataTable)this.filoTakipDataSet14.TblPlakaDurumları;
                 
                int result = this.tblPlakaDurumlarıTableAdapter.Update(dataTable);

                if (result > 0)
                {
                    MessageBox.Show("Veri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kaydetme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
