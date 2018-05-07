using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Selenium.WebTest.Framework.Support.Security;

namespace Selenium.Web.Tests.EncryptPassword
{
    [TestClass]
    public class EncryptPassword
    {
        [TestMethod]
        public void EncryptedPassword()
        {
            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            string password = "passwOrd";

            string encryptedPassword = EncrytpDecrypt.Encrypt(password, key);

            Console.WriteLine("encryptedPassword is " + encryptedPassword);
        }

        [TestMethod]
        public void DecryptPassword()
        {
            string key = ConfigurationManager.AppSettings["EncryptionKey"];
            string password = ConfigurationManager.AppSettings["Password"];

            string decryptedPassword = EncrytpDecrypt.Decrypt(password, key);

            Console.WriteLine("decryptedPassword is " + decryptedPassword);
        }
    }
}
