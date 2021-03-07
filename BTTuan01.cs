using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTheory122020
{
    class BTTuan01
    {
        private void countDegrees(AdjacencyMatrix g, ref int[] degrees)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int count = 0;
                for (int j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[i, j];
                        if (i == j)                         // 1 canh khuyen se tao ra 1 bac vao va 1 bac ra
                            count += g.a[i, i];
                    }
                degrees[i] = count;
            }
        }
        private void countDegrees(AdjacencyMatrix g, ref int[] in_degrees, ref int[] out_degrees)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int in_count = 0, out_count = 0;
                for (int j = 0; j < g.n; ++j)
                {
                    if (g.a[i, j] != 0)
                        out_count += g.a[i, j];
                    if (g.a[j, i] != 0)
                        in_count += g.a[j, i];
                }
                in_degrees[i] = in_count;
                out_degrees[i] = out_count;
            }
        }

        private int countEdges(int[] degrees, bool isDirected)
        {
            int sum_degrees = 0;
            for (int i = 0; i < degrees.Length; ++i)
                sum_degrees += degrees[i];
            if (isDirected == false)
                return sum_degrees / 2;
            else
                return sum_degrees;
        }
        private int countMultipleEdges(AdjacencyMatrix g, bool isDirected)
        {
            int count_multiple_edges = 0;
            if (isDirected == false)
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = i; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            count_multiple_edges++;
            }
            else
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = 0; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            count_multiple_edges++;
            }
            return count_multiple_edges;
        }
        private int countLoops(AdjacencyMatrix g)
        {
            int count_loops = 0;
            for (int i = 0; i < g.n; ++i)
                count_loops += g.a[i, i];
            return count_loops;
        }
        private int countLeafVertices(int[] degrees)
        {
            int count_leaf_vertices = 0;
            for (int i = 0; i < degrees.Length; ++i)
                if (degrees[i] == 1)
                    count_leaf_vertices++;
            return count_leaf_vertices;
        }

        private int countIsolatedVertices(int[] degrees)
        {
            int count_isolated_vertices = 0;
            for (int i = 0; i < degrees.Length; ++i)
                if (degrees[i] == 0)
                    count_isolated_vertices++;
            return count_isolated_vertices;
        }
        public bool isUndirectedGraph(AdjacencyMatrix g)
        {
            // Y tuong: kiem tra ma tran ke cua do thi co phai la ma tran doi xung?
            int i, j;
            bool isSymmetric = true;
            for (i = 0; i < g.n && isSymmetric; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j) ;
                if (j < g.n)
                    isSymmetric = false;
            }
            return isSymmetric;
        }
        public void processUndirectedGraph(AdjacencyMatrix g)
        {
            // a. Xuat ma tran
            g.Show();

            // b. Xac dinh tinh co huong cua do thi
            Console.WriteLine("Do thi vo huong");

            // c. So dinh
            Console.WriteLine("So dinh cua do thi: " + g.n.ToString());

            // Khai bao bien luu tru thong tin bac cua tung dinh
            int[] degrees = new int[g.n];   // Mảng chứa bậc của các đỉnh
            countDegrees(g, ref degrees);

            // d. So luong canh
            Console.WriteLine("So canh cua do thi: " + countEdges(degrees, false).ToString()); // dinh ly bat tay Handshaking Theorem, slide 32

            // e. So canh boi va canh khuyen
            int count_multiple_edges = countMultipleEdges(g, false);
            Console.WriteLine("So cap dinh xuat hien canh boi: " + count_multiple_edges.ToString());
            int count_loops = countLoops(g);
            Console.WriteLine("So canh khuyen: " + count_loops.ToString());

            // f. So dinh treo va dinh co lap
            Console.WriteLine("So dinh treo: " + countLeafVertices(degrees).ToString());
            Console.WriteLine("So dinh co lap: " + countIsolatedVertices(degrees).ToString());

            // g. Bac cua tung dinh
            Console.WriteLine("Bac cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write(i.ToString() + "(" + degrees[i].ToString() + ") ");
            Console.WriteLine();

            // h. Loai do thi
            if (count_loops > 0)
                Console.WriteLine("Gia do thi");
            else
            {
                if (count_multiple_edges > 0)
                    Console.WriteLine("Da do thi");
                else
                    Console.WriteLine("Don do thi");
            }
        }
        public void processDirectedGraph(AdjacencyMatrix g)
        {
            // a. Xuat ma tran
            g.Show();

            // b. Xac dinh tinh co huong cua do thi
            Console.WriteLine("Do thi co huong");

            // c. So dinh
            Console.WriteLine("So dinh cua do thi: " + g.n.ToString());

            // Khai bao bien luu tru thong tin bac cua tung dinh
            int[] in_degrees = new int[g.n];               // mang chua bac ra cua dinh
            int[] out_degrees = new int[g.n];               // mang chua bac vao cua dinh
            countDegrees(g, ref in_degrees, ref out_degrees);

            // d. So luong canh
            Console.WriteLine("So canh cua do thi: " + countEdges(in_degrees, true).ToString()); // dinh ly ve so bac do thi, slide 39

            // e. So canh boi va canh khuyen
            int count_multiple_edges = countMultipleEdges(g, true);
            Console.WriteLine("So cap dinh xuat hien canh boi: " + count_multiple_edges.ToString());
            int count_loops = countLoops(g);
            Console.WriteLine("So canh khuyen: " + count_loops.ToString());

            // f. So dinh treo va dinh co lap
            int[] degrees = new int[g.n];
            for (int i = 0; i < g.n; ++i)
                degrees[i] = in_degrees[i] + out_degrees[i];
            Console.WriteLine("So dinh treo: " + countLeafVertices(degrees).ToString());
            Console.WriteLine("So dinh co lap: " + countIsolatedVertices(degrees).ToString());

            // g. Bac cua tung dinh
            Console.WriteLine("(Bac vao - Bac ra) cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write(i.ToString() + "(" + in_degrees[i].ToString() + "-" + out_degrees[i].ToString() + ") ");
            Console.WriteLine();

            // h. Loai do thi
            if (count_multiple_edges > 0)
                Console.WriteLine("Da do thi co huong");
            else
                Console.WriteLine("Do thi co huong");
        }
        public bool isFullGraph(AdjacencyMatrix g)
        {
            int i, j;
            bool isFull = true;
            for (i = 0; i < g.n && isFull; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == 1); ++j) ;
                if (j < g.n)
                    isFull = false;
            }
            return isFull;
        }
        public bool isRegularGraph(AdjacencyMatrix g, ref int k)
        {
            k = 0;
            int i, j;
            bool isRegular = true;
            for (i = 0; i < g.n; ++i)
                if (g.a[0, i] == 1)
                    k++;
            for (i = 1; i < g.n && isRegular; ++i)
            {
                int count = 0;
                for (j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                        count++;
                if (count != k)
                    isRegular = false;
            }
            return isRegular;
        }
        public bool isCycleGraph(AdjacencyMatrix g)
        {
            int k = 0;
            isRegularGraph(g, ref k);
            if (k != 2)                     // do thi vong luon luon la do thi 2-chinh quy
                return false;
            
            int[] marked = new int[g.n];         // mang danh dau cac dinh da duyet qua
            int nm = 0;
            for (int i = 0; i < g.n; ++i)
                marked[i] = 0;

            bool isCycle = true;
            int v = 0, j, next;              // bat dau xet tu dinh 0
            while (nm < g.n && isCycle)
            {
                for (j = 0; j < g.n && (g.a[v, j] == 0 || marked[j] != 0); ++j) ;
                if (j < g.n)
                {
                    next = j;
                    marked[next] = 1;
                    v = next;
                    nm++;
                }
                else
                    isCycle = false;
            }
            return isCycle;
        }
    }
}