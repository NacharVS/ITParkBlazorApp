using BlazorApp4.Data;
using BlazorApp4.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Shared
{
    public partial class ActionsWithTasks
    {
        [Inject]
        public TaskService service { get; set; }
        [Parameter]
        public List<TaskItem> _tasks { get; set; }
        [Parameter]
        public bool actions { get; set; }
        [Parameter]
        public bool isAdmin { get; set; }
        private string _day;

        private static string _searchDay = string.Empty;

        private string _newTask { get; set; }



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

        private void AddTaskRerender()
        {
            service.AddNewTask(_newTask);
            StateHasChanged();
        }

    }
}
