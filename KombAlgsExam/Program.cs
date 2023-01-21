namespace KombAlgsExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = @"-1	7	-1	5	-1	-1	-1
7	-1	8	9	7	-1	-1
-1	8	-1	-1	5	-1	-1
5	9	-1	-1	15	6	-1
-1	7	5	15	-1	8	9
-1	-1	-1	6	8	-1	11
-1	-1	-1	-1	9	11	-1";
            var graph = GraphCreator.CreateGraphWithWeightFromMatrix(matrix);
            var boruvka = Algorithm.BoruvkaKraskal(graph);
            Console.WriteLine(boruvka.GetMatrix());
            Console.WriteLine();
            var dijkstra = Algorithm.YarnikPrimaDejkstra(graph);
            Console.WriteLine(dijkstra.GetMatrix());
            Console.WriteLine("Is Dijkstra and Boruvka same?");
            Console.WriteLine(dijkstra.GetMatrix() == boruvka.GetMatrix());
        }
    }
}