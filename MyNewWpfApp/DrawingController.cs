using System.Collections.Generic;
using Shapes = System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace MyNewWpfApp
{
    public static class DrawingController
    {
        private static int counter = 1;
        private static Point p1;
        private static Point p2;
        public static List<Line> Lines = new List<Line>();
        public static List<Point> IntersectionPoints = new List<Point>();
        static List<(int, int)> connectedLines = new List<(int, int)>();
        public static MainWindow mainWindow;
        public static void DrawLine(Point mousePoint, Canvas canvas, Brush color = default)
        {
            if(counter == 1) 
            { 
                p1 = mousePoint; 
                counter++;
            }
            else
            {
                p2 = mousePoint;
                counter = 1;
                var line = new Line(p1, p2, color);
                Lines.Add(line);
                canvas.Children.Add(new Shapes.Line()
                {
                    StrokeThickness = 4,
                    Stroke = color,
                    X1 = p1.X,
                    X2 = p2.X,
                    Y1 = p1.Y,
                    Y2 = p2.Y
                });
                mainWindow.OnLineCreated(line);
            }
        }
        public static void SetIntersectionPoints()
        {
            if (Lines.Count > 1)
            {
                for(int i = 0; i < Lines.Count; i++)
                    for (int j = 0; j < Lines.Count; j++)
                    {
                        Point? pointIntersection = null;
                        if (i != j)
                        {
                            if (!connectedLines.Contains((i, j)) && !connectedLines.Contains((j, i)))
                            {
                                pointIntersection = LineEquation.FindIntersectionPoint(Lines[i], Lines[j]);
                                if (pointIntersection != null)
                                    IntersectionPoints.Add(pointIntersection.Value);
                                connectedLines.Add((i, j));
                            }
                        }
                    }
            }
        }
    }
}
