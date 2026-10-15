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
        flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        DescriptionLabel = new System.Windows.Forms.Label();
        DescriptionTextBox = new System.Windows.Forms.TextBox();
        flowLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Controls.Add(DescriptionLabel);
        flowLayoutPanel1.Controls.Add(DescriptionTextBox);
        flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new System.Drawing.Size(231, 115);
        flowLayoutPanel1.TabIndex = 0;
        // 
        // DescriptionLabel
        // 
        DescriptionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        DescriptionLabel.Location = new System.Drawing.Point(3, 0);
        DescriptionLabel.Name = "DescriptionLabel";
        DescriptionLabel.Size = new System.Drawing.Size(74, 29);
        DescriptionLabel.TabIndex = 0;
        DescriptionLabel.Text = "Description:";
        // 
        // DescriptionTextBox
        // 
        DescriptionTextBox.Location = new System.Drawing.Point(83, 3);
        DescriptionTextBox.Multiline = true;
        DescriptionTextBox.Name = "DescriptionTextBox";
        DescriptionTextBox.Size = new System.Drawing.Size(145, 108);
        DescriptionTextBox.TabIndex = 1;
        // 
        // DescriptionEdit
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(flowLayoutPanel1);
        Size = new System.Drawing.Size(231, 115);
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label DescriptionLabel;
    private System.Windows.Forms.TextBox DescriptionTextBox;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    #endregion
}