using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iban_calculator
{
    class BBAN
    {
        //BBAN 6 numeroa, väliviiva ja 2-8 numeroa
        private int length = 0;

        //Check BBAN input length
        public Boolean CheckInput(String s)
        {
            if (s.Length >= 9 && s.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Add zeroes to BBAN
        public String Convert(String input)
        {
            String convertedNo = "";
            String convertingNo = "";
            int howManyZeroes = 0;
            convertingNo = input.Replace("-", "");
            String bank1 = convertingNo.Substring(0, 1);
            String bank2 = convertingNo.Substring(1, 1);
            String zeroes = "";
            if (int.Parse(bank1) == 4 || int.Parse(bank1) == 5 || int.Parse(bank2) == 4 && int.Parse(bank1) == 4 ||
                int.Parse(bank2) == 4 && int.Parse(bank1) == 5 || int.Parse(bank2) == 5 && int.Parse(bank1) == 4 ||
                int.Parse(bank2) == 5 && int.Parse(bank1) == 5)
            {
                length = convertingNo.Length;
                howManyZeroes = 14 - length;
                for (int i = 0; i < howManyZeroes; i++)
                {
                    zeroes += "0";
                }
                convertedNo = convertingNo.Insert(5, zeroes);
            }
            else
            {
                length = convertingNo.Length;
                howManyZeroes = 14 - length;
                for (int i = 0; i < howManyZeroes; i++)
                {
                    zeroes += "0";
                }
                convertedNo = convertingNo.Insert(6, zeroes);
            }

            return convertedNo;
        }
    }
}
