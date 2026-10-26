using Todo.utility;
using Todo.utility.interfaces;
using Todo.WebView.Components;

public class TodoWebView : ITodoView
{
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

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapStaticAssets();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        var file = app.Environment.WebRootFileProvider
            .GetFileInfo("_framework/blazor.web.js");

        Console.WriteLine($"Blazor script exists: {file.Exists}");
        app.Run();
    }

    public void UpdateActiveViewList(List<TodoData> todoDatas, Action<int> editAction, Func<int, string> cycleStatusAction)
    {
    }

    public void UpdateComboboxLists(List<string> lists, string selectList)
    {
    }
}