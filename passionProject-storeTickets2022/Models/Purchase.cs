using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionProject_storeTickets2022.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }

        [ForeignKey("Tickets")]
        public int TicketId { get; set; }
        public virtual Ticket Tickets { get; set; }
        public DateTime PurchaseDate { get; set; }

        public double PurchasePrice { get; set; }

        public int NumberOfTicket { get; set; }
    }

    public class PurchaseDto
    {
        public int PurchaseId { get; set; }

        public int UserId { get; set; }
       
        public int TicketId { get; set; }
       
        public DateTime PurchaseDate { get; set; }

        public double PurchasePrice { get; set; }

        public int NumberOfTicket { get; set; }

    }
}