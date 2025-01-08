using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;

namespace FiloTakipSistemi
{
    public partial class FrmMobiliz : Form
    {
        private const string apiUrl = "https://ng.mobiliz.com.tr/su7/api/integrations/activity/last";
        private const string apiToken = "dcbf43bb4015717c6d77420be787f6275e48840622519f2a149ba564099d4538";

        public FrmMobiliz()
        {
            InitializeComponent();
        }

        private async void FrmMobiliz_Load(object sender, EventArgs e)
        {







            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.DarkGreen;
            gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DarkGreen;
            gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);

            // Veri satırlarının görünümünü ayarla
            gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black; // Yazı rengi siyah
            gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 13); // Yazı tipi Arial ve boyutu 13

            try
            {
                // API'den verileri al
                var data = await GetMobilizDataAsync();
                if (data != null && data.Count > 0)
                {
                    // LookUpEdit'e plaka listesini bağla
                    var plates = new List<object>();
                    foreach (var item in data)
                    {
                        plates.Add(new { PLAKALAR = item.plate });
                    }

                    lookUpEdit1.Properties.DataSource = plates;
                    lookUpEdit1.Properties.DisplayMember = "PLAKALAR";
                    lookUpEdit1.Properties.ValueMember = "PLAKALAR";
                    lookUpEdit1.Properties.PopulateColumns();

                    // LookUpEdit'teki liste öğelerinin yazı tipini değiştir
                    lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13, FontStyle.Bold); // Arial, 13, Kalın

                    // GridControl başlangıç verilerini göster
                    gridControl1.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Veri bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Durum sütununu özelleştirmek için CustomColumnDisplayText olayını bağla
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;
        }

        private async void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedPlate = lookUpEdit1.EditValue?.ToString();
                if (!string.IsNullOrEmpty(selectedPlate))
                {
                    // API'den seçilen plaka bilgilerini al
                    var data = await GetMobilizDataAsync();
                    var plateData = data.Find(d => d.plate == selectedPlate);

                    if (plateData != null)
                    {
                        // GridControl için veriyi hazırla
                        var gridData = new List<object>
                        {
                            new
                            {
                                Plate = plateData.plate,
                                QuarterWay = plateData.quarter + " / " + plateData.way,
                                CityTown = plateData.city + " / " + plateData.town,
                                Speed = plateData.speed,
                                CanbusFuelUsed = plateData.canbusFuelUsed,
                                CanbusFuelLevel = plateData.canbusFuelLevel,
                                State = plateData.state
                            }
                        };

                        gridControl1.DataSource = gridData;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Plaka verileri alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<MobilizData>> GetMobilizDataAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Mobiliz-Token", apiToken);
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<MobilizApiResponse>(jsonResponse);
                    return apiResponse?.result ?? new List<MobilizData>();
                }
                else
                {
                    throw new Exception($"API Hatası: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        // API yanıtı için sınıf tanımları
        public class MobilizApiResponse
        {
            public bool success { get; set; }
            public string type { get; set; }
            public string message { get; set; }
            public List<MobilizData> result { get; set; }
        }

        public class MobilizData
        {
            public string plate { get; set; }
            public string quarter { get; set; }
            public string way { get; set; }
            public string city { get; set; }
            public string town { get; set; }
            public double speed { get; set; }
            public double canbusFuelUsed { get; set; }
            public double canbusFuelLevel { get; set; }
            public string state { get; set; }


        }

        private async void BtnSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                // LookUpEdit'ten seçilen plaka bilgisi alınır
                var selectedPlate = lookUpEdit1.EditValue?.ToString();
                if (string.IsNullOrEmpty(selectedPlate))
                {
                    MessageBox.Show("Lütfen bir plaka seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // API'den tüm verileri al
                var data = await GetMobilizDataAsync();

                // Seçilen plakaya göre filtrele
                var plateData = data.Find(d => d.plate == selectedPlate);

                if (plateData != null)
                {
                    // GridControl için veri oluştur
                    var gridData = new List<object>
                    {
                        new
                        {
                            Plaka = plateData.plate,
                            BulunduguKonum = plateData.quarter + " / " + plateData.way,
                            IlIlce = plateData.city + " / " + plateData.town,
                            Hiz = plateData.speed,
                            KullanilanYakit = plateData.canbusFuelUsed,
                            YakitSeviyesi = plateData.canbusFuelLevel,
                            Durum = plateData.state
                        }
                    };

                    // GridControl'e veri bağla
                    gridControl1.DataSource = gridData;

                    // GridView başlıklarını ayarla
                    var gridView = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                    if (gridView != null)
                    {
                        gridView.Columns.Clear();

                        // Kolonlar ve başlıklar
                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "Plaka",
                            Caption = "PLAKA",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "BulunduguKonum",
                            Caption = "BULUNDUĞU KONUM",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "IlIlce",
                            Caption = "İL / İLÇE",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "Hiz",
                            Caption = "HIZ",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "KullanilanYakit",
                            Caption = "KULLANILAN YAKIT",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "YakitSeviyesi",
                            Caption = "YAKIT SEVİYESİ",
                            Visible = true
                        });

                        gridView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
                        {
                            FieldName = "Durum",
                            Caption = "DURUM",
                            Visible = true
                        });

                        // Görünümü yenile
                        gridView.BestFitColumns();
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen plaka için bilgi bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Plaka bilgileri alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Durum sütununu özelleştirmek için CustomColumnDisplayText olayını kullan
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Durum")
            {
                switch (e.Value.ToString())
                {
                    case "STATE_STOPPED":
                        e.DisplayText = "HAREKETSİZ, DURUYOR";
                        break;
                    case "STATE_UNDEFINED":
                        e.DisplayText = "BELİRSİZ, TANIMLANMADI";
                        break;
                    case "STATE_MOVING":
                        e.DisplayText = "HAREKETTE, YOLDA";
                        break;
                    default:
                        e.DisplayText = e.Value.ToString();
                        break;
                }
            }
        }
    }
}
