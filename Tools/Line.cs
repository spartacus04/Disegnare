using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Line : Tool
    {
        public Point point2;

        public Line(Point _point, Point _point2, int _size, Color _color)
        {
            point = _point;
            point2 = _point2;
            size = _size;
            color = _color;
            canHold = true;
        }

        public override void draw(Graphics g)
        {
            //Disegna una riga di un certo colore
            g.DrawLine(new Pen(color, size), point, point2);
        }
    }
}