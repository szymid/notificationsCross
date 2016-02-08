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
            NotificationData data = new NotificationData(new Person("Zbigniew", "Boniek"), NotificationLevel.High, new GpsLocationAndroid(50.02341678941, 20.5673452123));
            TestContext.WriteLine(data.FormatJSONtoString());
            Assert.Pass("Your first passing test");
        }

        [Test]
        public void NotificationEnumTest()
        {
            Assert.IsInstanceOf<NotificationLevel>((NotificationLevel)Enum.Parse(typeof(NotificationLevel), "Low"));
            TestContext.WriteLine(((NotificationLevel)Enum.Parse(typeof(NotificationLevel), "Low")).ToString());
        }
    }
}
