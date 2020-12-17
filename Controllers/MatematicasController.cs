using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoMatematicas.Controllers
{
    public class MatematicasController : Controller
    {
        //GET SumarNumeros
        public IActionResult SumarNumeros()
        {
            return View();
        }
        //POST SumarNumeros
        [HttpPost]
        public IActionResult SumarNumeros(int num1, int num2)
        {
            ViewBag.Suma = num1 + num2;
            return View();
        }
        //GET TablaMultiplicar
        public IActionResult TablaMultiplicar()
        {
            return View();
        }
        //POST TablaMultiplicar
        [HttpPost]
        public IActionResult TablaMultiplicar(int numero)
        {
            List<int> resultadosTabla = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                resultadosTabla.Add(numero * i);
            }
            ViewBag.Numero = numero;
            return View(resultadosTabla);

        }
        //GET Collatz
        public IActionResult Collatz()
        {
            return View();
        }
        //POST Collatz
        [HttpPost]
        public IActionResult Collatz(int numero)
        {
            List<int> cadenaResultado = new List<int>();
            ViewBag.Negativo = false;
            cadenaResultado.Add(numero);
            if (numero > 1)
            {

                while (cadenaResultado[cadenaResultado.Count - 1] != 1)
                {
                    if (cadenaResultado[cadenaResultado.Count - 1] % 2 == 0)
                    {

                        cadenaResultado.Add(cadenaResultado[cadenaResultado.Count - 1] / 2);
                    }
                    else
                    {
                        cadenaResultado.Add(cadenaResultado[cadenaResultado.Count - 1] * 3 + 1);
                    }

                }
            }
            else
            {
                ViewBag.Negativo = true;
            }

            return View(cadenaResultado);
        }
        //Get CollatzNoForm with args
        [HttpGet]
        public IActionResult CollatzNoForm(int? numero)
        {
            if (numero == null)
            {
                List<int> numerosRandom = new List<int>();
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    numerosRandom.Add(random.Next(10, 200));
                }
                ViewBag.EnlacesNumeros = numerosRandom;
            }
            else
            {
                List<int> conjetura = new List<int>();
                ViewBag.Negativo = false;
                if (numero.Value > 1)
                {
                    conjetura.Add(numero.Value);
                    while (conjetura[conjetura.Count - 1] != 1)
                    {
                        if (conjetura[conjetura.Count - 1] % 2 == 0)
                        {
                            conjetura.Add(conjetura[conjetura.Count - 1] / 2);
                        }
                        else
                        {
                            conjetura.Add(conjetura[conjetura.Count - 1] * 3 + 1);
                        }

                    }
                }
                else
                {
                    ViewBag.Negativo = true;
                }
                return View(conjetura);
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
