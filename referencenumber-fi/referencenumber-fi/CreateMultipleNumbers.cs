using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referencenumber_fi
{
    class CreateMultipleNumbers
    {
        private String referenceNoS = "";
        private int length = 0;

        public void CreateNumbers(string inputNumber, int numberAmount)
        {
            String referenceNoStemp = "";
            String referenceToPrint = "";
            int amount = 0;
            length = inputNumber.Length;
            amount = numberAmount + 1;
            if (length < 3 || length > 19)
            {
                Console.WriteLine("Input can be 3-19 mark long!");
            }
            else
            {
                for (int i = 1; i < amount; i++)
                {
                    referenceNoS = "";
                    referenceNoStemp = inputNumber;
                    referenceNoStemp += i.ToString();
                    referenceToPrint = Validation(referenceNoStemp);
                    if (i == 1)
                    {
                        Console.WriteLine("Counted referencenumbers:");
                        Console.WriteLine(i + ". " + referenceToPrint);
                    }
                    else
                    {
                        Console.WriteLine(i + ". " + referenceToPrint);
                    }
                }
            }
        }

        public String Validation(String inputNumber)
        {
            int[] numbers;
            int[] rewerseNo;
            int[] weights = new int[] { 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3 };
            int equal = 0;
            int roundNo = 0;
            int validationNo = 0;
            int nextTenth = 0;
            length = inputNumber.Length;
            equal = 0;
            numbers = new int[length];
            var intList = inputNumber.Select(digit => int.Parse(digit.ToString()));
            numbers = intList.ToArray();
            rewerseNo = new int[length];
            Array.Copy(numbers, rewerseNo, length);
            Array.Reverse(rewerseNo);
            for (int i = 0; i < length; i++)
            {
                equal += rewerseNo[i] * weights[i];
            }
            roundNo = (equal) % 10;
            if (roundNo == 0)
            {
                nextTenth = equal + 10;
                validationNo = nextTenth - equal;
            }
            else
            {
                nextTenth = (10 - roundNo) + equal;
                validationNo = nextTenth - equal;
            }
            if (validationNo == 10)
            {
                validationNo = 0;
            }

            for (int i = 0; i < length; i++)
            {

                if (i != 5 && i != 10 && i != 15)
                {
                    referenceNoS += numbers[i].ToString();
                }
                else
                {
                    referenceNoS += " " + numbers[i].ToString();
                }

            }
            referenceNoS += validationNo.ToString();

            return referenceNoS;
        }
    }
}
