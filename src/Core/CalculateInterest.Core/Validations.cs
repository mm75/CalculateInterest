namespace CalculateInterest.Core
{
    public class Validations
    {
        public static void ValidateValueLessThanOrEqualToMinimum(double value, double minimum, string message)
        {
            if (value <= minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanOrEqualToMinimum(float value, float minimum, string message)
        {
            if (value <= minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanOrEqualToMinimum(decimal value, decimal minimum, string message)
        {
            if (value <= minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanOrEqualToMinimum(int value, int minimum, string message)
        {
            if (value <= minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanMinimum(double value, double minimum, string message)
        {
            if (value < minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanMinimum(float value, float minimum, string message)
        {
            if (value < minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanMinimum(decimal value, decimal minimum, string message)
        {
            if (value < minimum)
                throw new ApplicationException(message);
        }

        public static void ValidateValueLessThanMinimum(int value, int minimum, string message)
        {
            if (value < minimum)
                throw new ApplicationException(message);
        }
    }
}