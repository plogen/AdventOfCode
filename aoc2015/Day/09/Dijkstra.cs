using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace aoc2015.Day._09
{
    public class GraphNode
    {

        private Dictionary<GraphNode, int> outNodes = new Dictionary<GraphNode, int>();

        private string value;

        public GraphNode(string value)
        {
            this.value = value;
        }

        public string getValue()
        {
            return value;
        }

        public Dictionary<GraphNode, int> getOutNodes()
        {
            return outNodes;
        }

        /**
         * Add a connection to a node, then add node to this
         * Both weights will be the same
         */
        public void addConnectionTo(GraphNode node, int weight)
        {
            this.outNodes.Add(node, weight);
            if (!node.isConnectedTo(this))
            {
                node.addConnectionTo(this, weight);
            }
        }

        public bool isConnectedTo(GraphNode node)
        {
            return this.outNodes.ContainsKey(node);
        }
    }

    /**
     * Encapsulate a response for finding the shortest path
     */
    public class ShortestPath
    {

        private List<GraphNode> path;

        private int cost;

        public ShortestPath(List<GraphNode> path, int cost)
        {
            this.path = path;
            this.cost = cost;
        }

        public List<GraphNode> getPath()
        {
            return path;
        }

        public int getCost()
        {
            return cost;
        }
    }

    /**
     * Store the function in a class as a static method
     */
    public class Dijkstra
    {

        /**
         * Find the shortest path
         * Return an object which contains the path and sum of weights
         */
        public static ShortestPath findShortestPath(GraphNode startNode, GraphNode endNode)
        {
            // smallest weights between startNode and all other nodes
            Dictionary<GraphNode, int> smallestWeights = new Dictionary<GraphNode, int>();
            // for convenience, mark distance from startNode to itself as 0
            smallestWeights.Add(startNode, 0);

            // implicit graph of all nodes and previous node in ideal paths
            Dictionary<GraphNode, GraphNode> prevNodes = new Dictionary<GraphNode, GraphNode>();

            // use queue for breadth first search
            Queue<GraphNode> nodesToVisitQueue = new Queue<GraphNode>();

            // record visited nodes with a set
            HashSet<GraphNode> visitedNodes = new HashSet<GraphNode>();
            visitedNodes.Add(startNode);

            GraphNode currentNode = startNode;

            // loop through nodes
            while (true)
            {
                // get the shortest path so far from start to currentNode
                int dist = smallestWeights[currentNode];

                // iterate over current child's nodes and process
                Dictionary<GraphNode, int> childNodes = currentNode.getOutNodes();
                foreach (KeyValuePair<GraphNode, int> entry in childNodes)
                {
                    GraphNode childNode = entry.Key;
                    int weight = entry.Value;

                    // add node to queue if not already visited
                    if (!visitedNodes.Contains(childNode))
                    {
                        nodesToVisitQueue.Enqueue(childNode);
                    }

                    // check the distance from startNode to currentNode + thisNode
                    int thisDist = dist + weight;

                    // if we already have a distance to childNode, compare with this distance
                    if (prevNodes.ContainsKey(childNode))
                    {
                        // get the recordest smallest distance
                        int altDist = smallestWeights[childNode];

                        // if this distance is better, update smallest distance + prev node
                        if (thisDist < altDist)
                        {
                            prevNodes[childNode] = currentNode;
                            smallestWeights[childNode] = thisDist;
                        }
                    }
                    else
                    {
                        // if there is no distance recoded yet, add now
                        prevNodes[childNode] = currentNode;
                        smallestWeights[childNode] = thisDist;
                    }
                }

                // mark that we've visited this node
                visitedNodes.Add(currentNode);

                // exit if done
                if (nodesToVisitQueue.Count == 0)
                {
                    break;
                }

                // pull the next node to visit, if any
                currentNode = nodesToVisitQueue.Dequeue();
            }

            // get the shortest path into an array
            List<GraphNode> path = new List<GraphNode>();

            currentNode = endNode;
            while (currentNode != startNode)
            {
                path.Add(currentNode);

                currentNode = prevNodes[currentNode];
            }
            path.Add(startNode);

            // reverse the path so it starts with startNode
            path.Reverse();

            int cost = smallestWeights[endNode];
            return new ShortestPath(path, cost);
        }
    }
}