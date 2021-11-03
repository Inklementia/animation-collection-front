﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AnimationCollectionUI
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            string Baseurl = "http://ec2-54-89-162-123.compute-1.amazonaws.com/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}