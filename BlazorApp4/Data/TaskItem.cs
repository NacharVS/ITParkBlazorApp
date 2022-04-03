using MongoDB.Driver;

namespace BlazorApp4.Data
{
    public class TaskItem
    {
        public TaskItem(string name)
        {
            Name = name;
        }

        public TaskItem(string name, bool isDone, bool inProgress) : this(name)
        {
            IsDone = isDone;
            InProgress = inProgress;
        }

        private bool _isDone;
        private bool _inProgress;
        public string Name { get; set; }
        public bool IsDone
        {
            get => _isDone;
            set
            {
                if (_inProgress)
                {
                    _isDone = true;
                    _inProgress = false;
                }
                else
                {
                    _isDone = true;
                }
            }
        }
        public bool InProgress {
            get => _inProgress; 
            set
            {
                if (_isDone)
                {
                    _isDone = false;
                    _inProgress = true;
                }
                else
                {
                    _inProgress = true;
                }
            }
        }
    }
}