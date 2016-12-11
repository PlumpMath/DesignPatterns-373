using Visitor.Visitor;

namespace Visitor.Figures
{
    public interface IFigure
    {
        void Accept(IVisitor visitor);
    }
}
