using BlazorApp4.Data;
using BlazorApp4.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlazorApp4.Pages
{
    public partial class TaskList
    {
        [Inject]
        public  TaskService service { get; set; }
        private bool _isActive;
        private bool _isAdmin;

        private bool _check;

        private List<TaskItem> list2;/*TaskListDB.GetItem("Thuesday").GetAwaiter().GetResult();*/



        private void Checking()
        {
            if (_check)
                _check = !_check;
            else
                _check = !_check;
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
