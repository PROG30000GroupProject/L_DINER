using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class SeedData
    {
        public static void PopulatedData(IApplicationBuilder app)
        {
            LDINER_DBContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<LDINER_DBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Sides.Any())
            {
                context.Sides.AddRange(
                    new Side
                    {
                        Name = "Best Wing",
                        Price = 10
                    },
                    new Side
                    {
                        Name = "Famous Fries",
                        Price = 6
                    },
                    new Side
                    {
                        Name = "JOJO Shirmp",
                        Price = 14
                    },
                    new Side
                    {
                        Name = "Good Pizza",
                        Price = 12
                    });

                context.SaveChanges();
            }
            if (!context.Drinks.Any())
            {
                
                context.Drinks.AddRange(
                    new Drink
                    {
                        Name = "Coke",
                        Price = 2
                    },
                    new Drink
                    {
                        Name = "Orange Juice",
                        Price = 4
                    },
                    new Drink
                    {
                        Name = "Wisky",
                        Price = 11
                    },
                    new Drink
                    {
                        Name = "Ginger Ale",
                        Price = 2
                    });

                context.SaveChanges();
            }
            if (!context.Burgers.Any())
            {
                
                context.Burgers.AddRange(
                    new Burger
                    {
                        Name = "Cheese Burger",
                        Ingredients = {
                            new IngredientLine{
                                Ingredient={Name="Cheese" },
                                Quantity = 1
                            },
                            new IngredientLine{
                                Ingredient={Name="Beef" },
                                Quantity = 1
                            },
                            new IngredientLine{
                                Ingredient={Name="Picle" },
                                Quantity = 1
                            }
                        },
                        Price = 12
                    },
                    new Burger
                    {
                        Name = "Double Cheese Burger",
                        Ingredients = {
                            new IngredientLine{
                                Ingredient={Name="Cheese" },
                                Quantity = 2
                            },
                            new IngredientLine{
                                Ingredient={Name="Beef" },
                                Quantity = 2
                            },
                            new IngredientLine{
                                Ingredient={Name="Picle" },
                                Quantity = 1
                            }
                        },
                        Price = 12
                    },
                    new Burger
                    {
                        Name = "Meat Lover",
                        Ingredients = {
                            new IngredientLine{
                                Ingredient={Name="Cheese" },
                                Quantity = 1
                            },
                            new IngredientLine{
                                Ingredient={Name="Beef" },
                                Quantity = 2
                            },
                            new IngredientLine{
                                Ingredient={Name="Picle" },
                                Quantity = 1
                            },
                            new IngredientLine{
                                Ingredient={Name="Bacon" },
                                Quantity = 2
                            }
                        },
                        Price = 12
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
