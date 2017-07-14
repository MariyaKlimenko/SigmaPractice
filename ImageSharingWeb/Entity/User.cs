using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageSharing.Data.Entity
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; }
       

    }
}
