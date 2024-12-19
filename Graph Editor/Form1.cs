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

        List<Guna2CircleButton> nodes = new List<Guna2CircleButton>();

        Guna2CircleButton firstSelectedNode = null;
        string filePath;

        Dictionary<(int, int), int> edges = new Dictionary<(int, int), int>();
        List<List<Guna2CircleButton>> adjList = new List<List<Guna2CircleButton>>();
        public Form1()
        {
            InitializeComponent();
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


                Controls.Add(btn);
                nodes.Add(btn);

                List<Guna2CircleButton> guna2Buttons = new List<Guna2CircleButton>();
                guna2Buttons.Add(btn);
                adjList.Add(guna2Buttons);
                CreateAdjMatrix();
                CreateWeiMatrix();
            }
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
                    txt.Text = edges.ContainsKey((i, j)) ? "1": "0";
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
                    txt.Text = edges.ContainsKey((i, j)) ? edges[(i, j)].ToString() : "0";
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
            int i = adjMatrixPanel.Controls.GetChildIndex(txt) / num;
            int j = adjMatrixPanel.Controls.GetChildIndex(txt) % num;

            if (txt.Text == "1")
            {
                if (!adjList[i].Contains(nodes[j]))
                {
                    adjList[i].Add(nodes[j]);
                    adjList[j].Add(nodes[i]);
                    Invalidate();
                }
            }
            else
            {
                if (adjList[i].Contains(nodes[j]))
                {
                    adjList[i].Remove(nodes[j]);
                    adjList[j].Remove(nodes[i]);
                    Invalidate();
                }
            }
        }
        private void txt_ClickWei(object sender, MouseEventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;
            var indices = (ValueTuple<int, int>)txt.Tag;
            int row = indices.Item1;
            int column = indices.Item2;
            Guna2TextBox txt1 = weiMatrixPanel.Controls[column * num + row] as Guna2TextBox;
            if (e.Button == MouseButtons.Left)
            {

                if (txt.Text == "0")
                {
                    adjList[row].Add(nodes[column]);
                    adjList[column].Add(nodes[row]);
                    edges[(row, column)] = 1;
                }
                else
                {
                    if (edges.ContainsKey((row, column)))
                    {
                        ++edges[(row, column)];
                    }
                    else
                    {
                        ++edges[(column, row)];
                    }

                }
                if (edges.ContainsKey((row, column)))
                {
                    txt.Text = edges[(row, column)].ToString();
                    txt1.Text = edges[(row, column)].ToString();
                }
                else
                {
                    txt.Text = edges[(column, row)].ToString();
                    txt1.Text = edges[(column, row)].ToString();
                }

            }
            else
            {
                if (txt.Text == "0")
                {
                    return;
                }
                else if (txt.Text == "1")
                {
                    adjList[row].RemoveAt(column);
                    adjList[column].RemoveAt(row);
                    edges.Remove((row, column));
                    txt.Text = "0";
                }
                else
                {
                    edges[(row, column)]--;
                    txt.Text = edges[(row, column)].ToString();
                }
            }
            Invalidate();
        }


        private void txt_Click(object sender, EventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;

            var indices = (ValueTuple<int, int>)txt.Tag;
            int row = indices.Item1;
            int column = indices.Item2;

            Guna2TextBox txt1 = adjMatrixPanel.Controls[column * num + row] as Guna2TextBox;

            if (txt.Text == "1")
            {
                edges.Remove((row, column));
                txt.Text = "0";
                txt1.Text = "0";
            }

            else
            {
                edges[(row, column)] = 1;
                txt.Text = "1";
                txt1.Text = "1";
            }

            Invalidate();
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
                Invalidate();
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
                        adjList[i].Add(clickedNode);
                        adjList[j].Add(firstSelectedNode);
                        Guna2TextBox txt = adjMatrixPanel.Controls.OfType<Guna2TextBox>().ElementAt(i * num + j);
                        Guna2TextBox txt1 = weiMatrixPanel.Controls.OfType<Guna2TextBox>().ElementAt(i * num + j);
                        txt.Text = "1";
                        txt1.Text = "1";
                        txt = adjMatrixPanel.Controls.OfType<Guna2TextBox>().ElementAt(j * num + i);
                        txt1 = weiMatrixPanel.Controls.OfType<Guna2TextBox>().ElementAt(j * num + i);
                        txt1.Text = "1";
                        txt.Text = "1";
                        edges[(i, j)] = 1;
                        firstSelectedNode = null;
                        Invalidate();
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            CreateNode(e.Location);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //for (int i = 0; i < adjList.Count; ++i)
            //{
            //    Guna2CircleButton node1 = nodes[i];
            //    for (int j = 0; j < adjList[i].Count; ++j)
            //    {
            //        Guna2CircleButton node2 = adjList[i][j];
            //        Point point1 = new Point(node1.Left + node1.Width / 2, node1.Top + node1.Height / 2);
            //        Point point2 = new Point(node2.Left + node2.Width / 2, node2.Top + node2.Height / 2);
            //        using (Pen pen = new Pen(Color.Black, 2))
            //        {
            //            pen.StartCap = LineCap.Round;
            //            pen.EndCap = LineCap.Round;
            //            e.Graphics.DrawLine(pen, point1, point2);
            //        }
            //    }
            //}
            foreach (var edge in edges.Keys)
            {
                var node1 = nodes[edge.Item1];
                var node2 = nodes[edge.Item2];
                Point point1 = new Point(node1.Left + node1.Width / 2, node1.Top + node1.Height / 2);
                Point point2 = new Point(node2.Left + node2.Width / 2, node2.Top + node2.Height / 2);


                using (Pen pen = new Pen(Color.Black, 2))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, point1, point2);
                }
                //Them canh
                Point midpoint = new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);


                string edgeWeight = edges[(edge.Item1, edge.Item2)].ToString();
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(edgeWeight, font, Brushes.Black, midpoint);
                }
            }
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
                        MessageBox.Show("File không đủ dữ liệu để tạo ma trận.", "Error");
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
                            if (value != 0) edges[(i, j)] = value;
                        }
                        CreateNodeRandom();
                    }

                    MessageBox.Show("File đã được tải thành công và ma trận đã được xử lý!", "Success");
                    // Tiếp tục xử lý với ma trận `edges` nếu cần
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Error");
                }
            }
            Invalidate();
            CreateAdjMatrix();
            CreateWeiMatrix();
        }

        private void CreateNodeRandom()
        {
            Random rd = new Random();
            Guna2CircleButton btn = new Guna2CircleButton();
            btn.Size = new Size(60, 60);

            btn.Location = new Point(rd.Next(50, 550), rd.Next(100, 650));
            btn.Text = num++.ToString();
            btn.MouseDown += btn_MouseDown;
            btn.MouseMove += btn_MouseMove;
            btn.MouseUp += btn_MouseUp;

            Controls.Add(btn);
            nodes.Add(btn);

            List<Guna2CircleButton> guna2Buttons = new List<Guna2CircleButton>();
            guna2Buttons.Add(btn);
            adjList.Add(guna2Buttons);
        }

        private void saveFiles(object sender, EventArgs e)
        {
            filePath = "Graph" + num.ToString();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Ghi kích thước ma trận
                writer.WriteLine(num);

                foreach(Guna2TextBox txt in weiMatrixPanel.Controls)
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
    }
}
