using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.src
{
    class Graph
    {
        int id;
        string name;

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



    }
}
