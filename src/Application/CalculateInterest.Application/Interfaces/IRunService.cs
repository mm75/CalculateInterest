using System.Threading.Tasks;
using CalculateInterest.Application.DTO.DTO;

namespace CalculateInterest.Application.Interfaces
{
    public interface IRunService
    {
        Task<ComputeDTO> Run(double initialValue, int time);
    }
}