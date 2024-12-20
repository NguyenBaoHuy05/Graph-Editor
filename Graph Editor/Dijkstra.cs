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
        public async static void Algorithm(int n, int start, int end, List<List<Guna2CircleButton>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color visColor, Color underVisColor, RichTextBox Log)
        {
            // n la so luong phan tu
            int[] distances = new int[n]; // Khoảng cách từ nguồn đến các đỉnh
            bool[] completed = new bool[n]; // Đỉnh đã được duyệt
            int[] save = new int[n];

            // Khởi tạo khoảng cách ban đầu
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue; // Ban đầu khoảng cách là vô cực
                completed[i] = false; //Ban đầu chưa có phần tử nào được thăm
                save[i] = -1; //Ban đầu không có lưu vết
            }

            //Đặt khoảng cách từ nó đến chính nó là 0
            distances[start] = 0;

            // Tạo hàng đợi ưu tiên (sử dụng Min-Heap)
            var pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);
            nodes[start].FillColor = visColor;

            while (pq.Count > 0 && !completed[end])// nếu tìm được đường đi nhỏ nhất từ start đến end hoặc hàng đợi đã hết (tức là không có đường đi từ start đến end)
            {
                // Lấy đỉnh có khoảng cách nhỏ nhất trong hàng đợi và xóa nó khỏi hàng đợi
                int current = pq.Dequeue();

                // Nếu đã duyệt (nghĩa là đã tìm được đường đi từ điểm gốc đến điểm current, bỏ qua
                if (completed[current]) continue;
                completed[current] = true;

                // Duyệt các đỉnh kề
                for (int neighbor = 0; neighbor < n; neighbor++)
                {
                    if (!edges.ContainsKey((current, neighbor, defaultColor))) continue;
                    await Task.Delay(100);
                    nodes[neighbor].FillColor = underVisColor;

                    //Xét có đường đi giữa hai điểm và khác 0, đồng thời tổng đường đi mới phải nhỏ hơn cái cũ
                    if (edges[(current, neighbor,defaultColor)] > 0 && distances[current] + edges[(current, neighbor, defaultColor)] < distances[neighbor])
                    {
                        //Thay đổi khoảng cách của nó
                        distances[neighbor] = distances[current] + edges[(current, neighbor, defaultColor)];
                        // Lưu vết
                        save[neighbor] = current;
                        // Thêm vào hàng đợi
                        pq.Enqueue(neighbor, distances[neighbor]);
                        await Task.Delay(100);
                        nodes[neighbor].FillColor = visColor;
                    }


                }
                await Task.Delay(200);
            }

            // Hiển thị kết quả
            if (distances[end] == int.MaxValue)
            {
                Log.AppendText($"Không có đường đi từ {start} đến {end}");
            }
            else
            {
                Log.AppendText($"Khoảng cách ngắn nhất từ {start} đến {end}: {distances[end]}");
                Log.AppendText("Đường đi: ");
                Stack<int> path = new Stack<int>();
                int trace = end;
                while (trace != -1)
                {
                    path.Push(trace);
                    trace = save[trace];
                }
                Log.AppendText(string.Join(" -> ", path));
            }
        }
    }
}

