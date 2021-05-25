using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GDApplication
{
    public partial class AboneGirisForm : Form
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-9IQ5NO3T;Initial Catalog=GazeteDergiApp; "
                    + "Integrated Security=TRUE");
        public AboneGirisForm()
        {
            InitializeComponent();
        }

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                txtKullaniciAdi.Text = "";
                txtKullaniciAdi.ForeColor = Color.White;
            }
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
            {
                txtKullaniciAdi.Text = "Kullanıcı Adı";
                txtKullaniciAdi.ForeColor = Color.Silver;
            }
        }
        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.White;
                txtSifre.PasswordChar = '*';
            }
        }
        char? none = null;
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = Color.Silver;
                txtSifre.PasswordChar = Convert.ToChar(none);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool isThere;
        private void button3_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;


            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from AboneBilgileri", baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                if (kullaniciAdi == okuyucu["kullaniciAdi"].ToString().TrimEnd()
                    && sifre == okuyucu["sifre"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }
                else isThere = false;
            }
            baglanti.Close();
            if (isThere)
            {
                MessageBox.Show("Başarılı Giriş", "PROGRAM:");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!!", "PROGRAM:");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            KayıtOlForm kayıtOlForm = new KayıtOlForm();
            kayıtOlForm.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.ShowDialog();

        }
    }
}
