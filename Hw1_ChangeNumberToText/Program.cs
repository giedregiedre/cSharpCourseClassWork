using System;

class Program
{

    static void Main()
    {
        // min skaicius 
        const int FROM_NUMBER = -1000000000;

        // max skaicius 
        const int TO_NUMBER = 1000000000;

        string inputString = "";
        int inputNumber = 0;

        Console.Write("Sveiki!");
        while (inputString != " ")
        {
            Console.Write("\n(Enter SPACE to exit.)\nIveskite skaiciu:");
            inputString = Console.ReadLine();
            if (CheckIfGoodNumber(inputString))
            {
                Console.WriteLine("Skaicius teisingas!");
                inputNumber = Convert.ToInt32(inputString);
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
    static string ChangeNumberToText(int number)
    {
        string output = "";
        if (number < 0)
        {
            output = "minus ";
            number *= -1;
        }
        if (number < 1000000000)
        {
            ChangeMillionsToText(number, ref output);
        }
        else
        {
            output += "KLAIDA! neapdorotas skaicius: " + number;
        }
        return output;
    }

    // prideda milijonus
    static void ChangeMillionsToText(int number, ref string output)
    {
        if (number < 1000000)
        {
            ChangeThousandsToText(number, ref output);
        }
        else
        {
            int milijonai = number / 1000000;
            int tuksanciai = number % 1000000;

            if (milijonai > 0)
            {
                if (milijonai == 1)
                {
                    output += "milijonas";
                }
                else
                {
                    ChangeHundredsToText(milijonai, ref output);
                    if (milijonai % 10 == 0)
                    {
                        output += " milijonu";
                    }
                    else if (milijonai % 10 == 1)
                    {
                        output += " milijonas";
                    }
                    else
                    {
                        output += " milijonai";
                    }
                }
            }
            // pridet tukstancius
            if (tuksanciai != 0)
            {
                output += " ";
                ChangeThousandsToText(tuksanciai, ref output);
            }
        }
    }

    // prideda tukstancius.
    static void ChangeThousandsToText(int number, ref string output)
    {
        if (number < 1000)
        {
            ChangeHundredsToText(number, ref output);
        }
        else
        {
            int tukstanciai = number / 1000;
            int simtai = number % 1000;

            if (tukstanciai > 0)
            {
                if (tukstanciai == 1)
                {
                    output += "tukstantis";
                }
                else
                {
                    ChangeHundredsToText(tukstanciai, ref output);
                    if (tukstanciai % 10 == 0)
                    {
                        output += " tukstanciu";
                    }
                    else if (tukstanciai % 10 == 1)
                    {
                        output += " tukstantis";
                    }
                    else
                    {
                        output += " tukstanciai";
                    }
                }
            }
            // pridet simtus
            if (simtai != 0)
            {
                output += " ";
                ChangeHundredsToText(simtai, ref output);
            }
        }
    }

    // prideda simtus
    static void ChangeHundredsToText(int number, ref string output)
    {
        if (number < 100)
        {
            ChangeTensToText(number, ref output);
        }
        else
        {
            int simtai = number / 100;
            int vienetai = number % 100;

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
    static void ChangeTensToText(int number, ref string output)
    {
        if (number < 20)
        {
            ChangeTeensToText(number, ref output);
        }
        else
        {
            int desimtys = number / 10;
            int vienetai = number % 10;

            // pridet desimtys
            switch (desimtys)
            {
                case 0: output += ""; break;
                case 1: output += "desimt"; break;
                case 2: output += "dvidesimt"; break;
                case 3: output += "trisdesimt"; break;
                case 4: output += "keturiasdesimt"; break;
                case 5: output += "penkiasdesimt"; break;
                case 6: output += "sesiasdesimt"; break;
                case 7: output += "septyniasdesimt"; break;
                case 8: output += "astuoniasdesimt"; break;
                case 9: output += "devyniasdesimt"; break;
                default: output += "KLAIDA! neapdorotas skaicus:" + number; break;
            }

            // pridet vienetus
            if (vienetai != 0)
            {
                output += " ";
                ChangeOnesToText(vienetai, ref output);
            }
        }
    }

    // prideda niolikas.
    static void ChangeTeensToText(int number, ref string output)
    {
        if (number < 10)
        {
            ChangeOnesToText(number, ref output);
        }
        else
        {
            switch (number)
            {
                case 10: output += "desimt"; break;
                case 11: output += "vienualika"; break;
                case 12: output += "dvylika"; break;
                case 13: output += "trylika"; break;
                case 14: output += "keturiolika"; break;
                case 15: output += "penkiolika"; break;
                case 16: output += "sesiolika"; break;
                case 17: output += "septyniolika"; break;
                case 18: output += "astuoniolika"; break;
                case 19: output += "devyniolika"; break;
                default: output += "KLAIDA! neapdorotas skaicus:" + number; break;
            }
        }
    }

    // prideda vienetus.
    static void ChangeOnesToText(int number, ref string output)
    {
        switch (number)
        {
            case 0: output += "nulis"; break;
            case 1: output += "vienas"; break;
            case 2: output += "du"; break;
            case 3: output += "trys"; break;
            case 4: output += "keturi"; break;
            case 5: output += "penki"; break;
            case 6: output += "sesi"; break;
            case 7: output += "septyni"; break;
            case 8: output += "astuoni"; break;
            case 9: output += "devyni"; break;
            default: output += "KLAIDA! neapdorotas skaicus:" + number; break;
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
                if (ch == '-' && i != 0)
                {
                    {
                        // ne skaicius, minusas... bet ne pirmoi pozicijoi.
                        return false;
                    }
                }
                else
                {
                    // ne skaiciuss ir ne minusas. 
                    return false;
                }
            }
        }
        // neradome jokiu klaidu - geras skaicius.
        return true;
    }

    // funkcija gauna true jei skaicius checkNumber yar tarp fromNumber ir toNumber (imtinai)
    private static bool CheckIfNumberInRange(int fromNumber, int toNumber, int checkNumber)
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