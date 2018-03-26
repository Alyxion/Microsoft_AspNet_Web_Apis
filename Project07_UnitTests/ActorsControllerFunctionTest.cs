using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SakilaWebServer.Controllers;
using SakilaWebServer.Models;
using Xunit;

namespace Project07_UnitTests
{
    public class ActorsControllerFunctionTest
    {
        [Fact]
        public void GetActorByIdSmokeTest()
        {
            var controller = new ActorsController();
            var result = controller.Get(101) as OkObjectResult;
            var actor = result.Value as Actor;
            Assert.Equal(actor.Actor_ID, 101);
            Assert.Equal(actor.First_Name, "SUSAN");
            Assert.Equal(actor.Last_Name, "DAVIS");
        }
    }

    public class ActorsControllerEndToEndTest
    {
        [Fact]
        public async void GetActorByIdSmokeTest()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpClient.GetAsync("api/actors/101");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Actor actor = JsonConvert.DeserializeObject<Actor>(jsonString);
                Assert.NotNull(actor);
                Assert.Equal(actor.Actor_ID, 101);
                Assert.Equal(actor.First_Name, "SUSAN");
                Assert.Equal(actor.Last_Name, "DAVIS");
            }
        }
    }
}