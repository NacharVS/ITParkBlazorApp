using System.Collections.Generic;

namespace BlazorApp4
{
    public class User
    {
        public User(string v1, string v2, string v3, string v4)
        {
            Login = v1;
            Surname = v2;
            Name = v3;
            PhoneNumber = v4;
        }

        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }


        public static List<User> GetList()
        {
            var listToReturn = new List<User>();
            listToReturn.Add(new User("Bob", "Bobson", "Bobby", "222332"));
            listToReturn.Add(new User("Tom", "Tomson", "Tommie", "5566"));
            return listToReturn;
        }
    }
}
