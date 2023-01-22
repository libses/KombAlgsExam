namespace KombAlgsExam
{
    public interface IGraphWithFlow : IGraph
    {
        new List<IEdgeWithFlow> Edges { get; }

        INode S { get; }
        INode T { get; }
    }
}