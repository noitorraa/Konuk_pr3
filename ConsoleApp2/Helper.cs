using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Model;

namespace ConsoleApp2
{
    internal class Helper
    {
        public static Model1 model;
        public static Model.Model1 GetContext()
        {
            if (model == null)
            {
                model = new Model1();
            }
            return model;
        }
        public void CreateUsers(Model.User user)
        {
            GetContext();
            model.User.Add(user);
            model.SaveChanges();
        }
        public void CreateSotr(Model.Sotrudniki sotr)
        {
            GetContext();
            model.Sotrudniki.Add(sotr);
            model.SaveChanges();
        }
        public void UpdateUsers(Model.User user)
        {
            model.Entry(user).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
        }
        public void RemoveUsers(Model.User user)
        {
            model.User.Remove(user);
            model.SaveChanges();
        }
    }
}
