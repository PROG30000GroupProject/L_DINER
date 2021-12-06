using L_DINER.Helpers;
using L_DINER.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Controllers
{
    public class HomeController : Controller
    {
        private IBurgerRepository burgerRepo;
        private ISideRepository sideRepo;
        private IDrinkRepository drinkRepo;
        private IOrderRepository orderRepo;
        int defaultBurgerNumber = 3;
        List<IngredientLine> defaultIngredients = new List<IngredientLine> {
                new IngredientLine {
                    Ingredient = new Ingredient {
                        Name = "Beef"
                    },
                    Quantity = 1
                },
                 new IngredientLine
                 {
                     Ingredient = new Ingredient
                     {
                         Name = "Bacon"
                     },
                     Quantity = 1
                 },
                  new IngredientLine
                  {
                      Ingredient = new Ingredient
                      {
                          Name = "Cheese"
                      },
                      Quantity = 1
                  },
                   new IngredientLine
                   {
                       Ingredient = new Ingredient
                       {
                           Name = "Pincle"
                       },
                       Quantity = 1
                   }
            };
        public HomeController(IBurgerRepository bRepo, ISideRepository sRepo, IDrinkRepository dRepo, IOrderRepository oRepo)
        {
            burgerRepo = bRepo;
            sideRepo = sRepo;
            drinkRepo = dRepo;
            orderRepo = oRepo;
        }
        public IActionResult Index()
        {
            MenuObject menu = new MenuObject{
                Burgers = burgerRepo.Burgers.Where(b=>b.ID<=defaultBurgerNumber).ToList(),
                Sides = sideRepo.Sides.ToList(),
                Drinks = drinkRepo.Drinks.ToList()
            };
            return View(menu);
        }
        public IActionResult AddDrink(int ID) {
            if (HttpContext.Session.GetString("order")==null)
            {
                Order tempOrder = new Order();
                tempOrder.Drinks.Add(new OrderObjectForDrink
                {
                    Drink = drinkRepo.Drinks.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                //System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Drinks.Count());
            }
            else {
                Order tempOrder = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order"));
                tempOrder.Drinks.Add(new OrderObjectForDrink
                {
                    Drink = drinkRepo.Drinks.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Drinks.Count());
            }
            

            return RedirectToAction("Index");
        }
        public IActionResult AddSide(int ID)
        {
            if (HttpContext.Session.GetString("order") == null)
            {
                Order tempOrder = new Order();
                tempOrder.Sides.Add(new OrderObjectForSide
                {
                    Side = sideRepo.Sides.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                //System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Drinks.Count());
            }
            else
            {
                Order tempOrder = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order"));
                tempOrder.Sides.Add(new OrderObjectForSide
                {
                    Side = sideRepo.Sides.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Sides.Count());
            }


            return RedirectToAction("Index");
        }
        public IActionResult AddBurger(int ID)
        {
            if (HttpContext.Session.GetString("order") == null)
            {
                Order tempOrder = new Order();
                tempOrder.Burgers.Add(new OrderObjectForBurger
                {
                    Burger = burgerRepo.Burgers.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                //System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Drinks.Count());
            }
            else
            {
                Order tempOrder = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order"));
                tempOrder.Burgers.Add(new OrderObjectForBurger
                {
                    Burger = burgerRepo.Burgers.Where(d => d.ID == ID).FirstOrDefault(),
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Burgers.Count());
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CustomBurger() {
            
            return View(defaultIngredients);
        }
        [HttpPost]
        public IActionResult AddCustomBurgerToOrder(int []ingredient)
        {
            System.Diagnostics.Debug.WriteLine(ingredient[0]);
            foreach (var (item, index) in defaultIngredients.Select((value, i) => (value, i))) {
                item.Quantity = ingredient[index];
            }
            foreach (var line in defaultIngredients)
            {
                System.Diagnostics.Debug.WriteLine("Quantity:" + line.Quantity);
            }
            Burger burger = new Burger
            {
                Name = "Custom Burger",
                Price = 15.99,
                Ingredients = defaultIngredients
            };

            if (HttpContext.Session.GetString("order") == null)
            {
                Order tempOrder = new Order();
                tempOrder.Burgers.Add(new OrderObjectForBurger
                {
                    Burger = burger,
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                //System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Drinks.Count());
            }
            else
            {
                Order tempOrder = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order"));
                tempOrder.Burgers.Add(new OrderObjectForBurger
                {
                    Burger = burger,
                    Quantity = 1
                });
                HttpContext.Session.SetString("order", JsonConvert.SerializeObject(tempOrder));
                System.Diagnostics.Debug.WriteLine("Added:" + tempOrder.Burgers.Count());
            }
            return RedirectToAction("Index");
        }
        public IActionResult ReviewOrder()
        {
            //System.Diagnostics.Debug.WriteLine(HttpContext.Session.GetString("order"));
            //orderRepo.submitOrder(JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order")));
            if (HttpContext.Session.GetString("order") == null)
            {
                ViewBag.EmptyOrderError = "Order Cannot be empty";
                MenuObject menu = new MenuObject
                {
                    Burgers = burgerRepo.Burgers.Where(b => b.ID <= defaultBurgerNumber).ToList(),
                    Sides = sideRepo.Sides.ToList(),
                    Drinks = drinkRepo.Drinks.ToList()
                };
                return View("Index",menu);
            }
            else {
                return View(JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order")));
            }
            
        }
        public IActionResult MakeOrder() {
            orderRepo.submitOrder(JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order")));
            return RedirectToAction("Index");
        }
        public IActionResult ClearOrder()
        {
            HttpContext.Session.Remove("order");
            return RedirectToAction("Index");
        }
    }
}
