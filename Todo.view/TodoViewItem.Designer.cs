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
            deleteTodoButton = new Button();
            todoLabel = new System.Windows.Forms.Label();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(StatusButton);
            flowItem.Controls.Add(todoLabel);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Dock = DockStyle.Fill;
            flowItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowItem.Location = new Point(0, 0);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(710, 29);
            flowItem.TabIndex = 3;
            flowItem.WrapContents = false;
            // 
            // StatusButton
            // 
            StatusButton.Location = new Point(3, 2);
            StatusButton.Margin = new Padding(3, 2, 3, 2);
            StatusButton.Name = "StatusButton";
            StatusButton.Size = new Size(82, 22);
            StatusButton.TabIndex = 3;
            StatusButton.Text = "Status here";
            StatusButton.UseVisualStyleBackColor = true;
            // 
            // todoLabel
            // 
            todoLabel.BackColor = System.Drawing.Color.White;
            todoLabel.Location = new System.Drawing.Point(3, 0);
            todoLabel.Name = "todoLabel";
            todoLabel.Size = new System.Drawing.Size(518, 24);
            todoLabel.TabIndex = 3;
            todoLabel.Text = "svend";
            // 
            // deleteTodoButton
            // 
            deleteTodoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            deleteTodoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new System.Drawing.Point(527, 4);
            deleteTodoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            deleteTodoButton.Name = "deleteTodoButton";
            deleteTodoButton.Size = new System.Drawing.Size(86, 31);
            deleteTodoButton.TabIndex = 2;
            deleteTodoButton.Text = "Delete";
            deleteTodoButton.UseVisualStyleBackColor = true;
            deleteTodoButton.Click += deleteTodoButton_Click;
            // 
            // TodoViewItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Name = "TodoViewItem";
            Size = new Size(710, 29);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowItem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label todoLabel;

        #endregion

        private Button deleteTodoButton;
        private Button StatusButton;
        private System.Windows.Forms.FlowLayoutPanel flowItem;
    }
}
