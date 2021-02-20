using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace lab.src
{
    class Route: Drawable
    {
        string name;
        int angle;
        public int id;

        public SolidColorBrush color;
        
        Canvas canvas;

        public List<Graph> graphs = new List<Graph>();
        List<GraphEdge> edges = new List<GraphEdge>();
        //Random rnd = new Random();

        public Route(Canvas canvas)
        {
            this.canvas = canvas;

        }

        public void generateRoute()
        {
            /*int Seed = (int)DateTime.Now.Ticks;
            Random rnd = new Random(Seed);*/
            this.name = $"Маршрут {id}";

            Random rnd = MainWindow.rnd;

            int stationsCount = rnd.Next(7, 10);

            int windowWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int windowHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

            /*windowWidth = (int)canvas.ActualWidth;
            windowHeight = (int)canvas.ActualHeight;*/

            Console.WriteLine("parms");
            Console.WriteLine(windowWidth);
            Console.WriteLine(windowHeight);

            int x = windowWidth / 2 - windowWidth / 4 + rnd.Next(-100, 500);
            int y = windowHeight / 2 + windowHeight / 4 + rnd.Next(-100, 100);

            for (int i = 0; i != stationsCount; i++)
            {
                Graph newGraph = Graph.createGraph(i);
                newGraph.setCoords(x + this.angle, y + this.angle);
                newGraph.color = this.color;
                newGraph.setRoute(this);
                newGraph.setName($"Станция {i} M{newGraph.route.id}");

                if (this.graphs.Count > 0)
                {

                    Graph oldGraph = this.getLastGraph();

                    GraphEdge edge = GraphEdge.createGraphEdge();
                    edge.addEdges(oldGraph, newGraph);
                    edge.addLength(rnd.Next(4, 8));

                    this.addEdge(edge);
                }

                this.addGraph(newGraph);
                
                x -= rnd.Next(-50, 100);
                y -= rnd.Next(20, 100);
            }
        }

        public IEnumerable<Graph> getList()
        {
            return this.graphs;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setAngle(int angle)
        {
            this.angle = angle;
        }

        private void addGraph(Graph graph)
        {
            this.graphs.Add(graph);
        }

        private void addEdge(GraphEdge edge)
        {
            this.edges.Add(edge);
        }

        private Graph getLastGraph()
        {
            return this.graphs.Last();
        }

        public void draw(Canvas canvas)
        {
            Random rnd = MainWindow.rnd;

            foreach (Graph graph in this.graphs)
            {
                graph.draw(canvas);
            }

            foreach (GraphEdge graphEdge in this.edges)
            {
                graphEdge.draw(canvas);
            }

            int windowWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int windowHeight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

            int x = windowWidth / 2 - windowWidth / 4;
            int y = windowHeight / 2 + windowHeight / 4;

            Label routeLabel = new Label();
            routeLabel.Content = this.name;
            routeLabel.Width = 100;
            routeLabel.Height = 40;
            routeLabel.Foreground = this.color;
            routeLabel.Background = Brushes.White;
            routeLabel.FontWeight = FontWeights.UltraBold;

            Canvas.SetTop(routeLabel, this.graphs.First().y + 10);
            Canvas.SetLeft(routeLabel, this.graphs.First().x - 20);

            canvas.Children.Add(routeLabel);
        }
    }
}
