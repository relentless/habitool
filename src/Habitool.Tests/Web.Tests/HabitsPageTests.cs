using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Habitool.Web.Pages;
using Xunit;

namespace Web.Tests
{
    public class HabitsPageTests : BunitContext
    {
        [Fact]
        public async Task HabitsPageDisplaysListFromApi()
        {
            // Arrange: prepare sample response
            var sample = new[]
            {
                new { Id = 1, Title = "Test Habit", Description = "Desc" }
            };

            // create handler that returns sample json
            var handler = new FakeHttpMessageHandler(sample);
            var client = new HttpClient(handler)
            {
                BaseAddress = new System.Uri("https://localhost")
            };
            Services.AddSingleton<HttpClient>(client);

            // Act: render component
            var cut = Render<Habitool.Web.Pages.Habits>();

            // wait for the loading to complete
            await Task.Delay(50);

            // Assert: check that habit appears
            Assert.Contains("Test Habit", cut.Markup);
            Assert.Contains("Desc", cut.Markup);
        }

        private class FakeHttpMessageHandler : HttpMessageHandler
        {
            private readonly object _responseObj;
            public FakeHttpMessageHandler(object responseObj)
            {
                _responseObj = responseObj;
            }
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(_responseObj);
                var msg = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
                };
                return Task.FromResult(msg);
            }
        }
    }
}
