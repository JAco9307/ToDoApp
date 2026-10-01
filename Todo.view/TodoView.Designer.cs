namespace Todo.view
{
    partial class TodoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodoView));
            flowLayout = new FlowLayoutPanel();
            headerLayout = new FlowLayoutPanel();
            label1 = new Label();
            createTodoButton = new Button();
            headerLayout.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayout
            // 
            flowLayout.AutoScroll = true;
            flowLayout.AutoSize = true;
            flowLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayout.Dock = DockStyle.Fill;
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Location = new Point(0, 29);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new Size(800, 421);
            flowLayout.TabIndex = 1;
            flowLayout.WrapContents = false;
            // 
            // headerLayout
            // 
            headerLayout.AutoSize = true;
            headerLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            headerLayout.BackColor = Color.DimGray;
            headerLayout.Controls.Add(label1);
            headerLayout.Controls.Add(createTodoButton);
            headerLayout.Dock = DockStyle.Top;
            headerLayout.Location = new Point(0, 0);
            headerLayout.Name = "headerLayout";
            headerLayout.Size = new Size(800, 29);
            headerLayout.TabIndex = 3;
            headerLayout.WrapContents = false;
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
            // TodoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayout);
            Controls.Add(headerLayout);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TodoView";
            Text = "ToDo App";
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayout;
        private FlowLayoutPanel headerLayout;
        private Label label1;
        private Button createTodoButton;
    }
}
