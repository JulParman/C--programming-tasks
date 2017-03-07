using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace international_referencenumber
{
    class CheckReferenceNumber
    {
        public String checkReference(String s)
        {
            String referenceToCheck = "";
            String firstLetter = "";
            String secondLetter = "";
            String endPart = "";
            String leftOverNum = "";
            long longformat = 0;
            int firstNumber = 0;
            int secondNumber = 0;
            long remainder = 0;
            String firstPart = "";
            int length = 0;
            String[] letters = new String[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] numbers = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
            length = s.Length;
            s = s.ToUpper();
            referenceToCheck = s;
            if (length < 7 || length > 24)
            {
                Console.WriteLine("Referencenumber length incorrect");
            }
            else
            {
                firstLetter = referenceToCheck.Substring(0, 1);
                secondLetter = referenceToCheck.Substring(1, 1);
                endPart = referenceToCheck.Substring(2, 2);
                leftOverNum = referenceToCheck.Substring(4, (length - 4));
                for (int i = 0; i < letters.Length; i++)
                {
                    if (firstLetter.Contains(letters[i]))
                    {
                        firstNumber = numbers[i];
                    }
                    else if (secondLetter.Contains(letters[i]))
                    {
                        secondNumber = numbers[i];
                    }
                }
                referenceToCheck = "";
                firstPart += firstNumber.ToString() + secondNumber.ToString() + endPart;
                referenceToCheck += leftOverNum + firstPart;
                longformat = long.Parse(referenceToCheck);
                remainder = (longformat) % 97;
                if (remainder == 1)
                {
                    referenceToCheck = s + " - OK";
                }
                else
                {
                    referenceToCheck = "Incorrect referencenumber";
                }
            }

            return referenceToCheck;
        }
    }
}
