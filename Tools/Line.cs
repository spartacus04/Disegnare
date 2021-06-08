using System.Drawing;
using Poligoni.DrawSettings;

namespace Poligoni.CanvasTools
{
    internal class Line : Tool
    {

        public Line(Point _point, Color _color, int _lineThickness = 0)
        {
            point = new System.Collections.Generic.List<Point>();
            point.Add(_point);
            color = _color;
            lineThickness = _lineThickness == 0 ? DrawSettings.Settings.lineStrenght : _lineThickness;
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
                g.DrawLine(new Pen(color, lineThickness), point[0], point[1]);
        }
    }
}