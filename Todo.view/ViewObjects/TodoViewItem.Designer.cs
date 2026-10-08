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
            flowItem.Controls.Add(todoText);
            flowItem.Controls.Add(editTodoButton);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Dock = DockStyle.Fill;
            flowItem.Location = new Point(0, 0);
            flowItem.Margin = new Padding(4, 5, 4, 5);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(886, 49);
            flowItem.TabIndex = 3;
            flowItem.WrapContents = false;
            // 
            // todoText
            // 
            todoText.AcceptsReturn = true;
            todoText.Dock = DockStyle.Left;
            todoText.Location = new Point(4, 5);
            todoText.Margin = new Padding(4, 5, 4, 5);
            todoText.Name = "todoText";
            todoText.PlaceholderText = "Todo text here";
            todoText.ReadOnly = true;
            todoText.Size = new Size(646, 31);
            todoText.TabIndex = 1;
            // 
            // editTodoButton
            // 
            editTodoButton.Enabled = false;
            editTodoButton.FlatStyle = FlatStyle.Popup;
            editTodoButton.ForeColor = SystemColors.ButtonHighlight;
            editTodoButton.Location = new Point(658, 5);
            editTodoButton.Margin = new Padding(4, 5, 4, 5);
            editTodoButton.Name = "editTodoButton";
            editTodoButton.Size = new Size(108, 39);
            editTodoButton.TabIndex = 0;
            editTodoButton.Text = "Edit";
            editTodoButton.UseVisualStyleBackColor = true;
            // 
            // deleteTodoButton
            // 
            deleteTodoButton.BackColor = Color.Maroon;
            deleteTodoButton.FlatStyle = FlatStyle.Popup;
            deleteTodoButton.ForeColor = SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new Point(774, 5);
            deleteTodoButton.Margin = new Padding(4, 5, 4, 5);
            deleteTodoButton.Name = "deleteTodoButton";
            deleteTodoButton.Size = new Size(108, 39);
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
            Margin = new Padding(4, 5, 4, 5);
            Name = "TodoViewItem";
            Size = new Size(886, 49);
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
    }
}
