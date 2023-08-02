using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyNewWpfApp
{
    public class MathPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public MathPoint(double x = 0, double y = 0) => SetPoint(x, y);
        public void SetPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static implicit operator MathPoint(Point? p)
        {
            if(p == null) return null;
            return new MathPoint(p.Value.X, 410 - p.Value.Y);
        }
        

        public static implicit operator Point?(MathPoint p)
        {
            if (p == null) return null;
            return new Point(p.X, 410 - p.Y);
        }


        public override string ToString()
        {
            return $"x:{X}; y:{Y}";
        }
    }
}
