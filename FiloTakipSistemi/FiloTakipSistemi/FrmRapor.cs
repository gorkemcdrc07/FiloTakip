using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using FiloTakipSistemi.Entity7;

namespace FiloTakipSistemi
{
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            using (var db = new FiloTakipEntities9())
            {
                // Gecikme yapanları sorgula (GridControl1)
                var gecikenData = db.TblTamamlananSeferler
                    .Where(x => x.TahminiVaris < DateTime.Now && x.Gerceklesen != null)
                    .Select(x => new
                    {
                        x.Plaka,
                        TahminiVaris = x.TahminiVaris,  // DateTime? türünde veritabanından al
                        Gerceklesen = x.Gerceklesen,    // DateTime? türünde veritabanından al
                        GecikmeSaat = DbFunctions.DiffHours(x.TahminiVaris, x.Gerceklesen), // Gecikme saat olarak hesapla
                        GecikmeDakika = DbFunctions.DiffMinutes(x.TahminiVaris, x.Gerceklesen) % 60 // Gecikme dakika olarak hesapla
                    })
                    .Where(x => x.GecikmeSaat > 0 || x.GecikmeDakika > 0)  // Sadece gecikme süresi olanları seç
                    .ToList();

                // Erken varış yapanları sorgula (GridControl2)
                var erkenVaranData = db.TblTamamlananSeferler
                    .Where(x => x.TahminiVaris < DateTime.Now && x.Gerceklesen != null)
                    .Select(x => new
                    {
                        x.Plaka,
                        TahminiVaris = x.TahminiVaris,  // DateTime? türünde veritabanından al
                        Gerceklesen = x.Gerceklesen,    // DateTime? türünde veritabanından al
                        ErkenVarisSaat = DbFunctions.DiffHours(x.Gerceklesen, x.TahminiVaris), // Erken varış saat olarak hesapla
                        ErkenVarisDakika = DbFunctions.DiffMinutes(x.Gerceklesen, x.TahminiVaris) % 60 // Erken varış dakika olarak hesapla
                    })
                    .Where(x => x.ErkenVarisSaat > 0 || x.ErkenVarisDakika > 0)  // Sadece erken varış yapanları seç
                    .ToList();

                // Gecikme verisini formatla (GridControl1)
                var formattedGecikenData = gecikenData.Select(x => new
                {
                    x.Plaka,
                    TahminiVaris = x.TahminiVaris.HasValue ? x.TahminiVaris.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty,
                    Gerceklesen = x.Gerceklesen.HasValue ? x.Gerceklesen.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty,
                    Gecikme = $"{x.GecikmeSaat} saat {x.GecikmeDakika} dakika"
                }).ToList();

                // Erken varış verisini formatla (GridControl2)
                var formattedErkenVaranData = erkenVaranData.Select(x => new
                {
                    x.Plaka,
                    TahminiVaris = x.TahminiVaris.HasValue ? x.TahminiVaris.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty,
                    Gerceklesen = x.Gerceklesen.HasValue ? x.Gerceklesen.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty,
                    ErkenVaris = $"-{x.ErkenVarisSaat} saat {x.ErkenVarisDakika} dakika" // Erken varış için negatif işareti ekle
                }).ToList();

                // Geciken verileri gridControl1'e bağla
                gridControl1.DataSource = formattedGecikenData;

                // Erken varış yapan verileri gridControl2'ye bağla
                gridControl2.DataSource = formattedErkenVaranData;

                // Verilerin doğru şekilde güncellendiğinden emin olun
                gridControl1.RefreshDataSource();
                gridControl2.RefreshDataSource();
            }
        }
    }
}
