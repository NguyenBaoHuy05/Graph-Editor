using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class Kruscal
    {

        public static async Task Algorithm(int n, List<List<int>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color edgeColor, Color mstEdgeColor, int delayMilliseconds, RichTextBox Log, Guna2PictureBox Board)
        {
            Log.Clear();


            List<(int, int, int)> edgeList = new List<(int, int, int)>();
            foreach (var edge in edges)
            {
                int u = edge.Key.Item1;
                int v = edge.Key.Item2;
                int weight = edge.Value;

                edgeList.Add((u, v, weight));
            }


            edgeList.Sort((x, y) => x.Item3.CompareTo(y.Item3));

            // Bước 3: Tạo cấu trúc dữ liệu disjoint-set (union-find)
            int[] parent = new int[n];
            int[] rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }


            int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]);
                }
                return parent[x];
            }


            void Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX != rootY)
                {
                    if (rank[rootX] > rank[rootY])
                    {
                        parent[rootY] = rootX;
                    }
                    else if (rank[rootX] < rank[rootY])
                    {
                        parent[rootX] = rootY;
                    }
                    else
                    {
                        parent[rootY] = rootX;
                        rank[rootX]++;
                    }
                }
            }


            List<(int, int)> mstEdges = new List<(int, int)>();
            foreach (var edge in edgeList)
            {
                int u = edge.Item1;
                int v = edge.Item2;
                int weight = edge.Item3;


                if (Find(u) != Find(v))
                {
                    Union(u, v);
                    mstEdges.Add((u, v));

                    // Hiển thị cạnh đang được thêm vào MST
                    edges[(u, v, edgeColor)] = edges[(u, v, Color.Black)];
                    Board.Invalidate();

                    await Task.Delay(delayMilliseconds);
                    edges[(u, v, mstEdgeColor)] = edges[(u, v, Color.Black)];
                    Board.Invalidate();
                    Log.AppendText($"Cạnh {u} -> {v} với trọng số {weight} đã được thêm vào MST\n");

                    await Task.Delay(delayMilliseconds);
                }
            }

            Log.AppendText("Cây khung nhỏ nhất (MST) đã được tạo:\n");
            foreach (var edge in mstEdges)
            {
                Log.AppendText($"{edge.Item1} -> {edge.Item2}\n");
            }
        }
    }
}
