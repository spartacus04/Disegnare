using System.Collections.Generic;
using System.Drawing;

namespace Poligoni.CanvasTools
{
    //Da questa classe vengono ereditati tutti gli strumenti
    internal abstract class Tool
    {
        public List<Point> point { get; set; }
        public Size size { get; set; }
        public Color color { get; set; }
        public Color backColor { get; set; }

        public abstract void setPoint(Point _point);
        public abstract void draw(Graphics g);
    }
}