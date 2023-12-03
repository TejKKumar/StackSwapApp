using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Services;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;
using System.Diagnostics;

//By Imran 
namespace StackSwapApplication.Controllers
{
    public class HomeController : Controller
    {
        //Action method for Landing Page
        public IActionResult MainPage()
        {
            return View();
        }
    }
}