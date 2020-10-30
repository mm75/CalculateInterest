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

namespace CalculateInterest.Compute.API.Tests
{
    public class ShowMeTheCodeControllerTests
    {
        private readonly HttpClient _httpClient;
        
        public ShowMeTheCodeControllerTests()
        {
            IHostBuilder hostBuilder = new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                });

            IHost host = hostBuilder.Start();

            _httpClient = host.GetTestClient();
            
            _httpClient.BaseAddress = new Uri("http://localhost:6005");
        }
        
        [Fact(DisplayName = "Retorna o endereço do GitHub.")]
        [Trait("Category", "ShowMeTheCode")]
        public async Task ShowMeTheCodeController_Index_DeveRetornarEndereco()
        {
            // Arrange
            HttpResponseMessage response = await _httpClient.GetAsync("showmethecode");

            // Act
            string responseString = await response.Content.ReadAsStringAsync();

            ShowMeTheCodeDto result = JsonConvert.DeserializeObject<ShowMeTheCodeDto>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.Equal("https://github.com/mm75/CalculateInterest", result.UrlGitHub);
        }
    }
}