using System.Drawing;

namespace Poligoni.CanvasTools
{
    //Da questa classe vengono ereditati tutti gli strumenti
    internal abstract class Tool
    {
        public Point point { get; set; }
        public int size { get; set; }
        public Color color { get; set; }
        public Color backColor { get; set; }
        public bool canHold { get; set; }

        public abstract void draw(Graphics g);
    }
}