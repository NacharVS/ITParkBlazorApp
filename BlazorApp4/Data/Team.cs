using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class Team
    {
        public string TeamName { get; set; }
        public List<User> Users { get; set; }

        public List<Team> teams = new List<Team>
        {
            new Team()
            {
                TeamName = "Kolobki",
                Users = User.GetList()
            },
                  new Team()
            {
                TeamName = "Meteor",
                Users = User.GetList()
            },
                        new Team()
            {
                TeamName = "Vimpel",
                Users = User.GetList()
            }
        };

    }

}
