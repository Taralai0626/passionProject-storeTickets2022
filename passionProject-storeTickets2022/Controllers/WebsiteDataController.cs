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
using passionProject_storeTickets2022.Models;


namespace passionProject_storeTickets2022.Controllers
{
    public class WebsiteDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WebsiteData/ListWebsites
        [HttpGet]
        public IEnumerable<Website> ListWebsites()
        {
            return db.Websites;
        }

        // GET: api/WebsiteData/FindWebsite/5
        [ResponseType(typeof(Website))]
        [HttpGet]
        public IHttpActionResult FindWebsite(int id)
        {
            Website website = db.Websites.Find(id);
            if (website == null)
            {
                return NotFound();
            }

            return Ok(website);
        }

        // PUT: api/WebsiteData/Updatewebsite/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult updateWebsite(int id, Website website)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != website.WebsiteId)
            {
                return BadRequest();
            }

            db.Entry(website).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(id))
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

        // POST: api/WebsiteData/Addwebsite
        [ResponseType(typeof(Website))]
        [HttpPost]
        public IHttpActionResult AddWebsite(Website website)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Websites.Add(website);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = website.WebsiteId }, website);
        }

        // DELETE: api/WebsiteData/DeleteWebsite/5
        [ResponseType(typeof(Website))]
        [HttpPost]
        public IHttpActionResult DeleteWebsite(int id)
        {
            Website website = db.Websites.Find(id);
            if (website == null)
            {
                return NotFound();
            }

            db.Websites.Remove(website);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebsiteExists(int id)
        {
            return db.Websites.Count(e => e.WebsiteId == id) > 0;
        }
    }
}