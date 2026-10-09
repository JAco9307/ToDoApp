using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;

namespace Todo.view.Interfaces
{
    public interface IOption
    {
        public TodoOptions Save(TodoOptions currentOptions);
    }
}
