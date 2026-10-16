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
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddTagsLabel
            // 
            AddTagsLabel.AutoSize = true;
            AddTagsLabel.ForeColor = SystemColors.ControlLightLight;
            AddTagsLabel.Location = new Point(2, 0);
            AddTagsLabel.Margin = new Padding(2, 0, 2, 0);
            AddTagsLabel.MinimumSize = new Size(100, 0);
            AddTagsLabel.Name = "AddTagsLabel";
            AddTagsLabel.Size = new Size(100, 15);
            AddTagsLabel.TabIndex = 0;
            AddTagsLabel.Text = "Add Tags:";
            // 
            // CurrentTagsLabel
            // 
            CurrentTagsLabel.AutoSize = true;
            CurrentTagsLabel.ForeColor = SystemColors.ControlLightLight;
            CurrentTagsLabel.Location = new Point(2, 29);
            CurrentTagsLabel.Margin = new Padding(2, 0, 2, 0);
            CurrentTagsLabel.MinimumSize = new Size(100, 0);
            CurrentTagsLabel.Name = "CurrentTagsLabel";
            CurrentTagsLabel.Size = new Size(100, 15);
            CurrentTagsLabel.TabIndex = 1;
            CurrentTagsLabel.Text = "Current Tags:";
            // 
            // AddTagsComboBox
            // 
            AddTagsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AddTagsComboBox.FlatStyle = FlatStyle.Flat;
            AddTagsComboBox.FormattingEnabled = true;
            AddTagsComboBox.Location = new Point(107, 3);
            AddTagsComboBox.Name = "AddTagsComboBox";
            AddTagsComboBox.Size = new Size(215, 23);
            AddTagsComboBox.TabIndex = 2;
            AddTagsComboBox.SelectedIndexChanged += TagsComboBoxSelectionChanged;
            // 
            // CurrentTagsFlowLayout
            // 
            CurrentTagsFlowLayout.Location = new Point(106, 31);
            CurrentTagsFlowLayout.Margin = new Padding(2);
            CurrentTagsFlowLayout.Name = "CurrentTagsFlowLayout";
            CurrentTagsFlowLayout.Size = new Size(214, 90);
            CurrentTagsFlowLayout.TabIndex = 3;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(AddTagsLabel);
            flowLayoutPanel.Controls.Add(AddTagsComboBox);
            flowLayoutPanel.Controls.Add(CurrentTagsLabel);
            flowLayoutPanel.Controls.Add(CurrentTagsFlowLayout);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(348, 125);
            flowLayoutPanel.TabIndex = 4;
            // 
            // TagsEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(2);
            Name = "TagsEdit";
            Size = new Size(348, 125);
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddTagsLabel;
        private Label CurrentTagsLabel;
        private ComboBox AddTagsComboBox;
        private FlowLayoutPanel CurrentTagsFlowLayout;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
