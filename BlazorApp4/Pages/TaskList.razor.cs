using BlazorApp4.Data;
using BlazorApp4.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Pages
{
    public partial class TaskList
    {
        [Inject]
        public  TaskService service { get; set; }
        private bool _isActive;
        private bool _isAdmin;

        private List<TaskItem> list2;/*TaskListDB.GetItem("Thuesday").GetAwaiter().GetResult();*/

        protected override void OnInitialized()
        {
            list2 = service.taskItems;            
        }



        //protected override async Task OnInitializedAsync()
        //{
        //    list = await TaskListDB.GetItem("Thuesday");
        //}

        private void AddNewTaskToList()
        {
            //if (!string.IsNullOrEmpty(_newTask))
            //{
            //    _tasks.Add(new TaskItem(_newTask));
            //    _newTask = ""; // string.Empty;
            //}
        }


        private void AddToDB()
        {
            //if (!string.IsNullOrEmpty(_day))
            //{
            //    TaskListDB.AddItem(new TaskListDB(_tasks), _day);
            //}
            //_day = string.Empty;
        }

        //private void GetList()
        //{
        //    _tasks = TaskListDB.GetItem(_searchDay);
        //}
    }
}
