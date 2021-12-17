using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using ProductsandCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsandCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context; 
        // include above the routes (will allow us to use DB info in routes):
        public HomeController(MyContext context)
        {
                _context = context;
        }


        [HttpGet("products")]
        public IActionResult Products()
        {
            ProductViewModel viewmodel = new ProductViewModel()
            {
                AllProducts = _context.Products
                    .Include(p => p.Associations)
                        .ThenInclude(c => c.Product)
                    .ToList()
            };
            return View("products", viewmodel);
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            CategoryViewModel viewmodel = new CategoryViewModel()
            {
                AllCategories = _context.Categories
                    .Include(c => c.Associations)
                        .ThenInclude(p => p.Category)
                    .ToList()
            };
            return View("categories", viewmodel);
        }

        [HttpGet("products/{productid}")]
        public IActionResult ProductInformation(int productid)
        {
            ProductInformationVM viewmodel = new ProductInformationVM()
            {

            //get product by ProductId, sort categories into list of assigned and form of unassigned
            ThisProduct = _context.Products
                .Include(p => p.Associations)
                    .ThenInclude(c => c.Category)
                .FirstOrDefault(p => p.ProductId == productid),

            UnassignedCategories = _context.Categories
                .Include(p => p.Associations)
                    .ThenInclude(c => c.Category)
                    .Where(c => !c.Associations .Any( i => i.ProductId == productid))
                .ToList()
            };

            if(viewmodel.ThisProduct == null)
            {
                return RedirectToAction("products");
            }
            return View(viewmodel);
        }

        [HttpGet("categories/{categoryid}")]
        public IActionResult CategoryInformation(int categoryid)
        {
            CategoryInformationVM viewmodel = new CategoryInformationVM()
            {

            //get category by CategoryId, sort products into list of assigned and form of unassigned
            ThisCategory = _context.Categories
                .Include(c => c.Associations)
                    .ThenInclude(p => p.Product)
                .FirstOrDefault(c => c.CategoryId == categoryid),

            UnassignedProducts = _context.Products
                    .Include(c => c.Associations)
                        .ThenInclude(p => p.Product)
                        .Where(p => !p.Associations .Any(i => i.CategoryId == categoryid))
                    .ToList()
            };

            if(viewmodel.ThisCategory == null)
                {
                    return RedirectToAction("categories");
                }
                return View(viewmodel);
        }


        [HttpPost("createproduct")]
        public IActionResult CreateProduct(ProductViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(viewmodel.ThisProduct);
                _context.SaveChanges();
                return RedirectToAction ("ProductInformation", new {productid = viewmodel.ThisProduct.ProductId});
            }
            else
            {
                return Products();
            }
        }

        [HttpPost("createcategory")]
        public IActionResult CreateCategory(CategoryViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(viewmodel.ThisCategory);
                _context.SaveChanges();
                return RedirectToAction ("CategoryInformation", new {categoryid = viewmodel.ThisCategory.CategoryId});
            }
            else
            {
                return Categories();
            }
        }

        [HttpPost("productassigncategory")]
            // use a form to associate the ProductId and CategoryId
        public IActionResult AssignCategory(ProductInformationVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(viewmodel.Connection);
                _context.SaveChanges();
                return RedirectToAction("ProductInformation", new {productid = viewmodel.Connection.ProductId});
            }
            else
            {
                return Products();
            }
        }

        [HttpPost("categoryassignproduct")]
            // use a form to associate the Category Id and the ProductId
        public IActionResult AssignProduct(CategoryInformationVM viewmodel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(viewmodel.Connection);
                _context.SaveChanges();
                return RedirectToAction ("CategoryInformation", new {categoryid = viewmodel.Connection.CategoryId});
            }
            else
            {
                return Categories();
            }
        }
        


    }
}

