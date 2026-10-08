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
            flowItem = new System.Windows.Forms.FlowLayoutPanel();
            todoLabel = new System.Windows.Forms.Label();
            flowItem.SuspendLayout();
            SuspendLayout();
            // 
            // flowItem
            // 
            flowItem.AutoSize = true;
            flowItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowItem.Controls.Add(todoLabel);
            flowItem.Dock = System.Windows.Forms.DockStyle.Fill;
            flowItem.Location = new System.Drawing.Point(0, 0);
            flowItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            flowItem.Name = "flowItem";
            flowItem.Size = new System.Drawing.Size(524, 24);
            flowItem.TabIndex = 3;
            flowItem.WrapContents = false;
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
            // TodoViewItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(flowItem);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Size = new System.Drawing.Size(524, 24);
            flowItem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label todoLabel;

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowItem;
    }
}
