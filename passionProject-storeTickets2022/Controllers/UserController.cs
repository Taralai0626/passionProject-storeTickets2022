using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionProject_storeTickets2022.Models;
//using passionProject_storeTickets2022.Models.ViewModels;
using System.Web.Script.Serialization;

namespace passionProject_storeTickets2022.Controllers
{
    public class UserController : Controller
    {
        private static readonly HttpClient client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static UserController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44399/api/");
        }
    
        // GET: User/List
        public ActionResult List()
        
        {
            //objective: communicate with our animal data api to retrieve a list of animals
            //curl https://localhost:44399/api/userdata/listusers

            string url = "userdata/listusers";
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<User> users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            //Debug.WriteLine("Number of users received : ");
            //Debug.WriteLine(users.Count());

            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            //objective: communicate with our animal data api to rwtrieve one user
            //curl https://localhost:44399/api/userdata/finduser/{id}

            string url = "userdata/finduser/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is ");
            //Debug.WriteLine(response.StatusCode);

            User selecteduser = response.Content.ReadAsAsync<User>().Result;
            //Debug.WriteLine("User received : ");
            //Debug.WriteLine(selecteduser.UserName);

            return View(selecteduser);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: User/New
        public ActionResult New()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            Debug.WriteLine("the json payload is :");
            Debug.WriteLine(user.UserLastName);
            //objective: add a new user into our system using the API
            //curl -d @user.json -H "Content-type:application/json" https://localhost:44399/api/userdata/adduser
            string url = "userdata/adduser";

            string jsonpayload = jss.Serialize(user);

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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "userdata/finduser/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            User selecteduser = response.Content.ReadAsAsync<User>().Result;
            return View(selecteduser);
        }

        // POST: User/Update/5
        [HttpPost]
        public ActionResult Update(int id, User user)
        {
            string url = "userdata/updateuser/" + id;
            string jsonpayload = jss.Serialize(user);
            Debug.WriteLine(jsonpayload + "or This?");
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
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

        // GET: User/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "userdata/finduser/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            User selecteduser = response.Content.ReadAsAsync<User>().Result;
            return View(selecteduser);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "userdata/deleteuser/" + id;
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
