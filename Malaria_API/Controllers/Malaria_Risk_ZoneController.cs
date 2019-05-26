using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Malaria_API.Models;


namespace Malaria_API.Controllers
{
    public class Malaria_Risk_ZoneController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();

        [Route("api/Malaria_Risk_Zone/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getAboutreturnList(db.Malaria_Risk_Zone.ToList());
        }

        private List<dynamic> getAboutreturnList(List<Malaria_Risk_Zone> forRiskZone)
        {
            List<dynamic> dynamicRisk = new List<dynamic>();

            foreach (Malaria_Risk_Zone riskZoner in forRiskZone)
            {
                dynamic rzone = new ExpandoObject();
                rzone.RiskZone_ID = riskZoner.Malaria_Risk_Zone_ID;
                rzone.Location = riskZoner.Risk_Zone_Location; 
                rzone.Post_description = riskZoner.Risk_Zone;
                rzone.Severity = riskZoner.Severity;
                dynamicRisk.Add(rzone);
            }

            return dynamicRisk;
        }

        // GET: api/Malaria_Risk_Zone
        //public IQueryable<Malaria_Risk_Zone> GetMalaria_Risk_Zone()
        //{
        //    return db.Malaria_Risk_Zone;
        //}

        // GET: api/Malaria_Risk_Zone/5
        [ResponseType(typeof(Malaria_Risk_Zone))]
        public IHttpActionResult GetMalaria_Risk_Zone(int id)
        {
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            if (malaria_Risk_Zone == null)
            {
                return NotFound();
            }

            return Ok(malaria_Risk_Zone);
        }

        // PUT: api/Malaria_Risk_Zone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMalaria_Risk_Zone(int id, Malaria_Risk_Zone malaria_Risk_Zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != malaria_Risk_Zone.Malaria_Risk_Zone_ID)
            {
                return BadRequest();
            }

            db.Entry(malaria_Risk_Zone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Malaria_Risk_ZoneExists(id))
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

        // POST: api/Malaria_Risk_Zone
        [ResponseType(typeof(Malaria_Risk_Zone))]
        public IHttpActionResult PostMalaria_Risk_Zone(Malaria_Risk_Zone malaria_Risk_Zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Malaria_Risk_Zone.Add(malaria_Risk_Zone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = malaria_Risk_Zone.Malaria_Risk_Zone_ID }, malaria_Risk_Zone);
        }

        // DELETE: api/Malaria_Risk_Zone/5
        [ResponseType(typeof(Malaria_Risk_Zone))]
        public IHttpActionResult DeleteMalaria_Risk_Zone(int id)
        {
            Malaria_Risk_Zone malaria_Risk_Zone = db.Malaria_Risk_Zone.Find(id);
            if (malaria_Risk_Zone == null)
            {
                return NotFound();
            }

            db.Malaria_Risk_Zone.Remove(malaria_Risk_Zone);
            db.SaveChanges();

            return Ok(malaria_Risk_Zone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Malaria_Risk_ZoneExists(int id)
        {
            return db.Malaria_Risk_Zone.Count(e => e.Malaria_Risk_Zone_ID == id) > 0;
        }
    }
}