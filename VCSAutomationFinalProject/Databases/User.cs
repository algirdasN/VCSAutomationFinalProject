using System;
using System.Collections.Generic;
using System.Text;

namespace VCSAutomationFinalProject
{
    class User
    {
        public static User Default = new User("Nazim Dal", "nazim.dal@aallaa.org", "automation");

        public string Name;
        public string Email;
        public string Password;
        public List<string> SelectedWishListItemIdlList;

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            SelectedWishListItemIdlList = new List<string>();
        }
    }
}
