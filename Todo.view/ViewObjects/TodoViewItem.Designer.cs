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
            todoLabel = new Label();
            deleteTodoButton = new Button();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(todoLabel);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Dock = DockStyle.Fill;
            flowItem.Location = new Point(0, 0);
            flowItem.Margin = new Padding(4, 7, 4, 7);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(879, 66);
            flowItem.TabIndex = 3;
            flowItem.WrapContents = false;
            // 
            // todoLabel
            // 
            todoLabel.Anchor = AnchorStyles.None;
            todoLabel.BackColor = Color.White;
            todoLabel.Location = new Point(4, 13);
            todoLabel.Margin = new Padding(4, 0, 4, 0);
            todoLabel.Name = "todoLabel";
            todoLabel.Size = new Size(740, 40);
            todoLabel.TabIndex = 3;
            todoLabel.Text = "svend";
            // 
            // deleteTodoButton
            // 
            deleteTodoButton.BackColor = Color.Maroon;
            deleteTodoButton.FlatStyle = FlatStyle.Popup;
            deleteTodoButton.ForeColor = SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new Point(752, 7);
            deleteTodoButton.Margin = new Padding(4, 7, 4, 7);
            deleteTodoButton.Name = "deleteTodoButton";
            deleteTodoButton.Size = new Size(123, 52);
            deleteTodoButton.TabIndex = 2;
            deleteTodoButton.Text = "Delete";
            deleteTodoButton.UseVisualStyleBackColor = false;
            deleteTodoButton.Click += deleteTodoButton_Click;
            // 
            // TodoViewItem
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Margin = new Padding(4, 7, 4, 7);
            Name = "TodoViewItem";
            Size = new Size(879, 66);
            flowItem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label todoLabel;

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowItem;
        private System.Windows.Forms.Button deleteTodoButton;
    }
}
