using L_DINER.Helpers;
using L_DINER.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace L_DINER.Controllers
{
    public class HomeController : Controller
    {
        private IBurgerRepository burgerRepo;
        private ISideRepository sideRepo;
        private IDrinkRepository drinkRepo;
        private IOrderRepository orderRepo;
        private IUserRepository userRepo;

        public static int UserID = 0;

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
        public HomeController(IBurgerRepository bRepo, ISideRepository sRepo, IDrinkRepository dRepo, IOrderRepository oRepo, IUserRepository uRepo)
        {
            burgerRepo = bRepo;
            sideRepo = sRepo;
            drinkRepo = dRepo;
            orderRepo = oRepo;
            userRepo = uRepo;
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

            if (HttpContext.Session.GetString("isLoggedIn") == null)
            {
                HttpContext.Session.SetString("isLoggedIn", "false");
            }
            if (HttpContext.Session.GetString("isLoggedIn") == "false")
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                return View(defaultIngredients);
            }
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
                if (HttpContext.Session.GetString("isLoggedIn") == null)
                {
                    HttpContext.Session.SetString("isLoggedIn", "false");
                }

                if (HttpContext.Session.GetString("isLoggedIn").Equals("true"))
                {
                    return View(JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order")));
                }
                else
                {
                    return RedirectToAction("SignIn");
                }
                
            }
            
        }
        public IActionResult MakeOrder() {

            Order order = JsonConvert.DeserializeObject<Order>(HttpContext.Session.GetString("order"));
            order.Price = order.TotalCost();
            order.UserID = (int)Int64.Parse(HttpContext.Session.GetString("isLoggedInUser"));
            orderRepo.submitOrder(order);

            return RedirectToAction("ClearOrder");
        }
        public IActionResult ClearOrder()
        {
            HttpContext.Session.Remove("order");
            return RedirectToAction("Index");
        }

        public IActionResult SignIn()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (IsUserValid(email, password))
            {
                ViewBag.Error = "Valid Login";
                foreach (User u in userRepo.Users) 
                { 
                    if (u.Email.Equals(email))
                    {
                        UserID = u.ID;
                        HttpContext.Session.SetString("isLoggedInUser", u.ID.ToString());
                    }
                }
                HttpContext.Session.SetString("isLoggedIn", "true");
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Invalid username or password";
            return View(new User());
        }

        public bool IsUserValid(string email, string pass)
        {
            foreach (User u in userRepo.Users)
            {
                if (email.Equals(u.Email) && pass.Equals(u.Pass))
                {
                    return true;
                }
            }
            return false;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("isLoggedIn", "false");
            HttpContext.Session.SetString("isLoggedInUser", "0");
            return RedirectToAction("Index");
        }

        public IActionResult SignUp()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                bool emailUsed = false; 
                foreach (User u in userRepo.Users)
                {
                    if (u.Email.Equals(user.Email))
                    {
                        emailUsed = true;
                    }
                }
                if (emailUsed)
                {
                    ModelState.AddModelError(string.Empty, "Email already exists. Please use a different new email");
                    return View();
                }
                else
                {
                    ViewBag.Msg = "Thank you for signing up";
                    userRepo.SaveUser(user);
                    SendEmailToUser(user.Email);
                    ModelState.Clear();
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetString("isLoggedIn") == null)
            {
                HttpContext.Session.SetString("isLoggedIn", "false");
            }

            if (HttpContext.Session.GetString("isLoggedIn").Equals("true"))
            {
                int uid = (int)Int64.Parse(HttpContext.Session.GetString("isLoggedInUser"));

                User user = new User();
                foreach (User u in userRepo.Users)
                {
                    if (uid == u.ID)
                    {
                        user = u;
                    }
                }

                dynamic model = new ExpandoObject();
                model.User = user;
                model.Orders = orderRepo.Orders.Where(o => o.UserID == uid).ToList();

                return View(model);
            }
            else
            {
                return RedirectToAction("SignIn");
            }
            
        }
        private void SendEmailToUser(string toUser)
        {
            string from = "sheridangoats2024@gmail.com"; //From address
            MailMessage message = new MailMessage(from, toUser);

            string mailbody = "Dear User, You are successfully joined us, have a good day!!";
            message.Subject = "Registrition Successfull";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("sheridangoats2024@gmail.com", "goats2024-");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
