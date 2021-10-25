using AnimationCollectionUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnimationCollectionUI.Controllers
{
    public class AnimationController : Controller
    {
        // GET: Animation
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:23520/";

            List<Animation> animationList = new List<Animation>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAll Animations using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Animation");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Product list
                    animationList = JsonConvert.DeserializeObject<List<Animation>>(PrResponse);
                  
                }
                return View(animationList);
            }
        }

            // GET: Animation/Details/5
        public async Task<ActionResult> Details(int id)
        {
   
            return View();
        }

        // GET: Animation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
