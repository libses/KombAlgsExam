namespace KombAlgsExam
{

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
