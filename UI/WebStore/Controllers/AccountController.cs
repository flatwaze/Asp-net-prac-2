using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.API;
using WebStore.DomainNew.Entities;
using WebStore.Models;



namespace WebStore.Controllers
{
    public class WebApiTestController : Controller
    {
        private readonly IValuesService _ValuesService;
        public WebApiTestController(IValuesService ValuesService) => _ValuesService = ValuesService;

        public IActionResult Index()
        {
            var values = _ValuesService.Get();
            return View(values);
        }
    }
}