namespace GameLauncher
{
    partial class ImageDownloaderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDownloaderForm));
            nameTextBox = new TextBox();
            imagesPanel = new FlowLayoutPanel();
            searchButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(193, 13);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(323, 23);
            nameTextBox.TabIndex = 0;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // imagesPanel
            // 
            imagesPanel.AutoScroll = true;
            imagesPanel.BorderStyle = BorderStyle.FixedSingle;
            imagesPanel.Location = new Point(12, 52);
            imagesPanel.Name = "imagesPanel";
            imagesPanel.Size = new Size(700, 444);
            imagesPanel.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.Enabled = false;
            searchButton.Location = new Point(522, 12);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 2;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 16);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Game name:";
            // 
            // ImageDownloaderForm
            // 
            AcceptButton = searchButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 508);
            Controls.Add(label1);
            Controls.Add(searchButton);
            Controls.Add(imagesPanel);
            Controls.Add(nameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ImageDownloaderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Image Downloader";
            FormClosed += ImageDownloaderForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private FlowLayoutPanel imagesPanel;
        private Button searchButton;
        private Label label1;
    }
}