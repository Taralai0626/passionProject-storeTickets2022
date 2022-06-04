using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProject_storeTickets2022.Models
{
    public class MutipleModels
    {
        public int PurchaseId { get; set; }

        public int UserId { get; set; }

        public int TicketId { get; set; }

        public string EventName { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string WebsiteName { get; set; }

        public DateTime PurchaseDate { get; set; }

        public double PurchacePrice { get; set; }

        public int NumberOfTicket { get; set; }

    }
}


//@Html.LabelFor(model => model.User.UserName)
//@Html.LabelFor(model => model.Product.ProductName)
//@Html.LabelFor(model => model.Address.StreetName)