using System;
using Visitor.Figures;

namespace Visitor.Visitor
{
    public class GetAreaVisitor : IVisitor
    {
        public void VisitRectangle(Rectangle fig)
        {
            Console.WriteLine($"Rectangle area: {fig.Height * fig.Width}");
        }

        public void VisitTriangle(Triangle fig)
        {
            Console.WriteLine($"Triangle area: {fig.CurvePoints} - hard math...");
        }

        public void VisitCircle(Circle fig)
        {
            Console.WriteLine($"Circle area: {Math.PI * fig.Radius * fig.Radius}");
        }
    }
}
