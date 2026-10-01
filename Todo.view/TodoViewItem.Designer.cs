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
            deleteTodoButton = new Button();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(todoText);
            flowItem.Controls.Add(deleteTodoButton);
            flowItem.Dock = DockStyle.Fill;
            flowItem.Location = new Point(0, 0);
            flowItem.Name = "flowItem";
            flowItem.Size = new Size(541, 29);
            flowItem.TabIndex = 3;
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
            // deleteTodoButton
            // 
            deleteTodoButton.FlatStyle = FlatStyle.Popup;
            deleteTodoButton.ForeColor = SystemColors.ButtonHighlight;
            deleteTodoButton.Location = new Point(463, 3);
            deleteTodoButton.Name = "deleteTodoButton";
            deleteTodoButton.Size = new Size(75, 23);
            deleteTodoButton.TabIndex = 0;
            deleteTodoButton.Text = "Delete";
            deleteTodoButton.UseVisualStyleBackColor = true;
            // 
            // TodoViewItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Name = "TodoViewItem";
            Size = new Size(541, 29);
            flowItem.ResumeLayout(false);
            flowItem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowItem;
        private TextBox todoText;
        private Button deleteTodoButton;
    }
}
