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

        public Vertex<T> AddVertex(T value)
        {
            Vertex<T> newVertex = new Vertex<T>(value);
            AdjacencyList.Add(newVertex, new List<Edge<T, W>>());
            _size++;

            return newVertex;
        }

        public void AddDirectionalEdge(Vertex<T> fromVertex, Vertex<T> toVertex, W weight)
        {
            Edge<T, W> newEdge = new Edge<T, W>()
            {
                Vertex = toVertex,
                Weight = weight
            };
            AdjacencyList[fromVertex].Add(newEdge);
        }

        public void AddUndirectionalEdge(Vertex<T> vertexA, Vertex<T> vertexB, W weight)
        {
            AddDirectionalEdge(vertexA, vertexB, weight);
            AddDirectionalEdge(vertexB, vertexA, weight);
        }

        public List<Edge<T, W>> GetNeighbors(Vertex<T> value)
        {
            return AdjacencyList[value];
        }

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

        public List<Vertex<T>> GetAllVertices()
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();
            foreach (var vertex in AdjacencyList)
            {
                vertices.Add(vertex.Key);
            }

            return vertices;
        }

        public int GetSize()
        {
            return _size;
        }

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
