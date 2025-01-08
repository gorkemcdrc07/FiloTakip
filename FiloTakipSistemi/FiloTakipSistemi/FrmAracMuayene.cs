using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using FiloTakipSistemi.Entity7;

namespace FiloTakipSistemi
{
    public partial class FrmAracMuayene : Form
    {
        private BindingSource bindingSourceAracMuayene = new BindingSource();
        private NotifyIcon notifyIcon; // Bildirim için NotifyIcon tanımlayın

        public FrmAracMuayene()
        {
            InitializeComponent();
            InitializeNotifyIcon(); // NotifyIcon'u initialize edin
        }

        private void FrmAracMuayene_Load(object sender, EventArgs e)
        {
            Listele(); // Form yüklendiğinde listele
            gridViewAracMuayene.RowStyle += gridViewAracMuayene_RowStyle; // Satır stilini ayarla
        }

        // NotifyIcon'un ayarlarını yap
        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information; // Bildiri ikonu
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "Yaklaşan Tarihler"; // Bildiri başlığı
        }

        public void Listele()
        {
            using (FiloTakipEntities9 db = new FiloTakipEntities9())
            {
                // TblAraclar_New tablosundan veriyi al ve Status sütununda sadece AKTİF olanları seç
                var aracMuayeneListesi = db.TblAraclar
                    .Where(a => a.Status == "AKTİF") // Status kısmında sadece AKTİF olanları filtrele
                    .Select(a => new
                    {
                        a.ID,
                        a.CekiciDorse,
                        a.CekiciMuayene,
                        a.DorseMuayene,
                        a.TrafikSigorta,
                        a.AracYil,
                        a.DorseYil
                    })
                    .ToList();

                // BindingSource'a veri ekle
                bindingSourceAracMuayene.DataSource = aracMuayeneListesi;

                // gridControlAracMuayene'nin DataSource'unu BindingSource ile ayarla
                gridControlAracMuayene.DataSource = bindingSourceAracMuayene;

                // Eğer veri bulunamazsa, kullanıcıyı bilgilendirin
                if (aracMuayeneListesi.Count == 0)
                {
                    MessageBox.Show("Aktif araç muayene verisi bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CheckApproachingDates(aracMuayeneListesi); // Yaklaşan tarihleri kontrol et
                }
            }
        }

        // Yaklaşan tarihler için kullanıcıya bildirim göster ve satırları renklendir
        private void CheckApproachingDates(IEnumerable<dynamic> aracMuayeneListesi)
        {
            DateTime today = DateTime.Today;
            DateTime approachingDate = today.AddDays(7); // 7 gün içinde yaklaşılan tarihler için kontrol

            foreach (var arac in aracMuayeneListesi)
            {
                // Eğer tarihler yaklaşmışsa veya geçmişse bildirim ver ve boyama işlemini tetikle
                if ((arac.CekiciMuayene != null && arac.CekiciMuayene <= approachingDate && arac.CekiciMuayene >= today) ||
                    (arac.DorseMuayene != null && arac.DorseMuayene <= approachingDate && arac.DorseMuayene >= today) ||
                    (arac.TrafikSigorta != null && arac.TrafikSigorta <= approachingDate && arac.TrafikSigorta >= today))
                {
                    // Bildiri mesajı göster
                    notifyIcon.BalloonTipText = $"Araç ID: {arac.ID} - Yaklaşan Muayene/Sigorta Tarihi!";
                    notifyIcon.ShowBalloonTip(3000); // 3 saniye boyunca balon bildirimi göster
                }
                else if ((arac.CekiciMuayene != null && arac.CekiciMuayene < today) ||
                         (arac.DorseMuayene != null && arac.DorseMuayene < today) ||
                         (arac.TrafikSigorta != null && arac.TrafikSigorta < today))
                {
                    // Eğer tarih geçmişse kırmızı renkte bildirim göster
                    notifyIcon.BalloonTipText = $"Araç ID: {arac.ID} - Tarihi Geçmiş Muayene/Sigorta!";
                    notifyIcon.ShowBalloonTip(3000); // 3 saniye boyunca balon bildirimi göster
                }
            }

            gridViewAracMuayene.RefreshData(); // Satırların boyanması için tabloyu yenile
        }

        // RowStyle olayı - Tarihi geçmiş satırları kırmızıya, yaklaşanları sarıya boyamak için
        private void gridViewAracMuayene_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            DateTime today = DateTime.Today;
            DateTime approachingDate = today.AddDays(7); // 7 gün içinde yaklaşanlar için

            // Geçerli satırdaki veriyi alın
            var cekiciMuayeneDate = view.GetRowCellValue(e.RowHandle, "CekiciMuayene") as DateTime?;
            var dorseMuayeneDate = view.GetRowCellValue(e.RowHandle, "DorseMuayene") as DateTime?;
            var trafikSigortaDate = view.GetRowCellValue(e.RowHandle, "TrafikSigorta") as DateTime?;

            // Eğer tarih bugünden geçmişse, o satırı kırmızıya boyayın
            if ((cekiciMuayeneDate != null && cekiciMuayeneDate < today) ||
                (dorseMuayeneDate != null && dorseMuayeneDate < today) ||
                (trafikSigortaDate != null && trafikSigortaDate < today))
            {
                e.Appearance.BackColor = System.Drawing.Color.Red;
                e.Appearance.BackColor2 = System.Drawing.Color.LightCoral;
            }
            // Eğer tarih bugüne yaklaşıyorsa (7 gün içinde), sarıya boyayın
            else if ((cekiciMuayeneDate != null && cekiciMuayeneDate >= today && cekiciMuayeneDate <= approachingDate) ||
                     (dorseMuayeneDate != null && dorseMuayeneDate >= today && dorseMuayeneDate <= approachingDate) ||
                     (trafikSigortaDate != null && trafikSigortaDate >= today && trafikSigortaDate <= approachingDate))
            {
                e.Appearance.BackColor = System.Drawing.Color.Yellow;
                e.Appearance.BackColor2 = System.Drawing.Color.LightYellow;
            }
        }
    }
}
