namespace WeightedGraphNamespace;
public class WeightedNode
{
    public required string Name { get; set; }
    public Dictionary<string, (WeightedNode, int)> Connections { get; private set; } = new Dictionary<string, (WeightedNode, int)>();

    public int? Distance(string nodeName)
    {
        Connections.TryGetValue(nodeName, out var connection);
        (WeightedNode node, int dist) = connection;
        return dist == 0 ? null : dist;
    }

    public void AddConnection(WeightedNode connNode, int connDist)
    {
        if (Connections.ContainsKey(connNode.Name))
        {
            throw new ArgumentException("Node connection already exists.");
        }
        Connections.Add(connNode.Name, (connNode, connDist));
    }
}
