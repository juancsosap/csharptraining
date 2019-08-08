using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestedApp.Models;
using TestedApp.Models.DAO;

namespace TestedApp.Controllers
{
    public class PeopleController : ApiController
    {
        private IDAO<Person> db;

        public PeopleController()
        {
            this.db = new DAOEF<Person, AppDBContext>();
        }

        public PeopleController(IDAO<Person> db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Person> GetMany(int limit = 10, int offset = 0)
        {
            return db.RetriveMany(limit, offset);
        }

        [HttpGet]
        [ResponseType(typeof(Person))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            try
            {
                Person person = db.Retrive(id);
                return Request.CreateResponse(HttpStatusCode.OK, person);
            }
            catch (InvalidOperationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            
            if (id != person.id)
                return Request.CreateResponse(HttpStatusCode.BadRequest, id);

            try
            {
                db.Update(person);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (InvalidOperationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Person))]
        public HttpResponseMessage Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Person p = db.Create(person);
            return Request.CreateResponse(HttpStatusCode.Created, p);
        }

        [HttpDelete]
        [ResponseType(typeof(Person))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                Person p = db.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, p);
            }
            catch (InvalidOperationException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
    }
}