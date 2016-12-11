using System.Collections.Generic;
using Visitor.Figures;
using Visitor.Visitor;

namespace Visitor
{
    public class Hierarchy
    {
        private readonly List<IFigure> _figures = new List<IFigure>();

        public void Add(IFigure figure)
        {
            _figures.Add(figure);
        }

        public void Remove(IFigure figure)
        {
            _figures.Remove(figure);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var figure in _figures)
            {
                figure.Accept(visitor);
            }
        }
    }
}
