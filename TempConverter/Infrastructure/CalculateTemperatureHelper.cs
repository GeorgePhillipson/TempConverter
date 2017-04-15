using System.Collections.Generic;

namespace TempConverter.Infrastructure
{
    public static class CalculateTemperatureHelper
    {
        public static List<string> TempList(int value, string option)
        {
            List<string> lstOfTemps = new List<string>();

            switch (option)
            {
                case "1":
                    for (int i = value; i < value + 100; i += 1)
                    {
                        lstOfTemps.Add(
                            $"The temperature at {i:N}°C is {TemperatureConversionFormula.CelsiusToFahrenheit(i):N}°F");
                    }
                    break;
                case "2":
                    for (int i = value; i < 100; i += 1)
                    {
                        lstOfTemps.Add(
                            $"The temperature at {i:N}°F is {TemperatureConversionFormula.FahrenheitToCelsius(i):N}°C");
                    }
                    break;
                default:
                    lstOfTemps.Add($"The temperature conversion option you selected is not valid.");
                    break;
            }
            return lstOfTemps;
        }

        private static class TemperatureConversionFormula
        {
            public static double CelsiusToFahrenheit(int value)
            {
                return ((9.0 / 5.0) * value) + 32;
            }

            public static double FahrenheitToCelsius(int value)
            {
                return (5.0 / 9.0) * (value - 32);
            }
        }
    }
}