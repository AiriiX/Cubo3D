using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Practica_U3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarCubo();
            GuardarVerticesCuboOriginales();
        }

        private int xRotacionInicial = 0;
        private int yRotacionInicial = 0;
        private int zRotacionInicial = 0;

        private Color colorSeleccionado = Color.White;
        private const int AnchoPanel = 585;
        private const int AltoPanel = 275;

        private bool cuadroPresionado = false;
        private Point3D[] verticesCubo = new Point3D[8];
        private PointF[] cubo2D = new PointF[8];
        private int[,] aristasCubo = new int[,]
        {
        {0, 1}, {1, 2}, {2, 3}, {3, 0},
        {4, 5}, {5, 6}, {6, 7}, {7, 4},
        {0, 4}, {1, 5}, {2, 6}, {3, 7}
        };

        private Point3D[] verticesCuboOriginales = new Point3D[8];
        private int RotacionX;
        private int RotacionY;
        private int RotacionZ;

        private const int AnguloRotacionMaximo = 180;
        private const int AnguloRotacionMinimo = -180;

        private void ActualizarValoresBarra()
        {
            BarraRotacionX.Value = RotacionX;
            BarraRotacionY.Value = RotacionY;
            BarraRotacionZ.Value = RotacionZ;
        }

        private void LimitarAngulosRotacion()
        {
            RotacionX = Math.Max(Math.Min(RotacionX, AnguloRotacionMaximo), AnguloRotacionMinimo);
            RotacionY = Math.Max(Math.Min(RotacionY, AnguloRotacionMaximo), AnguloRotacionMinimo);
            RotacionZ = Math.Max(Math.Min(RotacionZ, AnguloRotacionMaximo), AnguloRotacionMinimo);
        }

        private void InicializarCubo()
        {

            verticesCubo[0] = new Point3D(-50, -50, -50); // Adelante Abajo Izquierda
            verticesCubo[1] = new Point3D(50, -50, -50);  // Adelante Abajo Derecha
            verticesCubo[2] = new Point3D(50, 50, -50);   // Adelante Arriba Derecha
            verticesCubo[3] = new Point3D(-50, 50, -50);  // Adelante Arriba Izquierda
            verticesCubo[4] = new Point3D(-50, -50, 50);  // Atras Abajo Izquierda
            verticesCubo[5] = new Point3D(50, -50, 50);   // Atras Abajo Derecha
            verticesCubo[6] = new Point3D(50, 50, 50);    // Atras Arriba Derecha
            verticesCubo[7] = new Point3D(-50, 50, 50);   // Atras Arriba Izquierda
        }

        private void GuardarVerticesCuboOriginales()
        {

            Array.Copy(verticesCubo, verticesCuboOriginales, verticesCubo.Length);
        }

        public class Point3D
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public Point3D(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Rotacionx_Scroll(object sender, EventArgs e)
        {
            RotacionX = BarraRotacionX.Value;
            LimitarAngulosRotacion();
            ActualizarValoresBarra();
            RotarCubo();
         
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorSeleccionado = colorDialog.Color;
            }
        }

        private void BtnRellenar_Click(object sender, EventArgs e)
        {
            using (Graphics g = PanelCubo.CreateGraphics())
            {
                Brush brush = new SolidBrush(colorSeleccionado);

                // Rellenar cada cara del cubo
                g.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[1], cubo2D[2], cubo2D[3] }); // Adelante
                g.FillPolygon(brush, new PointF[] { cubo2D[4], cubo2D[5], cubo2D[6], cubo2D[7] }); // Atras
                g.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[1], cubo2D[5], cubo2D[4] }); // Abajo
                g.FillPolygon(brush, new PointF[] { cubo2D[2], cubo2D[3], cubo2D[7], cubo2D[6] }); // Arriba
                g.FillPolygon(brush, new PointF[] { cubo2D[1], cubo2D[2], cubo2D[6], cubo2D[5] }); // Derecha
                g.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[3], cubo2D[7], cubo2D[4] }); // Izquierda
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            InicializarCubo();
            GuardarVerticesCuboOriginales();
            cuadroPresionado = true;
            PanelCubo.Invalidate();
        }

        int caraMasVisible = -1;

        private void PanelCubo_Paint(object sender, PaintEventArgs e)
        {

            // Calculamos el vector de vista
            PointF centroCubo = new PointF(AnchoPanel / 2, AltoPanel / 2);
            PointF vectorVista = new PointF(centroCubo.X - verticesCubo[0].X, centroCubo.Y - verticesCubo[0].Y);

            float maxDot = float.MinValue;


            for (int i = 0; i < aristasCubo.GetLength(0); i++)
            {
                // Obtenemos los vértices asociados a la arista actual
                int v1Index = aristasCubo[i, 0];
                int v2Index = aristasCubo[i, 1];

                // Calculamos la normal de la cara formada por la arista y el vector de vista
                float normalX = -(verticesCubo[v2Index].X - verticesCubo[v1Index].X);
                float normalY = verticesCubo[v2Index].Y - verticesCubo[v1Index].Y;

                // Normalizamos la normal de la cara
                float length = (float)Math.Sqrt(normalX * normalX + normalY * normalY);
                normalX /= length;
                normalY /= length;

                // Calculamos el producto escalar entre el vector de vista y la normal de la cara
                float dot = vectorVista.X * normalX + vectorVista.Y * normalY;

                // Si encontramos un producto escalar mayor, actualizamos la cara más visible
                if (dot > maxDot)
                {
                    maxDot = dot;
                    caraMasVisible = i;
                }
            }

            // Dibujamos cada cara del cubo
            for (int i = 0; i < aristasCubo.GetLength(0); i += 2)
            {

                // Obtenemos los índices de los vértices asociados a la cara actual
                int v1Index = aristasCubo[i, 0];
                int v2Index = aristasCubo[i, 1];
                int v3Index = aristasCubo[i + 1, 0];
                int v4Index = aristasCubo[i + 1, 1];

                // Elegimos el color de la cara dependiendo de si es la más visible o no
                Brush brush2 = (i == caraMasVisible || i + 1 == caraMasVisible) ? Brushes.DarkRed : new SolidBrush(colorSeleccionado);

                // Rellenamos la cara
                e.Graphics.FillPolygon(brush2, new PointF[] { cubo2D[v1Index], cubo2D[v2Index], cubo2D[v3Index], cubo2D[v4Index] });
               
            }

            // Rellenar cada cara del cubo con el color seleccionado
            Brush brush = new SolidBrush(colorSeleccionado);

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[1], cubo2D[2], cubo2D[3] }); // Adelante

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[4], cubo2D[5], cubo2D[6], cubo2D[7] }); // Atras

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[1], cubo2D[5], cubo2D[4] }); // Abajo

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[2], cubo2D[3], cubo2D[7], cubo2D[6] }); // Arriba

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[1], cubo2D[2], cubo2D[6], cubo2D[5] }); // Derecha

            e.Graphics.FillPolygon(brush, new PointF[] { cubo2D[0], cubo2D[3], cubo2D[7], cubo2D[4] }); // Izquierda
            


            // Dibujar las aristas del cubo en 2D
            for (int i = 0; i < aristasCubo.GetLength(0); i++)
            {
                e.Graphics.DrawLine(Pens.Black, cubo2D[aristasCubo[i, 0]], cubo2D[aristasCubo[i, 1]]);
            }
        }

        private PointF ProyeccionCubo(Point3D punto3D)
        {
            // Aplicar proyección ortográfica para convertir las coordenadas 3D a 2D
            float x = punto3D.X + AnchoPanel / 2;
            float y = punto3D.Y + AltoPanel / 2;
            return new PointF(x, y);
        }

        private void RotarCubo()
        {
            // Rotar los vértices del cubo en 3D
            for (int i = 0; i < verticesCubo.Length; i++)
            {
                verticesCubo[i] = RotarPunto(verticesCuboOriginales[i], RotacionX, RotacionY, RotacionZ);
                cubo2D[i] = ProyeccionCubo(verticesCubo[i]);
            }

           

            PanelCubo.Invalidate();

        }
        private Point3D RotarPunto(Point3D punto, int xRotacion, int yRotacion, int zRotacion)
        {
            // Aplicar rotación en los ejes X, Y y Z
            double anguloX = xRotacion * Math.PI / 180;
            double anguloY = yRotacion * Math.PI / 180;
            double anguloZ = zRotacion * Math.PI / 180;

            double sinX = Math.Sin(anguloX);
            double cosX = Math.Cos(anguloX);
            double sinY = Math.Sin(anguloY);
            double cosY = Math.Cos(anguloY);
            double sinZ = Math.Sin(anguloZ);
            double cosZ = Math.Cos(anguloZ);

            int x = (int)(punto.X * cosY * cosZ + punto.Y * (-cosX * sinZ + sinX * sinY * cosZ) + punto.Z * (sinX * sinZ + cosX * sinY * cosZ));
            int y = (int)(punto.X * cosY * sinZ + punto.Y * (cosX * cosZ + sinX * sinY * sinZ) + punto.Z * (-sinX * cosZ + cosX * sinY * sinZ));
            int z = (int)(-punto.X * sinY + punto.Y * sinX * cosY + punto.Z * cosX * cosY);

            return new Point3D(x, y, z);
        }

        private void BarraRotacionY_Scroll(object sender, EventArgs e)
        {
            RotacionY = BarraRotacionY.Value;
            LimitarAngulosRotacion();
            ActualizarValoresBarra();
            RotarCubo();
            
        }

        private void BarraRotacionZ_Scroll(object sender, EventArgs e)
        {
            RotacionZ = BarraRotacionZ.Value;
            LimitarAngulosRotacion();
            ActualizarValoresBarra();
            RotarCubo();
            
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            Array.Copy(verticesCuboOriginales, verticesCubo, verticesCuboOriginales.Length);
            PanelCubo.Invalidate();

            RotacionX = xRotacionInicial;
            RotacionY = yRotacionInicial;
            RotacionZ = zRotacionInicial;

            BarraRotacionX.Value = RotacionX;
            BarraRotacionY.Value = RotacionY;
            BarraRotacionZ.Value = RotacionZ;

            RotarCubo();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
    }
}