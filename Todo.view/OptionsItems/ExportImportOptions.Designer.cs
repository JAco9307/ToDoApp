namespace Todo.view.OptionsItems
{
    partial class ExportImportOptions
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
            ExportButton = new Button();
            ImportListButton = new Button();
            SuspendLayout();
            // 
            // ExportButton
            // 
            ExportButton.ForeColor = SystemColors.ControlLightLight;
            ExportButton.Location = new Point(3, 3);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(141, 34);
            ExportButton.TabIndex = 0;
            ExportButton.Text = "Export All Lists";
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += ExportButton_Click;
            // 
            // ImportListButton
            // 
            ImportListButton.ForeColor = SystemColors.ControlLightLight;
            ImportListButton.Location = new Point(150, 3);
            ImportListButton.Name = "ImportListButton";
            ImportListButton.Size = new Size(141, 34);
            ImportListButton.TabIndex = 2;
            ImportListButton.Text = "Import Lists";
            ImportListButton.UseVisualStyleBackColor = true;
            ImportListButton.Click += ImportListButton_Click;
            // 
            // ExportImportOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(ImportListButton);
            Controls.Add(ExportButton);
            Name = "ExportImportOptions";
            Size = new Size(300, 42);
            ResumeLayout(false);
        }

        #endregion

        private Button ExportButton;
        private Button ImportListButton;
    }
}
