namespace KombAlgsExam
{
    public interface IGraphWithWeight : IGraph
    {
        new List<IEdgeWithWeight> Edges { get; }
    }

    public class GraphWithWeight : Graph, IGraphWithWeight
    {
        public List<IEdgeWithWeight> Edges { get; }
        public GraphWithWeight() : base()
        {
            Edges = new List<IEdgeWithWeight>();
        }

        public GraphWithWeight Copy()
        {
            var graph = new GraphWithWeight();
            //НЕ КОПИРУЕЦА

            return graph;
        }

        public void RemoveNode(INode node)
        {
            Nodes.Remove(node);
            foreach (var o in node.Outgoing)
            {
                o.End.Ingoing.Remove(o);
            }

            foreach (var i in node.Ingoing)
            {
                i.Start.Outgoing.Remove(i);
            }

            node.Ingoing.Clear();
            node.Outgoing.Clear();
        }

        public void BuildUnorderedFromOrderedEdges()
        {
            if (Nodes.Count > 0)
            {
                throw new Exception("Множество вершин не пусто.");
            }

            var edges = Edges.ToArray();
            var dict = new Dictionary<Guid, INode>();
            Edges.Clear();
            var newEdges = new List<EdgeWithWeight>();
            var newREdges = new List<EdgeWithWeight>();
            foreach (var edge in edges)
            {
                if (!dict.ContainsKey(edge.Start.Id))
                {
                    var node = new Node(edge.Start.Number);
                    dict.Add(edge.Start.Id, node);
                    Nodes.Add(node);
                }

                if (!dict.ContainsKey(edge.End.Id))
                {
                    var node = new Node(edge.End.Number);
                    dict.Add(edge.End.Id, node);
                    Nodes.Add(node);
                }

                var newEdge = new EdgeWithWeight(dict[edge.Start.Id], dict[edge.End.Id], edge.Weight);
                dict[edge.Start.Id].Outgoing.Add(newEdge);
                dict[edge.End.Id].Ingoing.Add(newEdge);
                newEdges.Add(newEdge);
                var reverseEdge = new EdgeWithWeight(dict[edge.End.Id], dict[edge.Start.Id], edge.Weight);
                dict[edge.Start.Id].Ingoing.Add(reverseEdge);
                dict[edge.End.Id].Outgoing.Add(reverseEdge);
                newREdges.Add(reverseEdge);
            }

            Edges.AddRange(newEdges);
            Edges.AddRange(newREdges);
        }
    }
}