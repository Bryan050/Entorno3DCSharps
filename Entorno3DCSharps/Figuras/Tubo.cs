using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Entorno3DCSharps.Figuras;

namespace Entorno3DCSharps.Figuras
{
    class Tubo : Figura
    {
        private float radioMayor;
        private float radioMenor;
        public float altura;
        private Pen mPenFill;
        int numIteraciones = 0;
        int numIteracionesZ = -1;
        private List<PointF> vertices;
        List<PointF> poligonos;
        string nombreImagen;
        string imgPath;
        Bitmap imgTextura;
        int contador = 0;
        double xL = -1 / Math.Sqrt(3);
        double yL = 1 / Math.Sqrt(3);
        double zL = 1 / Math.Sqrt(3);
        double zV = 0;
        List<Color> colorS;
        public Tubo()
        {
            this.radioMayor = 2;
            this.radioMenor = 1.5f;
            vertices = new List<PointF>();
            poligonos = new List<PointF>();
            nombreImagen = "multicolor.jpg";
            imgPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Entorno3DCSharps" + @"\Textura\" + nombreImagen;
            imgTextura = new Bitmap(@imgPath, true);
            colorS = new List<Color>();
        }

        public void InicializarVertices()
        {
            vertex.Clear();
            numIteracionesZ = -1;
            float x, y, z;
            for (float h = 0; h <= altura; h +=1f)
            {
                numIteraciones = 0;
                for (float a = 0; a <= 2 * Math.PI + 0.1; a += 0.1f)
                {
                    x = radioMenor * (float)Math.Cos(a) * scale;
                    y = radioMenor * (float)Math.Sin(a) * scale;
                    z = h * scale;
                    vertex.Add(new Point3D(x, y, z));

                    x = radioMayor * (float)Math.Cos(a) * scale;
                    y = radioMayor * (float)Math.Sin(a) * scale;
                    z = h * scale;
                    vertex.Add(new Point3D(x, y, z));
                    numIteraciones++;
                }
                numIteracionesZ++;
            }

        }
        public override void DrawFigure(PictureBox picCanvas, bool isWireFrame, bool isSolid)
        {
            //picCanvas.BackColor = Color.Black;
            base.DrawFigure(picCanvas, isWireFrame, isSolid);

            foreach (PointF vscr in vScr)
            {
                vertices.Add(VectorToPointF(vscr));
            }

            vertices.Add(vertices.ElementAt(2 * numIteraciones));
            vertices.Add(vertices.ElementAt(0));
            vertices.Add(vertices.ElementAt(2 * numIteraciones + 1));
            vertices.Add(vertices.ElementAt(1));

            for (int i = 0; i < 2 * (numIteraciones * numIteracionesZ); i++)
            {
                poligonos.Add(vertices.ElementAt(i));
                poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones)));
                poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones) + 2));
                poligonos.Add(vertices.ElementAt(i + 2));

                

                int r = colorS.ElementAt(i).R;
                int g = colorS.ElementAt(i).G;
                int b = colorS.ElementAt(i).B;
                mPenFill = new Pen(Color.FromArgb(r, g, b), 2);
                ComprobarIipoGragico(mGraph, mPenFill, isWireFrame, isSolid, poligonos);
                poligonos.Clear();

                if (i < 2 * (numIteraciones) - 3)
                {

                    poligonos.Add(vertices.ElementAt(i + 3));
                    poligonos.Add(vertices.ElementAt(i + 2));
                    poligonos.Add(vertices.ElementAt(i));
                    poligonos.Add(vertices.ElementAt(i + 1));

                    ComprobarIipoGragico(mGraph, mPenFill, isWireFrame, isSolid, poligonos);
                    poligonos.Clear();

                }
                if (i > 2 * ((numIteraciones * numIteracionesZ) - numIteraciones))
                {
                    poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones) + 3));
                    poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones) + 2));
                    poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones)));
                    poligonos.Add(vertices.ElementAt(i + 2 * (numIteraciones) + 1));

                    ComprobarIipoGragico(mGraph, mPenFill, isWireFrame, isSolid, poligonos);
                    poligonos.Clear();
                }


            }

            colorS.Clear();

            vScr.Clear();
            //color = Color.Blue;

            vertices.Clear();
        }

        public void ComprobarIipoGragico(Graphics mGraph, Pen mPenFill, bool isWireFrame, bool isSolid, List<PointF> poligonos)
        {
            if (isWireFrame)
            {
                //MessageBox.Show(poligonos.ElementAt(0).ToString() + " " + poligonos.ElementAt(1).ToString() + " " + poligonos.ElementAt(2).ToString() + " " + poligonos.ElementAt(3).ToString());
                mGraph.DrawLines(mPenFill, poligonos.ToArray());

            }
            else if (isSolid)
            {
                mGraph.DrawLines(mPenFill, poligonos.ToArray());
                mGraph.FillPolygon(mPenFill.Brush, poligonos.ToArray());
            }
            else
            {
                if (contador < imgTextura.Width - 1 || contador < imgTextura.Height - 1)
                {
                    contador++;
                    Color pixelColor = imgTextura.GetPixel(contador, contador);
                    Brush brs = new SolidBrush(pixelColor);
                    mGraph.FillPolygon(brs, poligonos.ToArray());
                    brs.Dispose();
                }
                else
                {
                    contador = 0;
                }

            }
        }


        public void CalcularNormal()
        {
            float x, y, z;
            float i, j, k = 0;
            for (float h = 0; h <= altura; h += 0.1f)
            {
                for (float a = 0; a <= 2 * Math.PI + 0.1; a += 0.1f)
                {
                   /* x = radioMenor * (float)Math.Cos(a) * scale;
                    y = radioMenor * (float)Math.Sin(a) * scale;
                    z = h * scale;*/

                    i = radioMenor * (float)Math.Cos(a);aca
                    j = radioMenor * (float)Math.Sin(a);

                    int cColor = colorCodePhong(i,j,0);
                    colorS.Add(Color.FromArgb(cColor));

                    /*x = radioMayor * (float)Math.Cos(a) * scale;
                    y = radioMayor * (float)Math.Sin(a) * scale;
                    z = h * scale;*/

                    i = radioMayor * (float)Math.Cos(a);
                    j = radioMayor * (float)Math.Sin(a);
                    cColor = colorCodePhong(i, j, 0);
                    colorS.Add(Color.FromArgb(cColor));
                }
            }

            for (float a = 0; a <= 2 * Math.PI + 0.1; a += 0.1f)
            {
                x = radioMenor * (float)Math.Cos(a) * scale;
                y = radioMenor * (float)Math.Sin(a) * scale;
                z = 0;

                i = 2 * x;
                j = 2 * y;

                x = radioMayor * (float)Math.Cos(a) * scale;
                y = radioMayor * (float)Math.Sin(a) * scale;
                z = altura;
                i = 2 * x;
                j = 2 * y;
            }
        }
        double kAmb, kDiff, kSpec;
        public void setSpecular(Boolean isSpecular)
        {
            if (isSpecular)
            {
                kAmb = 0.2; kDiff = 0.7; kSpec = 0.2;
            }
            else
            {// Diffuse
                kAmb = 0.4; kDiff = 0.6; kSpec = 0.0;
            }
        }

        public int colorCodePhong(double xN, double yN, double zN)
        {
            // Viewing vector V (from O to E, length 1):
            double colorAmbR = this.color.R/255, colorAmbG = this.color.G/255, colorAmbB = this.color.B/255,
            colorDifR = this.color.R / 255, colorDifG = this.color.G/255, colorDifB = this.color.B/255,
            colorSpecR = this.color.R/255, colorSpecG = this.color.G/255, colorSpecB = this.color.B/255;
            // Red (R) and green (G) without blue (B) gives yellow.
            // Ambient component:

            double illumAmbR = kAmb * colorAmbR,
            illumAmbG = kAmb * colorAmbG,
            illumAmbB = kAmb * colorAmbB;
            // Diffuse component:
            double
            inprodLN = Math.Max(0, xL * xN + yL * yN + zL * zN),
            illumDiff = inprodLN * kDiff,
            illumDiffR = illumDiff * colorDifR,
            illumDiffG = illumDiff * colorDifG,
            illumDiffB = illumDiff * colorDifB;
            // Specular component:
            // Reflection vector R = 2(L . N)N - L
            // xR and yR would only be used to multiply them by xV
            // and yV, and these are zero since V points to the
            // viewpoint E and we are using eye coordinates, so
            // computing xR and yR would be useless.
            double zR = 2 * inprodLN * zN - zL, // // xV = yV = 0:
            dotProductVR = Math.Max(0, zV * zR),
            illumSpec = kSpec * Math.Pow(dotProductVR, 16),
            illumSpecR = illumSpec * colorSpecR,
            illumSpecG = illumSpec * colorSpecG,
            illumSpecB = illumSpec * colorSpecB;
            // Sum of ambient, diffuse and specular illumination:
            double
            illumR =
            Math.Min(1, illumAmbR + illumDiffR + illumSpecR),
            illumG =
            Math.Min(1, illumAmbG + illumDiffG + illumSpecG),
            illumB =
            Math.Min(1, illumAmbB + illumDiffB + illumSpecB);
            int red = (int)(255 * illumR),
            green = (int)(255 * illumG),
            blue = (int)(255 * illumB);
            return (red << 16) | (green << 8) | blue;
        }


    }
}
