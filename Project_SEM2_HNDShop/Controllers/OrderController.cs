using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_SEM2_HNDShop.Data;
using Project_SEM2_HNDShop.Services;

namespace Project_SEM2_HNDShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly Repository _repository;

        public OrderController(ApplicationContext context)
        {
            _context = context;
            _repository = new Repository(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}