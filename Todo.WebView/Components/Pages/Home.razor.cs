using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        [Inject]
        NavigationManager _navigationManager { get; set; } = default!;

        public TodoData[]? TodoDatas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TodoDatas = await GetTodosAsync();
        }

        private async Task<TodoData[]> GetTodosAsync()
        {
            while(MainView.todoDatas == null) await Task.Delay(10);
            return MainView.todoDatas.ToArray();
        }

        private void CycleStatus(int id)
        {
            MainView.CycleAction(id);
            _navigationManager.NavigateTo("/", true);
        }

        private void ShowEdit(int id)
        {
            popupRef.Show(TodoDatas[id]);
        }
    }
}
