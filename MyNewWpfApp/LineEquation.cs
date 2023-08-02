using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWpfApp
{
    public class LineEquation
    {
        public double k { get; private set; }
        public double b { get; private set; }
        public LineEquation() { }
        public LineEquation(Line line) => FindLineEquation(line);
        public Func<double, double> FindLineEquation(Line line)
        {
            MathPoint p1 = line.FirstPoint;
            MathPoint p2 = line.SecondPoint;
            k = (p2.Y - p1.Y) / (p2.X - p1.X);
            b = p1.Y - k * p1.X;
            Func<double, double> equation = (x) =>  k * x + b;
            return equation;
        }
        public static MathPoint FindIntersectionPoint(Line line1, Line line2)
        {
            var lineEquation1 = new LineEquation(line1);
            var lineEquation2 = new LineEquation(line2);
            double x = 0;
            double y = 0;
            MathPoint pointIntersection = new MathPoint();
            try
            {
                x = (lineEquation2.b - lineEquation1.b) / (lineEquation1.k - lineEquation2.k);
                y = x * lineEquation1.k + lineEquation1.b;
                pointIntersection.SetPoint(x, y);
            }
            catch
            {
                return null;
            }
            if(CheckPointInLine(line1, pointIntersection) && CheckPointInLine(line2, pointIntersection))
                return pointIntersection;
            else
                return null;
        }
        private static bool CheckPointInLine(Line line, MathPoint p)
        {
            var xMaxRange = Math.Max(line.SecondPoint.X, line.FirstPoint.X);
            var yMaxRange = Math.Max(line.SecondPoint.Y, line.FirstPoint.Y);
            var xMinRange = Math.Min(line.SecondPoint.X, line.FirstPoint.X);
            var yMinRange = Math.Min(line.SecondPoint.Y, line.FirstPoint.Y);
            return (p.X < xMaxRange && p.Y < yMaxRange) && (p.X > xMinRange && p.Y > yMinRange) ? true: false;
        }
    }
}
