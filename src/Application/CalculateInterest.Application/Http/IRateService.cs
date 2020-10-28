using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;
using Refit;

namespace CalculateInterest.Application.Http
{
    public interface IRateService
    {
        [Get("/taxaJuros")]
        Task<RateDTO> GetAsync();
    }
}