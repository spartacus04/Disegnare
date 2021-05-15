using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Circle : Tool
    {
        public Circle(Point _point, int _size, Color _color, Color _backColor)
        {
            point = _point;
            size = _size;
            color = _color;
            backColor = _backColor;
            canHold = false;
        }

        public override void draw(Graphics g)
        {
            //Disegna un cerchio
            g.DrawEllipse(new Pen(color, 3), point.X - size, point.Y - size, size + size, size + size);
            g.FillEllipse(new SolidBrush(backColor), point.X - size, point.Y - size, size + size, size + size);
        }
    }
}