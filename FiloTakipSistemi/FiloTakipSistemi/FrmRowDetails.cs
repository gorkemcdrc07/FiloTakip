using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace FiloTakipSistemi
{
    public partial class FrmRowDetails : Form
    {
        // SelectedDataRow özelliği, tıklanan satırın verisini tutar
        public DataRow SelectedDataRow { get; set; }
        public DataTable SortedData { get; set; }
        public DataTable AllData { get; set; }

        // gridControl1, FrmRowDetails formunun içinde tanımlı bir GridControl olmalıdır
        public GridControl GridControl1 { get; set; }

        public FrmRowDetails(DataTable sortedData, DataTable allData)
        {
            InitializeComponent();

            SortedData = sortedData;
            AllData = allData;
        }

        private void FrmRowDetails_Load(object sender, EventArgs e)
        {
            // Seçilen satırı GridControl1'e göstermek için:
            if (GridControl1 != null && SelectedDataRow != null)
            {
                // Satırı `gridControl1`'de gösterecek şekilde işlemler yapılabilir.
                // Örneğin, GridControl1'de sadece tıklanan satırı gösterme
                GridView gridView = GridControl1.MainView as GridView;
                if (gridView != null)
                {
                    gridView.FocusedRowHandle = SortedData.Rows.IndexOf(SelectedDataRow);
                }
            }
        }
    }
}
