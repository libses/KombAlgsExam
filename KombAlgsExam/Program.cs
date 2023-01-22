namespace KombAlgsExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckTrees();
            CheckMinPath();
        }

        public static void CheckMinPath()
        {
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
            Console.WriteLine("Проверим Флойда. Он должен выдавать то же, что и Форд Беллман для 0-4");
            var floydRes = Algorithm.Floyd(minRouteGraph)[0, 4];
            Console.WriteLine("Выдаёт то же?");
            Console.WriteLine(minPathFordBellman == floydRes);
            Console.WriteLine("TopoSorted:");
            var notTopoSorted = @"-1	-1	-1	-1	1
1	-1	-1	0	-1
3	2	-1	-1	-1
-1	-1	-1	-1	0
-1	-1	-1	-1	-1";
            var autoSorted = Algorithm.TopolSort(GraphCreator.CreateGraphWithWeightFromMatrix(notTopoSorted));
            Console.WriteLine(autoSorted.GetMatrix());
            Console.WriteLine("Для нахождения пути просто запустим поиск в ширину из первой вершины. За О(m) он найдёт все расстояния");
            Console.WriteLine("Для решения задачи об максимальном пути достаточно поменять в алгоритмах больше на меньше (и наоборот) и Очень Большое Число на Очень Маленькое");
            Console.WriteLine("Но это неправда для алгоритма Дейкстры");
            var maxMinGraph = @"-1	9	10	-1	-1	-1
-1	-1	-1	4	8	-1
-1	-1	-1	3	5	-1
-1	-1	-1	-1	-1	6
-1	-1	-1	-1	-1	7
-1	-1	-1	-1	-1	-1";
            var maxMinG = GraphCreator.CreateGraphWithWeightFromMatrix(maxMinGraph);
            Console.WriteLine("Проверим maxmin");
            var maxMin = Algorithm.DijkstraMaxMin(maxMinG, 0, 5);
            Console.WriteLine("Корректен?");
            Console.WriteLine(maxMin);
            Console.WriteLine(maxMin == 7);
            Console.WriteLine();
        }

        public static void CheckTrees()
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
            Console.WriteLine();
        }
    }
}