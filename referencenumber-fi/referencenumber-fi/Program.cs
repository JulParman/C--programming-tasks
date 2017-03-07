using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referencenumber_fi
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputNoToCheck = "";
            String checkedNo = "";
            int action = 0;
            int numbers = 0;

            Console.WriteLine("Press number for action (1)Check referencenumber, (2)Create referencenumber and (3)Create x number of referencenumbers:");
            action = int.Parse(Console.ReadLine());
            if (action == 1 || action == 2 || action == 3)
            {
                if (action == 1)
                {
                    Console.WriteLine("Give referencenumber:");
                    inputNoToCheck = Console.ReadLine();
                    CheckNumber checkNo = new CheckNumber();
                    checkedNo = checkNo.CheckInput(inputNoToCheck);
                    Console.WriteLine(checkedNo + " - OK");
                    Console.ReadKey();
                }
                else if (action == 2)
                {
                    Console.WriteLine("Give number to create referencenumber:");
                    inputNoToCheck = Console.ReadLine();
                    CreateSingleNum createSingleNum = new CreateSingleNum();
                    checkedNo = createSingleNum.CheckInput(inputNoToCheck);
                    Console.WriteLine(checkedNo);
                    Console.ReadKey();
                }
                else if (action == 3)
                {
                    Console.WriteLine("Give referencenumber basepart:");
                    inputNoToCheck = Console.ReadLine();
                    Console.WriteLine("Amount of referencenumbers:");
                    numbers = int.Parse(Console.ReadLine());
                    CreateMultipleNumbers createMultipleNum = new CreateMultipleNumbers();
                    createMultipleNum.CreateNumbers(inputNoToCheck, numbers);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
                Console.WriteLine("Press number for action (1)Check referencenumber, (2)Create referencenumber and (3)Create x number of referencenumbers");
                action = int.Parse(Console.ReadLine());
                Console.ReadKey();
            }
        }
    }
}
