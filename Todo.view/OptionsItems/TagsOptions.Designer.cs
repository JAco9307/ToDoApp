namespace Todo.view.OptionsItems
{
    partial class TagsOptions
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
            AvailableTagsLabel = new Label();
            TagsFlowLayoutPanel = new FlowLayoutPanel();
            AddTagButton = new Button();
            SuspendLayout();
            // 
            // AvailableTagsLabel
            // 
            AvailableTagsLabel.ForeColor = SystemColors.ControlLight;
            AvailableTagsLabel.Location = new Point(3, 6);
            AvailableTagsLabel.Name = "AvailableTagsLabel";
            AvailableTagsLabel.Size = new Size(145, 60);
            AvailableTagsLabel.TabIndex = 0;
            AvailableTagsLabel.Text = "Available Tags:";
            // 
            // TagsFlowLayoutPanel
            // 
            TagsFlowLayoutPanel.Location = new Point(154, 6);
            TagsFlowLayoutPanel.Name = "TagsFlowLayoutPanel";
            TagsFlowLayoutPanel.Size = new Size(392, 184);
            TagsFlowLayoutPanel.TabIndex = 1;
            // 
            // AddTagButton
            // 
            AddTagButton.ForeColor = SystemColors.ControlLight;
            AddTagButton.Location = new Point(552, 6);
            AddTagButton.Name = "AddTagButton";
            AddTagButton.Size = new Size(112, 34);
            AddTagButton.TabIndex = 2;
            AddTagButton.Text = "Add Tag";
            AddTagButton.UseVisualStyleBackColor = true;
            AddTagButton.Click += AddTagButton_Click;
            // 
            // TagsOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddTagButton);
            Controls.Add(TagsFlowLayoutPanel);
            Controls.Add(AvailableTagsLabel);
            Name = "TagsOptions";
            Size = new Size(671, 193);
            ResumeLayout(false);
        }

        #endregion

        private Label AvailableTagsLabel;
        private FlowLayoutPanel TagsFlowLayoutPanel;
        private Button AddTagButton;
    }
}
