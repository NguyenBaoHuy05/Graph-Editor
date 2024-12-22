using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class Prim
    {

        public static async Task Algorithm(int n, List<List<int>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color edgeColor, Color mstEdgeColor, int delayMilliseconds, RichTextBox Log, Guna2PictureBox Board)
        {
            Log.Clear();

            // Mảng đánh dấu các đỉnh đã được thêm vào MST
            bool[] inMST = new bool[n];

            // Mảng lưu trọng số nhỏ nhất để kết nối một đỉnh với cây hiện tại
            int[] key = new int[n];

            // Mảng lưu đỉnh cha trong cây MST
            int[] parent = new int[n];

            // Khởi tạo giá trị ban đầu
            for (int i = 0; i < n; i++)
            {
                key[i] = int.MaxValue;
                parent[i] = -1;
                inMST[i] = false;
            }

            // Bắt đầu từ đỉnh đầu tiên
            key[0] = 0;
            parent[0] = -1;

            // Thực hiện n-1 bước để thêm các đỉnh vào MST
            for (int count = 0; count < n - 1; count++)
            {
                // Tìm đỉnh u chưa nằm trong MST và có trọng số nhỏ nhất
                int u = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!inMST[i] && (u == -1 || key[i] < key[u]))
                    {
                        u = i;
                    }
                }

                // Đánh dấu đỉnh u đã được thêm vào MST
                inMST[u] = true;

                // Nếu u có cha (không phải đỉnh đầu tiên), hiển thị cạnh của nó
                if (parent[u] != -1)
                {
                    int v = parent[u];

                    // Đảm bảo vô hướng: chỉ lưu một chiều cho cạnh
                    var edgeKey = (v, u, Color.Black);
                    if (!edges.ContainsKey(edgeKey))
                    {
                        edgeKey = (u, v, Color.Black);
                    }

                    edges[edgeKey] = edges[edgeKey];
                    Board.Invalidate();
                    await Task.Delay(delayMilliseconds);

                    edges[edgeKey] = edges[edgeKey];
                    Board.Invalidate();
                    Log.AppendText($"Cạnh {v} -> {u} với trọng số {key[u]} đã được thêm vào MST\n");

                    await Task.Delay(delayMilliseconds);
                }

                // Cập nhật các đỉnh kề của u
                foreach (int v in adjList[u])
                {
                    var edgeKey = (u, v, Color.Black);
                    if (!edges.ContainsKey(edgeKey))
                    {
                        edgeKey = (v, u, Color.Black);
                    }

                    if (edges.TryGetValue(edgeKey, out int weight) && !inMST[v] && weight < key[v])
                    {
                        key[v] = weight;
                        parent[v] = u;
                    }
                }
            }

            Log.AppendText("Cây khung nhỏ nhất (MST) đã được tạo:\n");
            for (int i = 1; i < n; i++)
            {
                Log.AppendText($"{parent[i]} - {i}\n");
            }
        }


    }
}
