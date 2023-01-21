namespace KombAlgsExam
{

    public class Graph
    {
        public List<INode> Nodes { get; }
        public List<IEdge> Edges { get; }

        public Graph()
        {
            Nodes = new List<INode>();
            Edges = new List<IEdge>();
        }
    }
}