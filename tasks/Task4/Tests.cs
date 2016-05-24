using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4
{
    [TestFixture]

    public class Tests
    {
        [Test]
        public void TestAddNewNotebook()
        {
            var x = new Notebook("TestManufacturer", "TestModel", 1.1, "TestProcessor", 1, 1, 111m, Currency.EUR);

            Assert.IsTrue(x.Manufacturer == "TestManufacturer");
            Assert.IsTrue(x.Model == "TestModel");
            Assert.IsTrue(x.Display_Size == 1.1);
            Assert.IsTrue(x.Processor == "TestProcessor");
            Assert.IsTrue(x.Memory == 1);
            Assert.IsTrue(x.Capacity == 1);
            Assert.IsTrue(x.Price == 111m);
            Assert.IsTrue(x.Currency == Currency.EUR);
        }

        [Test]
        public void TestCannotCreateNotebookWithEmptyManufactuer()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook("", "TestModel", 1.1, "TestProcessor", 1, 1, 111m, Currency.EUR);
            });
        }

        [Test]
        public void TestCannotCreateNotebookWithEmptyModel()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook("TestManufacturer", null, 1.1, "TestProcessor", 1, 1, 111m, Currency.EUR);
            });
        }

        [Test]
        public void TestDisplaySizeShouldNotBeNegative()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook("TestManufacturer", "TestModel", -10, "TestProcessor", 1, 1, 111m, Currency.EUR);
            });
        }

        [Test]
        public void TestMemoryShouldNotBeNull()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook("TestManufacturer", "TestModel", 1, "TestProcessor", 0, 1, 111m, Currency.EUR);
            });
        }

        [Test]
        public void TestAddNewCoupon()
        {
            var x = new Coupon(100, Currency.EUR);

            Assert.IsTrue(x.Value == 100);
            Assert.IsTrue(x.Currency == Currency.EUR);
        }

        [Test]
        public void TestCanGetCoupon()
        {
            var x = new Coupon(100, Currency.EUR);
            Assert.IsTrue(x.GotCoupon == false);
            x.GoForCoupons();
            Assert.IsTrue(x.GotCoupon == true);
        }

        [Test]
        public void TestCannotGetCouponTwice()
        {
            var x = new Coupon(100, Currency.EUR);
            Assert.IsTrue(x.GotCoupon == false);
            x.GoForCoupons();
            Assert.IsTrue(x.GotCoupon == true);

            try
            {
                x.GoForCoupons();
                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}
