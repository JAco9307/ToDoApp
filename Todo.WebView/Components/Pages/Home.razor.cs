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
    }
}
