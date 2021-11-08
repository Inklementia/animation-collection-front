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
        private HttpClient _httpClient;
        public AnimationController()
        {
            _httpClient = HttpClientHelper.GetHttpClient();
        }

        // GET: Animation
        public async Task<ActionResult> Index()
        {
          
            List<Animation> animationList = new List<Animation>();

            HttpResponseMessage Res = await _httpClient.GetAsync("api/Animation");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Animation list
                animationList = JsonConvert.DeserializeObject<List<Animation>>(PrResponse);

            }
            return View(animationList);
        }

        // GET: Animation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            // if no id in url -> home
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // geting Animation page
            Animation animation = null;

            HttpResponseMessage Res = await _httpClient.GetAsync("api/Animation/"+ id);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Animation
                animation = JsonConvert.DeserializeObject<Animation>(PrResponse);

            }
            else
            {
                // if no response => back to index
                return RedirectToAction("Index");
            }
            return View(animation);
        }

        // GET: Animation/Create
        public ActionResult Create()
        {
            var animationViewModel = new Animation();
            return View(animationViewModel);
        }

        // POST: Animation/Create
        [HttpPost]
        public async Task<ActionResult> Create(Animation anim)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/Animation/", anim);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(anim);
            }
            catch
            {
                return View();
            }
        }

        // GET: Animation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            // if no id in url -> home
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // geting Animation page
            Animation animation = null;

            HttpResponseMessage Res = await _httpClient.GetAsync("api/Animation/" + id);
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var PrResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Animation
                animation = JsonConvert.DeserializeObject<Animation>(PrResponse);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(animation);
     
        }

        // POST: Animation/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Animation anim)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync("api/Animation/" + anim.Id, anim);
                //Checking the response is successful or not which is sent using HttpClient
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(anim);
            }
            catch
            {
                return View();
            }
        }

        // GET: Animation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            // if no id in url -> home
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // geting Animation page
            Animation animation = null;
            //Checking the response is successful or not which is sent using HttpClient
            HttpResponseMessage Res = await _httpClient.GetAsync("api/Animation/" + id);

            if (Res.IsSuccessStatusCode)
            {
                var PrResponse = await Res.Content.ReadAsStringAsync();
                //Deserializing the response recieved from web api and storing into the Animation
                animation = JsonConvert.DeserializeObject<Animation>(PrResponse);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View(animation);
        }

        // POST: Animation/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Animation anim)
        {
            try
            {
                // getting Animation
                HttpResponseMessage Res = await _httpClient.GetAsync("api/Animation/" + id);
                Animation animation = null;
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    var PrResponse = await Res.Content.ReadAsStringAsync();
                    //Deserializing the response recieved from web api and storing into the Animation list
                    animation = JsonConvert.DeserializeObject<Animation>(PrResponse);
                }
                // deleteing Animation
                var result = await _httpClient.DeleteAsync("api/Animation/" + anim.Id);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View(animation);
            }
            catch
            {
                return View();
            }
        }
    }
}
