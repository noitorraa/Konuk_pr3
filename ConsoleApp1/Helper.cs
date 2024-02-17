using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    public class Helper
    {
        private static Model1 Entities;
        public static Model1 GetContext()
        {
            if (Entities == null)
            {
                Entities = new Model1();
            }
            return Entities;
        }
        public void CreateUsers(Model.User user)
        {
            Entities.User.Add(user);
            Entities.SaveChanges();
        }
        public void CreateSotr(Model.Sotrudniki sotr)
        {
            Entities.Sotrudniki.Add(sotr);
            Entities.SaveChanges();
        }
        public void UpdateUsers(Model.User user)
        {
            Entities.Entry(user).State = EntityState.Modified;
            Entities.SaveChanges();
        }
        public void RemoveUsers(int id_user)
        {
            var users = Entities.User.Find(id_user);
            Entities.User.Remove(users);
            Entities.SaveChanges();
        }
        public void FiltrUsers()
        {
            var users = Entities.User.Where(x => x.Login.StartsWith("М") || x.Login.StartsWith("А"));
        }
        public void SortUsers()
        {
            var users = Entities.User.OrderBy(x => x.Login);
        }
    }
}
