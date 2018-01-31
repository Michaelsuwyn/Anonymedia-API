using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectBackend1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectBackend1.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private ApplicationDBContext context;
        public PostsController(ApplicationDBContext context)
        {
            this.context = context;
        }
             
         

        // GET: api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return context.Posts.ToList();
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return context.Posts.SingleOrDefault<Post>(p => p.ID == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            context.Add(post);
            context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Post Deleter = context.Posts.SingleOrDefault<Post>(p => p.ID == id);
            context.Posts.Remove(Deleter);
            context.SaveChanges();
        }
    }
}
