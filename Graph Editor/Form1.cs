﻿using Guna.UI2.WinForms;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Graph_Editor
{
    public partial class Form1 : Form
    {
        int num = 0;
        bool isDragging = false;
        Point startPos = new Point();
        Color defaultColor = Color.Black;
        List<Guna2CircleButton> nodes = new List<Guna2CircleButton>();
        List<PointF> F = new List<PointF>();
        Guna2CircleButton firstSelectedNode = null;
        Guna2CircleButton chosenNode = null;
        Guna2CircleButton draggingNode = null;
        string filePath;
        Dictionary<(int, int, Color), int> edges = new Dictionary<(int, int, Color), int>();
        List<List<int>> adjList = new List<List<int>>();

        public Form1()
        {
            InitializeComponent();
            Board.Paint += new PaintEventHandler(this.Board_Paint);
            this.DoubleBuffered = true;
            forceModeRadioBtn.Checked = true;
        }

        private void CreateNode(Point point)
        {
            if (addNodes.Checked)
            {
                Guna2CircleButton btn = new Guna2CircleButton();
                btn.Size = new Size(60, 60);
                btn.Location = point;
                btn.Click += Choosebtn;
                btn.Text = num++.ToString();
                btn.MouseDown += btn_MouseDown;
                btn.MouseMove += btn_MouseMove;
                btn.MouseUp += btn_MouseUp;
                btn.DisabledState.FillColor = Color.Gray;
                btn.DisabledState.BorderColor = Color.White;
                btn.DisabledState.ForeColor = Color.White;

                // Thiết lập vùng hiển thị hình tròn
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, btn.Width, btn.Height);
                btn.Region = new Region(path);


                Board.Controls.Add(btn);
                nodes.Add(btn);

                StartNode.Maximum = num - 1;
                EndNode.Maximum = num - 1;
                F.Add(new PointF(0, 0));

                CreateAdjMatrix();
                CreateWeiMatrix();
                ChangeText();
            }
        }
        private void CreateNodeRandom()
        {
            Random rd = new Random();
            Guna2CircleButton btn = new Guna2CircleButton();
            btn.Size = new Size(60, 60);

            btn.Location = new Point(rd.Next(50, 600), rd.Next(100, 600));
            btn.Text = num++.ToString();
            btn.Click += Choosebtn;
            btn.MouseDown += btn_MouseDown;
            btn.MouseMove += btn_MouseMove;
            btn.MouseUp += btn_MouseUp;

            btn.DisabledState.FillColor = Color.Gray;
            btn.DisabledState.BorderColor = Color.DarkGray;
            btn.DisabledState.ForeColor = Color.White;

            // Thiết lập vùng hiển thị hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);


            Board.Controls.Add(btn);
            nodes.Add(btn);
        }

        private void CreateNodeGph(Point point)
        {
            Guna2CircleButton btn = new Guna2CircleButton();
            btn.Size = new Size(60, 60);
            btn.Location = point;
            btn.Text = num++.ToString();
            btn.Click += Choosebtn;
            btn.MouseDown += btn_MouseDown;
            btn.MouseMove += btn_MouseMove;
            btn.MouseUp += btn_MouseUp;

            btn.DisabledState.FillColor = Color.Gray;
            btn.DisabledState.BorderColor = Color.DarkGray;
            btn.DisabledState.ForeColor = Color.White;

            // Thiết lập vùng hiển thị hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);


            Board.Controls.Add(btn);
            nodes.Add(btn);

        }
        private void ResetColor()
        {
            foreach (var node in nodes)
            {
                node.FillColor = Color.FromArgb(94, 148, 255);
            }
            foreach (Guna2Button btn in adjMatrixPanel.Controls)
            {
                btn.FillColor = Color.Turquoise;
            }
            foreach (Guna2Button btn in weiMatrixPanel.Controls)
            {
                btn.FillColor = Color.Turquoise;
            }
        }
        private void ChangeColor()
        {
            if (chosenNode == null) return;
            chosenNode.FillColor = Color.Gold;
            foreach (int i in adjList[int.Parse(chosenNode.Text)])
            {
                nodes[i].FillColor = Color.GreenYellow;
            }
            foreach (Guna2Button btn in adjMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)btn.Tag;
                if ((indices.Item1.ToString() == chosenNode.Text || indices.Item2.ToString() == chosenNode.Text) && btn.Text != "0" && btn.Text != "\u221E") btn.FillColor = Color.GreenYellow;
                else btn.FillColor = Color.Turquoise;
            }
            foreach (Guna2Button btn in weiMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)btn.Tag;
                if ((indices.Item1.ToString() == chosenNode.Text || indices.Item2.ToString() == chosenNode.Text) && btn.Text != "\u221E") btn.FillColor = Color.GreenYellow;
                else btn.FillColor = Color.Turquoise;
            }
        }
        private void ChangeChoosebtn(object sender, EventArgs e)
        {
            if (ChoseBtn.Checked)
            {
                return;
            }
            chosenNode = null;
            ResetColor();
        }
        private void Choosebtn(object sender, EventArgs e)
        {
            if (ChoseBtn.Checked)
            {
                Guna2CircleButton button = (Guna2CircleButton)sender;
                chosenNode = button;
                button.FillColor = Color.Gold;
                ResetColor();
                ChangeColor();
            }
        }
        private void Chosen()
        {
            ResetColor();
            ChangeColor();
        }
        private void CreateAdjMatrix()
        {
            adjMatrixPanel.Controls.Clear();
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                {
                    Guna2Button btn = new Guna2Button();
                    if (num < 8)
                    {
                        btn.Size = new Size(50, 50);
                        btn.Location = new Point(j * 50, i * 50);
                    }
                    else
                    {
                        btn.Size = new Size(adjMatrixPanel.Width / num, adjMatrixPanel.Height / num);
                        btn.Location = new Point(j * (adjMatrixPanel.Width / num), i * (adjMatrixPanel.Width / num));
                    }
                    btn.Tag = (i, j);
                    btn.FillColor = Color.Turquoise;
                    btn.ForeColor = Color.White;
                    btn.BorderColor = Color.White;
                    btn.BorderThickness = 1;
                    btn.MouseClick += btn_ClickAdj;
                    btn.DisabledState.FillColor = Color.Gray;
                    btn.DisabledState.BorderColor = Color.White;
                    btn.DisabledState.ForeColor = Color.White;
                    if (i == j)
                    {
                        btn.Enabled = false;
                    }
                    adjMatrixPanel.Controls.Add(btn);
                }
            }
        }

        private void CreateWeiMatrix()
        {
            weiMatrixPanel.Controls.Clear();
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                {
                    Guna2Button btn = new Guna2Button();
                    if (num < 8)
                    {
                        btn.Size = new Size(50, 50);
                        btn.Location = new Point(j * 50, i * 50);
                    }
                    else
                    {
                        btn.Size = new Size(weiMatrixPanel.Width / num, weiMatrixPanel.Height / num);
                        btn.Location = new Point(j * (weiMatrixPanel.Width / num), i * (weiMatrixPanel.Width / num));
                    }
                    btn.Tag = (i, j);
                    btn.FillColor = Color.Turquoise;
                    btn.ForeColor = Color.White;
                    btn.BorderColor = Color.White;
                    btn.BorderThickness = 1;
                    btn.MouseClick += btn_ClickWei;
                    btn.DisabledState.FillColor = Color.Gray;
                    btn.DisabledState.BorderColor = Color.White;
                    btn.DisabledState.ForeColor = Color.White;
                    if (i == j)
                    {
                        btn.Enabled = false;
                    }
                    weiMatrixPanel.Controls.Add(btn);
                }
            }
        }

        private void btn_ClickAdj(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            var indices = (ValueTuple<int, int>)btn.Tag;
            int row = indices.Item1;
            int column = indices.Item2;
            int max = Math.Max(row, column);
            int min = Math.Min(row, column);

            if (btn.Text == "1")
            {
                edges.Remove((min, max, defaultColor));
            }
            else
            {
                edges[(min, max, defaultColor)] = 1;
            }

            Board.Invalidate();
            ChangeText();
        }

        private void btn_ClickWei(object sender, MouseEventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            var indices = (ValueTuple<int, int>)btn.Tag;
            int row = indices.Item1;
            int column = indices.Item2;
            int max = Math.Max(row, column);
            int min = Math.Min(row, column);
            if (e.Button == MouseButtons.Left)
            {

                if (btn.Text == "\u221E")
                {

                    edges[(min, max, defaultColor)] = 1;
                }
                else
                {
                    ++edges[(min, max, defaultColor)];

                }

            }
            else
            {
                if (btn.Text == "\u221E")
                {
                    return;
                }
                else if (btn.Text == "1")
                {
                    edges.Remove((min, max, defaultColor));
                }
                else
                {
                    --edges[(min, max, defaultColor)];
                }
            }
            Board.Invalidate();
            ChangeText();
        }

        private void ChangeText()
        {
            foreach (Guna2Button btn in adjMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)btn.Tag;
                int row = indices.Item1;
                int column = indices.Item2;
                int max = Math.Max(row, column);
                int min = Math.Min(row, column);
                btn.Text = edges.ContainsKey((min, max, defaultColor)) ? "1" : "0";
            }
            foreach (Guna2Button btn in weiMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)btn.Tag;
                int row = indices.Item1;
                int column = indices.Item2;
                int max = Math.Max(row, column);
                int min = Math.Min(row, column);
                if (row == column)
                {
                    btn.Text = "0";
                }
                else
                {
                    btn.Text = edges.ContainsKey((min, max, defaultColor)) ? edges[(min, max, defaultColor)].ToString() : "\u221E";
                }

            }
            if (ChoseBtn.Checked)
            {
                LoadAdjList();
                Chosen();
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectNode.Checked)
            {
                isDragging = false;
                draggingNode = null;
            }
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectNode.Checked)
            {
                Guna2CircleButton btn = (Guna2CircleButton)sender;
                draggingNode = btn;
                var newLocation = new Point(
                    btn.Left + e.X - startPos.X,
                    btn.Top + e.Y - startPos.Y
                );
                btn.Location = newLocation;
                Board.Invalidate(); ;
            }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectNode.Checked)
            {
                isDragging = true;
                startPos = e.Location;
            }
            else if (addEdges.Checked)
            {
                var clickedNode = sender as Guna2CircleButton;

                if (firstSelectedNode == null)
                {
                    firstSelectedNode = clickedNode;
                }
                else
                {
                    if (firstSelectedNode != clickedNode)
                    {
                        int i = int.Parse(firstSelectedNode.Text);
                        int j = int.Parse(clickedNode.Text);
                        int max = Math.Max(i, j);
                        int min = Math.Min(i, j);
                        edges[(min, max, defaultColor)] = 1;
                        firstSelectedNode = null;
                        Board.Invalidate();
                    }
                }
            }
            ChangeText();
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            if (num != 0)
            {
                MessageBox.Show("Vui lòng reset!", "Dangerous", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Select a File"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                try
                {
                    var fileContent = File.ReadAllLines(filePath); // Đọc từng dòng trong file
                    if (fileContent.Length < 1)
                    {
                        MessageBox.Show("File trống hoặc không hợp lệ.", "Error");
                        return;
                    }

                    // Lấy chiều dài ma trận từ dòng đầu tiên
                    if (!int.TryParse(fileContent[0], out int length) || length < 1)
                    {
                        MessageBox.Show("Dữ liệu file không đúng định dạng. Chiều dài ma trận phải là số nguyên dương.", "Error");
                        return;
                    }

                    // Kiểm tra tổng số dòng file đủ để chứa ma trận
                    if (fileContent.Length < 1 + length)
                    {
                        MessageBox.Show("File không đủ dữ liệu để tạo graph.", "Error");
                        return;
                    }

                    // Tạo ma trận từ dữ liệu file
                    //int[,] edgesFile = new int[length, length];
                    for (int i = 0; i < length; i++)
                    {
                        var line = fileContent[i + 1].Split(' '); // Tách từng giá trị bằng dấu cách
                        if (line.Length != length)
                        {
                            MessageBox.Show($"Dòng {i + 2} không có đủ giá trị ({length} cột).", "Error");
                            return;
                        }

                        for (int j = 0; j < length; j++)
                        {
                            if (!int.TryParse(line[j], out int value))
                            {
                                MessageBox.Show($"Giá trị không hợp lệ tại dòng {i + 2}, cột {j + 1}.", "Error");
                                return;
                            }
                            int max = Math.Max(i, j);
                            int min = Math.Min(i, j);
                            if (value != 0) edges[(min, max, defaultColor)] = value;
                        }
                        CreateNodeRandom();
                    }

                    Board.Invalidate();
                    CreateAdjMatrix();
                    CreateWeiMatrix();

                    StartNode.Maximum = num - 1;
                    EndNode.Maximum = num - 1;

                    ChangeText();
                    MessageBox.Show("File đã được tải thành công và ma trận đã được xử lý!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error");
                }
            }

        }

        private void saveFiles(object sender, EventArgs e)
        {
            filePath = "Graph" + num.ToString();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Ghi kích thước ma trận
                writer.WriteLine(num);

                foreach (Guna2Button txt in weiMatrixPanel.Controls)
                {
                    var indices = (ValueTuple<int, int>)txt.Tag;
                    string content = txt.Text == "\u221E" ? "0" : txt.Text;
                    writer.Write(content);
                    if (indices.Item2 == num - 1) writer.WriteLine();
                    if (indices.Item2 < num - 1) writer.Write(" ");
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = Path.GetFileName(filePath), // Đặt tên mặc định là tên file gốc
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Save File To"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;

                try
                {
                    File.Copy(filePath, savePath, true);
                    MessageBox.Show($"File đã được lưu tại: {savePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi lưu file: {ex.Message}");
                }
            }
        }
        private void saveGph_Click(object sender, EventArgs e)
        {
            filePath = "Graph" + num.ToString();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Ghi kích thước ma trận
                writer.WriteLine(num);

                for (int i = 0; i < nodes.Count; i++)
                {
                    writer.Write(nodes[i].Location.X + " " + nodes[i].Location.Y);
                    writer.WriteLine();
                }
                writer.WriteLine(edges.Count);
                foreach (var edge in edges)
                {
                    writer.Write(edge.Key.Item1 + " " + edge.Key.Item2 + " " + edge.Value);
                    writer.WriteLine();
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = Path.GetFileName(filePath), // Đặt tên mặc định là tên file gốc
                Filter = "Text Files|*.gph|All Files|*.*",
                Title = "Save File To"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;

                try
                {
                    File.Copy(filePath, savePath, true);
                    MessageBox.Show($"File đã được lưu tại: {savePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi lưu file: {ex.Message}");
                }
            }
        }

        private void loadgph_Click(object sender, EventArgs e)
        {
            if (num != 0)
            {
                MessageBox.Show("Vui lòng reset!", "Dangerous", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.gph|All Files|*.*",
                Title = "Select a File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                try
                {
                    var fileContent = File.ReadAllLines(filePath); // Đọc từng dòng trong file
                    if (fileContent.Length < 1)
                    {
                        MessageBox.Show("File trống hoặc không hợp lệ.", "Error");
                        return;
                    }

                    // Lấy chiều dài ma trận từ dòng đầu tiên
                    if (!int.TryParse(fileContent[0], out int length) || length < 1)
                    {
                        MessageBox.Show($"Dữ liệu file không đúng định dạng. Chiều dài ma trận phải là số nguyên dương.s", "Error");
                        return;
                    }

                    // Kiểm tra tổng số dòng file đủ để chứa ma trận
                    if (fileContent.Length < 1 + length)
                    {
                        MessageBox.Show("File không đủ dữ liệu để tạo ma trận.", "Error");
                        return;
                    }

                    // Tạo ma trận từ dữ liệu files
                    for (int i = 0; i < length; i++)
                    {
                        var line = fileContent[i + 1].Split(' '); // Tách từng giá trị bằng dấu cách
                        int x = int.Parse(line[0]);
                        int y = int.Parse(line[1]);
                        CreateNodeGph(new Point(x, y));
                    }

                    int length1 = int.Parse(fileContent[1 + length]);

                    for (int i = 0; i < length1; i++)
                    {
                        var line = fileContent[i + 2 + length].Split(' '); // Tách từng giá trị bằng dấu cách
                        int x = int.Parse(line[0]);
                        int y = int.Parse(line[1]);
                        int z = int.Parse(line[2]);
                        edges[(x, y, defaultColor)] = z;
                    }

                    CreateAdjMatrix();
                    CreateWeiMatrix();
                    ChangeText();

                    StartNode.Maximum = num - 1;
                    EndNode.Maximum = num - 1;

                    Board.Invalidate();
                    MessageBox.Show("File đã được tải thành công và ma trận đã được xử lý!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error");
                }
            }
        }
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            //Board.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var edge in edges.Keys)
            {

                if (edge.Item1 > edge.Item2) continue;
                var node1 = nodes[edge.Item1];
                var node2 = nodes[edge.Item2];
                Point point1 = new Point(node1.Left + node1.Width / 2, node1.Top + node1.Height / 2);
                Point point2 = new Point(node2.Left + node2.Width / 2, node2.Top + node2.Height / 2);


                using (Pen pen = new Pen(edge.Item3, 2))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, point1, point2);
                }
                //Them canh
                Point midpoint = new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);


                string edgeWeight = edges[(edge.Item1, edge.Item2, defaultColor)].ToString();
                using (System.Drawing.Font font = new System.Drawing.Font("Robot", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(edgeWeight, font, Brushes.Chocolate, midpoint);
                }
            }
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            CreateNode(e.Location);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Board.Controls.Clear();
            adjList.Clear();
            edges.Clear();
            nodes.Clear();
            Board.Invalidate();
            adjMatrixPanel.Controls.Clear();
            weiMatrixPanel.Controls.Clear();
            num = 0;
            chosenNode = null;
        }

        private void TrackBar_Value(object sender, EventArgs e)
        {
            timeRun.Text = (TrackBar.Value).ToString() + "s";
        }

        private void ChoseAlgorithm(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            Algo.Text = toolStripMenuItem.Text.ToString();
        }

        private void btnColor(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Hiển thị hộp thoại
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Sử dụng màu được chọn
                    btn.FillColor = colorDialog.Color; // Đổi màu nền của Form
                }
            }
        }
        private void LoadAdjList()
        {
            adjList = new List<List<int>>();
            for (int i = 0; i < num; i++)
            {
                List<int> list = new List<int>();
                adjList.Add(list);
            }
            foreach (var edge in edges.Keys)
            {
                adjList[edge.Item1].Add(edge.Item2);
                adjList[edge.Item2].Add(edge.Item1);
            }
            foreach (var adj in adjList)
            {
                adj.Sort();
            }
        }
        async private void Run_Click(object sender, EventArgs e)
        {
            if (Run.Text == "Close")
            {
                for (int i = 0; i < num; ++i)
                {
                    nodes[i].FillColor = Color.FromArgb(94, 148, 255);
                }
                Board.Invalidate();
                Reset.Enabled = StartNode.Enabled = EndNode.Enabled = ChoseBtn.Enabled = addNodes.Enabled = addEdges.Enabled = true;
                Run.Text = "Run";
                return;
            }
            LoadAdjList();
            int time = TrackBar.Value * 1000;
            Color nodeColor = Color.FromArgb(94, 148, 255);
            Color visNodeColor = Color1.FillColor;
            Color bestNodeColor = Color2.FillColor;
            Color completedColor = Color3.FillColor;
            int start = int.Parse(StartNode.Value.ToString());
            int end = int.Parse(EndNode.Value.ToString());
            if (start == end && Algo.Text != "Kruskal" && Algo.Text != "Prim" && Algo.Text != "None")
            {
                MessageBox.Show("Đỉnh xuất phát không được trùng với đỉnh kết thức");
                return;
            }
            Run.Enabled = Reset.Enabled = StartNode.Enabled = EndNode.Enabled = ChoseBtn.Enabled = addNodes.Enabled = addEdges.Enabled = false;
            Dictionary<(int, int, Color), int> edgesCopy = new Dictionary<(int, int, Color), int>(edges);
            switch (Algo.Text.ToString())
            {
                case "A*":
                    await AStar.Algorithm(num, start, end, adjList, nodes, edges, nodeColor, visNodeColor, bestNodeColor, completedColor, time, Log);
                    break;
                case "Dijkstra":
                    await Dijkstra.Algorithm(num, start, end, adjList, nodes, edges, nodeColor, visNodeColor, bestNodeColor, completedColor, time, Log);
                    break;
                case "DFS":
                    await DFS.Algorithm(num, start, end, adjList, nodes, nodeColor, visNodeColor, bestNodeColor, completedColor, time, Log);
                    break;
                case "BFS":
                    await BFS.Algorithm(num, start, end, adjList, nodes, nodeColor, visNodeColor, bestNodeColor, completedColor, time, Log);
                    break;
                case "Kruskal":
                    await Kruskal.Algorithm(num, edges, visNodeColor, bestNodeColor, completedColor, time, Log, Board);
                    edges = edgesCopy;
                    break;
                case "Prim":
                    await Prim.Algorithm(num, adjList, nodes, edges, visNodeColor, bestNodeColor, completedColor, time, Log, Board);
                    edges = edgesCopy;
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn thuật toán");
                    Run.Enabled = Reset.Enabled = StartNode.Enabled = EndNode.Enabled = ChoseBtn.Enabled = addNodes.Enabled = addEdges.Enabled = true;
                    return;

            }
            MessageBox.Show("Algorithm is completed!", "Success");
            Run.Enabled = true;
            Run.Text = "Close";
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = tabControl1.SelectedIndex;
            if (idx == 3)
            {
                LoadAdjList();
                adjListShow.Clear();
                for (int i = 0; i < adjList.Count; ++i)
                {
                    adjListShow.AppendText(i.ToString() + " -> ");
                    foreach (int j in adjList[i])
                    {
                        adjListShow.AppendText($"[{j} ]");
                    }
                    adjListShow.AppendText("\n");
                }
            }
        }

        private void ApplyForce(int k, double coolingFactor, double l)
        {
            double maxForce = double.MaxValue;
            while (k > 0 && maxForce > 0.00001)
            {

                maxForce = F.Max(f => Math.Sqrt(f.X * f.X + f.Y * f.Y));
                Parallel.For(0, num, i =>
                {
                    PointF repForce = RepulsiveForce(i, l, 12);
                    PointF attrForce = AttractiveForce(i, l, 1, repForce);
                    F[i] = new PointF(repForce.X + attrForce.X, repForce.Y + attrForce.Y);
                });
                for (int i = 0; i < num; ++i)
                {
                    PointF newLocation = new PointF(
                        nodes[i].Location.X + (float)(coolingFactor * F[i].X),
                        nodes[i].Location.Y + (float)(coolingFactor * F[i].Y));
                    newLocation.X = Math.Max(0, Math.Min(Board.Width - nodes[i].Width, newLocation.X));
                    newLocation.Y = Math.Max(0, Math.Min(Board.Height - nodes[i].Height, newLocation.Y));
                    if (draggingNode == null || nodes[i].Location != draggingNode.Location)
                    {
                        nodes[i].Location = new Point((int)Math.Round(newLocation.X), (int)Math.Round(newLocation.Y));
                    }
                }
                coolingFactor *= 0.5;
                --k;
            }
        }
        private PointF RepulsiveForce(int node, double l, double crep)
        {
            PointF repForce = new PointF();
            repForce = new PointF(0, 0);
            Guna2CircleButton u = nodes[node];
            for (int i = 0; i < num; ++i)
            {
                if (i == node) continue;
                Guna2CircleButton v = nodes[i];
                PointF vu = new PointF(u.Location.X - v.Location.X, u.Location.Y - v.Location.Y);
                double distance = Math.Sqrt(vu.X * vu.X + vu.Y * vu.Y) / 148;
                double f = crep / (distance * distance);
                if (distance < 1.5)
                {
                    repForce.X += (float)(f * vu.X);
                    repForce.Y += (float)(f * vu.Y);
                }
            }
            return repForce;
        }

        private PointF AttractiveForce(int node, double l, double cspring, PointF repForce)
        {
            PointF attrForce = new PointF();
            attrForce = new PointF(0, 0);
            Guna2CircleButton u = nodes[node];
            foreach (int adjNode in adjList[node])
            {
                Guna2CircleButton v = nodes[adjNode];
                PointF uv = new PointF(v.Location.X - u.Location.X, v.Location.Y - u.Location.Y);
                double distance = Math.Sqrt(uv.X * uv.X + uv.Y * uv.Y);
                double f = cspring * Math.Log(distance / l);
                attrForce.X += (float)(f * uv.X);
                attrForce.Y += (float)(f * uv.Y);
            }
            return attrForce;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (num > 1 && forceModeRadioBtn.Checked)
            {
                LoadAdjList();
                ApplyForce(250, 0.001, 1);
                Board.Invalidate();
            }
        }
    }
}
