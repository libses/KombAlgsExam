namespace KombAlgsExam
{
    public interface IGraph
    {
        public List<INode> Nodes { get; }
        public List<IEdge> Edges { get; }
    }
}