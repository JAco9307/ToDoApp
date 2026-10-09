namespace Todo.view.Dialogs
{
    partial class TextInputDialog
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
            buttonContainer = new SplitContainer();
            saveButton = new Button();
            cancelButton = new Button();
            headerLabel = new Label();
            textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)buttonContainer).BeginInit();
            buttonContainer.Panel1.SuspendLayout();
            buttonContainer.Panel2.SuspendLayout();
            buttonContainer.SuspendLayout();
            SuspendLayout();
            // 
            // buttonContainer
            // 
            buttonContainer.Dock = DockStyle.Bottom;
            buttonContainer.IsSplitterFixed = true;
            buttonContainer.Location = new Point(0, 103);
            buttonContainer.Name = "buttonContainer";
            // 
            // buttonContainer.Panel1
            // 
            buttonContainer.Panel1.Controls.Add(saveButton);
            // 
            // buttonContainer.Panel2
            // 
            buttonContainer.Panel2.Controls.Add(cancelButton);
            buttonContainer.Size = new Size(350, 47);
            buttonContainer.SplitterDistance = 175;
            buttonContainer.TabIndex = 0;
            // 
            // saveButton
            // 
            saveButton.AutoSize = true;
            saveButton.Dock = DockStyle.Fill;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(0, 0);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(175, 47);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.AutoSize = true;
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(0, 0);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(171, 47);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 11F);
            headerLabel.ForeColor = SystemColors.ButtonHighlight;
            headerLabel.Location = new Point(0, 0);
            headerLabel.MinimumSize = new Size(0, 50);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(350, 50);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Header Text Here";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            textBox.Dock = DockStyle.Fill;
            textBox.Location = new Point(0, 50);
            textBox.Name = "textBox";
            textBox.Size = new Size(350, 23);
            textBox.TabIndex = 2;
            // 
            // TextInputDialog
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            CancelButton = cancelButton;
            ClientSize = new Size(350, 150);
            Controls.Add(textBox);
            Controls.Add(headerLabel);
            Controls.Add(buttonContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TextInputDialog";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            buttonContainer.Panel1.ResumeLayout(false);
            buttonContainer.Panel1.PerformLayout();
            buttonContainer.Panel2.ResumeLayout(false);
            buttonContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonContainer).EndInit();
            buttonContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer buttonContainer;
        private Label headerLabel;
        private TextBox textBox;
        private Button saveButton;
        private Button cancelButton;
    }
}