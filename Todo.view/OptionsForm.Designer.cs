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
            statusLabel = new Label();
            statusOptionsTextBox = new TextBox();
            CenterBox = new GroupBox();
            CenterBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(139, 265);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveClick;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(250, 265);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(28, 48);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(87, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "Status Options:";
            // 
            // statusOptionsTextBox
            // 
            statusOptionsTextBox.Location = new Point(121, 45);
            statusOptionsTextBox.MaxLength = 40;
            statusOptionsTextBox.Multiline = true;
            statusOptionsTextBox.Name = "statusOptionsTextBox";
            statusOptionsTextBox.Size = new Size(355, 51);
            statusOptionsTextBox.TabIndex = 3;
            // 
            // CenterBox
            // 
            CenterBox.Controls.Add(saveButton);
            CenterBox.Controls.Add(statusLabel);
            CenterBox.Controls.Add(statusOptionsTextBox);
            CenterBox.Controls.Add(cancelButton);
            CenterBox.Dock = DockStyle.Fill;
            CenterBox.FlatStyle = FlatStyle.Popup;
            CenterBox.Location = new Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new Size(500, 300);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // OptionsForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            CancelButton = cancelButton;
            ClientSize = new Size(500, 300);
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
            CenterBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button saveButton;
        private Button cancelButton;
        private TextBox statusOptionsTextBox;
        private GroupBox CenterBox;
        private Label statusLabel;
    }
}