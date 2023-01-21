namespace KombAlgsExam
{

    public class Edge : IEdge
    {
        private INode node;
        private INode end1;

        public INode Start { get; }
        public INode End { get; }

        public Edge(INode start, INode end)
        {
            Start = start;
            End = end;
        }

        public Edge(INode start, INode end, INode node, INode end1) : this(start, end)
        {
            this.node = node;
            this.end1 = end1;
        }
    }
}
