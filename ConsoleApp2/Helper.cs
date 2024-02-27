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
        /// <summary>
        /// Этот метод позволяет получать контекст данных базы данных 
        /// </summary>
        /// <returns></returns>
        public static Model.Model1 GetContext()
        {
            if (model == null)
            {
                model = new Model1();
            }
            return model;
        }
        /// <summary>
        /// Этот метод позволяет создать нового пользователя и записать его в базу данных
        /// </summary>
        /// <param name="user"></param>
        public void CreateUsers(Model.User user)
        {
            GetContext();
            model.User.Add(user);
            model.SaveChanges();
        }
        /// <summary>
        /// Этот метод позволяет создать нового сотрудника и записать его в базу данных
        /// </summary>
        /// <param name="sotr"></param>
        public void CreateSotr(Model.Sotrudniki sotr)
        {
            GetContext();
            model.Sotrudniki.Add(sotr);
            model.SaveChanges();
        }
        /// <summary>
        /// Этот метод позволяет обновить данных пользователя в базе данных
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUsers(Model.User user)
        {
            model.Entry(user).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
        }
        /// <summary>
        /// Этот метод позволяет удалить пользователя из базы данных
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUsers(Model.User user)
        {
            model.User.Remove(user);
            model.SaveChanges();
        }
    }
}
