using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;


namespace Facebook.Global
{
    class GlobalDefinitions
    {
        //Initialize the driver
        public static IWebDriver driver { get; set; }

        //Generic Methods
        //Identifying the Textbox
        public static void TextBox(IWebDriver driver, string Locator, string LocatorValue, string InputValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).SendKeys(InputValue);

            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).SendKeys(InputValue);

            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).SendKeys(InputValue);

        }



        //Identifying the ActionButtons or Dropdowns
        public static void ActionButton(IWebDriver driver, string Locator, string LocatorValue)
        {
            if (Locator == "Id")
                driver.FindElement(By.Id(LocatorValue)).Click();

            else if (Locator == "XPath")
                driver.FindElement(By.XPath(LocatorValue)).Click();

            else if (Locator == "CSS")
                driver.FindElement(By.CssSelector(LocatorValue)).Click();

        }

        //Get the text from the IWebElements
        public static string GetTextValue(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
                return driver.FindElement(By.Id(Lvalue)).Text;

            else if (Locator == "XPath")
                return driver.FindElement(By.XPath(Lvalue)).Text;

            else if (Locator == "CSS")
                return driver.FindElement(By.CssSelector(Lvalue)).Text;

            else
                Console.WriteLine("Invalid Locator value");
            return "";
        }


        //To clear the text
        public static void GetClear(IWebDriver driver, string Locator, string Lvalue)
        {
            if (Locator == "Id")
            {
                driver.FindElement(By.Id(Lvalue)).Clear();
            }
            else if (Locator == "XPath")
            {
                driver.FindElement(By.XPath(Lvalue)).Clear();
            }
            else if (Locator == "CSS")
            {
                driver.FindElement(By.CssSelector(Lvalue)).Clear();
            }
            else
                Console.WriteLine("Invalid Locator value");

        }


        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }
        #endregion

        public static bool ElementVisible(IWebDriver driver, string Locator, string Lvalue)
        {
            try
            {
                if (Locator == "Id")
                    return driver.FindElement(By.Id(Lvalue)).Displayed && driver.FindElement(By.Id(Lvalue)).Enabled;
                else if (Locator == "XPath")
                    return driver.FindElement(By.XPath(Lvalue)).Displayed && driver.FindElement(By.XPath(Lvalue)).Enabled;
                else if (Locator == "CSS")
                    return driver.FindElement(By.CssSelector(Lvalue)).Displayed && driver.FindElement(By.CssSelector(Lvalue)).Enabled;
                else
                {
                    Console.WriteLine("Invalid Locator value");
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;

            }
        }

        //Function to get By.<Locator>("<LValue>") expression
        internal static By GetFindByString(string Locator, string Lvalue)
        {
            By by = null;

            switch (Locator)
            {
                case "Id":
                    by = By.Id(Lvalue);
                    break;
                case "XPath":
                    by = By.XPath(Lvalue);
                    break;
                case "CSSSelector":
                    by = By.CssSelector(Lvalue);
                    break;
                case "ClassName":
                    by = By.ClassName(Lvalue);
                    break;
                case "TagName":
                    by = By.TagName(Lvalue);
                    break;
                case "Name":
                    by = By.Name(Lvalue);
                    break;
                case "LinkText":
                    by = By.LinkText(Lvalue);
                    break;
                case "PartialLinkText":
                    by = By.PartialLinkText(Lvalue);
                    break;
            }

            return by;
        }




        /* ToClickAsYes - When there is a need to find an element using for loop which also needs to be clicked, then ToClickAsYes will be "Yes" else it will be "No".
         * Need for AfterXPath variable - In case there is a need to identify and click an element in for loop where XPath can be split on the basis of i variable, 
         * then complete XPath will be 
         * Lvalue will have the Before XPath + i variable + AfterXPath */
        public static bool FindElementsUsingForLoop(IWebDriver driver, string Locator, string Lvalue, string AfterXpath, string Inputvalue, string ToClickAsYes)
        {
            try
            {

                //Trigger the function to get By.<Locator>("<LValue>") expression
                By by = GetFindByString(Locator, Lvalue);

                ReadOnlyCollection<IWebElement> elementlist = driver.FindElements(by);

                int i = 1;

                foreach (var element in elementlist)
                {

                    //if After XPath exists then 
                    if (Locator == "XPath" && AfterXpath != "" && Inputvalue == element.Text && ToClickAsYes == "Yes")
                    {
                        driver.FindElement(By.XPath(Lvalue + "[" + (i - 1) + "]" + AfterXpath)).Click();
                        return true;
                    }

                    if (AfterXpath == "" && Inputvalue == element.Text && ToClickAsYes == "Yes")
                    {
                        element.Click();
                        return true;
                    }
                    if (AfterXpath == "" && Inputvalue == element.Text && ToClickAsYes == "No")
                    {
                        return true;
                    }
                    i++;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SendDateWithOutCalendar(IWebDriver driver, string Locator, string Lvalue, string Inputvalue)
        {
            By by = GetFindByString(Locator, Lvalue);

            driver.FindElement(by).Clear();
            Thread.Sleep(500);
            driver.FindElement(by).SendKeys(Inputvalue);
            driver.FindElement(by).SendKeys(Keys.Tab);
        }

        // To Select address 
        public static void KeyDown(IWebDriver driver, string Locator, string Lvalue)
        {
            By by = GetFindByString(Locator, Lvalue);
            IWebElement element = driver.FindElement(by);
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Enter);
        }

        // To select element from dropdown using Select Element
        public static void SelectMethod(IWebDriver driver, string Locator, string LocatorValue, string InputValue)
        {

            By by = GetFindByString(Locator, LocatorValue);
            SelectElement select = new SelectElement(driver.FindElement(by));
            select.SelectByText(InputValue);

        }

        
        }
    }




