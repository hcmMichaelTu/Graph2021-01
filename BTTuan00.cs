using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTheory122020
{
    class BTTuan00
    {
        public void displayAdjacencyMatrix(string filename)
        {
            AdjacencyMatrix am = new AdjacencyMatrix(filename);
            am.Show();

            bool isSymmetric = true;
            for (int i = 0; i < am.n && isSymmetric; ++i)
            {
                int j;
                for (j = i + 1; j < am.n && am.a[i, j] == am.a[j, i]; ++j) ;
                if (j < am.n)
                    isSymmetric = false;
            }
            if (isSymmetric == false)
                Console.WriteLine("Ma tran khong doi xung");
            else
                Console.WriteLine("Ma tran doi xung");
        }
        public void displayAdjacencyList(string filename)
        {
            AdjacencyList al = new AdjacencyList(filename);
            al.Show();
            bool isUndirected = true;
            for (int i = 0; i < al.n && isUndirected; ++i)
            {
                int j;
                for (j = 0; j < al.a[i].Count && al.a[al.a[i][j]].Contains(i); ++j) ;
                if (j < al.a[i].Count)
                    isUndirected = false;
            }
            if (isUndirected == false)
                Console.WriteLine("Danh sach ke bieu dien do thi mot chieu");
            else
                Console.WriteLine("Danh sach ke bieu dien do thi hai chieu");
        }
        public void convertMatrixToList(string namein, string nameout)
        {
            AdjacencyMatrix am = new AdjacencyMatrix(namein);
            AdjacencyList al = new AdjacencyList();
            al.n = am.n;
            al.a = new List<int>[al.n];
            for (int i = 0; i < am.n; ++i)
            {
                al.a[i] = new List<int>();
                for (int j = 0; j < am.n; ++j)
                    if (am.a[i, j] != 0)
                        al.a[i].Add(j);
            }
            // write to file
            string content = al.n.ToString();
            for (int i = 0; i < al.n; ++i)
            {
                string s = Environment.NewLine + al.a[i].Count.ToString();
                for (int j = 0; j < al.a[i].Count; ++j)
                    s = s + " " + al.a[i][j].ToString();
                content = content + s;
            }
            System.IO.File.WriteAllText(nameout, content);
            Console.WriteLine("Da chuyen tu ma tran ke sang danh sach ke");
        }
        public void convertListToMatrix(string namein, string nameout)
        {
            AdjacencyList al = new AdjacencyList(namein);
            AdjacencyMatrix am = new AdjacencyMatrix();
            am.n = al.n;
            am.a = new int[am.n, am.n];
            Array.Clear(am.a, 0, am.a.Length);
            for (int i = 0; i < am.n; ++i)
            {
                for (int j = 0; j < al.a[i].Count; ++j)
                    am.a[i,al.a[i][j]] = 1;
            }
            // write to file
            string content = am.n.ToString();
            for (int i = 0; i < am.n; ++i)
            {
                string s = Environment.NewLine;
                for (int j = 0; j < am.n; ++j)
                    s = s + am.a[i,j].ToString() + " ";
                content = content + s;
            }
            System.IO.File.WriteAllText(nameout, content);
            Console.WriteLine("Da chuyen tu danh sach ke sang ma tran ke");
        }
    }
}
