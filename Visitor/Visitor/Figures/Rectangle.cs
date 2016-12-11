
using Visitor.Visitor;

namespace Visitor.Figures
{
    public class Rectangle : IFigure
    {
        private int x;
        private int y;

        public int Width { get; set; }
        public int Height { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitRectangle(this);
        }
    }
}
