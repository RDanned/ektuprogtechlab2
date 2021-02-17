using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.src
{
    class GraphEdge
    {
        Graph g1;
        Graph g2;

        public GraphEdge addEdges(Graph g1, Graph g2)
        {
            this.g1 = g1;
            this.g2 = g2;

            return this;
        }
    }
}
