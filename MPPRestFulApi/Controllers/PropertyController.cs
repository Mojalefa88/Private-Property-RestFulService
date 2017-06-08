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
    public class PropertyController : Controller
    {
        private readonly mppDBContext context;

        public PropertyController(mppDBContext context)
        {
            this.context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Properties> Get()
        {
            return context.Properties;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Properties Get(int id)
        {
            return context.Properties.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Properties property)
        {
            if (ModelState.IsValid)
            {
                context.Properties.Add(property);
                context.SaveChanges();
            }
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Properties property)
        {
            if (ModelState.IsValid)
            {
                if(id == property.PropertyId)
                {
                    context.Entry(property).State = EntityState.Modified;
                    context.SaveChanges();
                }
                
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Properties property = context.Properties.SingleOrDefault(p => p.PropertyId == id);

            if(property != null)
            {
                context.Properties.Remove(property);
                context.SaveChanges();
            }
        }
    }
}
