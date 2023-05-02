using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lavanderia
{
    public class Helper
    {
        public static int ReturnRandomNumber(int num1, int num2)
        {
            num2++;
            Random rdn = new Random();
            return rdn.Next(num1, num2);
        }

        public static (string comando, int n_macchina, int altro_parametro) SplitInputString(string input)
        {
            var inputString = input.Split(" ");
            string comando = "";
            int n_macchina = -1;
            int altro_parametro = -1;
            try
            {
                comando = inputString[0];
                n_macchina = int.Parse(inputString[1]);
                altro_parametro = int.Parse(inputString[2]);
            }
            catch
            {
            }

            return (comando, n_macchina, altro_parametro);
        }
    }
}
