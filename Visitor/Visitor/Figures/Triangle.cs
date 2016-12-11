using System.Collections.Generic;
using System.Drawing;
using Visitor.Visitor;

namespace Visitor.Figures
{
    public class Triangle : IFigure
    {
        public List<Point> CurvePoints { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitTriangle(this);
        }
    }
}
