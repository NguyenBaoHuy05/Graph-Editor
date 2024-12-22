using Guna.UI2.WinForms;
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

        Guna2CircleButton firstSelectedNode = null;
        string filePath;

        Dictionary<(int, int, Color), int> edges = new Dictionary<(int, int, Color), int>();
        List<List<int>> adjList = new List<List<int>>();
        public Form1()
        {
            InitializeComponent();
            Board.Paint += new PaintEventHandler(this.Board_Paint);
        }

        private void CreateNode(Point point)
        {
            if (addNodes.Checked)
            {
                Guna2CircleButton btn = new Guna2CircleButton();
                btn.Size = new Size(60, 60);
                btn.Location = point;
                btn.Text = num++.ToString();
                btn.MouseDown += btn_MouseDown;
                btn.MouseMove += btn_MouseMove;
                btn.MouseUp += btn_MouseUp;

                // Thiết lập vùng hiển thị hình tròn
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, btn.Width, btn.Height);
                btn.Region = new Region(path);


                Board.Controls.Add(btn);
                nodes.Add(btn);

                StartNode.Maximum = num - 1;
                EndNode.Maximum = num - 1;


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
            btn.MouseDown += btn_MouseDown;
            btn.MouseMove += btn_MouseMove;
            btn.MouseUp += btn_MouseUp;

            // Thiết lập vùng hiển thị hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);


            Board.Controls.Add(btn);
            nodes.Add(btn);

            StartNode.Maximum = num - 1;
            EndNode.Maximum = num - 1;

            CreateAdjMatrix();
            CreateWeiMatrix();
            ChangeText();

        }

        private void CreateNodeGph(Point point)
        {
            Guna2CircleButton btn = new Guna2CircleButton();
            btn.Size = new Size(60, 60);
            btn.Location = point;
            btn.Text = num++.ToString();
            btn.MouseDown += btn_MouseDown;
            btn.MouseMove += btn_MouseMove;
            btn.MouseUp += btn_MouseUp;

            // Thiết lập vùng hiển thị hình tròn
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);


            Board.Controls.Add(btn);
            nodes.Add(btn);

            StartNode.Maximum = num - 1;
            EndNode.Maximum = num - 1;
            CreateAdjMatrix();
            CreateWeiMatrix();
            ChangeText();
        }
        private void CreateAdjMatrix()
        {
            adjMatrixPanel.Controls.Clear();
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                {
                    Guna2TextBox txt = new Guna2TextBox();
                    if (num < 8)
                    {
                        txt.Size = new Size(50, 50);
                        txt.Location = new Point(j * 50, i * 50);
                    }
                    else
                    {
                        txt.Size = new Size(adjMatrixPanel.Width / num, adjMatrixPanel.Height / num);
                        txt.Location = new Point(j * (adjMatrixPanel.Width / num), i * (adjMatrixPanel.Width / num));
                    }
                    txt.Tag = (i, j);
                    txt.FillColor = Color.Turquoise;
                    txt.ForeColor = Color.White;
                    txt.BorderColor = Color.White;
                    txt.BorderThickness = 1;
                    txt.Click += txt_Click;
                    txt.TextChanged += txt_TextChanged;
                    if (i == j)
                    {
                        txt.Enabled = false;
                    }
                    adjMatrixPanel.Controls.Add(txt);
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
                    Guna2TextBox txt = new Guna2TextBox();
                    if (num < 8)
                    {
                        txt.Size = new Size(50, 50);
                        txt.Location = new Point(j * 50, i * 50);
                    }
                    else
                    {
                        txt.Size = new Size(weiMatrixPanel.Width / num, weiMatrixPanel.Height / num);
                        txt.Location = new Point(j * (int)(weiMatrixPanel.Width / num), i * (int)(weiMatrixPanel.Width / num));
                    }
                    txt.Tag = (i, j);
                    txt.FillColor = Color.Turquoise;
                    if (i == j) txt.Enabled = false;
                    txt.ForeColor = Color.White;
                    txt.BorderColor = Color.White;
                    txt.BorderThickness = 1;
                    txt.MouseClick += txt_ClickWei;
                    weiMatrixPanel.Controls.Add(txt);
                }
            }
        }
        private void txt_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;
            var indices = (ValueTuple<int, int>)txt.Tag;
            int row = indices.Item1;
            int column = indices.Item2;

            int max = Math.Max(row, column);
            int min = Math.Min(row, column);
            if (txt.Text == "1")
            {
                if (!edges.ContainsKey((min, max, defaultColor)))
                {
                    edges[(min, max, defaultColor)] = 1;
                    Board.Invalidate();
                }
            }
            else
            {
                if (!edges.ContainsKey((min, max, defaultColor)))
                {
                    edges.Remove((min, max, defaultColor));
                    Board.Invalidate();
                }
            }
            ChangeText();
        }
        private void txt_ClickWei(object sender, MouseEventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;
            var indices = (ValueTuple<int, int>)txt.Tag;
            int row = indices.Item1;
            int column = indices.Item2;
            int max = Math.Max(row, column);
            int min = Math.Min(row, column);
            if (e.Button == MouseButtons.Left)
            {

                if (txt.Text == "\u221E")
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
                if (txt.Text == "\u221E")
                {
                    return;
                }
                else if (txt.Text == "1")
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

        private void txt_Click(object sender, EventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;

            var indices = (ValueTuple<int, int>)txt.Tag;
            int row = indices.Item1;
            int column = indices.Item2;
            int max = Math.Max(row, column);
            int min = Math.Min(row, column);

            if (txt.Text == "1")
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

        private void ChangeText()
        {
            foreach (Guna2TextBox txt in adjMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)txt.Tag;
                int row = indices.Item1;
                int column = indices.Item2;
                int max = Math.Max(row, column);
                int min = Math.Min(row, column);
                if (edges.ContainsKey((min, max, defaultColor))) txt.Text = "1";
                else txt.Text = "0";
            }
            foreach (Guna2TextBox txt in weiMatrixPanel.Controls)
            {
                var indices = (ValueTuple<int, int>)txt.Tag;
                int row = indices.Item1;
                int column = indices.Item2;
                int max = Math.Max(row, column);
                int min = Math.Min(row, column);
                if (edges.ContainsKey((min, max, defaultColor))) txt.Text = edges[(min, max, defaultColor)].ToString();
                else txt.Text = "\u221E";
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectNode.Checked)
            {
                isDragging = false;
            }
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectNode.Checked)
            {
                Guna2CircleButton btn = (Guna2CircleButton)sender;
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

                    MessageBox.Show("File đã được tải thành công và ma trận đã được xử lý!", "Success");
                    Board.Invalidate();
                    CreateAdjMatrix();
                    CreateWeiMatrix();
                    ChangeText();
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

                foreach (Guna2TextBox txt in weiMatrixPanel.Controls)
                {
                    var indices = (ValueTuple<int, int>)txt.Tag;
                    writer.Write(txt.Text);
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

                    MessageBox.Show("File đã được tải thành công và ma trận đã được xử lý!", "Success");
                    CreateAdjMatrix();
                    CreateWeiMatrix();
                    ChangeText();
                    Board.Invalidate();
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
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(edgeWeight, font, Brushes.Black, midpoint);
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
            edges.Clear();
            nodes.Clear();
            Board.Invalidate();
            adjMatrixPanel.Controls.Clear();
            weiMatrixPanel.Controls.Clear();
            num = 0;
        }

        private void TrackBar_Value(object sender, EventArgs e)
        {
            timeRun.Text = (TrackBar.Value).ToString() + "s";
        }

        private void ChoseAlgorithm(object sender, EventArgs e)
        {
            Algo.Text = sender.ToString();
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
        }
        async private void Run_Click(object sender, EventArgs e)
        {
            LoadAdjList();
            int time = TrackBar.Value * 1000;
            Color nodeColor = Color.FromArgb(94, 148, 255);
            Color visNodeColor = Color1.FillColor;
            Color bestNodeColor = Color2.FillColor;
            Color completedColor = Color3.FillColor;
            int start = int.Parse(StartNode.Value.ToString());
            int end = int.Parse(EndNode.Value.ToString());
            await DFS.Algorithm(num, start, end, adjList, nodes, nodeColor, visNodeColor, bestNodeColor, completedColor, time, Log);
        }
    }
}
