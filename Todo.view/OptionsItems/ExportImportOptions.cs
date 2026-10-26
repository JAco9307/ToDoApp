using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.OptionsItems
{
    public partial class ExportImportOptions : UserControl, IOption
    {
        private bool _createExport = false;
        private string ImportFilePath = "";
        public ExportImportOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            currentOptions.CreateExport = _createExport;
            currentOptions.ImportFilePath = ImportFilePath;
            return currentOptions;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            _createExport = true;
            if (Parent?.Parent?.Parent is OptionsForm)
            {
                OptionsForm parent = (OptionsForm)Parent.Parent.Parent;
                parent.saveClick(this, EventArgs.Empty);
            }
        }

        private void ImportListButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files (*.json) | *.json";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            ImportFilePath = openFileDialog.FileName;

        }
    }
}
