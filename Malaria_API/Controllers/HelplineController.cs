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
    public class HelplineController : ApiController
    {

        private DBMobileEntities db = new DBMobileEntities();

        //GET HELPLINE

            public IQueryable<Help_Line> GetHelpline()
        {
            return db.Help_Line;
        }

        [Route("api/Help_Line/Get")]
        [System.Web.Mvc.HttpPost]

        public List<dynamic> Get()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return getHelplinereturnList(db.Help_Line.ToList());
        }

        private List<dynamic> getHelplinereturnList(List<Help_Line>forHelpline)
        {
            List<dynamic> dynamicHelpline = new List<dynamic>();

            foreach(Help_Line help in forHelpline)
            {
                dynamic hline = new ExpandoObject();
                hline.Help_Line_ID = help.Help_Line_ID;
                hline.Help_Line_Contact = help.Help_Line_Contact;
                hline.Help_Line_Practioner = help.Help_Line_Practioner;
                dynamicHelpline.Add(hline);
            }
            return dynamicHelpline;
        }

       // get:api/helpline

        //    public IQueryable<Help_Line> GetHelpline()
        //{
        //    return db.Help_Line;
        //}


        //get:api/helpline
        [ResponseType(typeof(Help_Line))]
        public IHttpActionResult Gethelp(int id)

        {
            Help_Line help = db.Help_Line.Find(id);
            if(help==null)
            {
                return NotFound();
            }

            return Ok(help);
        }

        //PUT api/Helpline/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHelpline(int id,Help_Line help)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id !=help.Help_Line_ID)
            {
                return BadRequest();
            }

            db.Entry(help).State = EntityState.Modified;

            try
            {
                db.SaveChanges();

            }

            catch(DbUpdateConcurrencyException)
            {
                if(!HelplineExists(id))
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

        //POST api/Helpline
        [ResponseType(typeof(Help_Line))]
        public IHttpActionResult PostHelpline(Help_Line help)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Help_Line.Add(help);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = help.Help_Line_ID }, help);
        }

        // DELETE: api/Statistics/5
        [ResponseType(typeof(Help_Line))]
        public IHttpActionResult DeleteHelpline(int id)
        {
            Help_Line helpline = db.Help_Line.Find(id);

            if (helpline == null)
            {
                return NotFound();
            }

            db.Help_Line.Remove(helpline);
            db.SaveChanges();

            return Ok(helpline);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HelplineExists(int id)
        {
            return db.Help_Line.Count(e => e.Help_Line_ID == id) > 0;
        }
    }

    }
