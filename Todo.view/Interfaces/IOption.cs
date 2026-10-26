using Todo.utility;

namespace Todo.view.Interfaces
{
    public interface IOption
    {

        /// <summary>
        /// Method describing how to parse and save the data
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        /// <returns>The output options.</returns>
        public TodoOptions Save(TodoOptions currentOptions);
    }
}
