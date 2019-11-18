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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private MD5 md5;
        private static EnCryptography _encrypt;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                ViewBag.session = HttpContext.Session.GetString("userEmail");
            }
            else
            {
                ViewBag.session = null;
            }
            var query = from cate in _context.Categories.ToList()
                        from product in _context.Products.ToList()
                        where cate.Id == product.CateId
                        from subrand in _context.SubBrands.ToList()
                        where product.SubBrandId == subrand.Id
                        from brand in _context.Brands.ToList()
                        where subrand.BrandId == brand.Id
                        from promo in _context.Promotions.ToList()
                        where product.PromoId == promo.Id
                        select new ProductDto()
                        {
                            product = product,
                            category = cate,
                            subBrand = subrand,
                            brand = brand,
                            promotion = promo
                        };
            var listproductdto = query.ToList();

            return View(listproductdto);
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                HttpContext.Session.Remove("userEmail");
                HttpContext.Session.Clear();
                return View(nameof(Index));
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Product()
        {
            var query = from cate in _context.Categories.ToList()
                        from product in _context.Products.ToList()
                        where cate.Id == product.CateId
                        from subrand in _context.SubBrands.ToList()
                        where product.SubBrandId == subrand.Id
                        from brand in _context.Brands.ToList()
                        where subrand.BrandId == brand.Id
                        from promo in _context.Promotions.ToList()
                        where product.PromoId == promo.Id
                        select new ProductDto()
                        {
                            product = product,
                            category = cate,
                            subBrand = subrand,
                            brand = brand,
                            promotion = promo
                        };
            var listproductdto = query.ToList();
            return View(listproductdto);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            bool checkpass = false;
            var loginUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (ModelState.IsValid)
            {
                using (md5 = MD5.Create())
                {
                    _encrypt = new EnCryptography();
                    checkpass = _encrypt.VerifyMd5Hash(md5, password, loginUser.UserPassword);
                }
                if (checkpass == true)
                {
                    HttpContext.Session.SetString("userEmail", loginUser.Email);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Email,UserPassword,FirstName,LastName,Phone,Address")] User user)
        {
            string hashpass;
            if (ModelState.IsValid)
            {
                var checkRegister = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (checkRegister == null)
                {
                    using (md5 = MD5.Create())
                    {
                        _encrypt = new EnCryptography();
                        hashpass = _encrypt.GetMd5Hash(md5, user.UserPassword);
                    }
                    user.Active = 1;
                    user.Rank = 0;
                    user.RoleId = 1;
                    user.UserPassword = hashpass;
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
