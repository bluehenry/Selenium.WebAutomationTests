using System;
using System.Configuration;
using System.Xml;
using WebApp.Test.Framework.Support.Security;

namespace WebApp.Test.Framework.Selenium
{
    public static class TestEnvironment
    {
        public static string BrowserType { get; private set; }
        public static string BrowserDriverPath { get; private set; }
        public static string BaseUrl { get; private set; }
        public static string DbConnectionString { get; private set; }
        public static string UserName { get; private set; }
        public static string Password { get; private set; }

        // Read from app.config file
        public static void Initialize()
        {
            BrowserType = ConfigurationManager.AppSettings["BrowserType"];
            BrowserDriverPath = ConfigurationManager.AppSettings["BrowserDriverPath"];

            string testEnv = ConfigurationManager.AppSettings["TestEnvironment"];

            if (testEnv.Equals("Dev", StringComparison.InvariantCultureIgnoreCase))
            {
                BaseUrl = ConfigurationManager.AppSettings["DevBaseUrl"];
                DbConnectionString = ConfigurationManager.AppSettings["DevDbConnectString"];
            }
            else if (testEnv.Equals("Dev", StringComparison.InvariantCultureIgnoreCase))
            {
                BaseUrl = ConfigurationManager.AppSettings["TestBaseUrl"];
                DbConnectionString = ConfigurationManager.AppSettings["TestDbConnectString"];
            }
            else
            {
                throw new ArgumentException();
            }

            //_userName = ConfigurationManager.AppSettings["UserName"];
            //string encryptedPassword = ConfigurationManager.AppSettings["Password"];

            //string key = ConfigurationManager.AppSettings["EncryptionKey"];
            //_password = EncrytpDecrypt.Decrypt(encryptedPassword, key);
        }
        
        /// <summary>
        /// Read from config.xml file.
        /// It's for supporing Jenkins integration
        /// </summary>
        public static void InitializeForJenkins()
        {
            string configFile = @"C:\Workspace\bhp-or-vdt-seleniumtests\VDT.SeleniumTests\VDT.Tests\config.xml";
            string environment = "";
            string devBaseUrl = "";
            string devDbConnectString = "";
            string testBaseUrl = "";
            string testDbConnectString = "";
            string encryptedPassword = "";
            string encryptionKey = "";


            using (XmlReader reader = XmlReader.Create(configFile)
            )
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "BrowserType":
                                if (reader.Read())
                                {
                                    BrowserType = reader.Value;
                                }
                                break;
                            case "BrowserDriverPath":
                                if (reader.Read())
                                {
                                    BrowserDriverPath = reader.Value;
                                }
                                break;
                            case "TestEnvironment":
                                if (reader.Read())
                                {
                                    environment = reader.Value;
                                }
                                break;
                            case "DevBaseUrl":
                                if (reader.Read())
                                {
                                    devBaseUrl = reader.Value;
                                }
                                break;
                            case "DevDbConnectString":
                                if (reader.Read())
                                {
                                    devDbConnectString = reader.Value;
                                }
                                break;
                            case "TestBaseUrl":
                                if (reader.Read())
                                {
                                    testBaseUrl = reader.Value;
                                }
                                break;
                            case "TestDbConnectString":
                                if (reader.Read())
                                {
                                    testDbConnectString = reader.Value;
                                }
                                break;
                            case "UserName":
                                if (reader.Read())
                                {
                                    UserName = reader.Value;
                                }
                                break;
                            case "EncryptedPassword":
                                if (reader.Read())
                                {
                                    encryptedPassword = reader.Value;
                                }
                                break;
                            case "EncryptionKey":
                                if (reader.Read())
                                {
                                    encryptionKey = reader.Value;
                                }
                                break;
                        }
                    }
                }
            }

            if (environment.Equals("Dev", StringComparison.InvariantCultureIgnoreCase))
            {
                BaseUrl = devBaseUrl;
                DbConnectionString = devDbConnectString;
            }
            else if (environment.Equals("Test", StringComparison.InvariantCultureIgnoreCase))
            {
                BaseUrl = testBaseUrl;
                DbConnectionString = testDbConnectString;
            }
            else
            {
                throw new ArgumentException();
            }

            Password = EncrytpDecrypt.Decrypt(encryptedPassword, encryptionKey);

            BaseUrl = $"https://{UserName}:{Password}@{BaseUrl}";
        }
    }
}
