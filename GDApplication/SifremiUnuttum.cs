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
using System.Data.Sql;
using System.Net;
using System.Net.Mail;

namespace GDApplication
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        //bu mailin gelmesi için google mail hesabınızdan güvenliği düşük uygulamalardan gelen maillere izin vermelisiniz.
        private void button1_Click(object sender, EventArgs e)
        {
            SqlBaglantisi baglan = new SqlBaglantisi();
            SqlCommand komut = new SqlCommand("Select * From AboneBilgileri Where kullaniciAdi='"+txtKullaniciAdi.Text.ToString()+"'and email= '"+txtMail.Text.ToString()+"'",baglan.baglan());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (baglan.baglan().State == ConnectionState.Closed)
                    {
                        baglan.baglan().Open();
                        //elif
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailAdresi = ("gazetedergi343541@gmail.com");
                    String sifre = ("343541SER");
                    String smtpsrvr = "smtp.gmail.com";
                    String kime = (oku["email"].ToString().TrimEnd());
                    String konu = ("ŞİFRE HATIRLATMA MAİLİ..");
                    String yaz = ("Sayin,"+oku["ad"].ToString().TrimEnd() + "\n"+"Bizden"+tarih+
                        "Tarihinde Şifre Hatırlatma Talebinde Bulundunuz."+"\n"+"Parolanız:"+oku["sifre"].ToString().TrimEnd() + 
                        "\nİyi Günler");
                    smtpserver.Credentials = new NetworkCredential(mailAdresi,sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smtpsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailAdresi);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Şifreniz Mail Adresinize Gönderilmiştir..");
                    this.Hide();
                   
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Bilgileri Kontrol Ediniz. Mail Gönderilemedi.", Hata.Message);  
                }
            }
;        }
    }
}
