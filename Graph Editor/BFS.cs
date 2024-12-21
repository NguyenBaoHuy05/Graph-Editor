using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Graph_Editor
{
    class BFS
    {
        public static async Task Algorithm(int n, int start, int end, List<List<int>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color visColor, Color bestNodeColor, Color completedColor, int delayMilliseconds, RichTextBox Log)
        {
            Log.Clear();
            bool[] vis = new bool[n];
            int[] save = new int[n];
            Queue<int> queue = new Queue<int>();
            Array.Fill(save, -1);
            Array.Fill(vis, false);

            queue.Enqueue(start);
            vis[start] = true;
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                // If we reached the destination node
                if (node == end)
                {
                    await Reconstruct(n, start, end, save, nodes, defaultColor, completedColor, delayMilliseconds, Log);
                    return;
                }

                if (node != start && node != end)
                {
                    nodes[node].FillColor = bestNodeColor;
                }

                foreach (int neighbor in adjList[node])
                {
                    if (vis[neighbor]) continue;

                    vis[neighbor] = true;
                    save[neighbor] = node;
                    queue.Enqueue(neighbor);

                    // Change node color to visualize exploration
                    if (neighbor != end)
                    {
                        nodes[neighbor].FillColor = visColor;
                    }

                    await Task.Delay(delayMilliseconds);

                    // Revert color after delay to show it as explored
                    if (neighbor != end)
                    {
                        nodes[neighbor].FillColor = defaultColor;
                    }
                }
            }

            Log.AppendText($"Không có đường đi từ {start} đến {end}\n");
        }

        private static async Task Reconstruct(int n, int start, int end, int[] save, List<Guna2CircleButton> nodes, Color defaultColor, Color completedColor, int delayMilliseconds, RichTextBox Log)
        {
            Log.AppendText($"Khoảng cách ngắn nhất từ {start} đến {end} đã được tìm thấy.\n");
            Log.AppendText("Đường đi: ");

            // Reset all nodes to default color
            for (int i = 0; i < n; ++i)
            {
                nodes[i].FillColor = defaultColor;
            }
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;

            // Reconstruct the path from the end to the start node using the save array
            int j = end;
            Stack<int> pathStack = new Stack<int>();
            while (save[j] != -1)
            {
                pathStack.Push(j);
                j = save[j];
            }

            Log.AppendText($"{start} -> ");
            while (pathStack.Count > 0)
            {
                int node = pathStack.Pop();
                Log.AppendText($"{node} ");
                nodes[node].FillColor = completedColor;
                await Task.Delay(delayMilliseconds);
            }
            Log.AppendText("\n");
        }
    }
}

