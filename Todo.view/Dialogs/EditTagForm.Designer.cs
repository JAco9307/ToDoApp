namespace Todo.view.Forms
{
    partial class EditTagForm
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
            SaveButton = new Button();
            CancelFormButton = new Button();
            TitleLabel = new Label();
            ColorLabel = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            PickColorButton = new Button();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.ForeColor = SystemColors.ControlLightLight;
            SaveButton.Location = new Point(12, 129);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(112, 34);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelFormButton
            // 
            CancelFormButton.ForeColor = SystemColors.ControlLightLight;
            CancelFormButton.Location = new Point(130, 129);
            CancelFormButton.Name = "CancelFormButton";
            CancelFormButton.Size = new Size(112, 34);
            CancelFormButton.TabIndex = 1;
            CancelFormButton.Text = "Cancel";
            CancelFormButton.UseVisualStyleBackColor = true;
            CancelFormButton.Click += CancelButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.ForeColor = SystemColors.ControlLightLight;
            TitleLabel.Location = new Point(30, 25);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(44, 25);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Title";
            // 
            // ColorLabel
            // 
            ColorLabel.AutoSize = true;
            ColorLabel.ForeColor = SystemColors.ControlLightLight;
            ColorLabel.Location = new Point(19, 72);
            ColorLabel.Name = "ColorLabel";
            ColorLabel.Size = new Size(55, 25);
            ColorLabel.TabIndex = 3;
            ColorLabel.Text = "Color";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Location = new Point(77, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(35, 36);
            panel1.TabIndex = 5;
            // 
            // PickColorButton
            // 
            PickColorButton.ForeColor = SystemColors.ControlLightLight;
            PickColorButton.Location = new Point(118, 67);
            PickColorButton.Name = "PickColorButton";
            PickColorButton.Size = new Size(112, 34);
            PickColorButton.TabIndex = 6;
            PickColorButton.Text = "Pick Color";
            PickColorButton.UseVisualStyleBackColor = true;
            PickColorButton.Click += PickColorButton_Click;
            // 
            // EditTagForm
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(254, 173);
            ControlBox = false;
            Controls.Add(PickColorButton);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(ColorLabel);
            Controls.Add(TitleLabel);
            Controls.Add(CancelFormButton);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "EditTagForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private Button CancelFormButton;
        private Label TitleLabel;
        private Label ColorLabel;
        private TextBox textBox1;
        private Panel panel1;
        private Button PickColorButton;
    }
}
