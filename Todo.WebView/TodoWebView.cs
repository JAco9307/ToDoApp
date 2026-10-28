using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Blazor;
using System.Drawing;
using Todo.utility;
using Todo.utility.Interfaces;
using Todo.WebView.Components;
using Todo.WebView.Components.Pages;

public class TodoWebView : ITodoView
{
    public List<TodoData>? todoDatas;
    public static void Main(string[] args) { }
    List<Action> actions = []; 
    Action<string>? listSelect;
    Action<int>? editAction;

    Home? home;
    Func<int, string>? cycleStatusAction;
    public void SetUpEvents(List<Action> _actions, Action<string> _listSelect)
    {
        actions = _actions;
        listSelect = _listSelect;
    }

    public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
    {
        home?.popupRef?.Show(currentData);
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
        builder.Services.AddSyncfusionBlazor();

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

    public void UpdateActiveViewList(List<TodoData> _todoDatas, Action<int> _editAction, Func<int, string> _cycleStatusAction)
    {
        todoDatas = _todoDatas;
        editAction = _editAction;
        cycleStatusAction = _cycleStatusAction;
    }

    public void UpdateComboboxLists(List<string> lists, string selectList)
    {
    }

    public void CycleAction(int i) 
    {
        if (cycleStatusAction != null && todoDatas != null)
        {
            TodoData todo = todoDatas[i];
            todo.Status = cycleStatusAction(i);
            todoDatas[i] = todo;
        }
    }

    public void Edit(int id, Home _home)
    {
        home = _home;
        editAction(id);
    }
}

