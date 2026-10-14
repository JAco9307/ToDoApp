namespace Todo.view
{
    partial class EditTodoForm
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
            saveButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            titleLabel = new System.Windows.Forms.Label();
            titleTextBox = new System.Windows.Forms.TextBox();
            CenterBox = new System.Windows.Forms.GroupBox();
            DescriptionLabel = new System.Windows.Forms.Label();
            DescriptionTextBox = new System.Windows.Forms.TextBox();
            statusLabel = new System.Windows.Forms.Label();
            statusComboBox = new System.Windows.Forms.ComboBox();
            CenterBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            saveButton.Location = new System.Drawing.Point(28, 271);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveClick;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            cancelButton.Location = new System.Drawing.Point(250, 271);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            titleLabel.Location = new System.Drawing.Point(54, 48);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(33, 15);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Title:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new System.Drawing.Point(93, 45);
            titleTextBox.MaxLength = 40;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new System.Drawing.Size(232, 23);
            titleTextBox.TabIndex = 3;
            // 
            // CenterBox
            // 
            CenterBox.Controls.Add(DescriptionLabel);
            CenterBox.Controls.Add(DescriptionTextBox);
            CenterBox.Controls.Add(statusLabel);
            CenterBox.Controls.Add(statusComboBox);
            CenterBox.Controls.Add(saveButton);
            CenterBox.Controls.Add(titleLabel);
            CenterBox.Controls.Add(titleTextBox);
            CenterBox.Controls.Add(cancelButton);
            CenterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            CenterBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CenterBox.Location = new System.Drawing.Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new System.Drawing.Size(364, 365);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            DescriptionLabel.Location = new System.Drawing.Point(17, 104);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new System.Drawing.Size(70, 15);
            DescriptionLabel.TabIndex = 7;
            DescriptionLabel.Text = "Description:";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new System.Drawing.Point(93, 104);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new System.Drawing.Size(232, 126);
            DescriptionTextBox.TabIndex = 6;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            statusLabel.Location = new System.Drawing.Point(45, 77);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(42, 15);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Status:";
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new System.Drawing.Point(93, 74);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new System.Drawing.Size(121, 23);
            statusComboBox.TabIndex = 4;
            // 
            // EditTodoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(364, 365);
            ControlBox = false;
            Controls.Add(CenterBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New Todo";
            TopMost = true;
            CenterBox.ResumeLayout(false);
            CenterBox.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label DescriptionLabel;

        private TextBox DescriptionTextBox;

        #endregion
        private Button saveButton;
        private Button cancelButton;
        private System.Windows.Forms.Label titleLabel;
        private TextBox titleTextBox;
        private GroupBox CenterBox;
        private System.Windows.Forms.Label statusLabel;
        private ComboBox statusComboBox;
    }
}