using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface IImportService
    {
        /// <summary>
        /// Determines whether import json.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>True if the operation succeeds; otherwise, false.</returns>
        public Task<bool> ImportJson(string filePath);

        /// <summary>
        /// Exports the json.
        /// </summary>
        /// <param name="lists">The lists.</param>
        public void ExportJson(List<TodoList> lists);
    }
}
