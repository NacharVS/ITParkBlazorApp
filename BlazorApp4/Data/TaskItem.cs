using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class TaskItem
    {
        public TaskItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
