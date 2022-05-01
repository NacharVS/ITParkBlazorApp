using BlazorApp4.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Shared
{
    public partial class ActionsWithTasks
    {
        [Parameter]
        public List<TaskItem> _tasks { get; set; }
        [Parameter]
        public bool actions { get; set; }
        [Parameter]
        public bool isAdmin { get; set; }
        private string _day;

        private static string _searchDay = string.Empty;

        private string _newTask { get; set; }
        [Parameter]
        public EventCallback<string> addNewTaskEvent { get; set; }


        private void AddToDB()
        {
            if (!string.IsNullOrEmpty(_day))
            {
                TaskListDB.AddItem(new TaskListDB(_tasks), _day);
            }
            _day = string.Empty;
        }

        private void GetList()
        {
            //_tasks = TaskListDB.GetItem(_searchDay);
        }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"OnParametersSet() invoked. {_tasks.Count}");
        }
    }
}
