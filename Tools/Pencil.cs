using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Pencil : Tool
    {
        public Pencil(Point _point, int _size, Color _color)
        {
            point = _point;
            size = _size;
            color = _color;
            canHold = true;
        }

        public override void draw(Graphics g)
        {
            //Disegna un punto quadrato di dimensioni minime con riepimento di un singolo colore
            Rectangle dot = new Rectangle(new Point(point.X - size / 2, point.Y - size / 2), new Size(size, size));
            g.FillRectangle(new SolidBrush(color), dot);
            g.DrawRectangle(new Pen(color), dot);
        }
    }
}