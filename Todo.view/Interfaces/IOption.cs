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

        /// <summary>
        /// Method describing how to parse and save the data
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        /// <returns>The output options.</returns>
        public TodoOptions Save(TodoOptions currentOptions);
    }
}
