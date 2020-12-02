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
    public class MedarbejdersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Medarbejders
        public IQueryable<Medarbejder> GetMedarbejders()
        {
            return db.Medarbejders;
        }

        // GET: api/Medarbejders/5
        [ResponseType(typeof(Medarbejder))]
        public IHttpActionResult GetMedarbejder(int id)
        {
            Medarbejder medarbejder = db.Medarbejders.Find(id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            return Ok(medarbejder);
        }

        // PUT: api/Medarbejders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedarbejder(int id, Medarbejder medarbejder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medarbejder.MedarbejderID)
            {
                return BadRequest();
            }

            db.Entry(medarbejder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedarbejderExists(id))
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

        // POST: api/Medarbejders
        [ResponseType(typeof(Medarbejder))]
        public IHttpActionResult PostMedarbejder(Medarbejder medarbejder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medarbejders.Add(medarbejder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medarbejder.MedarbejderID }, medarbejder);
        }

        // DELETE: api/Medarbejders/5
        [ResponseType(typeof(Medarbejder))]
        public IHttpActionResult DeleteMedarbejder(int id)
        {
            Medarbejder medarbejder = db.Medarbejders.Find(id);
            if (medarbejder == null)
            {
                return NotFound();
            }

            db.Medarbejders.Remove(medarbejder);
            db.SaveChanges();

            return Ok(medarbejder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedarbejderExists(int id)
        {
            return db.Medarbejders.Count(e => e.MedarbejderID == id) > 0;
        }
    }
}