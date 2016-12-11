using Visitor.Visitor;

namespace Visitor.Figures
{
    public class Circle : IFigure
    {
        public int Radius { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }
}
