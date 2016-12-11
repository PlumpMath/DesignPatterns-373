using System;
using System.Collections.Generic;
using System.Drawing;
using Visitor.Figures;
using Visitor.Visitor;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var hierarchy = new Hierarchy();
            hierarchy.Add(new Circle { Radius = 23 });
            hierarchy.Add(new Triangle { CurvePoints = new List<Point> {new Point(1, 2), new Point(2, 4), new Point(4, 1)} });
            hierarchy.Add(new Figures.Rectangle { Width = 100, Height = 200 });
            hierarchy.Accept(new DrawVisitor());
            hierarchy.Accept(new GetAreaVisitor());
            hierarchy.Accept(new GetNameVisitor());

            Console.Read();
        }
    }
}
