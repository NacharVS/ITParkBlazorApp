using BlazorApp4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Pages
{
    public partial class TaskList
    {

        private bool _isActive;
        private bool _isAdmin;

        private List<TaskItem> list2 = new List<TaskItem>();/*TaskListDB.GetItem("Thuesday").GetAwaiter().GetResult();*/



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
