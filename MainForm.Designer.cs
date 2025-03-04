namespace GameLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            addGame = new Button();
            gamesLayoutPanel = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            epicGamesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // addGame
            // 
            addGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addGame.AutoSize = true;
            addGame.Font = new Font("Segoe UI", 12F);
            addGame.Location = new Point(631, 493);
            addGame.Name = "addGame";
            addGame.Size = new Size(101, 36);
            addGame.TabIndex = 1;
            addGame.Text = "New Game";
            addGame.UseVisualStyleBackColor = true;
            addGame.Click += addButton_Click;
            // 
            // gamesLayoutPanel
            // 
            gamesLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gamesLayoutPanel.AutoScroll = true;
            gamesLayoutPanel.Location = new Point(12, 27);
            gamesLayoutPanel.Name = "gamesLayoutPanel";
            gamesLayoutPanel.Size = new Size(720, 452);
            gamesLayoutPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(744, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "Import games";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(55, 20);
            toolStripMenuItem1.Text = "Library";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { epicGamesToolStripMenuItem });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(180, 22);
            importToolStripMenuItem.Text = "Import from";
            // 
            // epicGamesToolStripMenuItem
            // 
            epicGamesToolStripMenuItem.Name = "epicGamesToolStripMenuItem";
            epicGamesToolStripMenuItem.Size = new Size(180, 22);
            epicGamesToolStripMenuItem.Text = "Epic Games";
            epicGamesToolStripMenuItem.Click += epicGamesToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 541);
            Controls.Add(gamesLayoutPanel);
            Controls.Add(addGame);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(760, 580);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Non-Steam Games Manager";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addGame;
        private FlowLayoutPanel gamesLayoutPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem epicGamesToolStripMenuItem;
    }
}