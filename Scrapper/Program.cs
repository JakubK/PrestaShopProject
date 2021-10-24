using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using CsvHelper;
using CsvHelper.Configuration;

namespace Scrapper
{
    class Program
    {
        public static void ScrapPage(List<Product> products, IHtmlCollection<IElement> rawProducts, string baseImgUrl)
        {
            foreach (var rawProduct in rawProducts)
            {
                Product p = new Product
                {
                    Id = products.Count,
                    Name = rawProduct.QuerySelector(".full-title-tooltip").TextContent,
                    Price = decimal.Parse(rawProduct.QuerySelector(".price span").TextContent.Split(" ")[0], CultureInfo.InvariantCulture),
                    ImageUrl = baseImgUrl + rawProduct.QuerySelector("a").GetAttribute("class").Split("-")[0] + ".png",
                    Url = "https:" + rawProduct.QuerySelector("a").GetAttribute("href"),
                    Author = rawProduct.QuerySelector("p a").TextContent
                };
                products.Add(p);
            }
        }

        static async Task Main(string[] args)
        {
            var target = "https://helion.pl/kategorie/kursy";

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(target);
            
            // Console.WriteLine(document.DocumentElement.OuterHtml);
            List<Product> products = new List<Product>();
            Dictionary<Category, List<Product>> productsDictionary = new Dictionary<Category, List<Product>>();
            // Get amount of pages
            var paging = document.QuerySelector(".stronicowanie");
            int pages = paging.QuerySelectorAll("a").Length;
            //Scrap 1 page
            var rawProducts = document.QuerySelectorAll(".book-list-container .list>li");
            string baseImgUrl = rawProducts[0].QuerySelector("img").GetAttribute("src").Split("helion-brak.png")[0];
            ScrapPage(products, rawProducts, baseImgUrl);
            if (pages > 1)
            {
                //Scrap 2...n pages
                for (int i = 2; i <= pages; i++)
                {
                    document = await context.OpenAsync(target + "/" + i);
                    rawProducts = document.QuerySelectorAll(".book-list-container .list>li");
                    ScrapPage(products, rawProducts, baseImgUrl);
                }
            }
            // int j = 1;
            // foreach(var product in products)
            // {
            //     document = await context.OpenAsync(product.Url);
            //     product.Description = document.QuerySelector(".book-description .center-body-center").TextContent;
            //     Console.WriteLine("Already visited " + j);
            //     j++;
            // }

            string fileName = "data.csv";
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                await csv.WriteRecordsAsync(products);
            }

        }
    }
}
