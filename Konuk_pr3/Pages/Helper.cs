using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konuk_pr3.Model;

namespace Konuk_pr3
{
    class Helper
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
        public void UpdateSotr(Model.Sotrudniki sotr)
        {
            model.Entry(sotr).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
        }
    }
}
