using System.Runtime.InteropServices;

namespace KombAlgsExam
{
    public static class Algorithm
    {
        public static IGraphWithWeight BoruvkaKraskal(IGraphWithWeight graph)
        {
            var result = new GraphWithWeight();
            var orderedEdges = graph.Edges.OrderBy(x => x.Weight).ToArray();
            var set = new NonIntersectingSet<INode>();

            foreach (var edge in orderedEdges)
            {
                if (set.Add(edge.Start, edge.End))
                {
                    result.Edges.Add(edge);
                }

                if (result.Edges.Count >= graph.Nodes.Count)
                {
                    break;
                }
            }

            result.BuildUnorderedFromOrderedEdges();
            return result;
        }

        public static IGraphWithWeight YarnikPrimaDejkstra(IGraphWithWeight graph)
        {
            var result = new GraphWithWeight();
            var joined = new HashSet<INode>();
            var joinedList = new List<INode>() { graph.Nodes[0] };
            while (true)
            {
                var nextEdge = joinedList.SelectMany(x => x.Outgoing).Where(x => !joined.Contains(x.End)).MinBy(x => ((EdgeWithWeight)x).Weight);
                if (nextEdge == null)
                {
                    break;
                }

                result.Edges.Add((IEdgeWithWeight)nextEdge);
                joined.Add(nextEdge.End);
                joinedList.Add(nextEdge.End);
            }

            result.BuildUnorderedFromOrderedEdges();
            return result;
        }

        public static int FordBellman(IGraphWithWeight graph, int start, int finish)
        {
            var distances = new Dictionary<int, int>();
            foreach (var v in graph.Nodes)
            {
                distances.Add(v.Number, 1000000);
            }

            distances[start] = 0;
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    if (distances[edge.End.Number] > (distances[edge.Start.Number] + edge.Weight))
                    {
                        distances[edge.End.Number] = distances[edge.Start.Number] + edge.Weight;
                    }
                }
            }

            return distances[finish];
        }

        public static int Dijkstra(IGraphWithWeight graph, int start, int finish)
        {
            var distances = new Dictionary<int, int>();
            foreach (var v in graph.Nodes)
            {
                distances.Add(v.Number, 1000000);
            }

            distances[start] = 0;
            var visited = new HashSet<INode>();
            while (visited.Count < graph.Nodes.Count)
            {
                var current = graph.Nodes.Where(x => !visited.Contains(x)).MinBy(x => distances[x.Number]);
                foreach (var e in current.Outgoing)
                {
                    if ((distances[e.Start.Number] + ((IEdgeWithWeight)e).Weight) < distances[e.End.Number])
                    {
                        distances[e.End.Number] = distances[e.Start.Number] + ((IEdgeWithWeight)e).Weight;
                    }
                }

                visited.Add(current);
            }

            return distances[finish];
        }

        public static IGraphWithWeight TopolSort(GraphWithWeight graph)
        {
            var res = graph.Copy();
            var numberDict = res.Nodes.ToDictionary(x => x.Number, y => y);
            var temp = graph.Copy();
            var n = temp.Nodes.Count - 1;
            while (true)
            {
                var forRemove = temp.Nodes.MinBy(x => x.Outgoing.Count);
                if (forRemove == null)
                {
                    break;
                }

                temp.RemoveNode(forRemove);
                numberDict[forRemove.Number].Number = n;
                n--;
            }

            return res;
        }

        public static int DijkstraMaxMin(IGraphWithWeight graph, int start, int finish)
        {
            var distances = new Dictionary<int, int>();
            foreach (var v in graph.Nodes)
            {
                distances.Add(v.Number, -100000000);
            }

            distances[start] = 100000000;
            var visited = new HashSet<INode>();
            while (visited.Count < graph.Nodes.Count)
            {
                var current = graph.Nodes.Where(x => !visited.Contains(x)).MaxBy(x => distances[x.Number]);
                foreach (var e in current.Ingoing)
                {
                    if (Math.Min(distances[e.Start.Number], ((IEdgeWithWeight)e).Weight) > distances[e.End.Number])
                    {
                        distances[e.End.Number] = Math.Min(distances[e.Start.Number], ((IEdgeWithWeight)e).Weight);
                    }
                }

                visited.Add(current);
            }

            return distances[finish];
        }

        public static int[,] Floyd(IGraphWithWeight graph)
        {
            var n = graph.Nodes.Count;
            var D = new int[graph.Nodes.Count, graph.Nodes.Count];
            var numberToNode = graph.Nodes.ToDictionary(x => x.Number, y => y);
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                for (int j = 0; j < graph.Nodes.Count; j++)
                {
                    var second = numberToNode[i].Outgoing.Where(x => x.End.Number == j).ToArray();
                    D[i, j] = second.Length == 0 ? 1000000 : ((EdgeWithWeight)second[0]).Weight;
                }
            }

            for (var k = 0; k < n; k++)
            {
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        if (D[i, j] > (D[i, k] + D[k, j]))
                        {
                            D[i, j] = D[i, k] + D[k, j];
                        }
                    }
                }
            }

            return D;
        }
    }
}