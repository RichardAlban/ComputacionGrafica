using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace HoneyComb
{
    internal class CHoneyComb
    {
        // Datos Miembros (Atributos)
        // Lado del hexagonopara calcular el Honey Comb
        private float side;
        //Apothema del Hexagono
        private float apothem;
        //Segmento 'b' del hexagono
        private float b;
        // Ángulo agudo del triángulo rectángulo APC.
        private float angle;
        // Objeto que activa el modo gráfico.
        private Graphics mGraph;
        // Constante scale factor (Zoom In/Zoom Out).
        private const float SF = 7;
        // Objeto bolígrafo que dibuja o escribe en un lienzo (canvas).
        private Pen mPen;
        // Objeto Punto que representa a los vértices del hexágono.
        private PointF A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V;
        private PointF Da, Db, Dc, Dd, De, Df, Dg, Dh, Di, Dj, Dk, Dl, Dm, Dn, Do, Dp;
        // Objeto que maneja un pincel para el relleno.
        private SolidBrush brush;

        public CHoneyComb()
        {
            side = 0.0f;
        }

        //Funcion que lee el lado del hexágono
        public void ReadData(TextBox txtSide)
        {
            try
            {
                side=float.Parse(txtSide.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso inválido");
            }
        }

        public void InitializeData(TextBox txtSide, PictureBox picCanvas)
        {
            side = 0.0f;
            txtSide.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        // Función que calcula los valores de los seis vértices del hexágono.
        public void CalculateVertex()
        {
            angle = 60.0f * (float)Math.PI / 180.0f;
            b = side * (float)Math.Cos(angle);
            apothem = side * (float)Math.Sin(angle);
            //Vertices de los segmentos de la figura
            A.X = 2.0f * side + 3.0f * b; A.Y = 0;
            B.X = 3.0f * side + 3.0f * b; B.Y = 0;
            D.X = 3.0f * side + 4.0f * b; D.Y = apothem;
            F.X = 3.0f * side + 3.0f * b; F.Y = 2.0f * apothem;
            E.X = 2.0f * side + 3.0f * b; E.Y = 2.0f * apothem;
            C.X = 2.0f * side + 2.0f * b; C.Y = apothem;
            G.X = side + 2.0f * b; G.Y = apothem;
            H.X = 2.0f * side + 2.0f * b; H.Y = 3.0f * apothem;
            I.X = side + 2.0f * b; I.Y = 3.0f * apothem;
            J.X = side + b; J.Y = 2.0f * apothem;
            K.X = b; K.Y = 2.0f * apothem;
            L.X = side + b; L.Y = 4.0f * apothem;
            M.X = b; M.Y = 4.0f * apothem;
            N.X = 0; N.Y = 3.0f * apothem;
            O.X = 4.0f * side + 4.0f * b; O.Y = apothem;
            P.X = 4.0f * side + 5.0f * b; P.Y = 2.0f * apothem;
            Q.X = 4.0f * side + 4.0f * b; Q.Y = 3.0f * apothem;
            R.X = 3.0f * side + 4.0f * b; R.Y = 3.0f * apothem;
            S.X = 5.0f * side + 5.0f * b; S.Y = 2.0f * apothem;
            T.X = 5.0f * side + 6.0f * b; T.Y = 3.0f * apothem;
            U.X = 5.0f * side + 5.0f * b; U.Y = 4.0f * apothem;
            V.X = 4.0f * side + 5.0f * b; V.Y = 4.0f * apothem;
            //Vertices del contorno de la Figura
            Da.X = 5.0f * side + 6.0f * b; Da.Y = 5.0f * apothem;
            Db.X = 5.0f * side + 5.0f * b; Db.Y = 6.0f * apothem;
            Dc.X = 5.0f * side + 6.0f * b; Dc.Y = 7.0f * apothem;
            Dd.X = 5.0f * side + 5.0f * b; Dd.Y = 8.0f * apothem;
            De.X = 4.0f * side + 5.0f * b; De.Y = 8.0f * apothem;
            Df.X = 4.0f * side + 4.0f * b; Df.Y = 9.0f * apothem;
            Dg.X = 3.0f * side + 4.0f * b; Dg.Y = 9.0f * apothem;
            Dh.X = 3.0f * side + 3.0f * b; Dh.Y = 10.0f * apothem;
            Di.X = 2.0f * side + 3.0f * b; Di.Y = 10.0f * apothem;
            Dj.X = 2.0f * side + 2.0f * b; Dj.Y = 9.0f * apothem;
            Dk.X = side + 2.0f * b; Dk.Y = 9.0f * apothem;
            Dl.X = side + b; Dl.Y = 8.0f * apothem;
            Dm.X = b; Dm.Y = 8.0f * apothem;
            Dn.X = 0; Dn.Y = 7.0f * apothem;
            Do.X = b; Do.Y = 6.0f * apothem;
            Dp.X = 0; Dp.Y = 5.0f * apothem;
        }

        //Función para graficar el panal de abeja
        public void PlotHoneyComb(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Yellow);
            CalculateVertex();
            //Vertices de los segmentos de la figura
            A.X = A.X * SF; A.Y = A.Y * SF;
            B.X = B.X * SF; B.Y = B.Y * SF;
            C.X = C.X * SF; C.Y = C.Y * SF;
            D.X = D.X * SF; D.Y = D.Y * SF;
            E.X = E.X * SF; E.Y = E.Y * SF;
            F.X = F.X * SF; F.Y = F.Y * SF;
            G.X = G.X * SF; G.Y = G.Y * SF;
            H.X = H.X * SF; H.Y = H.Y * SF;
            I.X = I.X * SF; I.Y = I.Y * SF;
            J.X = J.X * SF; J.Y = J.Y * SF;
            K.X = K.X * SF; K.Y = K.Y * SF;
            L.X = L.X * SF; L.Y = L.Y * SF;
            M.X = M.X * SF; M.Y = M.Y * SF;
            N.X = N.X * SF; N.Y = N.Y * SF;
            O.X = O.X * SF; O.Y = O.Y * SF;
            P.X = P.X * SF; P.Y = P.Y * SF;
            Q.X = Q.X * SF; Q.Y = Q.Y * SF;
            R.X = R.X * SF; R.Y = R.Y * SF;
            S.X = S.X * SF; S.Y = S.Y * SF;
            T.X = T.X * SF; T.Y = T.Y * SF;
            U.X = U.X * SF; U.Y = U.Y * SF;
            V.X = V.X * SF; V.Y = V.Y * SF;
            //Vertices del contorno de la figura
            Da.X = Da.X * SF; Da.Y = Da.Y * SF;
            Db.X = Db.X * SF; Db.Y = Db.Y * SF;
            Dc.X = Dc.X * SF; Dc.Y = Dc.Y * SF;
            Dd.X = Dd.X * SF; Dd.Y = Dd.Y * SF;
            De.X = De.X * SF; De.Y = De.Y * SF;
            Df.X = Df.X * SF; Df.Y = Df.Y * SF;
            Dg.X = Dg.X * SF; Dg.Y = Dg.Y * SF;
            Dh.X = Dh.X * SF; Dh.Y = Dh.Y * SF;
            Di.X = Di.X * SF; Di.Y = Di.Y * SF;
            Dj.X = Dj.X * SF; Dj.Y = Dj.Y * SF;
            Dk.X = Dk.X * SF; Dk.Y = Dk.Y * SF;
            Dl.X = Dl.X * SF; Dl.Y = Dl.Y * SF;
            Dm.X = Dm.X * SF; Dm.Y = Dm.Y * SF;
            Dn.X = Dn.X * SF; Dn.Y = Dn.Y * SF;
            Do.X = Do.X * SF; Do.Y = Do.Y * SF;
            Dp.X = Dp.X * SF; Dp.Y = Dp.Y * SF;
            PointF[] polPoints1 = { A, B, D, O, P, S, T, U, Da, Db, Dc, Dd, De, Df, Dg, Dh, Di, Dj, Dk, Dl, Dm, Dn, Do, Dp, M, N, K, J, G, C, A};
            mGraph.FillPolygon(brush, polPoints1);

            //Parte central de la figura
            for (int i = 0; i < 5; i++)
            {
                mGraph.DrawLine(mPen, A.X, A.Y + (2.0f * SF * i * apothem), B.X, B.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, B.X, B.Y + (2.0f * SF * i * apothem), D.X, D.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, D.X, D.Y + (2.0f * SF * i * apothem), F.X, F.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, F.X, F.Y + (2.0f * SF * i * apothem), E.X, E.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, E.X, E.Y + (2.0f * SF * i * apothem), C.X, C.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, C.X, C.Y + (2.0f * SF * i * apothem), A.X, A.Y + (2.0f * SF * i * apothem));
            }

            //Partes medias de la figura
            for (int i = 0; i < 4; i++)
            {
                mGraph.DrawLine(mPen, E.X, E.Y + (2.0f * SF * i * apothem), H.X, H.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, H.X, H.Y + (2.0f * SF * i * apothem), I.X, I.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, I.X, I.Y + (2.0f * SF * i * apothem), J.X, J.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, J.X, J.Y + (2.0f * SF * i * apothem), G.X, G.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, G.X, G.Y + (2.0f * SF * i * apothem), C.X, C.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, D.X, D.Y + (2.0f * SF * i * apothem), O.X, O.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, O.X, O.Y + (2.0f * SF * i * apothem), P.X, P.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, P.X, P.Y + (2.0f * SF * i * apothem), Q.X, Q.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, Q.X, Q.Y + (2.0f * SF * i * apothem), R.X, R.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, R.X, R.Y + (2.0f * SF * i * apothem), F.X, F.Y + (2.0f * SF * i * apothem));
            }

            //Partes externas de la figura
            for (int i = 0; i < 3; i++)
            {
                mGraph.DrawLine(mPen, I.X, I.Y + (2.0f * SF * i * apothem), L.X, L.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, L.X, L.Y + (2.0f * SF * i * apothem), M.X, M.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, M.X, M.Y + (2.0f * SF * i * apothem), N.X, N.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, N.X, N.Y + (2.0f * SF * i * apothem), K.X, K.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, K.X, K.Y + (2.0f * SF * i * apothem), J.X, J.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, P.X, P.Y + (2.0f * SF * i * apothem), S.X, S.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, S.X, S.Y + (2.0f * SF * i * apothem), T.X, T.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, T.X, T.Y + (2.0f * SF * i * apothem), U.X, U.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, U.X, U.Y + (2.0f * SF * i * apothem), V.X, V.Y + (2.0f * SF * i * apothem));
                mGraph.DrawLine(mPen, V.X, V.Y + (2.0f * SF * i * apothem), Q.X, Q.Y + (2.0f * SF * i * apothem));
            }

        }
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
