using GraphLibrary;
using System;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace GraphxUnitTests
{
    public class GraphTests
    {
        [Fact]
        public void AddVertexToGraph()
        {
            Graph<string, int> graph = new Graph<string, int>();
            graph.AddVertex("Washington");

            Assert.NotNull(graph);
        }

        [Fact]
        public void AddADirectionToGraph()
        {
            // Arrange
            Graph<string, int> graph = new Graph<string, int>();
            // Act
            var fromVertex = graph.AddVertex("Washington");
            var toVertex = graph.AddVertex("Oregon");

            graph.AddDirectionalEdge(fromVertex, toVertex, 100);

            var data = graph.AdjacencyList[fromVertex].Count;
            var data2 = graph.AdjacencyList[fromVertex].FirstOrDefault(x => x.Vertex == toVertex);

            // Assert
            Assert.NotNull(graph.AdjacencyList);
            Assert.Equal(1, data);
            Assert.Equal(100, data2.Weight);
            Assert.NotNull(data2.Vertex);
        }

        [Fact]
        public void AddAUndirectionalEdge()
        {
            Graph<string, int> graph = new Graph<string, int>();
            
            var a = graph.AddVertex("Washington");
            var b = graph.AddVertex("Oregon");

            graph.AddUndirectionalEdge(a, b, 50);

            var countA = graph.AdjacencyList[a].Count;
            var countB = graph.AdjacencyList[b].Count;

            var destinationA = graph.AdjacencyList[a].FirstOrDefault(x => x.Vertex == b);
            var destinationB = graph.AdjacencyList[b].FirstOrDefault(x => x.Vertex == a);

            Assert.Equal(1, countA);
            Assert.Equal(1, countB);

        }
    }
}
