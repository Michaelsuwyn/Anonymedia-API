using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBackend1.Models;
using ProjectBackend1.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectBackend1.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        ApplicationDBContext context;
        public UsersController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost("{id}/friends")]
        public string AddFriend(int id, [FromBody] User friend)
        {
            context.Friends.Add(new Friends { UserId = id, FriendId = friend.Id });
            context.Friends.Add(new Friends { UserId = friend.Id, FriendId = id });
            try
            {
                context.SaveChanges();
                return "Friend added";
            }
            catch(Exception )
            {
                return "Something went wrong";
            }
        }

        [HttpGet("{id}/friends")]
        public List<User> GetUser(int id)
        {
            //get all of the friends
            List<Friends> friends = context.Friends.Where(f => f.UserId == id).ToList();

            //create a list to store all friend ids
            List<int> friendIds = new List<int>();

            //add each friends id to the list of friend ids
            foreach(Friends friend in friends)
            {
                friendIds.Add(friend.FriendId);
            }

            //find and return all users with the ids in the friendIds list
            return context.Users.Where(u => friendIds.Contains(u.Id)).ToList();
        }

        // DELETE api/values/
        [HttpDelete("{id}/friends")]
        public void Delete(int id, [FromBody] User friend)
        {
            Friends Deleter = context.Friends.FirstOrDefault<Friends>(f => friend.Id == f.FriendId && id == f.UserId);
            context.Friends.Remove(Deleter);
            context.SaveChanges();
            
            
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users.ToList();
        }

        // GET api/Users/:id/posts
        [HttpGet("{id}/posts")]
        public List<Post> Get(int id)
        {
            return context.Posts.Where<Post>(p => p.userId == id).ToList();
        }

        // POST api/values
        [HttpPost("register")]
        public string register([FromBody]User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(u => u.Username == user.Username);
            if(foundUser != null)
            {
                
                return "Username is not available" ;
            }
            user.Salt = Auth.generateSalt();
            context.Users.Add(user);
            context.SaveChanges();
            return "username is available";
        }

        // POST api/values
        [HttpPost("login")]
        public User login([FromBody]User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(u => u.Username == user.Username && u.Password == user.Password);
            if(foundUser != null)
            {
                return foundUser;
            }
            return null;
        }

       

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

       
    }
}
