using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class TaskItem
    {
        private bool _isDone;
        private bool _inProgress;
        public TaskItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool IsDone 
        { 
            get => _isDone;
            set
            {
                _isDone = value;
            } 
        }
        public bool InProgress
        { 
            get => _inProgress; 
            set
            {              
                _inProgress = value;
            }
        }
    }
}
