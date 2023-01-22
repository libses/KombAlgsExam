namespace KombAlgsExam
{
    public interface IGraphWithFlow : IGraph
    {
        new List<IEdgeWithFlow> Edges { get; }
    }
}