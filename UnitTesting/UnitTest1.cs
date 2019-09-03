using System;

using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentalApp;
using System.Configuration;



namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        database myData = new database();
        [TestMethod]
        public void TestConnection()
        {
            var actualDataString = myData.connectionString;
            var expectedDataString = @"Data Source=LAPTOP-RSH35OIC\sqlexpress;Initial Catalog=MovieRental;Integrated Security=True";

            Assert.AreEqual(expectedDataString, actualDataString);
        }


        [TestMethod]
        public void AddCustomerTest()
        {
            Form1 myForm = new Form1();
            string name = "Gagan";
            string last = "singh";
            string address = "123 ABC";
            string phone = "123456789";
            var actualdata = myForm.addCust(name, last, address, phone);
            var expecteddata = "Data has been not Inserted";
            Assert.AreNotEqual(expecteddata, actualdata);
        }



    }
}
