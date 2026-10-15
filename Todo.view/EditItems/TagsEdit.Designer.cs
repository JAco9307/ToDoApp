namespace Todo.view.EditItems
{
    partial class TagsEdit
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
            AddTagsLabel = new Label();
            CurrentTagsLabel = new Label();
            AddTagsComboBox = new ComboBox();
            CurrentTagsFlowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // AddTagsLabel
            // 
            AddTagsLabel.AutoSize = true;
            AddTagsLabel.ForeColor = SystemColors.ControlLightLight;
            AddTagsLabel.Location = new Point(7, 13);
            AddTagsLabel.Name = "AddTagsLabel";
            AddTagsLabel.Size = new Size(90, 25);
            AddTagsLabel.TabIndex = 0;
            AddTagsLabel.Text = "Add Tags:";
            // 
            // CurrentTagsLabel
            // 
            CurrentTagsLabel.AutoSize = true;
            CurrentTagsLabel.ForeColor = SystemColors.ControlLightLight;
            CurrentTagsLabel.Location = new Point(7, 53);
            CurrentTagsLabel.Name = "CurrentTagsLabel";
            CurrentTagsLabel.Size = new Size(114, 25);
            CurrentTagsLabel.TabIndex = 1;
            CurrentTagsLabel.Text = "Current Tags:";
            // 
            // AddTagsComboBox
            // 
            AddTagsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AddTagsComboBox.FormattingEnabled = true;
            AddTagsComboBox.Location = new Point(138, 10);
            AddTagsComboBox.Name = "AddTagsComboBox";
            AddTagsComboBox.Size = new Size(306, 33);
            AddTagsComboBox.TabIndex = 2;
            AddTagsComboBox.SelectedIndexChanged += TagsComboBoxSelectionChanged;
            // 
            // CurrentTagsFlowLayout
            // 
            CurrentTagsFlowLayout.Location = new Point(138, 56);
            CurrentTagsFlowLayout.Name = "CurrentTagsFlowLayout";
            CurrentTagsFlowLayout.Size = new Size(306, 150);
            CurrentTagsFlowLayout.TabIndex = 3;
            // 
            // TagsEdit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(CurrentTagsFlowLayout);
            Controls.Add(AddTagsComboBox);
            Controls.Add(CurrentTagsLabel);
            Controls.Add(AddTagsLabel);
            Name = "TagsEdit";
            Size = new Size(451, 209);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddTagsLabel;
        private Label CurrentTagsLabel;
        private ComboBox AddTagsComboBox;
        private FlowLayoutPanel CurrentTagsFlowLayout;
    }
}
