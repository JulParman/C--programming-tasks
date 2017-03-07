using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode
{
    class Barcode
    {
        private String barCode = "";
        private String startC = "105";
        private String version = "";
        private String ibanNumber = "";
        private String euros = "";
        private String sents = "";
        private String threeZeroes = "000";
        private String indexNumber = "";
        private String rfIndexNumber = "";
        private String dueDate = "";
        private String endMark = "[stop]";
        private String paymentFullNumber = "";
        private String barCodeTemp = "";
        private String vv = "";
        private String kk = "";
        private String pp = "";

        public String CountPaymentZeroes(String p)
        {
            int piste = 0;
            bool containsDot = p.Contains(".");
            bool containsComma = p.Contains(",");
            if (containsDot == true)
            {
                piste = p.IndexOf(".");
            }
            else if (containsComma == true)
            {
                piste = p.IndexOf(",");
            }
            else if (containsDot == false && containsComma == false)
            {
                euros = p.Substring(0, p.Length);
                sents = "00";
            }
            euros = p.Substring(0, piste);
            sents = p.Substring(piste + 1, 2);
            String paymentLength = euros + sents;
            String paymentZeroes = "";
            for (int i = 0; i < ((8 - paymentLength.Length)); i++)
            {
                paymentZeroes += "0";
            }
            return paymentLength = paymentZeroes + paymentLength;
        }

        public String IndexNumberZeroesAdded(String indexN, String version)
        {
            int v = int.Parse(version);
            if (v == 4)
            {
                int howManyZeroesToIndex = 20 - indexN.Length;
                String indexZeroes = "";
                for (int i = 0; i < howManyZeroesToIndex; i++)
                {
                    indexZeroes += "0";
                }
                indexN = indexZeroes + indexN;
            }
            else if (v == 5)
            {
                int howManyZeroesToIndex = 23 - indexN.Length;
                String indexZeroes = "";
                for (int i = 0; i < howManyZeroesToIndex; i++)
                {
                    indexZeroes += "0";
                }
                indexN = indexN.Insert(2, indexZeroes);

            }
            return indexN;
        }

        public Double CountValidation(String barCode)
        {
            String barCodeT = barCode;
            int twoDigit = 0;
            double sum = 0;
            double validation = 0;
            int x = 0;
            for (int i = 0; i < 27; i++)
            {
                if (i == 0)
                {
                    twoDigit = 0;
                    twoDigit += int.Parse(startC) * 1;
                    twoDigit += int.Parse(barCodeT.Substring(0, 2)) * 1;
                }
                else
                {
                    x = 0;
                    x = (i * 2);
                    twoDigit = 0;
                    twoDigit += int.Parse(barCodeT.Substring(x, 2)) * (i + 1);
                }
                sum += twoDigit;
            }
            validation = (sum) % 103;
            return validation;
        }

        public String PrintBarCode(String barCodeT, String v)
        {
            int x = 0;
            String barCodeToPrint = "";
            for (int i = 0; i < 27; i++)
            {
                if (i == 0)
                {
                    barCodeToPrint += "[" + startC + "]" + " " + barCodeT.Substring(0, 2);
                }
                else if (i == 26)
                {
                    x = 0;
                    x = (i * 2);
                    barCodeToPrint += " " + barCodeT.Substring(x, 2) + " [" + v + "] " + endMark;
                }
                else
                {
                    x = 0;
                    x = (i * 2);
                    barCodeToPrint += " " + barCodeT.Substring(x, 2);
                }
            }
            return barCodeToPrint;
        }

        public String Version4(String iban, String payment, String indexN, String duedate)
        {
            ibanNumber = iban;
            ibanNumber = ibanNumber.Replace("FI", "");
            for (int i = 0; i < ibanNumber.Length; i++)
            {
                ibanNumber = ibanNumber.Replace(" ", "");
            }
            for (int i = 0; i < indexN.Length; i++)
            {
                indexN = indexN.Replace(" ", "");
            }

            version = "4";
            paymentFullNumber = CountPaymentZeroes(payment);
            if (duedate.Length == 0)
            {
                //dueDate += "00.00.0000";
                vv = "00";
                kk = "00";
                pp = "00";
            }
            else
            {
                dueDate = duedate;
                for (int i = 0; i < dueDate.Length; i++)
                {
                    dueDate = dueDate.Replace(".", "");
                }
                vv = dueDate.Substring(6, 2);
                kk = dueDate.Substring(2, 2);
                pp = dueDate.Substring(0, 2);
            }

            indexNumber = IndexNumberZeroesAdded(indexN, version);

            barCode = version + ibanNumber + paymentFullNumber + threeZeroes + indexNumber + vv + kk + pp;
            String validation = CountValidation(barCode).ToString();
            barCodeTemp = barCode;
            barCode = "";
            //[105] 47 94 40 52 02 00 36 08 20 04 88 31 50 00 00 00 08 68 51 62 59 61 98 97 10 06 12 [40] [stop]                     
            barCode = PrintBarCode(barCodeTemp, validation);

            return barCode;
        }

        public String Version5(String iban, String payment, String rfIndexNum, String duedate)
        {
            ibanNumber = iban;
            ibanNumber = ibanNumber.Replace("FI", "");
            rfIndexNum = rfIndexNum.Replace("RF", "");
            for (int i = 0; i < ibanNumber.Length; i++)
            {
                ibanNumber = ibanNumber.Replace(" ", "");
            }
            for (int i = 0; i < rfIndexNum.Length; i++)
            {
                rfIndexNum = rfIndexNum.Replace(" ", "");
            }
            version = "5";
            paymentFullNumber = CountPaymentZeroes(payment);
            if (duedate.Length == 0)
            {
                //dueDate = "00.00.0000";
                vv = "00";
                kk = "00";
                pp = "00";
            }
            else
            {
                dueDate = duedate;
                for (int i = 0; i < dueDate.Length; i++)
                {
                    dueDate = dueDate.Replace(".", "");
                }
                vv = dueDate.Substring(6, 2);
                kk = dueDate.Substring(2, 2);
                pp = dueDate.Substring(0, 2);
            }

            rfIndexNumber = IndexNumberZeroesAdded(rfIndexNum, version);
            barCode = version + ibanNumber + paymentFullNumber + rfIndexNumber + vv + kk + pp;
            String validation = CountValidation(barCode).ToString();
            barCodeTemp = barCode;
            barCode = "";
            barCode = PrintBarCode(barCodeTemp, validation);

            return barCode;
        }
    }
}
