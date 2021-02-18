using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace lab.src
{
    class GraphEdge
    {
        Graph g1;
        Graph g2;

        int length;

        public GraphEdge addEdges(Graph g1, Graph g2)
        {
            this.g1 = g1;
            this.g2 = g2;

            return this;
        }

        public void addLength(int length)
        {
            this.length = length;
        }

        public static GraphEdge createGraphEdge()
        {
            GraphEdge graphEdge = new GraphEdge();
            return graphEdge;
        }

        public void draw(Canvas canvas)
        {
            Line graphEdge = new Line();
            graphEdge.StrokeThickness = 2;
            graphEdge.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            graphEdge.X1 = this.g1.x;
            graphEdge.Y1 = this.g1.y;
            graphEdge.X2 = this.g2.x;
            graphEdge.Y2 = this.g2.y;

            canvas.Children.Add(graphEdge);
        }
    }
}
