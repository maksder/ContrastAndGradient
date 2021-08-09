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
                    Bitmap image = new Bitmap(file.FileName);
                    pictureBox1.Image = image;

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
            pictureBox2.Image = null;
        }

        private void GradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBarContrast.Visible = false;
            buttonSobel.Visible = true;
            pictureBox2.Image = null;
        }

        private void ButtonSobel_Click(object sender, EventArgs e)
        {
            Sobel image = new Sobel();
            image.SobelConvert(pictureBox1, pictureBox2);
        }

        private void TrackBarContrast_Scroll(object sender, EventArgs e)
        {
            //CallContrast();
            Contrast image = new Contrast();
            image.ContrastImage(pictureBox1, pictureBox2, trackBarContrast.Value, trackBarContrast.Maximum);
        }

    }
}
