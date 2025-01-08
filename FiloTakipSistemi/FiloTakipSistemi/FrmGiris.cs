using DevExpress.XtraEditors;
using FiloTakipSistemi.Entity7;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // KeyDown olayını subscribe et
            txtKullaniciAdi.KeyDown += Txt_KeyDown;
            txtSifre.KeyDown += Txt_KeyDown;
        }

        public string kullanicirolu; // Rol bilgisini saklayacak değişken

        // Kullanıcı nesnesi
        private TblGiris kullanici;

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (ValidateUser(txtKullaniciAdi.Text, txtSifre.Text))
            {
                // Kullanıcı rolünü global değişkende sakla
                GlobalUser.KullaniciRol = kullanici.Rol;

                XtraMessageBox.Show($"Giriş başarılı! Kullanıcı Rolü: {GlobalUser.KullaniciRol}",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Form1'i aç
                Form1 form1 = new Form1();
                form1.Show(); // Formu göster
                this.Hide(); // Giriş formunu gizle
            }
            else
            {
                XtraMessageBox.Show("Kullanıcı adı veya şifre yanlış.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class GlobalUser
        {
            public static string KullaniciAdi { get; set; }
            public static string KullaniciRol { get; set; }
        }






        private bool ValidateUser(string username, string password)
        {
            using (FiloTakipEntities9 db = new FiloTakipEntities9())
            {
                // Kullanıcı adı ve şifre hash ile sorgu yapılması önerilir.
                var user = db.TblGiris.FirstOrDefault(u => u.KullaniciAdi == username && u.Sifre == password);
                if (user != null)
                {
                    // Kullanıcı bulunduysa rolü döndür
                    kullanici = user; // Kullanıcıyı sakla, rolünü almak için
                    return true; // Kullanıcı bulunduysa true döner
                }
                return false; // Kullanıcı bulunmazsa false döner
            }
        }

        // Enter tuşuna basıldığında buton tıklama işlevini tetikle
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldığında
            {
                BtnGiris_Click(sender, e); // Buton tıklama metodunu doğrudan çağır
                e.SuppressKeyPress = true; // Anahtarın daha fazla işlenmesini engelle
            }
        }
    }
}
