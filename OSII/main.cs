using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSII
{
    class main
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite broj proizvodaca: ");
            int br_proizvodaca = int.Parse(Console.ReadLine());

            Process[] procesi = new Process[br_proizvodaca + 1];
            string[] znakovi = new string[br_proizvodaca];

            for (int i = 0; i < br_proizvodaca; i++)
            {
                Console.WriteLine("Unesite znakove za " + (i + 1) + ". proizvodaca");
                znakovi[i] = Console.ReadLine();
            }

            postaviOkolinu(znakovi, br_proizvodaca);

            for (int i = 0; i < br_proizvodaca; i++)
            {
                procesi[i] = new Process();
                procesi[i].StartInfo.Arguments = znakovi[i];
                procesi[i].StartInfo.UseShellExecute = false;
                procesi[i].StartInfo.FileName = "../../../proizvodac/bin/Debug/proizvodac.exe";
                procesi[i].Start();
            }
            procesi[br_proizvodaca + 1] = new Process();
            procesi[br_proizvodaca + 1].StartInfo.FileName = "../../../potrosac/bin/Debug/potrosac.exe";
            procesi[br_proizvodaca + 1].StartInfo.UseShellExecute = false;
            procesi[br_proizvodaca + 1].Start();

            for (int i = 0; i < br_proizvodaca + 1; i++)
            {
                procesi[i].WaitForExit();
            }


            Console.WriteLine("Glavni program je zavrsio s radom!");
            Console.ReadLine();
        }

        private static void kreirajRedPoruka()
        {
            
        }
        private static void postaviOkolinu(string[] znakovi, int br_proizvodaca)
        {
            string imeOkoline = "kljucevi";
            if (Environment.GetEnvironmentVariable(imeOkoline) == null)
            {
                for (int i = 0; i < br_proizvodaca; i++)
                {
                    Environment.SetEnvironmentVariable(imeOkoline, znakovi[i]);
                }
            }
        }
    }
}
