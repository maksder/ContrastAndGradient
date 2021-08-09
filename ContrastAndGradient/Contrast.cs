using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastAndGradient
{
    class Contrast
    {
        public void ContrastImage(PictureBox pictureBox1, PictureBox pictureBox2, int poz, int lenght)
        {
            Bitmap inputImage = new Bitmap(pictureBox1.Image);
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
            int R;
            int G;
            int B;
            int N = (100 / lenght) * poz;           
                for (int j = 0; j < inputImage.Height; j++)
                {
                    for (int i = 0; i < inputImage.Width; i++)
                    {
                        if (N >= 0)
                        {
                            if (N == 100) N = 99;
                            R = ((((int)(inputImage.GetPixel(i, j).R)) * 100 - 128 * N) / (100 - N));
                            G = ((((int)(inputImage.GetPixel(i, j).G)) * 100 - 128 * N) / (100 - N));
                            B = ((((int)(inputImage.GetPixel(i, j).B)) * 100 - 128 * N) / (100 - N));
                        }
                        else
                        {
                            R = ((((int)inputImage.GetPixel(i, j).R) * (100 - (-N)) + (128 * (-N))) / 100);
                            G = ((((int)inputImage.GetPixel(i, j).G) * (100 - (-N)) + (128 * (-N))) / 100);
                            B = ((((int)inputImage.GetPixel(i, j).B) * (100 - (-N)) + (128 * (-N))) / 100);
                        }
                        if (R < 0) R = 0;
                        if (R > 255) R = 255;
                        if (G < 0) G = 0;
                        if (G > 255) G = 255;
                        if (B < 0) B = 0;
                        if (B > 255) B = 255;
                        outputImage.SetPixel(i, j, Color.FromArgb(((int)R), ((int)G), ((int)B)));                      
                    }
                }            
            pictureBox2.Image = outputImage;         
        }
    }
}