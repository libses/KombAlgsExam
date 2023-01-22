namespace KombAlgsExam
{
    public interface IEdgeWithFlow : IEdge
    {
        int Flow { get; set; }
        int Capacity { get; set; }
    }
}
