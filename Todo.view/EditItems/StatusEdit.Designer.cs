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
            statusLabel = new Label();
            statusComboBox = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(statusLabel);
            flowLayoutPanel1.Controls.Add(statusComboBox);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(273, 50);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(4, 0);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.MinimumSize = new Size(86, 50);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(86, 50);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Status:";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusComboBox
            // 
            statusComboBox.Dock = DockStyle.Fill;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FlatStyle = FlatStyle.Popup;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(98, 5);
            statusComboBox.Margin = new Padding(4, 5, 4, 5);
            statusComboBox.MinimumSize = new Size(84, 0);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(171, 33);
            statusComboBox.TabIndex = 6;
            // 
            // StatusEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(flowLayoutPanel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "StatusEdit";
            Size = new Size(273, 50);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label statusLabel;
        private ComboBox statusComboBox;
    }
}
