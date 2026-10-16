namespace Todo.view.ViewObjects
{
    partial class TodoViewTag
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
            ViewTagText = new Label();
            ExitLabel = new Label();
            SuspendLayout();
            // 
            // ViewTagText
            // 
            ViewTagText.Anchor = AnchorStyles.None;
            ViewTagText.AutoSize = true;
            ViewTagText.Location = new Point(3, 4);
            ViewTagText.Name = "ViewTagText";
            ViewTagText.Size = new Size(59, 25);
            ViewTagText.TabIndex = 0;
            ViewTagText.Text = "label1";
            ViewTagText.Click += ViewTagText_Click;
            // 
            // ExitLabel
            // 
            ExitLabel.Anchor = AnchorStyles.Right;
            ExitLabel.AutoSize = true;
            ExitLabel.Location = new Point(78, 4);
            ExitLabel.Name = "ExitLabel";
            ExitLabel.Size = new Size(23, 25);
            ExitLabel.TabIndex = 1;
            ExitLabel.Text = "X";
            ExitLabel.Click += DeleteButton_Click;
            // 
            // TodoViewTag
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ExitLabel);
            Controls.Add(ViewTagText);
            Name = "TodoViewTag";
            Size = new Size(104, 34);
            MouseClick += TodoViewTag_MouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ViewTagText;
        private Label ExitLabel;
    }
}
