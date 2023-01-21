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

        }
    }
}