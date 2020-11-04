# Graph
This Data Structure demonstrates how a graph is constructed.  

## Initial Implementation Tests
1. Node can be successfully added to the graph
1. An edge can be successfully added to the graph
1. A collection of all nodes can be properly retrieved from the graph
1. All appropriate neighbors can be retrieved from the graph
1. Neighbors are returned with the weight between nodes included
1. The proper size is returned, representing the number of nodes in the graph
1. A graph with only one node and edge can be properly returned
1. An empty graph properly returns null
1. Successfully perform a breadth first traversal of all the vertices in the adjacency list.
1. Successfully perform a depth first traversal of all the vertices in the adjacency list.

## Approach & Efficiency (Adjacency List)
- AddVertex(value) - Time: O(1) | Space: O(1)
- AddDirectionalEdge(from, to, weight) - Time: O(1) | Space: O(1)
- AddUndirectionalEdge(from, to, weight) - Time: O(1) | Space: O(1)
- GetNeighbors(value) - Time: O(n) | Space: O(n)
- GetVertex(value) - Time: O(1) | Space: O(1)
- GetAllVertices() - Time: O(n) | Space: O(n)
- GetSize() - Time: O(n) | Space: O(n)
- Print() - Time: O(n) | Space: O(n)
- BreadthFirstTraversal(Vertex) - Time: O(n) | Space: O(n)
- DepthFirstTraversal(Vertex) - Time: O(n) | Space: O(n)
- FindEdges(Graph, Route) - Time: O(n) | Space: O(1)
- FindAnEge(Start, End) - Time: O(n) | Space: O(1)

## API
- AddVertex(value)
- AddDirectionalEdge(from, to, weight)
- AddUndirectionalEdge(from, to, weight)
- GetNeighbors(value) 
- GetVertex(value) 
- GetAllVertices() 
- GetSize() 
- Print() 
- BreadthFirstTraversal(Vertex)
- DepthFirstTraversal(Vertex)
- FindEdges(Graph, Route)
- FindAnEdge(Start, End)




