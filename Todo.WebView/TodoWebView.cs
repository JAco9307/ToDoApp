using Syncfusion.Blazor;
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

    public Home? home;
    Func<int, string>? cycleStatusAction;
    public void SetUpEvents(List<Action> _actions, Action<string> _listSelect)
    {
        actions = _actions;
        listSelect = _listSelect;
    }

    public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
    {
        if (home == null || home.popupRef == null) throw new NullReferenceException();
        EditDialog editDialog = home.popupRef;
        editDialog.Show(currentData, context);
        editDialog.closeEvent.WaitOne();
        if (!editDialog.Todo.Equals(currentData))
            home.Refresh();
        return editDialog.Todo;
    }

    public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
    {
        if (home == null || home.optionsRef == null) throw new NullReferenceException();
        OptionsDialog optionsDialog = home.optionsRef;
        optionsDialog.Show(currentOptions);
        optionsDialog.closeEvent.WaitOne();
        return optionsDialog.Options;
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
        home?.Refresh();
    }

    public void UpdateComboboxLists(List<string> lists, string selectList)
    {
        home?.ListNames = lists;
        home?.SelectedList = selectList;
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

    public void Edit(int id)
    {
        if (editAction != null)
            editAction(id);
    }

    public void NewTodo()
    {
        if (actions[0] != null)
            actions[0]();
    }

    public void OpenOptions()
    {
        if (actions[1] != null)
            actions[1]();
    }

    public void UpdateComboboxLists()
    {
        actions[3]();
    }
    public void UpdateComboboxListSelection(string name)
    {
        listSelect(name);
    }
}

