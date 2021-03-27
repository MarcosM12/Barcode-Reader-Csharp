using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;

namespace SS_OpenCV
{ 
    public partial class MainForm : Form
    {
        Image<Bgr, Byte> img = null; // working image
        Image<Bgr, Byte> imgUndo = null; // undo backup image - UNDO
        Image<Bgr, Byte> imgCopia = null; // undo backup image - UNDO

        string title_bak = "";

        public MainForm()
        {
            InitializeComponent();
            title_bak = Text;
        }

        /// <summary>
        /// Opens a new image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = new Image<Bgr, byte>(openFileDialog1.FileName);
                Text = title_bak + " [" +
                        openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) +
                        "]";

                ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
                ImageViewer.Dock = DockStyle.Fill;

                imgUndo = img.Copy();
                ImageViewer.Image = img.Bitmap;
                ImageViewer.Refresh();


            }
        }

        /// <summary>
        /// Saves an image with a new name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageViewer.Image.Save(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// restore last undo copy of the working image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgUndo == null) // verify if the image is already opened
                return; 
            Cursor = Cursors.WaitCursor;
            img = imgUndo.Copy();

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        /// <summary>
        /// Change visualization mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zoom
            if (autoZoomToolStripMenuItem.Checked)
            {
                ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
                ImageViewer.Dock = DockStyle.Fill;
            }
            else // with scroll bars
            {
                ImageViewer.Dock = DockStyle.None;
                ImageViewer.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        /// <summary>
        /// Show authors form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorsForm form = new AuthorsForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Calculate the image negative
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.Negative(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }



        /// <summary>
        /// Call image convertion to gray scale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.ConvertToGray(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void redChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.RedChannel(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void blueChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            ImageClass.BlueChannel(img);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void greenChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();


            ImageClass.GreenChannel(img);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void brightnessToolStripMenuItem1_Click(object sender, EventArgs e){

            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            InputBox form = new InputBox("brilho?");
            form.ShowDialog();
            int brilho = Convert.ToInt32(form.ValueTextBox.Text);
           // form2.ResetText();


            InputBox form2 = new InputBox("Contraste?");
            form2.ShowDialog();
            double cont = Convert.ToDouble(form.ValueTextBox.Text);


            ImageClass.BrightContrast(img, brilho, cont);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void translationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            
            InputBox form = new InputBox("Qual o valor Dx?");
            form.ShowDialog();
            int Dx = Convert.ToInt32(form.ValueTextBox.Text);

            InputBox form2 = new InputBox("Qual o valor Dy?");
            form2.ShowDialog();
            int Dy = Convert.ToInt32(form.ValueTextBox.Text);

            ImageClass.Translation(img, imgUndo, Dx, Dy);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
            
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 
            float angleRad = 0;
            //copy Undo Image
            imgUndo = img.Copy();

            InputBox form = new InputBox("Qual o valor do ângulo a rodar?");
            form.ShowDialog();
            int angle = Convert.ToInt32(form.ValueTextBox.Text);
            angleRad = (float)(Math.PI / 180) * angle;

            ImageClass.Rotation(img, imgUndo, angleRad);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            InputBox form = new InputBox("Qual o valor de Zoom?");
            form.ShowDialog();
            float scaleFactor = (float)Convert.ToDecimal(form.ValueTextBox.Text);

            ImageClass.Scale(img, imgUndo, scaleFactor);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor

        }

        //create mouse variable
        int mouseX, mouseY;
        bool mouseFlag = false;
        private void zoomXYToolStripMenuItem_Click(object sender, EventArgs e)
        {    

            if (img == null) // verify if the image is already opened
                return;
       

            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox form = new InputBox("Qual o valor de Zoom?");
            form.ShowDialog();
            //float scaleFactor = (float)Convert.ToDecimal(form.ValueTextBox.Text);
            float scaleFactor = float.Parse(form.ValueTextBox.Text);
            
            //get mouse coordinates using mouseclick event
            mouseFlag = true;
            while (mouseFlag) //wait for mouseclick
                Application.DoEvents();

            //apply the zoom
            ImageClass.Scale_point_xy(img, imgUndo, scaleFactor, mouseX, mouseY);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void meanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //////copy Undo Image
            imgUndo = img.Copy();


            ImageClass.Mean(img, imgUndo);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void nonUniformToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NonUniform form = new NonUniform();
            form.ShowDialog();

            
            float matrix1 = float.Parse(form.textBox1.Text);
            float matrix2 = float.Parse(form.textBox2.Text);
            float matrix3 = float.Parse(form.textBox3.Text);
            float matrix4 = float.Parse(form.textBox4.Text);
            float matrix5 = float.Parse(form.textBox5.Text);
            float matrix6 = float.Parse(form.textBox6.Text);
            float matrix7 = float.Parse(form.textBox7.Text);
            float matrix8 = float.Parse(form.textBox8.Text);
            float matrix9 = float.Parse(form.textBox9.Text);
            float weight = float.Parse(form.textBox10.Text);



            float[,] matrix = new float[,] { { matrix1, matrix2, matrix3 }, { matrix4, matrix5, matrix6 }, { matrix7, matrix8, matrix9 } };
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 


            //copy Undo Image
            imgUndo = img.Copy();


            switch (form.comboBox1.Text)
            {

                case "Mean 3x3":
                    ImageClass.Mean(img, imgUndo);
                    form.textBox1.Text = "1";
                    break;

                case "NonUniform":
                    ImageClass.NonUniform(img, imgUndo, matrix, weight);
                    break;

                case "Sobel":
                    ImageClass.Sobel(img, imgUndo);
                    break;

            }
            
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
            //NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight);

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void histogramGreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();


            Histogram form = new Histogram(ImageClass.Histogram_Gray(imgUndo));
            form.ShowDialog();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }
        
        private void histogramRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();


            HistogramRGB form = new HistogramRGB(ImageClass.Histogram_RGB(imgUndo));
            form.ShowDialog();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
            
        }

        private void binarizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox form = new InputBox("Qual o valor de Threshold?");
            form.ShowDialog();
            //float scaleFactor = (float)Convert.ToDecimal(form.ValueTextBox.Text);
            int threshold = int.Parse(form.ValueTextBox.Text);

  

            //apply the zoom
            ImageClass.ConvertToBW(img, threshold);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void histogramAllToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();


            HistogramAll form = new HistogramAll(ImageClass.Histogram_Gray(imgUndo),ImageClass.Histogram_RGB(imgUndo));
            form.ShowDialog();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
            
        }

        private void oTSUToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 


            ImageClass.ConvertToBW_Otsu(img);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 


        }

		private void sobelToolStripMenuItem_Click(object sender, EventArgs e) {
             if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            ImageClass.Sobel(img, imgUndo);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

		}

		private void diferenciaçãoToolStripMenuItem_Click(object sender, EventArgs e) {
            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            ImageClass.Diferentiation(img, imgUndo);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
		}

		private void medianToolStripMenuItem_Click(object sender, EventArgs e) {
             if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            ImageClass.Median(img,imgUndo);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor     
            
		}

        private void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            ImageClass.Roberts(img, imgUndo);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void contagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;
            int width = s.width;


            Projection_X form = new Projection_X(ImageClass.Projection_X(imgUndo), width);

            form.ShowDialog();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }

        private void projectionYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;
            int height = s.height;


            Project_Y form = new Project_Y(ImageClass.Projection_Y(imgUndo), height);

            form.ShowDialog();


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void drawRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            int[] matrix = new int[4];  //[xf,xi,yf,yi]
            matrix = ImageClass.Treshold_rectangle(img,1000);

            //[xf,xi,yf,yi]

            Point bc_centroid1 = new Point(0,0);
            bc_centroid1.X = matrix[1]; //(matrix[0] - matrix[1])/2; 
            bc_centroid1.Y = matrix[3]; //(matrix[2] - matrix[3])/2;


            Size bc_size1 = new Size(0,0);
            bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
            bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

            string bc_image1 = "ola";
            string bc_number1 = "ola";

            Point bc_centroid2 = new Point(0, 0);
            bc_centroid2.X = 0;
            bc_centroid2.Y = 0;

            Size bc_size2 = new Size(0, 0);
            bc_size2.Width = 0;
            bc_size2.Height = 0;
            
            string bc_image2 = "ola";
            string bc_number2 = "ola";


            ImageClass.BarCodeReader(img, 0, out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
            

            //ImageClass.BarCodeReader(img, 0, out Point1, new Size (190,71), "imagem", "number", new Point(95, 36), new Size(190, 71), "imagem2", "number2");
            
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void iterativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();            

           
            MIplImage s = imgUndo.MIplImage;
          
            
            ImageClass.SaveLabels(img, imgUndo);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 
        }

        private void erodeToolStripMenuItem_Click(object sender, EventArgs e) //Dilatation
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;


            ImageClass.Dilatation(img, imgUndo);



            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void erodeToolStripMenuItem1_Click(object sender, EventArgs e) //Erode
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;


            ImageClass.Erode(img, imgUndo);



            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor

        }

        //Draw Rectangle Iterative
        private void digitsToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            //imgCopia = img.Copy();
            


            Cursor = Cursors.WaitCursor; // clock cursor 
            float angleRad = 0;
            int angle=6;
            int[] matrix = new int[4];  //[xf,xi,yf,yi]
            angleRad = (float)(Math.PI / 180) * angle;
            float treshold = 5;


            ImageClass.ConvertToBW_Otsu(img);
            ImageClass.Negative(img);
            imgCopia = img.Copy();
            ImageClass.Rotation(img, imgCopia, angleRad);
            imgCopia = img.Copy();
            ImageClass.Border(img);
            imgCopia = img.Copy();
            matrix = ImageClass.RectangleIterative(img,treshold);

            //[xf,xi,yf,yi]
            Point bc_centroid1 = new Point(0, 0);
            bc_centroid1.X = matrix[1]; //(matrix[0] - matrix[1])/2; 
            bc_centroid1.Y = matrix[3]; //(matrix[2] - matrix[3])/2;


            Size bc_size1 = new Size(0, 0);
            bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
            bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

            string bc_image1 = "ola";
            string bc_number1 = "ola";

            Point bc_centroid2 = new Point(0, 0);
            bc_centroid2.X = 0;
            bc_centroid2.Y = 0;

            Size bc_size2 = new Size(0, 0);
            bc_size2.Width = 0;
            bc_size2.Height = 0;

            string bc_image2 = "ola";
            string bc_number2 = "ola";


            ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);


            //ImageClass.BarCodeReader(img, 0, out Point1, new Size (190,71), "imagem", "number", new Point(95, 36), new Size(190, 71), "imagem2", "number2");

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }


        private void ImageViewer_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (mouseFlag)
            {
                mouseX = e.X; //get mouse coordinates
                mouseY = e.Y;

                Console.WriteLine("args1: {0} args2: {1}", mouseX, mouseY);
                mouseFlag = false;  //unlock while(mouseFlag)
            }
        }


        public int ImageType() //Returns the type of image 1,2,3,4
        {
            string path = openFileDialog1.FileName;
            string type = string.Empty;
            int val=0;

            for (int i = 0; i < path.Length; i++)
            {
                if (Char.IsDigit(path[i]))
                { // encontra primeiro numero do path da imagem
                    type += path[i];
                    break;
                }

            }
            if (type.Length > 0)
                val = int.Parse(type); //converter caracter numero para int 

           Console.WriteLine(val);
            return val;
        }



        private void momentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;
        

            ImageClass.Momento(img);



            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void rotationBilinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 
            float angleRad = 0;
            //copy Undo Image
            imgUndo = img.Copy();

            InputBox form = new InputBox("Qual o valor do ângulo a rodar?");
            form.ShowDialog();
            int angle = Convert.ToInt32(form.ValueTextBox.Text);
            angleRad = (float)(Math.PI / 180) * angle;

            ImageClass.Rotation_Bilinear(img, imgUndo, angleRad);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor

        }

        private void zoomBilinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            InputBox form = new InputBox("Qual o valor de Zoom?");
            form.ShowDialog();
            float scaleFactor = (float)Convert.ToDecimal(form.ValueTextBox.Text);

            ImageClass.Scale_Bilinear(img, imgUndo, scaleFactor);

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

        private void zoomXYBilinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;


            //copy Undo Image
            imgUndo = img.Copy();
            Cursor = Cursors.WaitCursor; // clock cursor 

            InputBox form = new InputBox("Qual o valor de Zoom?");
            form.ShowDialog();
            //float scaleFactor = (float)Convert.ToDecimal(form.ValueTextBox.Text);
            float scaleFactor = float.Parse(form.ValueTextBox.Text);

            //get mouse coordinates using mouseclick event
            mouseFlag = true;
            while (mouseFlag) //wait for mouseclick
                Application.DoEvents();

            //apply the zoom
            ImageClass.Scale_point_xy(img, imgUndo, scaleFactor, mouseX, mouseY);


            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }
        


        //Função que encontra os digitos
        private void digitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;
            //char "r";
            
            ImageClass.Digitos(img);
            String b=ImageClass.EvaluateCompNumber();
            //Console.WriteLine(b);
            
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor

        }

        private void ImageViewer_Click(object sender, EventArgs e)
        {

        }

        private void border1pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();

            MIplImage s = imgUndo.MIplImage;
           
            ImageClass.Border(img);
            
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
        }

		private void digitosBarraToolStripMenuItem_Click(object sender, EventArgs e) {
            if (img == null) // verify if the image is already opened
                return;
            Cursor = Cursors.WaitCursor; // clock cursor 

            //copy Undo Image
            imgUndo = img.Copy();
            int[] matrix;

            MIplImage s = imgUndo.MIplImage;

            //matrix = ImageClass.RectangleIterative(img,(float)3.5);
            ////Console.WriteLine(ImageClass.DigitosBarra(img,matrix));
            //ImageClass.DigitosBarra(img, matrix);
            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor
		}

		private void barcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null) // Função para gerir métodos para processar barcodes
                return;

            
            Cursor = Cursors.WaitCursor; // clock cursor 

            //Variavéis
            int[] matrix = new int[4];  //[xf,xi,yf,yi]
            Point bc_centroid1 = new Point(0, 0);
            Size bc_size1 = new Size(0, 0);
            string bc_image1 = "ola";
            string bc_number1 = "ola";
            Size bc_size2 = new Size(0, 0);
            string bc_image2 = "ola";
            string bc_number2 = "ola";
            Point bc_centroid2 = new Point(0, 0);

            float angleRad = 0;
            int angle = 1;

            switch (ImageType()) //Ver o tipo de imagem
            {
                case 1:
                    Console.WriteLine("Função do tipo 1");
                    ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
                    break;

                case 2:
                    Console.WriteLine("Função do tipo 2");
                    ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
                    break;

                case 3:
                    Console.WriteLine("Função do tipo 3");
                    ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
                    break;



                case 4:
                     Console.WriteLine("Função do tipo 4");
                    ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
                    break;

                case 5:
                    Console.WriteLine("Função do tipo 5");
                     ImageClass.BarCodeReader(img, ImageType(), out bc_centroid1, out bc_size1, out bc_image1, out bc_number1, out bc_centroid2, out bc_size2, out bc_image2, out bc_number2);
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }

            ImageViewer.Image = img.Bitmap;
            ImageViewer.Refresh(); // refresh image on the screen

            Cursor = Cursors.Default; // normal cursor 

        }








    }

}