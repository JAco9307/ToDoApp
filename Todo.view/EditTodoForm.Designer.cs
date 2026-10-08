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
            groupBox1 = new System.Windows.Forms.GroupBox();
            deleteButton = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            saveButton.Location = new System.Drawing.Point(28, 95);
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
            cancelButton.Location = new System.Drawing.Point(250, 95);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(deleteButton);
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(titleLabel);
            groupBox1.Controls.Add(titleTextBox);
            groupBox1.Controls.Add(cancelButton);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(364, 141);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = System.Drawing.Color.DarkRed;
            deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            deleteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            deleteButton.Location = new System.Drawing.Point(138, 95);
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
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New Todo";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button deleteButton;

        #endregion
        private Button saveButton;
        private Button cancelButton;
        private Label titleLabel;
        private TextBox titleTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}