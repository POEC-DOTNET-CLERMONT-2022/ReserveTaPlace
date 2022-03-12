using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveTaPlace.Wpf.Tests
{
    [TestClass]
    public class WpfTest : WpfSession
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            Setup(testContext);
        }
        [TestMethod]
        public void TestApp()
        {
           var login = session.FindElementByAccessibilityId("TBPassword");
            login.Click();
            login.SendKeys("pqss");
            session.FindElementByAccessibilityId("LoginBTN").Click();
            Thread.Sleep(10000);
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            TearDown();
        }
    }
}
