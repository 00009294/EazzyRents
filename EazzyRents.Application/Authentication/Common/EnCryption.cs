using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Authentication.Common
{
    public static class EnCryption
    {
        public static string EnCrypt(string message)
        {
            const byte _num = 3;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var letter in message)
            {
                char temp = (char)((int)letter + _num);
                stringBuilder.Append(temp);
            }
            return stringBuilder.ToString();
        }
    }
}
