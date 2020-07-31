using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD.MVC.Models;
using CRUD.MVC.Repository;
using System.Net.Http;
using Newtonsoft.Json;

namespace CRUD.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        // GET: Employee  
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse();
                response.EnsureSuccessStatusCode();
                var employees =JsonConvert.DeserializeObject<List<Employee>>(response.Content.ReadAsStringAsync().Result);
                ViewBag.Title = "All Employees";
                return View(employees);
            }
            catch (Exception)
            {
                throw;
            }
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
