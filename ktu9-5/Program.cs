using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_5
{
    class Program
    {
        private static void skaiciavimas(ref int dienuPlius, ref Duomenys[] duomenys, int dienuSkaicius, double[] perDiena, string[] duom)
        {
            for (int i = 0; i < dienuSkaicius; i++)
            {
                if (perDiena[i] * 349 >= 1800)
                {
                    dienuPlius++;
                }
                double angliavandeniai = perDiena[i] * Convert.ToDouble(duom[0]);
                double baltymai = perDiena[i] * Convert.ToDouble(duom[1]);
                double riebalai = perDiena[i] * Convert.ToDouble(duom[2]);
                duomenys[i] = new Duomenys(angliavandeniai, baltymai, riebalai);
            }
        }
        private static double[] suvartojoGrikiu(string[] tekstas, int dienuSkaicius)
        {
            double[] perDiena = new double[dienuSkaicius];
            for (int i = 0; i < dienuSkaicius; i++)
            {
                perDiena[i] = Convert.ToDouble(tekstas[i + 2]) / 100;
            }

            return perDiena;
        }
        static void Main(string[] args)
        {
            string[] tekstas = System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-5\ktu9-5\duomenys.txt");
            int dienuSkaicius = Convert.ToInt32(tekstas[0]);
            string[] duom = tekstas[1].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            double[] perDiena = suvartojoGrikiu(tekstas, dienuSkaicius);

            int dienuPlius = 0;
            Duomenys[] duomenys = new Duomenys[dienuSkaicius];

            skaiciavimas(ref dienuPlius, ref duomenys, dienuSkaicius, perDiena, duom);

            spausdinimas(dienuPlius, duomenys);
        }

        private static void spausdinimas(int dienuPlius, Duomenys[] duomenys)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-5\ktu9-5\rezultatai.txt"))
            {
                foreach (Duomenys duome in duomenys)
                {
                    file.WriteLine(duome.angliavandeniai + "  " + duome.baltymai + "  " + duome.riebalai);
                }
                file.WriteLine(dienuPlius);
            }
        }

    }
}
