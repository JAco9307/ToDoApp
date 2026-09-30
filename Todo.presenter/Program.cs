using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;
using Todo.view;

namespace Todo.presenter
{
    
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var application = new System.Windows.Application();
            var main = new MainWindow();
            application.Run(main);
        }
    }
}

   