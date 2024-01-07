using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saglik_otomasyonu
{
    public partial class DoktorTanitma : Form
    {
        public DoktorTanitma()
        {
            InitializeComponent();
        }


        DataTable table = new DataTable();
        private void DoktorTanitma_Load(object sender, EventArgs e)
        {

            table.Columns.Add("Dr Kodu", typeof(string));
            table.Columns.Add("Doktor Adı", typeof(string));
            table.Columns.Add("Doktor Soyadı", typeof(string));
            table.Columns.Add("Cep Telefonu", typeof(string));

            dataGridView1.DataSource = table;

            table.Rows.Add("1068", "Dr. Batuhan", "Ertekin", "552-4334");
            table.Rows.Add("3450", "Dr. Berk", "Çetin", "532-1324");
            table.Rows.Add("4232", "Dr. Mehmet", "Yılmaz", "531-1234");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Kullanıcının girdiği Doktor Kodu'nu al
            string doktorKodu = textBox1.Text;  // textBoxDoktorKodu, kullanıcının doktor kodunu girdiği TextBox kontrolü

            // DataView oluştur ve tabloyu filtrele
            DataView dv = new DataView(table);
            dv.RowFilter = $"[Dr Kodu] = '{doktorKodu}'";

            // Filtrelenmiş DataView'i DataGridView'e ata
            dataGridView1.DataSource = dv.ToTable();

        }
    }
}
