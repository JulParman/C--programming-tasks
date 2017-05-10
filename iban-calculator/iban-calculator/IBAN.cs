using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iban_calculator
{
    class IBAN
    {
        //IBAN 2-Letters countrycode, 2-number validation ja 14-marks basic part
        //A = 10 G = 16 M = 22 S = 28 Y = 34
        //B = 11 H = 17 N = 23 T = 29 Z = 35
        //C = 12 I = 18 O = 24 U = 30
        //D = 13 J = 19 P = 25 V = 31
        //E = 14 K = 20 Q = 26 W = 32
        //F = 15 L = 21 R = 27 X = 33
        private String[] letters = new String[] {"A","B","C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"
        ,"Q","R","S","T","U","V","W","X","Y","Z"};
        private int[] numbers = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };
        private List<String> ibanList;
        private int size = 0;

        //Country code
        public String CountryCode(String s)
        {
            return s.Insert(s.Length, "FI00");
        }

        //Letters to numbers
        public String Letters(String s)
        {            
            for (int i = 0; i < letters.Length; i++)
            {
                if (s.Contains(letters[i]))
                {
                     s = s.Replace(letters[i], numbers[i].ToString());                    
                }
            }
            return s;
        }

        //Calculate validation code
        public String Validation(String s)
        {
            String validationN = "";
            ulong divider = 97;
            ulong reminder = 0;
            ulong number = ulong.Parse(s);
            reminder = (number) % divider;
            validationN = (98 - reminder).ToString();
            if (int.Parse(validationN) < 10)
            {
                validationN = validationN.Insert(0, "0");
            }
            return validationN;
        }

        //Counting IBAN
        public String IbanNumber(String s, String v)
        {
            String ibanN;
            ibanN = "FI" + v + s;
            ibanList = new List<String>();
            ibanList = ibanN.Select(digit => digit.ToString()).ToList();
            ibanN = "";
            for (int i = 0; i < ibanList.Count; i++)
            {
                if (i != 4 && i != 8 && i != 12 && i != 16 && i != 20 && i != 24)
                {
                    ibanN += ibanList[i];
                }
                else
                {
                    ibanN += " " + ibanList[i];
                }
            }
            return ibanN;
        }

        //Check if Iban is correct or not
        public string CheckIbanValidation(string ibanNumber)
        {
            ulong divider = 97;
            ulong reminder = 0;
            for(int i = 0;i<ibanNumber.Length;i++)
            {
                ibanNumber = ibanNumber.Replace(" ","");
            }
            string fourCharsToEnd = ibanNumber.Substring(0, 4);
            ibanNumber = ibanNumber.Remove(0, 4);
            ibanNumber = ibanNumber.Insert(ibanNumber.Count(), fourCharsToEnd);
            int index = ibanNumber.IndexOf("F");
            string letterConverted = Letters(ibanNumber.Substring(index, 2));
            ibanNumber = ibanNumber.Replace("FI", letterConverted);
            ulong number = ulong.Parse(ibanNumber);
            reminder = (number) % divider;

            if (reminder == 1)
            {
                return "Iban is correct!";
            }
            else
            {
                return "Iban is incorrect!";
            }
        }
    }
}
