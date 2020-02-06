using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    public class Guard
    {
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ValidateCoordinate(double latitude, double longitude,
            string latitudeParamName, string longitudeParamName)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException(latitudeParamName);
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new ArgumentOutOfRangeException(longitudeParamName);
            }
        }
    }
}
