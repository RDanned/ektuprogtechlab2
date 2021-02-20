using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace lab.src
{
    class Graph: Drawable
    {
        int id;
        public string name;
        int radius = 10;
        public int x = 0;
        public int y = 0;
        public SolidColorBrush color = Brushes.DarkBlue;
        public Route route;

        public Graph setId(int id)
        {
            this.id = id;

            return this;
        }

        public Graph setName(string name)
        {
            this.name = name;

            return this;
        }

        public Graph setCoords(int x, int y)
        {
            this.x = x;
            this.y = y;
            return this;
        }

        public Graph setRoute(Route route)
        {
            this.route = route;

            return this;
        }

        public void draw(Canvas canvas)
        {
            Ellipse graph = new Ellipse();
            graph.Stroke = Brushes.Black;
            graph.Fill = this.color;
            graph.HorizontalAlignment = HorizontalAlignment.Left;
            graph.VerticalAlignment = VerticalAlignment.Center;
            graph.Width = this.radius;
            graph.Height = this.radius;

            Canvas.SetTop(graph, this.y);
            Canvas.SetLeft(graph, this.x);

            Label graphLabel = new Label();
            graphLabel.Content = this.name;
            graphLabel.Width = 100;
            graphLabel.Height = 50;

            Canvas.SetTop(graphLabel, this.y - this.radius);
            Canvas.SetLeft(graphLabel, this.x + this.radius);

            canvas.Children.Add(graph);
            canvas.Children.Add(graphLabel);
        }

        public static Graph createGraph(int id)
        {
            Graph graph = new Graph();
            graph.setId(id);

            return graph;
        }
    }
}
