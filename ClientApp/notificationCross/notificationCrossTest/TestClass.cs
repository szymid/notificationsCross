using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notificationCross;
using notificationCross.Droid;

namespace notificationCrossTest
{
    [TestFixture]
    public class NotificationDataTest
    {
        [Test]
        public void TestMethod()
        {
            NotificationData data = new NotificationData(new Person("Zbigniew", "Boniek"), NotificationLevel.High, new GpsLocationAndroid(40, 50));
            TestContext.WriteLine(data.FormatJSONtoString());
            Assert.Pass("Your first passing test");
        }
    }
}
