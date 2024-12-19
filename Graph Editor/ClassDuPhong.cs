//Dijkstra 

//using System;

//class Program
//{
//    static void Main(string[] args)
//    {
//        int[,] graph = {
//            { 0, int.MaxValue, int.MaxValue, 3  },
//            { 2, 0 ,int.MaxValue, 6 },
//            { int.MaxValue, int.MaxValue, 0, int.MaxValue },
//            { int.MaxValue, int.MaxValue, 2, 0 }
//        };

//        //Source là điểm được chọn


//        Dijkstra(graph, 0, 2);

//        Console.WriteLine("Khoảng cách từ đỉnh nguồn:");
//    }

//    static void Dijkstra(int[,] graph, int start, int end)
//    {
//        int n = graph.GetLength(0); // Số đỉnh
//        int[] distances = new int[n]; // Khoảng cách từ nguồn đến các đỉnh
//        bool[] completed = new bool[n]; // Đỉnh đã được duyệt
//        int[] save = new int[n];

//        // Khởi tạo khoảng cách ban đầu
//        for (int i = 0; i < n; i++)
//        {
//            distances[i] = int.MaxValue; // Ban đầu khoảng cách là vô cực
//            completed[i] = false; //Ban đầu chưa có phần tử nào được thăm
//            save[i] = -1; //Ban đầu không có lưu vết
//        }

//        //Đặt khoảng cách từ nó đến chính nó là 0
//        distances[start] = 0;

//        // Tạo hàng đợi ưu tiên (sử dụng Min-Heap)
//        var pq = new PriorityQueue<int, int>();
//        pq.Enqueue(start, 0);

//        while (pq.Count > 0 && !completed[end])// nếu tìm được đường đi nhỏ nhất từ start đến end hoặc hàng đợi đã hết (tức là không có đường đi từ start đến end)
//        {
//            // Lấy đỉnh có khoảng cách nhỏ nhất trong hàng đợi và xóa nó khỏi hàng đợi
//            int current = pq.Dequeue();

//            // Nếu đã duyệt (nghĩa là đã tìm được đường đi từ điểm gốc đến điểm current, bỏ qua
//            if (completed[current]) continue; 
//            completed[current] = true;

//            // Duyệt các đỉnh kề
//            for (int neighbor = 0; neighbor < n; neighbor++)
//            {
//                //Xét có đường đi giữa hai điểm và khác 0, đồng thời tổng đường đi mới phải nhỏ hơn cái cũ
//                if (graph[current, neighbor] != int.MaxValue && graph[current, neighbor] > 0 && distances[current] + graph[current, neighbor] < distances[neighbor])
//                {
//                    //Thay đổi khoảng cách của nó
//                    distances[neighbor] = distances[current] + graph[current, neighbor];
//                    // Lưu vết
//                    save[neighbor] = current;
//                    // Thêm vào hàng đợi
//                    pq.Enqueue(neighbor, distances[neighbor]);
//                }
//            }
//        }

//        // Hiển thị kết quả
//        if (distances[end] == int.MaxValue)
//        {
//            Console.WriteLine($"Không có đường đi từ {start} đến {end}");
//        }
//        else
//        {
//            Console.WriteLine($"Khoảng cách ngắn nhất từ {start} đến {end}: {distances[end]}");
//            Console.Write("Đường đi: ");
//            Stack<int> path = new Stack<int>();
//            int trace = end;
//            while (trace != -1)
//            {
//                path.Push(trace);
//                trace = save[trace];
//            }
//            Console.WriteLine(string.Join(" -> ", path));
//        }
//    }
//}

//A*
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Ma trận trọng số: int.MaxValue là không có đường đi
        int inf = int.MaxValue;
        int[,] graph = {
            { 0, 4, inf, 3 },
            { 4, 0, 5, 6 },
            { inf, 5, 0, 2 },
            { 3, 6, 2, 0 }
        };

        // Tìm đường đi từ đỉnh 0 đến đỉnh 2
        AStar(graph, 0, 2);
    }

    static void AStar(int[,] graph, int start, int end)
    {
        //Tìm số đỉnh của graph
        int n = graph.GetLength(0);
        //Thuật toán A* có sử dụng hàm f(n) = g(n) + h(n) để đánh giá khoảng cách
        //với g(n): Khoảng cách từ đỉnh bắt đầu đến đỉnh 𝑛 (chi phí thực tế).
        //h(n): Ước lượng khoảng cách từ đỉnh 𝑛 đến đích goal (đươc tính bằng ước lượng khoảng cách Mahattan hoặc Euclidean
        int[] g = new int[n]; // Chi phí từ start đến mỗi đỉnh
        int[] f = new int[n]; // f(n) = g(n) + h(n)
        int[] h = new int[n]; // Ước lượng chi phí từ đỉnh đến đích (heuristics)
        bool[] closedList = new bool[n]; // Đã duyệt
        int[] save = new int[n]; // Lưu vết đường đi

        // Hàm heuristics (h): khoảng cách Euclidean
        for (int i = 0; i < n; i++)
        {
            // Ước lượng khoảng cách Euclidean
            h[i] = (int)Math.Sqrt(Math.Pow(i - end, 2));
        }

        // Khởi tạo
        for (int i = 0; i < n; i++)
        {
            // Chưa xác định chi phí
            g[i] = int.MaxValue;
            // Cho f(n) mặc định là vô cùng
            f[i] = int.MaxValue;
            //Xét các phần là chưa được duyệt
            closedList[i] = false;
            save[i] = -1; // Không có lưu vết
        }

        g[start] = 0;
        f[start] = h[start]; // f(start) = g(start) + h(start)

        // Danh sách mở (open list) sử dụng PriorityQueue
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(start, f[start]);

        while (pq.Count > 0)
        {
            // Lấy đỉnh có f(n) nhỏ nhất
            int current = pq.Dequeue();

            // Phần tử đã được duyệt, bỏ qua
            if (closedList[current]) continue;
            closedList[current] = true;

            // Nếu tìm thấy đích, dừng
            if (current == end)
                break;

            // Duyệt các đỉnh kề
            for (int neighbor = 0; neighbor < n; neighbor++)
            {
                //Xét có đường đi giữa hai điểm và khác 0, đồng thời tổng đường đi mới phải nhỏ hơn cái cũ
                if (graph[current, neighbor] != int.MaxValue && g[current] + graph[current, neighbor] < g[neighbor]) // Nếu có cạnh
                {
                    //Thay đổi khoảng cách g(n)
                    g[neighbor] = g[current] + graph[current, neighbor];
                    //Thay đôi hàm f(n) 
                    f[neighbor] = g[neighbor] + h[neighbor];
                    // Lưu vết
                    save[neighbor] = current;
                    // Thêm vào open list
                    pq.Enqueue(neighbor, f[neighbor]);
                }
            }
        }

        // Hiển thị kết quả
        if (g[end] == int.MaxValue)
        {
            Console.WriteLine($"Không có đường đi từ {start} đến {end}");
        }
        else
        {
            Console.WriteLine($"Khoảng cách ngắn nhất từ {start} đến {end}: {g[end]}");
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
