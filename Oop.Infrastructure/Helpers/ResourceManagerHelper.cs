using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Infrastructure.Helpers
{
    public static class ResourceManagerHelper
    {
        public static string FindValueInResources(Enum value)
        {
            return Resource.Resource.ResourceManager.GetString(value.ToString());
        }

        public static string FindValueInResources(string value)
        {
            try
            {
                var result = Resource.Resource.ResourceManager.GetString(value.UppercaseWords().Replace(" ", ""));
                return result ?? value;
            }
            catch (Exception)
            {
                return value;
            }
        }

        private static string UppercaseWords(this string value)
        {
            char[] array = value.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }
}
