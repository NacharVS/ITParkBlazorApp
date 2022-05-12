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

        public void ChangeTheme()
        {
            Color = "red";
            Background = "row alert-light";
        }
    }
}
