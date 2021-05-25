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
    public partial class KayıtOlForm : Form
    {
        SqlConnection baglanti = AboneGirisForm.baglanti;
        public KayıtOlForm()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = "";
                txtSifre.ForeColor = Color.Black;
                txtSifre.PasswordChar = '*';
            }
        }
        char? none = null;
        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
            {
                txtSifre.Text = "Şifre";
                txtSifre.ForeColor = Color.LightGray;
                txtSifre.PasswordChar = Convert.ToChar(none);
            }
        }

        private void txtAd_Enter(object sender, EventArgs e)
        {
            if (txtAd.Text == "Adınız")
            {
                txtAd.Text = "";
                txtAd.ForeColor = Color.Black;
            }
        }

        private void txtAd_Leave(object sender, EventArgs e)
        {
            if (txtAd.Text == "")
            {
                txtAd.Text = "Adınız";
                txtAd.ForeColor = Color.LightGray;
            }
        }

        private void txtSoyad_Enter(object sender, EventArgs e)
        {
            if (txtSoyad.Text == "Soyadınız")
            {
                txtSoyad.Text = "";
                txtSoyad.ForeColor = Color.Black;
            }
        }

        private void txtSoyad_Leave(object sender, EventArgs e)
        {
            if (txtSoyad.Text == "")
            {
                txtSoyad.Text = "Soyadınız";
                txtSoyad.ForeColor = Color.LightGray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "E-Mail")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "E-Mail";
                txtEmail.ForeColor = Color.LightGray;
            }
        }

        private void txtTcNo_Enter(object sender, EventArgs e)
        {
            if (txtTcNo.Text == "TC No")
            {
                txtTcNo.Text = "";
                txtTcNo.ForeColor = Color.Black;
            }
        }

        private void txtTcNo_Leave(object sender, EventArgs e)
        {
            if (txtTcNo.Text == "")
            {
                txtTcNo.Text = "TC No";
                txtTcNo.ForeColor = Color.LightGray;
            }
        }

        private void txtDogumTarihi_Enter(object sender, EventArgs e)
        {
            if (txtDogumTarihi.Text == "Doğum Tarihi")
            {
                txtDogumTarihi.Text = "";
                txtDogumTarihi.ForeColor = Color.Black;
            }
        }

        private void txtDogumTarihi_Leave(object sender, EventArgs e)
        {
            if (txtDogumTarihi.Text == "")
            {
                txtDogumTarihi.Text = "Doğum Tarihi";
                txtDogumTarihi.ForeColor = Color.LightGray;
            }
        }

        private void txtSehir_Enter(object sender, EventArgs e)
        {
            if (txtSehir.Text == "Şehir")
            {
                txtSehir.Text = "";
                txtSehir.ForeColor = Color.Black;
            }
        }

        private void txtSehir_Leave(object sender, EventArgs e)
        {
            if (txtSehir.Text == "")
            {
                txtSehir.Text = "Şehir";
                txtSehir.ForeColor = Color.LightGray;
            }
        }

        private void txtİlce_Enter(object sender, EventArgs e)
        {
            if (txtIlce.Text == "İlçe")
            {
                txtIlce.Text = "";
                txtIlce.ForeColor = Color.Black;
            }
        }

        private void txtİlce_Leave(object sender, EventArgs e)
        {
            if (txtIlce.Text == "")
            {
                txtIlce.Text = "İlçe";
                txtIlce.ForeColor = Color.LightGray;
            }
        }

        private void txtAdres_Enter(object sender, EventArgs e)
        {
            if (txtAdres.Text == "Adres")
            {
                txtAdres.Text = "";
                txtAdres.ForeColor = Color.Black;
            }
        }

        private void txtAdres_Leave(object sender, EventArgs e)
        {
            if (txtAdres.Text == "")
            {
                txtAdres.Text = "Adres";
                txtAdres.ForeColor = Color.LightGray;
            }
        }

        private void txtTelNo_Enter(object sender, EventArgs e)
        {
            if (txtTelNo.Text == "Telefon Numarası")
            {
                txtTelNo.Text = "";
                txtTelNo.ForeColor = Color.Black;
            }
        }

        private void txtTelNo_Leave(object sender, EventArgs e)
        {
            if (txtTelNo.Text == "")
            {
                txtTelNo.Text = "Telefon Numarası";
                txtTelNo.ForeColor = Color.LightGray;
            }
        }

        private void comboBoxCinsiyet_Enter(object sender, EventArgs e)
        {
            if (comboBoxCinsiyet.Text == "Cinsiyet")
            {
                comboBoxCinsiyet.Text = "";
                comboBoxCinsiyet.ForeColor = Color.Black;
            }
        }

        private void comboBoxCinsiyet_Leave(object sender, EventArgs e)
        {
            if (comboBoxCinsiyet.Text == "")
            {
                comboBoxCinsiyet.Text = "Cinsiyet";
                comboBoxCinsiyet.ForeColor = Color.LightGray;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into AboneBilgileri (kullaniciAdi,sifre,ad,soyad,email,tcNo," +
                "dogumTarihi,sehir,ilce,adres,telefonNo,cinsiyet) " +
                "values('"+textBox1.Text+ "','" + txtSifre.Text + "','"+txtAd.Text+ "','" + txtSoyad.Text + "'," +
                "'" + txtEmail.Text + "','" + txtTcNo.Text + "','" + txtDogumTarihi.Text + "','" + txtSehir.Text + "'," +
                "'" + txtIlce.Text + "','" + txtAdres.Text + "','" + txtTelNo.Text + "','" + comboBoxCinsiyet.Text + "')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Gerçekleşti...","Program::");
        }
    }
    }


