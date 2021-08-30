using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContrastAndGradient
{
    public partial class Form1 : Form
    {
        Bitmap inputImage;
        Contrast contrast = new Contrast();
        Sobel sobel = new Sobel();

        public Form1()
        {
            InitializeComponent();
        }

        public void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; 
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputImage = new Bitmap(file.FileName);
                    pictureBox1.Image = inputImage;
                }
                catch
                {
                    MessageBox.Show("Невернный формат файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBarContrast.Visible = true;
            buttonSobel.Visible = false;
            label1.Visible = true;
            pictureBox2.Image = inputImage;
        }

        private void GradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBarContrast.Visible = false;
            buttonSobel.Visible = true;
            label1.Visible = false;
            pictureBox2.Image = inputImage;
        }

        private async void ButtonSobel_Click(object sender, EventArgs e)
        {
            await Task.Run(() => sobel.SobelConvert(inputImage, inputImage.Width, inputImage.Height, pictureBox2));
        }

        private async void TrackBarContrast_MouseUp(object sender, MouseEventArgs e)
        {
            int poz = trackBarContrast.Value;
            int lenght = trackBarContrast.Maximum;
            await Task.Run(() => contrast.ContrastImage(inputImage, pictureBox2, poz, lenght));
        }
    }
}
