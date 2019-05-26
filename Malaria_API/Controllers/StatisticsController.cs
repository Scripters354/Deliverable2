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
    public class StatisticsController : ApiController
    {
        private DBMobileEntities db = new DBMobileEntities();

        // GET: api/Statistics
        public IQueryable<Statistic> GetStatistics()
        {
            return db.Statistics;
        }

        [Route("api/Statistics/Get")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getStatisticsreturnList(db.Statistics.ToList());
        }

        private List<dynamic> getStatisticsreturnList(List<Statistic> forStatistics)
        {
            List<dynamic> dynamicStatistics = new List<dynamic>();

            foreach (Statistic statistic in forStatistics)
            {
                dynamic XStats = new ExpandoObject();
                XStats.Statistics_ID = statistic.Statistic_ID;
         
                XStats.Malaria_Case = statistic.Malaria_Case;
                XStats.Malaria_Incidence = statistic.Malaria_Incidence;
                XStats.Malaria_Mortality_Percentage = statistic.Malaria_Mortality_Percentage;
                dynamicStatistics.Add(XStats);
            }

            return dynamicStatistics;
        }
        // GET: api/Statistics/5
        [ResponseType(typeof(Statistic))]
        public IHttpActionResult GetStatistic(int id)
        {
            Statistic statistic = db.Statistics.Find(id);
            if (statistic == null)
            {
                return NotFound();
            }

            return Ok(statistic);
        }

        // PUT: api/Statistics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatistic(int id, Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistic.Statistic_ID)
            {
                return BadRequest();
            }

            db.Entry(statistic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticExists(id))
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

        // POST: api/Statistics
        [ResponseType(typeof(Statistic))]
        public IHttpActionResult PostStatistic(Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statistics.Add(statistic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statistic.Statistic_ID }, statistic);
        }

        // DELETE: api/Statistics/5
        [ResponseType(typeof(Statistic))]
        public IHttpActionResult DeleteStatistic(int id)
        {
            Statistic statistic = db.Statistics.Find(id);
            if (statistic == null)
            {
                return NotFound();
            }

            db.Statistics.Remove(statistic);
            db.SaveChanges();

            return Ok(statistic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatisticExists(int id)
        {
            return db.Statistics.Count(e => e.Statistic_ID == id) > 0;
        }
    }
}