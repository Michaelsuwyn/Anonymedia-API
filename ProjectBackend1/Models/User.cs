using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackend1.Models
{
    public class User
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
       
        

    }
}

