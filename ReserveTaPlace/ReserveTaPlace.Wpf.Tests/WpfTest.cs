using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            session.FindElementByAccessibilityId("LoginBTN").Click();
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            TearDown();
        }
    }
}
