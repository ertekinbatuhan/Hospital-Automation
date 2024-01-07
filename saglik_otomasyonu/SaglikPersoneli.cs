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
    public partial class SaglikPersoneli : Form
    {
        public SaglikPersoneli()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaglikPersoneli_Load(object sender, EventArgs e)
        {

            table.Columns.Add("Çalışan Adı", typeof(string));
            table.Columns.Add("Soyadı", typeof(string));
            table.Columns.Add("Ünvanı", typeof(string));
            table.Columns.Add("Telefonu", typeof(string));

            table.Rows.Add("Şükrü","Özyıldız","Hemşire","534-232");
            table.Rows.Add("Hakan", "Fidan", "Acil Yardım", "531-324");
            table.Rows.Add("Büşra", "Çetin", "112-Acil", "544-123");



            dataGridView1.DataSource = table;
        }
    }
}
