using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace InVivo.Shared.Library
{
    public static class SharedStringLibrary
    {

        #region Laboratorial Exams

        public static ICollection<decimal[]> SetQuartil(decimal minValue, decimal maxValue)
        {
            decimal minValueQuartil = 0;
            decimal maxValueQuartil = 0;
            decimal constQuartil = 0;
            ICollection<decimal[]> quartil = new List<decimal[]>();

            constQuartil = ((maxValue - minValue) / 4);

            for (int item = 0; item < 4; item++)
            {
                if (maxValueQuartil.Equals(0))
                {
                    minValueQuartil = minValue;
                    maxValueQuartil = minValue + constQuartil;
                }
                else
                {
                    minValueQuartil = maxValueQuartil;
                    maxValueQuartil = minValueQuartil + constQuartil;
                }

                quartil.Add(new decimal[] { minValueQuartil, maxValueQuartil });
            }

            return quartil;
        }

        public static int GetQuartil(decimal valueToCheck, ICollection<decimal[]> valueArray)
        {

            if (valueToCheck >= valueArray.ToList()[0][0] && valueToCheck <= valueArray.ToList()[0][1])
                return 1;

            if (valueToCheck >= valueArray.ToList()[1][0] && valueToCheck <= valueArray.ToList()[1][1])
                return 2;

            if (valueToCheck >= valueArray.ToList()[2][0] && valueToCheck <= valueArray.ToList()[2][1])
                return 3;

            if (valueToCheck >= valueArray.ToList()[3][0] && valueToCheck <= valueArray.ToList()[3][1])
                return 4;

            return -1;
        }

        #endregion

        #region Enumerators

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        #endregion

        #region Encrypting

        public static string EncryptPassword(string pass)
        {
            if (!String.IsNullOrEmpty(pass))
            {
                var password = String.Empty;
                password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
                System.Text.StringBuilder sbString = new System.Text.StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sbString.Append(data[i].ToString("x2"));

                return sbString.ToString();
            }

            return "";
        }

        #endregion

    }
}