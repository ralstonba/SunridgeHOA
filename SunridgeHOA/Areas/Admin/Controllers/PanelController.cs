using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SunridgeHOA.Data;

namespace SunridgeHOA.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PanelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PanelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}