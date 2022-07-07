using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to InventoryPlus";
        }
    }
}

