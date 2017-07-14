using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Data.Entity;

namespace ImageSharing.Business
{
    public class UserHelper
    {
        public UserHelper(IRepository repository)
        {
            this.context = repository;
        }

        private IRepository context;

        public User AddUser(string firstname, string secondname, string email, string password, int role, bool isactive)
        {
            var u = new User() { FirstName = firstname, SecondName = secondname, Email = email, Password = password, Role = role, IsActive = isactive };

            context.Add(u);
            context.SaveChanges();
            return u;
        }

        public void DeleteUser(int id)
        {
            var u = GetUser(id);
            context.Delete(u);
            context.SaveChanges();
        }

        public User EditUser(int id, string firstname, string secondname, string email, string password)
        {
            var u = GetUser(id);
            u.FirstName = firstname;
            u.SecondName = secondname;
            u.Email = email;
            u.Password = password;
            context.Add(u);
            context.SaveChanges();
            return u;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User Login(string email, string password)
        {

            User res = null;
            foreach (var item in GetUsers())
            {
                if ((item.Email == email) && (item.Password == password))
                {
                    res = item;
                }
            }
            return res;
        }

        public IEnumerable<User> SearchUser(string s)
        {
            return GetUsers().Where(x => (x.FirstName + " " + x.SecondName).Contains(s));
        }

        public User GetUser(int id)
        {
            return GetUsers().First(x => x.ID == id);
        }
    }
}
