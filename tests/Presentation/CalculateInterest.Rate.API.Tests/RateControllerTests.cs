using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace CalculateInterest.Rate.API.Tests
{
    public class RateControllerTests
    {
        private readonly HttpClient _httpClient;

        public RateControllerTests()
        {
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                });

            IHost host = hostBuilder.Start();

            _httpClient = host.GetTestClient();
            
            _httpClient.BaseAddress = new Uri("http://localhost:5000");
        }
        
        [Fact(DisplayName = "Retorna taxa de juros.")]
        [Trait("Category", "Rate")]
        public async Task RateController_Get_RetornaTaxaDeJuros()
        {
            // Arrange
            HttpResponseMessage response = await _httpClient.GetAsync("taxaJuros");

            // Act
            string responseString = await response.Content.ReadAsStringAsync();

            RateDTO result = JsonConvert.DeserializeObject<RateDTO>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.Equal(0.01, result.Value);
        }
    }
}