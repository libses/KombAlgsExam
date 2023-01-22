using System.Text;

namespace KombAlgsExam
{
    public static class GraphCreator
    {
        public static GraphWithWeight CreateGraphWithWeightFromMatrix(string matrix)
        {
            var result = new GraphWithWeight();
            var lines = matrix.Split("\n").Select(x => x.Split("\t").Select(x => int.Parse(x)).ToArray()).ToArray();
            var nodes = Enumerable.Range(0, lines.Length).Select(x => new Node(x)).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                var node = nodes[i];
                result.Nodes.Add(node);
                for (int j = 0; j < lines.Length; j++)
                {
                    var other = nodes[j];
                    if (lines[i][j] != -1)
                    {
                        var edge = new EdgeWithWeight(node, other, lines[i][j]);
                        node.Outgoing.Add(edge);
                        other.Ingoing.Add(edge);
                        result.Edges.Add(edge);
                    }
                }
            }

            return result;
        }

        public static string GetMatrix(this IGraphWithWeight graph)
        {
            var i = 0;
            var nodeToNumber = graph.Nodes.ToDictionary(x => x, y => y.Number);
            var result = new int[nodeToNumber.Count][];
            foreach (var node in graph.Nodes)
            {
                var firstNumber = nodeToNumber[node];
                result[firstNumber] = new int[nodeToNumber.Count];
                for (int j = 0; j < nodeToNumber.Count; j++)
                {
                    result[firstNumber][j] = -1;
                }

                foreach (var outgoing in node.Outgoing)
                {
                    var secondNumber = nodeToNumber[outgoing.End];
                    result[firstNumber][secondNumber] = ((IEdgeWithWeight)outgoing).Weight;
                }
            }

            var strResult = new StringBuilder();
            foreach (var row in result)
            {
                strResult.AppendLine(string.Join("\t", row));
            }
            strResult.Remove(strResult.Length - 1, 1);
            return strResult.ToString();
        }
    }
}