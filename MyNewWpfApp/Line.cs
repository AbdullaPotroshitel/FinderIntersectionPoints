using System.Windows;
using System.Windows.Media;

namespace MyNewWpfApp
{
    public class Line
    {
        MathPoint firstPoint;
        MathPoint secondPoint;
        public MathPoint FirstPoint { get => firstPoint; set => firstPoint = value; }
        public MathPoint SecondPoint { get => secondPoint; set => secondPoint = value; }
        public Brush Color { get; set; }
        public Line(Point firstPoint = default, Point secondPoint = default, Brush color = default)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            Color = color;
        }
        public override string ToString() => $"p1{{{firstPoint}}}; p2{{{secondPoint}}}";
    }
}
