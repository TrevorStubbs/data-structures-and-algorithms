using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;
using static GraphLibrary.Graph<string, int>;

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

        [Fact]
        public void CanPerformABreadthFirstTraversal()
        {
            // Arrange
            Graph<int, int> graph = new Graph<int, int>();

            var a = graph.AddVertex(1);
            var b = graph.AddVertex(2);
            var c = graph.AddVertex(3);
            var d = graph.AddVertex(4);
            var e = graph.AddVertex(5);
            var f = graph.AddVertex(6);

            graph.AddUndirectionalEdge(a, b, 0);
            graph.AddUndirectionalEdge(b, c, 0);
            graph.AddUndirectionalEdge(c, d, 0);
            graph.AddUndirectionalEdge(d, e, 0);
            graph.AddUndirectionalEdge(e, f, 0);
            graph.AddUndirectionalEdge(c, a, 0);
            graph.AddUndirectionalEdge(d, b, 0);
            graph.AddUndirectionalEdge(f, d, 0);

            var expectedList = new List<int>()
            {
                1,2,3,4,5,6
            };

            // Act
            var returnFromMethod = graph.BreadthFirstTraversal(a);

            var checkTheseInts = new List<int>();

            foreach (var item in returnFromMethod)
            {
                checkTheseInts.Add(item.Value);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(checkTheseInts);
            Assert.Equal(expectedList, checkTheseInts);
        }

        [Fact]
        public void CanPerformABreadthFirstTraversalStartingFromTheMiddle()
        {
            // Arrange
            Graph<int, int> graph = new Graph<int, int>();

            var a = graph.AddVertex(1);
            var b = graph.AddVertex(2);
            var c = graph.AddVertex(3);
            var d = graph.AddVertex(4);
            var e = graph.AddVertex(5);
            var f = graph.AddVertex(6);

            graph.AddUndirectionalEdge(a, b, 0);
            graph.AddUndirectionalEdge(b, c, 0);
            graph.AddUndirectionalEdge(c, d, 0);
            graph.AddUndirectionalEdge(d, e, 0);
            graph.AddUndirectionalEdge(e, f, 0);

            var expectedList = new List<int>()
            {
                3,2,4,1,5,6
            };

            // Act
            var returnFromMethod = graph.BreadthFirstTraversal(c);

            var checkTheseInts = new List<int>();

            foreach (var item in returnFromMethod)
            {
                checkTheseInts.Add(item.Value);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(checkTheseInts);
            Assert.Equal(expectedList, checkTheseInts);
        }

        [Fact]
        public void CanPerformADepthFirstTraversal()
        {
            // Arrange
            Graph<int, int> graph = new Graph<int, int>();

            var a = graph.AddVertex(1);
            var b = graph.AddVertex(2);
            var c = graph.AddVertex(3);
            var d = graph.AddVertex(4);
            var e = graph.AddVertex(5);
            var f = graph.AddVertex(6);

            graph.AddUndirectionalEdge(a, b, 0);
            graph.AddUndirectionalEdge(b, c, 0);
            graph.AddUndirectionalEdge(c, d, 0);
            graph.AddUndirectionalEdge(d, e, 0);
            graph.AddUndirectionalEdge(e, f, 0);
            graph.AddUndirectionalEdge(c, a, 0);
            graph.AddUndirectionalEdge(d, b, 0);
            graph.AddUndirectionalEdge(f, d, 0);

            var expectedList = new List<int>()
            {
                1,2,3,4,5,6
            };

            // Act
            var returnFromMethod = graph.DepthFirstTraversal(a);

            var checkTheseInts = new List<int>();

            foreach (var item in returnFromMethod)
            {
                checkTheseInts.Add(item.Value);
            }

            Assert.NotNull(returnFromMethod);
            Assert.NotNull(checkTheseInts);
            Assert.Equal(expectedList, checkTheseInts);
        }

        [Fact]
        public void CanFindTheRouteFromMetrovilleToPandora()
        {
            //arrange
            Graph<string, int> graph = new Graph<string, int>();

            var Pandora = graph.AddVertex("Pandora");
            var Arendelle = graph.AddVertex("Arendelle");
            var Metroville = graph.AddVertex("Metroville");
            var Monstropolis = graph.AddVertex("Monstropolis");
            var Narnia = graph.AddVertex("Narnia");
            var Naboo = graph.AddVertex("Naboo");

            graph.AddUndirectionalEdge(Pandora, Metroville, 82);
            graph.AddUndirectionalEdge(Pandora, Arendelle, 150);
            graph.AddUndirectionalEdge(Arendelle, Metroville, 99);
            graph.AddUndirectionalEdge(Arendelle, Monstropolis, 42);
            graph.AddUndirectionalEdge(Metroville, Narnia, 37);
            graph.AddUndirectionalEdge(Metroville, Monstropolis, 105);
            graph.AddUndirectionalEdge(Metroville, Naboo, 26);
            graph.AddUndirectionalEdge(Monstropolis, Narnia, 73);
            graph.AddUndirectionalEdge(Naboo, Narnia, 250);

            Tuple<bool, int> expected = new Tuple<bool, int>(item1: true, item2: 82);

            // Act
            string[] route = { "Metroville", "Pandora" };
            var returnFromMethod = StringIntGraph.GetEdges(graph, route);

            // Assert
            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void CanFindTheRouteFromArendelleToMonsteropolisToNaboo()
        {
            //arrange
            Graph<string, int> graph = new Graph<string, int>();

            var Pandora = graph.AddVertex("Pandora");
            var Arendelle = graph.AddVertex("Arendelle");
            var Metroville = graph.AddVertex("Metroville");
            var Monstropolis = graph.AddVertex("Monstropolis");
            var Narnia = graph.AddVertex("Narnia");
            var Naboo = graph.AddVertex("Naboo");

            graph.AddUndirectionalEdge(Pandora, Metroville, 82);
            graph.AddUndirectionalEdge(Pandora, Arendelle, 150);
            graph.AddUndirectionalEdge(Arendelle, Metroville, 99);
            graph.AddUndirectionalEdge(Arendelle, Monstropolis, 42);
            graph.AddUndirectionalEdge(Metroville, Narnia, 37);
            graph.AddUndirectionalEdge(Metroville, Monstropolis, 105);
            graph.AddUndirectionalEdge(Metroville, Naboo, 26);
            graph.AddUndirectionalEdge(Monstropolis, Naboo, 73);
            graph.AddUndirectionalEdge(Naboo, Narnia, 250);

            Tuple<bool, int> expected = new Tuple<bool, int>(item1: true, item2: 115);

            // Act
            string[] route = { "Arendelle", "Monstropolis", "Naboo" };
            var returnFromMethod = StringIntGraph.GetEdges(graph, route);

            // Assert
            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }

        [Fact]
        public void CanNotFindARouteFromNabooToPandora()
        {
            //arrange
            Graph<string, int> graph = new Graph<string, int>();

            var Pandora = graph.AddVertex("Pandora");
            var Arendelle = graph.AddVertex("Arendelle");
            var Metroville = graph.AddVertex("Metroville");
            var Monstropolis = graph.AddVertex("Monstropolis");
            var Narnia = graph.AddVertex("Narnia");
            var Naboo = graph.AddVertex("Naboo");

            graph.AddUndirectionalEdge(Pandora, Metroville, 82);
            graph.AddUndirectionalEdge(Pandora, Arendelle, 150);
            graph.AddUndirectionalEdge(Arendelle, Metroville, 99);
            graph.AddUndirectionalEdge(Arendelle, Monstropolis, 42);
            graph.AddUndirectionalEdge(Metroville, Narnia, 37);
            graph.AddUndirectionalEdge(Metroville, Monstropolis, 105);
            graph.AddUndirectionalEdge(Metroville, Naboo, 26);
            graph.AddUndirectionalEdge(Monstropolis, Naboo, 73);
            graph.AddUndirectionalEdge(Naboo, Narnia, 250);

            Tuple<bool, int> expected = new Tuple<bool, int>(item1: false, item2: 0);

            // Act
            string[] route = { "Naboo", "Pandora" };
            var returnFromMethod = StringIntGraph.GetEdges(graph, route);

            // Assert
            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod);
        }
    }
}
