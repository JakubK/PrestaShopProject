using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost");
            Random r = new Random();
            
            //1. 10 products from 2 categories
            
            for(int i = 0;i < 2;i++) 
            {
                var categoryLinks = driver.FindElements(By.CssSelector("#top-menu li a"));
                categoryLinks[i].Click();                
                //Take 5 products each loop step
                for(int j = 0;j < 5;j++)
                {
                    var products = driver.FindElements(By.CssSelector("#products a.product-thumbnail"));
                    products[j].Click();

                    var quantityInput = driver.FindElement(By.Id("quantity_wanted"));
                    quantityInput.Clear();
                    quantityInput.SendKeys(r.Next() % 10 + 1 + "");//random quantity


                    //wait for cart modal to appear
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                    //add to cart
                    driver.FindElement(By.CssSelector(".btn.btn-primary.add-to-cart")).Click();
                    //continue shopping
                    driver.FindElement(By.CssSelector(".cart-content-btn button")).Click();

                    //after successful cart addition return to category
                    driver.Navigate().Back();
                }
            }

            //Go to the cart
            driver.FindElement(By.CssSelector(".blockcart")).Click();
            //Throw away 1 product
            int productToThrow = r.Next() % 10;
            driver.FindElements(By.CssSelector(".cart-items .cart-item a.remove-from-cart"))[productToThrow].Click();
            //Register new account
            driver.FindElement(By.CssSelector(".checkout.cart-detailed-actions.card-block a")).Click();


            //gender
            driver.FindElement(By.CssSelector(".form-group.row:nth-child(1) .custom-radio")).Click();

            //name
            driver.FindElement(By.CssSelector("input[name=firstname]")).SendKeys("Jan");
            //surname
            driver.FindElement(By.CssSelector("input[name=lastname]")).SendKeys("Kowalski");
            //email
            driver.FindElement(By.CssSelector("input[name=email]")).SendKeys("example" + r.Next() + "@example" + r.Next() + ".com");

            //password
            driver.FindElement(By.CssSelector("input[name=password]")).SendKeys("P@ssw0rd");

            //birthday
            driver.FindElement(By.CssSelector("input[name=birthday]")).SendKeys("1970-05-31");

            var checks = driver.FindElements(By.CssSelector(".custom-checkbox"));
            foreach(var check in checks)
            {
                check.Click();
            }

            driver.FindElement(By.CssSelector(".continue")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.FindElement(By.CssSelector("input[name=address1]")).SendKeys("Gdansk");
            driver.FindElement(By.CssSelector("input[name=address2]")).SendKeys("Politechniczna 21/37");
            driver.FindElement(By.CssSelector("input[name=postcode]")).SendKeys("14-888");
            driver.FindElement(By.CssSelector("input[name=city]")).SendKeys("Gdansk");


            //Supplier
            driver.FindElement(By.CssSelector("#delivery-address button[type=submit]")).Click();
            driver.FindElement(By.CssSelector("#js-delivery button[type=submit]")).Click();

            //Payment
            driver.FindElement(By.CssSelector("#payment-option-2-container .custom-radio")).Click();
            driver.FindElement(By.CssSelector(".custom-checkbox")).Click();
            //Submit order
            driver.FindElement(By.CssSelector("#payment-confirmation button")).Click();

            //Check status
            // Save order number
            var orderText = driver.FindElement(By.CssSelector("#order-details ul li:nth-child(1)")).Text;
            var orderNumber = orderText.Split(":")[1].Trim();
            System.Console.Error.WriteLine(orderNumber);
            driver.FindElement(By.CssSelector("a.account")).Click();

            driver.FindElement(By.Id("history-link")).Click();

            var orders = driver.FindElements(By.CssSelector("table tbody tr"));
            var orderIndex = 0;
            for(int i = 0;i < orders.Count;i++)
            {
                if(orders[i].FindElement(By.CssSelector("th:nth-of-type(1)")).Text == orderNumber)
                {
                    orderIndex = i;
                    break;
                }
            }

            orders[orderIndex].FindElement(By.CssSelector("a[data-link-action=view-order-details]")).Click();

            System.Console.WriteLine("Test Complete!");
        }
    }
}