using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace Scrapper
{
    class Program
    {
        public static void ScrapPage(List<Product> products, IHtmlCollection<IElement> rawProducts, string baseImgUrl)
        {
            foreach(var rawProduct in rawProducts)
            {
                Product p = new Product
                {
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
            // Get amount of pages
            var paging = document.QuerySelector(".stronicowanie");
            int pages = paging.QuerySelectorAll("a").Length;
            // Console.WriteLine(document.DocumentElement.OuterHtml);
            List<Product> products = new List<Product>();
            //Scrap 1 page
            var rawProducts = document.QuerySelectorAll(".book-list-container .list>li");
            string baseImgUrl = rawProducts[0].QuerySelector("img").GetAttribute("src").Split("helion-brak.png")[0];
            ScrapPage(products,rawProducts,baseImgUrl);
            if(pages > 1)
            {
                //Scrap 2...n pages
                for(int i = 2;i <= pages;i++)
                {
                    document = await context.OpenAsync(target + "/" + i);
                    // document = await context.OpenAsync(resp => resp.Header("Content-Type", "text/html;charset=utf-8").Address(target + "/" + i));
                    rawProducts = document.QuerySelectorAll(".book-list-container .list>li");
                    ScrapPage(products,rawProducts,baseImgUrl);
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

            string fileName = "data.json"; 
            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, products, jso);
            await createStream.DisposeAsync();
        }
    }
}
