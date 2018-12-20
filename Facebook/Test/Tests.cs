using Facebook.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class Tests
    {

        [TestFixture]
        [Category("Facebook")]
        class FB : Global.Base
        {
            //TestCase1
            [Test, Description("Test to Search for a fb member name")]
            public void SearchName()
            {
                //Start the reports
                test = extent.StartTest("Facebook page navigation");

                //Create a Class and Method
                FBHomePage obj = new FBHomePage();
                obj.SearchAName();

            }
        }
    }
}
