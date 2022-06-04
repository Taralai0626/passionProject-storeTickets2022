using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace passionProject_storeTickets2022.Models
{
    public class Website
    {
        [Key]
        public int WebsiteId { get; set; }

        public string WebsiteName { get; set; }

        public string WebsiteType { get; set; }
        //select direct sale website or resale website
    }
}