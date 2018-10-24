using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using program1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1          //orderservicetest
    {
        [TestMethod]
        public void ShowListtest()
        {
            List<OrderDetails> testList = new List<OrderDetails>();
            foreach (OrderDetails order in testList)
            {
                Console.WriteLine(order.ToString());
            }
            Assert.IsNotNull(testList);
            Assert.IsNull(testList);
        }
        [TestMethod()]
        public void createordertest()
        {
            List<OrderDetails> testList = new List<OrderDetails>();
            OrderDetails order = new OrderDetails();
            order.num = "0";
            testList.Add(order);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void DeletListTest()
        {
            List<OrderDetails> testList = new List<OrderDetails>();
            testList.RemoveAt(123);
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void ChangeListTest()
        {
            List<OrderDetails> testList = new List<OrderDetails>();
            OrderDetails order = new OrderDetails();
            testList.RemoveAt(12);
            order.num = "12";
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void SearchListTest()
        {
            List<OrderDetails> testList = new List<OrderDetails>();
            OrderDetails order = new OrderDetails();
            order.name = "1234";
            order.num = "123";
            order.price = 1;
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
    }
}
