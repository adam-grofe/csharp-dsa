using WeightedGraphNamespace;

namespace WeightedGraphTests;
public class WeightedGraphTests
{
    [Fact]
    public void GraphConstructor_ValidYamlString_CreatesGraphWithNodes()
    {
        // Arrange 
        string yamlString =
@"---
- Start: A
  End: B
  Distance: 4
- Start: A
  End: C
  Distance: 2
- Start: B
  End: D
  Distance: 8
";

        // Act
        var graph = new WeightedGraph(yamlString);


        // Assert
        Assert.Equal("A", graph["A"].Name);
        Assert.Equal("B", graph["B"].Name);
        Assert.Equal("C", graph["C"].Name);
        Assert.Equal("D", graph["D"].Name);
        Assert.Equal(4, graph["A"].Distance("B"));
        Assert.Equal(2, graph["A"].Distance("C"));
        Assert.Equal(8, graph["B"].Distance("D"));

    }

    [Fact]
    public void AddConnection_NewNodes_CreatesNodesInGraph()
    {
        // Arrange
        string startName = "E";
        string endName = "F";
        NodeConnection connection = new NodeConnection()
        {
            Distance = 7,
            Start = startName,
            End = endName
        };

        string yamlString =
@"---
- Start: A
  End: B
  Distance: 4
- Start: A
  End: C
  Distance: 2
- Start: B
  End: D
  Distance: 8
";

        // Act
        var graph = new WeightedGraph(yamlString);
        graph.AddConnection(connection);

        // Assert
        Assert.Equal(startName, graph[startName].Name);
        Assert.Equal(endName, graph[endName].Name);
        Assert.Equal(7, graph[startName].Distance(endName));
    }

    [Fact]
    public void GraphNode_NoConnect_DistanceReturnsNull()
    {
        // Arrange 
        string yamlString =
@"---
- Start: A
  End: B
  Distance: 4
- Start: A
  End: C
  Distance: 2
- Start: B
  End: D
  Distance: 8
";

        // Act
        var graph = new WeightedGraph(yamlString);


        // Assert
        Assert.Null(graph["A"].Distance("D"));
        Assert.Null(graph["C"].Distance("D"));
        Assert.Null(graph["C"].Distance("B"));

    }

    [Fact]
    public void Dijkstra_ConnectedGraph_ReturnsMin()
    {
        // Arrange
        int expected = 6;
        // Graph   6
        //      B----E       Top Path: 9
        //   2/ 4   5 \1
        //   A----C----F     Middle Path: 9
        //   2\   3   /1
        //     D-----G       Bottom Path: 6
        string yaml =
@"---
- Start: A
  End: B
  Distance: 2
- Start: A
  End: D
  Distance: 2
- Start: A
  End: C
  Distance: 4
- Start: B
  End: E
  Distance: 6
- Start: C
  End: F
  Distance: 5
- Start: D
  End: G
  Distance: 3
- Start: E
  End: F
  Distance: 1
- Start: G
  End: F
  Distance: 1
";

        var graph = new WeightedGraph(yaml);

        // Act
        var dist = graph.Dijkstra("A", "F");

        // Assert
        Assert.Equal(expected, dist);
    }
}
