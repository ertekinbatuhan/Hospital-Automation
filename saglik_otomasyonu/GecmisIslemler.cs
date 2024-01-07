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
    public partial class GecmisIslemler : Form
    {
        public GecmisIslemler()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataTable table = new DataTable();
        private void GecmisIslemler_Load(object sender, EventArgs e)
        {

            table.Columns.Add("Dosya No", typeof(string));
            table.Columns.Add("Ad", typeof(string));
            table.Columns.Add("Soyad", typeof(string));
            table.Columns.Add("Sevk Tarihi", typeof(string));
            table.Columns.Add("Poliklinik", typeof(string));



            table.Rows.Add("00001", "Ahmet", "Derin", "08.01.2024", "Poliklinik 1");
            table.Rows.Add("0002", "Batuhan Berk", "Ertekin", "08.01.2024", "Poliklinik 1");



            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int rowIndex = dataGridView1.SelectedRows[0].Index;

                table.Rows.RemoveAt(rowIndex);


                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime baslangicTarihi = dateTimePicker1.Value;
            DateTime bitisTarihi = dateTimePicker2.Value;

            DataView dv = new DataView(table);
            dv.RowFilter = string.Format("Convert([Sevk Tarihi], System.DateTime) >= #{0}# AND Convert([Sevk Tarihi], System.DateTime) <= #{1}#", baslangicTarihi.ToString("MM/dd/yyyy"), bitisTarihi.ToString("MM/dd/yyyy"));
            dataGridView1.DataSource = dv.ToTable();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string dosyaNo = selectedRow.Cells["Dosya No"].Value.ToString();
                string ad = selectedRow.Cells["Ad"].Value.ToString();
                string soyad = selectedRow.Cells["Soyad"].Value.ToString();
                string sevkTarihi = selectedRow.Cells["Sevk Tarihi"].Value.ToString();
                string poliklinik = selectedRow.Cells["Poliklinik"].Value.ToString();

                string mesaj = $"Dosya No: {dosyaNo}\nAd: {ad}\nSoyad: {soyad}\nSevk Tarihi: {sevkTarihi}\nPoliklinik: {poliklinik}";
                MessageBox.Show(mesaj, "Seçilen Veriler");
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

    }
}
