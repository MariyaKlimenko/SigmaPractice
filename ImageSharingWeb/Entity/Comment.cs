using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ImageSharing.Data.Entity
{
    public class Comment : Entity
    { 
        public User User { get; set; }
        public Post Post { get; set; }
        public string Commentary { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
