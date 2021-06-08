using System.Drawing;

namespace Poligoni.CanvasTools
{
    internal class Circle : Tool
    {

        public Circle(Point _point, Color _color, Color _backColor, int _lineThickness = 0)
        {
            point = new System.Collections.Generic.List<Point>();
            point.Add(_point);
            color = _color;
            backColor = _backColor;
            lineThickness = _lineThickness == 0 ? DrawSettings.Settings.lineStrenght : _lineThickness;
        }

        public override void setPoint(Point _point)
        {
            if(point.Count == 1)
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
            //Disegna un cerchio
            if(point.Count == 2)
            {
                g.DrawEllipse(new Pen(color, lineThickness), point[0].X - size.Width, point[0].Y - size.Height, size.Width * 2, size.Height * 2);
                g.FillEllipse(new SolidBrush(backColor), point[0].X - size.Width, point[0].Y - size.Height, size.Width * 2, size.Height * 2);
            }
        }
    }
}