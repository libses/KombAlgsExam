namespace KombAlgsExam
{
    public class GraphWithFlow : Graph, IGraphWithFlow
    {
        public List<IEdgeWithFlow> Edges { get; }
        public GraphWithFlow() : base()
        {
            Edges = new List<IEdgeWithFlow>();
        }
    }
}