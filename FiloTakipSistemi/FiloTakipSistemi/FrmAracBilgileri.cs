using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiloTakipSistemi.Entity2; // Entity sınıfının bulunduğu namespace

namespace FiloTakipSistemi
{
    public partial class FrmAracBilgileri : Form
    {
        private BindingSource bindingSourceAraclar = new BindingSource(); // BindingSource tanımı

        public FrmAracBilgileri()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde verileri listele
        private void FrmAracBilgileri_Load(object sender, EventArgs e)
        {
            Listele(); // Form açıldığında verileri listele
        }

        // Verileri listeleme metodu
        public void Listele()
        {
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
            {
                // TblAraclar_New tablosundan verileri al
                var araclarListesi = db.TblAraclar.ToList();

                // BindingSource'a veri ekle
                bindingSourceAraclar.DataSource = araclarListesi;

                // gridControlAracBilgileri'nin DataSource'unu BindingSource ile ayarla
                gridControlAracBilgileri.DataSource = bindingSourceAraclar;

                // Eğer veri bulunamazsa, kullanıcıyı bilgilendirin
                if (araclarListesi.Count == 0)
                {
                    MessageBox.Show("Veri bulunamadı."); // Veri yoksa bu mesaj çıkmalı
                }
            }
        }
    }
}
