using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array practice!");

            /*
              Parašyti funkciją, kuri paprašo vartotoją įvesti 5 string tekstus, įrašo juos į masyvą, ir grazina.
                ... ir atspausdina įvestus žodžius paeiliui kaip vieną sakinį. (sujungta be tarpu.)
                ... ir atspausdina jį atvirkščiai. (sujungta be tarpu.)
             */

            // - Sukurkite static public funkcija : InputFiveToArray

            // - InputFiveToArray sukurkite lokaliu kintamaji string[].

            // - InputFiveToArray vartotojas iveda 5 string, juos idekite i masyva.

            // - InputFiveToArray atspausdina kintamuosius is eiles be tarpu.

            // - InputFiveToArray atspausdina kintamuosius atbulai be tarpu.

            /*
              Parašyti metodą, kuris gauna string tipo masyva:
                             { "Mano", "batai", "Mano", "buvo", "batai", "buvo", "du", "buvo", "du", "." };

                ...suraskite dubliuotus žodžius, pakeiskite dublikatus į "!" (Visi zodziai turi butu unikalus.)
                        ...Atspausdina likusius žodžius. (Itekite 1 space tarpa tarp zodziu.)

                Papildoma! : Perrūšiuoti žodžius, kad visi šauktukai būtų masyvo gale.
                        ...Atspausdina likusius žodžius. (Itekite 1 space tarpa tarp zodziu.)
            */

            // - Sukurkite static public funkcija : RemoveDuplicatesFromArray

            // - RemoveDuplicatesFromArray turi gauti nurodita string masyva kaip parametra.

            // - RemoveDuplicatesFromArray turi surasti dublikuotus zodzius, ir pakeisti dublikatus i "!"

            // - RemoveDuplicatesFromArray atspausdina masyvo elementus is eiles su vienu SPACE tarpu tarp elementu.

            // - RemoveDuplicatesFromArray nukelia visus "!" i gala masyvo (visa kita pastumti i prieki.).

            // - RemoveDuplicatesFromArray atspausdina masyvo elementus is eiles su vienu SPACE tarpu tarp elementu.

            /*
            Funkcijoje ArrayReferenceTest Sukurkite 5 int skaičių masyvą(nuo 1 iki 5).
            atspausdinkite jį su foreach(1 space tarp elementu.).
            perduokite jį funkcijai SpoilArray, kuri jį sugadina. (visus kintamuosius priskirkite - 1)
            Atspausdinkite masyvą su foreach antrą kartą ArrayReferenceTest funkcijoje.

            Papildoma!: Visiškai nekeisdami funkcijos, kuri sugadina masyvą, užtikrinkite, kad jūsų masyvas nebus sugadintas tos funkcijos.
            */

            // - Sukurkite static public funkcija : ArrayReferenceTest

            // - ArrayReferenceTest turi turet int[] lokalu kintakaji. su duomenimis : 1,2,3,4,5

            // - ArrayReferenceTest atspausdina duomenis. (1 space tarp skaiciu.)

            // - Sukurkite static public funkcija : SpoilArray

            // - SpoilArray turi gauti int[] kaip parametra.

            // - SpoilArray visus masyvo elementus peraso i -1.

            // - ArrayReferenceTest atspausdina duomenis antra karta. (1 space tarp skaiciu.)

            // - Nekaisdami SpoilArray, uztikrinkite kad jusu masyvas nebutu sugadintas. (nebutu pakeistas i -1)


            /*

            Sukurkite metodą ParamsTesting, kuris ima, int, float[], ir params string[] kaip parametrų sąrašą.
            Atspausdinkite visus parametrus į ekraną.
            (Kiekviena parametra atspausdinti i nauja eilute.)
            (Masyvus atspausdinti atskiriant elementus 1 space)

            */

            // - Sukurkite static public funkcija : ParamsTesting

            // - ParamsTesting turi gauti int, float[], ir params string[] kaip parametrus.

            // - Atspausdinkite visus kintamuosius.


            //InputFiveToArray();

            //RemoveDuplicatesFromArray(new string[] { "Mano", "batai", "Mano", "buvo", "batai", "buvo", "du", "buvo", "du", "." });

            //ArrayReferenceTest();

            ParamsTesting(12345678, new float[] { 1.2f, 3.4f, 5.6f }, "Labas", "rytas", "-", "mano", "saule!");

            Console.ReadKey();
        }

        public static string[] InputFiveToArray()
        {
            string[] input = new string[5];

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"Iveskite teksta {i + 1}'taji teksta:");
                input[i] = Console.ReadLine();
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
            }

            Console.WriteLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
            return input;
        }

        public static void RemoveDuplicatesFromArray(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] == data[j])
                    {
                        data[j] = "!";
                    }
                }
            }

            foreach (string item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int endPosition = 0;
            for (int i = 0; i < data.Length - endPosition; i++)
            {
                if (data[i] == "!")
                {
                    for (int j = i; j < data.Length - 1; j++)
                    {
                        data[j] = data[j + 1];
                    }
                    data[data.Length - 1] = "!";

                    endPosition++;
                    i--;
                }

            }

            foreach (string item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }

        public static void ArrayReferenceTest()
        {
            int[] data = { 1, 2, 3, 4, 5 };

            foreach (int number in data)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            SpoilArray((int[])data.Clone());

            foreach (int number in data)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

        }

        public static void SpoilArray(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = -1;
            }
        }


        public static void ParamsTesting(int number, float[] floatArr, params string[] parameters)
        {
            Console.WriteLine(number);

            foreach (float flt in floatArr)
            {
                Console.Write(flt + " ");
            }
            Console.WriteLine();

            foreach (string param in parameters)
            {
                Console.Write(param + " ");
            }
            Console.WriteLine();

        }
    }
}
