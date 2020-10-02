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
        /// <returns>A List of all the verticies from the graph</returns>
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
        /// Gets the total number of verticies from the graph
        /// </summary>
        /// <returns>An integer of the size of the graph</returns>
        public int GetSize()
        {
            return _size;
        }

        /// <summary>
        /// Console WriteLines all the verticies from the graph
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

    }
}
