using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProject_storeTickets2022.Models;
using passionProject_storeTickets2022.Models.ViewModels;
using System.Web.Script.Serialization;

namespace passionProject_storeTickets2022.Controllers
{   
    public class TicketController : Controller
    {
        private static readonly HttpClient client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static TicketController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");
        }
        // GET: Ticket/List
        public ActionResult List()
        {
            //objective: communicate with ticket data api to retrieve a list of tickets
            //curl https://localhost:44399/api/ticketdata/listtickets

            string url = "ticketdata/listtickets";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<TicketDto> tickets = response.Content.ReadAsAsync<IEnumerable<TicketDto>>().Result;
            //Debug.WriteLine("Number of tickets received : ");
            //Debug.WriteLine(ticket.Count());

            return View(tickets);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            //objective: communicate with our ticket data api to rwtrieve one Ticket
            //curl https://localhost:44399/api/ticketdata/findticket/{id}

            string url = "ticketdata/findticket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            TicketDto selectedticket = response.Content.ReadAsAsync<TicketDto>().Result;
            //Debug.WriteLine("Ticket received : ");
            //Debug.WriteLine(selectedTicket.TicketName);
            return View(selectedticket);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Ticket/New
        public ActionResult New()
        {
            string url = "websitedata/listwebsites";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<Website> websiteOptions = response.Content.ReadAsAsync<IEnumerable<Website>>().Result;
            return View(websiteOptions);
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            Debug.WriteLine("the json payload is :");
            Debug.WriteLine(ticket.TicketId);
            //objective: add a new ticket into our system using the API
            //curl -d @ticket.json -H "Content-type:application/json" https://localhost:44399/api/ticketdata/addticket
            string url = "ticketdata/addticket";

            string jsonpayload = jss.Serialize(ticket);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            UpdateTicket ViewModel = new UpdateTicket();

            // the existing animal information
            string url = "ticketdata/findticket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TicketDto SelectedTicket = response.Content.ReadAsAsync<TicketDto>().Result;
            ViewModel.SelectedTicket = SelectedTicket;

            // all website to choose from when updating seleted ticket
            url = "websitedata/listwebsites";
            response = client.GetAsync(url).Result;
            IEnumerable<Website> WebsiteOptions = response.Content.ReadAsAsync<IEnumerable<Website>>().Result;
            ViewModel.WebsiteOptions = WebsiteOptions;
            Debug.WriteLine("pleease tell me what went wrong");
            Debug.WriteLine(ViewModel);
            Debug.WriteLine(url);

            return View(ViewModel);
        }

        // POST: Ticket/Update/5
        [HttpPost]
        public ActionResult Update(int id, TicketDto ticket)
        {
            string url = "ticketdata/updateticket/" + id;
            Debug.WriteLine(url + "This?");
            string jsonpayload = jss.Serialize(ticket);
            Debug.WriteLine(jsonpayload + "or This?");
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            Debug.WriteLine(content + "HELLO");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "ticketdata/findticket/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TicketDto selectedticket = response.Content.ReadAsAsync<TicketDto>().Result;
            return View(selectedticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "ticketdata/deleteticket/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
