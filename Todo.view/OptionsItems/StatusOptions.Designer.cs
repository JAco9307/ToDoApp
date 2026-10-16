namespace Todo.view.OptionsItems
{
    partial class StatusOptions
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
            StatusLabel = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            statusBox = new ListBox();
            addButton = new Button();
            renameButton = new Button();
            removeButton = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            buttonUp = new Button();
            buttonDown = new Button();
            flowLayoutPanel.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Dock = DockStyle.Fill;
            StatusLabel.ForeColor = SystemColors.ButtonHighlight;
            StatusLabel.Location = new Point(3, 0);
            StatusLabel.MinimumSize = new Size(100, 30);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(100, 70);
            StatusLabel.TabIndex = 4;
            StatusLabel.Text = "Status Options:";
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel.Controls.Add(StatusLabel);
            flowLayoutPanel.Controls.Add(statusBox);
            flowLayoutPanel.Controls.Add(tableLayoutPanel);
            flowLayoutPanel.Controls.Add(addButton);
            flowLayoutPanel.Controls.Add(renameButton);
            flowLayoutPanel.Controls.Add(removeButton);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(506, 70);
            flowLayoutPanel.TabIndex = 6;
            flowLayoutPanel.WrapContents = false;
            // 
            // statusBox
            // 
            statusBox.FormattingEnabled = true;
            statusBox.Location = new Point(109, 3);
            statusBox.Name = "statusBox";
            statusBox.ScrollAlwaysVisible = true;
            statusBox.Size = new Size(161, 64);
            statusBox.TabIndex = 7;
            // 
            // addButton
            // 
            addButton.AutoSize = true;
            addButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addButton.BackColor = Color.FromArgb(64, 64, 64);
            addButton.Dock = DockStyle.Top;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.ForeColor = SystemColors.ButtonHighlight;
            addButton.Location = new Point(276, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(68, 27);
            addButton.TabIndex = 8;
            addButton.Text = "Add New";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // renameButton
            // 
            renameButton.AutoSize = true;
            renameButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            renameButton.BackColor = Color.FromArgb(64, 64, 64);
            renameButton.Dock = DockStyle.Top;
            renameButton.FlatStyle = FlatStyle.Flat;
            renameButton.ForeColor = SystemColors.ButtonHighlight;
            renameButton.Location = new Point(350, 3);
            renameButton.Name = "renameButton";
            renameButton.Size = new Size(95, 27);
            renameButton.TabIndex = 9;
            renameButton.Text = "Change Name";
            renameButton.UseVisualStyleBackColor = false;
            renameButton.Click += renameButton_Click;
            // 
            // removeButton
            // 
            removeButton.AutoSize = true;
            removeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            removeButton.BackColor = Color.FromArgb(192, 0, 0);
            removeButton.Dock = DockStyle.Top;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.ForeColor = SystemColors.ButtonHighlight;
            removeButton.Location = new Point(451, 3);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(52, 27);
            removeButton.TabIndex = 10;
            removeButton.Text = "Delete";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Click += removeButton_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(buttonUp, 0, 0);
            tableLayoutPanel.Controls.Add(buttonDown, 0, 1);
            tableLayoutPanel.Location = new Point(276, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(26, 64);
            tableLayoutPanel.TabIndex = 9;
            // 
            // buttonUp
            // 
            buttonUp.AutoSize = true;
            buttonUp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonUp.Dock = DockStyle.Fill;
            buttonUp.FlatStyle = FlatStyle.Popup;
            buttonUp.ForeColor = SystemColors.ButtonHighlight;
            buttonUp.Location = new Point(3, 3);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(20, 26);
            buttonUp.TabIndex = 0;
            buttonUp.Text = "▲";
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += buttonUp_Click;
            // 
            // buttonDown
            // 
            buttonDown.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDown.Dock = DockStyle.Fill;
            buttonDown.FlatStyle = FlatStyle.Popup;
            buttonDown.ForeColor = SystemColors.ButtonHighlight;
            buttonDown.Location = new Point(3, 35);
            buttonDown.Name = "buttonDown";
            buttonDown.RightToLeft = RightToLeft.Yes;
            buttonDown.Size = new Size(20, 26);
            buttonDown.TabIndex = 1;
            buttonDown.Text = "▼";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += buttonDown_Click;
            // 
            // StatusOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(flowLayoutPanel);
            Name = "StatusOptions";
            Size = new Size(506, 70);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StatusLabel;
        private FlowLayoutPanel flowLayoutPanel;
        private ListBox statusBox;
        private Button addButton;
        private Button renameButton;
        private Button removeButton;

        private TableLayoutPanel tableLayoutPanel;
        private Button buttonUp;
        private Button buttonDown;
    }
}
