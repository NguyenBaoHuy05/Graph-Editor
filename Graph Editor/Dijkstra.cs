using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class Dijkstra
    {
        public static void DijkstraModel(int[,] graph, int start, int end)
        {
            int n = graph.GetLength(0); // Số đỉnh
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
                    //Xét có đường đi giữa hai điểm và khác 0, đồng thời tổng đường đi mới phải nhỏ hơn cái cũ
                    if (graph[current, neighbor] != int.MaxValue && graph[current, neighbor] > 0 && distances[current] + graph[current, neighbor] < distances[neighbor])
                    {
                        //Thay đổi khoảng cách của nó
                        distances[neighbor] = distances[current] + graph[current, neighbor];
                        // Lưu vết
                        save[neighbor] = current;
                        // Thêm vào hàng đợi
                        pq.Enqueue(neighbor, distances[neighbor]);
                    }
                }
            }

            // Hiển thị kết quả
            if (distances[end] == int.MaxValue)
            {
                Console.WriteLine($"Không có đường đi từ {start} đến {end}");
            }
            else
            {
                Console.WriteLine($"Khoảng cách ngắn nhất từ {start} đến {end}: {distances[end]}");
                Console.Write("Đường đi: ");
                Stack<int> path = new Stack<int>();
                int trace = end;
                while (trace != -1)
                {
                    path.Push(trace);
                    trace = save[trace];
                }
                Console.WriteLine(string.Join(" -> ", path));
            }
        }
    }
}

