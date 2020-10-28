namespace CalculateInterest.Application.Interfaces
{
    public interface IComputeService
    {
        public double Calculate(double initialValue, double rate, int time);
    }
}