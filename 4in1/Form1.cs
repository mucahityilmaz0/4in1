using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _4in1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> selectedImagePaths = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog.Multiselect = true;

            openFileDialog.FileOk += OpenFileDialog_FileOk4;

            openFileDialog.ShowDialog();
        }
        private void ShowSelectedImages()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }

            int pictureBoxWidth = 100;
            int pictureBoxHeight = 100;
            int pictureBoxSpacing = 10;
            int x = 12;
            int y = 90;

            foreach (string imagePath in selectedImagePaths)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(x, y);
                pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = Image.FromFile(imagePath);
                this.Controls.Add(pictureBox);

                x += pictureBoxWidth + pictureBoxSpacing;
                if (x + pictureBoxWidth > this.ClientSize.Width)
                {
                    x = 10;
                    y += pictureBoxHeight + pictureBoxSpacing;
                }
            }
        }
        private void OpenFileDialog_FileOk4(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog = (OpenFileDialog)sender;

            if (openFileDialog.FileNames.Length > 4)
            {
                e.Cancel = true;
                MessageBox.Show("Lütfen en fazla 4 dosya seçin.");
                return;
            }

            selectedImagePaths = openFileDialog.FileNames.ToList();
            ShowSelectedImages();
        }
        PictureBox pictureBox1 = new PictureBox();
        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni bir 256x256 boyutunda dizi oluþtur
            int[,] combinedPixelValues = new int[256, 256];

            // Tüm fotoðraflarýn piksel deðerlerini topla
            for (int k = 0; k < selectedImagePaths.Count; k++)
            {
                using (Bitmap bitmap = new Bitmap(selectedImagePaths[k]))
                {
                    for (int x = 0; x < 256; x++)
                    {
                        for (int y = 0; y < 256; y++)
                        {
                            // Pikselin gri seviyesini hesapla ve topla
                            Color pixelColor = bitmap.GetPixel(x, y);
                            int grayValue = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3.0);
                            combinedPixelValues[x, y] += grayValue;
                        }
                    }
                }
            }

            // Toplanan deðerleri fotoðraf sayýsýna böleerek ortalama deðeri al
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    combinedPixelValues[x, y] /= selectedImagePaths.Count;
                }
            }

            // TextBox'a eklenecek metni bir StringBuilder nesnesine ekle
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    sb.AppendLine(combinedPixelValues[x, y].ToString());
                }
            }

            // TextBox'a metni tek seferde ekle
            textBox1.Text = sb.ToString();

            // Yeni bir 256x256 boyutunda bitmap oluþtur
            Bitmap newImage = new Bitmap(256, 256);

            // Her piksel için renk oluþtur ve bitmap'e ekle
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    int grayValue = combinedPixelValues[x, y]; // Kombinasyonlanmýþ piksel deðerini al

                    // Gri tonlamalý renk oluþtur
                    Color color = Color.FromArgb(grayValue, grayValue, grayValue);

                    // Yeni pikseli bitmap'e ekle
                    newImage.SetPixel(x, y, color);
                }
            }

            // Oluþturulan yeni bitmap'i kullanabilirsiniz


            // PictureBox oluþturun veya mevcut bir PictureBox kontrolünün Image özelliðini newImage ile ayarlayýn
           
            pictureBox1.Image = newImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Size = new Size(256, 256);
            pictureBox1.Location = new Point(this.Width - pictureBox1.Width - 20, this.Height - pictureBox1.Height - 20);

            // PictureBox'ý formunuza ekleyin
            this.Controls.Add(pictureBox1);


        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog.Multiselect = true;

            openFileDialog.FileOk += OpenFileDialog_FileOk8;

            openFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk8(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog = (OpenFileDialog)sender;

            if (openFileDialog.FileNames.Length > 8)
            {
                e.Cancel = true;
                MessageBox.Show("Lütfen en fazla 8 dosya seçin.");
                return;
            }

            selectedImagePaths = openFileDialog.FileNames.ToList();
            ShowSelectedImages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog.Multiselect = true;

            openFileDialog.FileOk += OpenFileDialog_FileOk10;

            openFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk10(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog = (OpenFileDialog)sender;

            if (openFileDialog.FileNames.Length > 10)
            {
                e.Cancel = true;
                MessageBox.Show("Lütfen en fazla 10 dosya seçin.");
                return;
            }

            selectedImagePaths = openFileDialog.FileNames.ToList();
            ShowSelectedImages();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            double[] pmf = new double[256];
            Image newImage= pictureBox1.Image;
            string tempImagePath = Path.GetTempFileName();
            newImage.Save(tempImagePath);

            using (Mat image = CvInvoke.Imread(tempImagePath, ImreadModes.Grayscale))
            {
                Image<Gray, byte> grayImage = image.ToImage<Gray, byte>();

                DenseHistogram histogram = new DenseHistogram(256, new RangeF(0, 256));

                histogram.Calculate(new Image<Gray, byte>[] { grayImage }, false, null);

                float[] histogramValues = new float[256];
                histogram.CopyTo(histogramValues);

                double totalPixels = grayImage.Width * grayImage.Height;

                for (int i = 0; i < 256; i++)
                {
                    pmf[i] = histogramValues[i] / totalPixels;

                }

            }

            int[] X = new int[256];
            double[] uf = new double[256];
            for (int i = 0; i <= 255; i++)
            {
                X[i] = i;
                uf[i] = pmf[i];
            }

            for (int i = 1; i < X.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(X[i], uf[i]);
                if (i > -1)
                {
                    chart1.Series["Series1"].Points.AddXY(X[i], 0);
                    chart1.Series["Series1"].Points.AddXY(X[i], uf[i]);
                }
            }

            chart1.ChartAreas[0].AxisX.Title = "8-Bit Grayscale";
            chart1.ChartAreas[0].AxisY.Title = "# of Occurencess";
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Series1"].Color = Color.Blue;
            File.Delete(tempImagePath);
        }
    }
}
