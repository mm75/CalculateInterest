using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;
using CalculateInterest.Application.Http;
using CalculateInterest.Application.Interfaces;

namespace CalculateInterest.Application.Services
{
    public class RunService: IRunService
    {
        private readonly IRateService _rateService;
        private readonly IComputeService _computeService;

        /// <summary>
        /// Method responsible for starting the service.
        /// </summary>
        /// <param name="rateService"></param>
        /// <param name="computeService"></param>
        public RunService(IRateService rateService, IComputeService computeService)
        {
            _rateService = rateService;
            _computeService = computeService;
        }

        /// <summary>
        /// Method responsible for performing the calculation.
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<ComputeDTO> Run(double initialValue, int time)
        {
            RateDTO rateDto = await _rateService.GetAsync();

            double result = _computeService.Calculate(initialValue, rateDto.Value, time);

            return new ComputeDTO {Result = result};
        }
    }
}