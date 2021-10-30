using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using CsvHelper;

namespace Scrapper
{
    class Program
    {
        public static List<Product> ScrapPage(int catId, IHtmlCollection<IElement> rawProducts, string baseImgUrl)
        {
            List<Product> result = new List<Product>();
            foreach (var rawProduct in rawProducts)
            {
                Product p = new Product
                {
                    Name = rawProduct.QuerySelector(".full-title-tooltip").TextContent,
                    Price = decimal.Parse(rawProduct.QuerySelector(".price span").TextContent.Split(" ")[0], CultureInfo.InvariantCulture),
                    ImageUrl = baseImgUrl + rawProduct.QuerySelector("a").GetAttribute("class").Split("-")[0] + ".png",
                    Url = "https:" + rawProduct.QuerySelector("a").GetAttribute("href"),
                    Author = rawProduct.QuerySelector("p a").TextContent
                };
                result.Add(p);
            }
            return result;
        }

        static async Task Main(string[] args)
        {
            var baseTarget = "https://helion.pl";
            var target = "https://helion.pl/kategorie/kursy";

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(target);
            
            // Console.WriteLine(document.DocumentElement.OuterHtml);
            List<Product> products = new List<Product>();

            Dictionary<Category, List<Product>> productsDictionary = new Dictionary<Category, List<Product>>();
            // Get category urls
            var categories = document.QuerySelectorAll(".sub-categories a");
            var catCounter = 0;
            // Get amount of pages
            int pages = categories.Length;
            var rawProducts = document.QuerySelectorAll(".book-list-container .list > li");
            string baseImgUrl = rawProducts[0].QuerySelector("img").GetAttribute("src").Split("helion-brak.png")[0];

            foreach(var cat in categories)
            {
                var ID = catCounter++;
                var catText = cat.TextContent;
                System.Console.WriteLine("Visiting " + catText);
                document = await context.OpenAsync(baseTarget + cat.GetAttribute("href"));
                rawProducts = document.QuerySelectorAll(".book-list-container .list > li");
                productsDictionary.Add(new Category
                {
                    ID = ID,
                    Name = catText
                }, ScrapPage(ID, rawProducts,baseImgUrl));
            }

            // int j = 1;
            // foreach(var product in products)
            // {
            //     document = await context.OpenAsync(product.Url);
            //     product.Description = document.QuerySelector(".book-description .center-body-center").TextContent;
            //     Console.WriteLine("Already visited " + j);
            //     j++;
            // }

            string productFileName = "data.csv";
            using (var writer = new StreamWriter(productFileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach(var productsPart in productsDictionary.Values)
                {
                    await csv.WriteRecordsAsync(productsPart);
                }
            }

        }
    }
}
