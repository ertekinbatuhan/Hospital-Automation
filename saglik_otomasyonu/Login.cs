namespace saglik_otomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            bool loginSuccess = CheckCredentials(username, password);

            if (loginSuccess)
            {
                MessageBox.Show("Giri� ba�ar�yla ger�ekle�ti.");

                // Do�ru giri� yap�ld���nda MainForm formunu g�ster
                HastaView hastaView = new HastaView();
                hastaView.Show();

                // E�er LoginForm'� kapatmak istiyorsan�z:
                this.Hide(); // veya this.Close();
            }
            else
            {
                MessageBox.Show("Giri� ba�ar�s�z. Kullan�c� ad� veya �ifre hatal�.", "Uyar�");
            }
        }


        private bool CheckCredentials(string username, string password)
        {

            if (!File.Exists("users.txt"))
            {
                MessageBox.Show("Kullan�c� kay�tlar� bulunamad�.");
                return false;
            }

            string[] users = File.ReadAllLines("users.txt");

            foreach (var user in users)
            {
                string[] userInfo = user.Split(',');
                if (userInfo.Length == 2 && userInfo[0] == username && userInfo[1] == password)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            RegisterUser(username, password);

            MessageBox.Show("Kay�t ba�ar�yla tamamland�.");
        }


        private void RegisterUser(string username, string password)
        {
            using (StreamWriter writer = new StreamWriter("users.txt", true))
            {
                writer.WriteLine($"{username},{password}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}