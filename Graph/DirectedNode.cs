using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph { 
    public class DirectedNode
    {
        public int Value { get; set; }
        public List<DirectedNode> Neighbors { get; set; }

        public DirectedNode(int value)
        {
            Value = value;
            Neighbors = new List<DirectedNode>();
        }

        public void AddNeighbor(DirectedNode neighbor)
        {
            if (!Neighbors.Contains(neighbor))
            {
                Neighbors.Add(neighbor);
            }
        }
    }
}
