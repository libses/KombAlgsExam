namespace KombAlgsExam
{
    public class EdgeWithFlow : Edge, IEdgeWithFlow
    {
        public EdgeWithFlow(INode start, INode end) : base(start, end)
        {
        }

        public EdgeWithFlow(INode start, INode end, int capacity) : base(start, end)
        {
            Capacity = capacity;
        }

        public EdgeWithFlow(INode start, INode end, int capacity, int flow) : base(start, end)
        {
            Capacity = capacity;
            Flow = flow;
        }

        public int Flow { get; set; }
        public int Capacity { get; set; }
    }
}
