using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referencenumber_fi
{
    class CreateSingleNum
    {
        public String CheckInput(string inputNumber)
        {
            String referenceNoS = "";
            int[] numbers;
            int[] rewerseNo;
            int[] weights = new int[] { 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3 };
            int length = 0;
            int equal = 0;
            int roundNo = 0;
            int validationNo = 0;
            int nextTenth = 0;
            length = inputNumber.Length;
            if (length < 3 || length > 19)
            {
                Console.WriteLine("Input can be 3-19 mark long!");
            }
            else
            {
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
                    nextTenth = equal + (10 - roundNo);
                    validationNo = nextTenth - equal;
                }
                if (validationNo == 10)
                {
                    validationNo = 0;
                }
                else
                {
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
                }
            }
            return referenceNoS;
        }
    }
}
