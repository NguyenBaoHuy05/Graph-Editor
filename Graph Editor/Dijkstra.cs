using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class Dijkstra
    {
        public static async Task Algorithm(int n, int start, int end, List<List<int>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color visColor, Color bestNodeColor, Color completedColor, int delayMilliseconds, RichTextBox Log)
        {
            int[] distances = new int[n]; // Khoảng cách từ nguồn đến các đỉnh
            bool[] completed = new bool[n]; // Đỉnh đã được duyệt
            int[] save = new int[n]; // Lưu vết đường đi

            // Khởi tạo khoảng cách ban đầu
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue; // Ban đầu khoảng cách là vô cực
                completed[i] = false; // Chưa có đỉnh nào được thăm
                save[i] = -1; // Không có lưu vết
            }

            // Đặt khoảng cách từ start đến chính nó là 0
            distances[start] = 0;

            // Tạo hàng đợi ưu tiên
            var pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);

            // Đổi màu các đỉnh nguồn và đích
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;

            while (pq.Count > 0 && !completed[end]) // Khi chưa duyệt hết hoặc chưa tìm được đường đi
            {
                int current = pq.Dequeue(); // Lấy đỉnh có khoảng cách nhỏ nhất
                if(current == end)
                {
                    await Reconstruct(n, start, end, save, nodes, defaultColor, completedColor, delayMilliseconds, Log, distances);
                    return;
                }
                if (current != start && current != end) nodes[current].FillColor = bestNodeColor;

                // Nếu đỉnh đã hoàn tất, bỏ qua
                if (completed[current]) continue;
                completed[current] = true;

                // Duyệt các đỉnh kề
                foreach(int neighbor in adjList[current])
                {
                    if (completed[neighbor]) continue;
                    if(neighbor != end) nodes[neighbor].FillColor = visColor;
                    await Task.Delay(delayMilliseconds);

                    int min = Math.Min(neighbor, current);
                    int max = Math.Max(neighbor, current);
                    if (edges[(min, max, Color.Black)] > 0 &&
                       distances[current] + edges[(min, max, Color.Black)] < distances[neighbor])
                    {
                        distances[neighbor] = distances[current] + edges[(min, max, Color.Black)];
                        save[neighbor] = current; // Lưu vết
                        pq.Enqueue(neighbor, distances[neighbor]); // Thêm vào hàng đợi
                    }

                    if (neighbor != end) nodes[neighbor].FillColor = defaultColor; // Trả lại màu sau khi duyệt
                }

                await Task.Delay(delayMilliseconds);
            }
            // Hiển thị kết quả
            if (distances[end] == int.MaxValue)
            {
                Log.AppendText($"Không có đường đi từ {start} đến {end}\n");
            }
            else
            {
                Log.AppendText($"Khoảng cách ngắn nhất từ {start} đến {end}: {distances[end]}\n");
                Log.AppendText("Đường đi: ");

                Stack<int> path = new Stack<int>();
                int trace = end;
                while (trace != -1)
                {
                    path.Push(trace);
                    trace = save[trace];
                }
                Log.AppendText(string.Join(" -> ", path) + "\n");
            }
        }
        private static async Task Reconstruct(int n, int start, int end, int[] save, List<Guna2CircleButton> nodes, Color defaultColor, Color completedColor, int delayMilliseconds, RichTextBox Log, int[] g)
        {
            Log.AppendText($"Khoảng cách ngắn nhất từ {start} đến {end}: {g[end]}\n");
            Log.AppendText("Đường đi: ");
            for (int i = 0; i < n; ++i)
            {
                nodes[i].FillColor = defaultColor;
            }
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;
            int j = end;
            Stack<int> S = new Stack<int>();
            while (save[j] != start)
            {
                S.Push(save[j]);
                j = save[j];
            }
            Log.AppendText(string.Join(" -> ", S) + "\n");
            while (S.Count > 0)
            {
                int node = S.Pop();
                nodes[node].FillColor = completedColor;
                await Task.Delay(delayMilliseconds);
            }
        }
    }
}

