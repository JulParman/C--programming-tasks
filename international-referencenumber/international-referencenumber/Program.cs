using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace international_referencenumber
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "";
            String output = "";
            int action = 0;

            Console.WriteLine("Select option number: (1)Check international referencenumber or (2)Create international referencenumber");
            action = int.Parse(Console.ReadLine());
            if (action == 1)
            {
                Console.WriteLine("Referencenumber to check:");
                input = Console.ReadLine();
                CheckReferenceNumber checkReferenceNum = new CheckReferenceNumber();
                Console.WriteLine(checkReferenceNum.checkReference(input));
            }
            else if (action == 2)
            {
                CreateIRF createIRF = new CreateIRF();
                Console.WriteLine("Input referencenumber:");
                input = Console.ReadLine();
                output = createIRF.CreateReferenceNum(input);
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.ReadKey();
        }
    }
}
