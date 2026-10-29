using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Blazor.DropDowns;
using Syncfusion.Blazor.SplitButtons;
using System.Drawing;
using Todo.utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Todo.WebView.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public TodoWebView MainView { get; set; } = default!;
        public EditDialog? popupRef;
        public OptionsDialog? optionsRef;
        public DropDownMenuItems? ListDropdown;

        public List<string> ListNames = [];
        public string SelectedList = "";
        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        public TodoData[]? TodoDatas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TodoDatas = await GetTodosAsync();
            MainView.home = this;
            MainView.UpdateComboboxLists();
        }

        private async Task<TodoData[]> GetTodosAsync()
        {
            while(MainView.todoDatas == null) await Task.Delay(10);
            return MainView.todoDatas.ToArray();
        }

        private void CycleStatus(int id)
        {
            MainView.CycleAction(id);
            Refresh();
        }

        public void Refresh()
        {
            _navigationManager.NavigateTo("/", true);
        }

        private void ShowEdit(int id)
        {
            Task.Factory.StartNew(() => 
            { 
                MainView.Edit(id); 
            });
        }

        private void NewTodo()
        {
            Task.Factory.StartNew(() =>
            {
                MainView.NewTodo();
            });
        }

        private void OpenOptions()
        {
            Task.Factory.StartNew(() =>
            {
                MainView.OpenOptions();
            });
        }
        private void UpdateComboboxListSelection(
            ChangeEventArgs<string, string> args)
        {
            Task.Factory.StartNew(() =>
            {
                MainView.UpdateComboboxListSelection(args.Value);
            });
        }
    }
}
