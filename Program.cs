using System;

namespace GraphTheory122020
{
    class Program
    {
        static void Main(string[] args)
        {
            //BTTuan00 bt = new BTTuan00();

            //bt.displayAdjacencyMatrix("d:/adjacency-matrix1.txt");
            //bt.displayAdjacencyMatrix("d:/adjacency-matrix2.txt");

            //bt.displayAdjacencyList("d:/adjacency-list1.txt");
            //bt.displayAdjacencyList("d:/adjacency-list2.txt");

            //bt.convertMatrixToList("d:/adjacency-matrix1.txt", "d:/adjacency-list-out1.txt");
            //bt.convertMatrixToList("d:/adjacency-matrix2.txt", "d:/adjacency-list-out2.txt");

            //bt.convertListToMatrix("d:/adjacency-list1.txt", "d:/adjacency-matrix-out1.txt");
            //bt.convertListToMatrix("d:/adjacency-list2.txt", "d:/adjacency-matrix-out2.txt");

            BTTuan01 bt = new BTTuan01();
            AdjacencyMatrix g1 = new AdjacencyMatrix();
            g1.Read("input-vd-1-1.txt");
            // Thuc hien b. den h.
            if (bt.isUndirectedGraph(g1) == true)
                bt.processUndirectedGraph(g1);
            else
                bt.processDirectedGraph(g1);
            Console.WriteLine();

            AdjacencyMatrix g2 = new AdjacencyMatrix();
            g2.Read("input-vd-1-2.txt");
            // Thuc hien b. den h.
            if (bt.isUndirectedGraph(g2) == true)
                bt.processUndirectedGraph(g2);
            else
                bt.processDirectedGraph(g2);
            Console.WriteLine();

            AdjacencyMatrix g3 = new AdjacencyMatrix();
            g3.Read("input-K3C3R2.txt");
            if (bt.isFullGraph(g3))
                Console.WriteLine("Day la do thi day du K" + g3.n.ToString());
            else
                Console.WriteLine("Day khong phai la do thi day du");
            int k1 = 0;
            if (bt.isRegularGraph(g3, ref k1))
                Console.WriteLine("Day la do thi " + k1.ToString()+ "-chinh quy");
            else
                Console.WriteLine("Day khong phai la do thi chinh quy");
            if(bt.isCycleGraph(g3))
                Console.WriteLine("Day la do thi vong C" + g3.n.ToString());
            else
                Console.WriteLine("Day khong phai la do thi vong");
            Console.WriteLine();

            AdjacencyMatrix g4 = new AdjacencyMatrix();
            g4.Read("input-C6R2.txt");
            if (bt.isFullGraph(g4))
                Console.WriteLine("Day la do thi day du K" + g4.n.ToString());
            else
                Console.WriteLine("Day khong phai la do thi day du");
            int k2 = 0;
            if (bt.isRegularGraph(g4, ref k2))
                Console.WriteLine("Day la do thi " + k2.ToString() + "-chinh quy");
            else
                Console.WriteLine("Day khong phai la do thi chinh quy");
            if (bt.isCycleGraph(g4))
                Console.WriteLine("Day la do thi vong C" + g4.n.ToString());
            else
                Console.WriteLine("Day khong phai la do thi vong");
        }
    }
}
