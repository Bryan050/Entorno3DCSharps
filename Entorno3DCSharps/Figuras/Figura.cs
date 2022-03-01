using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Entorno3DCSharps.Figuras
{
    abstract class Figura
    {
        private double AngX;
        private double AngY;
        private double AngZ;
        private Point3D  Angs;
        private Point3D Coordenadas;
        protected float scale = 1;
        protected Color color;
        protected Pen mPen;

        //Variables y Angulos
        public float rho, theta = 0.3F, phi = 1.3F, d, objSize;

        //Datos miembros
        protected Graphics mGraph;
        public float mCx, mCy;
        int SF = 1;

        // Puntos en 2D y 3D
        protected List<Point3D> vertex; //Clase Coordenadas Mundiales
        protected List<PointF> vScr; //PointF Coordenadas de la Pantalla

        List<Point3D> pFigura;

        public Figura()
        {
            mPen = new Pen(color);
            AngX = AngY = AngZ = 0;
            vertex = new List<Point3D>();
            vScr = new List<PointF>();
            pFigura = new List<Point3D>();
            
            objSize = (float)Math.Sqrt(100F); 
            rho = 5 * objSize;

        }

        public virtual void WireFrame(PictureBox picCanvas)
        {

        }

        //Limpiar Lista de Puntos de todas las Caras
        public void ClearLists()
        {
            vScr.Clear();
        }

        //Dibujar el Cubo en Perspectiva
        public virtual void DrawFigure(PictureBox picCanvas, bool isWireFrame, bool isSolid)
        {
            int maxX = picCanvas.Width, maxY = picCanvas.Height, minMaxXY = Math.Min(maxX, maxY);
            d = rho * minMaxXY / objSize;
            //Encontrar el Centro del PicCanvas
            mCx = (picCanvas.Width / 2);
            mCy = (picCanvas.Height / 2);
            //Activar el entorno
            mGraph = picCanvas.CreateGraphics();
            //Declarar el Lapiz para las Lineas
            mPen = new Pen(Color.Black, 3);
            //Suaviza y mejora la calidad de las lineas y contornos
            mGraph.SmoothingMode = SmoothingMode.AntiAlias;
        }

        //Transformar a entorno grafico
        public PointF VectorToPointF(PointF aux)
        {
            PointF auxPointIni = new PointF();
            auxPointIni.X = aux.X * scale + mCx;
            auxPointIni.Y = (aux.Y * scale) * -1 + mCy;
            return (auxPointIni);
        }

        //Transfromacion de Coordenadas
        public void eyeAndScreen()
        {

            float costh = (float)Math.Cos(theta),
                sinth = (float)Math.Sin(theta),
                cosph = (float)Math.Cos(phi),
                sinph = (float)Math.Sin(phi);

            //define una matriz de Transformacion de Visualizacion de la forma:
            //[ -sin(theta)    -cos(phi) * cos(theta)   sin(phi) * cos(theta)  0]
            //[  cos(theta)    -cos(phi) * sin(theta)   sin(phi) * sin(theta)  0]
            //[     0                 sin(phi)                cos(phi)         0]
            //[     0                    0                     -rho            1]
            //Transformacion de Perspectiva


            for (int i = 0; i < vertex.Count; i++)
            {
                Point3D p = vertex.ElementAt(i);

                double x = -sinth * p.X + costh * p.Y;
                double y = (-cosph * costh) * p.X + (-cosph * sinth) * p.Y + sinph * p.Z;
                double z = (sinph * costh) * p.X + (sinph * sinth) * p.Y + cosph * p.Z + -rho;
                //Aplicamos las Formula de Transformacion
                //Transformacion de Perspectiva
                // X = -d (x / z)
                // Y = -d (y / z)
                vScr.Add(new PointF((float)(-d * x / z), (float)(-d * y / z)));
            }
        }

        public void RotateFigureX(float deltaX)
        {
            for (int i = 0; i < vertex.Count; i++)
            {
                // Aplicar rotación
                // Rotar puntos
                vertex[i] = RotateX(vertex.ElementAt(i), deltaX);
            }
        }

        public void RotateFigureY(int deltaY)
        {
            for (int i = 0; i < vertex.Count; i++)
            {
                // Aplicar rotación
                // Rotar puntos
                vertex[i] = RotateY(vertex.ElementAt(i), deltaY);
            }
        }

        public void RotateFigureZ(float deltaZ)
        {
            //MessageBox.Show(vertex.Count.ToString());
            for (int i = 0; i < vertex.Count; i++)
            {
                // Aplicar rotación
                // Rotar puntos
                vertex[i] = RotateZ(vertex.ElementAt(i), deltaZ);
            }
        }

        public void TralateFigure(Point3D vertice)
        {
            //MessageBox.Show(vertex.Count.ToString());
            for (int i = 0; i < vertex.Count; i++)
            {
                // Aplicar rotación
                // Rotar puntos
                vertex[i] = Traslate(vertex.ElementAt(i), vertice);
            }
        }

        public static Point3D RotateX(Point3D point3D, float degrees)
        {
            //[ 1    0        0   ]
            //[ 0   cos(x)  sin(x)]
            //[ 0   -sin(x) cos(x)]

            double cDegrees = degrees * (float)Math.PI / 180;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double y = (point3D.Y * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.Y * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Point3D(point3D.X, y, z);
        }

        public static Point3D RotateY(Point3D point3D, float degrees)
        {
            //[ cos(x)   0    sin(x)] 
            //[   0      1      0   ] 
            //[-sin(x)   0    cos(x)]

            double cDegrees = degrees * (float)Math.PI / 180;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Z * sinDegrees);
            double z = (point3D.X * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Point3D(x, point3D.Y, z);
        }
      

        public static Point3D RotateZ(Point3D point3D, float degrees)
        {
            //[ cos(x)  sin(x) 0]
            //[ -sin(x) cos(x) 0]
            //[    0     0     1]

            double cDegrees = degrees * (float)Math.PI / 180;
            double cosDegrees = Math.Cos(cDegrees);
            double sinDegrees = Math.Sin(cDegrees);

            double x = (point3D.X * cosDegrees) + (point3D.Y * sinDegrees);
            double y = (point3D.X * -sinDegrees) + (point3D.Y * cosDegrees);

            return new Point3D(x, y, point3D.Z);
        }

        public static Point3D Traslate(Point3D point3D, Point3D vertice)
        {
            //[ 1 0 0 Vx ][Px+Vx]
            //[ 0 1 0 Vy ][Py+Vy]
            //[ 0 0 1 Vz ][Pz+Vz]
            //[ 0 0 0 1 ][1]
            double x = point3D.X + vertice.X;
            double y = point3D.Y + vertice.Y;
            double z = point3D.Z + vertice.Z;
            return new Point3D(x, y, z);
        }

        public void Scale(float scale)
        {
            this.scale = scale;
        }

        public void setColor(Color color) { 
            this.color = color;
        }

        public float ProductoPunto(Point3D V1, Point3D V2)
        {
            float escalar = 0;
            escalar = (float)(V1.X * V2.X + V1.Y * V2.Y + V1.Z * V2.Z);
            return escalar;
        }


        /*public void Rotate(double ang, double rotX, double rotY, double rotZ)
        {
            Gl.glRotated(ang, rotX, rotY, rotZ);
        }
        public void ChangeColor(double[] color)
        {
            this.color = color;
        }
        public void ChangeScale(float scale)
        {
            this.scale = scale;
        }
        public float GetScale()
        {
            return this.scale;
        }
        public void Move(double x, double y, double z)
        {
            Gl.glTranslated(x, y, z);
        }
        public void ChangeTexture()
        {
            Gl.glTextureNormalEXT(1);
        }
        public virtual void DrawFigure()
        {

        }
        public virtual void DrawFigure(float valor1)
        {

        }*/

    }
}
