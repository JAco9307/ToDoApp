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
            saveButton = new Button();
            cancelButton = new Button();
            titleLabel = new Label();
            titleTextBox = new TextBox();
            CenterBox = new GroupBox();
            statusLabel = new Label();
            statusComboBox = new ComboBox();
            CenterBox.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(28, 118);
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
            cancelButton.Location = new Point(250, 118);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.ForeColor = SystemColors.ButtonHighlight;
            titleLabel.Location = new Point(28, 48);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(59, 15);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Todo text:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(93, 45);
            titleTextBox.MaxLength = 40;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(232, 23);
            titleTextBox.TabIndex = 3;
            // 
            // CenterBox
            // 
            CenterBox.Controls.Add(statusLabel);
            CenterBox.Controls.Add(statusComboBox);
            CenterBox.Controls.Add(saveButton);
            CenterBox.Controls.Add(titleLabel);
            CenterBox.Controls.Add(titleTextBox);
            CenterBox.Controls.Add(cancelButton);
            CenterBox.Dock = DockStyle.Fill;
            CenterBox.FlatStyle = FlatStyle.Popup;
            CenterBox.Location = new Point(0, 0);
            CenterBox.Name = "CenterBox";
            CenterBox.Size = new Size(364, 165);
            CenterBox.TabIndex = 4;
            CenterBox.TabStop = false;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = SystemColors.ButtonHighlight;
            statusLabel.Location = new Point(28, 77);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(42, 15);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Status:";
            // 
            // statusComboBox
            //
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(93, 74);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(121, 23);
            statusComboBox.TabIndex = 4;
            // 
            // EditTodoForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            CancelButton = cancelButton;
            ClientSize = new Size(364, 165);
            ControlBox = false;
            Controls.Add(CenterBox);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTodoForm";
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
        private Label titleLabel;
        private TextBox titleTextBox;
        private GroupBox CenterBox;
        private Label statusLabel;
        private ComboBox statusComboBox;
    }
}