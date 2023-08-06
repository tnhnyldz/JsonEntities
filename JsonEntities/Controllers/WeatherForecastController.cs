using JsonEntities.DataAccessLayer.Data;
using JsonEntities.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonEntities.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {


            List<ProductFiles> files = new List<ProductFiles>();
            var listtt1 = new ProductFiles
            {
                Name = "kadmnkads",
                Url = "alsdkladslads"
            };
            var listtt2 = new ProductFiles
            {
                Name = "kadmadadsankads",
                Url = "alsdkldsadsadsadslads"
            };
            files.Add(listtt1);
            files.Add(listtt2);
            var add1 = new ProductRequest
            {
                Currency = "USD",
                CountryId = 31,
                CancelOrderIfCouponFails = true,
                Instructions = "aksjdjadsad",
                MaxPrice = 100,
                Files= files
            };
            var add2 = new ProductRequest
            {
                Currency = "TRY",
                CountryId = 32,
                CancelOrderIfCouponFails = false,
                Instructions = "aksjdjsssssssssadsad",
                MaxPrice = 131,
                Files= files
            };
            var add3 = new ProductQuote
            {
                CouponCode = new List<string> { "s", "s", "s" },
                Notes="this is a note",
                SubTotal=20,
                Discount=89,
                Shipping=31,
                Tax=23
                
            };
            var add4 = new ProductQuote
            {
                CouponCode = new List<string> { "ss", "ss", "ss" },
                Notes = "this is a sssss",
                SubTotal = 202,
                Discount = 389,
                Shipping = 341,
                Tax = 253
            };

            var productreqList = new List<ProductRequest>();
            productreqList.Add(add1);
            productreqList.Add(add2);

            var productQuoteList = new List<ProductQuote>();
            productQuoteList.Add(add3);
            productQuoteList.Add(add4);

            var pd = new ProductDetail
            {
                ProductRequests = productreqList,
                ProductQuotes = productQuoteList
            };


            Product p1 = new Product
            {
                Name = "Ali Cabbar",
                Description = "Ali Cabbar Açıklama",
                Quantity = "3 Ali Cabbar",
                Price = 30,
                Detail = pd
            };


            var context = new Context();
            context.Products.Add(p1);
            context.SaveChanges();






            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
