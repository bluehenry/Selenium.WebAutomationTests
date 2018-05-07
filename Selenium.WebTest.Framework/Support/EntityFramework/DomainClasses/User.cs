using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selenium.WebTest.Framework.Support.EntityFramework.DomainClasses
{
    [Table("user")]
    public class User
    {
        [Key]
        public System.Guid user_id { get; set; }
        public string user_name { get; set; }
        public string pwd_hash { get; set; }
        public Nullable<int> security_level { get; set; }
        
    }
}
