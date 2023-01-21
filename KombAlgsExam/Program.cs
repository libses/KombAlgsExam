namespace KombAlgsExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixForTree = @"-1	7	-1	5	-1	-1	-1
7	-1	8	9	7	-1	-1
-1	8	-1	-1	5	-1	-1
5	9	-1	-1	15	6	-1
-1	7	5	15	-1	8	9
-1	-1	-1	6	8	-1	11
-1	-1	-1	-1	9	11	-1";
            var graph = GraphCreator.CreateGraphWithWeightFromMatrix(matrixForTree);
            var boruvka = Algorithm.BoruvkaKraskal(graph);
            Console.WriteLine(boruvka.GetMatrix());
            Console.WriteLine();
            var dijkstra = Algorithm.YarnikPrimaDejkstra(graph);
            Console.WriteLine(dijkstra.GetMatrix());
            Console.WriteLine("Is Dijkstra and Boruvka same?");
            Console.WriteLine(dijkstra.GetMatrix() == boruvka.GetMatrix());
            var minRouteMatrix = @"-1	2	3	-1	-1
-1	-1	1	-1	0
4	-1	-1	1	-1
-1	-1	-1	-1	-1
-1	-1	-1	0	-1";
            var minRouteGraph = GraphCreator.CreateGraphWithWeightFromMatrix(minRouteMatrix);
            var minPathFordBellman = Algorithm.FordBellman(minRouteGraph, 0, 4);
            Console.WriteLine(minPathFordBellman);
            var minPathDijkstra = Algorithm.Dijkstra(minRouteGraph, 0, 4);
            Console.WriteLine(minPathDijkstra);
            Console.WriteLine("Is Dijkstra and FordBellman same?");
            Console.WriteLine(minPathDijkstra == minPathFordBellman);
            var notTopoSorted = @"-1	-1	-1	-1	1
1	-1	-2	0	-1
3	2	-1	-1	-1
-1	-1	-1	-1	0
-1	-1	-1	-1	-1";
            var topoSorted = @"-1	2	3	-1	-1
-1	-1	1	0	-1
-1	-1	-1	-1	1
-1	-1	-1	-1	0
-1	-1	-1	-1	-1";
            var autoSorted = Algorithm.TopolSort(GraphCreator.CreateGraphWithWeightFromMatrix(notTopoSorted));
            Console.WriteLine(autoSorted.GetMatrix());
            Console.WriteLine("Is correct?");
            Console.WriteLine(autoSorted.GetMatrix() == topoSorted);
        }
    }
}