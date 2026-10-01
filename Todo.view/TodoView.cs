using Todo.view.Interfaces;
namespace Todo.view
{
    public partial class TodoView : Form, ITodoView
    {
        public TodoView()
        {
            InitializeComponent();
        }

        public List<Control> StartUp()
        {
            var newThread = new Thread(FormThread);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();

            List<Control> controls = [
                createTodoButton, 
                todoViewItem1.deleteButton, 
                todoViewItem1.textBox
                ];
            return controls;
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        public List<Control> UpdateActiveViewList(object todoList)
        {
            return new List<Control>();
        }
    }
}
