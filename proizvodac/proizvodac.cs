using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proizvodac
{
    class proizvodac
    {
        static void Main(string[] args)
        {
            var Id = Process.GetCurrentProcess().Id;
            //Console.WriteLine("Argumenti = " + args[0]);
            if (provjeriOkolinu() == 0)
            {
                return;
            }
            string poruka = args[0];
            for (int i = 0; i < poruka.Length; i++)
            {
                if (posaljiPoruku(poruka[i]) == -1)
                {
                    return;
                }
            }
            posaljiPoruku(' ');
            Console.WriteLine("Proizvodac " + Id + " je zavrsio s radom!");
        }

        private static int posaljiPoruku(char c)
        {

            return 0;
        }

        private static int provjeriOkolinu()
        {
            string imeOkoline = "kljucevi";
            if (Environment.GetEnvironmentVariable(imeOkoline) != null)
            {
                return 1;
            }
            return 0;

        }
    }
}
