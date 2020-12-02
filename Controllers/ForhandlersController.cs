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
using DealerProject;

namespace DealerProject.Controllers
{
    public class ForhandlersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Forhandlers
        public IQueryable<Forhandler> GetForhandlers()
        {
            return db.Forhandlers;
        }

        // GET: api/Forhandlers/5
        [ResponseType(typeof(Forhandler))]
        public IHttpActionResult GetForhandler(int id)
        {
            Forhandler forhandler = db.Forhandlers.Find(id);
            if (forhandler == null)
            {
                return NotFound();
            }

            return Ok(forhandler);
        }

        // PUT: api/Forhandlers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutForhandler(int id, Forhandler forhandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != forhandler.ForhandlerID)
            {
                return BadRequest();
            }

            db.Entry(forhandler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForhandlerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Forhandlers
        [ResponseType(typeof(Forhandler))]
        public IHttpActionResult PostForhandler(Forhandler forhandler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Forhandlers.Add(forhandler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = forhandler.ForhandlerID }, forhandler);
        }

        // DELETE: api/Forhandlers/5
        [ResponseType(typeof(Forhandler))]
        public IHttpActionResult DeleteForhandler(int id)
        {
            Forhandler forhandler = db.Forhandlers.Find(id);
            if (forhandler == null)
            {
                return NotFound();
            }

            db.Forhandlers.Remove(forhandler);
            db.SaveChanges();

            return Ok(forhandler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ForhandlerExists(int id)
        {
            return db.Forhandlers.Count(e => e.ForhandlerID == id) > 0;
        }
    }
}