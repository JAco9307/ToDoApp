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
            statusLabel = new Label();
            statusOptionsTextBox = new TextBox();
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(3, 0);
            statusLabel.MinimumSize = new Size(100, 30);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 30);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Status Options:";
            // 
            // statusOptionsTextBox
            // 
            statusOptionsTextBox.Location = new Point(109, 3);
            statusOptionsTextBox.MaxLength = 40;
            statusOptionsTextBox.Multiline = true;
            statusOptionsTextBox.Name = "statusOptionsTextBox";
            statusOptionsTextBox.Size = new Size(355, 51);
            statusOptionsTextBox.TabIndex = 5;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel.Controls.Add(statusLabel);
            flowLayoutPanel.Controls.Add(statusOptionsTextBox);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(467, 57);
            flowLayoutPanel.TabIndex = 6;
            flowLayoutPanel.WrapContents = false;
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
            Size = new Size(467, 57);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusLabel;
        private TextBox statusOptionsTextBox;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
