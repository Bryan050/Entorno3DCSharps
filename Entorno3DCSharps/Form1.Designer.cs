
namespace Entorno3DCSharps
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.btnWireFrame = new System.Windows.Forms.Button();
            this.btnTextura = new System.Windows.Forms.Button();
            this.picCanvasColor = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvasColor)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.InfoText;
            this.picCanvas.Location = new System.Drawing.Point(282, 25);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(572, 470);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(86, 166);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(75, 23);
            this.btnDibujar.TabIndex = 1;
            this.btnDibujar.Text = "Dibujar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // trackBarScale
            // 
            this.trackBarScale.Location = new System.Drawing.Point(42, 336);
            this.trackBarScale.Minimum = 1;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(186, 45);
            this.trackBarScale.TabIndex = 3;
            this.trackBarScale.Value = 1;
            this.trackBarScale.Scroll += new System.EventHandler(this.trackBarScale_Scroll_1);
            // 
            // btnWireFrame
            // 
            this.btnWireFrame.Location = new System.Drawing.Point(42, 376);
            this.btnWireFrame.Name = "btnWireFrame";
            this.btnWireFrame.Size = new System.Drawing.Size(75, 23);
            this.btnWireFrame.TabIndex = 4;
            this.btnWireFrame.Text = "Wireframe";
            this.btnWireFrame.UseVisualStyleBackColor = true;
            this.btnWireFrame.Click += new System.EventHandler(this.btnWireFrame_Click);
            // 
            // btnTextura
            // 
            this.btnTextura.Location = new System.Drawing.Point(42, 414);
            this.btnTextura.Name = "btnTextura";
            this.btnTextura.Size = new System.Drawing.Size(75, 23);
            this.btnTextura.TabIndex = 5;
            this.btnTextura.Text = "Textura";
            this.btnTextura.UseVisualStyleBackColor = true;
            this.btnTextura.Click += new System.EventHandler(this.btnTextura_Click);
            // 
            // picCanvasColor
            // 
            this.picCanvasColor.BackColor = System.Drawing.Color.Yellow;
            this.picCanvasColor.Location = new System.Drawing.Point(42, 456);
            this.picCanvasColor.Name = "picCanvasColor";
            this.picCanvasColor.Size = new System.Drawing.Size(100, 50);
            this.picCanvasColor.TabIndex = 6;
            this.picCanvasColor.TabStop = false;
            this.picCanvasColor.Click += new System.EventHandler(this.picCanvasColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "x";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(61, 77);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 9;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(61, 103);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "y";
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(61, 129);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(100, 20);
            this.txtZ.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "z";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 522);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvasColor);
            this.Controls.Add(this.btnTextura);
            this.Controls.Add(this.btnWireFrame);
            this.Controls.Add(this.trackBarScale);
            this.Controls.Add(this.btnDibujar);
            this.Controls.Add(this.picCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvasColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Button btnWireFrame;
        private System.Windows.Forms.Button btnTextura;
        private System.Windows.Forms.PictureBox picCanvasColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Label label4;
    }
}

