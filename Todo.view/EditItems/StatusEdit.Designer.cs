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
            flowLayoutPanel1 = new FlowLayoutPanel();
            StatusLabel = new Label();
            StatusComboBox = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(StatusLabel);
            flowLayoutPanel1.Controls.Add(StatusComboBox);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(193, 30);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.ForeColor = SystemColors.ButtonHighlight;
            StatusLabel.Location = new Point(3, 0);
            StatusLabel.MinimumSize = new Size(60, 30);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(60, 30);
            StatusLabel.TabIndex = 7;
            StatusLabel.Text = "Status:";
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // StatusComboBox
            // 
            StatusComboBox.Dock = DockStyle.Fill;
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusComboBox.FlatStyle = FlatStyle.Popup;
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(69, 3);
            StatusComboBox.MinimumSize = new Size(60, 0);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 23);
            StatusComboBox.TabIndex = 6;
            StatusComboBox.TabStop = false;
            // 
            // StatusEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(flowLayoutPanel1);
            Name = "StatusEdit";
            Size = new Size(193, 30);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label StatusLabel;
        private ComboBox StatusComboBox;
    }
}
