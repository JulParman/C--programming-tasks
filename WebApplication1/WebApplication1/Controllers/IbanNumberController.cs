using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class IbanNumberController : Controller
    {
        // GET: /IbanNumber/
        public IActionResult Index(string s)
        {
            var iban = new WebApplication1.Models.Iban(); 
            string validationN = "";
            double divider = 97;
            double reminder = 0;
            double number = double.Parse(s);
            reminder = (number) % divider;
            validationN = (98 - reminder).ToString();
            if (int.Parse(validationN) < 10)
            {
                validationN = validationN.Insert(0, "0");
            }
            
            return View();
        }

        



    }
}
