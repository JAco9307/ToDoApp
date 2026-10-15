namespace Todo.view
{
    partial class EditTodoForm
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
            saveButton = new Button();
            cancelButton = new Button();
            CenterBox = new GroupBox();
            flowLayoutPanel = new FlowLayoutPanel();
            tableLayoutPanel = new TableLayoutPanel();
            deleteButton = new Button();
            CenterBox.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.AutoSize = true;
            saveButton.Dock = DockStyle.Fill;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(177, 30);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveClick;
            // 
            // cancelButton
            // 
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(0, 0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(173, 30);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // CenterBox
            // 
            CenterBox.Controls.Add(flowLayoutPanel);
            CenterBox.Controls.Add(tableLayoutPanel);
            CenterBox.Dock = DockStyle.Fill;
            CenterBox.FlatStyle = FlatStyle.Popup;
            CenterBox.Location = new Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new Size(360, 165);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(3, 19);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(354, 113);
            flowLayoutPanel.TabIndex = 3;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel.Controls.Add(saveButton, 0, 0);
            tableLayoutPanel.Controls.Add(cancelButton, 1, 0);
            tableLayoutPanel.Controls.Add(deleteButton, 2, 0);
            tableLayoutPanel.Dock = DockStyle.Bottom;
            tableLayoutPanel.Location = new Point(3, 132);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(354, 30);
            tableLayoutPanel.TabIndex = 0;
            // 
            // deleteButton
            // 
            deleteButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteButton.BackColor = Color.DarkRed;
            deleteButton.Dock = DockStyle.Fill;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.ForeColor = SystemColors.ButtonHighlight;
            deleteButton.Location = new Point(239, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(112, 24);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // EditTodoForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            CancelButton = cancelButton;
            ClientSize = new Size(360, 165);
            ControlBox = false;
            Controls.Add(CenterBox);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTodoForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Todo";
            TopMost = true;
            CenterBox.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }



        #endregion
        private Button saveButton;
        private Button cancelButton;
        private GroupBox CenterBox;

        private FlowLayoutPanel flowLayoutPanel;
        private Button deleteButton;
        private TableLayoutPanel tableLayoutPanel;

    }
}