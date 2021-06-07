using System.Drawing;
using Poligoni.DrawSettings;

namespace Poligoni.CanvasTools
{
    internal class Line : Tool
    {

        public Line(Point _point, Color _color)
        {
            point = new System.Collections.Generic.List<Point>();
            point.Add(_point);

            color = _color;
        }

        public override void setPoint(Point _point)
        {
            if (point.Count == 1)
                point.Add(_point);
            else
                point[1] = _point;
        }

        public override void draw(Graphics g)
        {
            //Disegna una riga di un certo colore
            if(point.Count == 2)
                g.DrawLine(new Pen(color, Settings.lineStrenght), point[0], point[1]);
        }
    }
}