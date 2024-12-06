using DevExpress.XtraEditors;
using FiloTakipSistemi.Entity2;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FiloTakipSistemi
{
    public partial class FrmGiris : Form
    {
        private Timer timer, kayıtTimer; // İki ayrı Timer değişkeni
        private int step = 10; // Hareket adımı

        public FrmGiris()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Timer ayarları
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;

            kayıtTimer = new Timer();
            kayıtTimer.Interval = 50;
            kayıtTimer.Tick += KayıtTimer_Tick;

            // KeyDown olayını subscribe et
            txtKullaniciAdi.KeyDown += Txt_KeyDown;
            txtSifre.KeyDown += Txt_KeyDown;
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifre kontrolü
            if (ValidateUser(txtKullaniciAdi.Text, txtSifre.Text))
            {
                timer.Start(); // Kullanıcı doğrulandıysa timer'ı başlat
            }
            else
            {
                XtraMessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
            {
                // Kullanıcı adı ve şifre hash ile sorgu yapılması önerilir.
                var user = db.TblGiris.FirstOrDefault(u => u.KullaniciAdi == username && u.Sifre == password);
                return user != null; // Kullanıcı bulunduysa true döner
            }
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            string username = textEdit1.Text; // Kullanıcı adını al
            string password = textEdit2.Text; // Şifreyi al

            // Kullanıcı adı ve şifreyi veritabanına ekle
            using (FiloTakipEntities7 db = new FiloTakipEntities7())
            {
                // Yeni kullanıcı oluştur
                TblGiris newUser = new TblGiris
                {
                    KullaniciAdi = username,
                    Sifre = password
                };

                // Yeni kullanıcıyı ekle
                db.TblGiris.Add(newUser);

                try
                {
                    db.SaveChanges(); // Değişiklikleri kaydet
                    XtraMessageBox.Show("Kayıt başarılı! Filo Sistemine hoş geldiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    XtraMessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // pictureEdit1, BtnGiris, panel1 ve panel2'nin konumlarını sola kaydır
            pictureEdit1.Left -= step;
            BtnGiris.Left -= step;
            panel1.Left -= step;
            panel2.Left -= step;

            if (panel1.Right < 0 && panel2.Right < 0)
            {
                timer.Stop();

                Form1 form1 = new Form1();
                form1.Show();

                this.Hide();
            }
        }

        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            kayıtTimer.Start();
        }

        private void KayıtTimer_Tick(object sender, EventArgs e)
        {
            panel1.Left -= step;
            BtnGiris.Left -= step;
            pictureEdit1.Left -= step;
            panel2.Left -= step;

            if (pictureEdit1.Left <= 0)
            {
                kayıtTimer.Stop();
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
