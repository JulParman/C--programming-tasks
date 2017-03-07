using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace international_referencenumber
{
    class CreateIRF
    {
        public String CreateReferenceNum(String s)
        {
            String irf = "";
            String firf = "";
            String tempS = "";
            long tempL = 0;
            long reminder = 0;
            long validation = 0;
            String validationS = "";
            String rf = "2715";
            String zeroes = "00";
            int length = 0;
            List<String> list;
            length = s.Length;
            if (length < 4 || length > 20)
            {
                Console.WriteLine("Check referencenumber length (4-20)!");
            }
            else
            {
                firf = s;
                tempS = firf + rf + zeroes;
                tempL = long.Parse(tempS);
                reminder = (tempL) % 97;
                validation = 98 - reminder;
                if (validation < 10)
                {
                    validationS = "0" + validation;
                    irf = "RF" + validationS + firf;
                }
                else
                {
                    irf = "RF" + validation.ToString() + firf;
                }
                list = new List<string>();
                list = irf.Select(digit => digit.ToString()).ToList();
                irf = "";
                for (int i = 0; i < list.Count; i++)
                {
                    if (i != 4 && i != 8 && i != 12 && i != 16 && i != 20)
                    {
                        irf += list[i].ToString();
                    }
                    else
                    {
                        irf += " " + list[i].ToString();
                    }
                }
            }

            return irf;
        }
    }
}
