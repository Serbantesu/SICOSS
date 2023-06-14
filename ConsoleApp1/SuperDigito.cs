using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SuperDigito
    {
        public static void SuperDig(string numero)
        {
            Console.WriteLine("Ingresa un Numero");
            numero = Console.ReadLine();
            
            int sum = 0;
            int sp = 0;
            if (numero.Length >= 2)
            {
                for (int i = 0; i < numero.Length; i++)
                {
                    sum += Convert.ToInt32(numero.Substring(i, 1));
                }
                if (sum > 0)
                {
                    string res = sum.ToString();
                    for (int i = 0; i < 2; i++)
                    {
                        sp += Convert.ToInt32(res.Substring(i, 1));
                    }
                }
            }
            else
            {
                sp = int.Parse(numero);
            }
         
            Console.WriteLine("El super digito del numero es: " + sp);            
        }
    }
}
