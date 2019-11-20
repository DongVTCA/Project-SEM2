using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_SEM2_HNDShop.Data;
using Project_SEM2_HNDShop.DTO;
using Project_SEM2_HNDShop.Models;
using Project_SEM2_HNDShop.Services;
namespace Project_SEM2_HNDShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationContext _context;

        public CartController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                ViewBag.message = "You must login to view cart";
                return View();
            }
            else
            {
                var userId = HttpContext.Session.GetInt32("userId");
                var cart = _context.Carts.ToList().Where(c => c.UserId == userId);
                return View(cart);
            }
        }

        [Route("Cart/AddToCart/{id?}/{quantity?}")]
        public IActionResult AddToCart(int id, int quantity)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var cart = new Cart();
                cart.ProductId = id;
                cart.Quantity = quantity;
                cart.UserId = (int)HttpContext.Session.GetInt32("userId");
                var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == id && c.UserId == cart.UserId);
                if (cartItem != null)
                {
                    cartItem.Quantity += cart.Quantity;
                    _context.Carts.Update(cartItem);
                    _context.SaveChanges();
                }
                _context.Add(cart);
                _context.SaveChanges();
                return View();
            }
        }
        [Route("Cart/UpdateCountCart/{id?}/{quantity?}")]
        public IActionResult UpdateCountCart(int id, int quantity)
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return BadRequest();
            }
            else
            {
                var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == id && c.UserId == userId);
                cartItem.Quantity = quantity;
                _context.Update(cartItem);
                _context.SaveChanges();
                return View(nameof(Index));
            }
        }
        [Route("Cart/DeleteCartItem/{id?}")]
        public IActionResult DeleteCartItem(int id)
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return BadRequest();
            }
            else
            {
                var cartItem = _context.Carts.FirstOrDefault(c => c.ProductId == id && c.UserId == userId);
                if (cartItem != null)
                {
                    _context.Carts.Remove(cartItem);
                    _context.SaveChanges();
                    return View(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}