namespace Todo.view.OptionsItems
{
    partial class ListNameOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            titleLabel = new Label();
            listBox = new ListBox();
            addButton = new Button();
            removeButton = new Button();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel.Controls.Add(titleLabel);
            flowLayoutPanel.Controls.Add(listBox);
            flowLayoutPanel.Controls.Add(addButton);
            flowLayoutPanel.Controls.Add(removeButton);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(501, 70);
            flowLayoutPanel.TabIndex = 7;
            flowLayoutPanel.WrapContents = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(3, 0);
            titleLabel.MinimumSize = new Size(100, 30);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(100, 70);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Current Titles:";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(109, 3);
            listBox.MultiColumn = true;
            listBox.Name = "listBox";
            listBox.Size = new Size(208, 64);
            listBox.TabIndex = 5;
            // 
            // addButton
            // 
            addButton.AutoSize = true;
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.Dock = DockStyle.Fill;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(323, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(86, 64);
            addButton.TabIndex = 6;
            addButton.Text = "Add New list";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += this.addButton_Click;
            // 
            // removeButton
            // 
            removeButton.AutoSize = true;
            removeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            removeButton.Dock = DockStyle.Fill;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.ForeColor = SystemColors.ButtonHighlight;
            removeButton.Location = new Point(415, 3);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(83, 64);
            removeButton.TabIndex = 7;
            removeButton.Text = "Remove List";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += this.removeButton_Click;
            // 
            // ListNameOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowLayoutPanel);
            Name = "ListNameOptions";
            Size = new Size(501, 70);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label titleLabel;
        private ListBox listBox;
        private Button addButton;
        private Button removeButton;
    }
}
