using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace sigortaacentasi
{
    public partial class Hosgeldiniz : Form
    {
        public Hosgeldiniz()
        {
            InitializeComponent();
            txtParola.PasswordChar='*';
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataReader dr;

        private void Hosgeldiniz_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string ad = txtKullanici.Text;
            string parola = txtParola.Text;
            baglanti = new SqlConnection("Data Source=EMRE;Initial Catalog=sigortaacentasi;User ID=sa;Password=19951903");
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanici where kullaniciad='" + txtKullanici.Text + "' AND kullaniciparola='" + txtParola.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Musteri_Ekrani f2 = new Musteri_Ekrani();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            baglanti.Close();
        }
    }
}
