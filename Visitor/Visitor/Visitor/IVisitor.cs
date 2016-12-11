using Visitor.Figures;

namespace Visitor.Visitor
{
    public interface IVisitor
    {
        void VisitRectangle(Rectangle fig);
        void VisitTriangle(Triangle fig);
        void VisitCircle(Circle fig);
    }
}
