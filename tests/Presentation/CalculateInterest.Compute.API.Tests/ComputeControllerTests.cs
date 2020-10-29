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
using ApplicationException = CalculateInterest.Core.ApplicationException;

namespace CalculateInterest.Compute.API.Tests
{
    public class ComputeControllerTests
    {
        private readonly HttpClient _httpClient;

        public ComputeControllerTests()
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
        
        [Fact(DisplayName = "Executar o cálculo da taxa de juros.")]
        [Trait("Category", "Compute")]
        public async Task ComputeController_Get_ExecutarCalculoDeJuros()
        {
            // Arrange
            HttpResponseMessage response = await _httpClient.GetAsync("calculajuros?initialValue=100&time=5");

            // Act
            string responseString = await response.Content.ReadAsStringAsync();

            ComputeDto result = JsonConvert.DeserializeObject<ComputeDto>(responseString);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.Equal(105.10, result.Result);
        }
        
        [Fact(DisplayName = "Retornar erro ao validar se o valor inicial é menor ou igual a zero.")]
        [Trait("Category", "Compute")]
        public async Task ComputeController_Get_DeveRetornarErroAoValidarValorInicialMenorOuIgualZero()
        {
            await Assert.ThrowsAsync<ApplicationException>(() => _httpClient.GetAsync("calculajuros?initialValue=0&time=5"));
        }
        
        [Fact(DisplayName = "Retornar erro ao validar se o mês é menor ou igual a zero.")]
        [Trait("Category", "Compute")]
        public async Task ComputeController_Get_DeveRetornarErroAoValidarMesMenorOuIgualZero()
        {
            await Assert.ThrowsAsync<ApplicationException>(() => _httpClient.GetAsync("calculajuros?initialValue=100&time=0"));
        }
    }
}