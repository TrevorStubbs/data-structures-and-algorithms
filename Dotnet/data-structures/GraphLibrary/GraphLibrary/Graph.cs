using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class Graph<T, W>
    {
        public Dictionary<Vertex<T>, List<Edge<T, W>>> AdjacencyList { get; set; }
        private int _size = 0;

        public Graph()
        {
            AdjacencyList = new Dictionary<Vertex<T>, List<Edge<T, W>>>();
        }

        /// <summary>
        /// Adds a Vertex to the graph
        /// </summary>
        /// <param name="value">The value for the new vertex</param>
        /// <returns>The added vertex if successful</returns>
        public Vertex<T> AddVertex(T value)
        {
            Vertex<T> newVertex = new Vertex<T>(value);
            AdjacencyList.Add(newVertex, new List<Edge<T, W>>());
            _size++;

            return newVertex;
        }

        /// <summary>
        /// Adds a directional edge to a vertex.
        /// </summary>
        /// <param name="fromVertex">The vertex where the edge is coming from</param>
        /// <param name="toVertex">The vertex where the edge is going to</param>
        /// <param name="weight">The weight of the edge</param>
        public void AddDirectionalEdge(Vertex<T> fromVertex, Vertex<T> toVertex, W weight)
        {
            Edge<T, W> newEdge = new Edge<T, W>()
            {
                Vertex = toVertex,
                Weight = weight
            };

            AdjacencyList[fromVertex].Add(newEdge);
        }

        /// <summary>
        /// Add an unidirectional edge between 2 vertices  
        /// </summary>
        /// <param name="vertexA">The first vertex to be connected by the edge</param>
        /// <param name="vertexB">The second vertex to be connected by the edge</param>
        /// <param name="weight">The weight of the edge</param>
        public void AddUndirectionalEdge(Vertex<T> vertexA, Vertex<T> vertexB, W weight)
        {
            AddDirectionalEdge(vertexA, vertexB, weight);
            AddDirectionalEdge(vertexB, vertexA, weight);
        }

        /// <summary>
        /// Gets all the neighbors from a specific vertex
        /// </summary>
        /// <param name="value">The value of the vertex</param>
        /// <returns>A list of all the vertex's neighbors</returns>
        public List<Edge<T, W>> GetNeighbors(Vertex<T> value)
        {
            return AdjacencyList[value];
        }

        /// <summary>
        /// Gets a specific vertex
        /// </summary>
        /// <param name="value">The value of the vertex</param>
        /// <returns>The specified vertex</returns>
        public Vertex<T> GetVertex(T value)
        {
            foreach (var vertex in AdjacencyList)
            {
                if (vertex.Key.Value.Equals(value))
                {
                    return vertex.Key;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all the vertices from the graph
        /// </summary>
        /// <returns>A List of all the vertices from the graph</returns>
        public List<Vertex<T>> GetAllVertices()
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();
            foreach (var vertex in AdjacencyList)
            {
                vertices.Add(vertex.Key);
            }

            return vertices;
        }

        /// <summary>
        /// Checks to see if an edge between 2 vertices exists and if it does exist then output the edge object.
        /// </summary>
        /// <param name="startValue">The value of the first vertex</param>
        /// <param name="endValue">The value of the second vertex</param>
        /// <returns>A boolean and an edge (if it exists)</returns>
        public Boolean GetAnEdge(T startValue, T endValue, out Edge<T, W> outputEdge)
        {
            var startVertex = GetVertex(startValue);
            var endVertex = GetVertex(endValue);

            var startVertexEdges = AdjacencyList[startVertex];

            foreach (var edge in startVertexEdges)
            {
                if (endVertex == edge.Vertex)
                {
                    outputEdge = edge;
                    return true;
                }
            }

            outputEdge = null;
            return false;
        }

        /// <summary>
        /// Gets the total number of vertices from the graph
        /// </summary>
        /// <returns>An integer of the size of the graph</returns>
        public int GetSize()
        {
            return _size;
        }

        /// <summary>
        /// Console WriteLines all the vertices from the graph
        /// </summary>
        public void Print()
        {
            foreach (var item in AdjacencyList)
            {
                Console.WriteLine($"Vertex {item.Key.Value} -> ");

                foreach (var edge in item.Value)
                {
                    Console.WriteLine($"{edge.Vertex.Value}, {edge.Weight} -> ");
                }

                Console.WriteLine("null");
            }
        }

        /// <summary>
        /// This is my iterative way of performing a Breadth First traversal of a graph.
        /// </summary>
        /// <param name="start">The node to start the traversal with</param>
        /// <returns>A list of all vertices visited using this method</returns>
        public List<Vertex<T>> BreadthFirstTraversal(Vertex<T> start)
        {
            List<Vertex<T>> nodes = new List<Vertex<T>>();
            HashSet<Vertex<T>> vistedNodes = new HashSet<Vertex<T>>();
            Queue<Vertex<T>> breadth = new Queue<Vertex<T>>();
            breadth.Enqueue(start);
            vistedNodes.Add(start);

            while (breadth.TryPeek(out _))
            {
                Vertex<T> front = breadth.Dequeue();
                nodes.Add(front);

                foreach (var child in AdjacencyList[front])
                {
                    if (!vistedNodes.Contains(child.Vertex))
                    {
                        vistedNodes.Add(child.Vertex);
                        breadth.Enqueue(child.Vertex);
                    }
                }
            }

            return nodes;
        }

        /// <summary>
        /// Recursive Depth First Traversal of the graph.
        /// </summary>
        /// <param name="start">The starting vertex</param>
        /// <returns>A list of all the vertices in the graph</returns>
        public List<Vertex<T>> DepthFirstTraversal(Vertex<T> start)
        {
            HashSet<Vertex<T>> visitedNodes = new HashSet<Vertex<T>>();
            List<Vertex<T>> traversalList = new List<Vertex<T>>();
            DepthFirstTraversal(start, visitedNodes, traversalList);

            return traversalList;
        }

        /// <summary>
        /// Helper method for DepthFirstTraversal.
        /// </summary>
        /// <param name="currentVertex">The Vertex to look at.</param>
        /// <param name="vistedSet">A hashset of all the visited vertices</param>
        /// <param name="traversalList">The list of traversed vertices.</param>
        /// <returns>A list of the traversed vertices</returns>
        private List<Vertex<T>> DepthFirstTraversal(Vertex<T> currentVertex, HashSet<Vertex<T>> vistedSet, List<Vertex<T>> traversalList)
        {
            if (!vistedSet.Contains(currentVertex))
            {
                vistedSet.Add(currentVertex);
                traversalList.Add(currentVertex);
                foreach (var edge in AdjacencyList[currentVertex])
                {
                    DepthFirstTraversal(edge.Vertex, vistedSet, traversalList);
                }
            }

            return traversalList;
        }

        /// <summary>
        /// An extension of the graph class that only deals with <string, int> graphs.
        /// </summary>
        public static class StringIntGraph
        {
            /// <summary>
            /// Finds if a route from 1 location to another is available and if it is then it returns the cost of the whole route. 
            /// </summary>
            /// <param name="graph">The graph/map to traverse</param>
            /// <param name="locations">An array of starting location, ending location, and any intermediate stops.</param>
            /// <returns>A tuple with a boolean and the cost of the trip.</returns>
            public static Tuple<bool, int> GetEdges(Graph<string, int> graph, string[] locations)
            {
                var totalPrice = 0;
                var possible = false;

                for (int i = 0; i < locations.Length - 1; i++)
                {
                    if (graph.GetAnEdge(locations[i], locations[i+1], out var edge))
                    {
                        possible = true;
                        totalPrice += edge.Weight;
                    }
                    else
                    {
                        possible = false;
                        totalPrice = 0;
                    }
                }

                return new Tuple<bool, int>(item1: possible, item2: totalPrice);
            }
        }
    }
}
