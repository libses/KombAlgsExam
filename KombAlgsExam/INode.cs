namespace KombAlgsExam
{
    public interface INode
    {
        Guid Id { get; }
        int Number { get; set; }
        List<IEdge> Outgoing { get; }
        List<IEdge> Ingoing { get; }
    }
}
