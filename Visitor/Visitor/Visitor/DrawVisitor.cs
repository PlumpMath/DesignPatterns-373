using System;
using System.Drawing;
using Visitor.Figures;

namespace Visitor.Visitor
{
    public class DrawVisitor : IVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void SetCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void VisitRectangle(Figures.Rectangle fig)
        {
            var blackPen = new Pen(Color.Black, 3);
            var rect = new System.Drawing.Rectangle(X, Y, fig.Width, fig.Height);
            //e.Graphics.DrawRectangle(blackPen, rect);
            Console.WriteLine("Rectangle was drawed");
        }

        public void VisitTriangle(Triangle fig)
        {
            var blackPen = new Pen(Color.Black, 3);
            //e.Graphics.DrawPolygon(blackPen, fig.CurvePoints);
            Console.WriteLine("Triangle was drawed");
        }

        public void VisitCircle(Circle fig)
        {
            var blackPen = new Pen(Color.Black, 3);
            //e.Graphics.DrawEllipse(blackPen, X, Y, fig.Radius, fig.Radius);
            Console.WriteLine("Circle was drawed");
        }
    }
}
