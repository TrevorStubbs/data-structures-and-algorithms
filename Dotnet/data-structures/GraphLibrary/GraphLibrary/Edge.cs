using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class Edge<T, W>
    {
        public W Weight { get; set; }
        public Vertex<T> Vertex { get; set; }
    }
}
