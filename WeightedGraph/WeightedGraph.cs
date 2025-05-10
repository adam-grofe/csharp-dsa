using YamlDotNet.Serialization;

namespace WeightedGraphNamespace;
public class WeightedGraph
{
    private Dictionary<string, WeightedNode> _nodes;

    public WeightedGraph(string yaml)
    {

        _nodes = new Dictionary<string, WeightedNode>();
        var deserializer = new DeserializerBuilder().Build();
        var connections = deserializer.Deserialize<List<NodeConnection>>(yaml);
        foreach (var conn in connections)
        {
            AddConnection(conn);
        }
    }

    public void AddConnection(NodeConnection connection)
    {
        var start = _nodes.ContainsKey(connection.Start) ? _nodes[connection.Start] : new WeightedNode() { Name = connection.Start };
        var end = _nodes.ContainsKey(connection.End) ? _nodes[connection.End] : new WeightedNode() { Name = connection.End };
        start.AddConnection(end, connection.Distance);
        end.AddConnection(start, connection.Distance);

        if (!_nodes.ContainsKey(connection.Start))
        {
            _nodes.Add(connection.Start, start);
        }
        if (!_nodes.ContainsKey(connection.End))
        {
            _nodes.Add(connection.End, end);
        }
    }

    public WeightedNode this[string key]
    {
        get => _nodes[key];
    }

    public int Dijkstra(string start, string end)
    {
        var distances = InitializeDistances(start);
        var processed = new HashSet<string>();
        var current = GetClosestUnprocessed(distances, processed);
        var parents = InitializeParents(start);

        while (current is not null)
        {
            var dist = distances[current.Name];
            foreach (var connection in current.Connections)
            {
                (WeightedNode node, int connDist) = connection.Value;
                var newDist = dist + connDist;
                if (distances[node.Name] > newDist)
                {
                    distances[node.Name] = newDist;

                    parents[node.Name] = current.Name;
                }
            }
            processed.Add(current.Name);
            current = GetClosestUnprocessed(distances, processed);
        }
        return distances[end];
    }

    private Dictionary<string, int> InitializeDistances(string start)
    {
        var distances = new Dictionary<string, int>();
        foreach (var key in _nodes.Keys)
        {
            distances.Add(key, int.MaxValue);
        }

        foreach (var item in _nodes[start].Connections)
        {
            (WeightedNode itemNode, int itemDistance) = item.Value;
            distances[item.Key] = itemDistance;
        }

        return distances;
    }

    private Dictionary<string, string?> InitializeParents(string start)
    {
        var parents = new Dictionary<string, string?>();
        foreach (var node in _nodes.Keys)
        {
            parents.Add(node, null);
        }

        foreach (var conn in _nodes[start].Connections)
        {
            (WeightedNode node, int dist) = conn.Value;
            parents[node.Name] = start;
        }
        return parents;
    }

    private WeightedNode? GetClosestUnprocessed(Dictionary<string, int> distances, HashSet<string> processed)
    {
        WeightedNode? result = null;
        int lowest = int.MaxValue;
        foreach (var node in _nodes)
        {
            if (distances[node.Key] < lowest && !processed.Contains(node.Key))
            {
                lowest = distances[node.Key];
                result = node.Value;
            }
        }
        return result;
    }
}
