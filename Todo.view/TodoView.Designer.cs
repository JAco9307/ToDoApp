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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodoView));
            flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            headerLayout = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            createTodoButton = new System.Windows.Forms.Button();
            optionsButton = new System.Windows.Forms.Button();
            SortingDropDown = new System.Windows.Forms.ComboBox();
            headerLayout.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayout
            // 
            flowLayout.AutoScroll = true;
            flowLayout.AutoSize = true;
            flowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayout.Location = new System.Drawing.Point(0, 29);
            flowLayout.Name = "flowLayout";
            flowLayout.Size = new System.Drawing.Size(800, 421);
            flowLayout.TabIndex = 1;
            flowLayout.WrapContents = false;
            // 
            // headerLayout
            // 
            headerLayout.AutoSize = true;
            headerLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerLayout.BackColor = System.Drawing.Color.DimGray;
            headerLayout.Controls.Add(label1);
            headerLayout.Controls.Add(createTodoButton);
            headerLayout.Controls.Add(optionsButton);
            headerLayout.Controls.Add(SortingDropDown);
            headerLayout.Dock = System.Windows.Forms.DockStyle.Top;
            headerLayout.Location = new System.Drawing.Point(0, 0);
            headerLayout.Name = "headerLayout";
            headerLayout.Size = new System.Drawing.Size(800, 29);
            headerLayout.TabIndex = 3;
            headerLayout.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 29);
            label1.TabIndex = 0;
            label1.Text = "Todos:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createTodoButton
            // 
            createTodoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            createTodoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            createTodoButton.Location = new System.Drawing.Point(51, 3);
            createTodoButton.Name = "createTodoButton";
            createTodoButton.Size = new System.Drawing.Size(75, 23);
            createTodoButton.TabIndex = 1;
            createTodoButton.Text = "New Todo";
            createTodoButton.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            optionsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            optionsButton.Location = new System.Drawing.Point(132, 3);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new System.Drawing.Size(75, 23);
            optionsButton.TabIndex = 2;
            optionsButton.Text = "Options";
            optionsButton.UseVisualStyleBackColor = true;
            // 
            // SortingDropDown
            // 
            SortingDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            SortingDropDown.FormattingEnabled = true;
            SortingDropDown.Location = new System.Drawing.Point(213, 3);
            SortingDropDown.Name = "SortingDropDown";
            SortingDropDown.Size = new System.Drawing.Size(97, 23);
            SortingDropDown.TabIndex = 3;
            // 
            // TodoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(flowLayout);
            Controls.Add(headerLayout);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            Text = "ToDo App";
            headerLayout.ResumeLayout(false);
            headerLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox SortingDropDown;

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.FlowLayoutPanel headerLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createTodoButton;
        private System.Windows.Forms.Button optionsButton;
    }
}
