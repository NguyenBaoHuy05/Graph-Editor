﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Graph_Editor
{
    class AStar
    {
        public static async Task Algorithm(int n, int start, int end, List<List<Guna2CircleButton>> adjList, List<Guna2CircleButton> nodes, Dictionary<(int, int, Color), int> edges, Color defaultColor, Color visColor, Color bestNodeColor, Color completedColor, int delayMilliseconds)
        {
            int[] g = new int[n];
            double[] f = new double[n];
            double[] h = new double[n];
            bool[] vis = new bool[n];
            int[] save = new int[n];
            Array.Fill(g, int.MaxValue);
            Array.Fill(f, int.MaxValue);
            g[start] = 0;
            f[start] = 0;
            nodes[start].FillColor = Color.Red; 
            nodes[end].FillColor = Color.Green;

            for (int i = 0; i < n; ++i)
            {
                if(i != start && i != end)
                {
                    nodes[i].FillColor = defaultColor;
                }
                h[i] = Dist(nodes[i], nodes[end]);
            }
            save[start] = -1;

            var pq = new PriorityQueue<int, double>();
            pq.Enqueue(start, f[start]);

            while (pq.Count > 0)
            {
                int node = pq.Dequeue();
                if (node == end)
                {
                    await Reconstruct(n, start, end, save, nodes, defaultColor, completedColor, delayMilliseconds);
                    break;
                }

                if (node != start && node != end)
                {
                    nodes[node].FillColor = bestNodeColor;
                }

                await Task.Delay(delayMilliseconds); 

                foreach (Guna2CircleButton button in adjList[node])
                {
                    int neighbor = int.Parse(button.Text);
                    if (vis[neighbor]) continue;
                    if(neighbor != end)
                    {
                        nodes[neighbor].FillColor = visColor;
                    }
                    int weight;
                    if (edges.ContainsKey((node, neighbor, Color.Black)))
                    {
                        weight = edges[(node, neighbor, Color.Black)];
                    }
                    else
                    {
                        weight = edges[(neighbor, node, Color.Black)];
                    }

                    int dist = weight + g[node];
                    if (dist < g[neighbor])
                    {
                        save[neighbor] = node;
                        g[neighbor] = dist;
                        f[neighbor] = dist + h[neighbor];

                        pq.Enqueue(neighbor, f[neighbor]);
                    }
                    await Task.Delay(delayMilliseconds);
                    if(neighbor != end)
                    {
                        nodes[neighbor].FillColor = defaultColor;
                    }
                }

                vis[node] = true;
            }
        }
        private static async Task Reconstruct(int n, int start, int end, int[] save, List<Guna2CircleButton> nodes, Color defaultColor, Color completedColor, int delayMilliseconds)
        {
            for(int i = 0; i < n; ++i)
            {
                nodes[i].FillColor = defaultColor;
            }
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;
            int j = end;
            Stack<int> S = new Stack<int>();
            while(save[j] != start)
            {
                S.Push(save[j]);
                j = save[j];
            }
            while(S.Count > 0)
            {
                int node = S.Pop();
                nodes[node].FillColor = completedColor;
                await Task.Delay(delayMilliseconds);
            }
        }
        private static double Dist(Guna2CircleButton node1, Guna2CircleButton node2)
        {
            double x1 = node1.Location.X;
            double y1 = node1.Location.Y;
            double x2 = node2.Location.X;
            double y2 = node2.Location.Y;
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}
