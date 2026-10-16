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
            AvailableTagsLabel.Location = new Point(2, 4);
            AvailableTagsLabel.Margin = new Padding(2, 0, 2, 0);
            AvailableTagsLabel.Name = "AvailableTagsLabel";
            AvailableTagsLabel.Size = new Size(102, 36);
            AvailableTagsLabel.TabIndex = 0;
            AvailableTagsLabel.Text = "Available Tags:";
            // 
            // TagsFlowLayoutPanel
            // 
            TagsFlowLayoutPanel.Location = new Point(108, 4);
            TagsFlowLayoutPanel.Margin = new Padding(2, 2, 2, 2);
            TagsFlowLayoutPanel.Name = "TagsFlowLayoutPanel";
            TagsFlowLayoutPanel.Size = new Size(274, 110);
            TagsFlowLayoutPanel.TabIndex = 1;
            // 
            // AddTagButton
            // 
            AddTagButton.ForeColor = SystemColors.ControlLight;
            AddTagButton.Location = new Point(386, 4);
            AddTagButton.Margin = new Padding(2, 2, 2, 2);
            AddTagButton.MinimumSize = new Size(0, 25);
            AddTagButton.Name = "AddTagButton";
            AddTagButton.Size = new Size(78, 25);
            AddTagButton.TabIndex = 2;
            AddTagButton.Text = "Add Tag";
            AddTagButton.UseVisualStyleBackColor = true;
            AddTagButton.Click += AddTagButton_Click;
            // 
            // TagsOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddTagButton);
            Controls.Add(TagsFlowLayoutPanel);
            Controls.Add(AvailableTagsLabel);
            Margin = new Padding(2, 2, 2, 2);
            Name = "TagsOptions";
            Size = new Size(470, 116);
            ResumeLayout(false);
        }

        #endregion

        private Label AvailableTagsLabel;
        private FlowLayoutPanel TagsFlowLayoutPanel;
        private Button AddTagButton;
    }
}
