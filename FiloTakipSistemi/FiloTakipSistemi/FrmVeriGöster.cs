using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid; // GridView kullanmak için gerekli namespace

namespace FiloTakipSistemi
{
    public partial class FrmVeriGöster : Form
    {
        public FrmVeriGöster()
        {
            InitializeComponent();

        }

        public void SetGridData(DataTable dataTable)
        {
            // gridControlGoster'in GridView'ına veri kaydediyoruz
            gridControlGoster.DataSource = dataTable;

            // GridView'ı alıyoruz (Varsayılan olarak gridControl'un View kısmı GridView'dir)
            GridView gridView = gridControlGoster.MainView as GridView;

            if (gridView != null)
            {
                // Hücrelerin düzenlenmesini engelliyoruz
                gridView.OptionsBehavior.Editable = false;  // Tüm hücrelerde düzenlemeyi engeller
            }
        }


        private void BtnAktar_Click(object sender, EventArgs e)
        {
            // Kaynak DataTable'ı alıyoruz  
            DataTable kaynakDataTable = gridControlGoster.DataSource as DataTable;
            if (kaynakDataTable == null)
            {
                MessageBox.Show("Veri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hedef formu oluşturuyoruz  
            FrmVeriEklemeEkranı veriEklemeForm = new FrmVeriEklemeEkranı();

            // Veriyi aktarıyoruz  
            veriEklemeForm.AktarVeri(kaynakDataTable);

            // Form1'i MDI Parent olarak ayarlıyoruz  
            veriEklemeForm.MdiParent = this.MdiParent; // FrmVeriGöster'in MdiParent özelliğini kullanıyoruz

            // MDI Child olarak gösteriyoruz  
            veriEklemeForm.Show();

            // gridControlGoster üzerindeki verileri temizliyoruz  
            if (gridControlGoster.DataSource is DataTable dataTable)
            {
                dataTable.Clear(); // DataTable'ı temizliyoruz  
            }
        }



    }
}
