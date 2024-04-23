using Lottery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lottery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult GerarNumeros()
        {
            int[] vetor = new int[6];
            Random random = new Random();
            int aleatorio;

            for (int c = 0; c < 6; c++)
            {
                do
                {
                    aleatorio = random.Next(1, 61);
                } while (vetor.Contains(aleatorio));

                vetor[c] = aleatorio;
            }

            Array.Sort(vetor);

            // Passa os números para a View através da ViewBag
            ViewBag.Numeros = vetor;

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
