using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPractice
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Basic practice!");

            // - Sukurkite static funkcija : PracticeVariables

            // - Funkcijoje PracticeVariables sukurkite lokalius int, float, string, bool kintamuosius funkcijos viduje (ne funkcijos parametrus.). Juos atspausdinkite i ekrana.

            // - Sukurkite static funkcija : CheckMarkAvarage

            // - CheckMarkAvarage funkcija gauna 3 float skaicius kaip parametrus.

            // - CheckMarkAvarage funkcija turi grazinti string.

            // - CheckMarkAvarage funkcija grazina "blogai", jei bent vienas is skaiciu < 3.5.

            // - CheckMarkAvarage funkcija grazina "Labai puiku!", jei visi skaiciai > 8.

            // - CheckMarkAvarage likusiais atvejais grazina: "Vidurkis:X", kur X yra 3 skaiciu vidurkis.

            // - Sukurkite static funkcija : SumNumbersInRange

            // - SumNumbersInRange funkcija gauna 2 int argumentus kaip parametrus: 'from', 'to'.

            // - SumNumbersInRange funkcija turi grazinti int skaiciu.

            // - SumNumbersInRange funkcija paskaiciuoja ir grazina visu skaiciu suma imtinai nuo 'from' iki 'to'.

            // - SumNumbersInRange funkcija grazina -123 jeigu 'from' skaicius didesnis uz 'to'.

            PracticeVariables();

            Console.WriteLine(CheckMarkAvarage(1.2f, 3.4f, 5.6f));
            Console.WriteLine(CheckMarkAvarage(9f, 9f, 9f));
            Console.WriteLine(CheckMarkAvarage(4f, 5f, 6f));

            Console.WriteLine(SumNumbersInRange(-10, 10));
            Console.WriteLine(SumNumbersInRange(10, -10));


            Console.ReadKey();
        }



        static void PracticeVariables()
        {
            int intNumber = 123;
            float realNumber = 12.34f;
            string text = "test";
            bool isItTrue = true;

            Console.WriteLine($"Var test: int:{intNumber} float:{realNumber} string:{text} bool:{isItTrue}");
        }

        static string CheckMarkAvarage(float mark1, float mark2, float mark3)
        {
            if (mark1 < 3.5 || mark2 < 3.5 || mark3 < 3.5)
            {
                return "blogai";
            }

            if (mark1 > 8 && mark2 > 8 && mark3 > 8)
            {
                return "Labai puiku!";
            }

            return "Vidurkis:" + (mark1 + mark2 + mark3) / 3;
        }

        static int SumNumbersInRange(int from, int to)
        {
            if (from > to)
            {
                return -123;
            }

            int sum = 0;

            for (int i = from; i <= to; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
