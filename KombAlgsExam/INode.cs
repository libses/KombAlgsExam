namespace KombAlgsExam
{
    public interface INode
    {
        Guid Id { get; }
        int Number { get; }
        List<IEdge> Outgoing { get; }
        List<IEdge> Ingoing { get; }
    }
}
