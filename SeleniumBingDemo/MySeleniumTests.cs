using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumBingDemo
{
	[TestClass]
	public class MySeleniumTests
	{
		private IWebDriver driver;

		[TestMethod]
		[TestCategory("Chrome")]
		public void TheBingSearchTest2()
		{
			var appURL = "http://www.bing.com/";
			driver.Navigate().GoToUrl(appURL);
			driver.Manage().Window.Maximize();
			driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
			var koss = driver.FindElement(By.Id("sb_form_go"));
			Console.WriteLine("found element {0}", koss.GetAttribute("outerHTML"));
			koss.Click();
		}

		[TestInitialize()]
		public void SetupTest()
		{
			string browser = "Chrome";
			switch (browser)
			{
				case "Chrome":
					driver = new ChromeDriver();
					break;
				case "Firefox":
					driver = new FirefoxDriver();
					break;
				case "IE":
					driver = new InternetExplorerDriver();
					break;
				default:
					driver = new ChromeDriver();
					break;
			}
		}

		[TestCleanup()]
		public void MyTestCleanup()
		{
			//driver.Quit();
		}
	}
}
