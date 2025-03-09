using Graph;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GraphTests;

public class DirectedGraphTests
{
    [Fact]
    public void TestReadGraphFromJson()
    {
        // Arrange
        var graph = new DirectedGraph();
        string jsonFileName = "graph_1.json";
        // Act
        graph.CreateGraphFromJson(jsonFileName);
        // Assert
        Assert.NotNull(graph.rootNode);
    }

    [Fact]
    public void TestApplyToNodesBreadthFirst()
    {
        // Arrange
        var graph = new DirectedGraph();
        string jsonFileName = "graph_1.json";
        graph.CreateGraphFromJson(jsonFileName);
        List<int> visitedValues = new List<int>();
        Action<DirectedNode> action = node => visitedValues.Add(node.Value);

        // Act
        graph.ApplyToNodes(action, false); // false for breadth-first

        // Assert
        List<int> expectedValues = new List<int> { 0, 10, 20, 30, 11, 21, 31, 12, 22, 32 };
        Assert.Equal(expectedValues, visitedValues);
    }

    [Fact]
    public void TestApplyToNodesDepthFirst()
    {
        // Arrange
        var graph = new DirectedGraph();
        string jsonFileName = "graph_1.json";
        graph.CreateGraphFromJson(jsonFileName);
        List<int> visitedValues = new List<int>();
        Action<DirectedNode> action = node => visitedValues.Add(node.Value);

        // Act
        graph.ApplyToNodes(action, true);

        // Assert
        List<int> expectedValues = new List<int> { 0, 30, 31, 32, 20, 21, 22, 10, 11, 12 };
        Assert.Equal(expectedValues, visitedValues);
    }
}
