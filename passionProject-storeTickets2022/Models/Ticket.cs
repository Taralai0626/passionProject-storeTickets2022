using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionProject_storeTickets2022.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        //a ticket belong to a website
        //a website can have many ticket
        [ForeignKey("Websites")]
        public int WebsiteId { get; set; }
        public virtual Website Websites { get; set; }

        public string EventName { get; set; }

        public string EventType { get; set; }

        public string EventVenue { get; set; }

        public string EventLocation { get; set; }

        public DateTime EventDate { get; set; }

        public double TicketStartingPrice { get; set; }

    }
    public class TicketDto
    {
        public int TicketId { get; set; }

        public int WebsiteId { get; set; }

        public string EventName { get; set; }

        public string EventType { get; set; }

        public string EventVenue { get; set; }

        public string EventLocation { get; set; }

        public DateTime EventDate { get; set; }

        public double TicketStartingPrice { get; set; }



    }
}