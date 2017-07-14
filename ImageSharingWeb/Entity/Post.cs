using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSharing.Data.Entity
{
    public class Post : Entity
    {
        public string Image { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
