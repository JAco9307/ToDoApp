namespace Todo.view
{
    partial class TodoViewItem
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
            flowItem = new FlowLayoutPanel();
            StatusButton = new Button();
            todoLabel = new Label();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(StatusButton);
            flowItem.Controls.Add(todoLabel);
            flowItem.Dock = DockStyle.Fill;
            flowItem.Location = new Point(0, 0);
            flowItem.Margin = new Padding(3, 4, 3, 4);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(612, 26);
            flowItem.TabIndex = 3;
            flowItem.WrapContents = false;
            // 
            // StatusButton
            // 
            StatusButton.ForeColor = SystemColors.ButtonHighlight;
            StatusButton.Location = new Point(3, 2);
            StatusButton.Margin = new Padding(3, 2, 3, 2);
            StatusButton.Name = "StatusButton";
            StatusButton.Size = new Size(82, 22);
            StatusButton.TabIndex = 3;
            StatusButton.TabStop = false;
            StatusButton.Text = "Status here";
            StatusButton.UseVisualStyleBackColor = true;
            // 
            // todoLabel
            // 
            todoLabel.BackColor = Color.White;
            todoLabel.Location = new Point(91, 0);
            todoLabel.Name = "todoLabel";
            todoLabel.Size = new Size(518, 24);
            todoLabel.TabIndex = 3;
            todoLabel.Text = "svend";
            // 
            // TodoViewItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TodoViewItem";
            Size = new Size(612, 26);
            flowItem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label todoLabel;

        #endregion

        private Button StatusButton;
        private System.Windows.Forms.FlowLayoutPanel flowItem;
    }
}
