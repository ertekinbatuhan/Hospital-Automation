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
    public partial class PoliklinikTanitma : Form
    {
        public PoliklinikTanitma()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kaydedilenVeri = textBox1.Text;

            System.IO.File.AppendAllText("poliklinik_data.txt", kaydedilenVeri + Environment.NewLine);
        }
    }
}
