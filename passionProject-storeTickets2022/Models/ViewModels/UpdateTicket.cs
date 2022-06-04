using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProject_storeTickets2022.Models.ViewModels
{
    public class UpdateTicket
    {
        public TicketDto SelectedTicket { get; set; }

        public IEnumerable<Website> WebsiteOptions { get; set; }


    }
}