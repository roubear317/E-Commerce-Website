using E_commerce.EF.Context;
using E_commerce.EF.Model;
using E_Commerce.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.EF.Data.extentions
{
    public static class SeedDataExtention
    {

        public static async Task SeedDataAsync(AppDbContext context ,ILoggerFactory loggerfactory)
        {
           // var logger = loggerfactory.CreateLogger<SeedDataExtention>();
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "E-commerce.EF/Data");


           // var logger = loggerfactory.CreateLogger(typeof(SeedDataExtention));






            try
            {
                if (!context.Categories.Any())
                {
                    //var CategoryData = File.ReadAllText("../E-commerce.EF/Data/Category.json");

              //      await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories ON");
                    var CategoryData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\Category.json");




                    //  var CategoryData = File.ReadAllText(Path.Combine(basePath, "Category.json"));

                    


                    var category = JsonSerializer.Deserialize<List<Category>>(CategoryData);

                    foreach(var item in category)
                    {
                        await context.Categories.AddAsync(item);

                       
                    }

                    await context.SaveChangesAsync();
              //      await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories OFF");
                }
                if (!context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\Product.json");

                    //var ProductsData = File.ReadAllText(Path.Combine(basePath, "Product.json"));

                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                    foreach (var item in Products)
                    {
                        await context.Products.AddAsync(item);


                    }

                    await context.SaveChangesAsync();

                }
                if (!context.Orders.Any())
                {
                   var OrdersData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\Order.json");

                    // var OrdersData = File.ReadAllText(Path.Combine(basePath, "Order.json"));

                    var options = new JsonSerializerOptions
                    {
                        Converters =
    {
        new JsonDateTimeConverter()  
    }
                    };

                    


                    var Orders = JsonSerializer.Deserialize<List<Order>>(OrdersData, options);

                    foreach (var item in Orders)
                    {
                        await context.Orders.AddAsync(item);


                    }

                    await context.SaveChangesAsync();

                }
                if (!context.Payments.Any())
                {
                    var PaymentsData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\Payment.json");

                   // var PaymentsData = File.ReadAllText(Path.Combine(basePath, "Payment.json"));

                    var Payments = JsonSerializer.Deserialize<List<Payment>>(PaymentsData);

                    foreach (var item in Payments)
                    {
                        await context.Payments.AddAsync(item);


                    }

                    await context.SaveChangesAsync();

                }
                if (!context.Items.Any())
                {
                    var OrderItemsData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\OrderItem.json");

                    //var OrderItemsData = File.ReadAllText(Path.Combine(basePath, "OrderItem.json"));

                    var orderItemts = JsonSerializer.Deserialize<List<OrderItem>>(OrderItemsData);

                    foreach (var item in orderItemts)
                    {
                        await context.Items.AddAsync(item);


                    }

                    await context.SaveChangesAsync();

                }

                if (!context.Photos.Any())
                {
                   var PhotosData = File.ReadAllText("D:\\مشروع Angular\\Project E-commerce.api\\E-commerce.EF\\Data\\Photo.json");

                    //var PhotosData = File.ReadAllText(Path.Combine(basePath, "Photo.json"));

                    var PhotosItemts = JsonSerializer.Deserialize<List<Photo>>(PhotosData);

                    foreach (var item in PhotosItemts)
                    {
                        await context.Photos.AddAsync(item);


                    }

                    await context.SaveChangesAsync();

                }
            }catch(Exception ex)
            {
                var logger = loggerfactory.CreateLogger<AppDbContext>();

                logger.LogError(ex.Message);
            }


        }


    }
}
