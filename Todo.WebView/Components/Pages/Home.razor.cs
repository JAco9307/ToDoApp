using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using Todo.utility;

namespace Todo.WebView.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public TodoWebView MainView { get; set; } = default!;

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
<<<<<<< Updated upstream
=======

        public void CycleStatus(int id)
        {
            MainView.CycleAction(id);
            _navigationManager.NavigateTo("/", true);
        }

        public EditPopup? popupRef;

        private async Task EditTodo(int id)
        {
            if (TodoDatas == null) return;
            Task.Run(()=>
                MainView.EditTodo(id, this));
        }
>>>>>>> Stashed changes
    }
}
