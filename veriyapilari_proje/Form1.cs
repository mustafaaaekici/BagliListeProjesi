using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriyapilari_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Dugum
        {
            public int kod, fiyat;
            public String isim;
            public Dugum onceki, sonraki;
        }
        Dugum ilkDugum = null;
        Dugum sonDugum = null;
        Dugum gecici;
        public void basaEkleme()
        {
            Dugum dugum = new Dugum();
            dugum.kod = Convert.ToInt32(textBox1.Text);
            dugum.isim = textBox2.Text;
            dugum.fiyat = Convert.ToInt32(textBox3.Text);
            dugum.sonraki = ilkDugum;
            dugum.onceki = null;
            if (ilkDugum != null)
            {
                ilkDugum.onceki = dugum;
            }
            ilkDugum = dugum;
        }
        public void sonaEkle()
        {
            Dugum dugum = new Dugum();
            dugum.kod = Convert.ToInt32(textBox1.Text);
            dugum.isim = textBox2.Text;
            dugum.fiyat = Convert.ToInt32(textBox3.Text);
            Dugum sondugum = ilkDugum;
            dugum.sonraki = null;
            if (ilkDugum == null)
            {
                dugum.onceki = null;
                ilkDugum = dugum;
            }
            while (sondugum.sonraki != null)
            {
                sondugum = sondugum.sonraki;
            }
            sondugum.sonraki = dugum;
            dugum.onceki = sondugum;
        }
        public void arayaEkle()
        {
            Dugum dugum = new Dugum();
            dugum.kod = Convert.ToInt32(textBox1.Text);
            dugum.isim = textBox2.Text;
            dugum.fiyat = Convert.ToInt32(textBox3.Text);
            gecici = ilkDugum;
            if (ilkDugum != null)
            {
                while (gecici.kod < dugum.kod)
                {
                    if (gecici.sonraki.kod > dugum.kod)
                    {
                        break;
                    }
                    gecici = gecici.sonraki;
                }
                gecici.sonraki.onceki = dugum;
                dugum.sonraki = gecici.sonraki;
                gecici.sonraki = dugum;
                dugum.onceki = gecici;
            }
        }
        public void listeyeYazdir(Dugum ilkDugum)
        {
            richTextBox1.Text = null;
            while (ilkDugum != null)
            {
                richTextBox1.Text += ilkDugum.kod + ":" + ilkDugum.isim + ":" + ilkDugum.fiyat;
                richTextBox1.Text += "->";
                ilkDugum = ilkDugum.sonraki;
            }
            richTextBox1.Text += null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            basaEkleme();
            listeyeYazdir(ilkDugum);
        }
        public Dugum silinecekBul(int kod)
        {
            int silinecekSayi = kod;
            int kontrol = 0;
            if (ilkDugum == null)
            {
                richTextBox1.Text = "Listeye eleman girilmemiş";
            }
            if (ilkDugum.kod == silinecekSayi)
            {
                MessageBox.Show("Eleman bulundu");
            }
            Dugum gecici = ilkDugum;
            while (gecici.sonraki != null)
            {
                if (gecici.sonraki.kod == silinecekSayi)
                {
                    kontrol = 1;
                    textBox5.Text = gecici.sonraki.isim;
                    textBox6.Text = Convert.ToString(gecici.sonraki.fiyat);
                    break;
                }
                gecici = gecici.sonraki;
            }
            if (kontrol == 0)
            {
                textBox5.Text = "Bulunamadı...";
                textBox6.Text = "Bulunamadı...";
            }
            return gecici.sonraki;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int silinecekSayi = 0;
            silinecekSayi = Convert.ToInt32(textBox4.Text);
            silinecekBul(silinecekSayi);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int aranacakSayi = 0;
            aranacakSayi = Convert.ToInt32(textBox7.Text);
            bul(aranacakSayi);
        }
        public Dugum bul(int kod)
        {
            int aranacakSayi = kod;
            aranacakSayi = Convert.ToInt32(textBox7.Text);
            int kontrol = 0;
            if (ilkDugum == null)
            {
                richTextBox1.Text = "Listeye eleman girilmemiş";
            }
            if (ilkDugum.kod == aranacakSayi)
            {
                MessageBox.Show("Eleman bulundu");
            }
            Dugum gecici = ilkDugum;
            while (gecici.sonraki != null)
            {
                if (gecici.sonraki.kod == aranacakSayi)
                {
                    kontrol = 1;
                    textBox8.Text = gecici.sonraki.isim;
                    textBox9.Text = Convert.ToString(gecici.sonraki.fiyat);
                    break;
                }
                gecici = gecici.sonraki;
            }

            if (kontrol == 0)
            {
                textBox8.Text = "Bulunamadı...";
                textBox9.Text = "Bulunamadı...";
            }
            return gecici.sonraki;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sonaEkle();
            listeyeYazdir(ilkDugum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arayaEkle();
            listeyeYazdir(ilkDugum);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int fiyat = Convert.ToInt32(textBox9.Text);
            textBox9.Text = " ";          
            Dugum guncelle = bul(Convert.ToInt32(textBox7.Text));
            gecici = ilkDugum;
            while (gecici.sonraki != null)
            {
                
                if (gecici.kod == guncelle.kod)
                {

                    guncelle.fiyat = fiyat;
                    listeyeYazdir(ilkDugum);
                }
                gecici = gecici.sonraki;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Dugum sil = silinecekBul(Convert.ToInt32(textBox4.Text));
            gecici = ilkDugum;
            if (ilkDugum.sonraki == null)
            {
                if (ilkDugum != null)
                {
                    ilkDugum = gecici.sonraki;
                    gecici.onceki = null;
                }
            }
            while (gecici.sonraki != null)
            {
                if (gecici.kod == sil.kod)
                {
                    gecici.onceki.sonraki = gecici.sonraki;
                    gecici.sonraki.onceki = gecici.onceki;
                    break;
                }
                gecici = gecici.sonraki;
            }
            if (gecici.sonraki == null)
            {
                if (ilkDugum.sonraki != null)
                {
                    gecici = ilkDugum;
                    while (gecici.sonraki.sonraki != null)
                    {
                        gecici = gecici.sonraki;
                    }
                    gecici.sonraki = null;
                }    
            }
            listeyeYazdir(ilkDugum);
        }
    }
}
