using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class TaskItem
    {
        private bool _isDone;
        private bool _isProgress;

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
                _isProgress = false;
            }
        }

        public bool IsProgress
        {
            get => _isProgress;
            set
            {
                _isProgress = value;
                _isDone = false;
            }
        }
    }
}
