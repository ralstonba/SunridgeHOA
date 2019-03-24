﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunridgeHOA.Models;

namespace SunridgeHOA.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BoardMembers()
        {
            return View();
        }

        public IActionResult EventCalender()
        {
            return View();
        }

        public IActionResult Lots()
        {
            return View();
        }

        public IActionResult Cabins()
        {
            return View();
        }

        public IActionResult OtherServices()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult Forms()
        {
            return View();
        }

        public IActionResult FireInfo()
        {
            return View();
        }

        public IActionResult Season2018()
        {
            return View();
        }

        public IActionResult Season2017()
        {
            return View();
        }

        public IActionResult Season2016()
        {
            return View();
        }

        public IActionResult PhotoGallery()
        {
            return View();
        }

        public IActionResult SummerGallery()
        {
            return View();
        }

        public IActionResult WinterGallery()
        {
            return View();
        }

        public IActionResult PeopleGallery()
        {
            return View();
        }

        public IActionResult H13()
        {
            return View();
        }

        public IActionResult CabinBak()
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