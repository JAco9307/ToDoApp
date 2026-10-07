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
            todoText = new TextBox();
            editTodoButton = new Button();
            deleteTodoButton = new Button();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(StatusButton);
            flowItem.Controls.Add(todoText);
            flowItem.Controls.Add(editTodoButton);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Dock = DockStyle.Fill;
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
            // todoText
            // 
            todoText.AcceptsReturn = true;
            todoText.Dock = DockStyle.Left;
            todoText.Location = new Point(91, 3);
            todoText.Name = "todoText";
            todoText.PlaceholderText = "Todo text here";
            todoText.ReadOnly = true;
            todoText.Size = new Size(454, 23);
            todoText.TabIndex = 1;
            // 
            // editTodoButton
            // 
            editTodoButton.Enabled = false;
            editTodoButton.FlatStyle = FlatStyle.Popup;
            editTodoButton.ForeColor = SystemColors.ButtonHighlight;
            editTodoButton.Location = new Point(551, 3);
            editTodoButton.Name = "editTodoButton";
            editTodoButton.Size = new Size(75, 23);
            editTodoButton.TabIndex = 0;
            editTodoButton.Text = "Edit";
            editTodoButton.UseVisualStyleBackColor = true;
            // 
            // deleteTodoButton
            // 
            deleteTodoButton.FlatStyle = FlatStyle.Popup;
            deleteTodoButton.ForeColor = SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new Point(632, 3);
            deleteTodoButton.Name = "deleteTodoButton";
            deleteTodoButton.Size = new Size(75, 23);
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
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Name = "TodoViewItem";
            Size = new Size(710, 29);
            flowItem.ResumeLayout(false);
            flowItem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowItem;
        private TextBox todoText;
        private Button editTodoButton;
        private Button deleteTodoButton;
        private Button StatusButton;
    }
}
