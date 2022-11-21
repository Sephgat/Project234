using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.SModels;
using Microsoft.EntityFrameworkCore;
using MMABooksContext = MMABooksEFClasses.SModels.MMABooksContext;
using Product = MMABooksEFClasses.SModels.Supplier;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        
        MMABooksContext dbContext;
        Supplier? s;
        List<Supplier>? suppliers;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABooksContext();
            //dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllTest()
        {
            suppliers = dbContext.Suppliers.OrderBy(s => s.SupplierId).ToList();
            Assert.AreEqual(3, suppliers.Count);
            Assert.AreEqual(1, suppliers[0].SupplierId);
        }
        
        [Test]
        public void GetByPrimaryKeyTest()
        {
            s = dbContext.Suppliers.Find(2);
            Assert.IsNotNull(s);
            Assert.AreEqual(2, s.SupplierId);
            Console.WriteLine(s);
        }
        
        [Test]
        public void GetUsingWhere()
        {
            // get a list of all of the products that have a unit price of 56.50
            suppliers = dbContext.Suppliers.Where(s => s.Name.Equals("Willemtte hops co")).OrderBy(s => s.Name).ToList();
            Assert.AreEqual("Willemtte hops co", suppliers[0].Name);
            
        }
       
        [Test]
        public void DeleteTest()
        {
            p = dbContext.Products.Find("ZJLR");
            dbContext.Products.Remove(p);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.States.Find("ZJLR"));
        }

        [Test]
        public void CreateTest()
        {
            s = new Supplier();
            s.Name = "Y2KN";
            s.Address = "Test";
            s.Email = "yayaya@Test";
            s.PhoneNumber = "1234567894";
            dbContext.Suppliers.Add(s);
            dbContext.SaveChanges();
            Assert.IsNotNull(dbContext.Products.Find("Y2KN"));
        }

        [Test]
        public void UpdateTest()
        {
            p = dbContext.Products.Find("ZJLR");
            p.Description = ("ITWORKS");
            dbContext.Products.Update(p);
            dbContext.SaveChanges();
            p = dbContext.Products.Find("ZJLR");
            Assert.IsTrue(p.Description == "ITWORKS");
        }
       */
    }
}