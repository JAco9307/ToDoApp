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
            groupBox1 = new GroupBox();
            statusLabel = new Label();
            comboBox1 = new ComboBox();
            groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(titleLabel);
            groupBox1.Controls.Add(titleTextBox);
            groupBox1.Controls.Add(cancelButton);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 165);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(93, 74);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 4;
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
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditTodoForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Todo";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button saveButton;
        private Button cancelButton;
        private Label titleLabel;
        private TextBox titleTextBox;
        private GroupBox groupBox1;
        private Label statusLabel;
        private ComboBox comboBox1;
    }
}