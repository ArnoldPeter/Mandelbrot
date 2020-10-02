using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    double a = (double)(i - (pictureBox1.Width / 2))/((double)pictureBox1.Width /4);
                    double b = (double)(j - (pictureBox1.Height / 2)) / ((double)pictureBox1.Height / 4);
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    int it = 0;

                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);

                        if(z.Magnitude() > 2.0)
                        {
                            break;
                        }
                    }
                    while (it < 200);
                    bm.SetPixel(i, j, it < 100 ? Color.Black : Color.White);
                }
            }
            pictureBox1.Image = bm;
        }
    }
}
