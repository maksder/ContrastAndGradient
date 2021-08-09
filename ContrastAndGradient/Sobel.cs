using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastAndGradient
{
    class Sobel
    {
        public void SobelConvert(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            Bitmap inputImage = new Bitmap(pictureBox1.Image);
            Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
            int width = inputImage.Width;
            int height = inputImage.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];
        
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = inputImage.GetPixel(i, j).R;
                    allPixG[i, j] = inputImage.GetPixel(i, j).G;
                    allPixB[i, j] = inputImage.GetPixel(i, j).B;
                }
            }

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            double rG, gG, bG;
            for (int i = 1; i < inputImage.Width - 1; i++)
            {
                for (int j = 1; j < inputImage.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;
                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            if (hw == 0)
                            {
                                new_rx += 2 * (gx[wi + 1, hw + 1] * rc);
                                new_ry += 2 * (gy[wi + 1, hw + 1] * rc);
                            }
                            else
                            {
                                new_rx += gx[wi + 1, hw + 1] * rc;
                                new_ry += gy[wi + 1, hw + 1] * rc;
                            }


                            gc = allPixG[i + hw, j + wi];
                            if (hw == 0)
                            {
                                new_gx += 2 * (gx[wi + 1, hw + 1] * gc);
                                new_gy += 2 * (gy[wi + 1, hw + 1] * gc);
                            }
                            else
                            {
                                new_gx += gx[wi + 1, hw + 1] * gc;
                                new_gy += gy[wi + 1, hw + 1] * gc;
                            }


                            bc = allPixB[i + hw, j + wi];
                            if (hw == 0)
                            {
                                new_bx += 2 * (gx[wi + 1, hw + 1] * bc);
                                new_by += 2 * (gy[wi + 1, hw + 1] * bc);
                            }
                            else
                            {
                                new_bx += gx[wi + 1, hw + 1] * bc;
                                new_by += gy[wi + 1, hw + 1] * bc;
                            }

                        }
                    }

                    rG = Math.Sqrt(Math.Pow(new_rx, 2) + Math.Pow(new_ry, 2));
                    gG = Math.Sqrt(Math.Pow(new_gx, 2) + Math.Pow(new_gy, 2));
                    bG = Math.Sqrt(Math.Pow(new_bx, 2) + Math.Pow(new_by, 2));

                    if (rG > 255) rG = 255;
                    else if (rG < 0) rG = 0;
                    if (gG > 255) gG = 255;
                    else if (gG < 0) gG = 0;
                    if (bG > 255) bG = 255;
                    else if (bG < 0) bG = 0;

                    outputImage.SetPixel(i, j, Color.FromArgb(((int)rG), ((int)gG), ((int)bG)));
                }
            }
            pictureBox2.Image = outputImage;
        }

    }
}

