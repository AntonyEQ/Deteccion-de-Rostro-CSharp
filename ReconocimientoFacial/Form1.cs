using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReconocimientoFacial
{
    public partial class Form1 : Form
    {
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() {Multiselect = false, Filter = "JPEG,PNG|*.JPG;*.PNG" })
            {
                if (ofd.ShowDialog()==DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    Bitmap bitmap = new Bitmap(pictureBox1.Image);  
                    Image<Rgb, Byte> grayImage = new Image<Rgb, Byte>(bitmap);
                    Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.4, 0);

                    foreach (Rectangle rectangulo in rectangles)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (Pen lapiz = new Pen(Color.GreenYellow, 2))
                            {
                                graphics.DrawRectangle(lapiz, rectangulo);

                            }
                        }
                    }
                    pictureBox1.Image = bitmap;
                }
            }
        }
    }
}
 