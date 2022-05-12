using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class ApplicationStyles
    {
        public string Color { get; set; } = "green";
        public string Background { get; set; } = "row alert-dark";
        public string ButtonStyle { get; set; } = "btn btn-primary";
        private bool IsDark = true;

        public void ChangeTheme()
        {
            
            if (!IsDark)
            {
                Color = "green";
                Background = "row alert-dark";
                ButtonStyle = "btn btn-primary";

            }
            else
            {
                Color = "red";
                Background = "row alert-ligt";
                ButtonStyle = "btn btn-danger";
            }
            IsDark = !IsDark;
        }
    }
}
