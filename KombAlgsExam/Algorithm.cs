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
                foreach (var e in current.Ingoing)
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
                var forRemove = temp.Nodes.MinBy(x => x.Ingoing.Count);
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
    }
}