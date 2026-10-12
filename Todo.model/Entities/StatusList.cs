using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.model.Entities
{
    public class StatusList
    {
        public List<string> options = new();
        public int Id = 1;
        public StatusList() {
            options = [ "Not Started",
                    "In Progress",
                    "Completed"];
        }
    }
}
