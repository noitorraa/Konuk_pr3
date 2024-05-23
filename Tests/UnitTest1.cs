using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Konuk_pr3.Pages;
using Konuk_pr3;
using Konuk_pr3.Model;
using HashPasswords;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerateCapcha() //С корректными данными
        {
            int length = 5;
            Autho autho = new Autho(); 
            
            string capcha = autho.GanerateCapcha(length);

            Assert.AreEqual(length, capcha.Length);
        }
        [TestMethod]
        public void OutOfRangeinCapcha() //С некорректными данными
        {
            Autho autho = new Autho();

            Assert.ThrowsException<OverflowException>(() => autho.GanerateCapcha(-1));
        }
        [TestMethod]
        public void HashPasswordReturnsCorrectHash()
        {
            string password = "password123";
            string expectedHash = "EF92B778BAFE771E89245B89ECBC08A44A4E166C06659911881F383D4473E94F";
            string actualHash = HashPassword.HashPassword1(password);

            Assert.AreEqual(expectedHash, actualHash);
        }
        [TestMethod]
        public void VoidValidTesting() //Пустой
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            var contextSotr = new ValidationContext(sotrudniki);
            var results = new List<ValidationResult>();
            Assert.IsFalse(Validator.TryValidateObject(sotrudniki, contextSotr, results, true)); //Так как экземпляр sotrudniki пустой получаем false
        }
        [TestMethod]
        public void SuccesfullyValidTesting() //Корректный
        {
            Sotrudniki sotrudniki = new Sotrudniki()
            {
                Imea = "Test", Familia = "Test", Otchestvo = "Test", Adres = "Test", Telephon = "8(999)-999-99-99"
            };
            var contextSotr = new ValidationContext(sotrudniki);
            var results = new List<ValidationResult>();
            Assert.IsTrue(Validator.TryValidateObject(sotrudniki, contextSotr, results, true));
        }
        [TestMethod]
        public void FailValidTesting() //Проваленный
        {
            Sotrudniki sotrudniki = new Sotrudniki()
            {
                Imea = "FO23.,.,//fvkmKV",
                Familia = "00KIMv,.VfvM",
                Otchestvo = "TIFDVn348V*!!!!!!!",
                Adres = "Test___+))($$",
                Telephon = "@#&*&*%!&$#%^@#UFNOIVvidfunv"
            };
            var contextSotr = new ValidationContext(sotrudniki);
            var results = new List<ValidationResult>();
            Assert.IsFalse(Validator.TryValidateObject(sotrudniki, contextSotr, results, true));
        }
    }

}
