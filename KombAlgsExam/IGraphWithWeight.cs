namespace KombAlgsExam
{
    public interface IGraphWithWeight : IGraph
    {
        new List<IEdgeWithWeight> Edges { get; }
    }
}