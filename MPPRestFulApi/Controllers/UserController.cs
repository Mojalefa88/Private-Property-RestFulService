using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPPRestFulApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MPPRestFulApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private mppDBContext context;

        public UserController(mppDBContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return context.Users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return context.Users.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Users user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Users user)
        {
            
               if(id == user.Id)
                {
                    context.Entry(user).State = EntityState.Modified;
                }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Users user = context.Users.SingleOrDefault(u => u.Id == id);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
