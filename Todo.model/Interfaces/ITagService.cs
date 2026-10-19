using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Gets the all tags.
        /// </summary>
        /// <returns>The list result.</returns>
        public List<TodoTag> GetAll();


        /// <summary>
        /// Adds the given tag options.
        /// </summary>
        /// <param name="newTags">The new tags.</param>
        public void AddOptions(List<TodoTag> newTags);

        /// <summary>
        /// Removes the given tag options.
        /// </summary>
        /// <param name="newTags">The tags to remove.</param>
        public void RemoveOptions(List<TodoTag> newTags);
    }
}
