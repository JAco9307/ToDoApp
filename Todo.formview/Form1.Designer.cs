namespace Todo.formview
{
    partial class FormView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            deleteTodoButton = new Button();
            flowLayout = new FlowLayoutPanel();
            headerLayout = new FlowLayoutPanel();
            label1 = new Label();
            createTodoButton = new Button();
            flowItem = new FlowLayoutPanel();
            todoText = new TextBox();
            flowLayout.SuspendLayout();
            headerLayout.SuspendLayout();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // deleteTodoButton
            // 
            deleteTodoButton.FlatStyle = FlatStyle.Popup;
            deleteTodoButton.ForeColor = SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new Point(463, 3);
            deleteTodoButton.Name = "deleteTodo";
            deleteTodoButton.Size = new Size(75, 23);
            deleteTodoButton.TabIndex = 0;
            deleteTodoButton.Text = "Delete";
            deleteTodoButton.UseVisualStyleBackColor = true;
            // 
            // flowLayout
            // 
            flowLayout.Controls.Add(headerLayout);
            flowLayout.Controls.Add(flowItem);
            flowLayout.Dock = DockStyle.Left;
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Location = new Point(0, 0);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new Size(716, 450);
            flowLayout.TabIndex = 1;
            // 
            // headerLayout
            // 
            headerLayout.AutoSize = true;
            headerLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerLayout.BackColor = Color.DimGray;
            headerLayout.Controls.Add(label1);
            headerLayout.Controls.Add(createTodoButton);
            headerLayout.Dock = DockStyle.Top;
            headerLayout.Location = new Point(3, 3);
            headerLayout.Name = "headerLayout";
            headerLayout.Size = new Size(541, 29);
            headerLayout.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 29);
            label1.TabIndex = 0;
            label1.Text = "Todos:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // createTodoButton
            // 
            createTodoButton.FlatStyle = FlatStyle.Popup;
            createTodoButton.ForeColor = SystemColors.ButtonHighlight;
            createTodoButton.Location = new Point(51, 3);
            createTodoButton.Name = "createTodoButton";
            createTodoButton.Size = new Size(75, 23);
            createTodoButton.TabIndex = 1;
            createTodoButton.Text = "New Todo";
            createTodoButton.UseVisualStyleBackColor = true;
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(todoText);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Location = new Point(3, 38);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(541, 29);
            flowItem.TabIndex = 2;
            flowItem.WrapContents = false;
            // 
            // todoText
            // 
            todoText.AcceptsReturn = true;
            todoText.Dock = DockStyle.Left;
            todoText.Location = new Point(3, 3);
            todoText.Name = "todoText";
            todoText.PlaceholderText = "Todo text here";
            todoText.Size = new Size(454, 23);
            todoText.TabIndex = 1;
            // 
            // FormView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayout);
            Name = "FormView";
            Text = "FormView";
            flowLayout.ResumeLayout(false);
            flowLayout.PerformLayout();
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            flowItem.ResumeLayout(false);
            flowItem.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public Button deleteTodoButton;
        private FlowLayoutPanel flowLayout;
        private FlowLayoutPanel flowItem;
        public TextBox todoText;
        private FlowLayoutPanel headerLayout;
        private Label label1;
        public Button createTodoButton;
    }
}
