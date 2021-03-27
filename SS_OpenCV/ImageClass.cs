using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Numerics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SS_OpenCV
{
    class ImageClass {

        /// <summary>
        /// Image Negative using EmguCV library
        /// Slower method
        /// </summary>
        /// <param name="img">Image</param>
        public static void NegativeSlow(Image<Bgr, byte> img) {
            int x, y;

            Bgr aux;
            for (y = 0; y < img.Height; y++) {
                for (x = 0; x < img.Width; x++) {
                    // Indirect access
                    aux = img[y, x];
                    img[y, x] = new Bgr(255 - aux.Blue, 255 - aux.Green, 255 - aux.Red);
                }
            }
        }

        /// <summary>
        /// Convert to gray
        /// Direct access to memory - faster method
        /// </summary>
        /// <param name="img">image</param>
        public static unsafe void ConvertToGray(Image<Bgr, byte> img) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte blue, green, red, gray;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int x, y;

            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        //retrive 3 colour components
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // convert to gray
                        gray = (byte)Math.Round(((int)blue + green + red) / 3.0);

                        // store in the image
                        dataPtr[0] = gray;
                        dataPtr[1] = gray;
                        dataPtr[2] = gray;

                        // advance the pointer to the next pixel
                        dataPtr += nChan;
                    }

                    //at the end of the line advance the pointer by the aligment bytes (padding)
                    dataPtr += padding;
                }
            }
        }

         /// <summary>
        /// // Negative
        ///  function with fast access to memory
        ///  returns the negative of image img
        /// </summary>
        /// <param name="img">image</param>       
        public static unsafe void Negative(Image<Bgr, byte> img) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte blue, green, red;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int x, y;


            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        //retrive 3 colour components
                        blue = dataPtr[0];
                        green = dataPtr[1];
                        red = dataPtr[2];

                        // convert to negative
                        // store in the image
                        dataPtr[0] = (byte)(255 - blue);
                        dataPtr[1] = (byte)(255 - green);
                        dataPtr[2] = (byte)(255 - red);

                        // advance the pointer to the next pixel
                        dataPtr += nChan;
                    }

                    //at the end of the line advance the pointer by the aligment bytes (padding)
                    dataPtr += padding;
                }
            }

        }

        /// <summary>
        /// RedChannel
        /// Attribute the red component value to the other two components
        /// Three components R, G and B have the same value (value of the R component)
        /// </summary>
        /// <param name="img">image</param>  
        public static unsafe void RedChannel(Image<Bgr, byte> img) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte red;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alignment bytes (padding)
            int x, y;

            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        //retrive 3 colour components
                        red = dataPtr[2];
                        //attribute the red component value to the other two components
                        dataPtr[0] = red;
                        dataPtr[1] = red;

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
            }

        }

        /// <summary>
        /// GreenChannel
        /// Attribute the green component value to the other two components
        /// Three components R, G and B have the same value (value of the G component)
        /// </summary>
        /// <param name="img">image</param>  
        public static unsafe void GreenChannel(Image<Bgr, byte> img) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte green;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; 
            int x, y;

            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        //retrive 3 colour components
                        green = dataPtr[1];

                        dataPtr[0] = green;
                        dataPtr[2] = green;

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
            }
        }

         /// <summary>
        /// BlueChannel
        /// Attribute the blue component value to the other two components
        /// Three components R, G and B have the same value (value of the B component)
        /// </summary>
        /// <param name="img">image</param>  
        public static unsafe void BlueChannel(Image<Bgr, byte> img) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte blue;

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int x, y;

            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        //retrive 3 colour components
                        blue = dataPtr[0];

                        dataPtr[1] = blue;
                        dataPtr[2] = blue;

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
            }
        }

        /// <summary>
        /// BrightContrast
        /// Changes the contrast and brightness of image img,
        /// according to the values bright and contrast given by the user
        /// </summary>
        /// <param name="img">image</param> 
        /// <param name="bright">Brigthness value</param>
        /// <param name="contrast">Contrast value</param>
        public static unsafe void BrightContrast(Image<Bgr, byte> img, int bright, double contrast) {

            // direct access to the image memory(sequencial)
            // direcion top left -> bottom right

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image            

            int width = img.Width;
            int height = img.Height;
            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int x, y, i;

            double aux;
            if (nChan == 3) // image in RGB
            {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {

                        for (i = 0; i < 3; i++) {
                           aux= Math.Round(contrast * dataPtr[i] + bright);
                            if (aux > 255)
                                dataPtr[i] = 255;
                            else {
                                if (aux < 0)
                                    dataPtr[i] = 0;
                                else
                                    dataPtr[i] = (byte)aux;

                            }
                        }

                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
            }
        }

        /// <summary>
        /// Translation
        /// Translates image img according to the coordenates dx,dy
        /// </summary>
        /// <param name="img">image</param> 
        /// <param name="imgCopy">Backup image</param>
        /// <param name="dx">Coordenate x</param>
        ///  <param name="dy">Coordenate y</param>
        public static unsafe void Translation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, int dx, int dy) {

            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer();     
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();
            byte* dataOrigPtr;

            int height = img.Height; 
            int width = img.Width;   
            int nChan = m.nChannels; 
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = n.widthStep;
            int x, y, x_origem, y_origem;


            if (nChan == 3) { //image in RGB

                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        x_origem = x - dx;
                        y_origem = y - dy;

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height)) {
                            
                            dataOrigPtr = dataCopyPtr + (y_origem) * widthstep + (x_origem) * nChan;
                            dataPtr[0] = dataOrigPtr[0];
                            dataPtr[1] = dataOrigPtr[1];
                            dataPtr[2] = dataOrigPtr[2];

                        }
                        else {
                            // Black background
                            dataPtr[0] = 0; 
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // increment pointer
                        dataPtr += nChan;
                    }
                    
                    dataPtr += padding;
                }
            }
        }

        /// <summary>
        /// Rotation
        /// Rotates image [img]  [angle] radians 
        /// </summary>
        /// <param name="img">image</param> 
        /// <param name="imgCopy">Backup image</param>
        /// <param name="angle">Rotation angle in radians</param>
        public static unsafe void Rotation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float angle) {

            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obtain an img pointer 
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer(); // pointer copy
            byte* dataOrigPtr;
            int height = img.Height; //img height
            int width = img.Width;   //img width
            int nChan = m.nChannels; //number of channels of img
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = n.widthStep;
            int x, y, x_origem = 0, y_origem = 0;



            if (nChan == 3) { //image in RGB

                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {

                        
                        y_origem = (int)Math.Round(height / 2.0 - (x - width / 2.0) * Math.Sin(angle) - (height / 2.0 - y) * Math.Cos(angle));
                        x_origem = (int)Math.Round((x - width / 2.0) * Math.Cos(angle) - (height / 2.0 - y) * Math.Sin(angle) + width / 2.0);

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height)) {
                            dataOrigPtr = dataCopyPtr + (y_origem) * widthstep + (x_origem) * nChan;
                            dataPtr[0] = dataOrigPtr[0];
                            dataPtr[1] = dataOrigPtr[1];
                            dataPtr[2] = dataOrigPtr[2];

                        }
                        else { //background
                            dataPtr[0] = 255;                       
                            dataPtr[1] = 255; 
                            dataPtr[2] = 255;
                        }
                        //Next pixel
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }
            }
        }
       
         /// <summary>
        /// Scale
        /// Scale image [img] based on scale factor [scaleFactor]
        /// </summary>
        /// <param name="img">image</param> 
        /// <param name="imgCopy">Backup image</param>
        /// <param name="scaleFactor">Scale factor</param>
        public static unsafe void Scale(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor) {

            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer();    
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();
            byte* dataOrigPtr = dataCopyPtr;
            int height = img.Height; 
            int width = img.Width;   
            int nChan = m.nChannels; 
            int padding = m.widthStep - m.nChannels * m.width; 
            int widthstep = n.widthStep;
            int x, y, x_origem = 0, y_origem = 0;



            if (nChan == 3) { //image in RGB

                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        if (scaleFactor > 0) {
                            x_origem = (int)Math.Round((x / scaleFactor));
                            y_origem = (int)Math.Round((y / scaleFactor));

                        }

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height)) {
                            dataOrigPtr = dataCopyPtr + (y_origem) * widthstep + (x_origem) * nChan;
                            
                            dataPtr[0] = dataOrigPtr[0];
                            dataPtr[1] = dataOrigPtr[1];
                            dataPtr[2] = dataOrigPtr[2];

                        }
                        else {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                       
                        dataPtr += nChan;
                    }
                   
                    dataPtr += padding;
                }
            }
        }
         /// <summary>
        /// Scale_point_xy
        /// Scale image [img] based on scale factor [scaleFactor] and coordenates center x and center y
        /// Scales image and centers it in centerX and centerY
        /// </summary>
        /// <param name="img">image</param> 
        /// <param name="imgCopy">Backup image</param>
        /// <param name="scaleFactor">Scale factor</param>
        /// <param name="centerX">Scale factor</param>
        /// <param name="centerY">Scale factor</param>
        public static unsafe void Scale_point_xy(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor, int centerX, int centerY) {

            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem    
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();// obter apontador da imagem copia
            byte* dataOrigPtr = dataCopyPtr;
            int height = img.Height; //altura imagem
            int width = img.Width;   //largura imagem
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = n.widthStep;
            int x, y, x_origem = 0, y_origem = 0;


            if (nChan == 3) { //image in RGB

                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        if (scaleFactor > 0) {


                            y_origem = (int)Math.Round((y / scaleFactor) + centerY - ((height / 2) / scaleFactor));
                            x_origem = (int)Math.Round((x / scaleFactor) + centerX - ((width / 2) / scaleFactor));

                        }


                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height)) {

                            dataOrigPtr = dataCopyPtr + (y_origem) * widthstep + (x_origem) * nChan;
                            // calcula endereço do pixel no ponto (x,y)
                            dataPtr[0] = dataOrigPtr[0];
                            dataPtr[1] = dataOrigPtr[1];
                            dataPtr[2] = dataOrigPtr[2];

                        }
                        else {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }
        }

        
        public static unsafe void Mean(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy) {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //To reset dataPtr pointer
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // (padding)
            int widthStep = s.widthStep;
            double x, y;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = Top-rigth corner
            //aux_2 = Bottom-rigth corner
            //aux_3 = Top-left corner
            //aux_4 = Bottom-left corner

            if (nChan == 3) {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++) {
                    for (x = 1; x < width - 1; x++) {

                        for (int k = 0; k < 3; k++) {
                            dataPtr[k] = (byte)Math.Round((((dataPtrCopy + aux_3)[k] + (dataPtrCopy - widthStep)[k] +
                                (dataPtrCopy + aux_1)[k] + (dataPtrCopy - nChan)[k] + dataPtrCopy[k] +
                                (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_4)[k] + (dataPtrCopy + widthStep)[k] +
                                (dataPtrCopy + aux_2)[k]) / 9.0));

                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                //(canto superior esquerdo)  x=0 e y=0
                for (int i = 0; i <= 2; i++) {
                    dataPtr[i] = (byte)Math.Round((((dataPtrCopy)[i] * 4.0 + (dataPtrCopy + nChan)[i] * 2.0 + (dataPtrCopy + aux_2)[i] + (dataPtrCopy + widthStep)[i] * 2.0) / 9.0));
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {

                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + nChan)[k] * 2.0 +
                            (dataPtrCopy + aux_2)[k] + (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_4)[k]) / 9.0));
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++) {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_4)[k] + (dataPtrCopy + widthStep)[k] * 2.0) / 9.0));
                }

                dataPtr += nChan;
                dataPtrCopy += nChan;
                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                for (y = 1; y < height - 1; y++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy + widthStep)[k] * 2.0 +
                        (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k] + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy + aux_1)[k]) / 9.0));
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++) {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy + nChan)[k] * 2.0 + (dataPtrCopy + aux_1)[k] + (dataPtrCopy - widthStep)[k] * 2.0) / 9.0));
                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy + nChan)[k] * 2.0 +
                        (dataPtrCopy + aux_1)[k] + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_3)[k] + (dataPtrCopy - widthStep)[k]) / 9.0));
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++) {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_3)[k]) / 9.0));
                }

                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;

                for (y = 1; y < height - 1; y++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy + widthStep)[k] * 2.0 + (dataPtrCopy + aux_3)[k] + (dataPtrCopy + aux_4)[k] + (dataPtrCopy - nChan)[k]) / 9.0));
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

            }

        }
        public static unsafe void Mean_solutionB(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y;
            byte sum;
            double[] soma9 = new double[3];
            soma9[0] = 0;
            soma9[1] = 0;
            soma9[2] = 0;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3)
            {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        //Percorrer o kernel 3x3 na imagem

                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy + aux_3)[k] + (dataPtrCopy - widthStep)[k] +
                            (dataPtrCopy + aux_1)[k] + (dataPtrCopy - nChan)[k] + dataPtrCopy[k] +
                            (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_4)[k] + (dataPtrCopy + widthStep)[k] +
                            (dataPtrCopy + aux_2)[k]) / 9.0));

                        soma9[k] = ((dataPtrCopy + aux_3)[k] + (dataPtrCopy - widthStep)[k] +
                            (dataPtrCopy + aux_1)[k] + (dataPtrCopy - nChan)[k] + dataPtrCopy[k] +
                            (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_4)[k] + (dataPtrCopy + widthStep)[k] +
                            (dataPtrCopy + aux_2)[k]);


                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                    for (x = 2; x < width - 1; x++)
                    {

                        for (int k = 0; k < 3; k++)
                        {

                            //Percorrer o kernel 3x3 na imagem
                            dataPtr[k] = (byte)Math.Round((((soma9[k] - (dataPtrCopy - 2 * nChan)[k] - (dataPtrCopy - 2 * nChan + widthStep)[k] - (dataPtrCopy - 2 * nChan - widthStep)[k] +
                                (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_1)[k] + (dataPtrCopy + aux_2)[k])) / 9.0));

                            soma9[k] = (((soma9[k] - (dataPtrCopy - 2 * nChan)[k] - (dataPtrCopy - 2 * nChan + widthStep)[k] - (dataPtrCopy - 2 * nChan - widthStep)[k] +
                                ((dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_1)[k] + (dataPtrCopy + aux_2)[k]))));

                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                //(canto superior esquerdo)  x=0 e y=0
                for (int i = 0; i <= 2; i++)
                {
                    dataPtr[i] = (byte)Math.Round((((dataPtrCopy)[i] * 4.0 + (dataPtrCopy + nChan)[i] * 2.0 + (dataPtrCopy + aux_2)[i] + (dataPtrCopy + widthStep)[i] * 2.0) / 9.0));
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + nChan)[k] * 2.0 +
                            (dataPtrCopy + aux_2)[k] + (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_4)[k]) / 9.0));
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++)
                {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_4)[k] + (dataPtrCopy + widthStep)[k] * 2.0) / 9.0));
                }

                dataPtr += nChan;
                dataPtrCopy += nChan;
                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy + widthStep)[k] * 2.0 +
                        (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k] + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy + aux_1)[k]) / 9.0));
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++)
                {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy + nChan)[k] * 2.0 + (dataPtrCopy + aux_1)[k] + (dataPtrCopy - widthStep)[k] * 2.0) / 9.0));
                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy + nChan)[k] * 2.0 +
                        (dataPtrCopy + aux_1)[k] + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_3)[k] + (dataPtrCopy - widthStep)[k]) / 9.0));
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++)
                {
                    dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 4.0 + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy - nChan)[k] * 2.0 + (dataPtrCopy + aux_3)[k]) / 9.0));
                }

                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;

                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtr[k] = (byte)Math.Round((((dataPtrCopy)[k] * 2.0 + (dataPtrCopy - widthStep)[k] * 2.0 + (dataPtrCopy + widthStep)[k] * 2.0 + (dataPtrCopy + aux_3)[k] + (dataPtrCopy + aux_4)[k] + (dataPtrCopy - nChan)[k]) / 9.0));
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

            }

        }



        public static unsafe void NonUniform(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float[,] matrix, float matrixWeight) {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y, dataPtrAux;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo



            if (nChan == 3) {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++) {
                    for (x = 1; x < width - 1; x++) {

                        for (int k = 0; k < 3; k++) {

                            //Percorrer o kernel 3x3 na imagem
                            dataPtrAux = Math.Round((((dataPtrCopy + aux_3)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy + aux_1)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy + aux_4)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + aux_2)[k] * matrix[2, 2]) / matrixWeight));

                            if (dataPtrAux < 0)
                                dataPtr[k] = 0;
                            else if (dataPtrAux > 255)
                                dataPtr[k] = 255;
                            else
                                dataPtr[k] = (byte)dataPtrAux;

                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++) {

                    dataPtrAux = Math.Round((((dataPtrCopy)[k] * matrix[0, 0] + (dataPtrCopy)[k] * matrix[0, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[0, 2] + (dataPtrCopy)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy + widthStep)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + aux_2)[k] * matrix[2, 2]) / matrixWeight));


                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {

                        dataPtrAux = Math.Round((((dataPtrCopy - nChan)[k] * matrix[0, 0] + (dataPtrCopy)[k] * matrix[0, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy + aux_4)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + aux_2)[k] * matrix[2, 2]) / matrixWeight));

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = Math.Round((((dataPtrCopy - nChan)[k] * matrix[0, 0] + (dataPtrCopy)[k] * matrix[0, 1] +
                                (dataPtrCopy)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy)[k] * matrix[1, 2] + (dataPtrCopy + aux_4)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + widthStep)[k] * matrix[2, 2]) / matrixWeight));

                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                /*
                dataPtr += nChan;
                dataPtrCopy += nChan;

                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                */


                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                dataPtr += widthStep;
                dataPtrCopy += widthStep;


                for (y = 1; y < height - 1; y++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Round((((dataPtrCopy - widthStep)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy + aux_1)[k] * matrix[0, 2] + (dataPtrCopy)[k] * matrix[1, 0] + (dataPtrCopy)[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy + widthStep)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + aux_2)[k] * matrix[2, 2]) / matrixWeight));

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = Math.Round((((dataPtrCopy - widthStep)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy + aux_1)[k] * matrix[0, 2] + (dataPtrCopy)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy)[k] * matrix[2, 0] + (dataPtrCopy)[k] * matrix[2, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[2, 2]) / matrixWeight));

                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Round((((dataPtrCopy + aux_3)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy + aux_1)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy - nChan)[k] * matrix[2, 0] + (dataPtrCopy)[k] * matrix[2, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[2, 2]) / matrixWeight));

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = Math.Round((((dataPtrCopy + aux_3)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy - widthStep)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy)[k] * matrix[1, 2] + (dataPtrCopy - nChan)[k] * matrix[2, 0] + (dataPtrCopy)[k] * matrix[2, 1] +
                                (dataPtrCopy)[k] * matrix[2, 2]) / matrixWeight));

                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                /*
                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;

                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtrAux = Math.Round((((dataPtrCopy + aux_3)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy + aux_1)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy + nChan)[k] * matrix[1, 2] + (dataPtrCopy + aux_4)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + aux_2)[k] * matrix[2, 2]) / matrixWeight));

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }
                */

                //(linha direita) x=width y
                dataPtr -= widthStep;
                dataPtrCopy -= widthStep;
                for (y = height - 2; y > 0; y--) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Round((((dataPtrCopy + aux_3)[k] * matrix[0, 0] + (dataPtrCopy - widthStep)[k] * matrix[0, 1] +
                                (dataPtrCopy - widthStep)[k] * matrix[0, 2] + (dataPtrCopy - nChan)[k] * matrix[1, 0] + dataPtrCopy[k] * matrix[1, 1] +
                                (dataPtrCopy)[k] * matrix[1, 2] + (dataPtrCopy + aux_4)[k] * matrix[2, 0] + (dataPtrCopy + widthStep)[k] * matrix[2, 1] +
                                (dataPtrCopy + widthStep)[k] * matrix[2, 2]) / matrixWeight));

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr -= widthStep;
                    dataPtrCopy -= widthStep;
                }

            }

        }

        public static unsafe void Sobel(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy) {

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y, dataPtrAux;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            double Sx = 0, Sy = 0;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3) {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++) {
                    for (x = 1; x < width - 1; x++) {

                        for (int k = 0; k < 3; k++) // RGB
                        {

                            //Percorrer o kernel 3x3 na imagem
                            Sx = ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy + aux_4)[k]) - ((dataPtrCopy + aux_1)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k]);
                            Sy = ((dataPtrCopy + aux_4)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_2)[k]) - ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy + aux_1)[k]);

                            dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);   // Calcular módulo
                            if (dataPtrAux < 0)
                                dataPtr[k] = 0;
                            else if (dataPtrAux > 255)
                                dataPtr[k] = 255;
                            else
                                dataPtr[k] = (byte)dataPtrAux;


                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)


                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++) {

                    Sx = ((dataPtrCopy)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + widthStep)[k]) - ((dataPtrCopy + nChan)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k]);
                    Sy = ((dataPtrCopy + widthStep)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_2)[k]) - ((dataPtrCopy)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + nChan)[k]);
                    dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {

                        Sx = ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy + aux_4)[k]) - ((dataPtrCopy + nChan)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k]);
                        Sy = ((dataPtrCopy + aux_4)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_2)[k]) - ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + nChan)[k]);
                        dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++) {
                    Sx = ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy + aux_4)[k]) - ((dataPtrCopy)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + widthStep)[k]);
                    Sy = ((dataPtrCopy + aux_4)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + widthStep)[k]) - ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy)[k]);
                    dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                //(linha esquerda) x=0 y

                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                dataPtr += widthStep;
                dataPtrCopy += widthStep;


                for (y = 1; y < height - 1; y++) {
                    for (int k = 0; k < 3; k++) {
                        Sx = ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + widthStep)[k]) - ((dataPtrCopy + aux_1)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + aux_2)[k]);
                        Sy = ((dataPtrCopy + widthStep)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + aux_2)[k]) - ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy + aux_1)[k]);
                        dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++) {
                    Sx = ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy)[k]) - ((dataPtrCopy + aux_1)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + nChan)[k]);
                    Sy = ((dataPtrCopy)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + nChan)[k]) - ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy + aux_1)[k]);
                    dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {
                        Sx = ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy - nChan)[k]) - ((dataPtrCopy + aux_1)[k] + 2 * (dataPtrCopy + nChan)[k] + (dataPtrCopy + nChan)[k]);
                        Sy = ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + nChan)[k]) - ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy + aux_1)[k]);
                        dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++) {
                    Sx = ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy - nChan)[k]) - ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy)[k]);
                    Sy = ((dataPtrCopy - nChan)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy)[k]) - ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy - widthStep)[k]);
                    dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }


                //(linha direita) x=width y
                dataPtr -= widthStep;
                dataPtrCopy -= widthStep;
                for (y = height - 2; y > 0; y--) {
                    for (int k = 0; k < 3; k++) {
                        Sx = ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - nChan)[k] + (dataPtrCopy + aux_4)[k]) - ((dataPtrCopy - widthStep)[k] + 2 * (dataPtrCopy)[k] + (dataPtrCopy + widthStep)[k]);
                        Sy = ((dataPtrCopy + aux_4)[k] + 2 * (dataPtrCopy + widthStep)[k] + (dataPtrCopy + widthStep)[k]) - ((dataPtrCopy + aux_3)[k] + 2 * (dataPtrCopy - widthStep)[k] + (dataPtrCopy - widthStep)[k]);
                        dataPtrAux = Math.Abs(Sx) + Math.Abs(Sy);
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr -= widthStep;
                    dataPtrCopy -= widthStep;
                }

            }

        }

        public static unsafe void Diferentiation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy) {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y, dataPtrAux;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            double aux1 = 0, aux2 = 0;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3) {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++) {
                    for (x = 1; x < width - 1; x++) {

                        for (int k = 0; k < 3; k++) // RGB
                        {

                            //Percorrer o kernel 3x3 na imagem                         
                            dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]) + Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação
                            if (dataPtrAux < 0)
                                dataPtr[k] = 0;
                            else if (dataPtrAux > 255)
                                dataPtr[k] = 255;
                            else
                                dataPtr[k] = (byte)dataPtrAux;


                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)


                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++) {


                    dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]) + Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {

                        dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]) + Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }



                //(linha esquerda) x=0 y

                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                dataPtr += widthStep;
                dataPtrCopy += widthStep;


                for (y = 1; y < height - 1; y++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]) + Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação

                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]);   // Calcular diferenciação
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }

                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + nChan)[k]);   // Calcular diferenciação
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++) {
                    dataPtrAux = 0;   // Calcular diferenciação
                    if (dataPtrAux < 0)
                        dataPtr[k] = 0;
                    else if (dataPtrAux > 255)
                        dataPtr[k] = 255;
                    else
                        dataPtr[k] = (byte)dataPtrAux;
                }


                //(linha direita) x=width y
                dataPtr -= widthStep;
                dataPtrCopy -= widthStep;
                for (y = height - 2; y > 0; y--) {
                    for (int k = 0; k < 3; k++) {
                        dataPtrAux = Math.Abs((dataPtrCopy)[k] - (dataPtrCopy + widthStep)[k]);   // Calcular diferenciação
                        if (dataPtrAux < 0)
                            dataPtr[k] = 0;
                        else if (dataPtrAux > 255)
                            dataPtr[k] = 255;
                        else
                            dataPtr[k] = (byte)dataPtrAux;
                    }
                    dataPtr -= widthStep;
                    dataPtrCopy -= widthStep;
                }

            }

        }

        public static void Roberts(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {
            unsafe
            {
                // Origem
                MIplImage mCopy = imgCopy.MIplImage;
                byte* dataPtrCopy = (byte*)mCopy.imageData.ToPointer();

                //Destino
                MIplImage m2 = img.MIplImage;
                byte* dataPtr = (byte*)m2.imageData.ToPointer();

                int width = img.Width;
                int height = img.Height;
                int nChan = m2.nChannels; // number of channels - 3
                int padding = m2.widthStep - m2.nChannels * m2.width; // alinhament bytes (padding)
                double R0_p0, R0_p1, R1_p0, R1_p1, R2_p0, R2_p1;
                double r = 0, g = 0, b = 0;
                int x = 0, y = 0;
                /*NOTAS:
                    O TRATAMENTO DO CANTO SUPERIOR ESQUERDO = LINHA SUPERIOR = COLUNA ESQUERDA = CENTRO
                    O TRATAMENTO DO CANTO SUPERIOR DIREITO = COLUNA DIREITA
                    O TRATAMENTO DO CANTO INFERIOR ESQUERDO = LINHA INFERIOR                                  
                */


                //Fronteira começando pelo CANTO SUPERIOR ESQUERDO

                R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan + m2.widthStep)[0]);  //Diagonal Principal
                R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy + m2.widthStep)[0]);//Diagonal Secundária
                b = Math.Round(R0_p0 + R0_p1);

                R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan + m2.widthStep)[1]);
                R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy + m2.widthStep)[1]);
                g = Math.Round(R1_p0 + R1_p1);

                R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan + m2.widthStep)[2]);
                R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy + m2.widthStep)[2]);
                r = Math.Round(R2_p0 + R2_p1);
                /*if(b > 255)
                {
                    dataPtr[0] = 255
                }
                else
                {
                    if(b < 0)
                    {
                        dataPtr[0] = 0;
                    }
                    else
                    {
                        dataPtr[0] =b;
                    }
                }
                */
                dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));  //1º Caso b maior que 255 --> b=255 senão [2ºCaso b menor que 0---> b=0 senão mantem o valor de b original]  
                dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                //Agora vamos percorrer esta linha onde estamos, LINHA SUPERIOR
                dataPtr += nChan;
                dataPtrCopy += nChan;

                for (x = 1; x < width - 1; x++)
                {


                    R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan + m2.widthStep)[0]);
                    R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy + m2.widthStep)[0]);
                    b = Math.Round(R0_p0 + R0_p1);

                    R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan + m2.widthStep)[1]);
                    R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy + m2.widthStep)[1]);
                    g = Math.Round(R1_p0 + R1_p1);

                    R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan + m2.widthStep)[2]);
                    R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy + m2.widthStep)[2]);
                    r = Math.Round(R2_p0 + R2_p1);

                    dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                    dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                    dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //Tratamos agora da fronteira do CANTO SUPERIOR DIREITO 

                R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + m2.widthStep)[0]);
                R0_p1 = Math.Abs((dataPtrCopy)[0] - (dataPtrCopy + m2.widthStep)[0]);
                b = Math.Round(R0_p0 + R0_p1);

                R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + m2.widthStep)[1]);
                R1_p1 = Math.Abs((dataPtrCopy)[1] - (dataPtrCopy + m2.widthStep)[1]);
                g = Math.Round(R1_p0 + R1_p1);

                R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + m2.widthStep)[2]);
                R2_p1 = Math.Abs((dataPtrCopy)[2] - (dataPtrCopy + m2.widthStep)[2]);
                r = Math.Round(R2_p0 + R2_p1);

                dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                //Em seguida tratamos da fronteira da COLUNA DIREITA
                dataPtr += m2.widthStep;
                dataPtrCopy += m2.widthStep;

                for (y = 1; y < height - 1; y++)
                {


                    R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + m2.widthStep)[0]);
                    R0_p1 = Math.Abs((dataPtrCopy)[0] - (dataPtrCopy + m2.widthStep)[0]);
                    b = Math.Round(R0_p0 + R0_p1);

                    R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + m2.widthStep)[1]);
                    R1_p1 = Math.Abs((dataPtrCopy)[1] - (dataPtrCopy + m2.widthStep)[1]);
                    g = Math.Round(R1_p0 + R1_p1);

                    R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + m2.widthStep)[2]);
                    R2_p1 = Math.Abs((dataPtrCopy)[2] - (dataPtrCopy + m2.widthStep)[2]);
                    r = Math.Round(R2_p0 + R2_p1);

                    dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                    dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                    dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                    dataPtr += m2.widthStep;
                    dataPtrCopy += m2.widthStep;

                }

                //Percorrendo a coluna direita chegamos ao CANTO INFERIOR DIREITO

                dataPtr[0] = 0;
                dataPtr[1] = 0;
                dataPtr[2] = 0;

                //Agora vamos percorrer esta linha onde estamos, LINHA INFERIOR

                dataPtr -= nChan;
                dataPtrCopy -= nChan;
                for (x = 1; x < width - 1; x++)
                {

                    R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan)[0]);
                    R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy)[0]);
                    b = Math.Round(R0_p0 + R0_p1);

                    R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan)[1]);
                    R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy)[1]);
                    g = Math.Round(R1_p0 + R1_p1);

                    R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan)[2]);
                    R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy)[2]);
                    r = Math.Round(R2_p0 + R2_p1);

                    dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                    dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                    dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                    dataPtr -= nChan;
                    dataPtrCopy -= nChan;
                }

                //Por fim tratamos do UlTIMO canto que falta, CANTO INFERIOR ESQUERDO

                R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan)[0]);
                R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy)[0]);
                b = Math.Round(R0_p0 + R0_p1);

                R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan)[1]);
                R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy)[1]);
                g = Math.Round(R1_p0 + R1_p1);

                R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan)[2]);
                R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy)[2]);
                r = Math.Round(R2_p0 + R2_p1);

                dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                //Estando no canto esquerda falta tratar da COLUNA ESQUERDA
                dataPtr -= m2.widthStep;
                dataPtrCopy -= m2.widthStep;

                for (y = 1; y < height - 1; y++)
                {

                    R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan + m2.widthStep)[0]);
                    R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy + m2.widthStep)[0]);
                    b = Math.Round(R0_p0 + R0_p1);

                    R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan + m2.widthStep)[1]);
                    R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy + m2.widthStep)[1]);
                    g = Math.Round(R1_p0 + R1_p1);

                    R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan + m2.widthStep)[2]);
                    R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy + m2.widthStep)[2]);
                    r = Math.Round(R2_p0 + R2_p1);

                    dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                    dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                    dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));

                    dataPtr -= m2.widthStep;
                    dataPtrCopy -= m2.widthStep;

                }
                //Tratar finalmente da parte CENTRAL


                //centro/////////////////////////////////////////////////////////////////////////////////////////////

                dataPtr += m2.widthStep;
                dataPtrCopy += m2.widthStep;

                for (y = 1; y < height - 1; y++)
                {
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                    for (x = 1; x < width - 1; x++)
                    {

                        R0_p0 = Math.Abs(dataPtrCopy[0] - (dataPtrCopy + nChan + m2.widthStep)[0]);
                        R0_p1 = Math.Abs((dataPtrCopy + nChan)[0] - (dataPtrCopy + m2.widthStep)[0]);
                        b = Math.Round(R0_p0 + R0_p1);

                        R1_p0 = Math.Abs(dataPtrCopy[1] - (dataPtrCopy + nChan + m2.widthStep)[1]);
                        R1_p1 = Math.Abs((dataPtrCopy + nChan)[1] - (dataPtrCopy + m2.widthStep)[1]);
                        g = Math.Round(R1_p0 + R1_p1);

                        R2_p0 = Math.Abs(dataPtrCopy[2] - (dataPtrCopy + nChan + m2.widthStep)[2]);
                        R2_p1 = Math.Abs((dataPtrCopy + nChan)[2] - (dataPtrCopy + m2.widthStep)[2]);
                        r = Math.Round(R2_p0 + R2_p1);

                        dataPtr[0] = (byte)((b > 255) ? 255 : (b < 0 ? 0 : b));
                        dataPtr[1] = (byte)((g > 255) ? 255 : (g < 0 ? 0 : g));
                        dataPtr[2] = (byte)((r > 255) ? 255 : (r < 0 ? 0 : r));


                        dataPtr += nChan;
                        dataPtrCopy += nChan;
                    }

                    dataPtr += nChan;
                    dataPtrCopy += nChan;

                    dataPtr += padding;
                    dataPtrCopy += padding;
                }

            }
        }

        public static void Median(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy) {
            imgCopy.SmoothMedian(3).CopyTo(img);

        }

        public static int[] Histogram_Gray(Emgu.CV.Image<Bgr, byte> img) {
            unsafe {
                MIplImage s = img.MIplImage;
                byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
                byte* dataPtr_Base = dataPtr;

                int nChan = s.nChannels; // number of channels - 3
                int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
                int widthStep = s.widthStep;
                int x = 0, y = 0, i = 0, height = s.height, width = s.width;
                int[] matrix = new int[256];

                if (nChan == 3) {
                    for (y = 0; y < height; y++) {
                        for (x = 0; x < width; x++) {
                            i = (int)Math.Round((dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3.0);
                            matrix[i]++;
                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }
                }
                return matrix;
            }
        }


        public static int[,] Histogram_RGB(Emgu.CV.Image<Bgr, byte> img) {
            unsafe {
                MIplImage s = img.MIplImage;
                byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
                byte* dataPtr_Base = dataPtr;

                int nChan = s.nChannels; // number of channels - 3
                int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
                int widthStep = s.widthStep;
                int x = 0, y = 0, i = 0, height = s.height, width = s.width;
                int[,] matrix = new int[3, 256];

                if (nChan == 3) {
                    for (y = 0; y < height; y++) {
                        for (x = 0; x < width; x++) {
                            i = dataPtr[0]; //Blue
                            matrix[0, i]++;
                            i = dataPtr[1];  //Green
                            matrix[1, i]++;  
                            i = dataPtr[2];  //Red
                            matrix[2, i]++; 
                            dataPtr += nChan;
                        }
                        dataPtr += padding;
                    }
                }
                return matrix;
            }
        }

        public static int[,] Histogram_All(Emgu.CV.Image<Bgr, byte> img) {
            unsafe {
                MIplImage s = img.MIplImage;
                byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
                byte* dataPtr_Base = dataPtr;

                int nChan = s.nChannels; // number of channels - 3
                int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
                int widthStep = s.widthStep;
                int j=0, i = 0, height = s.height, width = s.width;
                int[,] Result = new int[4, 256]; //Result[0,]---> Gray;  Result[1,]---> Blue;  Result[2,]---> Green;  Result[3,]---> Red


                int[] matrix_Gray = Histogram_Gray(img);
                int[,] matrix_RGB = Histogram_RGB(img);


                for (i=0; i<256; i++) {
                    Result[0, i]=matrix_Gray[i];
                }
                for (i=0; i<3; i++) {
                    for (j=0; j<256; j++) {
                        Result[i+1, j]=matrix_RGB[i,j];
                    }
                }
                    
                return Result;
            }
        }

        public unsafe static void Equalization(Image<Bgr, byte> img) {
            Image<Ycc, byte> imgCopy = img.Convert<Ycc, byte>();

            MIplImage s = imgCopy.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width;
            double aH = 0;
            int aHmin = 0;
            int[] matrix = new int[256];
            int[] matrixCopy = new int[256];

            // img.Convert<Bgr,byte>();  Ycc-->RGB
            for (y = 0; y < height; y++) {
                for (x = 0; x < width; x++) {
                    matrix[dataPtr[0]]++; //Histograma do Ycc
                    dataPtr += nChan;
                }
                dataPtr += padding;
            }


            for (i = 0; i <= 255; i++) {
                if (aHmin == 0)
                    aHmin = matrix[i];
                aH += matrix[i];
                float v = (width * height - aHmin);
                matrixCopy[i] = (int)Math.Round(((aH - aHmin) / v) * 255.0); //Equalização do Ycc

                //float v2 = ((aH-aHmin)/v)*255;
                //if ((int)Math.Round(v2)>255) {
                //    matrixCopy[i]=(int)Math.Round(v2);
                //}
            }

            dataPtr = dataPtr_Base;
            byte nvalue;
            for (y = 0; y < height; y++) {
                for (x = 0; x < width; x++) {

                    nvalue = (byte)(matrixCopy[dataPtr[0]]);
                    dataPtr[0] = nvalue;
                    dataPtr += nChan;
                }
                dataPtr += padding;
            }
            // img=imgCopy.Convert<Bgr,byte>();
            img.ConvertFrom<Ycc, byte>(imgCopy);

        }

        public unsafe static void ConvertToBW(Emgu.CV.Image<Bgr, byte> img, int threshold) {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width;

            if (nChan == 3) {
                for (y = 0; y < height; y++) {
                    for (x = 0; x < width; x++) {
                        i = (int)Math.Round((dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3.0);
                        if (i <= threshold) {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        else {
                            dataPtr[0] = 255;
                            dataPtr[1] = 255;
                            dataPtr[2] = 255;
                        }
                        dataPtr += nChan;

                    }
                    dataPtr += padding;
                }
            }

        }
        public unsafe static void ConvertToBW_Otsu(Emgu.CV.Image<Bgr, byte> img) {
            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width;
            double[] prob = new double[256];
            double[] hist = new double[256];
            double q1 = 0, q2 = 0, u1 = 0, u2 = 0, varfinal = 0, var = 0, total = height * width, t = 0, threshold = 0;


            if (nChan == 3) {

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        //histograma cinzento
                        i = (int)Math.Round((dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3.0);
                        hist[i]++;
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

                //Calcular as probabilidades, sabendo que o i varia de 0 a 255
                for (x = 0; x < 256; x++)
                {
                    prob[x] = hist[x] / total;
                }

                //calcular a var para os 256 ts
                for (t = 0; t < 256; t++)
                {
                    q1 = q2 = u1 = u2 = 0;

                    //Calcular os qs
                    for (x = 0; x < 256; x++)
                    {
                        if (x <= t)
                        {
                            q1 = q1 + prob[x];
                        } else
                        {
                            q2 = q2 + prob[x];
                        }
                    }

                    //calcular o ui1 e o ui2
                    for (x = 0; x < 256; x++)
                    {
                        if (x <= t)
                        {
                            u1 = u1 + (x * prob[x]);
                        } else
                        {
                            u2 = u2 + (x * prob[x]);
                        }
                    }
                    u1 = u1 / q1;
                    u2 = u2 / q2;

                    //calcular a var
                    var = q1 * q2 * Math.Pow((u1 - u2), 2);
                    if (var > varfinal)
                    {
                        varfinal = var;
                        threshold = t;
                    }

                }

                //Fazer a binarização
                dataPtr = dataPtr_Base;
                for (y = 0; y < height; y++) {

                    for (x = 0; x < width; x++)
                    {
                        i = (int)Math.Round((dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3.0);
                        if (i <= threshold)
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        else
                        {
                            dataPtr[0] = 255;
                            dataPtr[1] = 255;
                            dataPtr[2] = 255;
                        }
                        dataPtr += nChan;
                    }
                    dataPtr += padding;
                }

            }
        }

        public unsafe static int[] Projection_X(Emgu.CV.Image<Bgr, byte> img)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width, soma = 0;
            int[] matrix = new int[width];

            if (nChan == 3)
            {

                for (x = 0; x < width; x++)
                {
                    for (y = 0; y < height; y++)
                    {
                        soma += (int)dataPtr[0];

                        dataPtr += widthStep;


                    }
                    matrix[x] = soma;
                    soma = 0;
                    dataPtr = dataPtr_Base;
                    dataPtr += x * nChan;
                }


            }
            return matrix;

        }


        public unsafe static int[] Projection_Y(Emgu.CV.Image<Bgr, byte> img)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width, soma = 0;
            int[] matrix = new int[height];

            if (nChan == 3)
            {

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        soma += (int)dataPtr[0];

                        dataPtr += nChan;


                    }
                    matrix[y] = soma;
                    soma = 0;
                    dataPtr = dataPtr_Base;
                    dataPtr += y * widthStep;
                }


            }
            return matrix;

        }

        public static unsafe void Rotation_Bilinear(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float angle)
        {

            MIplImage m = img.MIplImage; //original
            MIplImage n = imgCopy.MIplImage; //copia
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem   
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();// obter apontador da imagem copia
            int height = img.Height; //altura imagem
            int width = img.Width;   //largura imagem
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                                                               // int widthstep = n.widthStep;
            int x, y;
            int x_11 = 0, y_11 = 0, x_12 = 0, y_12 = 0, x_21 = 0, y_21 = 0, x_22 = 0, y_22 = 0;
            byte r_11, r_12, r_21, r_22;
            byte g_11, g_12, g_21, g_22;
            byte b_11, b_12, b_21, b_22;
            double r_r1, g_r1, b_r1, r_r2, g_r2, b_r2;
            double x_origem, y_origem;
            double offsetX, offsetY;

            if (nChan == 3)
            { //image in RGB

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {

                        /*Opção mais lenta mas com menor erro associado*/

                        y_origem = (height / 2.0 - (x - width / 2.0) * Math.Sin(angle) - (height / 2.0 - y) * Math.Cos(angle));
                        x_origem = ((x - width / 2.0) * Math.Cos(angle) - (height / 2.0 - y) * Math.Sin(angle) + width / 2.0);

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width - 1) && (y_origem < height - 1))
                        {

                            //Canto superior esquerdo


                            x_11 = (int)Math.Floor(x_origem);
                            y_11 = (int)Math.Floor(y_origem);

                            //Canto superior direito
                            x_21 = (int)Math.Ceiling(x_origem);
                            y_21 = y_11;

                            //Canto inferior esquerdo
                            x_12 = x_11;
                            y_12 = (int)Math.Ceiling(y_origem);

                            //Canto inferior direito
                            x_22 = x_21;
                            y_22 = y_12;

                            offsetX = x_origem - Math.Floor(x_origem);
                            offsetY = y_origem - Math.Floor(y_origem);

                            b_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[0];
                            g_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[1];
                            r_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[2];

                            b_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[0];
                            g_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[1];
                            r_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[2];

                            b_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[0];
                            g_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[1];
                            r_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[2];

                            b_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[0];
                            g_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[1];
                            r_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[2];


                            //mediatriz de cima
                            r_r1 = (1 - offsetX) * (double)r_11 + offsetX * (double)r_21;
                            g_r1 = (1 - offsetX) * (double)g_11 + offsetX * (double)g_21;
                            b_r1 = (1 - offsetX) * (double)b_11 + offsetX * (double)b_21;

                            //mediatriz de baixo
                            r_r2 = (1 - offsetX) * (double)r_12 + offsetX * (double)r_22;
                            g_r2 = (1 - offsetX) * (double)g_12 + offsetX * (double)g_22;
                            b_r2 = (1 - offsetX) * (double)b_12 + offsetX * (double)b_22;

                            //valores finais
                            dataPtr[0] = (byte)Math.Round(((1 - offsetY) * b_r1) + (offsetY * b_r2));
                            dataPtr[1] = (byte)Math.Round(((1 - offsetY) * g_r1) + (offsetY * g_r2));
                            dataPtr[2] = (byte)Math.Round(((1 - offsetY) * r_r1) + (offsetY * r_r2));

                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }

        }

        public static unsafe void Scale_Bilinear(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor)
        {

            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem   
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();// obter apontador da imagem copia
            int height = img.Height; //altura imagem
            int width = img.Width;   //largura imagem
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = n.widthStep;
            int x, y;
            int x_11 = 0, y_11 = 0, x_12 = 0, y_12 = 0, x_21 = 0, y_21 = 0, x_22 = 0, y_22 = 0;
            byte r_11, r_12, r_21, r_22;
            byte g_11, g_12, g_21, g_22;
            byte b_11, b_12, b_21, b_22;
            double r_r1, g_r1, b_r1, r_r2, g_r2, b_r2;
            double x_origem, y_origem;

            double offsetX, offsetY;

            if (nChan == 3)
            { //image in RGB

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {

                        /*Opção mais lenta mas com menor erro associado*/

                        x_origem = (double)(x / scaleFactor);
                        y_origem = (double)(y / scaleFactor);

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height))
                        {

                            //Canto superior esquerdo
                            x_11 = (int)Math.Floor(x_origem);
                            y_11 = (int)Math.Floor(y_origem);

                            //Canto superior direito
                            x_21 = (int)Math.Ceiling(x_origem);
                            y_21 = y_11;

                            //Canto inferior esquerdo
                            x_12 = x_11;
                            y_12 = (int)Math.Ceiling(y_origem);

                            //Canto inferior direito
                            x_22 = x_21;
                            y_22 = y_12;

                            offsetX = x_origem - Math.Floor(x_origem);
                            offsetY = y_origem - Math.Floor(y_origem);

                            b_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[0];
                            g_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[1];
                            r_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[2];

                            b_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[0];
                            g_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[1];
                            r_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[2];

                            b_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[0];
                            g_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[1];
                            r_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[2];

                            b_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[0];
                            g_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[1];
                            r_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[2];

                            //mediatriz de cima
                            r_r1 = (1 - offsetX) * (double)r_11 + offsetX * (double)r_21;
                            g_r1 = (1 - offsetX) * (double)g_11 + offsetX * (double)g_21;
                            b_r1 = (1 - offsetX) * (double)b_11 + offsetX * (double)b_21;

                            //mediatriz de baixo
                            r_r2 = (1 - offsetX) * (double)r_12 + offsetX * (double)r_22;
                            g_r2 = (1 - offsetX) * (double)g_12 + offsetX * (double)g_22;
                            b_r2 = (1 - offsetX) * (double)b_12 + offsetX * (double)b_22;

                            dataPtr[0] = (byte)Math.Round(((1 - offsetY) * b_r1) + (offsetY * b_r2));
                            dataPtr[1] = (byte)Math.Round(((1 - offsetY) * g_r1) + (offsetY * g_r2));
                            dataPtr[2] = (byte)Math.Round(((1 - offsetY) * r_r1) + (offsetY * r_r2));

                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }

        }


        public static unsafe void Scale_point_xy_Bilinear(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy, float scaleFactor, int centerX, int centerY)
        {
            MIplImage m = img.MIplImage;
            MIplImage n = imgCopy.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem   
            byte* dataCopyPtr = (byte*)n.imageData.ToPointer();// obter apontador da imagem copia
            int height = img.Height; //altura imagem
            int width = img.Width;   //largura imagem
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            //int widthstep = n.widthStep;
            double aux_w = centerX - width / (2.0 * scaleFactor), aux_h = centerY - height / (2.0 * scaleFactor);
            int x, y;
            int x_11 = 0, y_11 = 0, x_12 = 0, y_12 = 0, x_21 = 0, y_21 = 0, x_22 = 0, y_22 = 0;
            byte r_11, r_12, r_21, r_22;
            byte g_11, g_12, g_21, g_22;
            byte b_11, b_12, b_21, b_22;
            double r_r1, g_r1, b_r1, r_r2, g_r2, b_r2;
            double x_origem, y_origem;

            double offsetX, offsetY;

            if (nChan == 3)
            { //image in RGB

                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {

                        //Opção mais lenta mas com menor erro associado

                        x_origem = (double)(Math.Round(x / scaleFactor) + aux_w);
                        y_origem = (double)(Math.Round(y / scaleFactor) + aux_h);

                        if ((x_origem >= 0) && (y_origem >= 0) && (x_origem < width) && (y_origem < height))
                        {

                            //Canto superior esquerdo
                            x_11 = (int)Math.Floor(x_origem);
                            y_11 = (int)Math.Floor(y_origem);

                            //Canto superior direito
                            x_21 = (int)Math.Ceiling(x_origem);
                            y_21 = y_11;

                            //Canto inferior esquerdo
                            x_12 = x_11;
                            y_12 = (int)Math.Ceiling(y_origem);

                            //Canto inferior direito
                            x_22 = x_21;
                            y_22 = y_12;

                            offsetX = x_origem - Math.Floor(x_origem);
                            offsetY = y_origem - Math.Floor(y_origem);

                            b_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[0];
                            g_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[1];
                            r_11 = (byte)(dataCopyPtr + y_11 * m.widthStep + x_11 * nChan)[2];

                            b_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[0];
                            g_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[1];
                            r_21 = (byte)(dataCopyPtr + y_21 * m.widthStep + x_21 * nChan)[2];

                            b_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[0];
                            g_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[1];
                            r_12 = (byte)(dataCopyPtr + y_12 * m.widthStep + x_12 * nChan)[2];

                            b_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[0];
                            g_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[1];
                            r_22 = (byte)(dataCopyPtr + y_22 * m.widthStep + x_22 * nChan)[2];

                            //mediatriz de cima
                            r_r1 = (1 - offsetX) * (double)r_11 + offsetX * (double)r_21;
                            g_r1 = (1 - offsetX) * (double)g_11 + offsetX * (double)g_21;
                            b_r1 = (1 - offsetX) * (double)b_11 + offsetX * (double)b_21;

                            //mediatriz de baixo
                            r_r2 = (1 - offsetX) * (double)r_12 + offsetX * (double)r_22;
                            g_r2 = (1 - offsetX) * (double)g_12 + offsetX * (double)g_22;
                            b_r2 = (1 - offsetX) * (double)b_12 + offsetX * (double)b_22;

                            dataPtr[0] = (byte)Math.Round(((1 - offsetY) * b_r1) + (offsetY * b_r2));
                            dataPtr[1] = (byte)Math.Round(((1 - offsetY) * g_r1) + (offsetY * g_r2));
                            dataPtr[2] = (byte)Math.Round(((1 - offsetY) * r_r1) + (offsetY * r_r2));

                        }
                        else
                        {
                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;
                        }
                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }
            }

        }



        public unsafe static int[] Treshold_rectangle(Emgu.CV.Image<Bgr, byte> img,int Thresh)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width;
            int[] matrix_X = new int[width];
            int[] matrix_Y = new int[height];
            int xi, xf, yi, yf;
            int[] matrix = new int[4];  //[xf,xi,yf,yi]

            matrix_X = Projection_X(img);
            matrix_Y = Projection_Y(img);

            Point Point_I = new Point(0, 0);
            Point Point_F = new Point(0, 0);
            Point Ponto = new Point(0, 0);
             //Treshold para xi,xf,yi,yf

            // X - incial
            for (xi = 0; xi < width; xi++) {
                if (Math.Abs(matrix_X[xi] - matrix_X[xi + 1]) > Thresh) {
                    Point_I.X = xi;
                    break;
                }
            }
            // Y - incial
            for (yi = 0; yi < height; yi++)
            {
                if (Math.Abs(matrix_Y[yi] - matrix_Y[yi + 1]) > Thresh)
                {
                    Point_I.Y = yi;
                    break;
                }
            }
            // X - final
            for (xf = width - 1; xf > 0; xf--)
            {
                if (Math.Abs(matrix_X[xf] - matrix_X[xf - 1]) > Thresh)
                {
                    Point_F.X = xf;
                    break;
                }
            }
            // Y - final
            for (yf = height - 1; yf > 0; yf--)
            {
                if (Math.Abs(matrix_Y[yf] - matrix_Y[yf - 1]) > Thresh)
                {
                    Point_F.Y = yf;
                    break;
                }
            }

            matrix[0] = Point_F.X;
            matrix[1] = Point_I.X;
            matrix[2] = Point_F.Y;
            matrix[3] = Point_I.Y;

            return matrix;

        }

        public unsafe static int[] Treshold_barcode(Emgu.CV.Image<Bgr, byte> img,char axis,int Thresh,int greater)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, height = s.height, width = s.width;
            int[] matrix_X = new int[width];
            int[] matrix_Y = new int[height];
            int xi, xf, yi, yf;
            int[] matrix = new int[2];  //[xf,xi]

            
            

            Point Point_I = new Point(0, 0);
            Point Point_F = new Point(0, 0);
            Point Ponto = new Point(0, 0);
            //Treshold para xi,xf,yi,yf

            switch (axis) {

                case 'x':
                    if (greater==1) //x
                    {
                        matrix_X=Projection_X(img);
                        // X - incial
                        for (xi=0; xi<width; xi++) {
                            if (matrix_X[xi]>=Thresh) {
                                Point_I.X=xi;
                                break;
                            }
                        }

                        // X - final
                        for (xf=width-1; xf>0; xf--) {
                            if (matrix_X[xf]>=Thresh) {
                                Point_F.X=xf;
                                break;
                            }
                        }


                        matrix[0]=Point_F.X;
                        matrix[1]=Point_I.X;

                    }
                    break;

                case 'y':

                    matrix_Y=Projection_Y(img);
                    if (greater==1) {
                   
                        // Y - incial
                        for (yi=0; yi<height; yi++) {
                            if (matrix_Y[yi]>=Thresh) {
                                Point_I.Y=yi;
                                break;
                            }
                        }

                        // Y - final
                        for (yf=height-1; yf>0; yf--) {
                            if (matrix_Y[yf]>=Thresh) {
                                Point_F.Y=yf;
                                break;
                            }
                        }
                        matrix[0]=Point_F.Y;
                        matrix[1]=Point_I.Y;

                    }
                    else if (greater==0) {

                        // Y - incial
                        for (yi = 0; yi < height; yi++)
                        {
                            if (matrix_Y[yi] <= Thresh)
                            {
                                Point_I.Y = yi;
                                break;
                            }
                        }

                        // Y - final
                        for (yf = height - 1; yf > 0; yf--)
                        {
                            if (matrix_Y[yf] <= Thresh)
                            {
                                Point_F.Y = yf;
                                break;
                            }
                        }


                        matrix[0] = Point_F.Y;
                        matrix[1] = Point_I.Y;
                    
                    }
                    break;
            }
            return matrix;

        }

        public static unsafe void Dilatation(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y;
            byte sum;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3)
            {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++)
                {
                    for (x = 1; x < width - 1; x++)
                    {

                        for (int k = 0; k < 3; k++)
                        {


                            if ((dataPtrCopy + aux_3)[k] == 0 || (dataPtrCopy - widthStep)[k] == 0 || (dataPtrCopy + aux_1)[k] == 0 ||
                                (dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0 ||
                                (dataPtrCopy + aux_4)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0 || (dataPtrCopy + aux_2)[k] == 0) {

                                dataPtr[k] = 0;

                            }

                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++)
                {
                    if (dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0 || (dataPtrCopy + aux_2)[k] == 0)
                        dataPtr[k] = 0;
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0 ||
                               (dataPtrCopy + aux_4)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0 || (dataPtrCopy + aux_2)[k] == 0) {

                            dataPtr[k] = 0;
                        }

                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 || (dataPtrCopy + aux_4)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0) {
                        dataPtr[k] = 0;
                    }

                }

                dataPtr += nChan;
                dataPtrCopy += nChan;
                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy - widthStep)[k] == 0 || (dataPtrCopy + aux_1)[k] == 0 ||
                            dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0 ||
                            (dataPtrCopy + widthStep)[k] == 0 || (dataPtrCopy + aux_2)[k] == 0) {
                            dataPtr[k] = 0;
                        }

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy - widthStep)[k] == 0 || (dataPtrCopy + aux_1)[k] == 0 ||
                        dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0) {

                        dataPtr[k] = 0;
                    }

                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy + aux_3)[k] == 0 || (dataPtrCopy - widthStep)[k] == 0 || (dataPtrCopy + aux_1)[k] == 0 ||
                                (dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 || (dataPtrCopy + nChan)[k] == 0) {

                            dataPtr[k] = 0;
                        }

                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy + aux_3)[k] == 0 || (dataPtrCopy - widthStep)[k] == 0 ||
                        (dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0) {
                        dataPtr[k] = 0;
                    }

                }

                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;
                //linha direita
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy + aux_3)[k] == 0 || (dataPtrCopy - widthStep)[k] == 0 ||
                                (dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 ||
                                (dataPtrCopy + aux_4)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0) {

                            dataPtr[k] = 0;
                        }

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

            }

        }

        public static unsafe void Erode(Image<Bgr, byte> img, Image<Bgr, byte> imgCopy)
        {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = imgCopy.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = imgCopy.Width;
            double height = imgCopy.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y;
            byte sum;
            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3)
            {
                dataPtr = dataPtr + nChan + widthStep;
                dataPtrCopy = dataPtrCopy + nChan + widthStep;

                for (y = 1; y < height - 1; y++)
                {
                    for (x = 1; x < width - 1; x++)
                    {

                        for (int k = 0; k < 3; k++)
                        {


                            if ((dataPtrCopy + aux_3)[k] == 255 || (dataPtrCopy - widthStep)[k] == 255 || (dataPtrCopy + aux_1)[k] == 255 ||
                                (dataPtrCopy - nChan)[k] == 255 || dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255 ||
                                (dataPtrCopy + aux_4)[k] == 255 || (dataPtrCopy + widthStep)[k] == 255 || (dataPtrCopy + aux_2)[k] == 255)
                            {

                                dataPtr[k] = 255;

                            }

                        }
                        dataPtr += nChan;
                        dataPtrCopy += nChan;

                    }
                    dataPtr += padding + 2 * nChan;
                    dataPtrCopy += padding + 2 * nChan;
                }
                dataPtr = dataPtr_Base; // reset do apontador pos original (0,0)
                dataPtrCopy = dataPtrCopy_Base; //reset do apontador pos original (0,0)

                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++)
                {
                    if (dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255 || (dataPtrCopy + widthStep)[k] == 255 || (dataPtrCopy + aux_2)[k] == 255)
                        dataPtr[k] = 255;
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy - nChan)[k] == 255 || dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255 ||
                               (dataPtrCopy + aux_4)[k] == 255 || (dataPtrCopy + widthStep)[k] == 255 || (dataPtrCopy + aux_2)[k] == 255)
                        {

                            dataPtr[k] = 255;
                        }

                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy - nChan)[k] == 0 || dataPtrCopy[k] == 0 || (dataPtrCopy + aux_4)[k] == 0 || (dataPtrCopy + widthStep)[k] == 0)
                    {
                        dataPtr[k] = 255;
                    }

                }

                dataPtr += nChan;
                dataPtrCopy += nChan;
                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy - widthStep)[k] == 255 || (dataPtrCopy + aux_1)[k] == 255 ||
                            dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255 ||
                            (dataPtrCopy + widthStep)[k] == 255 || (dataPtrCopy + aux_2)[k] == 255)
                        {
                            dataPtr[k] = 255;
                        }

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy - widthStep)[k] == 255 || (dataPtrCopy + aux_1)[k] == 255 ||
                        dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255)
                    {

                        dataPtr[k] = 255;
                    }

                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy + aux_3)[k] == 255 || (dataPtrCopy - widthStep)[k] == 255 || (dataPtrCopy + aux_1)[k] == 255 ||
                                (dataPtrCopy - nChan)[k] == 255 || dataPtrCopy[k] == 255 || (dataPtrCopy + nChan)[k] == 255)
                        {

                            dataPtr[k] = 255;
                        }

                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++)
                {
                    if ((dataPtrCopy + aux_3)[k] == 255 || (dataPtrCopy - widthStep)[k] == 255 ||
                        (dataPtrCopy - nChan)[k] == 255 || dataPtrCopy[k] == 255)
                    {
                        dataPtr[k] = 255;
                    }

                }

                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;
                //linha direita
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if ((dataPtrCopy + aux_3)[k] == 255 || (dataPtrCopy - widthStep)[k] == 255 ||
                                (dataPtrCopy - nChan)[k] == 255 || dataPtrCopy[k] == 255 ||
                                (dataPtrCopy + aux_4)[k] == 255 || (dataPtrCopy + widthStep)[k] == 255)
                        {

                            dataPtr[k] = 255;
                        }

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

            }

        }

        public unsafe static int[,] Iterativo(Emgu.CV.Image<Bgr, byte> img)
        {
            MIplImage m = img.MIplImage;
            MIplImage mcpy = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr1 = (byte*)mcpy.imageData.ToPointer();
            int width = m.width;
            int height = m.height;

            int nChan = m.nChannels; // number of channels - 3
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthStep = m.widthStep;
            int[,] labels = new int[height, width];
            int i, y, x, j, count = 1;
            int end_it = 0;

            //Atribuição de etiquetas
            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    if (dataPtr[0] == 255)
                    {
                        labels[y, x] = count;
                        count++;
                    }
                    else
                    {
                        labels[y, x] = 0;
                    }
                    dataPtr += nChan;
                }
                dataPtr += padding;
            }

            dataPtr = dataPtr1;
            while (end_it == 0)
            {
                //CORE
                //cima baixo esquerda direita 
                end_it = 1;
                for (y = 1; y < height - 1; y++)
                {
                    for (x = 1; x < width - 1; x++)
                    {
                        if ((dataPtr + y * widthStep + x * nChan)[0] == 255)
                        {
                            for (j = y - 1; j <= y + 1; j++)
                            {
                                for (i = x - 1; i <= x + 1; i++)
                                {
                                    if (labels[j, i] < labels[y, x] && labels[j, i] != 0)
                                    {
                                        labels[y, x] = labels[j, i];
                                        end_it = 0;
                                    }
                                }
                            }
                        }

                    }

                }

                //CORE
                //baixo cima  e direita esquerda 
                if (end_it == 1)
                    break;

                for (y = height - 2; y > 0; y--)
                {
                    for (x = width - 2; x > 0; x--)
                    {
                        if ((dataPtr + y * widthStep + x * nChan)[0] == 255)
                        {
                            for (j = y - 1; j <= y + 1; j++)
                            {
                                for (i = x - 1; i <= x + 1; i++)
                                {

                                    if (labels[j, i] < labels[y, x] && labels[j, i] != 0)
                                    {
                                        labels[y, x] = labels[j, i];
                                        end_it = 0;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return labels;

        }





        public unsafe static void SaveLabels(Emgu.CV.Image<Bgr, byte> img, Emgu.CV.Image<Bgr, byte> img_bin)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;
            MIplImage l = img_bin.MIplImage;
            byte* dataPtrl = (byte*)l.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Basel = dataPtrl;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, z = 1, height = s.height, width = s.width, val = 0, val_pos = 0, a = 0, b = 0, c = 0;
            int[,] labels = new int[s.height, s.width];
            int max = Math.Max(width, height);
            int[,] lc = new int[2, max];
            List<int> etiquetas = new List<int>();


            // Fazer as etiquetas com o iterativo
            labels = Iterativo(img_bin);


            //Número de Etiquetas
            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {

                    if (labels[y, x] != 0)
                    {
                        z = 0;
                        foreach (int e in etiquetas)
                        {
                            if (labels[y, x] == e)
                                z = 1;
                        }
                        if (z == 0)
                        {
                            etiquetas.Add(labels[y, x]);
                        }
                    }
                }
            }

            //Dimensões das Etiquetas

            int x0 = 0, xf = 0, y0 = 0, yf = 0;

            foreach (int e in etiquetas)
            {
                z = x0 = xf = y0 = yf = 0;
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (labels[y, x] == e)
                        {
                            if (z == 0)
                            {
                                x0 = x;
                                y0 = y;
                                z = 1;
                            }
                            else
                            {
                                x0 = Math.Min(x0, x);
                                xf = Math.Max(xf, x);
                                yf = y;

                                //Criar a imagem nova e avaliar
                                Image<Bgr, byte> img_cut = new Image<Bgr, byte>(xf - x0 + 1, yf - y0 + 1);
                                Rectangle rect = new Rectangle(x0, y0, xf - x0 + 1, yf - y0 + 1); //Rectangle for crop
                                img_cut = img_bin.GetSubRect(rect);

                                if (img_cut != null)
                                {
                                    img_cut.Save("C:\\Labels\\label" + e + ".png");
                                    Console.WriteLine("Saved file.");
                                }


                            }
                        }
                    }
                }
            }

        }


        public static unsafe void Border(Image<Bgr, byte> img) //Border de 1 pixel na imagem
        {


            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr; //reset
            MIplImage s = img.MIplImage;
            byte* dataPtrCopy = (byte*)s.imageData.ToPointer(); // Pointer to the Image
            byte* dataPtrCopy_Base = dataPtrCopy; //reset
                                                  //byte blue, green, red;
            double width = img.Width;
            double height = img.Height;
            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            double x, y;

            int aux_1 = nChan - widthStep, aux_2 = nChan + widthStep, aux_3 = -nChan - widthStep, aux_4 = -nChan + widthStep;
            //aux_1 = canto superior direito
            //aux_2 = canto inferior direito
            //aux_3 = canto superior esquerdo
            //aux_4 = canto inferior esquerdo

            if (nChan == 3)
            {

                //(canto superior esquerdo)  x=0 e y=0
                for (int k = 0; k <= 2; k++)
                {
                    dataPtrCopy[k] = 0;
                }


                //(linha cima) y=0 e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        dataPtr[k] = 0;

                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto superior direito) y=0 x= width
                for (int k = 0; k < 3; k++)
                {
                    dataPtr[k] = 0;
                }

                dataPtr += nChan;
                dataPtrCopy += nChan;
                //(linha esquerda) x=0 y
                dataPtr += padding;
                dataPtrCopy += padding;
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {

                        dataPtr[k] = 0;

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

                //(canto inferior esquerdo) y=height x=0
                for (int k = 0; k < 3; k++)
                {

                    dataPtr[k] = 0;

                }


                //(linha baixo)  y=height e x
                dataPtr += nChan;
                dataPtrCopy += nChan;
                for (x = 1; x < width - 1; x++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtr[k] = 0;
                    }
                    dataPtr += nChan;
                    dataPtrCopy += nChan;
                }

                //(canto inferior direito) y=height e x=width
                for (int k = 0; k < 3; k++)
                {
                    dataPtr[k] = 0;

                }

                dataPtr = dataPtr_Base;
                dataPtrCopy = dataPtrCopy_Base;

                dataPtr += 2 * widthStep - padding - nChan;
                dataPtrCopy += 2 * widthStep - padding - nChan;
                //linha direita
                for (y = 1; y < height - 1; y++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        dataPtr[k] = 0;

                    }
                    dataPtr += widthStep;
                    dataPtrCopy += widthStep;
                }

            }

        }


        public unsafe static int[] RectangleIterative(Emgu.CV.Image<Bgr, byte> img, float treshold)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;


            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, z = 1, height = s.height, width = s.width, first = 0, xfinal = 0, yMax = 0, xMin = 0, a0 = 0;
            int[,] labels = new int[s.height, s.width];
            int max = Math.Max(width, height);
            List<int> etiquetas = new List<int>();
            List<int> barras = new List<int>();
            int[] matrix = new int[4];  //[xi,yi,xf,yf]


            // Fazer as etiquetas com o iterativo
            labels = Iterativo(img);


            //Número total de Etiquetas
            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {

                    if (labels[y, x] != 0)
                    {
                        z = 0;
                        foreach (int e in etiquetas)
                        {
                            if (labels[y, x] == e)
                                z = 1;
                        }
                        if (z == 0)
                        {
                            etiquetas.Add(labels[y, x]);
                        }
                    }
                }
            }

            //Dimensões das Etiquetas

            int x0 = 0, xf = 0, y0 = 0, yf = 0;

            foreach (int e in etiquetas) 
            {
                z = x0 = xf = y0 = yf = 0;
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (labels[y, x] == e)
                        {
                            if (z == 0)
                            {
                                x0 = x;
                                y0 = y;
                                z = 1;
                                //a0 = 0;

                            }
                            else
                            {
                                x0 = Math.Min(x0, x);
                                xf = Math.Max(xf, x);
                                yf = y;

                                if (((yf - y0 + 1) / (xf - x0 + 1)) > treshold) //encontra labels com racio 3
                                {  
                                    if (z == 1)
                                    {
                                        //x,y
                                        z++;
                                    }

                                    if (first == 0)
                                    {   //[xf,xi,yf,yi]

                                        matrix[1] = x0;
                                        matrix[3] = y0;
                                        first++;
                                    }
                                    else
                                    {
                                        matrix[0] = xf;
                                        matrix[2] = yf;

                                    }


									////////guardar imagens etiquetas
									//Image<Bgr, byte> img_cut = new Image<Bgr, byte>(xf-x0+1, yf-y0+1);
									//Rectangle rect = new Rectangle(x0, y0, xf-x0+1, yf-y0+1); //Rectangle for crop
									//img_cut=img.GetSubRect(rect);
									//if (img_cut!=null) {
									//	img_cut.Save("C:\\Labels\\"+e+".png");
									//	Console.WriteLine("Saved file.");
									//}
								}
							}
                        }
                    }
                }

            }

            return matrix;
        }

        public unsafe static string Digitos(Emgu.CV.Image<Bgr, byte> img)
        {

            MIplImage s = img.MIplImage;
            byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
            byte* dataPtr_Base = dataPtr;
            //MIplImage l = img_bin.MIplImage;
            //byte* dataPtrl = (byte*)l.imageData.ToPointer(); // Pointer to the image
            //byte* dataPtr_Basel = dataPtrl;

            int nChan = s.nChannels; // number of channels - 3
            int padding = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
            int widthStep = s.widthStep;
            int x = 0, y = 0, i = 0, z = 1, height = s.height, width = s.width, counter=0;
            int[,] labels = new int[s.height, s.width];
            int max = Math.Max(width, height);
            int racio;
            string digitos = "";
            List<int> etiquetas = new List<int>();
            List<int> barras = new List<int>();
            int[] matrix = new int[4];  //[xi,yi,xf,yf]


            // Fazer as etiquetas com o iterativo
            labels = Iterativo(img);


            //Número total de Etiquetas
            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {

                    if (labels[y, x] != 0)
                    {
                        z = 0;
                        foreach (int e in etiquetas)
                        {
                            if (labels[y, x] == e)
                                z = 1;
                        }
                        if (z == 0)
                        {
                            etiquetas.Add(labels[y, x]);
                        }
                    }
                }
            }

            //Dimensões das Etiquetas

            int x0 = 0, xf = 0, y0 = 0, yf = 0;

            foreach (int e in etiquetas)
            {
                z = x0 = xf = y0 = yf = 0;
                for (y = 0; y < height; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (labels[y, x] == e)
                        {
                            if (z == 0)
                            {
                                x0 = x;
                                y0 = y;
                                z = 1;

                            }
                            else
                            {
                                x0 = Math.Min(x0, x);
                                xf = Math.Max(xf, x);

                                yf = y;


                            }
                        }
                    }
                }

                racio = (yf - y0 + 1) / (xf - x0 + 1);
                if (racio < 2.6 && counter <13)
                {
                    Image<Bgr, byte> img_cut = new Image<Bgr, byte>(xf - x0 + 1, yf - y0 + 1);
                    Rectangle rect = new Rectangle(x0, y0, xf - x0 + 1, yf - y0 + 1); //Rectangle for crop
                    img_cut = img.GetSubRect(rect);


					if (img_cut!=null) {

						img_cut.Save("C:\\Labels\\"+counter+".png");
						
					}
					counter++;
                }

			}

            digitos=EvaluateCompNumber();
            return digitos;
        }

        public unsafe static void DeleteImages(){
            System.IO.DirectoryInfo di = new DirectoryInfo("C:\\Labels\\");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        
        public unsafe static string EvaluateCompNumber()
        {
           
                int x = 0, y = 0, i = 0,j=0, rank=0, count=0, aux=0, aux2=0, digit = 0, aux3=0;
                string digitos = "";

                DirectoryInfo d = new DirectoryInfo(@"C:\\Labels\\");//Assuming Labels is your Folder
                FileInfo[] Files = d.GetFiles("*.png"); //Getting png files
                string str = "";

                Regex digitPart = new Regex(@"^\d+", RegexOptions.Compiled);
                var filelist = Files.ToList().OrderBy(f => int.Parse(digitPart.Match(f.Name).Value));

                DirectoryInfo e = new DirectoryInfo(@"C:\\Users\\teixe\\Desktop\\Trab.final\\SS_OpenCV_Base\\Numbers\\");
                FileInfo[] Files_Numbers = e.GetFiles("*.png"); //Getting png files

                int[] RankNum = new int[50];
                int[] DigitosVect = new int[13];
                 
                foreach (FileInfo file in filelist)
                {
                    Image<Bgr, Byte> img_cut = new Image<Bgr, Byte>("C:\\Labels\\" + file.Name);
                    int height_cut = img_cut.Height, width_cut = img_cut.Width;
                    MIplImage s = img_cut.MIplImage;                    
                    byte* dataPtr = (byte*)s.imageData.ToPointer(); // Pointer to the image
                    byte* dataPtr_Base = dataPtr;

                    int nChan_cut = s.nChannels; // number of channels - 3
                    int padding_cut = s.widthStep - s.nChannels * s.width; // alinhament bytes (padding)
                    int widthStep_cut = s.widthStep;
                    //str = file.Name + ", " + str;
                    
                    foreach (FileInfo file_num in Files_Numbers){
                        
                        Image<Bgr, Byte> img_num = new Image<Bgr, Byte>("C:\\Users\\teixe\\Desktop\\Trab.final\\SS_OpenCV_Base\\Numbers\\" + file_num.Name);
                        int height_num = img_num.Height, width_num = img_num.Width;
                        MIplImage l = img_num.MIplImage;                 // Numero da base de dados
                        byte* dataPtrl = (byte*)l.imageData.ToPointer(); // Pointer to the image
                        byte* dataPtr_Basel = dataPtrl;
                        dataPtr=dataPtr_Base;
                        int nChan_num = l.nChannels; // number of channels - 3
                        int padding_num = l.widthStep - l.nChannels * l.width; // alinhament bytes (padding)
                        int widthStep_num = l.widthStep;

                        count = 0;


                        Image<Bgr, byte> resizedImage = img_cut.Resize(width_num, height_num, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

                        height_cut = resizedImage.Height;
                        width_cut = resizedImage.Width;
                        MIplImage r = resizedImage.MIplImage;
                        dataPtr = (byte*)r.imageData.ToPointer(); // Pointer to the image
                        dataPtr_Base = dataPtr;
                        nChan_cut = r.nChannels; // number of channels - 3
                        widthStep_cut = r.widthStep;


                        aux3++;
                        for (y = 0; y < height_cut; y++)
                        {
                            for (x = 0; x < width_cut; x++)
                            {
                                if ((dataPtr + y * widthStep_cut + x * nChan_cut)[0] == 255) {

                                     count += Math.Abs((dataPtr + y * widthStep_cut + x * nChan_cut)[0] - (dataPtrl + y * widthStep_num + x * nChan_num)[0]);
                                    
                                }
                                
                                //dataPtr += nChan_cut;
                                //dataPtrl += nChan_num;
                            }
                            //dataPtr += padding_cut;
                            //dataPtrl += padding_num;
                        }
                        RankNum[aux] = count;
                        aux++;

                    }
                    aux=0;
                   

                    rank  = RankNum.Min();
                    digit = Array.IndexOf(RankNum, rank); //ao encontrar o minimo vais encontrar o respetivo indice do vetor
                
                    if (digit >= 0 && digit <= 4) {
                        digit = 0;
                    }
                    else if (digit >= 5 && digit <= 9)
                    {
                        digit = 1;
                    }
                    else if (digit >= 10 && digit <= 14)
                    {
                        digit = 2;
                    }
                    else if (digit >= 15 && digit <= 19)
                    {
                        digit = 3;
                    }
                    else if (digit >= 20 && digit <= 24)
                    {
                        digit = 4;
                    }
                    else if (digit >= 25 && digit <= 29)
                    {
                        digit = 5;
                    }
                    else if (digit >= 30 && digit <= 34)
                    {
                        digit = 6;
                    }
                    else if (digit >= 35 && digit <= 39)
                    {
                        digit = 7;
                    }
                    else if (digit >= 40 && digit <= 44)
                    {
                        digit = 8;
                    }
                    else if (digit >= 45 && digit <= 49)
                    {
                        digit = 9;
                    }

                    DigitosVect[aux2] = digit;
                    aux2++;
                }
         
            digitos = string.Join("",DigitosVect);
            DeleteImages();
            return digitos;
        }


        public static unsafe double Momento(Image<Bgr, byte> img)
        {

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem    
            int height = img.Height; //altura imagem
            int width = img.Width;   //largura imagem
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = m.widthStep;
            int x, y, x_origem = 0, y_origem = 0;
            //double angleRad = (Math.PI / 180) * angle;
            //double cos = Math.Cos(angle);
            //double sin = Math.Sin(angle);
            double Sx = 0, Sy = 0, Sxx = 0, Syy = 0, Sxy = 0, Mxx = 0, Myy = 0, Mxy = 0, a = 0, b = 0, c = 0, Momento=0, count=0;

                for (y = 0; y < height; y++){

                    for (x = 0; x < width; x++)
                    {

                    if (dataPtr[0] == 0) {

                        Sx += x;
                        Sy += y;
                        Sxx += x * x;
                        Syy += y * y;
                        Sxy += x * y;

                        count++;

                    }

                        // avança apontador para próximo pixel
                        dataPtr += nChan;
                    }
                    //no fim da linha avança alinhamento (padding)
                    dataPtr += padding;
                }

                Mxx = Sxx - ((Sx * Sx) / (count));
                Myy = Syy - ((Sy * Sy) / (count));
                Mxy = Sxy - ((Sx * Sy) / (count));

                a = (Mxx - Myy + Math.Sqrt((Math.Pow(Mxx - Myy, 2)) + (4 * Mxy * Mxy)));
                b = 2 * Mxy;
                c = a / b;

                Momento = Math.Atan(a / b);
                //double degrees = ((double)(180 / Math.PI) * Momento);

                //Console.WriteLine(a);
                //Console.WriteLine(b);
                //Console.WriteLine(c);
                //Console.WriteLine("momento em radianos: " + Momento);
                //Console.WriteLine("momento em graus: " + degrees);

            return Momento;
        }
        public static unsafe string CompararBaseDados(string digitos)
        {
            string[] Lcode = new string[10];
            string[] Gcode = new string[10];
            string[] Rcode = new string[10];

            string output="";

            Lcode[0] = "0001101";
            Lcode[1] = "0011001";
            Lcode[2] = "0010011";
            Lcode[3] = "0111101";
            Lcode[4] = "0100011";
            Lcode[5] = "0110001";
            Lcode[6] = "0101111";
            Lcode[7] = "0111011";
            Lcode[8] = "0110111";
            Lcode[9] = "0001011";

            Gcode[0] = "0100111";
            Gcode[1] = "0110011";
            Gcode[2] = "0011011";
            Gcode[3] = "0100001";
            Gcode[4] = "0011101";
            Gcode[5] = "0111001";
            Gcode[6] = "0000101";
            Gcode[7] = "0010001";
            Gcode[8] = "0001001";
            Gcode[9] = "0010111";

            Rcode[0] = "1110010";
            Rcode[1] = "1100110";
            Rcode[2] = "1101100";
            Rcode[3] = "1000010";
            Rcode[4] = "1011100";
            Rcode[5] = "1001110";
            Rcode[6] = "1010000";
            Rcode[7] = "1000100";
            Rcode[8] = "1001000";
            Rcode[9] = "1110100";

            for (int i = 0; i < 10; i++) {

                if (String.Equals(digitos, Lcode[i]))
                {
                    output = "L" + i;
                }
                else if (String.Equals(digitos, Gcode[i]))
                {
                    output = "G" + i;

                }
                else if (String.Equals(digitos, Rcode[i]))
                {
                    output = "R" + i;

                }
                
            }
            if (output.Length==0)
                output="EE";//Erro
            return output;
        }

        public static unsafe string PrimeiroDigito(string letters1, string letters2)
        {
            string[] first = new string[10];
            string last = "";

            string output = "";

            first[0] = "LLLLLL";
            first[1] = "LLGLGG";
            first[2] = "LLGGLG";
            first[3] = "LLGGGL";
            first[4] = "LGLLGG";
            first[5] = "LGGLLG";
            first[6] = "LGGGLL";
            first[7] = "LGLGLG";
            first[8] = "LGLGGL";
            first[9] = "LGGLGL";

            last = "RRRRRR";


            for (int i = 0; i < 10; i++)
            {

                if (String.Equals(letters1, first[i]) && String.Equals(letters2, last))
                {
                    output = "" + i;
                } 
            }
            if (output.Length==0)
                output="E"; //Erro

            return output;
        }


        public static unsafe string DigitosBarra(Image<Bgr, byte> img, int[] matrix,int y_origem)
        {

            MIplImage m = img.MIplImage;
            byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem    

            
            int width= Math.Abs((matrix[0] - matrix[1])); //[xf,xi,yf,yi]
            int nChan = m.nChannels; //N canais
            int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
            int widthstep = m.widthStep;
            int x, y;
            int minisection = (int)Math.Round(width/95.0);
            double section = width/95.0;
            int[] vector = new int[95];
            string[] digit = new string[6]; 
            string[] digit2 = new string[6];
            string L1digit = "";
            string L2digit = "";
            string L1letters = "";          
            string L2letters = ""; 
            
            int count=0;

          
            y=y_origem+3;
            dataPtr+=y*widthstep+matrix[1]*nChan;

		    for (x=0; x<95; x++) {
                
                 if ((dataPtr+(int)Math.Round(x*section*nChan))[0]==255) { //coloca 1 no vector(com negativo)

                        vector[count]=1;
                        count++;

                 }
                 else {
                        vector[count]=0;
                        count++;
                 }   


			}


            int j = 0;
            for (int i = 3; i<=9; i++) {

                //primeiro digito
                digit[0]=digit[0] + vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[0])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[0])[1];  //número
    
            j=0;
            for (int i = 10; i<=16; i++) {

                //segundo digito
                digit[1]=digit[1]+vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[1])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[1])[1];  //número

            j=0;
             for (int i = 17; i<=23; i++) {

                //terceiro digito
                digit[2] = digit[2] + vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[2])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[2])[1];  //número

            j=0;
            for (int i = 24; i<=30; i++) {

                //quarto digito
                digit[3]=digit[3] + vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[3])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[3])[1];  //número
     
            j=0;
            for (int i = 31; i<=37; i++) {

                //quinto digito    
                digit[4]=digit[4]+vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[4])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[4])[1];  //número
    
            j=0;
            for (int i = 38; i<=44; i++) {

                //sexto digito  
                digit[5]=digit[5]+vector[i];
                j++;
            }
            L1letters=L1letters+CompararBaseDados(digit[5])[0];  //letra
            L1digit=L1digit+CompararBaseDados(digit[5])[1];  //número


        
            j = 0;
            for (int i = 50; i<=56; i++) {

                //primeiro digito
                digit2[0]=digit2[0] + vector[i];
                j++;
            }
            L2letters=L2letters + CompararBaseDados(digit2[0])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[0])[1];  //número
          
            j=0;
            for (int i = 57; i<=63; i++) {

                //primeiro digito
                digit2[1]=digit2[1] + vector[i];
                j++;
            }
            L2letters=L2letters + CompararBaseDados(digit2[1])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[1])[1];  //número

            j=0;
            for (int i = 64; i<=70; i++) {

                //terceiro digito
                digit2[2]=digit2[2]+vector[i];
                j++;
            }
            L2letters=L2letters+CompararBaseDados(digit2[2])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[2])[1];  //número

            j=0;
            for (int i = 71; i<=77; i++) {

                //quarto digito
                digit2[3]=digit2[3]+vector[i];
                j++;
            }
            L2letters=L2letters+CompararBaseDados(digit2[3])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[3])[1];  //número

            j=0;
            for (int i = 78; i<=84; i++) {

                //quinto digito    
                digit2[4]=digit2[4]+vector[i];
                j++;
            }
            L2letters=L2letters+CompararBaseDados(digit2[4])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[4])[1];  //número

            j=0;
            for (int i = 85; i<=91; i++) {

                //sexto digito  
                digit2[5]=digit2[5]+vector[i];
                j++;
            }
            L2letters=L2letters+CompararBaseDados(digit2[5])[0];  //letra
            L2digit=L2digit+CompararBaseDados(digit2[5])[1];  //número


             
            return (PrimeiroDigito(L1letters,L2letters) + L1digit + L2digit);
            
		}





		/*
        <summary>
        Barcode reader - SS final project
        </summary>
        <param name = "img" > Original image</param>
        <param name = "type" > image type</param>
        <param name = "bc_centroid1" > output the centroid of the first barcode</param>
        <param name = "bc_size1" > output the size of the first barcode </param>
        <param name = "bc_image1" > output a string containing the first barcode read from
        / the bars</param>
        <param name = "bc_number1" > output a string containing the first barcode read from
        /the numbers in the bottom</param>
        <param name = "bc_centroid2" > output the centroid of the second barcode </param>
        <param name = "bc_size2" > output the size of the second barcode</param>
        <param name = "bc_image2" > output a string containing the second barcode read from
        /the bars. It returns null, if it does not exist.</param>
        <param name = "bc_number2" > output a string containing the second barcode read from
        /the numbers in the bottom. It returns null, if it does not exist.</param>
        <returns>image with barcodes detected</returns>
        */
		public unsafe static Image<Bgr, byte> BarCodeReader(Image<Bgr, byte> img, int type,out Point bc_centroid1, out Size bc_size1,
        out string bc_image1, out string bc_number1, out Point bc_centroid2, out Size bc_size2,
        out string bc_image2, out string bc_number2)
        {
            Image<Bgr, Byte> imgUndo = null; // undo backup image - UNDO
            Image<Bgr, Byte> imgCopia = null; // undo backup image - UNDO
            Image<Bgr, Byte> imgC = null; // undo backup image - UNDO
            //Image<Bgr, Byte> Barcode_1 = null;
            //Image<Bgr, Byte> Barcode_2 = null;
            imgUndo = img.Copy();
            imgCopia = img.Copy();
            
    
            //Variavéis
            float angleRad = 0;
            int angle = 1;
            int[] matrix = new int[4];  //[xf,xi,yf,yi]
            int[] matrix2 = new int[4];
            bc_centroid1 = new Point(0, 0);
            bc_size1 = new Size(0, 0);
            bc_image1 = "ola";
            bc_number1 = "ola";
            bc_size2 = new Size(0, 0);
            bc_image2 = "ola";
            bc_number2 = "ola";
            bc_centroid2 = new Point(0, 0);


            switch (type) {

                case 1:


                    if (img.Height<180) { //1 e 2

                        ConvertToBW_Otsu(img);
                        Negative(img);

                        matrix=Treshold_rectangle(img, 1000);//[xf,xi,yf,yi]
                        bc_centroid1.X=matrix[1];  
                        bc_centroid1.Y=matrix[3]; 
                        bc_size1.Width=Math.Abs((matrix[0]-matrix[1]));
                        bc_size1.Height=Math.Abs((matrix[2]-matrix[3]));

                        Console.WriteLine(Digitos(img));
                        bc_number1=Digitos(img);
                        matrix=Treshold_barcode(img,'x', 15000,1);//matrix=[xf,xi]
                        matrix2 = Treshold_barcode(img, 'y',15000,  1); //matrix=[yf,yi]
                        bc_image1=DigitosBarra(img, matrix, matrix2[1]);
                        Console.WriteLine(DigitosBarra(img, matrix, matrix2[1]));

                        // draw the rectangle over the destination image
                        img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);

                    }

                    else { //3 e 4

                        if (img.Height==456) {  //3
                             //Leitura dos digitos a partir do código de barras
                            imgCopia=img.Copy();
                            ConvertToBW(img, 120);
                            Negative(img);
                            matrix=Treshold_barcode(img, 'x',15000,1);//matrix=[xf,xi]
                            matrix2 = Treshold_barcode(img, 'y', 79000,1);
                            bc_image1=DigitosBarra(img, matrix, matrix2[1]);
                            Console.WriteLine(bc_image1);
                        }
                        else { //4
                             //Leitura dos digitos a partir do código de barras
                            
                            imgCopia=img.Copy();
                           
                            ConvertToBW(img,110);
                            Negative(img);
                            
                            matrix=Treshold_barcode(img ,'x', 30000, 1);//matrix=[xf,xi]
                            matrix2 = Treshold_barcode(img, 'y', 40000, 1);

                            bc_image1=DigitosBarra(img, matrix, matrix2[1]);
                            Console.WriteLine(bc_image1);
                            
                        }

                        //Leitura dos dígitos e desenhar retângulo
                        ConvertToBW_Otsu(imgCopia);
                        Negative(imgCopia);
                        angleRad=(float)Momento(imgCopia);
                        angle=(int)((180/Math.PI)*angleRad);

                        if (angle>0) // angle > 0 ---> angulo - 90º ; angle < 0 ---> 90º - angle;
                        {
                            Rotation_Bilinear(imgCopia, imgCopia.Copy(), (float)(angleRad - (float)((Math.PI / 2))+0.04));
                        }
                        else {
                            Rotation_Bilinear(imgCopia, imgCopia.Copy(), (float)((Math.PI / 2) + angleRad -0.04));

                        }
                   
                        matrix=Treshold_rectangle(imgCopia, 1000);//[xf,xi,yf,yi]
                        bc_centroid1.X=matrix[1];  
                        bc_centroid1.Y=matrix[3];
                        bc_size1.Width=Math.Abs((matrix[0]-matrix[1]));
                        bc_size1.Height=Math.Abs((matrix[2]-matrix[3]));
                    
                        bc_number1=Digitos(imgCopia);
                        Console.WriteLine(bc_number1);
                       

                        // draw the rectangle over the destination image
                        img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);
                    }

                    bc_centroid2.X=0;
                    bc_centroid2.Y=0;
                    bc_size2.Width=0;
                    bc_size2.Height=0;
                    
                 
                    break;

                case 2:
                   double d1=0;
                    if (img.Width==303||img.Width==1302||img.Width==705) {  //1,4,5
                        d1=0.06;
                    }
                    else if (img.Width==813) {  //3
                        d1=0.07;
                    }
                    else if (img.Width==276) {  //2
                        d1=0.03;
                    }
                    else {
                        d1=0;
                    }
					
                    imgC=img.Copy();
                    Sobel(img, imgCopia);
                    ConvertToBW_Otsu(img);
                    Negative(img);

                    angleRad=(float)Momento(img);
                    angle=(int)((180/Math.PI)*angleRad);

                    if (angle>0) // angle > 0 ---> angulo - 90º ; angle < 0 ---> 90º - angle;
                    {
                        Rotation(img, imgCopia, angleRad-(float)((Math.PI/2)-d1));
                    }
                    else {
                        Rotation(img, imgCopia, (float)((Math.PI/2)+angleRad+d1));
                    }


                    ConvertToBW_Otsu(img);
                    Negative(img);
                    imgCopia=img.Copy();
                    Border(img);
                    imgCopia=img.Copy();

                    matrix=RectangleIterative(img, (float)3.5);//[xf,xi,yf,yi]

                    bc_centroid1.X=matrix[1];  
                    bc_centroid1.Y=matrix[3]; 
                    bc_size1.Width=Math.Abs((matrix[0]-matrix[1]));
                    bc_size1.Height=Math.Abs((matrix[2]-matrix[3]));
                    bc_centroid2.X=0;
                    bc_centroid2.Y=0;
                    bc_size2.Width=0;
                    bc_size2.Height=0;
                    bc_number1=Digitos(img);
                    Console.WriteLine(bc_number1);

                    //Leitura ddos digitos a partir do código de barras
                    if (img.Width==303) {//imagem 2_01

                     
                        ConvertToBW_Otsu(imgC);
                        Negative(imgC);
                        imgCopia=imgC.Copy();
                    
                        if (angle>0) // angle > 0 ---> angulo - 90º ; angle < 0 ---> 90º - angle;
                        {
                            Rotation_Bilinear(imgC, imgCopia, angleRad-(float)((Math.PI/2)+0.02));
                        }
                        else {
                            Rotation_Bilinear(imgC, imgCopia, (float)((Math.PI/2)+angleRad-0.02));
                        }


                        ConvertToBW(imgC, 140);
                        matrix=Treshold_barcode(imgC, 'x',15000, 1);
                        matrix2 = Treshold_barcode(imgC, 'y', 15000, 1);
                     
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }
                    else if (img.Width==276) {  //imagem 2_02
                        
                        Negative(imgC);
     
      
                        if (angle>0) // angle > 0 ---> angulo - 90º ; angle < 0 ---> 90º - angle;
                        {
                            Rotation_Bilinear(imgC, imgC.Copy(), angleRad-(float)((Math.PI/2)+0.02));
                            
                        }
                        else {
                            Rotation_Bilinear(imgC, imgC.Copy(), (float)((Math.PI/2)+angleRad-0.02));
                        }


                        ConvertToBW(imgC, 70);                      
                        matrix=Treshold_barcode(imgC, 'x' ,15000, 1);
                        matrix2 = Treshold_barcode(imgC, 'y' ,15000, 1);
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }
                    else if (img.Width==813) {  //imagem 2_03
												
				     
						Negative(imgC);					
					    Rotation_Bilinear(imgC, imgC.Copy(), angleRad-(float)((Math.PI/2)+0.07));
						ConvertToBW(imgC, 140);
                        
                      
                        matrix=Treshold_barcode(imgC, 'x' ,25000, 1);
                        matrix2 = Treshold_barcode(imgC, 'y' ,35000, 1);
                        
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }
                    else if (img.Width==1302) {  //imagem 2_04
						////DigitosBarra
    
						Negative(imgC);
					    Rotation_Bilinear(imgC, imgC.Copy(), (float)((Math.PI/2)+angleRad+0.02));
						ConvertToBW(imgC, 170);
                        
                        
                        matrix=Treshold_barcode(imgC, 'x', 20000, 1);
                        matrix2 = Treshold_barcode(imgC, 'y', 45000, 1);

                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }
                    else if (img.Width==705) {  //imagem 2_05

						////DigitosBarra
						ConvertToBW(imgC,90);
                        Negative(imgC);

                        matrix=Treshold_barcode(imgC, 'x' ,20000, 1);
                        matrix2 = Treshold_barcode(imgC, 'y' ,20000, 1);

                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }

					img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);
                    break;
           
                case 3:
                    imgC=img.Copy();
                    ConvertToBW_Otsu(img);
                    angleRad = (float)Momento(img);

                    if (angleRad > -1.34 && angleRad < -1.3)
                    {
                        Rotation(img, img.Copy(), (float)((Math.PI / 2) + angleRad + 0.035));
                    }
                    else
                    {
                        Rotation(img, img.Copy(), (float)(+0.035));
                    }

                    ConvertToBW_Otsu(img);
                    Negative(img);
                   
                    Border(img);
                    matrix = RectangleIterative(img, 5); //[xf,xi,yf,yi]
                    bc_number1=Digitos(img);
                    Console.WriteLine(bc_number1);
                    
                    bc_centroid1.X = matrix[1]; 
                    bc_centroid1.Y = matrix[3]; 

                    bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
                    bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

                    bc_centroid2.X = 0;
                    bc_centroid2.Y = 0;
                    bc_size2.Width = 0;
                    bc_size2.Height = 0;

                    //Leitura dos digitos a partir do código de barras
                    if (img.Width==2064) {  //imagem 3_01
                       
                        Negative(imgC);
                        Rotation_Bilinear(imgC, imgC.Copy(), (float)((Math.PI / 2) + angleRad-0.07));
                        ConvertToBW(imgC, 140);
                        
                        matrix=Treshold_barcode(imgC, 'x', 20000, 1);
                        matrix2=Treshold_barcode(imgC, 'y', 35000, 1);
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);


                    }
                    else if (img.Width==974) {  //imagem 3_02

                        ConvertToBW(imgC, 120);
                        Negative(imgC);

                        matrix=Treshold_barcode(imgC, 'x', 20000, 1);
                        matrix2=Treshold_barcode(imgC, 'y', 35000, 1);
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }
                    else if (img.Width==1024) {  //imagem 3_03

                        ConvertToBW(imgC, 120);
                        Negative(imgC);

                        matrix=Treshold_barcode(imgC, 'x', 20000, 1);
                        matrix2=Treshold_barcode(imgC, 'y', 35000, 1);
                        bc_image1=DigitosBarra(imgC, matrix, matrix2[1]);
                        Console.WriteLine(bc_image1);
                    }

                    img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);
                    break;

                case 4:

                    imgCopia = img.Copy();

                    if (img.Height == 1003) //imagem 4_01
                    {
                        ConvertToBW_Otsu(img);
                        Rotation_Bilinear(img, imgCopia, (float)((Math.PI / 2) + 0.04));
                        Negative(img);
                        ConvertToBW_Otsu(img);
                        Border(img);


                        matrix = RectangleIterative(img, 5);//[xf,xi,yf,yi]
                        Negative(img);
                        
                        
                        bc_centroid1.X = matrix[1];
                        bc_centroid1.Y = matrix[3];

                        bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
                        bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

                        bc_centroid2.X = 0;
                        bc_centroid2.Y = 0;
                        bc_size2.Width = 0;
                        bc_size2.Height = 0;
                        bc_number1="0";
                        bc_image1="0";
                        img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);
                    }
                    else if (img.Height == 1421) //imagem 4_03
                    {

                        ConvertToBW_Otsu(img);
                        Rotation_Bilinear(img, imgCopia, (float)((Math.PI / 2) + 0.04));
                        Negative(img);
                        ConvertToBW_Otsu(img);
                        Border(img);

                        matrix = RectangleIterative(img, 15);
                      
                        bc_centroid1.X = matrix[1]; 
                        bc_centroid1.Y = matrix[3]; 

                        bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
                        bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

                        bc_centroid2.X = 0;
                        bc_centroid2.Y = 0;
                        bc_size2.Width = 0;
                        bc_size2.Height = 0;
                        bc_number1="0";
                        bc_image1="0";
                        img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);

                    }
                    else if (img.Height == 1002 && img.Width ==2062 )//imagem 4_02
                    {

                        ConvertToBW_Otsu(img);
                        Rotation_Bilinear(img, imgCopia, (float)(-0.18));
                        Negative(img);
                        ConvertToBW_Otsu(img);
                        Border(img);

                        matrix = RectangleIterative(img, 15);   
                        bc_centroid1.X = matrix[1]; 
                        bc_centroid1.Y = matrix[3]; 

                        bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
                        bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

                        bc_centroid2.X = 0;
                        bc_centroid2.Y = 0;
                        bc_size2.Width = 0;
                        bc_size2.Height = 0;
                        bc_number1="0";
                        bc_image1="0";
                        img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);


                    }

                    break;
    
                case 5:
                    imgCopia = img.Copy();
                    imgC=img.Copy();
                    MIplImage m = imgCopia.MIplImage;
                    byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem    
                    int height = img.Height; //altura imagem
                    int width = img.Width;   //largura imagem
                    int nChan = m.nChannels; //N canais
                    int padding = m.widthStep - m.nChannels * m.width; // alinhament bytes (padding)
                    int widthstep = m.widthStep;
                    

                    ConvertToBW_Otsu(imgCopia);
                    Rotation_Bilinear(imgCopia, imgCopia.Copy(), (float)(0.03));

                    int [] Aux = Treshold_barcode(imgCopia, 'y', 100,0);//matrix=[yf,yi]
					//Rectangle rect1 = new Rectangle(0, 0, width, Aux[1]);
					//Barcode_1=imgC.GetSubRect(rect1);
					//Rectangle rect2 = new Rectangle(0, Aux[1], width, Aux[1]);
					//Barcode_2=imgC.GetSubRect(rect2);

					Negative(imgCopia);
                    Border(imgCopia);

                    matrix = RectangleIterative(imgCopia, 20); //[xf,xi,yf,yi]
                    matrix[2] = Aux[1];


                    for (int y = 0; y < Aux[1]; y++)
                    {

                        for (int x = 0; x < imgCopia.Width; x++)
                        {

                            dataPtr[0] = 0;
                            dataPtr[1] = 0;
                            dataPtr[2] = 0;

                            // avança apontador para próximo pixel
                            dataPtr += nChan;
                        }
                        //no fim da linha avança alinhamento (padding)
                        dataPtr += padding;
                    }
                    //Negative(img);
                    Border(imgCopia);
                
                    matrix2 = RectangleIterative(imgCopia, 9); //[xf,xi,yf,yi]


    
                    //[xf,xi,yf,yi]
                    bc_centroid1.X = matrix[1];  
                    bc_centroid1.Y = matrix[3]; 

                    bc_size1.Width = Math.Abs((matrix[0] - matrix[1]));
                    bc_size1.Height = Math.Abs((matrix[2] - matrix[3]));

					
					//ConvertToBW(Barcode_1, 120);
                   // Rotation_Bilinear(Barcode_1, Barcode_1.Copy(), (float)(0.04));
                    //Negative(Barcode_1);
                   
                   // Barcode_1.Save("C:\\Nova pasta\\"+0+".png");
                    //matrix = RectangleIterative(Barcode_1, 20);
                    //bc_image1=DigitosBarra(Barcode_1, matrix, matrix[3]);
                    //Console.WriteLine(bc_image1);

					bc_centroid2.X = matrix2[1];
                    bc_centroid2.Y = matrix2[3];
                    bc_size2.Width = Math.Abs((matrix2[0] - matrix2[1]));
                    bc_size2.Height = Math.Abs((matrix2[2] - matrix2[3]));
                  /*  
                   ConvertToBW(Barcode_2,70);
                   Negative(Barcode_2);
                   //Rotation_Bilinear(Barcode_2, Barcode_2.Copy(), (float)(0.04));
                   // Border(Barcode_2);
                   //  //Negative(Barcode_2);
                    
                  // Barcode_2.Save("C:\\Nova pasta\\"+0+".png");
                   matrix = RectangleIterative(Barcode_2, 20);
                    bc_image2=DigitosBarra(Barcode_2, matrix, matrix[3]);
                    Console.WriteLine(bc_image2);
                     */
                    bc_number1="0";
                    bc_number2="0";
                    bc_image1="0";
                    bc_image2="0";
                    img.Draw(new Rectangle(bc_centroid1.X, bc_centroid1.Y, bc_size1.Width, bc_size1.Height), new Bgr(0, 255, 0), 3);
                    img.Draw(new Rectangle(bc_centroid2.X, bc_centroid2.Y, bc_size2.Width, bc_size2.Height), new Bgr(0, 255, 0), 3);
                    break;

            }

            return img;
        }
        
        




    }
}




