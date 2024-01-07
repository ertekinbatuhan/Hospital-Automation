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
    public partial class HastaView : Form
    {

        public HastaView()
        {
            InitializeComponent();

            try
            {

                string[] veriler = System.IO.File.ReadAllLines("poliklinik_data.txt");


                comboBox2.Items.AddRange(veriler);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri okuma hatası: " + ex.Message);
            }

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.Items.Add("Genel Tarama");
            comboBox3.Items.Add("Aşı");
            comboBox3.Items.Add("Ehliyet Taraması");

            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox4.Items.Add("1068");
            comboBox4.Items.Add("3450");
            comboBox4.Items.Add("4232");

            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add("08.01.2024");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            DosyaArama dosyaAramaYardimiForm = new DosyaArama();

            // Oluşturulan formu gösterin
            dosyaAramaYardimiForm.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        DataTable table = new DataTable();
        private string dosyaYolu = "CikisBilgilerii.txt";

        private void HastaView_Load(object sender, EventArgs e)
        {

            table.Columns.Add("Poliklinik", typeof(string));
            table.Columns.Add("Sıra No", typeof(int));
            table.Columns.Add("Saat", typeof(string));
            table.Columns.Add("Yapılan İşlem", typeof(string));
            table.Columns.Add("Dr.Kodu", typeof(int));
            table.Columns.Add("Miktar", typeof(int));
            table.Columns.Add("Birim Fiyat", typeof(int));

            dataGridView1.DataSource = table;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            string currentHour = DateTime.Now.ToString("HH:mm:ss");

            table.Rows.Add(comboBox2.Text, textBox5.Text, currentHour, comboBox3.Text, comboBox4.Text, Convert.ToString(numericUpDown1.Value), textBox6.Text);
            dataGridView1.DataSource = table;

            label14.Text = Convert.ToString(numericUpDown1.Value * Convert.ToInt32(textBox6.Text)) + "TL";


        }

        private void button5_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    DataRow row = rowView.Row;
                    table.Rows.Remove(row);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    DataRow row = rowView.Row;
                    string poliklinik = row["Poliklinik"].ToString();
                    string siraNo = row["Sıra No"].ToString();
                    string yapilanIslem = row["Yapılan İşlem"].ToString();
                    string drKodu = row["Dr.Kodu"].ToString();
                    int miktar = Convert.ToInt32(row["Miktar"]);
                    int birimFiyat = Convert.ToInt32(row["Birim Fiyat"]);

                    DateTime cikisSaati = DateTime.Now;
                    KaydetDosyaya(cikisSaati, poliklinik, siraNo, yapilanIslem, drKodu, miktar, birimFiyat);

                    table.Rows.Remove(row);
                }
            }
        }


        private void KaydetDosyaya(DateTime cikisSaati, string poliklinik, string siraNo, string yapilanIslem, string drKodu, int miktar, int birimFiyat)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(dosyaYolu))
                {
                    sw.WriteLine($"Çıkış Saati: {cikisSaati}");
                    sw.WriteLine($"Poliklinik: {poliklinik}");
                    sw.WriteLine($"Sıra No: {siraNo}");
                    sw.WriteLine($"Yapılan İşlem: {yapilanIslem}");
                    sw.WriteLine($"Dr. Kodu: {drKodu}");
                    sw.WriteLine($"Miktar: {miktar}");
                    sw.WriteLine($"Birim Fiyat: {birimFiyat}");

                }

                MessageBox.Show("Çıkış bilgisi dosyaya kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya kaydetme hatası: " + ex.Message);
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (File.Exists(dosyaYolu))
            {
                string veri = File.ReadAllText(dosyaYolu);
                Console.WriteLine(veri);
                MessageBox.Show(veri);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PoliklinikTanitma poliklinikForm = new PoliklinikTanitma();


            poliklinikForm.Show();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HastaBilgileri hastaBilgileri = new HastaBilgileri();

            hastaBilgileri.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GecmisIslemler gecmisIslemlerForm = new GecmisIslemler();


            gecmisIslemlerForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DoktorTanitma doktorTanitma = new DoktorTanitma();
            doktorTanitma.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SaglikPersoneli saglikPersoneli = new SaglikPersoneli();
            saglikPersoneli.ShowDialog(); 
        }
    }

}