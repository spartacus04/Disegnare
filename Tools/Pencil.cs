using System.Collections.Generic;
using System.Drawing;
using Poligoni.DrawSettings;

namespace Poligoni.CanvasTools
{
    internal class Pencil : Tool
    {
        private bool overrideSize = false;

        public Pencil(Point _point, Color _color, bool _overrideSize = false, int _lineThickness = 0)
        {
            point = new System.Collections.Generic.List<Point>();
            point.Add(_point);
            color = _color;
            overrideSize = _overrideSize;
            lineThickness = _lineThickness == 0 ? DrawSettings.Settings.lineStrenght : _lineThickness;
        }

        public override void setPoint(Point _point)
        {
            point.Add(_point);
        }

        public override void draw(Graphics g)
        {
            //Disegna un punto quadrato di dimensioni minime con riepimento di un singolo colore
            for(int i = 0; i < point.Count; i++)
            {
                Rectangle dot = new Rectangle(new Point(point[i].X - lineThickness / 2, point[i].Y - lineThickness / 2), new Size(lineThickness, lineThickness));
                g.FillRectangle(new SolidBrush(color), dot);
                g.DrawRectangle(new Pen(color), dot);

                //Controllo per l'interpolazione di una linea
                if (i + 1 == point.Count) break;
                Rectangle nextDot = new Rectangle(new Point(point[i + 1].X - lineThickness / 2, point[i + 1].Y - lineThickness / 2), new Size(lineThickness, lineThickness));
                if (!dot.IntersectsWith(nextDot))
                {
                    Line line = new Line(point[i], color);
                    line.setPoint(point[i + 1]);
                    line.draw(g);
                }
            }
        }
    }
}