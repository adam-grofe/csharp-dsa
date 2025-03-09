using Newtonsoft.Json;
using System.Collections;
namespace Graph;

public class DirectedGraph
{

    public DirectedNode? rootNode;

    public DirectedGraph()
    {
        rootNode = null;
    }

    public void CreateGraphFromJson(string jsonFileName)
    {
        // Read the JSON file and deserialize it into a list of DirectedNode objects
        using (StreamReader reader = new StreamReader(jsonFileName))
        {
            string json = reader.ReadToEnd();
            var deserializedNode = JsonConvert.DeserializeObject<DirectedNode>(json);
            if (deserializedNode != null)
            {
                rootNode = deserializedNode;
            }
        }
    }

    public void ApplyToNodes(Action<DirectedNode> action, bool DepthFirst)
    {
        if (DepthFirst)
        {
            ApplyToNodesDepthFirst(action);
        }
        else
        {
            ApplyToNodesBreadthFirst(action);
        }
    }

    void ApplyToNodesBreadthFirst(Action<DirectedNode> action)
    {
        if( rootNode == null)
        {
            return;
        }

        Queue<DirectedNode> nodeQueue = new Queue<DirectedNode>();
        nodeQueue.Enqueue(rootNode);
        while( nodeQueue.Count() > 0)
        {
            DirectedNode currentNode = nodeQueue.Dequeue();
            action(currentNode);
            if (currentNode.Neighbors.Count() > 0)
            {
                foreach (DirectedNode node in currentNode.Neighbors)
                {
                    nodeQueue.Enqueue(node);
                }
            }
        }
    }

    void ApplyToNodesDepthFirst(Action<DirectedNode> action)
    {
        if( rootNode == null )
        {
            return;
        }

        Stack<DirectedNode> nodeStack = new Stack<DirectedNode>();
        nodeStack.Push(rootNode);
        while( nodeStack.Count() > 0)
        {
            DirectedNode currentNode = nodeStack.Pop();
            action(currentNode);
            if( currentNode.Neighbors.Count() > 0)
            {
                foreach (DirectedNode node in currentNode.Neighbors)
                {
                    nodeStack.Push(node);
                }
            }
        }
    }

}
