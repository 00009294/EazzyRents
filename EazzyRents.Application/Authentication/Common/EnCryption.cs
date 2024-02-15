using System.Text;

namespace EazzyRents.Application.Authentication.Common
{
      public static class EnCryption
      {
            public static string EnCrypt(string message)
            {
                  const byte _num = 3;

                  StringBuilder stringBuilder = new StringBuilder();
                  foreach(var letter in message)
                  {
                        char temp = (char)((int)letter + _num);
                        stringBuilder.Append(temp);
                  }
                  return stringBuilder.ToString();
            }
      }
}
