using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace passionProject_storeTickets2022.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string UserName { get; set; }
        //user can create a random name

        public string PhoneNnumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }
    }
}