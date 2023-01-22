namespace KombAlgsExam
{
    public class GraphWithFlow : Graph, IGraphWithFlow
    {
        public List<IEdgeWithFlow> Edges { get; }
        public INode S { get; }
        public INode T { get; }
        public GraphWithFlow() : base()
        {
            Edges = new List<IEdgeWithFlow>();
        }

        public GraphWithFlow(INode s, INode t) : base()
        {
            Edges = new List<IEdgeWithFlow>();
            S = s;
            T = t;
        }
    }
}