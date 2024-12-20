namespace Graph_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            adjMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            tabPage7 = new TabPage();
            weiMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            tabPage8 = new TabPage();
            richTextBox1 = new RichTextBox();
            tabPage9 = new TabPage();
            richTextBox2 = new RichTextBox();
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            selectNode = new RadioButton();
            addEdges = new RadioButton();
            addNodes = new RadioButton();
            panel1 = new Panel();
            Reset = new Button();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveGph = new ToolStripMenuItem();
            savetxtToolStripMenuItem = new ToolStripMenuItem();
            loadFile = new ToolStripMenuItem();
            loadgph = new ToolStripMenuItem();
            loadtxtToolStripMenuItem = new ToolStripMenuItem();
            dFSToolStripMenuItem = new ToolStripMenuItem();
            dFSToolStripMenuItem1 = new ToolStripMenuItem();
            bFSToolStripMenuItem = new ToolStripMenuItem();
            dijkstraToolStripMenuItem = new ToolStripMenuItem();
            aToolStripMenuItem = new ToolStripMenuItem();
            primToolStripMenuItem = new ToolStripMenuItem();
            kruscalToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            Board = new Guna.UI2.WinForms.Guna2PictureBox();
            tabControl2 = new TabControl();
            tabPage10 = new TabPage();
            tabPage11 = new TabPage();
            tabPage12 = new TabPage();
            tabPage13 = new TabPage();
            tabPage14 = new TabPage();
            tabPage15 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage7.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage9.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Board).BeginInit();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Controls.Add(tabPage9);
            tabControl1.Location = new Point(743, 259);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(464, 492);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DarkGray;
            tabPage2.Controls.Add(adjMatrixPanel);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(456, 456);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Adjacency Matrix";
            // 
            // adjMatrixPanel
            // 
            adjMatrixPanel.CustomizableEdges = customizableEdges1;
            adjMatrixPanel.Dock = DockStyle.Fill;
            adjMatrixPanel.Location = new Point(3, 3);
            adjMatrixPanel.Name = "adjMatrixPanel";
            adjMatrixPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            adjMatrixPanel.Size = new Size(450, 450);
            adjMatrixPanel.TabIndex = 0;
            // 
            // tabPage7
            // 
            tabPage7.BackColor = Color.DarkGray;
            tabPage7.Controls.Add(weiMatrixPanel);
            tabPage7.Location = new Point(4, 32);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(456, 456);
            tabPage7.TabIndex = 1;
            tabPage7.Text = "Weighted Matrix";
            // 
            // weiMatrixPanel
            // 
            weiMatrixPanel.CustomizableEdges = customizableEdges3;
            weiMatrixPanel.Dock = DockStyle.Fill;
            weiMatrixPanel.Location = new Point(3, 3);
            weiMatrixPanel.Name = "weiMatrixPanel";
            weiMatrixPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            weiMatrixPanel.Size = new Size(450, 450);
            weiMatrixPanel.TabIndex = 1;
            // 
            // tabPage8
            // 
            tabPage8.BackColor = Color.White;
            tabPage8.Controls.Add(richTextBox1);
            tabPage8.Location = new Point(4, 32);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(456, 456);
            tabPage8.TabIndex = 2;
            tabPage8.Text = "Adjacency List";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(456, 456);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(richTextBox2);
            tabPage9.Location = new Point(4, 32);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(3);
            tabPage9.Size = new Size(456, 456);
            tabPage9.TabIndex = 3;
            tabPage9.Text = "Log";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            richTextBox2.Dock = DockStyle.Fill;
            richTextBox2.Location = new Point(3, 3);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(450, 450);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "";
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(384, 162);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(242, 75);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 46);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(242, 75);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 46);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(242, 75);
            tabPage5.TabIndex = 0;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 46);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(242, 75);
            tabPage6.TabIndex = 1;
            tabPage6.Text = "tabPage6";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // selectNode
            // 
            selectNode.AutoSize = true;
            selectNode.Location = new Point(138, 9);
            selectNode.Name = "selectNode";
            selectNode.Size = new Size(114, 24);
            selectNode.TabIndex = 3;
            selectNode.TabStop = true;
            selectNode.Text = "Select nodes";
            selectNode.UseVisualStyleBackColor = true;
            // 
            // addEdges
            // 
            addEdges.AutoSize = true;
            addEdges.Location = new Point(13, 9);
            addEdges.Name = "addEdges";
            addEdges.Size = new Size(102, 24);
            addEdges.TabIndex = 2;
            addEdges.TabStop = true;
            addEdges.Text = "Add edges";
            addEdges.UseVisualStyleBackColor = true;
            // 
            // addNodes
            // 
            addNodes.AutoSize = true;
            addNodes.Location = new Point(275, 9);
            addNodes.Name = "addNodes";
            addNodes.Size = new Size(102, 24);
            addNodes.TabIndex = 4;
            addNodes.TabStop = true;
            addNodes.Text = "Add nodes";
            addNodes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(Reset);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(addNodes);
            panel1.Controls.Add(addEdges);
            panel1.Controls.Add(selectNode);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(733, 40);
            panel1.TabIndex = 5;
            // 
            // Reset
            // 
            Reset.BackColor = Color.Cyan;
            Reset.Location = new Point(624, 7);
            Reset.Name = "Reset";
            Reset.Size = new Size(70, 28);
            Reset.TabIndex = 8;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = false;
            Reset.Click += Reset_Click;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(525, 9);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(96, 24);
            radioButton2.TabIndex = 7;
            radioButton2.TabStop = true;
            radioButton2.Text = "End Node";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(400, 9);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(102, 24);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "Start Node";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveFile, loadFile });
            saveToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            saveToolStripMenuItem.ForeColor = Color.Black;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(61, 29);
            saveToolStripMenuItem.Text = "&File";
            // 
            // saveFile
            // 
            saveFile.DropDownItems.AddRange(new ToolStripItem[] { saveGph, savetxtToolStripMenuItem });
            saveFile.Name = "saveFile";
            saveFile.Size = new Size(148, 30);
            saveFile.Text = "&Save";
            // 
            // saveGph
            // 
            saveGph.Name = "saveGph";
            saveGph.Size = new Size(196, 30);
            saveGph.Text = "Save .gph";
            saveGph.Click += saveGph_Click;
            // 
            // savetxtToolStripMenuItem
            // 
            savetxtToolStripMenuItem.Name = "savetxtToolStripMenuItem";
            savetxtToolStripMenuItem.Size = new Size(196, 30);
            savetxtToolStripMenuItem.Text = "Save .txt";
            savetxtToolStripMenuItem.Click += saveFiles;
            // 
            // loadFile
            // 
            loadFile.DropDownItems.AddRange(new ToolStripItem[] { loadgph, loadtxtToolStripMenuItem });
            loadFile.Name = "loadFile";
            loadFile.Size = new Size(148, 30);
            loadFile.Text = "&Load";
            // 
            // loadgph
            // 
            loadgph.Name = "loadgph";
            loadgph.Size = new Size(194, 30);
            loadgph.Text = "Load .gph";
            loadgph.Click += loadgph_Click;
            // 
            // loadtxtToolStripMenuItem
            // 
            loadtxtToolStripMenuItem.Name = "loadtxtToolStripMenuItem";
            loadtxtToolStripMenuItem.Size = new Size(194, 30);
            loadtxtToolStripMenuItem.Text = "Load .txt";
            loadtxtToolStripMenuItem.Click += loadFile_Click;
            // 
            // dFSToolStripMenuItem
            // 
            dFSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dFSToolStripMenuItem1, bFSToolStripMenuItem, dijkstraToolStripMenuItem, aToolStripMenuItem, primToolStripMenuItem, kruscalToolStripMenuItem });
            dFSToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            dFSToolStripMenuItem.ForeColor = Color.Black;
            dFSToolStripMenuItem.Name = "dFSToolStripMenuItem";
            dFSToolStripMenuItem.Size = new Size(128, 29);
            dFSToolStripMenuItem.Text = "&Algorithms";
            // 
            // dFSToolStripMenuItem1
            // 
            dFSToolStripMenuItem1.Name = "dFSToolStripMenuItem1";
            dFSToolStripMenuItem1.Size = new Size(171, 30);
            dFSToolStripMenuItem1.Text = "DFS";
            // 
            // bFSToolStripMenuItem
            // 
            bFSToolStripMenuItem.Name = "bFSToolStripMenuItem";
            bFSToolStripMenuItem.Size = new Size(171, 30);
            bFSToolStripMenuItem.Text = "BFS";
            // 
            // dijkstraToolStripMenuItem
            // 
            dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            dijkstraToolStripMenuItem.Size = new Size(171, 30);
            dijkstraToolStripMenuItem.Text = "Dijkstra";
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(171, 30);
            aToolStripMenuItem.Text = "A*";
            // 
            // primToolStripMenuItem
            // 
            primToolStripMenuItem.Name = "primToolStripMenuItem";
            primToolStripMenuItem.Size = new Size(171, 30);
            primToolStripMenuItem.Text = "Prim";
            // 
            // kruscalToolStripMenuItem
            // 
            kruscalToolStripMenuItem.Name = "kruscalToolStripMenuItem";
            kruscalToolStripMenuItem.Size = new Size(171, 30);
            kruscalToolStripMenuItem.Text = "Kruscal";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 192, 192);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, dFSToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1214, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Board
            // 
            Board.BackColor = Color.PeachPuff;
            Board.CustomizableEdges = customizableEdges5;
            Board.FillColor = Color.Bisque;
            Board.ImageRotate = 0F;
            Board.Location = new Point(7, 91);
            Board.Name = "Board";
            Board.ShadowDecoration.CustomizableEdges = customizableEdges6;
            Board.Size = new Size(726, 660);
            Board.TabIndex = 0;
            Board.TabStop = false;
            Board.Paint += Board_Paint;
            Board.MouseDown += Board_MouseDown;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage10);
            tabControl2.Controls.Add(tabPage11);
            tabControl2.Controls.Add(tabPage12);
            tabControl2.Controls.Add(tabPage13);
            tabControl2.Controls.Add(tabPage14);
            tabControl2.Controls.Add(tabPage15);
            tabControl2.Location = new Point(743, 46);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(464, 207);
            tabControl2.TabIndex = 6;
            // 
            // tabPage10
            // 
            tabPage10.Location = new Point(4, 29);
            tabPage10.Name = "tabPage10";
            tabPage10.Size = new Size(456, 174);
            tabPage10.TabIndex = 0;
            tabPage10.Text = "DFS";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 29);
            tabPage11.Name = "tabPage11";
            tabPage11.Size = new Size(242, 92);
            tabPage11.TabIndex = 1;
            tabPage11.Text = "BFS";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            tabPage12.Location = new Point(4, 29);
            tabPage12.Name = "tabPage12";
            tabPage12.Size = new Size(242, 92);
            tabPage12.TabIndex = 2;
            tabPage12.Text = "Dijkstra";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            tabPage13.Location = new Point(4, 29);
            tabPage13.Name = "tabPage13";
            tabPage13.Size = new Size(242, 92);
            tabPage13.TabIndex = 3;
            tabPage13.Text = "A*";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            tabPage14.Location = new Point(4, 29);
            tabPage14.Name = "tabPage14";
            tabPage14.Size = new Size(242, 92);
            tabPage14.TabIndex = 4;
            tabPage14.Text = "Kruscal";
            tabPage14.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            tabPage15.Location = new Point(4, 29);
            tabPage15.Name = "tabPage15";
            tabPage15.Size = new Size(242, 92);
            tabPage15.TabIndex = 5;
            tabPage15.Text = "Prim";
            tabPage15.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1214, 772);
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Controls.Add(Board);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Graph Editor";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            tabPage9.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Board).EndInit();
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private Guna.UI2.WinForms.Guna2Panel adjMatrixPanel;
        private Guna.UI2.WinForms.Guna2Panel weiMatrixPanel;
        private RadioButton selectNode;
        private RadioButton addEdges;
        private RadioButton addNodes;
        private Panel panel1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem dFSToolStripMenuItem;
        private ToolStripMenuItem dFSToolStripMenuItem1;
        private ToolStripMenuItem bFSToolStripMenuItem;
        private ToolStripMenuItem dijkstraToolStripMenuItem;
        private ToolStripMenuItem aToolStripMenuItem;
        private ToolStripMenuItem primToolStripMenuItem;
        private ToolStripMenuItem kruscalToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveFile;
        private ToolStripMenuItem loadFile;
        private Guna.UI2.WinForms.Guna2PictureBox Board;
        private TabPage tabPage9;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button Reset;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private ToolStripMenuItem saveGph;
        private ToolStripMenuItem loadgph;
        private ToolStripMenuItem savetxtToolStripMenuItem;
        private ToolStripMenuItem loadtxtToolStripMenuItem;
        private TabControl tabControl2;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private TabPage tabPage14;
        private TabPage tabPage15;
    }
}
