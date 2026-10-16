using System.ComponentModel;

namespace Todo.view.EditItems;

partial class DescriptionEdit
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        flowLayoutPanel1 = new FlowLayoutPanel();
        DescriptionLabel = new Label();
        DescriptionTextBox = new TextBox();
        flowLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Controls.Add(DescriptionLabel);
        flowLayoutPanel1.Controls.Add(DescriptionTextBox);
        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(259, 115);
        flowLayoutPanel1.TabIndex = 0;
        // 
        // DescriptionLabel
        // 
        DescriptionLabel.ForeColor = SystemColors.ButtonHighlight;
        DescriptionLabel.Location = new Point(3, 0);
        DescriptionLabel.Name = "DescriptionLabel";
        DescriptionLabel.Size = new Size(100, 29);
        DescriptionLabel.TabIndex = 0;
        DescriptionLabel.Text = "Description:";
        DescriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // DescriptionTextBox
        // 
        DescriptionTextBox.Location = new Point(109, 3);
        DescriptionTextBox.Multiline = true;
        DescriptionTextBox.Name = "DescriptionTextBox";
        DescriptionTextBox.Size = new Size(145, 108);
        DescriptionTextBox.TabIndex = 1;
        // 
        // DescriptionEdit
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(flowLayoutPanel1);
        Name = "DescriptionEdit";
        Size = new Size(259, 115);
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label DescriptionLabel;
    private System.Windows.Forms.TextBox DescriptionTextBox;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    #endregion
}