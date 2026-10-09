namespace Todo.view
{
    partial class OptionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new Button();
            cancelButton = new Button();
            CenterBox = new GroupBox();
            flowLayoutPanel = new FlowLayoutPanel();
            splitContainer = new SplitContainer();
            CenterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Dock = DockStyle.Fill;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(309, 32);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveClick;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(0, 0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(313, 32);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // CenterBox
            // 
            CenterBox.Controls.Add(flowLayoutPanel);
            CenterBox.Controls.Add(splitContainer);
            CenterBox.Dock = DockStyle.Fill;
            CenterBox.FlatStyle = FlatStyle.Popup;
            CenterBox.Location = new Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new Size(632, 300);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Dock = DockStyle.Top;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(3, 19);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(626, 240);
            flowLayoutPanel.TabIndex = 2;
            flowLayoutPanel.WrapContents = false;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Bottom;
            splitContainer.IsSplitterFixed = true;
            splitContainer.Location = new Point(3, 265);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(saveButton);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(cancelButton);
            splitContainer.Size = new Size(626, 32);
            splitContainer.SplitterDistance = 309;
            splitContainer.TabIndex = 3;
            // 
            // OptionsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            CancelButton = cancelButton;
            ClientSize = new Size(632, 300);
            ControlBox = false;
            Controls.Add(CenterBox);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionsForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Todo";
            TopMost = true;
            CenterBox.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button saveButton;
        private Button cancelButton;
        private GroupBox CenterBox;
        private SplitContainer splitContainer;
        private FlowLayoutPanel flowLayoutPanel;
    }
}