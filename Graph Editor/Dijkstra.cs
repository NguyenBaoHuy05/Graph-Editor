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
    public static async Task Algorithm(
        int n, int start, int end,
        List<List<Guna2CircleButton>> adjList,
        List<Guna2CircleButton> nodes,
        Dictionary<(int, int, Color), int> edges,
        Color defaultColor, Color visColor,
        Color underVisColor,
        int delayMilliseconds, RichTextBox Log)
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

                // Nếu đỉnh đã hoàn tất, bỏ qua
                if (completed[current]) continue;
                completed[current] = true;
                if (current != start) nodes[current].FillColor = Color.GreenYellow;
                // Duyệt các đỉnh kề
                for (int neighbor = 0; neighbor < n; neighbor++)
                {
                    if (!edges.ContainsKey((current, neighbor, defaultColor))) continue;
                    if(completed[neighbor]) continue;
                    // Đổi màu đỉnh neighbor đang xét
                    nodes[neighbor].FillColor = Color.Yellow;
                    await Task.Delay(delayMilliseconds);

                    // Nếu có đường đi và khoảng cách mới nhỏ hơn khoảng cách cũ
                    if (edges[(current, neighbor, defaultColor)] > 0 &&
                        distances[current] + edges[(current, neighbor, defaultColor)] < distances[neighbor])
                    {
                        distances[neighbor] = distances[current] + edges[(current, neighbor, defaultColor)];
                        save[neighbor] = current; // Lưu vết
                        pq.Enqueue(neighbor, distances[neighbor]); // Thêm vào hàng đợi
                    }

                    nodes[neighbor].FillColor = visColor; // Trả lại màu sau khi duyệt
                }
                await Task.Delay(delayMilliseconds);
            }
            nodes[end].FillColor = Color.Green;
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

    }
}

