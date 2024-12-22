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
        public static async Task Algorithm(int n, int start, int end, List<List<int>> adjList, List<Guna2CircleButton> nodes, Color defaultColor, Color visColor, Color bestNodeColor, Color completedColor, int delayMilliseconds, RichTextBox Log)
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
                    if (neighbor != end)
                    {
                        nodes[neighbor].FillColor = visColor;
                    }

                    await Task.Delay(delayMilliseconds);

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
            Log.AppendText($"Đường đi từ {start} đến {end} đã được tìm thấy.\n");
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
            Log.AppendText($"{start} -> ");
            Log.AppendText(string.Join(" -> ", S));
            Log.AppendText($" -> {end} \n");
            while (S.Count > 0)
            {
                int node = S.Pop();
                nodes[node].FillColor = completedColor;
                await Task.Delay(delayMilliseconds);
            }
        }
    }
}

