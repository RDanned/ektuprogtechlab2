using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab.src;

namespace lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Graph> graphs;
        List<GraphEdge> edges;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();

            int stationsCount = rnd.Next(5, 10);

            for(int i = 0; i != stationsCount; i++)
            {
                if(graphs.Count > 0)
                {
                    Graph oldGraph = this.getLastGraph();
                    Graph newGraph = this.addGraph(i);

                    GraphEdge edge = new GraphEdge();
                    edge.addEdges(oldGraph, newGraph);

                    this.addEdge();
                } 
                else
                {
                    this.addGraph(i);
                }
            }

        }

        private Graph addGraph(int id)
        {
            Graph graph = new Graph();
            graph.setId(id);
            graph.setName($"Станция {id}");
            this.graphs.Add(graph);

            return graph;
        }

        private void addEdge(GraphEdge edge)
        {
            this.edges.Add(edge);
        }

        private Graph getLastGraph()
        {
            return this.graphs.Last();
        }
    }
}
