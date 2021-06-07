using System;
using System.Collections.Generic;
using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Polygon : Tool
    {
        public int sides = 4;

        public Polygon(Point _point, Color _color, Color _backColor)
        {
            point = new System.Collections.Generic.List<Point>();
            point.Add(_point);
            color = _color;
            backColor = _backColor;
        }

        public void setSides(int _sides)
        {
            sides = _sides;
        }

        public override void setPoint(Point _point)
        {
            if (point.Count == 1)
            {
                point.Add(_point);
                size = new Size(point[1].X - point[0].X, point[1].Y - point[0].Y);
            }
            else
            {
                point[1] = (_point);
                size = new Size(point[1].X - point[0].X, point[1].Y - point[0].Y);
            }
        }

        public void setRegular(bool _regular)
        {
            if (_regular)
            {
                int lenght = size.Width > size.Height ? size.Width : size.Height;
                size = new Size(lenght, lenght);
            }
        }

        public override void draw(Graphics g)
        {
            if(point.Count == 2)
            {
                //In C# per disegnare un poligono bisogna essere a conoscenza delle coordinate dei vertici di un poligono

                List<PointF> points = new List<PointF>();

                //Rotazione del poligono per avere la base allineata con l'asse x
                double offset = sides % 2 == 1 ? -(Math.PI / 2) : (sides % 4 == 2 ? - (Math.PI / sides * 2) : -(Math.PI / sides));

                //Trovo le coordinate dei vertici
                for (int i = 0; i < sides; i++)
                {
                    double angle = (2 * Math.PI) / sides;
                    double xi = Math.Cos(angle * i + offset);
                    double yi = Math.Sin(angle * i + offset);

                    points.Add(new PointF((float)(xi * size.Width + point[0].X), (float)(yi * size.Height + point[0].Y)));
                }

                List<Point> toDraw = new List<Point>();
                //Arrotondo i valori
                foreach (PointF point in points)
                {
                    toDraw.Add(new Point((int)Math.Floor((double)point.X), (int)Math.Floor((double)point.Y)));
                }

                //Disegna il poligono
                g.DrawPolygon(new Pen(color, DrawSettings.Settings.lineStrenght), toDraw.ToArray());
                g.FillPolygon(new SolidBrush(backColor), toDraw.ToArray());
            }
        }
    }
}