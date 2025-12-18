using Microsoft.AspNetCore.Mvc;
using MVCClassTask.Models;
using MVCClassTask.ViewModels;

namespace MVCClassTask.Controllers
{
    public class HomeController:Controller
    {
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
                    Discount=20
                },
                new Product
                {
                    Name = "iPad Retina Display",
                    Author = "Apple",
                    ImageUrl = "product-2.jpg",
                    Price = 980,
                    OldPrice=1350,
                    Discount=15
                },
                new Product
                {
                    Name = "Headphone EP",
                    Author = "Beats",
                    ImageUrl = "product-3.jpg",
                    Price = 89,
                    OldPrice=150,
                    Discount=25
                },
                new Product
                {
                    Name = "Wireless Speaker",
                    Author = "JBL",
                    ImageUrl = "product-4.jpg",
                    Price = 150,
                    OldPrice=200,
                    Discount=30
                }

        };


        HomeVM homeVM = new HomeVM 
                {
                Features = features,
                Products = products

        };
                



            return View(homeVM);

        }

    }
}
