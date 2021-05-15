using System;
using System.Collections.Generic;
using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Polygon : Tool
    {
        private int sides;

        public Polygon(Point _point, int _size, Color _color, Color _backColor, int _sides)
        {
            point = _point;
            size = _size;
            color = _color;
            sides = _sides;
            backColor = _backColor;
            canHold = false;
        }

        public override void draw(Graphics g)
        {
            //In C# per disegnare un poligono bisogna essere a conoscenza delle coordinate dei vertici di un poligono

            List<PointF> points = new List<PointF>();
            //Trovo il raggio della circonferenza circoscritta
            double apotema = (sides / 2) + Math.Tan(Math.PI * (sides - 2) * (2 * sides));
            double raggio = Math.Sqrt((apotema * apotema) + Math.Pow(size / 2, 2));

            //Rotazione del poligono per avere la base allineata con l'asse x
            double offset = sides % 2 == 1 ? -(Math.PI / 2) : 0;

            //Trovo le coordinate dei vertici
            for (int i = 0; i < sides; i++)
            {
                double angle = (2 * Math.PI) / sides;
                double xi = Math.Cos(angle * i + offset);
                double yi = Math.Sin(angle * i + offset);

                points.Add(new PointF((float)(xi * raggio + point.X), (float)(yi * raggio + point.Y)));
            }

            List<Point> toDraw = new List<Point>();
            //Arrotondo i valori
            foreach (PointF point in points)
            {
                toDraw.Add(new Point((int)Math.Floor((double)point.X), (int)Math.Floor((double)point.Y)));
            }

            //Disegna il poligono
            g.DrawPolygon(new Pen(color, 5), toDraw.ToArray());
            g.FillPolygon(new SolidBrush(backColor), toDraw.ToArray());
        }
    }
}