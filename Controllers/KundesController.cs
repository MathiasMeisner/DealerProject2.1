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
    public class KundesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Kundes
        public IQueryable<Kunde> GetKundes()
        {
            return db.Kundes;
        }

        // GET: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult GetKunde(string id)
        {
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }

        // PUT: api/Kundes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKunde(string id, Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kunde.KundeEmail)
            {
                return BadRequest();
            }

            db.Entry(kunde).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/Kundes
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult PostKunde(Kunde kunde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kundes.Add(kunde);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KundeExists(kunde.KundeEmail))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kunde.KundeEmail }, kunde);
        }

        // DELETE: api/Kundes/5
        [ResponseType(typeof(Kunde))]
        public IHttpActionResult DeleteKunde(string id)
        {
            Kunde kunde = db.Kundes.Find(id);
            if (kunde == null)
            {
                return NotFound();
            }

            db.Kundes.Remove(kunde);
            db.SaveChanges();

            return Ok(kunde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KundeExists(string id)
        {
            return db.Kundes.Count(e => e.KundeEmail == id) > 0;
        }
    }
}