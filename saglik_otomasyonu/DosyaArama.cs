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
    public partial class DosyaArama : Form
    {
        public DosyaArama()
        {
            InitializeComponent();


            comboBox1.Items.Add("Hasta Adı Soyadı");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DosyaArama_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
