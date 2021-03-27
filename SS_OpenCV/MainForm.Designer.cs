namespace SS_OpenCV
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blueChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.greenChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.brightnessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.transformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rotationBilinearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomBilinearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomXYBilinearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.momentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.meanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nonUniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.diferenciaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.robertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.border1pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramGreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectionYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binarizaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.oTSUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.drawRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iterativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.erodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.digitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.digitosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.digitosBarraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.barcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ImageViewer = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Images (*.png, *.bmp, *.jpg)|*.png;*.bmp;*.jpg";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.barcodeToolStripMenuItem,
            this.autoresToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(578, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save As...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.transformsToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.autoZoomToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.binarizaçãoToolStripMenuItem,
            this.oTSUToolStripMenuItem,
            this.drawRectangleToolStripMenuItem,
            this.iterativoToolStripMenuItem,
            this.erodeToolStripMenuItem,
            this.erodeToolStripMenuItem1,
            this.digitsToolStripMenuItem,
            this.digitosToolStripMenuItem,
            this.digitosBarraToolStripMenuItem});
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
			this.imageToolStripMenuItem.Text = "Image Processing";
			// 
			// colorToolStripMenuItem
			// 
			this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negativeToolStripMenuItem,
            this.grayToolStripMenuItem,
            this.redChannelToolStripMenuItem,
            this.blueChannelToolStripMenuItem,
            this.greenChannelToolStripMenuItem,
            this.brightnessToolStripMenuItem1});
			this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
			this.colorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.colorToolStripMenuItem.Text = "Color";
			// 
			// negativeToolStripMenuItem
			// 
			this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
			this.negativeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.negativeToolStripMenuItem.Text = "Negative";
			this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negativeToolStripMenuItem_Click);
			// 
			// grayToolStripMenuItem
			// 
			this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
			this.grayToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.grayToolStripMenuItem.Text = "Gray";
			this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
			// 
			// redChannelToolStripMenuItem
			// 
			this.redChannelToolStripMenuItem.Name = "redChannelToolStripMenuItem";
			this.redChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.redChannelToolStripMenuItem.Text = "Red Channel";
			this.redChannelToolStripMenuItem.Click += new System.EventHandler(this.redChannelToolStripMenuItem_Click);
			// 
			// blueChannelToolStripMenuItem
			// 
			this.blueChannelToolStripMenuItem.Name = "blueChannelToolStripMenuItem";
			this.blueChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.blueChannelToolStripMenuItem.Text = "Blue Channel";
			this.blueChannelToolStripMenuItem.Click += new System.EventHandler(this.blueChannelToolStripMenuItem_Click);
			// 
			// greenChannelToolStripMenuItem
			// 
			this.greenChannelToolStripMenuItem.Name = "greenChannelToolStripMenuItem";
			this.greenChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.greenChannelToolStripMenuItem.Text = "Green Channel";
			this.greenChannelToolStripMenuItem.Click += new System.EventHandler(this.greenChannelToolStripMenuItem_Click);
			// 
			// brightnessToolStripMenuItem1
			// 
			this.brightnessToolStripMenuItem1.Name = "brightnessToolStripMenuItem1";
			this.brightnessToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.brightnessToolStripMenuItem1.Text = "Brightness";
			this.brightnessToolStripMenuItem1.Click += new System.EventHandler(this.brightnessToolStripMenuItem1_Click);
			// 
			// transformsToolStripMenuItem
			// 
			this.transformsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.rotationBilinearToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.zoomXYToolStripMenuItem,
            this.zoomBilinearToolStripMenuItem,
            this.zoomXYBilinearToolStripMenuItem,
            this.momentoToolStripMenuItem});
			this.transformsToolStripMenuItem.Name = "transformsToolStripMenuItem";
			this.transformsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.transformsToolStripMenuItem.Text = "Transforms";
			// 
			// translationToolStripMenuItem
			// 
			this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
			this.translationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.translationToolStripMenuItem.Text = "Translation";
			this.translationToolStripMenuItem.Click += new System.EventHandler(this.translationToolStripMenuItem_Click);
			// 
			// rotationToolStripMenuItem
			// 
			this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
			this.rotationToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.rotationToolStripMenuItem.Text = "Rotation";
			this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
			// 
			// rotationBilinearToolStripMenuItem
			// 
			this.rotationBilinearToolStripMenuItem.Name = "rotationBilinearToolStripMenuItem";
			this.rotationBilinearToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.rotationBilinearToolStripMenuItem.Text = "Rotation Bilinear";
			this.rotationBilinearToolStripMenuItem.Click += new System.EventHandler(this.rotationBilinearToolStripMenuItem_Click);
			// 
			// zoomToolStripMenuItem
			// 
			this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
			this.zoomToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.zoomToolStripMenuItem.Text = "Zoom";
			this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
			// 
			// zoomXYToolStripMenuItem
			// 
			this.zoomXYToolStripMenuItem.Name = "zoomXYToolStripMenuItem";
			this.zoomXYToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.zoomXYToolStripMenuItem.Text = "Zoom_XY";
			this.zoomXYToolStripMenuItem.Click += new System.EventHandler(this.zoomXYToolStripMenuItem_Click);
			// 
			// zoomBilinearToolStripMenuItem
			// 
			this.zoomBilinearToolStripMenuItem.Name = "zoomBilinearToolStripMenuItem";
			this.zoomBilinearToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.zoomBilinearToolStripMenuItem.Text = "Zoom Bilinear";
			this.zoomBilinearToolStripMenuItem.Click += new System.EventHandler(this.zoomBilinearToolStripMenuItem_Click);
			// 
			// zoomXYBilinearToolStripMenuItem
			// 
			this.zoomXYBilinearToolStripMenuItem.Name = "zoomXYBilinearToolStripMenuItem";
			this.zoomXYBilinearToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.zoomXYBilinearToolStripMenuItem.Text = "Zoom_XY_Bilinear";
			this.zoomXYBilinearToolStripMenuItem.Click += new System.EventHandler(this.zoomXYBilinearToolStripMenuItem_Click);
			// 
			// momentoToolStripMenuItem
			// 
			this.momentoToolStripMenuItem.Name = "momentoToolStripMenuItem";
			this.momentoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.momentoToolStripMenuItem.Text = "Momento";
			this.momentoToolStripMenuItem.Click += new System.EventHandler(this.momentoToolStripMenuItem_Click);
			// 
			// filtersToolStripMenuItem
			// 
			this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanToolStripMenuItem,
            this.nonUniformToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.diferenciaçãoToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.robertsToolStripMenuItem,
            this.border1pxToolStripMenuItem});
			this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
			this.filtersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.filtersToolStripMenuItem.Text = "Filters";
			// 
			// meanToolStripMenuItem
			// 
			this.meanToolStripMenuItem.Name = "meanToolStripMenuItem";
			this.meanToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.meanToolStripMenuItem.Text = "Mean";
			this.meanToolStripMenuItem.Click += new System.EventHandler(this.meanToolStripMenuItem_Click);
			// 
			// nonUniformToolStripMenuItem
			// 
			this.nonUniformToolStripMenuItem.Name = "nonUniformToolStripMenuItem";
			this.nonUniformToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.nonUniformToolStripMenuItem.Text = "NonUniform";
			this.nonUniformToolStripMenuItem.Click += new System.EventHandler(this.nonUniformToolStripMenuItem_Click);
			// 
			// sobelToolStripMenuItem
			// 
			this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
			this.sobelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.sobelToolStripMenuItem.Text = "Sobel";
			this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
			// 
			// diferenciaçãoToolStripMenuItem
			// 
			this.diferenciaçãoToolStripMenuItem.Name = "diferenciaçãoToolStripMenuItem";
			this.diferenciaçãoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.diferenciaçãoToolStripMenuItem.Text = "Diferentiation";
			this.diferenciaçãoToolStripMenuItem.Click += new System.EventHandler(this.diferenciaçãoToolStripMenuItem_Click);
			// 
			// medianToolStripMenuItem
			// 
			this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
			this.medianToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.medianToolStripMenuItem.Text = "Median";
			this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
			// 
			// robertsToolStripMenuItem
			// 
			this.robertsToolStripMenuItem.Name = "robertsToolStripMenuItem";
			this.robertsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.robertsToolStripMenuItem.Text = "Roberts";
			this.robertsToolStripMenuItem.Click += new System.EventHandler(this.robertsToolStripMenuItem_Click);
			// 
			// border1pxToolStripMenuItem
			// 
			this.border1pxToolStripMenuItem.Name = "border1pxToolStripMenuItem";
			this.border1pxToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.border1pxToolStripMenuItem.Text = "Border 1px";
			this.border1pxToolStripMenuItem.Click += new System.EventHandler(this.border1pxToolStripMenuItem_Click);
			// 
			// autoZoomToolStripMenuItem
			// 
			this.autoZoomToolStripMenuItem.CheckOnClick = true;
			this.autoZoomToolStripMenuItem.Name = "autoZoomToolStripMenuItem";
			this.autoZoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.autoZoomToolStripMenuItem.Text = "Auto Zoom";
			this.autoZoomToolStripMenuItem.Click += new System.EventHandler(this.autoZoomToolStripMenuItem_Click);
			// 
			// histogramToolStripMenuItem
			// 
			this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramGreyToolStripMenuItem,
            this.histogramRGBToolStripMenuItem,
            this.histogramAllToolStripMenuItem,
            this.contagemToolStripMenuItem,
            this.projectionYToolStripMenuItem});
			this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
			this.histogramToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.histogramToolStripMenuItem.Text = "Histogram";
			this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
			// 
			// histogramGreyToolStripMenuItem
			// 
			this.histogramGreyToolStripMenuItem.Name = "histogramGreyToolStripMenuItem";
			this.histogramGreyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.histogramGreyToolStripMenuItem.Text = "Histogram Gray";
			this.histogramGreyToolStripMenuItem.Click += new System.EventHandler(this.histogramGreyToolStripMenuItem_Click);
			// 
			// histogramRGBToolStripMenuItem
			// 
			this.histogramRGBToolStripMenuItem.Name = "histogramRGBToolStripMenuItem";
			this.histogramRGBToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.histogramRGBToolStripMenuItem.Text = "Histogram RGB";
			this.histogramRGBToolStripMenuItem.Click += new System.EventHandler(this.histogramRGBToolStripMenuItem_Click);
			// 
			// histogramAllToolStripMenuItem
			// 
			this.histogramAllToolStripMenuItem.Name = "histogramAllToolStripMenuItem";
			this.histogramAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.histogramAllToolStripMenuItem.Text = "Histogram All";
			this.histogramAllToolStripMenuItem.Click += new System.EventHandler(this.histogramAllToolStripMenuItem_Click);
			// 
			// contagemToolStripMenuItem
			// 
			this.contagemToolStripMenuItem.Name = "contagemToolStripMenuItem";
			this.contagemToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.contagemToolStripMenuItem.Text = "Projection_X";
			this.contagemToolStripMenuItem.Click += new System.EventHandler(this.contagemToolStripMenuItem_Click);
			// 
			// projectionYToolStripMenuItem
			// 
			this.projectionYToolStripMenuItem.Name = "projectionYToolStripMenuItem";
			this.projectionYToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.projectionYToolStripMenuItem.Text = "Projection_Y";
			this.projectionYToolStripMenuItem.Click += new System.EventHandler(this.projectionYToolStripMenuItem_Click);
			// 
			// binarizaçãoToolStripMenuItem
			// 
			this.binarizaçãoToolStripMenuItem.Name = "binarizaçãoToolStripMenuItem";
			this.binarizaçãoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.binarizaçãoToolStripMenuItem.Text = "Binarization";
			this.binarizaçãoToolStripMenuItem.Click += new System.EventHandler(this.binarizaçãoToolStripMenuItem_Click);
			// 
			// oTSUToolStripMenuItem
			// 
			this.oTSUToolStripMenuItem.Name = "oTSUToolStripMenuItem";
			this.oTSUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.oTSUToolStripMenuItem.Text = "OTSU";
			this.oTSUToolStripMenuItem.Click += new System.EventHandler(this.oTSUToolStripMenuItem_Click);
			// 
			// drawRectangleToolStripMenuItem
			// 
			this.drawRectangleToolStripMenuItem.Name = "drawRectangleToolStripMenuItem";
			this.drawRectangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.drawRectangleToolStripMenuItem.Text = "Draw Rectangle";
			this.drawRectangleToolStripMenuItem.Click += new System.EventHandler(this.drawRectangleToolStripMenuItem_Click);
			// 
			// iterativoToolStripMenuItem
			// 
			this.iterativoToolStripMenuItem.Name = "iterativoToolStripMenuItem";
			this.iterativoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.iterativoToolStripMenuItem.Text = "Iterativo";
			this.iterativoToolStripMenuItem.Click += new System.EventHandler(this.iterativoToolStripMenuItem_Click);
			// 
			// erodeToolStripMenuItem
			// 
			this.erodeToolStripMenuItem.Name = "erodeToolStripMenuItem";
			this.erodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.erodeToolStripMenuItem.Text = "Dilatation";
			this.erodeToolStripMenuItem.Click += new System.EventHandler(this.erodeToolStripMenuItem_Click);
			// 
			// erodeToolStripMenuItem1
			// 
			this.erodeToolStripMenuItem1.Name = "erodeToolStripMenuItem1";
			this.erodeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.erodeToolStripMenuItem1.Text = "Erode";
			this.erodeToolStripMenuItem1.Click += new System.EventHandler(this.erodeToolStripMenuItem1_Click);
			// 
			// digitsToolStripMenuItem
			// 
			this.digitsToolStripMenuItem.Name = "digitsToolStripMenuItem";
			this.digitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.digitsToolStripMenuItem.Text = "Rectangle Iterative";
			this.digitsToolStripMenuItem.Click += new System.EventHandler(this.digitsToolStripMenuItem_Click);
			// 
			// digitosToolStripMenuItem
			// 
			this.digitosToolStripMenuItem.Name = "digitosToolStripMenuItem";
			this.digitosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.digitosToolStripMenuItem.Text = "Digitos";
			this.digitosToolStripMenuItem.Click += new System.EventHandler(this.digitosToolStripMenuItem_Click);
			// 
			// digitosBarraToolStripMenuItem
			// 
			this.digitosBarraToolStripMenuItem.Name = "digitosBarraToolStripMenuItem";
			this.digitosBarraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.digitosBarraToolStripMenuItem.Text = "DigitosBarra";
			this.digitosBarraToolStripMenuItem.Click += new System.EventHandler(this.digitosBarraToolStripMenuItem_Click);
			// 
			// autoresToolStripMenuItem
			// 
			this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
			this.autoresToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.autoresToolStripMenuItem.Text = "Authors";
			this.autoresToolStripMenuItem.Click += new System.EventHandler(this.autoresToolStripMenuItem_Click);
			// 
			// barcodeToolStripMenuItem
			// 
			this.barcodeToolStripMenuItem.Name = "barcodeToolStripMenuItem";
			this.barcodeToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
			this.barcodeToolStripMenuItem.Text = "Barcode Reader";
			this.barcodeToolStripMenuItem.Click += new System.EventHandler(this.barcodeToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.ImageViewer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(578, 330);
			this.panel1.TabIndex = 6;
			// 
			// ImageViewer
			// 
			this.ImageViewer.Location = new System.Drawing.Point(0, 0);
			this.ImageViewer.Name = "ImageViewer";
			this.ImageViewer.Size = new System.Drawing.Size(576, 427);
			this.ImageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImageViewer.TabIndex = 6;
			this.ImageViewer.TabStop = false;
			this.ImageViewer.Click += new System.EventHandler(this.ImageViewer_Click);
			this.ImageViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageViewer_MouseClick_1);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(578, 354);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Sistemas Sensoriais 2020/2021 - Image processing";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoZoomToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImageViewer;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonUniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarizaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oTSUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem diferenciaçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iterativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem digitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem momentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationBilinearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomBilinearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomXYBilinearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem border1pxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem digitosBarraToolStripMenuItem;
	}
}

