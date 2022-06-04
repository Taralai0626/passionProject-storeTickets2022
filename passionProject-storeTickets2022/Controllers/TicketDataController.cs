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
    public class TicketDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TicketData/ListTickets
        [HttpGet]
        [ResponseType(typeof(TicketDto))]
        public IHttpActionResult ListTickets()
        {
            List<Ticket> Tickets = db.Tickets.ToList();
            List<TicketDto> TicketDtos = new List<TicketDto>();

            Tickets.ForEach(a => TicketDtos.Add(new TicketDto()
            {
                TicketId = a.TicketId,
                WebsiteId = a.Websites.WebsiteId,
                EventName = a.EventName,
                EventType = a.EventType,
                EventVenue = a.EventVenue,
                EventLocation = a.EventLocation,
                EventDate = a.EventDate,
                TicketStartingPrice = a.TicketStartingPrice
            }));

            return Ok(TicketDtos);
        }

        [HttpGet]
        [ResponseType(typeof(TicketDto))]
        public IHttpActionResult ListTicketForWebsite(int id)
        {
            List<Ticket> Tickets = db.Tickets.Where(a => a.WebsiteId == id).ToList();
            List<TicketDto> TicketDtos = new List<TicketDto>();

            Tickets.ForEach(a => TicketDtos.Add(new TicketDto()
            {
                TicketId = a.TicketId,
                WebsiteId = a.Websites.WebsiteId,
                EventName = a.EventName,
                EventType = a.EventType,
                EventVenue = a.EventVenue,
                EventLocation = a.EventLocation,
                EventDate = a.EventDate,
                TicketStartingPrice = a.TicketStartingPrice
            }));

            return Ok(TicketDtos);
        }


        // GET: api/TicketData/FindTicket/5
        [ResponseType(typeof(TicketDto))]
        [HttpGet]
        public IHttpActionResult FindTicket(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            TicketDto TicketDto = new TicketDto()
            {
                TicketId = ticket.TicketId,
                WebsiteId = ticket.Websites.WebsiteId,
                EventName = ticket.EventName,
                EventType = ticket.EventType,
                EventVenue = ticket.EventVenue,
                EventLocation = ticket.EventLocation,
                EventDate = ticket.EventDate,
                TicketStartingPrice = ticket.TicketStartingPrice
            };
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(TicketDto);
        }

        // PUT: api/TicketData/UpdateTicket/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Updateicket(int id, Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            db.Entry(ticket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/TicketData/AddTicket
        [ResponseType(typeof(Ticket))]
        [HttpPost]
        public IHttpActionResult AddTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tickets.Add(ticket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticket.TicketId }, ticket);
        }

        // DELETE: api/TicketData/DeleteTicket/5
        [ResponseType(typeof(Ticket))]
        [HttpPost]
        public IHttpActionResult DeleteTicket(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            db.Tickets.Remove(ticket);
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

        private bool TicketExists(int id)
        {
            return db.Tickets.Count(e => e.TicketId == id) > 0;
        }
    }
}