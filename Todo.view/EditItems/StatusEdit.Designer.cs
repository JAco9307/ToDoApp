namespace Todo.view.EditItems
{
    partial class StatusEdit
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
            StatusLabel = new Label();
            StatusComboBox = new ComboBox();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(StatusLabel);
            flowLayoutPanel.Controls.Add(StatusComboBox);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(280, 50);
            flowLayoutPanel.TabIndex = 0;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Dock = DockStyle.Fill;
            StatusLabel.ForeColor = SystemColors.ButtonHighlight;
            StatusLabel.Location = new Point(3, 0);
            StatusLabel.MinimumSize = new Size(143, 50);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(143, 50);
            StatusLabel.TabIndex = 7;
            StatusLabel.Text = "Status:";
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StatusComboBox
            // 
            StatusComboBox.Dock = DockStyle.Fill;
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FlatStyle = FlatStyle.Flat;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(153, 5);
            StatusComboBox.Margin = new Padding(4, 5, 4, 5);
            StatusComboBox.MinimumSize = new Size(60, 0);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 33);
            StatusComboBox.TabIndex = 6;
            StatusComboBox.TabStop = false;
            // 
            // StatusEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "StatusEdit";
            Size = new Size(280, 50);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label StatusLabel;
        private ComboBox StatusComboBox;
    }
}
