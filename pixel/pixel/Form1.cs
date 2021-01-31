using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixel
{

    public partial class Form1 : Form
    {
        Bitmap resim = new Bitmap(300, 300);
        Bitmap gray_resim = new Bitmap(300, 300);
        Bitmap bitmap_resim = new Bitmap(300, 300);
        Bitmap pikselOP_resim = new Bitmap(300, 300);
        
        int Bxl, Bx, Bxr;
        int Dl = 255, D = 255, Dr = 255;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                Graphics.FromImage(resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);


            }
            Graphics.FromImage(gray_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(bitmap_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(pikselOP_resim).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            if (resim != null)
            {
                int x, y;
                x = Convert.ToInt32(textBox1.Text);
                y = Convert.ToInt32(textBox2.Text);
                Color renk = resim.GetPixel(x, y);
                panel1.BackColor = renk;
                int r, g, b, a;
                r = renk.R;
                g = renk.G;
                b = renk.B;
                a = renk.A;

                textBox3.Text = a + "-" + r + "-" + g + "-" + b;
                //  textBox3.Text = renk.Name;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int gray;
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    gray = (r + g + b) / 3;
                    gray_resim.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
                pictureBox2.Image = gray_resim;
                this.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (textBox4.Text != "")
            {


                Color renk;
                int r, g, b;
                int gray, threshold;
                threshold = Convert.ToInt32(textBox4.Text);
                for (int x = 0; x < 300; x++)
                {
                    for (int y = 0; y < 300; y++)
                    {
                        renk = resim.GetPixel(x, y);
                        r = Convert.ToInt32(renk.R);
                        g = Convert.ToInt32(renk.G);
                        b = Convert.ToInt32(renk.B);
                        gray = (r + g + b) / 3;

                        if (gray > threshold)
                        {
                            bitmap_resim.SetPixel(x, y, Color.FromArgb(255, 255, 255));//Beyaz rengi yazdırır
                        }
                        else
                        {
                            bitmap_resim.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                pictureBox2.Image = bitmap_resim;

            }
            else
            {
                MessageBox.Show("Eşit değerini giriniz:");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int darken;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler
                    darken = r - 128;
                    r = darken;
                    if (darken < 0) r = 0;
                    //red için işlmeler

                    //green için işlemler
                    darken = g - 128;
                    g = darken;
                    if (darken < 0) g = 0;
                    //red için işlmeler

                    //blue için işlemler
                    darken = b - 128;
                    b = darken;
                    if (darken < 0) b = 0;
                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int L_contrast;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler
                    L_contrast = r / 2;
                    r = L_contrast;

                    //red için işlmeler

                    //green için işlemler
                    L_contrast = g / 2;
                    g = L_contrast;

                    //red için işlmeler

                    //blue için işlemler
                    L_contrast = b / 2;
                    b = L_contrast;

                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int N_L_contrast;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler

                    N_L_contrast = (int)Math.Pow((r / 255), 0.33) * 255;
                    r = N_L_contrast;

                    //red için işlmeler

                    //green için işlemler
                    N_L_contrast = (int)Math.Pow((g / 255), 0.33) * 255;
                    g = N_L_contrast;

                    //red için işlmeler

                    //blue için işlemler
                    N_L_contrast = (int)Math.Pow((b / 255), 0.33) * 255;
                    b = N_L_contrast;

                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int N_R_contrast;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler

                    N_R_contrast = (int)((Math.Pow((r / 255), 2)) * 255);
                    r = N_R_contrast;

                    //red için işlmeler

                    //green için işlemler
                    N_R_contrast = (int)((Math.Pow((g / 255), 2)) * 255);
                    g = N_R_contrast;

                    //red için işlmeler

                    //blue için işlemler
                    N_R_contrast = (int)((Math.Pow((b / 255), 2)) * 255);
                    b = N_R_contrast;

                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;

        }

        private void button10_Click(object sender, EventArgs e)
        {

            Color renk;
            int r, g, b;
            int invert;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler
                    invert = 255 - r;
                    r = invert;
                    if (invert < 0) r = 0;
                    //red için işlmeler

                    //green için işlemler
                    invert = 255 - g;
                    g = invert;
                    if (invert < 0) g = 0;
                    //red için işlmeler

                    //blue için işlemler
                    invert = 255 - b;
                    b = invert;
                    if (invert < 0) b = 0;
                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int Lighteen;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler
                    Lighteen = r + 128;
                    r = Lighteen;
                    if (Lighteen > 255) r = 255;
                    //red için işlmeler

                    //green için işlemler
                    Lighteen = g + 128;
                    g = Lighteen;
                    if (Lighteen > 255) g = 255;
                    //red için işlmeler

                    //blue için işlemler
                    Lighteen = b + 128;
                    b = Lighteen;
                    if (Lighteen > 255) b = 255;
                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int R_contrast;

            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 300; y++)
                {
                    renk = resim.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);

                    //red için işlemler
                    R_contrast = r * 2;
                    r = R_contrast;
                    if (R_contrast > 255) r = 255;
                    //red için işlmeler

                    //green için işlemler
                    R_contrast = g * 2;
                    g = R_contrast;
                    if (R_contrast > 255) g = 255;
                    //red için işlmeler

                    //blue için işlemler
                    R_contrast = b * 2;
                    b = R_contrast;
                    if (R_contrast > 255) b = 255;
                    //blue için işlmeler

                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(r, g, b));//Beyaz rengi yazdırır
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Color renk;
            int SX, SY, Gradient;
            int sy0=-1, sy1=0, sy2=1, sy3=-2, sy4=0, sy5=2, sy6=-1, sy7=0, sy8=1; ;
            int sx0=1, sx1=2, sx2=1, sx3=0, sx4=0, sx5=0, sx6=-1, sx7=-2, sx8=-1; ;
            int p0, p1, p2, p3, p4, p5, p6, p7, p8;
            
            for (int x = 1; x < 299; x++)
            {
                for (int y = 1; y < 299; y++)
                {
                    renk = gray_resim.GetPixel(x-1, y-1);
                    p0 = renk.R;
                    renk = gray_resim.GetPixel(x, y - 1);
                    p1 = renk.R;
                    renk = gray_resim.GetPixel(x+1, y - 1);
                    p2 = renk.R;
                    renk = gray_resim.GetPixel(x - 1, y );
                    p3 = renk.R;
                    renk = gray_resim.GetPixel(x , y);
                    p4= renk.R;
                    renk = gray_resim.GetPixel(x+1, y);
                    p5 = renk.R;
                    renk = gray_resim.GetPixel(x -1, y+1);
                    p6 = renk.R;
                    renk = gray_resim.GetPixel(x, y+1);
                    p7= renk.R;
                    renk = gray_resim.GetPixel(x + 1, y+1);
                    p8= renk.R;
                    SY =( sy0 * p0 + sy1 * p1 + sy2 * p2 + sy3 * p3 + sy4 * p4 + sy5 * p5 + sy6 * p6 + sy7 * p7 + sy8 * p8)/8;
                    SX = (sx0 * p0 + sx1 * p1 + sx2 * p2 + sx3 * p3 + sx4 * p4 + sx5 * p5 + sx6 * p6 + sx7 * p7 + sx8 * p8)/8;
                    Gradient = (int)Math.Sqrt(SY * SY + SX * SX);
                    int THR = Convert.ToInt32(textBox4.Text);
                    //listBox1.Items.Add(Gradient);
                    if (Gradient >= 128) { 
                    pikselOP_resim.SetPixel(x, y, Color.FromArgb(255,255 ,255));
                }
                    else
                    {
                        pikselOP_resim.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox2.Image = pikselOP_resim;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (textBox4.Text != "")
            {

              
                Color renk;
                
                for (int x = 1; x < 299; x++)
                {
                    for (int y = 1; y < 299; y++)
                    {
                        renk = bitmap_resim.GetPixel(x-1, y);
                        Bxl = renk.R;

                        renk = bitmap_resim.GetPixel(x , y);
                        Bx = renk.R;

                        renk = bitmap_resim.GetPixel(x +1, y);
                        Bxr = renk.R;

                        if ((Dl==Bxl)|| (D==Bx)||(Dr==Bxr))
                        {
                            pikselOP_resim.SetPixel(x, y, Color.FromArgb(255, 255, 255));//Beyaz rengi yazdırır
                        }
                       
                    }
                }
                pictureBox2.Image = pikselOP_resim;

            }
           
        }

    }
}
