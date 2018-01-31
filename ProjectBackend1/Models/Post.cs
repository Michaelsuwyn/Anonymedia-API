using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackend1.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int userId { get; set; }
        public string content { get; set; }
        public DateTime timeCreated { get; set; }
    }
}
