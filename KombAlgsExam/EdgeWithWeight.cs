namespace KombAlgsExam
{
    public interface IWeighted
    {
        public int Weight { get; }
    }

    public interface IEdgeWithWeight : IWeighted, IEdge
    {
    }

    public class EdgeWithWeight : Edge, IEdgeWithWeight
    {
        public EdgeWithWeight(INode start, INode end) : base(start, end)
        {
        }

        public EdgeWithWeight(INode start, INode end, int weight) : base(start, end)
        {
            Weight = weight;
        }

        public int Weight { get; }
    }
}
