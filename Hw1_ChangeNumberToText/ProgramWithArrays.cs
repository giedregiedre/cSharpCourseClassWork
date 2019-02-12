using System;
using System.Security.Cryptography;
using System.Threading;

class ProgramWithArrays
{

    static void Main()
    {
        // min skaicius 
        const long FROM_NUMBER = -1000000000000000000;

        // max skaicius 
        const long TO_NUMBER = 1000000000000000000;

        string inputString = "";
        long inputNumber = 0;

        Console.Write("Sveiki!");
        while (inputString != " ")
        {
            Console.Write("\n(Enter SPACE to exit.)\nIveskite skaiciu:");

            Console.WriteLine();

            inputString = Console.ReadLine();

            Console.ReadKey();

            if (CheckIfGoodNumber(inputString))
            {
                Console.WriteLine("Skaicius teisingas!");
                inputNumber = Convert.ToInt64(inputString);
                if (CheckIfNumberInRange(FROM_NUMBER, TO_NUMBER, inputNumber))
                {
                    Console.WriteLine($"Skaicius {inputNumber} zodziais:\n {ChangeNumberToText(inputNumber)}");
                }
                else
                {
                    Console.WriteLine($"Blogas skaicius {inputString}, prasau ivesti skaiciu reziuose: {FROM_NUMBER}..{TO_NUMBER}");
                }
            }
            else
            {
                Console.WriteLine($"Ivesti duomenys:{inputString} nera skaicius!");
            }
        }

        Console.WriteLine("\nAciu uz demesi, viso gero.");
        Console.ReadKey();
    }

    // bendra funkcija apjungti visom funkcijom kurias jus sukursit.
    static string ChangeNumberToText(long number)
    {
        string output = "";
        if (number < 0)
        {
            output = "minus ";
            number *= -1;
        }

        if (number == 0)
        {
            return "nulis";
        }

        string[] singular = { "tukstantis", "milijonas", "milijardas", "trilijonas", "kvadrilijonas" };
        string[] plural1 = { "tukstanciai", "milijonai", "milijardai", "trilijonai", "kvadrilijonai" };
        string[] plural2 = { "tukstanciu", "milijonu", "milijardu", "trilijonu", "kvadrilijonu" };

        long divider = 1000;
        int tripletIndex = 0;
        for (int i = 0; i < singular.Length; i++)
        {
            divider *= 1000;
            tripletIndex++;
        }

        if (number < divider)
        {
            do
            {
                divider /= 1000;
                tripletIndex--;

                long numberStart = number / divider;
                long numberEnd = number % divider;

                if (numberStart > 0)
                {
                    if (numberStart == 1)
                    {
                        output += " " + singular[tripletIndex];
                    }
                    else
                    {
                        ChangeHundredsToText(numberStart, ref output);
                        if (numberStart % 10 == 0)
                        {
                            output += " " + plural2[tripletIndex];
                        }
                        else if (numberStart % 10 == 1)
                        {
                            output += " " + singular[tripletIndex];
                        }
                        else
                        {
                            output += " " + plural1[tripletIndex];
                        }
                    }
                    output += " ";
                }
                number = numberEnd;

            } while (divider > 1000);

            if (number > 0)
            {
                ChangeHundredsToText(number, ref output);
            }
        }
        else
        {
            output += "KLAIDA! neapdorotas skaicius: " + number;
        }

        return output;
    }

    // prideda simtus
    static void ChangeHundredsToText(long number, ref string output)
    {
        if (number < 100)
        {
            ChangeTensToText(number, ref output);
        }
        else
        {
            long simtai = number / 100;
            long vienetai = number % 100;

            if (simtai > 0)
            {
                if (simtai == 1)
                {
                    output += "simtas";
                }
                else
                {
                    ChangeTensToText(simtai, ref output);
                    output += " simtai";
                }
            }
            // pridet desimtis
            if (vienetai != 0)
            {
                output += " ";
                ChangeTensToText(vienetai, ref output);
            }
        }
    }

    // prideda dasimtis
    static void ChangeTensToText(long number, ref string output)
    {
        if (number < 20)
        {
            ChangeTeensToText(number, ref output);
        }
        else
        {
            long desimtys = number / 10;
            long vienetai = number % 10;

            // pridet desimtys

            string[] tensNumbers = { "", "desimt", "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt" };

            if (desimtys > 9)
            {
                output += "KLAIDA! neapdorotas skaicus:" + number;
            }
            else
            {
                output += tensNumbers[desimtys];
            }

            // pridet vienetus
            if (vienetai != 0)
            {
                output += " ";
                ChangeTeensToText(vienetai, ref output);
            }
        }
    }



    // prideda niolikas.
    static void ChangeTeensToText(long number, ref string output)
    {
        string[] firstNumbers = { "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni", "desimt", "vienualika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika" };

        if (number > 19)
        {
            output += "KLAIDA! ChangeTeensToText neapdorotas skaicus:" + number;
        }
        else
        {
            output += firstNumbers[number];
        }
    }

    // funkcija gauna string skaiciu, patikrina ar skaicius teisingu formatu. Pvz: "123", "-123" grazina true. "12a3", "1-23" grazina false.
    static bool CheckIfGoodNumber(string dataToCheck)
    {
        // tikrinam ar ne tuscias tekstas.
        if (dataToCheck == "")
        {
            return false;
        }

        for (int i = 0; i < dataToCheck.Length; i++)
        {
            char ch = dataToCheck[i];

            // tikrinam ar simbolis yra skaicius.
            if (ch != '0' && ch != '1' && ch != '2' && ch != '3' && ch != '4' && ch != '5' && ch != '6' && ch != '7' && ch != '8' && ch != '9')
            {
                // praleidziam isimti su minusu priekyje.
                if (ch != '-' || i != 0)
                {
                    return false;
                }

            }
        }
        // neradome jokiu klaidu - geras skaicius.
        return true;
    }

    // funkcija gauna true jei skaicius checkNumber yar tarp fromNumber ir toNumber (imtinai)
    private static bool CheckIfNumberInRange(long fromNumber, long toNumber, long checkNumber)
    {
        return checkNumber > fromNumber && checkNumber < toNumber;
    }

    //Skaiciai zodziais:  
    // "minus"; 
    // "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni"; 
    // "desimt", "vienualika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika"; 
    // "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt"; 
    // "simtas", "tukstantis", "milijonas", "milijardas"; 
    // "simtai", "tukstanciai", "milijonai", "milijardai"; 
    // "simtu", "tukstanciu", "milijonu", "milijardu"; 
}