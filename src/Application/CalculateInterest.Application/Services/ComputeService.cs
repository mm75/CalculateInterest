using System;
using CalculateInterest.Application.Interfaces;
using CalculateInterest.Core;

namespace CalculateInterest.Application.Services
{
    public class ComputeService : IComputeService
    {
        public double Calculate(double initialValue, double rate, int time)
        {
            Validations.ValidateValueLessThanOrEqualToMinimum(initialValue, 0, "O valor inicial deve ser maior que zero.");
            Validations.ValidateValueLessThanMinimum(rate, 0, "A taxa de juros deve ser maior ou igual a zero.");
            Validations.ValidateValueLessThanOrEqualToMinimum(time, 0, "O total de meses deve ser maior que zero.");
            
            double calcResult = initialValue * Math.Pow((1 + rate), time);

            return Math.Truncate(100 * calcResult) / 100;
        }
    }
}