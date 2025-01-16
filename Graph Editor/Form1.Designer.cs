﻿namespace Graph_Editor
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tabControl1 = new TabControl();
            AdjacencyMatrix = new TabPage();
            adjMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            WeightMatrix = new TabPage();
            weiMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            TabLog = new TabPage();
            Log = new RichTextBox();
            AdjencyList = new TabPage();
            adjListShow = new RichTextBox();
            selectNode = new RadioButton();
            addEdges = new RadioButton();
            addNodes = new RadioButton();
            panel1 = new Panel();
            ChoseBtn = new RadioButton();
            timeRun = new Guna.UI2.WinForms.Guna2HtmlLabel();
            Run = new Button();
            TrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            guna2vSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            Reset = new Button();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveFile = new ToolStripMenuItem();
            saveGph = new ToolStripMenuItem();
            savetxtToolStripMenuItem = new ToolStripMenuItem();
            loadFile = new ToolStripMenuItem();
            loadgph = new ToolStripMenuItem();
            loadtxtToolStripMenuItem = new ToolStripMenuItem();
            Algorithm = new ToolStripMenuItem();
            dFS = new ToolStripMenuItem();
            bFS = new ToolStripMenuItem();
            dijkstra = new ToolStripMenuItem();
            aStar = new ToolStripMenuItem();
            prim = new ToolStripMenuItem();
            kruscal = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            Board = new Guna.UI2.WinForms.Guna2PictureBox();
            groupBox1 = new GroupBox();
            drawModeRadioBtn = new RadioButton();
            forceModeRadioBtn = new RadioButton();
            Color3 = new Guna.UI2.WinForms.Guna2Button();
            Color2 = new Guna.UI2.WinForms.Guna2Button();
            Color1 = new Guna.UI2.WinForms.Guna2Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            Algo = new Label();
            EndNode = new Guna.UI2.WinForms.Guna2NumericUpDown();
            StartNode = new Guna.UI2.WinForms.Guna2NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            AdjacencyMatrix.SuspendLayout();
            WeightMatrix.SuspendLayout();
            TabLog.SuspendLayout();
            AdjencyList.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Board).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EndNode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartNode).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(AdjacencyMatrix);
            tabControl1.Controls.Add(WeightMatrix);
            tabControl1.Controls.Add(TabLog);
            tabControl1.Controls.Add(AdjencyList);
            tabControl1.Location = new Point(798, 259);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(464, 492);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // AdjacencyMatrix
            // 
            AdjacencyMatrix.BackColor = Color.DarkGray;
            AdjacencyMatrix.Controls.Add(adjMatrixPanel);
            AdjacencyMatrix.Location = new Point(4, 32);
            AdjacencyMatrix.Name = "AdjacencyMatrix";
            AdjacencyMatrix.Padding = new Padding(3);
            AdjacencyMatrix.Size = new Size(456, 456);
            AdjacencyMatrix.TabIndex = 0;
            AdjacencyMatrix.Text = "Adjacency Matrix";
            // 
            // adjMatrixPanel
            // 
            adjMatrixPanel.CustomizableEdges = customizableEdges17;
            adjMatrixPanel.Dock = DockStyle.Fill;
            adjMatrixPanel.Location = new Point(3, 3);
            adjMatrixPanel.Name = "adjMatrixPanel";
            adjMatrixPanel.ShadowDecoration.CustomizableEdges = customizableEdges18;
            adjMatrixPanel.Size = new Size(450, 450);
            adjMatrixPanel.TabIndex = 0;
            // 
            // WeightMatrix
            // 
            WeightMatrix.BackColor = Color.DarkGray;
            WeightMatrix.Controls.Add(weiMatrixPanel);
            WeightMatrix.Location = new Point(4, 32);
            WeightMatrix.Name = "WeightMatrix";
            WeightMatrix.Padding = new Padding(3);
            WeightMatrix.Size = new Size(456, 456);
            WeightMatrix.TabIndex = 1;
            WeightMatrix.Text = "Weight Matrix";
            // 
            // weiMatrixPanel
            // 
            weiMatrixPanel.CustomizableEdges = customizableEdges19;
            weiMatrixPanel.Dock = DockStyle.Fill;
            weiMatrixPanel.Location = new Point(3, 3);
            weiMatrixPanel.Name = "weiMatrixPanel";
            weiMatrixPanel.ShadowDecoration.CustomizableEdges = customizableEdges20;
            weiMatrixPanel.Size = new Size(450, 450);
            weiMatrixPanel.TabIndex = 1;
            // 
            // TabLog
            // 
            TabLog.Controls.Add(Log);
            TabLog.Location = new Point(4, 32);
            TabLog.Name = "TabLog";
            TabLog.Padding = new Padding(3);
            TabLog.Size = new Size(456, 456);
            TabLog.TabIndex = 3;
            TabLog.Text = "Log";
            TabLog.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            Log.Dock = DockStyle.Fill;
            Log.Location = new Point(3, 3);
            Log.Name = "Log";
            Log.Size = new Size(450, 450);
            Log.TabIndex = 0;
            Log.Text = "";
            // 
            // AdjencyList
            // 
            AdjencyList.BackColor = SystemColors.ActiveCaption;
            AdjencyList.Controls.Add(adjListShow);
            AdjencyList.Location = new Point(4, 32);
            AdjencyList.Name = "AdjencyList";
            AdjencyList.Size = new Size(456, 456);
            AdjencyList.TabIndex = 4;
            AdjencyList.Text = "Adjacency List";
            // 
            // adjListShow
            // 
            adjListShow.Dock = DockStyle.Fill;
            adjListShow.Location = new Point(0, 0);
            adjListShow.Name = "adjListShow";
            adjListShow.Size = new Size(456, 456);
            adjListShow.TabIndex = 2;
            adjListShow.Text = "";
            // 
            // selectNode
            // 
            selectNode.AutoSize = true;
            selectNode.Location = new Point(115, 10);
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
            addEdges.Location = new Point(7, 9);
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
            addNodes.Location = new Point(235, 10);
            addNodes.Name = "addNodes";
            addNodes.Size = new Size(102, 24);
            addNodes.TabIndex = 4;
            addNodes.TabStop = true;
            addNodes.Text = "Add nodes";
            addNodes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ChoseBtn);
            panel1.Controls.Add(timeRun);
            panel1.Controls.Add(Run);
            panel1.Controls.Add(TrackBar);
            panel1.Controls.Add(guna2vSeparator1);
            panel1.Controls.Add(Reset);
            panel1.Controls.Add(addNodes);
            panel1.Controls.Add(addEdges);
            panel1.Controls.Add(selectNode);
            panel1.Location = new Point(0, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 49);
            panel1.TabIndex = 5;
            // 
            // ChoseBtn
            // 
            ChoseBtn.AutoSize = true;
            ChoseBtn.Location = new Point(340, 10);
            ChoseBtn.Name = "ChoseBtn";
            ChoseBtn.Size = new Size(120, 24);
            ChoseBtn.TabIndex = 12;
            ChoseBtn.TabStop = true;
            ChoseBtn.Text = "Choose Node";
            ChoseBtn.UseVisualStyleBackColor = true;
            ChoseBtn.CheckedChanged += ChangeChoosebtn;
            // 
            // timeRun
            // 
            timeRun.BackColor = Color.Transparent;
            timeRun.Location = new Point(683, 13);
            timeRun.Name = "timeRun";
            timeRun.Size = new Size(17, 22);
            timeRun.TabIndex = 11;
            timeRun.Text = "1s";
            // 
            // Run
            // 
            Run.BackColor = Color.Cyan;
            Run.Location = new Point(714, 10);
            Run.Name = "Run";
            Run.Size = new Size(69, 28);
            Run.TabIndex = 10;
            Run.Text = "Run";
            Run.UseVisualStyleBackColor = false;
            Run.Click += Run_Click;
            // 
            // TrackBar
            // 
            TrackBar.Location = new Point(545, 9);
            TrackBar.Maximum = 10;
            TrackBar.Name = "TrackBar";
            TrackBar.Size = new Size(132, 29);
            TrackBar.TabIndex = 8;
            TrackBar.ThumbColor = Color.FromArgb(160, 113, 255);
            TrackBar.Value = 1;
            TrackBar.ValueChanged += TrackBar_Value;
            // 
            // guna2vSeparator1
            // 
            guna2vSeparator1.Location = new Point(524, 5);
            guna2vSeparator1.Name = "guna2vSeparator1";
            guna2vSeparator1.Size = new Size(17, 34);
            guna2vSeparator1.TabIndex = 9;
            // 
            // Reset
            // 
            Reset.BackColor = Color.Cyan;
            Reset.Location = new Point(466, 7);
            Reset.Name = "Reset";
            Reset.Size = new Size(59, 28);
            Reset.TabIndex = 8;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = false;
            Reset.Click += Reset_Click;
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
            // Algorithm
            // 
            Algorithm.DropDownItems.AddRange(new ToolStripItem[] { dFS, bFS, dijkstra, aStar, prim, kruscal });
            Algorithm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            Algorithm.ForeColor = Color.Black;
            Algorithm.Name = "Algorithm";
            Algorithm.Size = new Size(128, 29);
            Algorithm.Text = "&Algorithms";
            // 
            // dFS
            // 
            dFS.Name = "dFS";
            dFS.Size = new Size(171, 30);
            dFS.Text = "DFS";
            dFS.Click += ChoseAlgorithm;
            // 
            // bFS
            // 
            bFS.Name = "bFS";
            bFS.Size = new Size(171, 30);
            bFS.Text = "BFS";
            bFS.Click += ChoseAlgorithm;
            // 
            // dijkstra
            // 
            dijkstra.Name = "dijkstra";
            dijkstra.Size = new Size(171, 30);
            dijkstra.Text = "Dijkstra";
            dijkstra.Click += ChoseAlgorithm;
            // 
            // aStar
            // 
            aStar.Name = "aStar";
            aStar.Size = new Size(171, 30);
            aStar.Text = "A*";
            aStar.Click += ChoseAlgorithm;
            // 
            // prim
            // 
            prim.Name = "prim";
            prim.Size = new Size(171, 30);
            prim.Text = "Prim";
            prim.Click += ChoseAlgorithm;
            // 
            // kruscal
            // 
            kruscal.Name = "kruscal";
            kruscal.Size = new Size(171, 30);
            kruscal.Text = "Kruskal";
            kruscal.Click += ChoseAlgorithm;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Aqua;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, Algorithm });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1274, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // Board
            // 
            Board.BackColor = Color.PeachPuff;
            Board.CustomizableEdges = customizableEdges21;
            Board.FillColor = Color.Bisque;
            Board.ImageRotate = 0F;
            Board.Location = new Point(7, 91);
            Board.Name = "Board";
            Board.ShadowDecoration.CustomizableEdges = customizableEdges22;
            Board.Size = new Size(776, 660);
            Board.TabIndex = 0;
            Board.TabStop = false;
            Board.Paint += Board_Paint;
            Board.MouseDown += Board_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(drawModeRadioBtn);
            groupBox1.Controls.Add(forceModeRadioBtn);
            groupBox1.Controls.Add(Color3);
            groupBox1.Controls.Add(Color2);
            groupBox1.Controls.Add(Color1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Algo);
            groupBox1.Controls.Add(EndNode);
            groupBox1.Controls.Add(StartNode);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(794, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(468, 189);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Algorithms ";
            // 
            // drawModeRadioBtn
            // 
            drawModeRadioBtn.AutoSize = true;
            drawModeRadioBtn.Location = new Point(163, 155);
            drawModeRadioBtn.Name = "drawModeRadioBtn";
            drawModeRadioBtn.Size = new Size(108, 24);
            drawModeRadioBtn.TabIndex = 13;
            drawModeRadioBtn.TabStop = true;
            drawModeRadioBtn.Text = "Draw mode";
            drawModeRadioBtn.UseVisualStyleBackColor = true;
            // 
            // forceModeRadioBtn
            // 
            forceModeRadioBtn.AutoSize = true;
            forceModeRadioBtn.Location = new Point(25, 155);
            forceModeRadioBtn.Name = "forceModeRadioBtn";
            forceModeRadioBtn.Size = new Size(109, 24);
            forceModeRadioBtn.TabIndex = 12;
            forceModeRadioBtn.TabStop = true;
            forceModeRadioBtn.Text = "Force mode";
            forceModeRadioBtn.UseVisualStyleBackColor = true;
            // 
            // Color3
            // 
            Color3.BorderRadius = 10;
            Color3.CustomizableEdges = customizableEdges23;
            Color3.DisabledState.BorderColor = Color.DarkGray;
            Color3.DisabledState.CustomBorderColor = Color.DarkGray;
            Color3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Color3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Color3.FillColor = Color.Fuchsia;
            Color3.Font = new Font("Segoe UI", 9F);
            Color3.ForeColor = Color.White;
            Color3.Location = new Point(320, 122);
            Color3.Name = "Color3";
            Color3.ShadowDecoration.CustomizableEdges = customizableEdges24;
            Color3.Size = new Size(72, 30);
            Color3.TabIndex = 11;
            Color3.Text = "Select";
            Color3.Click += btnColor;
            // 
            // Color2
            // 
            Color2.BorderRadius = 10;
            Color2.CustomizableEdges = customizableEdges25;
            Color2.DisabledState.BorderColor = Color.DarkGray;
            Color2.DisabledState.CustomBorderColor = Color.DarkGray;
            Color2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Color2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Color2.FillColor = Color.FromArgb(192, 192, 0);
            Color2.Font = new Font("Segoe UI", 9F);
            Color2.ForeColor = Color.White;
            Color2.Location = new Point(320, 73);
            Color2.Name = "Color2";
            Color2.ShadowDecoration.CustomizableEdges = customizableEdges26;
            Color2.Size = new Size(72, 30);
            Color2.TabIndex = 10;
            Color2.Text = "Select";
            Color2.Click += btnColor;
            // 
            // Color1
            // 
            Color1.BorderRadius = 10;
            Color1.CustomizableEdges = customizableEdges27;
            Color1.DisabledState.BorderColor = Color.DarkGray;
            Color1.DisabledState.CustomBorderColor = Color.DarkGray;
            Color1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Color1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Color1.FillColor = Color.FromArgb(255, 128, 0);
            Color1.Font = new Font("Segoe UI", 9F);
            Color1.ForeColor = Color.White;
            Color1.Location = new Point(320, 26);
            Color1.Name = "Color1";
            Color1.ShadowDecoration.CustomizableEdges = customizableEdges28;
            Color1.Size = new Size(72, 30);
            Color1.TabIndex = 9;
            Color1.Text = "Select";
            Color1.Click += btnColor;
            // 
            // label6
            // 
            label6.Location = new Point(198, 118);
            label6.Name = "label6";
            label6.Size = new Size(113, 34);
            label6.TabIndex = 8;
            label6.Text = "Completed";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Location = new Point(198, 73);
            label5.Name = "label5";
            label5.Size = new Size(103, 34);
            label5.TabIndex = 7;
            label5.Text = "Best";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new Point(198, 23);
            label4.Name = "label4";
            label4.Size = new Size(107, 34);
            label4.TabIndex = 6;
            label4.Text = "Visit";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Algo
            // 
            Algo.AutoSize = true;
            Algo.Location = new Point(115, 125);
            Algo.Name = "Algo";
            Algo.Size = new Size(45, 20);
            Algo.TabIndex = 5;
            Algo.Text = "None";
            Algo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EndNode
            // 
            EndNode.BackColor = Color.Transparent;
            EndNode.CustomizableEdges = customizableEdges29;
            EndNode.Font = new Font("Segoe UI", 9F);
            EndNode.Location = new Point(115, 77);
            EndNode.Margin = new Padding(3, 4, 3, 4);
            EndNode.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            EndNode.Name = "EndNode";
            EndNode.ShadowDecoration.CustomizableEdges = customizableEdges30;
            EndNode.Size = new Size(54, 30);
            EndNode.TabIndex = 4;
            // 
            // StartNode
            // 
            StartNode.BackColor = Color.Transparent;
            StartNode.CustomizableEdges = customizableEdges31;
            StartNode.Font = new Font("Segoe UI", 9F);
            StartNode.Location = new Point(115, 27);
            StartNode.Margin = new Padding(3, 4, 3, 4);
            StartNode.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            StartNode.Name = "StartNode";
            StartNode.ShadowDecoration.CustomizableEdges = customizableEdges32;
            StartNode.Size = new Size(54, 30);
            StartNode.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point(16, 118);
            label3.Name = "label3";
            label3.Size = new Size(93, 34);
            label3.TabIndex = 2;
            label3.Text = "Algorithm:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(16, 73);
            label2.Name = "label2";
            label2.Size = new Size(93, 34);
            label2.TabIndex = 1;
            label2.Text = "End Node:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Location = new Point(16, 23);
            label1.Name = "label1";
            label1.Size = new Size(93, 34);
            label1.TabIndex = 0;
            label1.Text = "Start Node:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1274, 772);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            Controls.Add(Board);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Graph Editor";
            tabControl1.ResumeLayout(false);
            AdjacencyMatrix.ResumeLayout(false);
            WeightMatrix.ResumeLayout(false);
            TabLog.ResumeLayout(false);
            AdjencyList.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Board).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)EndNode).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartNode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage AdjacencyMatrix;
        private TabPage WeightMatrix;
        private Guna.UI2.WinForms.Guna2Panel adjMatrixPanel;
        private Guna.UI2.WinForms.Guna2Panel weiMatrixPanel;
        private RadioButton selectNode;
        private RadioButton addEdges;
        private RadioButton addNodes;
        private Panel panel1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem Algorithm;
        private ToolStripMenuItem dFS;
        private ToolStripMenuItem bFS;
        private ToolStripMenuItem dijkstra;
        private ToolStripMenuItem aStar;
        private ToolStripMenuItem prim;
        private ToolStripMenuItem kruscal;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveFile;
        private ToolStripMenuItem loadFile;
        private Guna.UI2.WinForms.Guna2PictureBox Board;
        private TabPage TabLog;
        private Button Reset;
        private RichTextBox Log;
        private ToolStripMenuItem saveGph;
        private ToolStripMenuItem loadgph;
        private ToolStripMenuItem savetxtToolStripMenuItem;
        private ToolStripMenuItem loadtxtToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2VSeparator guna2vSeparator1;
        private Button Run;
        private Guna.UI2.WinForms.Guna2TrackBar TrackBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel timeRun;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2NumericUpDown StartNode;
        private Label Algo;
        private Guna.UI2.WinForms.Guna2NumericUpDown EndNode;
        private Label label6;
        private Label label5;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Button Color3;
        private Guna.UI2.WinForms.Guna2Button Color2;
        private Guna.UI2.WinForms.Guna2Button Color1;
        private RadioButton ChoseBtn;
        private TabPage AdjencyList;
        private RichTextBox adjListShow;
        private System.Windows.Forms.Timer timer1;
        private RadioButton forceModeRadioBtn;
        private RadioButton drawModeRadioBtn;
    }
}
