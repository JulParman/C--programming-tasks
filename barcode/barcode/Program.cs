using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode
{
    class Program
    {
        static void Main(string[] args)
        {
            int version = 0;
            String iban = "";
            String payment = "";
            String indexNumber = "";
            String rfIndexNumber = "";
            String dueDate = "";

            Console.WriteLine("Give version number 4 or 5:");
            version = int.Parse(Console.ReadLine());
            if (version == 4)
            {
                Console.WriteLine("Give IBAN.");
                iban = Console.ReadLine();
                Console.WriteLine("Give payment");
                payment = Console.ReadLine();
                Console.WriteLine("Give indexnumber");
                indexNumber = Console.ReadLine();
                Console.WriteLine("Give duedate");
                dueDate = Console.ReadLine();
                Barcode barCode = new Barcode();
                Console.WriteLine(barCode.Version4(iban, payment, indexNumber, dueDate));
                Console.ReadKey();
            }
            else if (version == 5)
            {
                Console.WriteLine("Give IBAN.");
                iban = Console.ReadLine();
                Console.WriteLine("Give payment");
                payment = Console.ReadLine();
                Console.WriteLine("Give indexnumber");
                rfIndexNumber = Console.ReadLine();
                Console.WriteLine("Give duedate");
                dueDate = Console.ReadLine();
                Barcode barCode = new Barcode();
                Console.WriteLine(barCode.Version5(iban, payment, rfIndexNumber, dueDate));
                Console.ReadKey();
            }
        }
    }
}
