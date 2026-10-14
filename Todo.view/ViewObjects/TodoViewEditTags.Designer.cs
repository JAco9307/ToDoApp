namespace Todo.view.ViewObjects
{
    partial class TodoViewEditTags
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
            TagLabel = new Label();
            TagsComboBox = new ComboBox();
            TagsFlowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // TagLabel
            // 
            TagLabel.AutoSize = true;
            TagLabel.Location = new Point(12, 23);
            TagLabel.Name = "TagLabel";
            TagLabel.Size = new Size(47, 25);
            TagLabel.TabIndex = 0;
            TagLabel.Text = "Tags";
            // 
            // TagsComboBox
            // 
            TagsComboBox.FormattingEnabled = true;
            TagsComboBox.Location = new Point(65, 20);
            TagsComboBox.Name = "TagsComboBox";
            TagsComboBox.Size = new Size(303, 33);
            TagsComboBox.TabIndex = 1;
            // 
            // TagsFlowLayout
            // 
            TagsFlowLayout.Location = new Point(3, 71);
            TagsFlowLayout.Name = "TagsFlowLayout";
            TagsFlowLayout.Size = new Size(381, 103);
            TagsFlowLayout.TabIndex = 2;
            // 
            // TodoViewEditTags
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TagsFlowLayout);
            Controls.Add(TagsComboBox);
            Controls.Add(TagLabel);
            Name = "TodoViewEditTags";
            Size = new Size(387, 177);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TagLabel;
        private ComboBox TagsComboBox;
        private FlowLayoutPanel TagsFlowLayout;
    }
}
