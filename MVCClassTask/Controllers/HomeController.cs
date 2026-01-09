using Microsoft.AspNetCore.Mvc;
using MVCClassTask.DAL;
using MVCClassTask.Models;
using MVCClassTask.ViewModels;

namespace MVCClassTask.Controllers
{
    public class HomeController:Controller
    {
        public readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Feature> features = new List<Feature>        {
            new Feature
            {
                Id = 1,
                Title = "Free Shipping Item ",
                Description = "Orders over $500",
                Icon = "fas fa-shipping-fast"
            },
            new Feature
            {
                Id = 2,
                Title = "Money Back Guarantee",
                Description = "100% money back",
                Icon = "fas fa-undo"
            },
            new Feature
            {
                Id = 3,
                Title = "Secure Payment",
                Description = "Safe & secure payment",
                Icon = "fas fa-lock"
            },
            new Feature
            {
                Id = 4,
                Title = "24/7 Support",
                Description = "Dedicated support",
                Icon = "fas fa-headset"
            }
        };
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Name = "Beats Solo3 Wireless",
                    Author = "Apple",
                    ImageUrl = "product-1.jpg",
                    Price = 120,
                    OldPrice=150,
                    Discount=20,
                    CategoryID = 1
                },
                new Product
                {
                    Name = "iPad Retina Display",
                    Author = "Apple",
                    ImageUrl = "product-2.jpg",
                    Price = 980,
                    OldPrice=1350,
                    Discount=15,
                    CategoryID = 1

                },
                new Product
                {
                    Name = "Headphone EP",
                    Author = "Beats",
                    ImageUrl = "product-3.jpg",
                    Price = 89,
                    OldPrice=150,
                    Discount=25,
                    CategoryID = 1
                },
                new Product
                {
                    Name = "Wireless Speaker",
                    Author = "JBL",
                    ImageUrl = "product-4.jpg",
                    Price = 150,
                    OldPrice=200,
                    Discount=30,
                    CategoryID = 1
                }

        };

            //_context.Product.AddRange(products);
            //_context.SaveChanges();
            products=_context.Product.ToList();
            HomeVM homeVM = new HomeVM 
                {
                Features = features,
                Products = products

        };
                



            return View(homeVM);

        }

    }
}
