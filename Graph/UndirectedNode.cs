namespace Graph
{
    class UndirectedNode
    {
        public int Value { get; set; }
        public List<UndirectedNode> Neighbors { get; set; }

        public UndirectedNode(int value)
        {
            Value = value;
            Neighbors = new List<UndirectedNode>();
        }

        public void AddNeighbor(UndirectedNode neighbor)
        {
            if (!Neighbors.Contains(neighbor))
            {
                Neighbors.Add(neighbor);
                neighbor.Neighbors.Add(this); // Assuming undirected graph
            }
        }
    }
}
