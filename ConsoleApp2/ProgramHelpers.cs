
using HashPasswords;
using System;
using System.Data.Entity;
using ConsoleApp2.Model;

namespace ConsoleApp2
{
    internal static class ProgramHelpers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя: ");
            Helper helper = new Helper();
            //Model1 db = Helper.GetContext();
            var sotr = new Sotrudniki();
            var user = new User();
            sotr.Imea = Console.ReadLine();
            Console.WriteLine("Введите фамилию пользователя: ");
            sotr.Familia = Console.ReadLine();
            Console.WriteLine("Введите отчество пользователя: ");
            sotr.Otchestvo = Console.ReadLine();
            Console.WriteLine("Введите id должности: ");
            sotr.ID_dolzhnosti = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите логин пользователя: ");
            user.Login = Console.ReadLine();
            Console.WriteLine("Введите пароль пользователя: ");
            string password = Console.ReadLine();
            string hashpass = HashPassword.HashPassword1(password);
            user.Parol = hashpass;
            //sotr.id_user = user.id_user;
            Console.WriteLine("Введите id сотрудника: ");
            sotr.ID_sotrudnika = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Введите id должности: ");
            //sotr.ID_dolzhnost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите id пользователя: ");
            user.ID_user = Convert.ToInt32(Console.ReadLine());
            //sotr.ID_sotrudnika = sotr.id_user;
            helper.CreateUsers(user);
            sotr.id_user = user.ID_user;
            helper.CreateSotr(sotr);
            //user.id_user = sotr.id_user;
            Console.ReadKey();
        }
    }
}