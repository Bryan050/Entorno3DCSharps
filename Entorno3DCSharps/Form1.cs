using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Entorno3DCSharps
{
    public partial class Form1 : Form
    {
        bool isWireFrame = false;
        bool isSolid = false;
        Color color = new Color();
        Figuras.Tubo objTubo = new Figuras.Tubo();
        
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            float x=0, y=0, z=0;
            if (!String.IsNullOrEmpty(txtX.Text))
            {
                x = float.Parse(txtX.Text);
            }
            if (!String.IsNullOrEmpty(txtX.Text))
            {
                y = float.Parse(txtY.Text);
            }
            if (!String.IsNullOrEmpty(txtZ.Text))
            {
                z = float.Parse(txtZ.Text);
            }

            isWireFrame = false;
            isSolid = true;
            picCanvas.Refresh();


            
            int r = picCanvasColor.BackColor.R;
            int g = picCanvasColor.BackColor.G;
            int b = picCanvasColor.BackColor.B;
            //MessageBox.Show(picCanvasColor.BackColor.ToString());
            objTubo.setColor(Color.FromArgb(r,g,b));
            objTubo.setSpecular(true);
            objTubo.CalcularNormal();
            objTubo.altura = 1;
            objTubo.InicializarVertices();
            objTubo.TralateFigure(new Point3D(x, y, z));
            objTubo.eyeAndScreen();
            objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
        }

        private void trackBarScale_Scroll_1(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            objTubo.setSpecular(true);
            objTubo.CalcularNormal();
            objTubo.Scale(trackBarScale.Value);
            objTubo.eyeAndScreen();
            objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
        }

        private void btnWireFrame_Click(object sender, EventArgs e)
        {
            isWireFrame = true;
            picCanvas.Refresh();
            //objTubo.InicializarVertices();
            objTubo.setSpecular(true);
            objTubo.CalcularNormal();
            objTubo.eyeAndScreen();
            objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
        }

        private void btnTextura_Click(object sender, EventArgs e)
        {
            isWireFrame = false;
            isSolid = false;
            picCanvas.Refresh();
            objTubo.InicializarVertices();
            objTubo.setSpecular(true);
            objTubo.CalcularNormal();
            objTubo.altura = 1;
            objTubo.eyeAndScreen();
            objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
        }

        private void picCanvasColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog()==DialogResult.OK)
            {
                picCanvasColor.BackColor = colorPicker.Color;
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Presionaste: "+e.KeyData);
            char key = e.KeyData.ToString().ToCharArray()[0];
            switch (key)
            {
                case 'w':
                case 'W':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureY(3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 's':
                case 'S':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureY(-3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'd':
                case 'D':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureX(3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'a':
                case 'A':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureX(-3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'q':
                case 'Q':
                    
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureZ(3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'e':
                case 'E':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 0));
                    objTubo.RotateFigureZ(-3);
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'i':
                case 'I':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(-1, 0, 0));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'k':
                case 'K':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(1, 0, 0));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'l':
                case 'L':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 1, 0));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'j':
                case 'J':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, -1, 0));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'u':
                case 'U':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, 1));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
                case 'o':
                case 'O':
                    picCanvas.Refresh();
                    objTubo.TralateFigure(new Point3D(0, 0, -1));
                    objTubo.setSpecular(true);
                    objTubo.CalcularNormal();
                    objTubo.eyeAndScreen();
                    objTubo.DrawFigure(picCanvas, isWireFrame, isSolid);
                    break;
            }

        }
    }
}
