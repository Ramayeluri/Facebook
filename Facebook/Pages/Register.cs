using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Facebook.Global.CommonMethods;

namespace Facebook.Pages
{
    class Register
    {
        internal void RegisterwithValidData()
        {
            //Populate the Excel file
            Global.CommonMethods.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Registration");

            //Navigate to the Registration URL
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "InputValue"));

            //Enter FirstName
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(3, "FirstName"));

            //Enter SurName           
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"), ExcelLib.ReadData(4, "SurName"));

            //Enter Email          
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"), ExcelLib.ReadData(5, "Email"));

            //Enter Password
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "LocatorValue"), ExcelLib.ReadData(6, "Password"));

            //Select Birthday Date from dropdown
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "LocatorValue"));
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "LocatorValue"), ExcelLib.ReadData(7, "InputValue"));

            //Select Birthday Month from dropdown
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, ExcelLib.ReadData(8, "Locator"), ExcelLib.ReadData(8, "LocatorValue"));
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(8, "Locator"), ExcelLib.ReadData(8, "LocatorValue"), ExcelLib.ReadData(8, "InputValue"));

            //Select Birthday Year from dropdown            
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, ExcelLib.ReadData(9, "Locator"), ExcelLib.ReadData(9, "LocatorValue"));
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, ExcelLib.ReadData(9, "Locator"), ExcelLib.ReadData(9, "LocatorValue"), ExcelLib.ReadData(9, "InputValue"));

            //Select the Gender Male button 
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, ExcelLib.ReadData(10, "Locator"), ExcelLib.ReadData(10, "LocatorValue"));

            //Click on Sign Up Button
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, ExcelLib.ReadData(12, "Locator"), ExcelLib.ReadData(12, "LocatorValue"));
        }
    }
}


