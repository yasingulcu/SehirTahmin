using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SehirCalisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem.ToString()==textBox1.Text)
            {
                MessageBox.Show("Doğru");
                textBox1.Clear();
                RastgeleSecim();
                Karistir();

            }
            else
            {
                MessageBox.Show("Yanlış");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader streamReader = File.OpenText(@"C:\Users\ysg02\Desktop\Sehirler.txt");
            string metin;
            while((metin=streamReader.ReadLine())!=null)
            {
                listBox1.Items.Add(metin);
            }
            streamReader.Close();
            label1.Text = "";
            RastgeleSecim();
            Karistir();
            
        }
        private void RastgeleSecim()
        {
            int adet = listBox1.Items.Count;
            Random rnd = new Random();
            int sayi = rnd.Next(0, adet);
            listBox1.SelectedIndex = sayi;
            label1.Text = listBox1.SelectedItem.ToString();
        }
        private void Karistir()
        {
            string metin = label1.Text;
            string yeni = "";
            Random r = new Random();
            int randomIndex = 0;
            int uzunluk = metin.Length;
            for (int i = uzunluk; i > 0; i--)
            {
                randomIndex = r.Next(0, uzunluk);
                yeni += metin[randomIndex];
                metin = metin.Remove(randomIndex, 1);
                uzunluk = metin.Length;
            }
            label1.Text = yeni;
        }
    }
}
