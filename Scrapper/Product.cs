using CsvHelper.Configuration.Attributes;

namespace Scrapper
{
    public class Product
    {
        [Name("Base Price")]
        public decimal Price { get; set; }

        [Name("Quantity")]
        public int Quantity { get; set; } = 9999;

        [Name("Name")]
        public string Name { get; set; }
        [Name("Supplier")]
        public string Author { get; set; }
        [Name("Image URL")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Ignore]
        public string Url { get; set; }

        [Name("Category")]
        public string Categories { get; set; }
    }
}