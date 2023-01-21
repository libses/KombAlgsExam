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
    }
}