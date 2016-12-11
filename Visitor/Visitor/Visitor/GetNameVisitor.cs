using System;
using Visitor.Figures;

namespace Visitor.Visitor
{
    public class GetNameVisitor : IVisitor
    {
        public void VisitRectangle(Rectangle fig)
        {
            Console.WriteLine("This is Rectangle");
        }

        public void VisitTriangle(Triangle fig)
        {
            Console.WriteLine("This is Triangle");
        }

        public void VisitCircle(Circle fig)
        {
            Console.WriteLine("This is Circle");
        }
    }
}
