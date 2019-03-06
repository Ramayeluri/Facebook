using Facebook.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Facebook.Global.CommonMethods;

namespace Facebook.Pages
{
    internal class FBHomePage
    {
        internal void SearchAName()
        {
           
            //Thread.Sleep(8000);
            IAlert alt = GlobalDefinitions.driver.SwitchTo().Alert();
            GlobalDefinitions.wait(4);
            alt.Accept();
            //Populate the excel sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, "HomePage");
            //IAlert alt = GlobalDefinitions.driver.SwitchTo().Alert();
            // alt.Dismiss();
            GlobalDefinitions.wait(4);
            //Enter the Name or word on the Search box
            GlobalDefinitions.TextBox(GlobalDefinitions.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(3, "InputValue"));
            GlobalDefinitions.wait(3);
            //Click on Search
            GlobalDefinitions.ActionButton(GlobalDefinitions.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
        }
    }
}
