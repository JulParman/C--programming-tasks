using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iban_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input BBAN number:");
            string bbanInput = Console.ReadLine();
            BBAN bbanObject = new BBAN();
            String convertedBban = "";
            String countryAdded = "";
            String lettersToNum = "";
            String validNum = "";
            String fullIban = "";

            if (bbanObject.CheckInput(bbanInput) == true)
            {
                convertedBban = bbanObject.Convert(bbanInput);
                Console.WriteLine(convertedBban);
            }
            else
            {
                Console.WriteLine("Wrong BBAN!");
            }
            IBAN iban = new IBAN();
            countryAdded = iban.CountryCode(convertedBban);
            Console.WriteLine(countryAdded);
            lettersToNum = iban.Letters(countryAdded);
            Console.WriteLine(lettersToNum);
            validNum = iban.Validation(lettersToNum);
            Console.WriteLine("Tarkiste: " + validNum);
            fullIban = iban.IbanNumber(convertedBban, validNum);
            Console.WriteLine("IBAN: " + fullIban);
            Console.ReadKey();
        }
    }
}
