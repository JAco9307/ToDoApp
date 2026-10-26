using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using Todo.utility;
using Todo.utility.Interfaces;
using Todo.WebView.Components;

public class TodoWebView : ITodoView
{
    public List<TodoData>? todoDatas;
    public static void Main(string[] args) { }
    public void SetUpEvents(List<Action> actions, Action<string> listSelect)
    {
    }

    public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
    {
        throw new NotImplementedException();
    }

    public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
    {
        throw new NotImplementedException();
    }

    public void StartUp()
    {
        var appAssembly = typeof(App).Assembly;

        // Adjust this path to the manifest produced by your build.
        var manifestPath = Path.Combine(
            AppContext.BaseDirectory,
            $"{appAssembly.GetName().Name}.staticwebassets.runtime.json");

        if (File.Exists(manifestPath))
        {
            Environment.SetEnvironmentVariable(
                "ASPNETCORE_STATICWEBASSETS",
                manifestPath);
        }
        else
        {
            Console.WriteLine($"Static web assets manifest not found: {manifestPath}");
        }

        var builder = WebApplication.CreateBuilder(
            new WebApplicationOptions
            {
                ApplicationName = appAssembly.GetName().Name
            });

        builder.WebHost.UseUrls("http://localhost:5000");
        builder.WebHost.UseStaticWebAssets();

        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddSingleton<TodoWebView>(this);
        builder.Services.AddSingleton<ITodoView>(this);

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapStaticAssets();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        _app = app;
        app.StartAsync();

    }

    private WebApplication? _app;

    public void UpdateActiveViewList(List<TodoData> _todoDatas, Action<int> editAction, Func<int, string> cycleStatusAction)
    {
        todoDatas = _todoDatas;
    }

    public void UpdateComboboxLists(List<string> lists, string selectList)
    {
    }
}

