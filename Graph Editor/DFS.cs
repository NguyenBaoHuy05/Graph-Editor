using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class DFS
    {
        public static async Task Algorithm(int n, List<List<int>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color visColor, int delayMilliseconds, RichTextBox Log, Guna2PictureBox Board)
        {
            Log.Clear();

            // Mảng đánh dấu các đỉnh đã được thăm
            bool[] visited = new bool[n];

            // Hàm đệ quy DFS
            async Task DfsRecursive(int u)
            {
                // Đánh dấu đỉnh u đã thăm
                visited[u] = true;
                nodes[u].FillColor = visColor; // Hiển thị đỉnh đã thăm

                Log.AppendText($"Đã thăm đỉnh {u}\n");
                await Task.Delay(delayMilliseconds);
                Board.Invalidate();

                // Duyệt qua các đỉnh kề của u
                foreach (int v in adjList[u])
                {
                    var edgeKey = (u, v, Color.Black);
                    if (!edges.ContainsKey(edgeKey))
                    {
                        edgeKey = (v, u, Color.Black);
                    }

                    if (edges.TryGetValue(edgeKey, out int weight) && !visited[v])
                    {
                        // Vẽ cạnh (u, v) và tiếp tục đệ quy cho v
                        edges[edgeKey] = weight;
                        Board.Invalidate();
                        await Task.Delay(delayMilliseconds);

                        Log.AppendText($"Duyệt cạnh {u} -> {v} với trọng số {weight}\n");
                        await Task.Delay(delayMilliseconds);

                        await DfsRecursive(v);  // Gọi đệ quy cho đỉnh kề
                    }
                }

                // Sau khi thăm xong các đỉnh kề, trả về màu cũ của đỉnh
                nodes[u].FillColor = Color.Blue; // Trả lại màu cũ
                 // Để hiển thị màu sắc cũ
                Board.Invalidate();
            }

            // Bắt đầu từ đỉnh 0 (hoặc có thể thay đổi cho đỉnh bất kỳ)
            await DfsRecursive(0);
        }
    }
}
