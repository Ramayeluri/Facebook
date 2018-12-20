using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Facebook.Pages
{
    class LoginPage
    
    {
       public void LoginSteps()
            {

                //Populate the Excel Sheet
                Global.CommonMethods.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Login");

                //Navigate to the URL
                Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.CommonMethods.ExcelLib.ReadData(2, "InputValue"));

                //Delete cookies
                // Global.GlobalDefinitions.driver.Manage().Cookies.DeleteAllCookies();

                //Enter Email or phone
                Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(3, "Locator"), Global.CommonMethods.ExcelLib.ReadData(3, "LocatorValue"), Global.CommonMethods.ExcelLib.ReadData(3, "InputValue"));
                 Thread.Sleep(3000);
                //Enter Password
                Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(4, "Locator"), Global.CommonMethods.ExcelLib.ReadData(4, "LocatorValue"), Global.CommonMethods.ExcelLib.ReadData(4, "InputValue"));
                  Thread.Sleep(3000);
                //Click on Login Button
                Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(5, "Locator"), Global.CommonMethods.ExcelLib.ReadData(5, "LocatorValue"));


            }
        }
}
