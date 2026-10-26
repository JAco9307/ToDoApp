using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Serialization;

namespace Todo.model.Services
{
    public class ImportService : IImportService
    {
        IListService ListService;
        ITagService TagService;
        ITodoService TodoService;

        public ImportService(IListService listService, ITagService tagService, ITodoService todoService)
        {
            ListService = listService;
            TagService = tagService;
            TodoService = todoService;
        }

        //interface
        public async Task<bool> ImportJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            options.Converters.Add(new ColorJsonConverter());
            List<TodoList>? lists;
            try
            {
                lists = JsonSerializer.Deserialize<List<TodoList>>(json, options);
            }
            catch (Exception)
            {
                return false;
            }
            List<string> currentListNames = await ListService.GetNames();
            if (lists == null)
                return false;
            foreach (TodoList list in lists)
            {
                list.Title = CheckIfListNameAlreadyExist(list.Title + " (Imported List)", currentListNames);
                ListService.Add(list.Title);
                TodoList newList = await ListService.Get(list.Title);
                copyList(list, newList.Id);
            }
            return true;
        }

        //interface
        public void ExportJson(List<TodoList> lists)
        {
            string json = JsonSerializer.Serialize(lists, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Lists.json", json);
        }

        /// <summary>
        /// Matches the list of tag with the list of allTags and returns a list of the matching elements from the allTags list.
        /// </summary>
        /// <param name="tags">The new tags.</param>
        /// <param name="allTags">All current tags in the database.</param>
        /// <returns>The list result.</returns>
        private List<TodoTag> UseExistingTags(List<TodoTag> tags, List<TodoTag> allTags)
        {
            return tags.Select(tag => FindMatchingTag(tag, allTags)).ToList();
        }

        /// <summary>
        /// Finds the matching tag.
        /// </summary>
        /// <param name="newTag">The new tag.</param>
        /// <param name="allTags">All tags.</param>
        /// <returns>The todo tag result.</returns>
        private TodoTag FindMatchingTag(TodoTag newTag, List<TodoTag> allTags)
        {
            return allTags.FirstOrDefault(tag => tag.Title == newTag.Title) ?? newTag;
        }

        /// <summary>
        /// Checks the if list name already exist recursively.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="currentTitles">The current titles in the list.</param>
        /// <returns>The string result, will always be unique.</returns>
        private string CheckIfListNameAlreadyExist(string title, List<string> currentTitles)
        {
            if (currentTitles.Contains(title))
                return CheckIfListNameAlreadyExist(title + "(1)", currentTitles);
            return title;
        }

        /// <summary>
        /// Copies items from the given list to the list in the database with the given id.
        /// </summary>
        /// <param name="fromList">The list to copy from.</param>
        /// <param name="toListId">The list id to copy to.</param>
        private async void copyList(TodoList fromList, int toListId)
        {
            List<TodoTag> allTags = await TagService.GetAll();
            foreach (TodoItem item in fromList.Items)
            {
                if (!SanitizeItem(item))
                    continue;
                item.SetTags(UseExistingTags(item.Tags, allTags));
                item.ListId = toListId;
                TodoService.Add(item);
            }
        }

        /// <summary>
        /// Sanitizes the data on import.
        /// </summary>
        /// <param name="item">The item to sanitize.</param>
        /// <returns>True if the operation succeeds; otherwise, false.</returns>
        private bool SanitizeItem(TodoItem item)
        {
            if (item.Title == null)
                return false;
            if (item.Title.Length > 40)
                item.SetTodoTitle(item.Title.Substring(0, 40));
            if (item.Status == null)
                item.SetTodoStatus("");
            if (item.Description == null)
                item.SetDescription("");
            if (item.Tags == null)
                item.SetTags(new List<TodoTag>());

            foreach (TodoTag tag in item.Tags ?? new List<TodoTag>())
            {
                if (tag.Title == null)
                    item.Tags?.Remove(tag);
            }

            return true;
        }
    }
}
