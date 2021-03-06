﻿using System;
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

            Console.ReadKey();
        }
    }
}
