namespace KombAlgsExam
{

    public class Node : INode
    {
        public List<IEdge> Outgoing { get; }

        public List<IEdge> Ingoing { get; }

        public Guid Id { get; }

        public Node()
        {
            Outgoing = new List<IEdge>();
            Ingoing = new List<IEdge>();
            Id = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            var other = (Node)obj;
            return other.Id == this.Id;
        }
    }
}
