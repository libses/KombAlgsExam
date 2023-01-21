namespace KombAlgsExam
{
    public interface INode
    {
        Guid Id { get; }
        List<IEdge> Outgoing { get; }
        List<IEdge> Ingoing { get; }
    }
}
