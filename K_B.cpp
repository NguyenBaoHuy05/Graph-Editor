using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kruscal_BFS
{
    class Graph
    {
        public int dinh;
        public int[,] a = new int[100, 100];
    }

    class UnionFind
    {
        private int[] parent;
        private int[] Size;

        public UnionFind(int n)
        {
            parent = new int[n];
            Size = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                Size[i] = 0;
            }
        }
        // tim dai dien
        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public void UnionSets(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                // Union by Size
                if (Size[rootX] > Size[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (Size[rootX] < Size[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    Size[rootX]++;
                }
            }
        }
    }

    class Edge
    {
        public int u, v, weight;
        public Edge(int _u, int _v, int _weight)
        {
            u = _u;
            v = _v;
            weight = _weight;
        }

        // S?p x?p c?nh theo tr?ng s?
        public static Comparison<Edge> CompareByWeight = (e1, e2) => e1.weight.CompareTo(e2.weight);
    }

    class Program
    {
        // Hàm nh?p d? th?
        static void InputGraph(ref Graph g)
        {
            g.dinh = int.Parse(Console.ReadLine());
            for (int i = 0; i < g.dinh; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < g.dinh; j++)
                {
                    g.a[i, j] = line[j];
                }
            }
        }

        // Hàm BFS
        static void BFS(Graph g, int startVertex)
        {
            bool[] visited = new bool[g.dinh];
            Queue<int> q = new Queue<int>();
            q.Enqueue(startVertex);
            visited[startVertex] = true;

            Console.WriteLine($"BFS starting from vertex {startVertex}:");
            while (q.Count > 0)
            {
                int u = q.Dequeue();
                Console.Write(u + " ");

                for (int v = 0; v < g.dinh; v++)
                {
                    if (g.a[u, v] != 0 && !visited[v])
                    {
                        q.Enqueue(v);
                        visited[v] = true;
                    }
                }
            }
            Console.WriteLine();
        }


        // Hàm Kruskal
        static void Kruskal(Graph g)
        {
            List<Edge> edges = new List<Edge>();

            // Ð?c t?t c? các c?nh t? ma tr?n k?
            for (int i = 0; i < g.dinh; i++)
            {
                for (int j = i + 1; j < g.dinh; j++) // Ch? l?y n?a trên c?a ma tr?n k? (do d? th? vô hu?ng)
                {
                    if (g.a[i, j] != 0)
                    {
                        edges.Add(new Edge(i, j, g.a[i, j]));
                    }
                }
            }

            // S?p x?p các c?nh theo tr?ng s?
            edges.Sort(Edge.CompareByWeight);

            // S? d?ng Union-Find d? t?o cây khung nh? nh?t
            UnionFind uf = new UnionFind(g.dinh);
            int mstWeight = 0;
            Console.WriteLine("Edges in the MST:");

            foreach (var edge in edges)
            {
                // N?u 2 d?nh c?a c?nh chua thu?c cùng m?t t?p h?p, thêm c?nh vào MST
                if (uf.Find(edge.u) != uf.Find(edge.v))
                {
                    uf.UnionSets(edge.u, edge.v);
                    mstWeight += edge.weight;
                    Console.WriteLine($"{edge.u} - {edge.v} (Weight: {edge.weight})");
                }
            }

            Console.WriteLine($"Total weight of MST: {mstWeight}");
        }


        static void Main(string[] args)
        {
            Graph g = new Graph();
            InputGraph(ref g); 

    
            Console.WriteLine("Enter start vertex for BFS: ");
            int startVertex = int.Parse(Console.ReadLine());
            BFS(g, startVertex);


            Kruskal(g); 
        }
    }

}


