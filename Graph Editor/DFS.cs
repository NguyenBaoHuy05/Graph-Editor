﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Editor
{
    internal class DFS
    {
        public static async Task Algorithm(int n, int start, int end, List<List<int>> adjList, List<Guna2CircleButton> nodes, Color defaultColor, Color visColor, Color bestColor, Color completedColor, int delayMilliseconds, RichTextBox Log)
        {
            Log.Clear();
            nodes[start].FillColor = Color.Red;
            nodes[end].FillColor = Color.Green;
            bool[] visited = new bool[n];
            int[] save = new int[n];
            Array.Fill(save, -1);
            Array.Fill(visited, false);
            async Task<bool> DfsRecursive(int u)
            {
                if(u == end)
                {
                    await Reconstruct(n, start, end, save, nodes, defaultColor, completedColor, delayMilliseconds, Log);
                    return true;
                }
                if (u != start)
                {
                    nodes[u].FillColor = bestColor;
                }
                visited[u] = true;
                await Task.Delay(delayMilliseconds);
                foreach (int v in adjList[u])
                {
                    if (!visited[v])
                    {
                        save[v] = u;
                        if(v != start && v != end)
                        {
                            nodes[v].FillColor = visColor;
                        }
                        await Task.Delay(delayMilliseconds);
                        if(await DfsRecursive(v))
                        {
                            return true;
                        } 
                    }
                }
                nodes[u].FillColor = defaultColor;
                return false;
            }
            await DfsRecursive(start);
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
