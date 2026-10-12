namespace Todo.view.OptionsItems
{
    partial class ListIdOptions
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
            listComboBox = new ComboBox();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.BackColor = Color.FromArgb(64, 64, 64);
            flowLayoutPanel.Controls.Add(titleLabel);
            flowLayoutPanel.Controls.Add(listComboBox);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(236, 30);
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
            titleLabel.Size = new Size(100, 30);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "On List:";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listComboBox
            // 
            listComboBox.Dock = DockStyle.Fill;
            listComboBox.FormattingEnabled = true;
            listComboBox.Location = new Point(109, 3);
            listComboBox.Name = "listComboBox";
            listComboBox.Size = new Size(124, 23);
            listComboBox.TabIndex = 5;
            // 
            // ListIdOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowLayoutPanel);
            Name = "ListIdOptions";
            Size = new Size(236, 30);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label titleLabel;
        private ComboBox listComboBox;
    }
}
