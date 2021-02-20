using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace API_Exam_Prep
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void List_short_URLs()
        {
            var client = new RestClient("https://shorturl.kishy.repl.co/api/urls");
            client.Timeout = 3000;
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.IsTrue(response.ContentType.StartsWith("application/json"));
            var urls = new JsonDeserializer().Deserialize<List<URLResponse>>(response);
            Assert.IsTrue(urls != null);
        }

        [Test]
        public void Find_URL_by_short_code_Valid_Data()
        {
            var client = new RestClient("https://shorturl.kishy.repl.co/api/urls/nak");
            client.Timeout = 3000;
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            var expectedURL = new URLResponse {
                Url = "https://nakov.com",
                ShortCode = "nak",
                ShortUrl = "http://shorturl.kishy.repl.co/go/nak",
                DateCreated = "2021-02-17T14:41:33.000Z",
                Visists = 160
            };


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseURL = new JsonDeserializer().Deserialize<URLResponse>(response);
            Assert.IsTrue(response.ContentType.StartsWith("application/json"));
            AssertObjectsAreEqual(expectedURL, responseURL);
           
        }

        private void AssertObjectsAreEqual(object obj1, object obj2)
        {
            string Obj1Json = new JsonDeserializer().Serialize(obj1);
            string Obj2Json = new JsonDeserializer().Serialize(obj2);
            Assert.AreEqual(Obj1Json, Obj2Json);
        }

        [Test]
        public void Find_URL_by_short_code_InValid_Data()
        {
            var client = new RestClient("https://shorturl.kishy.repl.co/api/urls/naka");
            client.Timeout = 3000;
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Test]
        public void Create_new_short_URL()
        {
            var client = new RestClient("https://shorturl.kishy.repl.co/api/urls/");
            client.Timeout = 3000;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter
                ("application/json", "{\r\n     \"url\" : \"https://www.memecenter.com/\"," +
                "\r\n    \"shortCode\" :  \"meme\"\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            




        }


    }
}