using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using CsvHelper;
using CsvHelper.Configuration;

namespace Scrapper
{
    class Program
    {
        //name
        public static Dictionary<string, List<string>> prodCatDictionary = new Dictionary<string, List<string>>();
        public static List<Product> allProducts = new List<Product>();

        public static void ScrapPage(string catName, IHtmlCollection<IElement> rawProducts, string baseImgUrl)
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
                p.Name = p.Name.Length > 128 ? p.Name.Substring(0,127) : p.Name;
                if(prodCatDictionary.ContainsKey(p.Name))
                {
                    prodCatDictionary[p.Name].Add(catName);
                }
                else {
                    prodCatDictionary.Add(p.Name,new List<string>());
                    prodCatDictionary[p.Name].Add(catName);
                }

                allProducts.Add(p);
            }
        }

        static async Task Main(string[] args)
        {
            var baseTarget = "https://helion.pl";
            var target = "https://helion.pl/kategorie/kursy";

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(target);
            
            // Console.WriteLine(document.DocumentElement.OuterHtml);
            List<Category> categoriesList = new List<Category>();
            
            // Get category urls
            var categories = document.QuerySelectorAll(".sub-categories a");
            var catCounter = 0;
            // Get amount of pages
            int pages = categories.Length;
            var rawProducts = document.QuerySelectorAll(".book-list-container .list > li");
            string baseImgUrl = "https://static01.helion.com.pl/global/okladki/326x466/";

            foreach(var cat in categories)
            {
                var ID = ++catCounter;
                var catText = cat.TextContent;
                categoriesList.Add(new Category {
                    Name = catText
                });
                System.Console.WriteLine("Visiting " + catText + " " + ID + "/" + pages);
                document = await context.OpenAsync(baseTarget + cat.GetAttribute("href"));
                rawProducts = document.QuerySelectorAll(".book-list-container .list > li");
                ScrapPage(catText, rawProducts,baseImgUrl);
            }

            var limitedProducts = allProducts.GroupBy(x => x.Name).Select(g=>g.First()).ToList();
            int j = 0;
            foreach(var limited in limitedProducts)
            {
                System.Console.WriteLine("Evaluating " + (++j) + " of " + limitedProducts.Count);
                limited.Categories = string.Join(";", prodCatDictionary[limited.Name]);
                document = await context.OpenAsync(limited.Url);
                limited.Description = Regex.Replace(document.QuerySelector(".book-description .text").TextContent, @"\t|\n|\r", "");
            }

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|",
            };
            string productFileName = "data.csv";
            using (var writer = new StreamWriter(productFileName))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                await csv.WriteRecordsAsync(limitedProducts);
            }

            string categoryFileName = "categories.csv";
            using (var writer = new StreamWriter(categoryFileName))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                await csv.WriteRecordsAsync(categoriesList);
            }

        }
    }
}
