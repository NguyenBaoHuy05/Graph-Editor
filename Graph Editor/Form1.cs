using Guna.UI2.WinForms;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;

namespace Graph_Editor
{
    public partial class Form1 : Form
    {
        int num = 0;
        bool isDragging = false;
        Point startPos = new Point();

        List<Guna2CircleButton> nodes = new List<Guna2CircleButton>();
        List<(Guna2CircleButton, Guna2CircleButton)> edges = new List<(Guna2CircleButton, Guna2CircleButton)>();

        List<List<(int, int)>> adjMatrix = new List<List<(int, int)>>();
        Guna2CircleButton firstSelectedNode = null;
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

                Controls.Add(btn);
                nodes.Add(btn);
                List<(int, int)> row = new List<(int, int)>();
                adjMatrix.Add(row);
                CreateAdjMatrix();
            }
        }
        //Loi can sua
        private void CreateAdjMatrix()
        {
            adjMatrixPanel.Controls.Clear();
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                {
                    Guna2TextBox txt = new Guna2TextBox();
                    if(num < 8)
                    {
                        txt.Size = new Size(50, 50);
                        txt.Location = new Point(j * 50, i * 50);
                    }
                    else
                    {
                        new Size(adjMatrixPanel.Width / num, adjMatrixPanel.Height / num);
                        txt.Location = new Point(j * (adjMatrixPanel.Width / num), i * (adjMatrixPanel.Width / num));
                    }
                    txt.Text = i == j ? "1" : "0";
                    txt.FillColor = Color.Turquoise;
                    txt.ForeColor = Color.White;
                    txt.BorderColor = Color.White;
                    txt.BorderThickness = 1;
                    txt.KeyPress += txt_KeyPress;
                    adjMatrixPanel.Controls.Add(txt);
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            Guna2TextBox txt = (Guna2TextBox)sender;
            adjMatrix[(txt.Width - 50) / 50][(txt.Height - 50) / 50] = (0, 1);
            adjMatrix[(txt.Height - 50) / 50][(txt.Width - 50) / 50] = (0, 1);

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
                        edges.Add((firstSelectedNode, clickedNode));
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
            // Draw edges
            foreach (var edge in edges)
            {

                var node1 = edge.Item1;
                var node2 = edge.Item2;
                Point point1 = new Point(node1.Left + node1.Width / 2, node1.Top + node1.Height / 2);
                Point point2 = new Point(node2.Left + node2.Width / 2, node2.Top + node2.Height / 2);


                using (Pen pen = new Pen(Color.Black, 2))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, point1, point2);
                }
            }
        }
    }
}
