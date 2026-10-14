namespace Todo.view.EditItems
{
    partial class TitleEdit
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
            titleTextBox = new TextBox();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel.Controls.Add(titleLabel);
            flowLayoutPanel.Controls.Add(titleTextBox);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(302, 31);
            flowLayoutPanel.TabIndex = 7;
            flowLayoutPanel.WrapContents = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(3, 0);
            titleLabel.MinimumSize = new Size(60, 25);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(60, 31);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Title:";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(69, 3);
            titleTextBox.MaxLength = 40;
            titleTextBox.Multiline = true;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(230, 25);
            titleTextBox.TabIndex = 5;
            // 
            // TitleEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowLayoutPanel);
            Name = "TitleEdit";
            Size = new Size(302, 31);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label titleLabel;
        private TextBox titleTextBox;
    }
}
