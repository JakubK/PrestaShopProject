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

            //Throw away 1 product

            //Register new account

            //Payment

            //Supplier

            //Submit order

            //Check status
            System.Console.WriteLine("Test Complete!");
        }
    }
}