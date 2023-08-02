using System;
using System.Windows;
using Shapes = System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using Ex = System.Linq.Expressions;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Controls.Primitives;
using System.Data;

namespace MyNewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> intersectionPoints = new List<Point>();
        ObservableCollection<Line> lines = new ObservableCollection<Line>();
        
        public MainWindow()
        {
            InitializeComponent();
            DrawingController.mainWindow = this;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(myCanvas);
            DrawingController.DrawLine(point, myCanvas, Brushes.Red);
            if (LinesTable.Columns.Count > 3)
            {
                LinesTable.Columns.Remove(LinesTable.Columns[3]);
                LinesTable.Columns.Remove(LinesTable.Columns[3]);
                LinesTable.Columns.Remove(LinesTable.Columns[3]);
            }
                
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            MathPoint point = e.GetPosition(myCanvas);
            PositionText.Text = point.ToString();
        }

        private void FindIntersection_Click(object sender, RoutedEventArgs e)
        { 
            DrawingController.SetIntersectionPoints();
            var listPoints = DrawingController.IntersectionPoints;
            foreach (var point in listPoints )
            {
                if (intersectionPoints.Contains(point)) continue;
                intersectionPoints.Add(point);
                var ellipse = new Shapes.Ellipse()
                {
                    Margin = new Thickness(point.X - 5, point.Y - 5, 0, 0),
                    StrokeThickness = 10,
                    Stroke = Brushes.Black,
                };
                myCanvas.Children.Add(ellipse);
            }
            
        }
        public void OnLineCreated(Line line)
        {
            lines.Add(line);
            LinesTable.ItemsSource = lines;
        }
        private void ColorCell_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridCell cell = e.Source as DataGridCell;
            if(cell != null)
            {
                cell.Content = null;
                var line = cell.DataContext as Line;
                cell.Background = line.Color;
            }
        }

        private void LinesTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = sender as DataGridCell;
            if(cell != null)
            {
                Test.Text = cell.DataContext.ToString();
            }else
            {
                Test.Text = "error";
            }
        }
    }
}
