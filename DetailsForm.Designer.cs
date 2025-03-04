namespace GameLauncher
{
    partial class DetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsForm));
            gridPictureBox = new PictureBox();
            heroPictureBox = new PictureBox();
            gameNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            launcherExecutableTextBox = new TextBox();
            label3 = new Label();
            gameExecutableTextBox = new TextBox();
            selectLauncherDialog = new OpenFileDialog();
            button1 = new Button();
            label4 = new Label();
            processNameTextBox = new TextBox();
            selectGameDialog = new OpenFileDialog();
            logoPictureBox = new PictureBox();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)gridPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)heroPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // gridPictureBox
            // 
            gridPictureBox.BorderStyle = BorderStyle.FixedSingle;
            gridPictureBox.Cursor = Cursors.Hand;
            gridPictureBox.Location = new Point(14, 147);
            gridPictureBox.Name = "gridPictureBox";
            gridPictureBox.Size = new Size(120, 180);
            gridPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            gridPictureBox.TabIndex = 0;
            gridPictureBox.TabStop = false;
            gridPictureBox.Click += gridPictureBox_Click;
            // 
            // heroPictureBox
            // 
            heroPictureBox.BorderStyle = BorderStyle.FixedSingle;
            heroPictureBox.Cursor = Cursors.Hand;
            heroPictureBox.Location = new Point(147, 147);
            heroPictureBox.Name = "heroPictureBox";
            heroPictureBox.Size = new Size(320, 180);
            heroPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            heroPictureBox.TabIndex = 1;
            heroPictureBox.TabStop = false;
            heroPictureBox.Click += heroPictureBox_Click;
            // 
            // gameNameTextBox
            // 
            gameNameTextBox.Location = new Point(232, 12);
            gameNameTextBox.Name = "gameNameTextBox";
            gameNameTextBox.Size = new Size(235, 23);
            gameNameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(147, 15);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Game name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(147, 48);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 4;
            label2.Text = "Launcher path:";
            // 
            // launcherExecutableTextBox
            // 
            launcherExecutableTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            launcherExecutableTextBox.ImeMode = ImeMode.Disable;
            launcherExecutableTextBox.Location = new Point(232, 45);
            launcherExecutableTextBox.Name = "launcherExecutableTextBox";
            launcherExecutableTextBox.Size = new Size(235, 23);
            launcherExecutableTextBox.TabIndex = 5;
            launcherExecutableTextBox.Click += launcherPathTextBox_Click;
            launcherExecutableTextBox.KeyPress += CancelKeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 80);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 6;
            label3.Text = "Game path:";
            // 
            // gameExecutableTextBox
            // 
            gameExecutableTextBox.Location = new Point(232, 77);
            gameExecutableTextBox.Name = "gameExecutableTextBox";
            gameExecutableTextBox.Size = new Size(235, 23);
            gameExecutableTextBox.TabIndex = 7;
            gameExecutableTextBox.Click += gamePathText_Click;
            gameExecutableTextBox.TextChanged += gameExecutableTextBox_TextChanged;
            gameExecutableTextBox.KeyPress += CancelKeyPress;
            // 
            // selectLauncherDialog
            // 
            selectLauncherDialog.Filter = "Applications (.exe)|*.exe";
            selectLauncherDialog.Title = "Select the launcher executable";
            selectLauncherDialog.FileOk += selectLauncherDialog_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(392, 346);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += saveButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 112);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 9;
            label4.Text = "Process name:";
            // 
            // processNameTextBox
            // 
            processNameTextBox.Location = new Point(232, 109);
            processNameTextBox.Name = "processNameTextBox";
            processNameTextBox.Size = new Size(235, 23);
            processNameTextBox.TabIndex = 8;
            // 
            // selectGameDialog
            // 
            selectGameDialog.Filter = "Applications (.exe)|*.exe";
            selectGameDialog.Title = "Select the game executable";
            selectGameDialog.FileOk += selectGameDialog_FileOk;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BorderStyle = BorderStyle.FixedSingle;
            logoPictureBox.Cursor = Cursors.Hand;
            logoPictureBox.Location = new Point(14, 12);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(120, 120);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 10;
            logoPictureBox.TabStop = false;
            logoPictureBox.Click += logoPictureBox_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(311, 346);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(75, 23);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Visible = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 381);
            Controls.Add(deleteButton);
            Controls.Add(logoPictureBox);
            Controls.Add(processNameTextBox);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(gameExecutableTextBox);
            Controls.Add(label3);
            Controls.Add(launcherExecutableTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gameNameTextBox);
            Controls.Add(heroPictureBox);
            Controls.Add(gridPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(501, 420);
            MinimumSize = new Size(501, 420);
            Name = "DetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Game";
            Load += DetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)heroPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox gridPictureBox;
        private PictureBox heroPictureBox;
        private TextBox gameNameTextBox;
        private Label label1;
        private Label label2;
        private TextBox launcherExecutableTextBox;
        private Label label3;
        private TextBox gameExecutableTextBox;
        private OpenFileDialog selectLauncherDialog;
        private Button button1;
        private Label label4;
        private TextBox processNameTextBox;
        private OpenFileDialog selectGameDialog;
        private PictureBox logoPictureBox;
        private Button deleteButton;
    }
}