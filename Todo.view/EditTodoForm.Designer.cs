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
            statusLabel = new System.Windows.Forms.Label();
            statusComboBox = new System.Windows.Forms.ComboBox();
            deleteButton = new System.Windows.Forms.Button();
            CenterBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            saveButton.Location = new System.Drawing.Point(28, 102);
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
            cancelButton.Location = new System.Drawing.Point(250, 102);
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
            titleLabel.Location = new System.Drawing.Point(28, 48);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(59, 15);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Todo text:";
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
            CenterBox.Controls.Add(statusLabel);
            CenterBox.Controls.Add(statusComboBox);
            CenterBox.Controls.Add(deleteButton);
            CenterBox.Controls.Add(saveButton);
            CenterBox.Controls.Add(titleLabel);
            CenterBox.Controls.Add(titleTextBox);
            CenterBox.Controls.Add(cancelButton);
            CenterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            CenterBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CenterBox.Location = new System.Drawing.Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new System.Drawing.Size(364, 141);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            statusLabel.Location = new System.Drawing.Point(28, 77);
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
            // deleteButton
            // 
            deleteButton.BackColor = System.Drawing.Color.DarkRed;
            deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            deleteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            deleteButton.Location = new System.Drawing.Point(138, 102);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(75, 23);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteButton_Click;
            // 
            // EditTodoForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(364, 141);
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

        private System.Windows.Forms.Button deleteButton;

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private Label titleLabel;
        private TextBox titleTextBox;
        private GroupBox CenterBox;
        private Label statusLabel;
        private ComboBox statusComboBox;
    }
}