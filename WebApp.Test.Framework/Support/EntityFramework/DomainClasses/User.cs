using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Test.Framework.Support.EntityFramework.DomainClasses
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
