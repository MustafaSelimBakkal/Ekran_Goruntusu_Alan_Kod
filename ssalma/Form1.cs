using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ssalma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap Screenshot()
        {
            // Ekran görüntüsü alırken formu kapatır ve böylece ekranda gözükmez
            this.Opacity = 0;

            // ss alan kodumuz
            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);


            // formu geri getiren kod
            this.Opacity = 1;

            return Screenshot;
        }

        string KayitYolu = @"C:\Ekran_Resimleri";
        string ResimAdi()
        {
            return "SS_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_") + ".jpg";
            // Örnek Resim Adı : SS_20.04.2023_12_48_50.jpg 
            // Saniyeye kadar aldıkki resim adları çakışmasın. Çakışma olması durumda eskiyi siler. Üzerine yazar.
        }

        void Kaydet(string resimAdi)
        {
            // C yerel diskinde bir klasör açıyoruz. 
            // Klasör varsa hiçbir işlem yapmayacak
            // Klasör yoksa klasör oluşturacak.
            if(!File.Exists(KayitYolu))
                Directory.CreateDirectory(KayitYolu);
            // Aldığımız resmi kayıt ediyoruz.
            Screenshot().Save(KayitYolu + "\\" + resimAdi + "", ImageFormat.Jpeg);

        }

        //Home tuşu jısa yol olucak kısayolun kodu
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Home)
                Kaydet(ResimAdi());
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Kaydet(ResimAdi());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
