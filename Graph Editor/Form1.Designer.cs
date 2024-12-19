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
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            adjMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            tabPage7 = new TabPage();
            weiMatrixPanel = new Guna.UI2.WinForms.Guna2Panel();
            tabPage8 = new TabPage();
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            selectNode = new RadioButton();
            addEdges = new RadioButton();
            addNodes = new RadioButton();
            panel1 = new Panel();
            saveToolStripMenuItem = new ToolStripMenuItem();
            dFSToolStripMenuItem = new ToolStripMenuItem();
            dFSToolStripMenuItem1 = new ToolStripMenuItem();
            bFSToolStripMenuItem = new ToolStripMenuItem();
            dijkstraToolStripMenuItem = new ToolStripMenuItem();
            aToolStripMenuItem = new ToolStripMenuItem();
            primToolStripMenuItem = new ToolStripMenuItem();
            kruscalToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            saveToolStripMenuItem1 = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage7.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(697, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(471, 740);
            panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(471, 740);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DarkGray;
            tabPage2.Controls.Add(adjMatrixPanel);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(463, 704);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Adjacency Matrix";
            // 
            // adjMatrixPanel
            // 
            adjMatrixPanel.CustomizableEdges = customizableEdges1;
            adjMatrixPanel.Location = new Point(6, 79);
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
            tabPage7.Size = new Size(463, 704);
            tabPage7.TabIndex = 1;
            tabPage7.Text = "Weighted Matrix";
            // 
            // weiMatrixPanel
            // 
            weiMatrixPanel.CustomizableEdges = customizableEdges3;
            weiMatrixPanel.Location = new Point(6, 79);
            weiMatrixPanel.Name = "weiMatrixPanel";
            weiMatrixPanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            weiMatrixPanel.Size = new Size(450, 450);
            weiMatrixPanel.TabIndex = 1;
            // 
            // tabPage8
            // 
            tabPage8.BackColor = Color.DarkGray;
            tabPage8.Location = new Point(4, 32);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(463, 704);
            tabPage8.TabIndex = 2;
            tabPage8.Text = "Adjacency List";
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
            selectNode.Location = new Point(142, 9);
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
            addNodes.Location = new Point(280, 9);
            addNodes.Name = "addNodes";
            addNodes.Size = new Size(102, 24);
            addNodes.TabIndex = 4;
            addNodes.TabStop = true;
            addNodes.Text = "Add nodes";
            addNodes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(addNodes);
            panel1.Controls.Add(addEdges);
            panel1.Controls.Add(selectNode);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(697, 40);
            panel1.TabIndex = 5;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem1, loadToolStripMenuItem });
            saveToolStripMenuItem.Font = new Font("Roboto Black", 12F, FontStyle.Bold);
            saveToolStripMenuItem.ForeColor = Color.Black;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(58, 28);
            saveToolStripMenuItem.Text = "&File";
            // 
            // dFSToolStripMenuItem
            // 
            dFSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dFSToolStripMenuItem1, bFSToolStripMenuItem, dijkstraToolStripMenuItem, aToolStripMenuItem, primToolStripMenuItem, kruscalToolStripMenuItem });
            dFSToolStripMenuItem.Font = new Font("Roboto Black", 12F, FontStyle.Bold);
            dFSToolStripMenuItem.ForeColor = Color.Black;
            dFSToolStripMenuItem.Name = "dFSToolStripMenuItem";
            dFSToolStripMenuItem.Size = new Size(126, 28);
            dFSToolStripMenuItem.Text = "&Algorithms";
            // 
            // dFSToolStripMenuItem1
            // 
            dFSToolStripMenuItem1.Name = "dFSToolStripMenuItem1";
            dFSToolStripMenuItem1.Size = new Size(165, 28);
            dFSToolStripMenuItem1.Text = "DFS";
            // 
            // bFSToolStripMenuItem
            // 
            bFSToolStripMenuItem.Name = "bFSToolStripMenuItem";
            bFSToolStripMenuItem.Size = new Size(165, 28);
            bFSToolStripMenuItem.Text = "BFS";
            // 
            // dijkstraToolStripMenuItem
            // 
            dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            dijkstraToolStripMenuItem.Size = new Size(165, 28);
            dijkstraToolStripMenuItem.Text = "Dijkstra";
            // 
            // aToolStripMenuItem
            // 
            aToolStripMenuItem.Name = "aToolStripMenuItem";
            aToolStripMenuItem.Size = new Size(165, 28);
            aToolStripMenuItem.Text = "A*";
            // 
            // primToolStripMenuItem
            // 
            primToolStripMenuItem.Name = "primToolStripMenuItem";
            primToolStripMenuItem.Size = new Size(165, 28);
            primToolStripMenuItem.Text = "Prim";
            // 
            // kruscalToolStripMenuItem
            // 
            kruscalToolStripMenuItem.Name = "kruscalToolStripMenuItem";
            kruscalToolStripMenuItem.Size = new Size(165, 28);
            kruscalToolStripMenuItem.Text = "Kruscal";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 192, 192);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, dFSToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1168, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.Size = new Size(224, 28);
            saveToolStripMenuItem1.Text = "&Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(224, 28);
            loadToolStripMenuItem.Text = "&Load";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1168, 772);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Graph Editor";
            MouseUp += Form1_MouseUp;
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
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
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem loadToolStripMenuItem;
    }
}
