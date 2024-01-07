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
    public partial class HastaBilgileri : Form
    {
        public HastaBilgileri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            dataGridView1.DataSource = table;
        }

        DataTable table = new DataTable();

        private void HastaBilgileri_Load(object sender, EventArgs e)

        {

            table.Columns.Add("Hasta Adı", typeof(string));
            table.Columns.Add("Hasta Soyadı", typeof(string));
            table.Columns.Add("Hasta Kimlik No", typeof(string));
            table.Columns.Add("Cep Telefonu", typeof(string));
            table.Rows.Add("Batuhan", "Ertekin", "14879539940", "05317452123");

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)

        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            DataGridViewRow dataGridViewRow = dataGridView1.Rows[rowIndex];
            dataGridViewRow.Cells[0].Value = textBox1.Text;
            dataGridViewRow.Cells[1].Value = textBox2.Text;
            dataGridViewRow.Cells[2].Value = textBox3.Text;
            dataGridViewRow.Cells[3].Value = textBox4.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }
    }
}

