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
        //
        /// <summary>
        /// Action method for Landing Page
        /// </summary>
        /// <returns></returns>
        public IActionResult MainPage()
        {
            return View();
        }
    }
}